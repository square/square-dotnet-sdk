namespace Square.Apis
{
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

    /// <summary>
    /// ISitesApi.
    /// </summary>
    public interface ISitesApi
    {
        /// <summary>
        /// Lists the Square Online sites that belong to a seller. Sites are listed in descending order by the `created_at` date.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <returns>Returns the Models.ListSitesResponse response from the API call.</returns>
        Models.ListSitesResponse ListSites();

        /// <summary>
        /// Lists the Square Online sites that belong to a seller. Sites are listed in descending order by the `created_at` date.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListSitesResponse response from the API call.</returns>
        Task<Models.ListSitesResponse> ListSitesAsync(CancellationToken cancellationToken = default);
    }
}