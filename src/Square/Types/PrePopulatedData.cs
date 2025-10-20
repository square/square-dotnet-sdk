using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes buyer data to prepopulate in the payment form.
/// For more information,
/// see [Optional Checkout Configurations](https://developer.squareup.com/docs/checkout-api/optional-checkout-configurations).
/// </summary>
[Serializable]
public record PrePopulatedData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The buyer email to prepopulate in the payment form.
    /// </summary>
    [JsonPropertyName("buyer_email")]
    public string? BuyerEmail { get; set; }

    /// <summary>
    /// The buyer phone number to prepopulate in the payment form.
    /// </summary>
    [JsonPropertyName("buyer_phone_number")]
    public string? BuyerPhoneNumber { get; set; }

    /// <summary>
    /// The buyer address to prepopulate in the payment form.
    /// </summary>
    [JsonPropertyName("buyer_address")]
    public Address? BuyerAddress { get; set; }

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
