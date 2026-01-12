using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record SelectOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
