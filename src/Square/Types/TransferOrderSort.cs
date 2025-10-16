using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Sort configuration for search results
/// </summary>
public record TransferOrderSort
{
    /// <summary>
    /// Field to sort by
    /// See [TransferOrderSortField](#type-transferordersortfield) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public TransferOrderSortField? Field { get; set; }

    /// <summary>
    /// Sort order direction
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("order")]
    public SortOrder? Order { get; set; }

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
