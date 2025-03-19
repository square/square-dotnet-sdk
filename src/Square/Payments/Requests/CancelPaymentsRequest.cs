using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Payments;

public record CancelPaymentsRequest
{
    /// <summary>
    /// The ID of the payment to cancel.
    /// </summary>
    [JsonIgnore]
    public required string PaymentId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
