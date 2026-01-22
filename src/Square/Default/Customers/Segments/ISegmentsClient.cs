using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Customers;

public partial interface ISegmentsClient
{
    /// <summary>
    /// Retrieves the list of customer segments of a business.
    /// </summary>
    Task<Pager<CustomerSegment>> ListAsync(
        ListSegmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific customer segment as identified by the `segment_id` value.
    /// </summary>
    Task<GetCustomerSegmentResponse> GetAsync(
        GetSegmentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
