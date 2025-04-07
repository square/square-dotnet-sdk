using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record SelectOptions
{
    /// <summary>
    /// The title text to display in the select flow on the Terminal.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The body text to display in the select flow on the Terminal.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; set; }

    /// <summary>
    /// Represents the buttons/options that should be displayed in the select flow on the Terminal.
    /// </summary>
    [JsonPropertyName("options")]
    public IEnumerable<SelectOption> Options { get; set; } = new List<SelectOption>();

    /// <summary>
    /// The buyer’s selected option.
    /// </summary>
    [JsonPropertyName("selected_option")]
    public SelectOption? SelectedOption { get; set; }

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
