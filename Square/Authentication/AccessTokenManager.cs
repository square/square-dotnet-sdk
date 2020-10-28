using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Square.Http.Request;

namespace Square.Authentication
{
     internal class AccessTokenManager : IAccessTokenCredentials, IAuthManager
     {
        /// <summary>
        /// Constructor
        /// </summary>
        public AccessTokenManager(string accessToken)
        {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Getter for accessToken
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        public bool Equals(string accessToken) {
            return accessToken.Equals(AccessToken);
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest
        /// </summary>
        /// <param name="httpRequest">Http Request</param>
        /// <return>Returns the httpRequest after adding authentication</return>
        public HttpRequest Apply(HttpRequest httpRequest)
        {
            httpRequest.Headers["Authorization"] = "Bearer " + AccessToken;
            return httpRequest;
        }

        /// <summary>
        /// Adds authentication to the given HttpRequest
        /// </summary>
        /// <param name="httpRequest">Http Request</param>
        /// <return>Returns the httpRequest after adding authentication</return>
        public Task<HttpRequest> ApplyAsync(HttpRequest httpRequest)
        {
            httpRequest.Headers["Authorization"] = "Bearer " + AccessToken;
            return Task.FromResult(httpRequest);
        }
    }
}