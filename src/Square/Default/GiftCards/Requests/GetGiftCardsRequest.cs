using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.GiftCards;

[Serializable]
public record GetGiftCardsRequest
{
    /// <summary>
    /// The ID of the gift card to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
