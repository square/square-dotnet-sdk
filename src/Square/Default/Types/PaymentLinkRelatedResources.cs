using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record PaymentLinkRelatedResources : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The order associated with the payment link.
    /// </summary>
    [JsonPropertyName("orders")]
    public IEnumerable<Order>? Orders { get; set; }

    /// <summary>
    /// The subscription plan associated with the payment link.
    /// </summary>
    [JsonPropertyName("subscription_plans")]
    public IEnumerable<CatalogObject>? SubscriptionPlans { get; set; }

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
