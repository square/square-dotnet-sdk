using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Specific details for curbside pickup.
/// </summary>
[Serializable]
public record FulfillmentPickupDetailsCurbsidePickupDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Specific details for curbside pickup, such as parking number and vehicle model.
    /// </summary>
    [JsonPropertyName("curbside_details")]
    public string? CurbsideDetails { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the buyer arrived and is waiting for pickup. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonPropertyName("buyer_arrived_at")]
    public string? BuyerArrivedAt { get; set; }

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
