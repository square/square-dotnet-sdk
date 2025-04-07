using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record BatchChangeInventoryResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The current counts for all objects referenced in the request.
    /// </summary>
    [JsonPropertyName("counts")]
    public IEnumerable<InventoryCount>? Counts { get; set; }

    /// <summary>
    /// Changes created for the request.
    /// </summary>
    [JsonPropertyName("changes")]
    public IEnumerable<InventoryChange>? Changes { get; set; }

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
