namespace Square
{
    using System;
    using System.Net;
    using Square.Authentication;
    using Square.Models;

    /// <summary>
    /// IConfiguration.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Gets Square Connect API versions
        /// </summary>
        string SquareVersion { get; }

        /// <summary>
        /// Gets Current API environment.
        /// </summary>
        Environment Environment { get; }

        /// <summary>
        /// Gets Sets the base URL requests are made to. Defaults to `https://connect.squareup.com`
        /// </summary>
        string CustomUrl { get; }

        /// <summary>
        /// Gets the OAuth 2.0 Access Token.
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        string GetBaseUri(Server alias = Server.Default);
    }
}