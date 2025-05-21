using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The parameters of a `Shift` search query, which includes filter and sort options.
///
/// Deprecated at Square API version 2025-05-21. See the [migration notes](https://developer.squareup.com/docs/labor-api/what-it-does#migration-notes).
/// </summary>
public record ShiftQuery
{
    /// <summary>
    /// Query filter options.
    /// </summary>
    [JsonPropertyName("filter")]
    public ShiftFilter? Filter { get; set; }

    /// <summary>
    /// Sort order details.
    /// </summary>
    [JsonPropertyName("sort")]
    public ShiftSort? Sort { get; set; }

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
