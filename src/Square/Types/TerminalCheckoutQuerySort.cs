using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record TerminalCheckoutQuerySort
{
    /// <summary>
    /// The order in which results are listed.
    /// Default: `DESC`
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("sort_order")]
    public SortOrder? SortOrder { get; set; }

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
