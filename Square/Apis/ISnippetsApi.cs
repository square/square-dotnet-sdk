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
    /// ISnippetsApi.
    /// </summary>
    public interface ISnippetsApi
    {
        /// <summary>
        /// Removes your snippet from a Square Online site.
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site that contains the snippet..</param>
        /// <returns>Returns the Models.DeleteSnippetResponse response from the API call.</returns>
        Models.DeleteSnippetResponse DeleteSnippet(
                string siteId);

        /// <summary>
        /// Removes your snippet from a Square Online site.
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site that contains the snippet..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DeleteSnippetResponse response from the API call.</returns>
        Task<Models.DeleteSnippetResponse> DeleteSnippetAsync(
                string siteId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves your snippet from a Square Online site. A site can contain snippets from multiple snippet applications, but you can retrieve only the snippet that was added by your application.
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site that contains the snippet..</param>
        /// <returns>Returns the Models.RetrieveSnippetResponse response from the API call.</returns>
        Models.RetrieveSnippetResponse RetrieveSnippet(
                string siteId);

        /// <summary>
        /// Retrieves your snippet from a Square Online site. A site can contain snippets from multiple snippet applications, but you can retrieve only the snippet that was added by your application.
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site that contains the snippet..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveSnippetResponse response from the API call.</returns>
        Task<Models.RetrieveSnippetResponse> RetrieveSnippetAsync(
                string siteId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a snippet to a Square Online site or updates the existing snippet on the site. .
        /// The snippet code is appended to the end of the `head` element on every page of the site, except checkout pages. A snippet application can add one snippet to a given site. .
        /// You can call [ListSites]($e/Sites/ListSites) to get the IDs of the sites that belong to a seller.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="siteId">Required parameter: The ID of the site where you want to add or update the snippet..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpsertSnippetResponse response from the API call.</returns>
        Models.UpsertSnippetResponse UpsertSnippet(
                string siteId,
                Models.UpsertSnippetRequest body);

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
        Task<Models.UpsertSnippetResponse> UpsertSnippetAsync(
                string siteId,
                Models.UpsertSnippetRequest body,
                CancellationToken cancellationToken = default);
    }
}