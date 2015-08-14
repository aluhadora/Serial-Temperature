using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
      int numOfLines = Math.Max(lines.Count() - 2000, 0);
      var newLines = lines.Skip(numOfLines);

      logTextBox.Lines = newLines.ToArray();
    }

    private void DisposeReader(object sender, FormClosingEventArgs e)
    {
      _reader.Dispose();
    }

    private void ZeroCheckBoxChanged(object sender, EventArgs e)
    {
     if (zeroCheckBox.Checked) chart1.ChartAreas[0].AxisY.Minimum = 0;
     else
     {
       chart1.ChartAreas[0].AxisY.Minimum = Math.Floor(chart1.Series[0].Points.Min(x => x.YValues[0])/10)*10;
     }
    }

    private void splineCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      chart1.Series[0].ChartType = splineCheckBox.Checked ? SeriesChartType.Spline : SeriesChartType.Line;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var points = chart1.Series[0].Points.ToList();
      var lines = File.ReadAllLines("test.csv");
      foreach (var line in lines)
      {
        if (line.Count(x => x == ',') != 1) continue;
        var parts = line.Split(',');
        DateTime date;
        float t;
        if (!DateTime.TryParse(parts[0], out date)) continue;
        if (!float.TryParse(parts[1], out t)) continue;

        chart1.Series[0].Points.AddXY(date, t);
      }

      chart1.DataManipulator.Sort(PointSortOrder.Ascending, "X", "Temperature");

      logTextBox.Clear();
      foreach (var point in chart1.Series[0].Points)
      {
        DateTime date;
        float t;
        if (!DateTime.TryParse(point[0], out date)) continue;
        if (!float.TryParse(point[1], out t)) continue;

        var entry = new Entry(date, t);
        Log(entry.TimeEntry);
      }

      Log("Loaded from file");
    }
  }
}
