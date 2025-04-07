using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes an ad hoc item and price to generate a quick pay checkout link.
/// For more information,
/// see [Quick Pay Checkout](https://developer.squareup.com/docs/checkout-api/quick-pay-checkout).
/// </summary>
public record QuickPay
{
    /// <summary>
    /// The ad hoc item name. In the resulting `Order`, this name appears as the line item name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The price of the item.
    /// </summary>
    [JsonPropertyName("price_money")]
    public required Money PriceMoney { get; set; }

    /// <summary>
    /// The ID of the business location the checkout is associated with.
    /// </summary>
    [JsonPropertyName("location_id")]
    public required string LocationId { get; set; }

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
