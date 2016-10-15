namespace Bitly.fi.API
{
    /// <summary>
    /// Contains values from server response to JSON request.
    /// </summary>
    public class APIJsonResponse
    {
        /// <summary>
        /// Incase there was an error creating shorturl, true, otherwise false.
        /// </summary>
        public bool Error { get; internal set; } = false;

        /// <summary>
        /// Shorturl from server response.
        /// </summary>
        public string ShortUrl { get; internal set; }

        /// <summary>
        /// If there was an error, contains errormessage, else just empty string.
        /// </summary>
        public string ErrorMsg { get; internal set; } = string.Empty;
    }
}
