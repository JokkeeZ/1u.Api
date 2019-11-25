using Urlshortener.Api;
using static System.Console;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			using var api = new URLShortener();

			// Send request to 1u.fi endpoint with custom url-parameters.
			// Gets plaintext response and print short url to Console.
			SendPlainTextRequest(api, new ApiRequestParameters
			{
				ApiKey = "YOUR API KEY",
				Url = "URL TO SHORTEN",

				// Optional.
				CustomAlias = "OPTIONAL CUSTOM ALIAS"
			});
		}

		static void SendJsonRequest(URLShortener api, ApiRequestParameters parameters)
		{
			var response = api.GetJsonResponse(parameters);

			if (response != null)
			{
				WriteLine(response.Error == 1 ? response.ErrorMessage : response.ShortUrl);
			}
		}

		static void SendPlainTextRequest(URLShortener api, ApiRequestParameters parameters)
		{
			var response = api.GetTextResponse(parameters);

			if (response != null)
			{
				WriteLine(response);
			}
		}
	}
}
