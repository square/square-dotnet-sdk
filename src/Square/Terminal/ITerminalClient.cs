using Square;
using Square.Terminal.Actions;
using Square.Terminal.Checkouts;

namespace Square.Terminal;

public partial interface ITerminalClient
{
    public ActionsClient Actions { get; }
    public CheckoutsClient Checkouts { get; }
    public Square.Terminal.Refunds.RefundsClient Refunds { get; }

    /// <summary>
    /// Dismisses a Terminal action request if the status and type of the request permits it.
    ///
    /// See [Link and Dismiss Actions](https://developer.squareup.com/docs/terminal-api/advanced-features/custom-workflows/link-and-dismiss-actions) for more details.
    /// </summary>
    Task<DismissTerminalActionResponse> DismissTerminalActionAsync(
        DismissTerminalActionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Dismisses a Terminal checkout request if the status and type of the request permits it.
    /// </summary>
    Task<DismissTerminalCheckoutResponse> DismissTerminalCheckoutAsync(
        DismissTerminalCheckoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Dismisses a Terminal refund request if the status and type of the request permits it.
    /// </summary>
    Task<DismissTerminalRefundResponse> DismissTerminalRefundAsync(
        DismissTerminalRefundRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
