using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Payouts;

public record GetPayoutsRequest
{
    /// <summary>
    /// The ID of the payout to retrieve the information for.
    /// </summary>
    [JsonIgnore]
    public required string PayoutId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
