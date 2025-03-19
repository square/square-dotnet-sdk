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
    /// PayoutsApi.
    /// </summary>
    internal class PayoutsApi : BaseApi, IPayoutsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayoutsApi"/> class.
        /// </summary>
        internal PayoutsApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

        /// <summary>
        /// Retrieves a list of all payouts for the default location.
        /// You can filter payouts by location ID, status, time range, and order them in ascending or descending order.
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="locationId">Optional parameter: The ID of the location for which to list the payouts. By default, payouts are returned for the default (main) location associated with the seller..</param>
        /// <param name="status">Optional parameter: If provided, only payouts with the given status are returned..</param>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the payout creation time, in RFC 3339 format. Inclusive. Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the payout creation time, in RFC 3339 format. Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which payouts are listed..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). If request parameters change between requests, subsequent results may contain duplicates or missing records..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value. If the provided value is greater than 100, it is ignored and the default value is used instead. Default: `100`.</param>
        /// <returns>Returns the Models.ListPayoutsResponse response from the API call.</returns>
        public Models.ListPayoutsResponse ListPayouts(
            string locationId = null,
            string status = null,
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            int? limit = null
        ) =>
            CoreHelper.RunTask(
                ListPayoutsAsync(locationId, status, beginTime, endTime, sortOrder, cursor, limit)
            );

        /// <summary>
        /// Retrieves a list of all payouts for the default location.
        /// You can filter payouts by location ID, status, time range, and order them in ascending or descending order.
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="locationId">Optional parameter: The ID of the location for which to list the payouts. By default, payouts are returned for the default (main) location associated with the seller..</param>
        /// <param name="status">Optional parameter: If provided, only payouts with the given status are returned..</param>
        /// <param name="beginTime">Optional parameter: The timestamp for the beginning of the payout creation time, in RFC 3339 format. Inclusive. Default: The current time minus one year..</param>
        /// <param name="endTime">Optional parameter: The timestamp for the end of the payout creation time, in RFC 3339 format. Default: The current time..</param>
        /// <param name="sortOrder">Optional parameter: The order in which payouts are listed..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). If request parameters change between requests, subsequent results may contain duplicates or missing records..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value. If the provided value is greater than 100, it is ignored and the default value is used instead. Default: `100`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPayoutsResponse response from the API call.</returns>
        public async Task<Models.ListPayoutsResponse> ListPayoutsAsync(
            string locationId = null,
            string status = null,
            string beginTime = null,
            string endTime = null,
            string sortOrder = null,
            string cursor = null,
            int? limit = null,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListPayoutsResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/payouts")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Query(_query => _query.Setup("location_id", locationId))
                                .Query(_query => _query.Setup("status", status))
                                .Query(_query => _query.Setup("begin_time", beginTime))
                                .Query(_query => _query.Setup("end_time", endTime))
                                .Query(_query => _query.Setup("sort_order", sortOrder))
                                .Query(_query => _query.Setup("cursor", cursor))
                                .Query(_query => _query.Setup("limit", limit))
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves details of a specific payout identified by a payout ID.
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="payoutId">Required parameter: The ID of the payout to retrieve the information for..</param>
        /// <returns>Returns the Models.GetPayoutResponse response from the API call.</returns>
        public Models.GetPayoutResponse GetPayout(string payoutId) =>
            CoreHelper.RunTask(GetPayoutAsync(payoutId));

        /// <summary>
        /// Retrieves details of a specific payout identified by a payout ID.
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="payoutId">Required parameter: The ID of the payout to retrieve the information for..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetPayoutResponse response from the API call.</returns>
        public async Task<Models.GetPayoutResponse> GetPayoutAsync(
            string payoutId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.GetPayoutResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/payouts/{payout_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Template(_template =>
                                _template.Setup("payout_id", payoutId)
                            )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves a list of all payout entries for a specific payout.
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="payoutId">Required parameter: The ID of the payout to retrieve the information for..</param>
        /// <param name="sortOrder">Optional parameter: The order in which payout entries are listed..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). If request parameters change between requests, subsequent results may contain duplicates or missing records..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value. If the provided value is greater than 100, it is ignored and the default value is used instead. Default: `100`.</param>
        /// <returns>Returns the Models.ListPayoutEntriesResponse response from the API call.</returns>
        public Models.ListPayoutEntriesResponse ListPayoutEntries(
            string payoutId,
            string sortOrder = null,
            string cursor = null,
            int? limit = null
        ) => CoreHelper.RunTask(ListPayoutEntriesAsync(payoutId, sortOrder, cursor, limit));

        /// <summary>
        /// Retrieves a list of all payout entries for a specific payout.
        /// To call this endpoint, set `PAYOUTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="payoutId">Required parameter: The ID of the payout to retrieve the information for..</param>
        /// <param name="sortOrder">Optional parameter: The order in which payout entries are listed..</param>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by a previous call to this endpoint. Provide this cursor to retrieve the next set of results for the original query. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). If request parameters change between requests, subsequent results may contain duplicates or missing records..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to be returned in a single page. It is possible to receive fewer results than the specified limit on a given page. The default value of 100 is also the maximum allowed value. If the provided value is greater than 100, it is ignored and the default value is used instead. Default: `100`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListPayoutEntriesResponse response from the API call.</returns>
        public async Task<Models.ListPayoutEntriesResponse> ListPayoutEntriesAsync(
            string payoutId,
            string sortOrder = null,
            string cursor = null,
            int? limit = null,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListPayoutEntriesResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/payouts/{payout_id}/payout-entries")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Template(_template => _template.Setup("payout_id", payoutId))
                                .Query(_query => _query.Setup("sort_order", sortOrder))
                                .Query(_query => _query.Setup("cursor", cursor))
                                .Query(_query => _query.Setup("limit", limit))
                        )
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
