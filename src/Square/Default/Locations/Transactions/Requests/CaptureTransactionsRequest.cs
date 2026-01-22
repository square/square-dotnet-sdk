using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Locations;

[Serializable]
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
