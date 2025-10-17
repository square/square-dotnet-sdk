using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes an ad hoc item and price to generate a quick pay checkout link.
/// For more information,
/// see [Quick Pay Checkout](https://developer.squareup.com/docs/checkout-api/quick-pay-checkout).
/// </summary>
[Serializable]
public record QuickPay : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
