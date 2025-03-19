using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Locations.Transactions;

public record CaptureTransactionsRequest
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
