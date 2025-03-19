using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents details about a `CLEAR_BALANCE` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
public record GiftCardActivityClearBalance
{
    /// <summary>
    /// The reason the gift card balance was cleared.
    /// See [Reason](#type-reason) for possible values
    /// </summary>
    [JsonPropertyName("reason")]
    public required GiftCardActivityClearBalanceReason Reason { get; set; }

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
