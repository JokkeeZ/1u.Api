namespace Bitly.fi.API
{
    /// <summary>
    /// Contains values from server response to plaintext request.
    /// </summary>
    public class APITextResponse
    {
        /// <summary>
        /// Shorturl from server response.
        /// </summary>
        public string ShortUrl { get; internal set; }
    }
}
