using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CatalogVersionUpdatedEventData
{
    /// <summary>
    /// Name of the affected object’s type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// An object containing fields and values relevant to the event. Is absent if affected object was deleted.
    /// </summary>
    [JsonPropertyName("object")]
    public CatalogVersionUpdatedEventObject? Object { get; set; }

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
