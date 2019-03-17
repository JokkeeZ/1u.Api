using System.Net;
using Newtonsoft.Json;

namespace Urlshortener.Api
{
	/// <summary>
	/// API wrapper for 1u.fi API using Newtonsoft.Json library.
	/// </summary>
	public class URLShortener
	{
		/// <summary>
		/// Parses JSON string from server response.
		/// </summary>
		/// <param name="parameters">Custom parameters for inititializing request. (APIKey and Url needed always)</param>
		/// <returns>New <see cref="ApiJsonResponse"/> object from server response.</returns>
		public ApiJsonResponse GetJsonResponse(ApiRequestParameters parameters)
		{
			var url = CreateUrlForRequest(parameters);

			using (var client = new WebClient())
			{
				var json = client.DownloadString(url);
				return JsonConvert.DeserializeObject<ApiJsonResponse>(json);
			}
		}

		/// <summary>
		/// Parses string from server response.
		/// </summary>
		/// <param name="parameters">Custom parameters for inititializing request. (APIKey and Url needed always)</param>
		/// <returns>New <see cref="APITextResponse"/> object from server response.</returns>
		public ApiTextResponse GetTextResponse(ApiRequestParameters parameters)
		{
			var url = CreateUrlForRequest(parameters);
			url += "&format=text";

			using (var client = new WebClient())
			{
				var plaintext = client.DownloadString(url);
				return new ApiTextResponse { ShortUrl = plaintext };
			}
		}

		private string CreateUrlForRequest(ApiRequestParameters parameters)
		{
			var url = $"http://1u.fi/api?api={parameters.ApiKey}&url={parameters.Url}";

			if (parameters.ApiKey == null)
				throw new ApiParameterException("APIKey parameter is required for the request.");

			if (parameters.Url == null)
				throw new ApiParameterException("Url parameter is required for the request.");

			if (!string.IsNullOrWhiteSpace(parameters.CustomAlias))
				url += $"&custom={parameters.CustomAlias}";

			return url;
		}
	}
}
