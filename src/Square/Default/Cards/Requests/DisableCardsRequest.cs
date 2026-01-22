using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record DisableCardsRequest
{
    /// <summary>
    /// Unique ID for the desired Card.
    /// </summary>
    [JsonIgnore]
    public required string CardId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
