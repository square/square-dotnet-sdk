using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Locations;

[Serializable]
public record VoidTransactionsRequest
{
    [JsonIgnore]
    public required string LocationId { get; set; }

    [JsonIgnore]
    public required string TransactionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
