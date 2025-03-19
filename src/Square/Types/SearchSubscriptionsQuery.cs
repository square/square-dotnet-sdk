using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a query, consisting of specified query expressions, used to search for subscriptions.
/// </summary>
public record SearchSubscriptionsQuery
{
    /// <summary>
    /// A list of query expressions.
    /// </summary>
    [JsonPropertyName("filter")]
    public SearchSubscriptionsFilter? Filter { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
