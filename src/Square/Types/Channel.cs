using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record Channel : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The channel's unique ID.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The unique ID of the merchant this channel belongs to.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("merchant_id")]
    public string? MerchantId { get; set; }

    /// <summary>
    /// The name of the channel.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The version number which is incremented each time an update is made to the channel.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// Represents an entity the channel is associated with.
    /// </summary>
    [JsonPropertyName("reference")]
    public Reference? Reference { get; set; }

    /// <summary>
    /// Status of the channel.
    /// See [Status](#type-status) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public ChannelStatus? Status { get; set; }

    /// <summary>
    /// The timestamp for when the channel was created, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// For more information, see [Working with Dates](https://developer.squareup.com/docs/build-basics/working-with-dates).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp for when the channel was last updated, in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
    /// For more information, see [Working with Dates](https://developer.squareup.com/docs/build-basics/working-with-dates).
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

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
