namespace Urlshortener.Api
{
	/// <summary>
	/// Represents values from server response.
	/// </summary>
	public interface IApiResponse
	{
		/// <summary>
		/// Short url from server response.
		/// </summary>
		string ShortUrl { get; }
	}
}
