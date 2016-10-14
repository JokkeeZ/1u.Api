namespace Bitly.fi.API
{
    /// <summary>
    /// Contains values from response to JSON request.
    /// </summary>
    public class APIJsonResponse
    {
        /// <summary>
        /// Incase there was an error creating short url, value becames true, otherwise false.
        /// </summary>
        public bool Error { get; internal set; }

        /// <summary>
        /// Short url from server response.
        /// </summary>
        public string ShortUrl { get; internal set; }

        /// <summary>
        /// If there was an error, contains error message, else just empty string.
        /// </summary>
        public string ErrorMsg { get; internal set; } = "";
    }
}
