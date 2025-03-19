using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines output parameters in a response of the [DeleteSubscriptionAction](api-endpoint:Subscriptions-DeleteSubscriptionAction)
/// endpoint.
/// </summary>
public record DeleteSubscriptionActionResponse
{
    /// <summary>
    /// Errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The subscription that has the specified action deleted.
    /// </summary>
    [JsonPropertyName("subscription")]
    public Subscription? Subscription { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
