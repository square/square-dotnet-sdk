using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The payment methods that customers can use to pay an [invoice](entity:Invoice) on the Square-hosted invoice payment page.
/// </summary>
public record InvoiceAcceptedPaymentMethods
{
    /// <summary>
    /// Indicates whether credit card or debit card payments are accepted. The default value is `false`.
    /// </summary>
    [JsonPropertyName("card")]
    public bool? Card { get; set; }

    /// <summary>
    /// Indicates whether Square gift card payments are accepted. The default value is `false`.
    /// </summary>
    [JsonPropertyName("square_gift_card")]
    public bool? SquareGiftCard { get; set; }

    /// <summary>
    /// Indicates whether ACH bank transfer payments are accepted. The default value is `false`.
    /// </summary>
    [JsonPropertyName("bank_account")]
    public bool? BankAccount { get; set; }

    /// <summary>
    /// Indicates whether Afterpay (also known as Clearpay) payments are accepted. The default value is `false`.
    ///
    /// This option is allowed only for invoices that have a single payment request of the `BALANCE` type. This payment method is
    /// supported if the seller account accepts Afterpay payments and the seller location is in a country where Afterpay
    /// invoice payments are supported. As a best practice, consider enabling an additional payment method when allowing
    /// `buy_now_pay_later` payments. For more information, including detailed requirements and processing limits, see
    /// [Buy Now Pay Later payments with Afterpay](https://developer.squareup.com/docs/invoices-api/overview#buy-now-pay-later).
    /// </summary>
    [JsonPropertyName("buy_now_pay_later")]
    public bool? BuyNowPayLater { get; set; }

    /// <summary>
    /// Indicates whether Cash App payments are accepted. The default value is `false`.
    ///
    /// This payment method is supported only for seller [locations](entity:Location) in the United States.
    /// </summary>
    [JsonPropertyName("cash_app_pay")]
    public bool? CashAppPay { get; set; }

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
