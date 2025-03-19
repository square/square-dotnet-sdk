using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Details about the customer making the payment.
/// </summary>
public record CustomerDetails
{
    /// <summary>
    /// Indicates whether the customer initiated the payment.
    /// </summary>
    [JsonPropertyName("customer_initiated")]
    public bool? CustomerInitiated { get; set; }

    /// <summary>
    /// Indicates that the seller keyed in payment details on behalf of the customer.
    /// This is used to flag a payment as Mail Order / Telephone Order (MOTO).
    /// </summary>
    [JsonPropertyName("seller_keyed_in")]
    public bool? SellerKeyedIn { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
