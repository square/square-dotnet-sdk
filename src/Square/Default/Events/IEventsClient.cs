using Square;

namespace Square.Default;

public partial interface IEventsClient
{
    /// <summary>
    /// Search for Square API events that occur within a 28-day timeframe.
    /// </summary>
    Task<SearchEventsResponse> SearchEventsAsync(
        SearchEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Disables events to prevent them from being searchable.
    /// All events are disabled by default. You must enable events to make them searchable.
    /// Disabling events for a specific time period prevents them from being searchable, even if you re-enable them later.
    /// </summary>
    Task<DisableEventsResponse> DisableEventsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Enables events to make them searchable. Only events that occur while in the enabled state are searchable.
    /// </summary>
    Task<EnableEventsResponse> EnableEventsAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Lists all event types that you can subscribe to as webhooks or query using the Events API.
    /// </summary>
    Task<ListEventTypesResponse> ListEventTypesAsync(
        ListEventTypesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
