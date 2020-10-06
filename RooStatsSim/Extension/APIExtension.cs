using System;
using System.IO;
using System.Net;

namespace RooStatsSim.Extension
{
    class APIExtension
    {
        public APIExtension()
        { }

        public static string callWebClient(string targetURL)
        {
            string result = string.Empty;
            try
            {
                WebClient client = new WebClient();

                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                using (Stream data = client.OpenRead(targetURL))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string s = reader.ReadToEnd();
                        result = s;

                        reader.Close();
                        data.Close();
                    }
                }

            }
            catch (Exception e)
            {
                //통신 실패시 처리로직
                Console.WriteLine(e.ToString());
            }
            return result;
        }
    }
}
