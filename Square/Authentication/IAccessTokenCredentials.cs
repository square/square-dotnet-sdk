using System;

namespace Square.Authentication
{
    public interface IAccessTokenCredentials
    {
        /// <summary>
        /// This returns the access token currently stored
        /// </summary>
        /// <param></param>
        /// <return> Returns AccessToken </return>
        string AccessToken { get; }
    }
}