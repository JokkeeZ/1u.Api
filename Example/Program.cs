using Bitly.fi.API;
using static System.Console;

namespace Example
{
    class Program
    {
        static Bitlyfi bitlyfi;

        static void Main(string[] args)
        {
            // Create new Bitlyfi object for api requests.
            bitlyfi = new Bitlyfi();

            // Send request to Bitly.fi server with custom url-parameters.
            var parameters = new APIRequestParameters()
            {
                APIKey = "APIKEY",
                Url = "URL TO BE SHORTENED"
            };

            // Send plaintext request
            PlainTextRequest(parameters);
        }

        static void JsonRequest(APIRequestParameters parameters)
        {
            var response = bitlyfi.GetJsonResponse(parameters);
            WriteLine(((response.Error) ? response.ErrorMsg : response.ShortUrl));
        }

        static void PlainTextRequest(APIRequestParameters parameters)
        {
            var response = bitlyfi.GetTextResponse(parameters);
            WriteLine(response.ShortUrl);
        }
    }
}
