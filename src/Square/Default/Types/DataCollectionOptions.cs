using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record DataCollectionOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The title text to display in the data collection flow on the Terminal.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The body text to display under the title in the data collection screen flow on the
    /// Terminal.
    /// </summary>
    [JsonPropertyName("body")]
    public required string Body { get; set; }

    /// <summary>
    /// Represents the type of the input text.
    /// See [InputType](#type-inputtype) for possible values
    /// </summary>
    [JsonPropertyName("input_type")]
    public required DataCollectionOptionsInputType InputType { get; set; }

    /// <summary>
    /// The buyer’s input text from the data collection screen.
    /// </summary>
    [JsonPropertyName("collected_data")]
    public CollectedData? CollectedData { get; set; }

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
