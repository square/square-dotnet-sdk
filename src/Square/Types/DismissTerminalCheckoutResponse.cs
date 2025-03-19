using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record DismissTerminalCheckoutResponse
{
    /// <summary>
    /// Information on errors encountered during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Current state of the checkout to be dismissed.
    /// </summary>
    [JsonPropertyName("checkout")]
    public TerminalCheckout? Checkout { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
