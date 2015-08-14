using System;

namespace Serial_Temperature
{
  public class Entry
  {
    public DateTime Time { get; set; }
    public float Temperature { get; set; }

    public Entry()
    {
      
    }

    public Entry(DateTime time, float temperature)
    {
      Time = time;
      Temperature = temperature;
    }

    public Entry(float temperature) : this(DateTime.Now, temperature)
    {
    }

    public string ExcelEntry
    {
      get { return string.Format("{0},{1}{2}", Time, Temperature, Environment.NewLine); }
    }

    public string TimeEntry
    {
      get { return string.Format("{0:hh:mm:ss} -- {1}", Time, Temperature); }
    }
  }
}
