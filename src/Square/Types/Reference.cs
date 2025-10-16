using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record Reference
{
    /// <summary>
    /// The type of entity a channel is associated with.
    /// See [Type](#type-type) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public ReferenceType? Type { get; set; }

    /// <summary>
    /// The id of the entity a channel is associated with.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

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
