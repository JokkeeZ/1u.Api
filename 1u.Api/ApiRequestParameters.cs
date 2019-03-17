namespace Urlshortener.Api
{
	/// <summary>
	/// Represents parameters for initializing request to 1u.fi API endpoint.
	/// </summary>
	public struct ApiRequestParameters
	{
		/// <summary>
		/// Url to be shortened.
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Unique user own API-key for accessing 1u.fi API endpoint.
		/// </summary>
		public string ApiKey { get; set; }

		/// <summary>
		/// Custom alias for creating custom ending shorturls.
		/// </summary>
		public string CustomAlias { get; set; }
	}
}
