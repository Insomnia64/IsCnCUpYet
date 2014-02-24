using System;
using System.Net;
using System.Threading;

namespace IsCnCUpYet
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string html = GetHtml("http://www.candccentral.co.uk");
                if (html != "InternalServerError")
                {
                    while (true)
                    {
                        Console.Beep();
                        Console.WriteLine("It's up!");
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public static string GetHtml(string url)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    return client.DownloadString(url);
                }
                catch (WebException we) //catch error
                {
                    return ((HttpWebResponse)we.Response).StatusCode.ToString();
                }
            }
        }
    }
}
