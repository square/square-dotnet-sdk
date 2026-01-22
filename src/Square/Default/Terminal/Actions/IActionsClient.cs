using Square;
using Square.Default;

namespace Square.Default.Terminal;

public partial interface IActionsClient
{
    /// <summary>
    /// Creates a Terminal action request and sends it to the specified device.
    /// </summary>
    Task<CreateTerminalActionResponse> CreateAsync(
        CreateTerminalActionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a filtered list of Terminal action requests created by the account making the request. Terminal action requests are available for 30 days.
    /// </summary>
    Task<SearchTerminalActionsResponse> SearchAsync(
        SearchTerminalActionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a Terminal action request by `action_id`. Terminal action requests are available for 30 days.
    /// </summary>
    Task<GetTerminalActionResponse> GetAsync(
        GetActionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a Terminal action request if the status of the request permits it.
    /// </summary>
    Task<CancelTerminalActionResponse> CancelAsync(
        CancelActionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
