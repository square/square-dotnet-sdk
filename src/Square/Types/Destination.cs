using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about the destination against which the payout was made.
/// </summary>
[Serializable]
public record Destination : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Type of the destination such as a bank account or debit card.
    /// See [DestinationType](#type-destinationtype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public DestinationType? Type { get; set; }

    /// <summary>
    /// Square issued unique ID (also known as the instrument ID) associated with this destination.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

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
