using Square;
using Square.Core;
using Square.Default;

namespace Square.Default.Labor;

public partial interface IWorkweekConfigsClient
{
    /// <summary>
    /// Returns a list of `WorkweekConfig` instances for a business.
    /// </summary>
    Task<Pager<WorkweekConfig>> ListAsync(
        ListWorkweekConfigsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a `WorkweekConfig`.
    /// </summary>
    Task<UpdateWorkweekConfigResponse> GetAsync(
        UpdateWorkweekConfigRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
