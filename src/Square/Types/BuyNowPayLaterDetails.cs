using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Additional details about a Buy Now Pay Later payment type.
/// </summary>
[Serializable]
public record BuyNowPayLaterDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The brand used for the Buy Now Pay Later payment.
    /// The brand can be `AFTERPAY`, `CLEARPAY` or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    /// <summary>
    /// Details about an Afterpay payment. These details are only populated if the `brand` is
    /// `AFTERPAY`.
    /// </summary>
    [JsonPropertyName("afterpay_details")]
    public AfterpayDetails? AfterpayDetails { get; set; }

    /// <summary>
    /// Details about a Clearpay payment. These details are only populated if the `brand` is
    /// `CLEARPAY`.
    /// </summary>
    [JsonPropertyName("clearpay_details")]
    public ClearpayDetails? ClearpayDetails { get; set; }

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
