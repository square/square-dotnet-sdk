using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that contains the gift card activity associated with a
/// `gift_card.activity.created` event.
/// </summary>
public record GiftCardActivityCreatedEventObject
{
    /// <summary>
    /// The new gift card activity.
    /// </summary>
    [JsonPropertyName("gift_card_activity")]
    public GiftCardActivity? GiftCardActivity { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
