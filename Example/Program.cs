using Los.fi.Api;
using static System.Console;

namespace Example
{
	class Program
	{
		static LosApi api;

		static void Main(string[] args)
		{
			// Create new LosApi object for api requests.
			api = new LosApi();

			// Send request to Los.fi server with custom url-parameters.
			var parameters = new ApiRequestParameters()
			{
				ApiKey = "APIKEY",
				Url = "URL TO BE SHORTENED",

				// Optional.
				CustomAlias = "This_is_my_custom_alias"
			};

			// Get plaintext request and print short url to console.
			PlainTextRequest(parameters);
		}

		static void JsonRequest(ApiRequestParameters parameters)
		{
			var response = api.GetJsonResponse(parameters);

			if (response != null)
			{
				WriteLine(response.Error == 1 ? response.ErrorMessage : response.ShortUrl);
			}
		}

		static void PlainTextRequest(ApiRequestParameters parameters)
		{
			var response = api.GetTextResponse(parameters);

			if (response != null)
			{
				WriteLine(response.ShortUrl);
			}
		}
	}
}
