using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record ConfirmationOptions
{
    /// <summary>
    /// The title text to display in the confirmation screen flow on the Terminal.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The agreement details to display in the confirmation flow on the Terminal.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; set; }

    /// <summary>
    /// The button text to display indicating the customer agrees to the displayed terms.
    /// </summary>
    [JsonPropertyName("agree_button_text")]
    public required string AgreeButtonText { get; set; }

    /// <summary>
    /// The button text to display indicating the customer does not agree to the displayed terms.
    /// </summary>
    [JsonPropertyName("disagree_button_text")]
    public string? DisagreeButtonText { get; set; }

    /// <summary>
    /// The result of the buyer’s actions when presented with the confirmation screen.
    /// </summary>
    [JsonPropertyName("decision")]
    public ConfirmationDecision? Decision { get; set; }

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
