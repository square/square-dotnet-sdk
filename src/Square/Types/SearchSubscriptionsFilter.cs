using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a set of query expressions (filters) to narrow the scope of targeted subscriptions returned by
/// the [SearchSubscriptions](api-endpoint:Subscriptions-SearchSubscriptions) endpoint.
/// </summary>
public record SearchSubscriptionsFilter
{
    /// <summary>
    /// A filter to select subscriptions based on the subscribing customer IDs.
    /// </summary>
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string>? CustomerIds { get; set; }

    /// <summary>
    /// A filter to select subscriptions based on the location.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// A filter to select subscriptions based on the source application.
    /// </summary>
    [JsonPropertyName("source_names")]
    public IEnumerable<string>? SourceNames { get; set; }

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
