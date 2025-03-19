using System;

namespace Square.Legacy.Authentication
{
    /// <summary>
    /// Authentication configuration interface for BearerAuth.
    /// </summary>
    public interface IBearerAuthCredentials
    {
        /// <summary>
        /// Gets string value for accessToken.
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="accessToken"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string accessToken);
    }
}
