using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Square.Http.Request;

namespace Square.Authentication
{
     internal class AccessTokenManager: IAuthManager, IAccessTokenCredentials
     {
        /// Header Param to be used for requests
        public string AccessToken { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AccessTokenManager(string accessToken)
        {
            AccessToken = accessToken;
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