using System.Net;

namespace Lection11Program9;
class Program
{
    static string OpenSite(string uri)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
              return reader.ReadToEnd();    
            }
        }
    }

    static  void Main(string[] args)
    {
        Console.WriteLine(OpenSite("https://yandex.ru"));
    }
}

