using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an applied portion of a discount to a line item in an order.
///
/// Order scoped discounts have automatically applied discounts present for each line item.
/// Line-item scoped discounts must have applied discounts added manually for any applicable line
/// items. The corresponding applied money is automatically computed based on participating
/// line items.
/// </summary>
[Serializable]
public record OrderLineItemAppliedDiscount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID that identifies the applied discount only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` of the discount that the applied discount represents. It must
    /// reference a discount present in the `order.discounts` field.
    ///
    /// This field is immutable. To change which discounts apply to a line item,
    /// you must delete the discount and re-add it as a new `OrderLineItemAppliedDiscount`.
    /// </summary>
    [JsonPropertyName("discount_uid")]
    public required string DiscountUid { get; set; }

    /// <summary>
    /// The amount of money applied by the discount to the line item.
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
