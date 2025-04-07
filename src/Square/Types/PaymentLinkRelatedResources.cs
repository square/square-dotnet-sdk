using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record PaymentLinkRelatedResources
{
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
