using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Sets the sort order of search results.
/// </summary>
public record ShiftSort
{
    /// <summary>
    /// The field to sort on.
    /// See [ShiftSortField](#type-shiftsortfield) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public ShiftSortField? Field { get; set; }

    /// <summary>
    /// The order in which results are returned. Defaults to DESC.
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("order")]
    public SortOrder? Order { get; set; }

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
