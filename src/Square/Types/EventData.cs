using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record EventData
{
    /// <summary>
    /// The name of the affected object’s type.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The ID of the affected object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// This is true if the affected object has been deleted; otherwise, it's absent.
    /// </summary>
    [JsonPropertyName("deleted")]
    public bool? Deleted { get; set; }

    /// <summary>
    /// An object containing fields and values relevant to the event. It is absent if the affected object has been deleted.
    /// </summary>
    [JsonPropertyName("object")]
    public object? Object { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
