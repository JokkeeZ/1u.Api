using System;

namespace Urlshortener.Api
{
	/// <summary>
	/// Represents errors that occur during sending request to 1u.fi server.
	/// </summary>
	[Serializable]
	public class ApiParameterException : Exception
	{
		/// <summary>
		/// Initializes an new instance of <see cref="ApiParameterException"/> with a specified error message.
		/// </summary>
		/// <param name="message">Error message thrown by exception.</param>
		public ApiParameterException(string message) : base(message) { }
	}
}
