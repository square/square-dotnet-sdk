using Square;

namespace Square.Terminal.Checkouts;

public partial interface ICheckoutsClient
{
    /// <summary>
    /// Creates a Terminal checkout request and sends it to the specified device to take a payment
    /// for the requested amount.
    /// </summary>
    Task<CreateTerminalCheckoutResponse> CreateAsync(
        CreateTerminalCheckoutRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a filtered list of Terminal checkout requests created by the application making the request. Only Terminal checkout requests created for the merchant scoped to the OAuth token are returned. Terminal checkout requests are available for 30 days.
    /// </summary>
    Task<SearchTerminalCheckoutsResponse> SearchAsync(
        SearchTerminalCheckoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a Terminal checkout request by `checkout_id`. Terminal checkout requests are available for 30 days.
    /// </summary>
    Task<GetTerminalCheckoutResponse> GetAsync(
        GetCheckoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels a Terminal checkout request if the status of the request permits it.
    /// </summary>
    Task<CancelTerminalCheckoutResponse> CancelAsync(
        CancelCheckoutsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
