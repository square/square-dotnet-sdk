using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a supplier to a seller.
/// </summary>
[Serializable]
public record Vendor : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique Square-generated ID for the [Vendor](entity:Vendor).
    /// This field is required when attempting to update a [Vendor](entity:Vendor).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An RFC 3339-formatted timestamp that indicates when the
    /// [Vendor](entity:Vendor) was created.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// An RFC 3339-formatted timestamp that indicates when the
    /// [Vendor](entity:Vendor) was last updated.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The name of the [Vendor](entity:Vendor).
    /// This field is required when attempting to create or update a [Vendor](entity:Vendor).
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The address of the [Vendor](entity:Vendor).
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }

    /// <summary>
    /// The contacts of the [Vendor](entity:Vendor).
    /// </summary>
    [JsonPropertyName("contacts")]
    public IEnumerable<VendorContact>? Contacts { get; set; }

    /// <summary>
    /// The account number of the [Vendor](entity:Vendor).
    /// </summary>
    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// A note detailing information about the [Vendor](entity:Vendor).
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// The version of the [Vendor](entity:Vendor).
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// The status of the [Vendor](entity:Vendor).
    /// See [Status](#type-status) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public VendorStatus? Status { get; set; }

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
