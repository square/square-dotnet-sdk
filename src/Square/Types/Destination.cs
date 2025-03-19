using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Information about the destination against which the payout was made.
/// </summary>
public record Destination
{
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
