using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes query filters to apply.
/// </summary>
public record InvoiceFilter
{
    /// <summary>
    /// Limits the search to the specified locations. A location is required.
    /// In the current implementation, only one location can be specified.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string> LocationIds { get; set; } = new List<string>();

    /// <summary>
    /// Limits the search to the specified customers, within the specified locations.
    /// Specifying a customer is optional. In the current implementation,
    /// a maximum of one customer can be specified.
    /// </summary>
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string>? CustomerIds { get; set; }

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
