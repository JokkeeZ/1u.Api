using System;
using System.Net;
using Newtonsoft.Json;

namespace Urlshortener.Api
{
	/// <summary>
	/// API wrapper for <see href="https://1u.fi/"/> API, using Newtonsoft.Json library.
	/// </summary>
	public class URLShortener : IDisposable
	{
		private readonly WebClient client;

		/// <summary>
		/// Initializes an new instance of the <see cref="URLShortener"/> class.
		/// </summary>
		public URLShortener() => client = new WebClient();

		/// <summary>
		/// Gets response in json, and parses it to new <see cref="ApiJsonResponse"/> object.
		/// </summary>
		/// <param name="parameters">Custom parameters for inititializing request. (APIKey and Url needed always)</param>
		/// <returns>New <see cref="ApiJsonResponse"/> object from API endpoint response.</returns>
		public ApiJsonResponse GetJsonResponse(ApiRequestParameters parameters)
		{
			var url = CreateUrlForRequest(parameters);

			var json = client.DownloadString(url);
			return JsonConvert.DeserializeObject<ApiJsonResponse>(json);
		}

		/// <summary>
		/// Gets response in plaintext, and parses it to <see cref="string"/>.
		/// </summary>
		/// <param name="parameters">Custom parameters for inititializing request. (APIKey and Url needed always)</param>
		/// <returns>API endpoint response as string.</returns>
		public string GetTextResponse(ApiRequestParameters parameters)
		{
			var url = CreateUrlForRequest(parameters) + "&format=text";
			return client.DownloadString(url);
		}

		static string CreateUrlForRequest(ApiRequestParameters parameters)
		{
			var url = $"http://1u.fi/api?api={parameters.ApiKey}&url={parameters.Url}";

			if (parameters.ApiKey == null)
			{
				throw new ArgumentNullException("APIKey parameter is required for the request.");
			}

			if (parameters.Url == null)
			{
				throw new ArgumentNullException("Url parameter is required for the request.");
			}

			if (!string.IsNullOrWhiteSpace(parameters.CustomAlias))
			{
				url += $"&custom={parameters.CustomAlias}";
			}

			return url;
		}

		/// <summary>
		/// Releases all resources used by the current <see cref="URLShortener"/> instance.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				client?.Dispose();
			}
		}
	}
}
