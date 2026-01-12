using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record PaymentLink : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The Square-assigned ID of the payment link.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The Square-assigned version number, which is incremented each time an update is committed to the payment link.
    /// </summary>
    [JsonPropertyName("version")]
    public required int Version { get; set; }

    /// <summary>
    /// The optional description of the `payment_link` object.
    /// It is primarily for use by your application and is not used anywhere.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The ID of the order associated with the payment link.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("order_id")]
    public string? OrderId { get; set; }

    /// <summary>
    /// The checkout options configured for the payment link.
    /// For more information, see [Optional Checkout Configurations](https://developer.squareup.com/docs/checkout-api/optional-checkout-configurations).
    /// </summary>
    [JsonPropertyName("checkout_options")]
    public CheckoutOptions? CheckoutOptions { get; set; }

    /// <summary>
    /// Describes buyer data to prepopulate
    /// on the checkout page.
    /// </summary>
    [JsonPropertyName("pre_populated_data")]
    public PrePopulatedData? PrePopulatedData { get; set; }

    /// <summary>
    /// The shortened URL of the payment link.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// The long URL of the payment link.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("long_url")]
    public string? LongUrl { get; set; }

    /// <summary>
    /// The timestamp when the payment link was created, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the payment link was last updated, in RFC 3339 format.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// An optional note. After Square processes the payment, this note is added to the
    /// resulting `Payment`.
    /// </summary>
    [JsonPropertyName("payment_note")]
    public string? PaymentNote { get; set; }

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
