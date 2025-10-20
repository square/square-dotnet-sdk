using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details about the customer making the payment.
/// </summary>
[Serializable]
public record CustomerDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the customer initiated the payment.
    /// </summary>
    [JsonPropertyName("customer_initiated")]
    public bool? CustomerInitiated { get; set; }

    /// <summary>
    /// Indicates that the seller keyed in payment details on behalf of the customer.
    /// This is used to flag a payment as Mail Order / Telephone Order (MOTO).
    /// </summary>
    [JsonPropertyName("seller_keyed_in")]
    public bool? SellerKeyedIn { get; set; }

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
