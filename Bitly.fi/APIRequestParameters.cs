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
        /// Custom alias for creating custom ending shorturls.
        /// </summary>
        public string CustomAlias { get; set; }

        /// <summary>
        /// Initializes new instance of <see cref="APIRequestParameters"/> with default values.
        /// </summary>
        public APIRequestParameters() { }
    }
}
