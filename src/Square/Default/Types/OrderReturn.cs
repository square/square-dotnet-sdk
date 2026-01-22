using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The set of line items, service charges, taxes, discounts, tips, and other items being returned in an order.
/// </summary>
[Serializable]
public record OrderReturn : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique ID that identifies the return only within this order.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// An order that contains the original sale of these return line items. This is unset
    /// for unlinked returns.
    /// </summary>
    [JsonPropertyName("source_order_id")]
    public string? SourceOrderId { get; set; }

    /// <summary>
    /// A collection of line items that are being returned.
    /// </summary>
    [JsonPropertyName("return_line_items")]
    public IEnumerable<OrderReturnLineItem>? ReturnLineItems { get; set; }

    /// <summary>
    /// A collection of service charges that are being returned.
    /// </summary>
    [JsonPropertyName("return_service_charges")]
    public IEnumerable<OrderReturnServiceCharge>? ReturnServiceCharges { get; set; }

    /// <summary>
    /// A collection of references to taxes being returned for an order, including the total
    /// applied tax amount to be returned. The taxes must reference a top-level tax ID from the source
    /// order.
    /// </summary>
    [JsonPropertyName("return_taxes")]
    public IEnumerable<OrderReturnTax>? ReturnTaxes { get; set; }

    /// <summary>
    /// A collection of references to discounts being returned for an order, including the total
    /// applied discount amount to be returned. The discounts must reference a top-level discount ID
    /// from the source order.
    /// </summary>
    [JsonPropertyName("return_discounts")]
    public IEnumerable<OrderReturnDiscount>? ReturnDiscounts { get; set; }

    /// <summary>
    /// A collection of references to tips being returned for an order.
    /// </summary>
    [JsonPropertyName("return_tips")]
    public IEnumerable<OrderReturnTip>? ReturnTips { get; set; }

    /// <summary>
    /// A positive or negative rounding adjustment to the total value being returned. Adjustments are commonly
    /// used to apply cash rounding when the minimum unit of the account is smaller than the lowest
    /// physical denomination of the currency.
    /// </summary>
    [JsonPropertyName("rounding_adjustment")]
    public OrderRoundingAdjustment? RoundingAdjustment { get; set; }

    /// <summary>
    /// An aggregate monetary value being returned by this return entry.
    /// </summary>
    [JsonPropertyName("return_amounts")]
    public OrderMoneyAmounts? ReturnAmounts { get; set; }

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
