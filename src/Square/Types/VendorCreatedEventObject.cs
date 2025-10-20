using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record VendorCreatedEventObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The operation on the vendor that caused the event to be published. The value is `CREATED`.
    /// See [Operation](#type-operation) for possible values
    /// </summary>
    [JsonPropertyName("operation")]
    public string? Operation { get; set; }

    /// <summary>
    /// The created vendor as the result of the specified operation.
    /// </summary>
    [JsonPropertyName("vendor")]
    public Vendor? Vendor { get; set; }

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
