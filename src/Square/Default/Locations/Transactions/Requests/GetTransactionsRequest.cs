using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Locations.Transactions;

[Serializable]
public record GetTransactionsRequest
{
    /// <summary>
    /// The ID of the transaction's associated location.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// The ID of the transaction to retrieve.
    /// </summary>
    [JsonIgnore]
    public required string TransactionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
