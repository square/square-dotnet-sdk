using System;

namespace Square.Authentication
{
    public interface IAccessTokenCredentials
    {
        /// <summary>
        /// Getter for accessToken
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        bool Equals(string accessToken);
    }
}