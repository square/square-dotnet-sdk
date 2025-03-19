using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CreateTerminalActionResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// The created `TerminalAction`
    /// </summary>
    [JsonPropertyName("action")]
    public TerminalAction? Action { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
