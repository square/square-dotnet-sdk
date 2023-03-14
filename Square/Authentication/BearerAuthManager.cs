namespace Square.Authentication
{
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Square.Http.Request;
using APIMatic.Core.Authentication;

/// <summary>
/// BearerAuthManager.
/// </summary>
internal class BearerAuthManager : AuthManager, IBearerAuthCredentials
{
        /// <summary>
        /// Initializes a new instance of the <see cref="BearerAuthManager"/> class.
        /// </summary>
        /// <param name="accessToken">accessToken.</param>
        public BearerAuthManager(string accessToken)
        {
            this.AccessToken = accessToken;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("Authorization", "Bearer " + this.AccessToken)));
        }

        /// <summary>
        /// Gets string value for accessToken.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="accessToken"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string accessToken)
        {
            return accessToken.Equals(this.AccessToken);
        }

    }
}