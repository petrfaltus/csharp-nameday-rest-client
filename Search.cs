using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Newtonsoft.Json;

namespace NameDayRestClient
{
    static class Search
    {
        private static readonly string URL_ADDRESS = "http://api.petrfaltus.net/name_day/json/1.0";
        private static readonly string WEB_REQUEST_FAILED = "The web request to the REST service failed";
        private static readonly Encoding encoding = Encoding.UTF8;

        private static string lastError = null;
        private static Dictionary<string, string> countries = null;

        public static string run(string query)
        {
            lastError = null; // await no errors

            // the web client
            WebClient client = new WebClient();
            client.Encoding = encoding;

            string restRequestJson;
            string restReplyJson;

            if (countries == null)
            {
                // the first request (supported countries)
                RestRequest1 restRequest1 = new RestRequest1();

                restRequestJson = JsonConvert.SerializeObject(restRequest1);
                try
                {
                    restReplyJson = client.UploadString(URL_ADDRESS, restRequestJson);
                }
                catch (Exception)
                {
                    lastError = WEB_REQUEST_FAILED;
                    return null;
                }
                RestReply1 restReply1 = JsonConvert.DeserializeObject<RestReply1>(restReplyJson);

                if (restReply1.error_code != 0)
                {
                    lastError = restReply1.error_string;
                    return null;
                }

                countries = restReply1.data;
            }

            // prepare the second request (one country)
            RestRequest2 restRequest2 = new RestRequest2();
            restRequest2.query = query;

            string result = "";

            foreach(KeyValuePair<string, string> country in countries)
            {
                // for every country complete the second request
                restRequest2.country = country.Key;

                restRequestJson = JsonConvert.SerializeObject(restRequest2);
                try
                {
                    restReplyJson = client.UploadString(URL_ADDRESS, restRequestJson);
                }
                catch (Exception)
                {
                    lastError = WEB_REQUEST_FAILED;
                    return null;
                }
                RestReply2 restReply2 = JsonConvert.DeserializeObject<RestReply2>(restReplyJson);

                result += string.Format("{0} ... {1}\n", country.Value, restReply2.error_string);

                if (restReply2.error_code == 0)
                {
                    foreach (string line in restReply2.data)
                    {
                        // for every line of the returned data
                        result += "- " + line;
                        result += Environment.NewLine;
                    }
                }

                result += Environment.NewLine;
            }

            return result;
        }

        public static string getLastError()
        {
            return lastError;
        }
    }
}
