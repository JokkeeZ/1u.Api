namespace Urlshortener.Api
{
	/// <summary>
	/// Represents values from endpoint response.
	/// </summary>
	public interface IApiResponse
	{
		/// <summary>
		/// Short url from endpoint response.
		/// </summary>
		string ShortUrl { get; }
	}
}
