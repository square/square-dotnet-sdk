using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter events by loyalty account.
/// </summary>
public record LoyaltyEventLoyaltyAccountFilter
{
    /// <summary>
    /// The ID of the [loyalty account](entity:LoyaltyAccount) associated with loyalty events.
    /// </summary>
    [JsonPropertyName("loyalty_account_id")]
    public required string LoyaltyAccountId { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
