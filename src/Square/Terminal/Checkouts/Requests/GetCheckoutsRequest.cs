using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Terminal.Checkouts;

public record GetCheckoutsRequest
{
    /// <summary>
    /// The unique ID for the desired `TerminalCheckout`.
    /// </summary>
    [JsonIgnore]
    public required string CheckoutId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
