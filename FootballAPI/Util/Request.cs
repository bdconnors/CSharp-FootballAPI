using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FootballAPI.Util
{
    class Request
    {
        private string season = null;
        private static string BaseReqString = "https://api.mysportsfeeds.com/v1.0/pull/nfl/";

        /// <summary>
        /// Constructs a ApiRequest object using the specified season year for requests
        /// </summary>
        /// <param name="season">Contains a specific NFL season year (i.e. 2016)</param>
        public Request(string season, bool regularSeason)
        {
            this.season = season;
            if (regularSeason == true)
            {
                BaseReqString += season + "-regular";
            }
            else
            {
                BaseReqString += season + "-playoff";
            }

        }      
        /// <summary>
        /// Constructs a ApiRequest object using the current season year for requests
        /// </summary>
        public Request(bool regularSeason)
        {
            this.season = DateTime.Now.Year.ToString();
            if (regularSeason == true)
            {
                BaseReqString += season + "-regular";
            }
            else
            {
                BaseReqString += season + "-playoff";
            }
        }
        /// <summary>
        /// Issues HTTP request to MySportsFeeds.com and returns a String containing Json response
        /// </summary>
        /// <param name="ReqString">Contains a MySportsFeeds.com HTTP request URL</param>
        /// <returns>async Task<string> Containing result of the request</returns>
        public async Task<string> Submit(string ReqString)
        {
            byte[] key = Encoding.ASCII.GetBytes("b4b138b1-909e-4ffa-80ee-baccda:iste330");
            string url = BaseReqString + ReqString;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(key));
            request.Method = "GET";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string JsonString = reader.ReadToEnd();
                    return JsonString;
                }
            }
        }
    }
}
