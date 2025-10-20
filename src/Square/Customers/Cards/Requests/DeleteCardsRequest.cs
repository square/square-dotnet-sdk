using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Customers.Cards;

[Serializable]
public record DeleteCardsRequest
{
    /// <summary>
    /// The ID of the customer that the card on file belongs to.
    /// </summary>
    [JsonIgnore]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The ID of the card on file to delete.
    /// </summary>
    [JsonIgnore]
    public required string CardId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
