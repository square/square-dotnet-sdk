using Square;
using Square.Loyalty.Accounts;
using Square.Loyalty.Programs;
using Square.Loyalty.Rewards;

namespace Square.Loyalty;

public partial interface ILoyaltyClient
{
    public AccountsClient Accounts { get; }
    public ProgramsClient Programs { get; }
    public RewardsClient Rewards { get; }

    /// <summary>
    /// Searches for loyalty events.
    ///
    /// A Square loyalty program maintains a ledger of events that occur during the lifetime of a
    /// buyer's loyalty account. Each change in the point balance
    /// (for example, points earned, points redeemed, and points expired) is
    /// recorded in the ledger. Using this endpoint, you can search the ledger for events.
    ///
    /// Search results are sorted by `created_at` in descending order.
    /// </summary>
    Task<SearchLoyaltyEventsResponse> SearchEventsAsync(
        SearchLoyaltyEventsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
