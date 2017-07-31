namespace Los.fi.Api
{
	/// <summary>
	/// Represents values from server response to plaintext request.
	/// </summary>
	public class ApiTextResponse : IApiResponse
	{
		/// <summary>
		/// Short url from server response.
		/// </summary>
		public string ShortUrl { get; internal set; }
	}
}
