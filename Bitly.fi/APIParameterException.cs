using System;

namespace Bitly.fi.API
{
    /// <summary>
    /// Represents errors that occur during sending request to Bitly.fi server.
    /// </summary>
    [Serializable]
    public class APIParameterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <seealso cref="APIParameterException"/> with a specified error message.
        /// </summary>
        /// <param name="message">Error message to be printed on exception.</param>
        public APIParameterException(string message) : base(message) { }
    }
}
