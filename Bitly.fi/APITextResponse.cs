namespace Bitly.fi.API
{
    /// <summary>
    /// Contains values from response to plain text request.
    /// </summary>
    public class APITextResponse
    {
        /// <summary>
        /// Short url from server response.
        /// </summary>
        public string ShortUrl { get; internal set; }
    }
}
