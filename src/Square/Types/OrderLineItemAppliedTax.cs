using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an applied portion of a tax to a line item in an order.
///
/// Order-scoped taxes automatically include the applied taxes in each line item.
/// Line item taxes must be referenced from any applicable line items.
/// The corresponding applied money is automatically computed, based on the
/// set of participating line items.
/// </summary>
public record OrderLineItemAppliedTax
{
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
