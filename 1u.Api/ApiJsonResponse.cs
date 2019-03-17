using Newtonsoft.Json;

namespace Urlshortener.Api
{
	/// <summary>
	/// Represents values from server response to json request.
	/// </summary>
	public class ApiJsonResponse : IApiResponse
	{
		/// <summary>
		/// Incase there was an error creating shorturl 1; otherwise 0.
		/// </summary>
		[JsonProperty("error")]
		public int Error { get; internal set; }

		/// <summary>
		/// Short url from server response.
		/// </summary>
		[JsonProperty("short")]
		public string ShortUrl { get; internal set; }

		/// <summary>
		/// Incase there was an error, contains error message; otherwise null.
		/// </summary>
		[JsonProperty("msg")]
		public string ErrorMessage { get; internal set; }
	}
}
