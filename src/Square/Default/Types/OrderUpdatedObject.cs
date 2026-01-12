using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record OrderUpdatedObject : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Information about the updated order.
    /// </summary>
    [JsonPropertyName("order_updated")]
    public OrderUpdated? OrderUpdated { get; set; }

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
