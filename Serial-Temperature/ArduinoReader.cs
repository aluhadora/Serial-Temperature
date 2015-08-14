using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Serial_Temperature
{
  public class ArduinoReader : IDisposable
  {
    private Timer _timer;
    private SerialPort Port { get; set; }
    public event Action<string> StringRead;
    
    public ArduinoReader(string com, int baud = 9600)
    {
      Port = new SerialPort(com, baud, Parity.None);
      Port.Open();
      _timer = new Timer {Interval = 1000};
      _timer.Tick += Tick;
      _timer.Start();
    }

    private string _working = string.Empty;

    private void Tick(object sender, EventArgs e)
    {
      if (!Port.IsOpen || StringRead == null) return;
      var buffer = new char[200];
      Port.Read(buffer, 0, 200);
      //StringRead(Convert.ToSingle(new string(buffer)));
      var s = new string(buffer);
      _working += s.Trim('\0');
      if (!_working.Contains("\n")) return;
      var splits = _working.Split('\n');
      for (int i = 0; i < splits.Length - 1; i++)
      {
        StringRead(splits[i].Trim('\0').Trim());
      }
      _working = splits[splits.Length - 1];
    }

    public void Close()
    {
      _timer.Stop();
      Port.Close();
    }

    #region Implementation of IDisposable

    public void Dispose()
    {
      Close();
      _timer = null;
      Port = null;
    }

    #endregion
  }
}
