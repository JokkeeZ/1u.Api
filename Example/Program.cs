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

            // Send json request
            JsonRequest(parameters);

            // Send plaintext request
            PlainTextRequest(parameters);
        }

        static void JsonRequest(APIRequestParameters parameters)
        {
            // Needs to be false for JSON response.
            parameters.Text = false;

            var response = bitlyfi.GetJsonResponse(parameters);

            // There was an error.
            if (response.Error)
            {
                // Write error message to Console buffer.
                WriteLine(response.ErrorMsg);
            }
            else
            {
                // Write created short url to Console buffer.
                WriteLine(response.ShortUrl);
            }
        }

        static void PlainTextRequest(APIRequestParameters parameters)
        {
            // Needs to be true for plaintext response.
            parameters.Text = true;

            var response = bitlyfi.GetTextResponse(parameters);
            WriteLine(response.ShortUrl);
        }
    }
}
