using System;
using System.Net;

/// <summary>
/// Kensored API namespace
/// </summary>
namespace KensoredAPI
{
    /// <summary>
    /// Web client extended
    /// </summary>
    internal class WebClientEx : WebClient
    {
        /// <summary>
        /// Timeout
        /// </summary>
        private readonly int timeout;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="timeout">Timeout</param>
        public WebClientEx(int timeout)
        {
            this.timeout = timeout;
        }

        /// <summary>
        /// Get web request
        /// </summary>
        /// <param name="uri">URI</param>
        /// <returns>Web request</returns>
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = timeout;
            return w;
        }
    }
}
