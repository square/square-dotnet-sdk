using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record AcceptedPaymentMethods
{
    /// <summary>
    /// Whether Apple Pay is accepted at checkout.
    /// </summary>
    [JsonPropertyName("apple_pay")]
    public bool? ApplePay { get; set; }

    /// <summary>
    /// Whether Google Pay is accepted at checkout.
    /// </summary>
    [JsonPropertyName("google_pay")]
    public bool? GooglePay { get; set; }

    /// <summary>
    /// Whether Cash App Pay is accepted at checkout.
    /// </summary>
    [JsonPropertyName("cash_app_pay")]
    public bool? CashAppPay { get; set; }

    /// <summary>
    /// Whether Afterpay/Clearpay is accepted at checkout.
    /// </summary>
    [JsonPropertyName("afterpay_clearpay")]
    public bool? AfterpayClearpay { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
