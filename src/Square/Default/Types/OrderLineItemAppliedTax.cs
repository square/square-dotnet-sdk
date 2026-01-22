using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Represents an applied portion of a tax to a line item in an order.
///
/// Order-scoped taxes automatically include the applied taxes in each line item.
/// Line item taxes must be referenced from any applicable line items.
/// The corresponding applied money is automatically computed, based on the
/// set of participating line items.
/// </summary>
[Serializable]
public record OrderLineItemAppliedTax : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID that identifies the applied tax only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The `uid` of the tax for which this applied tax represents. It must reference
    /// a tax present in the `order.taxes` field.
    ///
    /// This field is immutable. To change which taxes apply to a line item, delete and add a new
    /// `OrderLineItemAppliedTax`.
    /// </summary>
    [JsonPropertyName("tax_uid")]
    public required string TaxUid { get; set; }

    /// <summary>
    /// The amount of money applied by the tax to the line item.
    /// </summary>
    [JsonPropertyName("applied_money")]
    public Money? AppliedMoney { get; set; }

    /// <summary>
    /// Indicates whether the tax was automatically applied to the order based on
    /// the catalog configuration. For an example, see
    /// [Automatically Apply Taxes to an Order](https://developer.squareup.com/docs/orders-api/apply-taxes-and-discounts/auto-apply-taxes).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("auto_applied")]
    public bool? AutoApplied { get; set; }

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
