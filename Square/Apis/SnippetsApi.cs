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
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// SnippetsApi.
    /// </summary>
    internal class SnippetsApi : BaseApi, ISnippetsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SnippetsApi"/> class.
        /// </summary>
        internal SnippetsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Removes your snippet from a Square Online site.
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site that contains the snippet..</param>
        /// <returns>Returns the Models.DeleteSnippetResponse response from the API call.</returns>
        public Models.DeleteSnippetResponse DeleteSnippet(
                string siteId)
            => CoreHelper.RunTask(DeleteSnippetAsync(siteId));

        /// <summary>
        /// Removes your snippet from a Square Online site.
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site that contains the snippet..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteSnippetResponse response from the API call.</returns>
        public async Task<Models.DeleteSnippetResponse> DeleteSnippetAsync(
                string siteId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DeleteSnippetResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/v2/sites/{site_id}/snippet")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("site_id", siteId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves your snippet from a Square Online site. A site can contain snippets from multiple snippet applications, but you can retrieve only the snippet that was added by your application.
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site that contains the snippet..</param>
        /// <returns>Returns the Models.RetrieveSnippetResponse response from the API call.</returns>
        public Models.RetrieveSnippetResponse RetrieveSnippet(
                string siteId)
            => CoreHelper.RunTask(RetrieveSnippetAsync(siteId));

        /// <summary>
        /// Retrieves your snippet from a Square Online site. A site can contain snippets from multiple snippet applications, but you can retrieve only the snippet that was added by your application.
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site that contains the snippet..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveSnippetResponse response from the API call.</returns>
        public async Task<Models.RetrieveSnippetResponse> RetrieveSnippetAsync(
                string siteId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveSnippetResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/sites/{site_id}/snippet")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("site_id", siteId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Adds a snippet to a Square Online site or updates the existing snippet on the site. .
        /// The snippet code is appended to the end of the `head` element on every page of the site, except checkout pages. A snippet application can add one snippet to a given site. .
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site where you want to add or update the snippet..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertSnippetResponse response from the API call.</returns>
        public Models.UpsertSnippetResponse UpsertSnippet(
                string siteId,
                Models.UpsertSnippetRequest body)
            => CoreHelper.RunTask(UpsertSnippetAsync(siteId, body));

        /// <summary>
        /// Adds a snippet to a Square Online site or updates the existing snippet on the site. .
        /// The snippet code is appended to the end of the `head` element on every page of the site, except checkout pages. A snippet application can add one snippet to a given site. .
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site where you want to add or update the snippet..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpsertSnippetResponse response from the API call.</returns>
        public async Task<Models.UpsertSnippetResponse> UpsertSnippetAsync(
                string siteId,
                Models.UpsertSnippetRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpsertSnippetResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/sites/{site_id}/snippet")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("site_id", siteId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}