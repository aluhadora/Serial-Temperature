using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Serial_Temperature
{
  public class PlotlyWriter
  {
    public async void TestOld()
    {
      var client = new HttpClient {BaseAddress = new Uri("http://stream.plot.ly")};
            // Add an Accept header for JSON format.
      //client.DefaultRequestHeaders.Accept.Add(
      //  new MediaTypeWithQualityHeaderValue("application/json"));
      client.DefaultRequestHeaders.Add("plotly-streamtoken", "3zhjitcvb5");
      var openPost = new { x = new List<float>().ToArray(), y = new List<float>().ToArray(), type = "scatter", mode = "markers", stream = new { token = "3zhjitcvb5", maxpoints = 500 } };

      var test  = JsonConvert.SerializeObject(openPost, Formatting.Indented);

      MediaTypeFormatter formatter = new JsonMediaTypeFormatter { Indent =  true};
      var response = await client.PostAsJsonAsync("", openPost);
      if (response.IsSuccessStatusCode)
      {
        // Get the URI of the created resource.
        Uri gizmoUrl = response.Headers.Location;
      }
    }
    public async void Test()
    {
      return;
      var client = new HttpClient {BaseAddress = new Uri("https://plot.ly/clientresp")};
            // Add an Accept header for JSON format.
      //client.DefaultRequestHeaders.Accept.Add(
      //  new MediaTypeWithQualityHeaderValue("application/json"));
      client.DefaultRequestHeaders.Add("plotly-streamtoken", "3zhjitcvb5");
      var openPost =
        new
        {
          un = "aluhadora",
          key = "1a0vln1uto",
          origin = "plot",
          platform = "C#",
          args = new [] { 1 },
          kwargs = new
          {
            filename = "filename",
            fileopt = "append"
          },
          x = new List<float>().ToArray(),
          y = new List<float>().ToArray(),
          type = "scatter",
          mode = "markers",
          stream = new {token = "3zhjitcvb5", maxpoints = 500}
        };

      var test  = JsonConvert.SerializeObject(openPost, Formatting.Indented);

      MediaTypeFormatter formatter = new JsonMediaTypeFormatter { Indent =  true};
      var response = await client.PostAsync("", test, formatter);
      if (response.IsSuccessStatusCode)
      {
        // Get the URI of the created resource.
        Uri gizmoUrl = response.Headers.Location;

        var test2 = "{ \"y\": 3 }\n";

        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("54.152.190.107"), 80);

        var s = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream, ProtocolType.Tcp);
        s.Connect(ipep);

        SendVarData(s, Encoding.ASCII.GetBytes(test2));
      }
    }

    private static int SendVarData(Socket s, byte[] data)
    {
      int total = 0;
      int size = data.Length;
      int dataleft = size;
      int sent;

      byte[] datasize = new byte[4];
      datasize = BitConverter.GetBytes(size);
      sent = s.Send(datasize);

      while (total < size)
      {
        sent = s.Send(data, total, dataleft, SocketFlags.None);
        total += sent;
        dataleft -= sent;
      }
      return total;
    }
  }
}
