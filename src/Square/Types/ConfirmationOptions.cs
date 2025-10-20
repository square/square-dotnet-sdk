using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record ConfirmationOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
