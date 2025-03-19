using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DataCollectionOptions
{
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
