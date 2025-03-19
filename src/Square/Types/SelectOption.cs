using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record SelectOption
{
    /// <summary>
    /// The reference id for the option.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public required string ReferenceId { get; set; }

    /// <summary>
    /// The title text that displays in the select option button.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

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
