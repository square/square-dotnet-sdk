using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Contains the details necessary to fulfill an in-store order.
/// </summary>
[Serializable]
public record FulfillmentInStoreDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A note to provide additional instructions about the in-store fulfillment
    /// displayed in the Square Point of Sale application and set by the API.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    /// <summary>
    /// Information about the person to receive this in-store fulfillment.
    /// </summary>
    [JsonPropertyName("recipient")]
    public FulfillmentRecipient? Recipient { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was placed. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonPropertyName("placed_at")]
    public string? PlacedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was completed. This field is automatically set when the
    /// fulfillment `state` changes to `COMPLETED`. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("completed_at")]
    public string? CompletedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicates when the seller started processing the fulfillment.
    /// This field is automatically set when the fulfillment `state` changes to `RESERVED`.
    /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("in_progress_at")]
    public string? InProgressAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was moved to the `PREPARED` state, which indicates that the
    /// fulfillment is ready. The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("prepared_at")]
    public string? PreparedAt { get; set; }

    /// <summary>
    /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
    /// indicating when the fulfillment was canceled. This field is automatically set when the
    /// fulfillment `state` changes to `CANCELED`. The timestamp must be in RFC 3339 format
    /// (for example, "2016-09-04T23:59:33.123Z").
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("canceled_at")]
    public string? CanceledAt { get; set; }

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
