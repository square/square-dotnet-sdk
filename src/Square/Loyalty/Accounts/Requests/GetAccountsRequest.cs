using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Loyalty.Accounts;

public record GetAccountsRequest
{
    /// <summary>
    /// The ID of the [loyalty account](entity:LoyaltyAccount) to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string AccountId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
