using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Information about a merge operation, which creates a new customer using aggregated properties from two or more existing customers.
/// </summary>
[Serializable]
public record CustomerDeletedEventEventContextMerge : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
