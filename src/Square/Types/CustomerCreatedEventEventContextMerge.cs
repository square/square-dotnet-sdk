using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about a merge operation, which creates a new customer using aggregated properties from two or more existing customers.
/// </summary>
public record CustomerCreatedEventEventContextMerge
{
    /// <summary>
    /// The IDs of the existing customers that were merged and then deleted.
    /// </summary>
    [JsonPropertyName("from_customer_ids")]
    public IEnumerable<string>? FromCustomerIds { get; set; }

    /// <summary>
    /// The ID of the new customer created by the merge.
    /// </summary>
    [JsonPropertyName("to_customer_id")]
    public string? ToCustomerId { get; set; }

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
