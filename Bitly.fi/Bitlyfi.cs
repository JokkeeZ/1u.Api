using System.Net;
using Newtonsoft.Json.Linq;

namespace Bitly.fi.API
{
    /// <summary>
    /// API wrapper for Bitly.fi API using Newtonsoft.Json library.
    /// </summary>
    public class Bitlyfi
    {
        internal const string URL = "http://bitly.fi/api?api={0}&url={1}";

        /// <summary>
        /// Initializes new instance of <seealso cref="Bitlyfi"/> API wrapper.
        /// </summary>
        public Bitlyfi() { }

        /// <summary>
        /// Parses JSON string from server response.
        /// </summary>
        /// <param name="parameters">Custom parameters for inititializing request. (APIKey and Url needed always, Text parameter needs to be false.)</param>
        /// <returns>New <seealso cref="APIJsonResponse"/> object from server response.</returns>
        public APIJsonResponse GetJsonResponse(APIRequestParameters parameters)
        {
            if (parameters == null)
                throw new APIParameterException("Parameters needs to be set for valid request.");

            if (parameters.APIKey == null)
                throw new APIParameterException("APIKey parameter is required for request.");

            if (parameters.Url == null)
                throw new APIParameterException("Url parameter is required for request.");

            if (parameters.Text)
                throw new APIParameterException("Use GetTextResponse() method instead for text response.");

            using (var client = new WebClient())
            {
                var finalUrl = string.Format(URL + "{2}", parameters.APIKey, parameters.Url,
                    ((parameters.CustomAlias != null) ? $"&custom={parameters.CustomAlias}" : ""));

                var json = client.DownloadString(finalUrl);
                var jObject = JObject.Parse(json);

                var response = new APIJsonResponse();
                response.Error = ((int)jObject["error"] == 1);

                if (response.Error)
                    response.ErrorMsg = (string)jObject["msg"];
                else
                    response.ShortUrl = (string)jObject["short"];

                return response;
            }
        }

        /// <summary>
        /// Parses string from server response.
        /// </summary>
        /// <param name="parameters">Custom parameters for inititializing request. (APIKey and Url needed always, Text parameter needs to be true.)</param>
        /// <returns>New <seealso cref="APITextResponse"/> object from server response.</returns>
        public APITextResponse GetTextResponse(APIRequestParameters parameters)
        {
            if (parameters == null)
                throw new APIParameterException("Parameters needs to be set for valid request.");

            if (parameters.APIKey == null)
                throw new APIParameterException("APIKey parameter is required for request.");

            if (parameters.Url == null)
                throw new APIParameterException("Url parameter is required for request.");

            if (parameters.Text != true)
                throw new APIParameterException("Text parameter needs to be 'true' for text response.");

            using (var client = new WebClient())
            {
                var finalUrl = string.Format(URL + "{2}&format=text", parameters.APIKey, parameters.Url,
                    ((parameters.CustomAlias != null) ? $"&custom={parameters.CustomAlias}" : ""));

                var data = client.DownloadString(finalUrl);
                return new APITextResponse()
                {
                    ShortUrl = data
                };
            }
        }
    }
}
