namespace Square.Authentication
{
    using System;

    public interface IBearerAuthCredentials
    {
        /// <summary>
        /// Gets accessToken.
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        bool Equals(string accessToken);
    }
}