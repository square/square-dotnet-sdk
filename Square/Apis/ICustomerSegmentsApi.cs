using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface ICustomerSegmentsApi
    {
        /// <summary>
        /// Retrieves the list of customer segments of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by previous calls to __ListCustomerSegments__. Used to retrieve the next set of query results.  See the [Pagination guide](https://developer.squareup.com/docs/docs/working-with-apis/pagination) for more information.</param>
        /// <return>Returns the Models.ListCustomerSegmentsResponse response from the API call</return>
        Models.ListCustomerSegmentsResponse ListCustomerSegments(string cursor = null);

        /// <summary>
        /// Retrieves the list of customer segments of a business.
        /// </summary>
        /// <param name="cursor">Optional parameter: A pagination cursor returned by previous calls to __ListCustomerSegments__. Used to retrieve the next set of query results.  See the [Pagination guide](https://developer.squareup.com/docs/docs/working-with-apis/pagination) for more information.</param>
        /// <return>Returns the Models.ListCustomerSegmentsResponse response from the API call</return>
        Task<Models.ListCustomerSegmentsResponse> ListCustomerSegmentsAsync(string cursor = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a specific customer segment as identified by the `segment_id` value.
        /// </summary>
        /// <param name="segmentId">Required parameter: The Square-issued ID of the customer segment.</param>
        /// <return>Returns the Models.RetrieveCustomerSegmentResponse response from the API call</return>
        Models.RetrieveCustomerSegmentResponse RetrieveCustomerSegment(string segmentId);

        /// <summary>
        /// Retrieves a specific customer segment as identified by the `segment_id` value.
        /// </summary>
        /// <param name="segmentId">Required parameter: The Square-issued ID of the customer segment.</param>
        /// <return>Returns the Models.RetrieveCustomerSegmentResponse response from the API call</return>
        Task<Models.RetrieveCustomerSegmentResponse> RetrieveCustomerSegmentAsync(string segmentId, CancellationToken cancellationToken = default);

    }
}