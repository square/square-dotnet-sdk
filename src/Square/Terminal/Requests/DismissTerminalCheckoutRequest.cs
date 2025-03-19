using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Terminal;

public record DismissTerminalCheckoutRequest
{
    /// <summary>
    /// Unique ID for the `TerminalCheckout` associated with the checkout to be dismissed.
    /// </summary>
    [JsonIgnore]
    public required string CheckoutId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
