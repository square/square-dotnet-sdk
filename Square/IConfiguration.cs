using System;
using System.Net;
using Square.Models;

namespace Square
{
    public interface IConfiguration
    {
        /// <summary>
        /// Http client timeout
        /// </summary>
        TimeSpan Timeout { get; }

        /// <summary>
        /// Square Connect API versions
        /// </summary>
        string SquareVersion { get; }

        /// <summary>
        /// OAuth 2.0 Access Token
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// Current API environment
        /// </summary>
        Environment Environment { get; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        string GetBaseUri(Server alias = Server.Default);
    }
}