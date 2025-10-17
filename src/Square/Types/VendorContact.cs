using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a contact of a [Vendor](entity:Vendor).
/// </summary>
[Serializable]
public record VendorContact : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique Square-generated ID for the [VendorContact](entity:VendorContact).
    /// This field is required when attempting to update a [VendorContact](entity:VendorContact).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the [VendorContact](entity:VendorContact).
    /// This field is required when attempting to create a [Vendor](entity:Vendor).
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The email address of the [VendorContact](entity:VendorContact).
    /// </summary>
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// The phone number of the [VendorContact](entity:VendorContact).
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The state of the [VendorContact](entity:VendorContact).
    /// </summary>
    [JsonPropertyName("removed")]
    public bool? Removed { get; set; }

    /// <summary>
    /// The ordinal of the [VendorContact](entity:VendorContact).
    /// </summary>
    [JsonPropertyName("ordinal")]
    public required int Ordinal { get; set; }

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
