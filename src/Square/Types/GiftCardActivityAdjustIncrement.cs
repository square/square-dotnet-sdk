using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents details about an `ADJUST_INCREMENT` [gift card activity type](entity:GiftCardActivityType).
/// </summary>
public record GiftCardActivityAdjustIncrement
{
    /// <summary>
    /// The amount added to the gift card balance. This value is a positive integer.
    /// </summary>
    [JsonPropertyName("amount_money")]
    public required Money AmountMoney { get; set; }

    /// <summary>
    /// The reason the gift card balance was adjusted.
    /// See [Reason](#type-reason) for possible values
    /// </summary>
    [JsonPropertyName("reason")]
    public required GiftCardActivityAdjustIncrementReason Reason { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
