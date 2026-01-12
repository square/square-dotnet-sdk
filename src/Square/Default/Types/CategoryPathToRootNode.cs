using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A node in the path from a retrieved category to its root node.
/// </summary>
[Serializable]
public record CategoryPathToRootNode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The category's ID.
    /// </summary>
    [JsonPropertyName("category_id")]
    public string? CategoryId { get; set; }

    /// <summary>
    /// The category's name.
    /// </summary>
    [JsonPropertyName("category_name")]
    public string? CategoryName { get; set; }

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
