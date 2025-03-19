using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Cards;

public record GetCardsRequest
{
    /// <summary>
    /// Unique ID for the desired Card.
    /// </summary>
    [JsonIgnore]
    public required string CardId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
