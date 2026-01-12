using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Defines output parameters in a response from the
/// [UpdateSubscription](api-endpoint:Subscriptions-UpdateSubscription) endpoint.
/// </summary>
[Serializable]
public record UpdateSubscriptionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The updated subscription.
    /// </summary>
    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; set; }

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
