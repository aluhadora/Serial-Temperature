using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Serial_Temperature
{
  public partial class TemperatureForm : Form
  {
    private ArduinoReader _reader;

    public TemperatureForm()
    {
      InitializeComponent();
    }

    private void FormLoaded(object sender, EventArgs e)
    {
      _reader = new ArduinoReader("COM3");
      _reader.StringRead += Read;

      new PlotlyWriter().Test();
    }

    private float? _lastT;

    private void Read(string value)
    {
      float t;
      if (!float.TryParse(value, out t))
      {
        Log("Error parsing string(" + value + ")");
      }

      if (_lastT == t && Entries > 5) return;
      _lastT = t;

      var entry = new Entry(t);
      Log(entry);
    }

    protected int Entries
    {
      get { return logTextBox.Lines.Length; }
    }

    private void Log(Entry entry)
    {
      DeleteOldLogEntries();
      Log(entry.TimeEntry);
      File.AppendAllText("test.csv", entry.ExcelEntry);
      Graph(entry);
      FillTitle(entry);
    }

    private void FillTitle(Entry entry)
    {
      Text = string.Format("Current Temperature: {0:0.00} °F", entry.Temperature);
    }

    private void Graph(Entry entry)
    {
      chart1.Series[0].Points.AddXY(entry.Time, entry.Temperature);
    }

    private void Log(string value)
    {
      DeleteOldLogEntries();
      logTextBox.AppendText(value);
      logTextBox.AppendText(Environment.NewLine);
    }

    private void DeleteOldLogEntries()
    {
      var lines = logTextBox.Lines;
      int numOfLines = Math.Max(lines.Count() - 200, 0);
      var newLines = lines.Skip(numOfLines);

      logTextBox.Lines = newLines.ToArray();
    }

    private void DisposeReader(object sender, FormClosingEventArgs e)
    {
      _reader.Dispose();
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
     if (checkBox1.Checked) chart1.ChartAreas[0].AxisY.Minimum = 0;
     else
     {
       chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(chart1.Series[0].Points.Min(x => x.YValues[0])/10)*10;
     }
    }
  }
}
