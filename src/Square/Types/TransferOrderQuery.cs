using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Query parameters for searching transfer orders
/// </summary>
public record TransferOrderQuery
{
    /// <summary>
    /// Filter criteria
    /// </summary>
    [JsonPropertyName("filter")]
    public TransferOrderFilter? Filter { get; set; }

    /// <summary>
    /// Sort configuration
    /// </summary>
    [JsonPropertyName("sort")]
    public TransferOrderSort? Sort { get; set; }

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
