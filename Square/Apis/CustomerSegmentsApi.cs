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
    /// CustomerSegmentsApi.
    /// </summary>
    internal class CustomerSegmentsApi : BaseApi, ICustomerSegmentsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSegmentsApi"/> class.
        /// </summary>
        internal CustomerSegmentsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Retrieves the list of customer segments of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by previous calls to `ListCustomerSegments`. This cursor is used to retrieve the next set of query results.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the specified limit is less than 1 or greater than 50, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <returns>Returns the Models.ListCustomerSegmentsResponse response from the API call.</returns>
        public Models.ListCustomerSegmentsResponse ListCustomerSegments(
                string cursor = null,
                int? limit = null)
            => CoreHelper.RunTask(ListCustomerSegmentsAsync(cursor, limit));

        /// <summary>
        /// Retrieves the list of customer segments of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by previous calls to `ListCustomerSegments`. This cursor is used to retrieve the next set of query results.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. If the specified limit is less than 1 or greater than 50, Square returns a `400 VALUE_TOO_LOW` or `400 VALUE_TOO_HIGH` error. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomerSegmentsResponse response from the API call.</returns>
        public async Task<Models.ListCustomerSegmentsResponse> ListCustomerSegmentsAsync(
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListCustomerSegmentsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/customers/segments")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("limit", limit))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a specific customer segment as identified by the `segment_id` value.
        /// </summary>
        /// <param name="segmentId">Required parameter: The Square-issued ID of the customer segment..</param>
        /// <returns>Returns the Models.RetrieveCustomerSegmentResponse response from the API call.</returns>
        public Models.RetrieveCustomerSegmentResponse RetrieveCustomerSegment(
                string segmentId)
            => CoreHelper.RunTask(RetrieveCustomerSegmentAsync(segmentId));

        /// <summary>
        /// Retrieves a specific customer segment as identified by the `segment_id` value.
        /// </summary>
        /// <param name="segmentId">Required parameter: The Square-issued ID of the customer segment..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerSegmentResponse response from the API call.</returns>
        public async Task<Models.RetrieveCustomerSegmentResponse> RetrieveCustomerSegmentAsync(
                string segmentId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveCustomerSegmentResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/customers/segments/{segment_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("segment_id", segmentId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}