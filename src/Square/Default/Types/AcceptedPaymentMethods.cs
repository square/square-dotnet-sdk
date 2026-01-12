using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

[Serializable]
public record AcceptedPaymentMethods : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
