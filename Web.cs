using System.Net;
using System.Text;

namespace NameDayRestClient
{
    public class Web
    {
        private static readonly string URL_ADDRESS = "http://api.petrfaltus.net/name_day/json/1.0";
        private static readonly Encoding encoding = Encoding.UTF8;
        private static readonly string USER_AGENT = "Petr Faltus C# Name day REST client";

        private static WebClient client = null;

        public static string Request(string input)
        {
            if (client == null)
            {
                // the web client
                client = new WebClient();
                client.Encoding = encoding;
                client.Headers.Add("user-agent", USER_AGENT);
            }

            string output = client.UploadString(URL_ADDRESS, input);

            return output;
        }
    }
}
