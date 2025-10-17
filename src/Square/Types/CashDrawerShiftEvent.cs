using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record CashDrawerShiftEvent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the event.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The type of cash drawer shift event.
    /// See [CashDrawerEventType](#type-cashdrawereventtype) for possible values
    /// </summary>
    [JsonPropertyName("event_type")]
    public CashDrawerEventType? EventType { get; set; }

    /// <summary>
    /// The amount of money that was added to or removed from the cash drawer
    /// in the event. The amount can be positive (for added money)
    /// or zero (for other tender type payments). The addition or removal of money can be determined by
    /// by the event type.
    /// </summary>
    [JsonPropertyName("event_money")]
    public Money? EventMoney { get; set; }

    /// <summary>
    /// The event time in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// An optional description of the event, entered by the employee that
    /// created the event.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The ID of the team member that created the event.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("team_member_id")]
    public string? TeamMemberId { get; set; }

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
