using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record PaymentOptions
{
    /// <summary>
    /// Indicates whether the `Payment` objects created from this `TerminalCheckout` are automatically
    /// `COMPLETED` or left in an `APPROVED` state for later modification.
    ///
    /// Default: true
    /// </summary>
    [JsonPropertyName("autocomplete")]
    public bool? Autocomplete { get; set; }

    /// <summary>
    /// The duration of time after the payment's creation when Square automatically resolves the
    /// payment. This automatic resolution applies only to payments that do not reach a terminal state
    /// (`COMPLETED` or `CANCELED`) before the `delay_duration` time period.
    ///
    /// This parameter should be specified as a time duration, in RFC 3339 format, with a minimum value
    /// of 1 minute and a maximum value of 36 hours. This feature is only supported for card payments,
    /// and all payments will be considered card-present.
    ///
    /// This parameter can only be set for a delayed capture payment (`autocomplete=false`). For more
    /// information, see [Delayed Capture](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture#time-threshold).
    ///
    /// Default: "PT36H" (36 hours) from the creation time
    /// </summary>
    [JsonPropertyName("delay_duration")]
    public string? DelayDuration { get; set; }

    /// <summary>
    /// If set to `true` and charging a Square Gift Card, a payment might be returned with
    /// `amount_money` equal to less than what was requested. For example, a request for $20 when charging
    /// a Square Gift Card with a balance of $5 results in an APPROVED payment of $5. You might choose
    /// to prompt the buyer for an additional payment to cover the remainder or cancel the Gift Card
    /// payment.
    ///
    /// This parameter can only be set for a delayed capture payment (`autocomplete=false`).
    ///
    /// For more information, see [Take Partial Payments](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/partial-payments-with-gift-cards).
    ///
    /// Default: false
    /// </summary>
    [JsonPropertyName("accept_partial_authorization")]
    public bool? AcceptPartialAuthorization { get; set; }

    /// <summary>
    /// The action to be applied to the `Payment` when the delay_duration has elapsed.
    /// The action must be CANCEL or COMPLETE.
    ///
    /// The action cannot be set to COMPLETE if an `order_id` is present on the TerminalCheckout.
    ///
    /// This parameter can only be set for a delayed capture payment (`autocomplete=false`). For more
    /// information, see [Delayed Capture](https://developer.squareup.com/docs/payments-api/take-payments/card-payments/delayed-capture#time-threshold).
    ///
    /// Default: CANCEL
    /// See [DelayAction](#type-delayaction) for possible values
    /// </summary>
    [JsonPropertyName("delay_action")]
    public PaymentOptionsDelayAction? DelayAction { get; set; }

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
