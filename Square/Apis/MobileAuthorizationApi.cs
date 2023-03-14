namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// MobileAuthorizationApi.
    /// </summary>
    internal class MobileAuthorizationApi : BaseApi, IMobileAuthorizationApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileAuthorizationApi"/> class.
        /// </summary>
        internal MobileAuthorizationApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

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
        public Models.CreateMobileAuthorizationCodeResponse CreateMobileAuthorizationCode(
                Models.CreateMobileAuthorizationCodeRequest body)
            => CoreHelper.RunTask(CreateMobileAuthorizationCodeAsync(body));

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
        public async Task<Models.CreateMobileAuthorizationCodeResponse> CreateMobileAuthorizationCodeAsync(
                Models.CreateMobileAuthorizationCodeRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateMobileAuthorizationCodeResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/mobile/authorization-code")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.CreateMobileAuthorizationCodeResponse>(_response)))
              .ExecuteAsync(cancellationToken);
    }
}