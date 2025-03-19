using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Additional details about a Buy Now Pay Later payment type.
/// </summary>
public record BuyNowPayLaterDetails
{
    /// <summary>
    /// The brand used for the Buy Now Pay Later payment.
    /// The brand can be `AFTERPAY`, `CLEARPAY` or `UNKNOWN`.
    /// </summary>
    [JsonPropertyName("brand")]
    public string? Brand { get; set; }

    /// <summary>
    /// Details about an Afterpay payment. These details are only populated if the `brand` is
    /// `AFTERPAY`.
    /// </summary>
    [JsonPropertyName("afterpay_details")]
    public AfterpayDetails? AfterpayDetails { get; set; }

    /// <summary>
    /// Details about a Clearpay payment. These details are only populated if the `brand` is
    /// `CLEARPAY`.
    /// </summary>
    [JsonPropertyName("clearpay_details")]
    public ClearpayDetails? ClearpayDetails { get; set; }

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
