using System.Text.Json.Serialization;
using Square.Core;

namespace Square.GiftCards;

public record GetGiftCardsRequest
{
    /// <summary>
    /// The ID of the gift card to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
