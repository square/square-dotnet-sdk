using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TerminalRefundQuerySort
{
    /// <summary>
    /// The order in which results are listed.
    /// - `ASC` - Oldest to newest.
    /// - `DESC` - Newest to oldest (default).
    /// </summary>
    [JsonPropertyName("sort_order")]
    public string? SortOrder { get; set; }

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
