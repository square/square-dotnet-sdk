using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TerminalActionQuerySort
{
    /// <summary>
    /// The order in which results are listed.
    /// - `ASC` - Oldest to newest.
    /// - `DESC` - Newest to oldest (default).
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("sort_order")]
    public SortOrder? SortOrder { get; set; }

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
