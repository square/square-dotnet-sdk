namespace Square.Authentication
{
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Square.Http.Request;

/// <summary>
/// BearerAuthManager.
/// </summary>
internal class BearerAuthManager : IBearerAuthCredentials, IAuthManager
{
        /// <summary>
        /// Initializes a new instance of the <see cref="BearerAuthManager"/> class.
        /// </summary>
        /// <param name="accessToken">accessToken.</param>
        public BearerAuthManager(string accessToken)
        {
            this.AccessToken = accessToken;
        }

        /// <summary>
        /// Gets accessToken.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="accessToken"> AccessToken.</param>
        /// <returns> The boolean value.</returns>
        public bool Equals(string accessToken)
        {
            return accessToken.Equals(this.AccessToken);
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest.
        /// </summary>
        /// <param name="httpRequest">Http Request.</param>
        /// <returns>Returns the httpRequest after adding authentication.</returns>
        public HttpRequest Apply(HttpRequest httpRequest)
        {
            httpRequest.Headers["Authorization"] = "Bearer " + this.AccessToken;
            return httpRequest;
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest.
        /// </summary>
        /// <param name="httpRequest">Http Request.</param>
        /// <returns>Returns the httpRequest after adding authentication.</returns>
        public Task<HttpRequest> ApplyAsync(HttpRequest httpRequest)
        {
            httpRequest.Headers["Authorization"] = "Bearer " + this.AccessToken;
            return Task.FromResult(httpRequest);
        }
    }
}