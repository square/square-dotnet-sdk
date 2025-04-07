using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An option that can be assigned to an item.
/// For example, a t-shirt item may offer a color option or a size option.
/// </summary>
public record CatalogItemOptionForItem
{
    /// <summary>
    /// The unique id of the item option, used to form the dimensions of the item option matrix in a specified order.
    /// </summary>
    [JsonPropertyName("item_option_id")]
    public string? ItemOptionId { get; set; }

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
