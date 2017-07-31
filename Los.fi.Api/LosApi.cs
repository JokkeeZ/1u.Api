using System.Net;
using Newtonsoft.Json;

namespace Los.fi.Api
{
	/// <summary>
	/// API wrapper for Los.fi API using Newtonsoft.Json library.
	/// </summary>
	public class LosApi
	{
		/// <summary>
		/// Parses JSON string from server response.
		/// </summary>
		/// <param name="parameters">Custom parameters for inititializing request. (APIKey and Url needed always)</param>
		/// <returns>New <see cref="ApiJsonResponse"/> object from server response.</returns>
		public ApiJsonResponse GetJsonResponse(ApiRequestParameters parameters)
		{
			var url = CreateUrlForRequest(parameters);
			if (url == null) return null;

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
			if (url == null) return null;

			url += "&format=text";

			using (var client = new WebClient())
			{
				var plaintext = client.DownloadString(url);
				return new ApiTextResponse { ShortUrl = plaintext };
			}
		}

		private string CreateUrlForRequest(ApiRequestParameters parameters)
		{
			var url = $"http://los.fi/api?api={parameters.ApiKey}&url={parameters.Url}";

			if (parameters.ApiKey == null)
				throw new ApiParameterException("APIKey parameter is required for request.");

			if (parameters.Url == null)
				throw new ApiParameterException("Url parameter is required for request.");

			if (!string.IsNullOrWhiteSpace(parameters.CustomAlias))
				url += $"&custom={parameters.CustomAlias}";

			return url;
		}
	}
}
