using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Http.Client;
using Square.Http.Request;
using Square.Http.Response;
using Square.Utilities;

namespace Square.Apis
{
    /// <summary>
    /// IMobileAuthorizationApi.
    /// </summary>
    public interface IMobileAuthorizationApi
    {
        /// <summary>
        /// Generates code to authorize a mobile application to connect to a Square card reader.
        /// Authorization codes are one-time-use codes and expire 60 minutes after being issued.
        /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:.
        /// ```.
        /// Authorization: Bearer ACCESS_TOKEN.
        /// ```.
        /// Replace `ACCESS_TOKEN` with a.
        /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateMobileAuthorizationCodeResponse response from the API call.</returns>
        Models.CreateMobileAuthorizationCodeResponse CreateMobileAuthorizationCode(
                Models.CreateMobileAuthorizationCodeRequest body);

        /// <summary>
        /// Generates code to authorize a mobile application to connect to a Square card reader.
        /// Authorization codes are one-time-use codes and expire 60 minutes after being issued.
        /// __Important:__ The `Authorization` header you provide to this endpoint must have the following format:.
        /// ```.
        /// Authorization: Bearer ACCESS_TOKEN.
        /// ```.
        /// Replace `ACCESS_TOKEN` with a.
        /// [valid production authorization credential](https://developer.squareup.com/docs/build-basics/access-tokens).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateMobileAuthorizationCodeResponse response from the API call.</returns>
        Task<Models.CreateMobileAuthorizationCodeResponse> CreateMobileAuthorizationCodeAsync(
                Models.CreateMobileAuthorizationCodeRequest body,
                CancellationToken cancellationToken = default);
    }
}