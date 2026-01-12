using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Terminal.Checkouts;

[Serializable]
public record CancelCheckoutsRequest
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
