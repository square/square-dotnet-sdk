using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines supported query expressions to search for vendors by.
/// </summary>
[Serializable]
public record SearchVendorsRequestFilter : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The names of the [Vendor](entity:Vendor) objects to retrieve.
    /// </summary>
    [JsonPropertyName("name")]
    public IEnumerable<string>? Name { get; set; }

    /// <summary>
    /// The statuses of the [Vendor](entity:Vendor) objects to retrieve.
    /// See [VendorStatus](#type-vendorstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public IEnumerable<VendorStatus>? Status { get; set; }

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
