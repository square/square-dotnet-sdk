using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Payments;

[Serializable]
public record GetPaymentsRequest
{
    /// <summary>
    /// A unique ID for the desired payment.
    /// </summary>
    [JsonIgnore]
    public required string PaymentId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
