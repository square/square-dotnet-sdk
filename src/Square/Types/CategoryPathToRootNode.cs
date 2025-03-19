using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A node in the path from a retrieved category to its root node.
/// </summary>
public record CategoryPathToRootNode
{
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
