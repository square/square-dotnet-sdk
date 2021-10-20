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
    /// ICustomerSegmentsApi.
    /// </summary>
    public interface ICustomerSegmentsApi
    {
        /// <summary>
        /// Retrieves the list of customer segments of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by previous calls to `ListCustomerSegments`. This cursor is used to retrieve the next set of query results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. The limit is ignored if it is less than 1 or greater than 50. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <returns>Returns the Models.ListCustomerSegmentsResponse response from the API call.</returns>
        Models.ListCustomerSegmentsResponse ListCustomerSegments(
                string cursor = null,
                int? limit = null);

        /// <summary>
        /// Retrieves the list of customer segments of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by previous calls to `ListCustomerSegments`. This cursor is used to retrieve the next set of query results.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results. The limit is ignored if it is less than 1 or greater than 50. The default value is 50.  For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination)..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListCustomerSegmentsResponse response from the API call.</returns>
        Task<Models.ListCustomerSegmentsResponse> ListCustomerSegmentsAsync(
                string cursor = null,
                int? limit = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific customer segment as identified by the `segment_id` value.
        /// </summary>
        /// <param name="segmentId">Required parameter: The Square-issued ID of the customer segment..</param>
        /// <returns>Returns the Models.RetrieveCustomerSegmentResponse response from the API call.</returns>
        Models.RetrieveCustomerSegmentResponse RetrieveCustomerSegment(
                string segmentId);

        /// <summary>
        /// Retrieves a specific customer segment as identified by the `segment_id` value.
        /// </summary>
        /// <param name="segmentId">Required parameter: The Square-issued ID of the customer segment..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveCustomerSegmentResponse response from the API call.</returns>
        Task<Models.RetrieveCustomerSegmentResponse> RetrieveCustomerSegmentAsync(
                string segmentId,
                CancellationToken cancellationToken = default);
    }
}