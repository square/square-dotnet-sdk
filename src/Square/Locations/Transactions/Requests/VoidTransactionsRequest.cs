using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Locations.Transactions;

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
