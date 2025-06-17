using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record JobCreatedEventData
{
    /// <summary>
    /// Name of the affected object’s type, `"job"`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// ID of the created job.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// An object containing the created job.
    /// </summary>
    [JsonPropertyName("object")]
    public JobCreatedEventObject? Object { get; set; }

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
