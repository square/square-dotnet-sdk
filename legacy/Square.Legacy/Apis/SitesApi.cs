using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// SitesApi.
    /// </summary>
    internal class SitesApi : BaseApi, ISitesApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SitesApi"/> class.
        /// </summary>
        internal SitesApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

        /// <summary>
        /// Lists the Square Online sites that belong to a seller. Sites are listed in descending order by the `created_at` date.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <returns>Returns the Models.ListSitesResponse response from the API call.</returns>
        public Models.ListSitesResponse ListSites() => CoreHelper.RunTask(ListSitesAsync());

        /// <summary>
        /// Lists the Square Online sites that belong to a seller. Sites are listed in descending order by the `created_at` date.
        /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListSitesResponse response from the API call.</returns>
        public async Task<Models.ListSitesResponse> ListSitesAsync(
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListSitesResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder.Setup(HttpMethod.Get, "/v2/sites").WithAuth("global")
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
