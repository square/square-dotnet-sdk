using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record DeviceCheckoutOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the device intended for this `TerminalCheckout`.
    /// A list of `DeviceCode` objects can be retrieved from the /v2/devices/codes endpoint.
    /// Match a `DeviceCode.device_id` value with `device_id` to get the associated device code.
    /// </summary>
    [JsonPropertyName("device_id")]
    public required string DeviceId { get; set; }

    /// <summary>
    /// Instructs the device to skip the receipt screen. Defaults to false.
    /// </summary>
    [JsonPropertyName("skip_receipt_screen")]
    public bool? SkipReceiptScreen { get; set; }

    /// <summary>
    /// Indicates that signature collection is desired during checkout. Defaults to false.
    /// </summary>
    [JsonPropertyName("collect_signature")]
    public bool? CollectSignature { get; set; }

    /// <summary>
    /// Tip-specific settings.
    /// </summary>
    [JsonPropertyName("tip_settings")]
    public TipSettings? TipSettings { get; set; }

    /// <summary>
    /// Show the itemization screen prior to taking a payment. This field is only meaningful when the
    /// checkout includes an order ID. Defaults to true.
    /// </summary>
    [JsonPropertyName("show_itemized_cart")]
    public bool? ShowItemizedCart { get; set; }

    /// <summary>
    /// Controls whether the mobile client applies Auto Card Surcharge (ACS) during checkout.
    /// If true, ACS is applied based on Dashboard configuration.
    /// If false, ACS is not applied regardless of that configuration.
    /// For more information, see [Add a Card Surcharge](https://developer.squareupstaging.com/docs/terminal-api/additional-payment-checkout-features#add-a-card-surcharge).
    /// </summary>
    [JsonPropertyName("allow_auto_card_surcharge")]
    public bool? AllowAutoCardSurcharge { get; set; }

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
