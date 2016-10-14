namespace Bitly.fi.API
{
    /// <summary>
    /// Represents parameters for initializing request to Bitly.fi API endpoint.
    /// </summary>
    public class APIRequestParameters
    {
        /// <summary>
        /// Long url to be shortened.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Unique users own API-key for accessing Bitly.fi API endpoint.
        /// </summary>
        public string APIKey { get; set; }

        /// <summary>
        /// Custom alias for creating custom ending short urls.
        /// </summary>
        public string CustomAlias { get; set; }

        /// <summary>
        /// Controls server response type, default value is false for JSON response, otherwise response will be plain text.
        /// </summary>
        public bool Text { get; set; } = false;

        /// <summary>
        /// Initializes new instance of <seealso cref="APIRequestParameters"/> with default values.
        /// </summary>
        public APIRequestParameters() { }
    }
}
