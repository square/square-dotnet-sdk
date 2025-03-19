using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Locations;

public record CreateCheckoutRequest
{
    /// <summary>
    /// The ID of the business location to associate the checkout with.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// A unique string that identifies this checkout among others you have created. It can be
    /// any valid string but must be unique for every order sent to Square Checkout for a given location ID.
    ///
    /// The idempotency key is used to avoid processing the same order more than once. If you are
    /// unsure whether a particular checkout was created successfully, you can attempt it again with
    /// the same idempotency key and all the same other parameters without worrying about creating duplicates.
    ///
    /// You should use a random number/string generator native to the language
    /// you are working in to generate strings for your idempotency keys.
    ///
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/working-with-apis/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The order including line items to be checked out.
    /// </summary>
    [JsonPropertyName("order")]
    public required CreateOrderRequest Order { get; set; }

    /// <summary>
    /// If `true`, Square Checkout collects shipping information on your behalf and stores
    /// that information with the transaction information in the Square Seller Dashboard.
    ///
    /// Default: `false`.
    /// </summary>
    [JsonPropertyName("ask_for_shipping_address")]
    public bool? AskForShippingAddress { get; set; }

    /// <summary>
    /// The email address to display on the Square Checkout confirmation page
    /// and confirmation email that the buyer can use to contact the seller.
    ///
    /// If this value is not set, the confirmation page and email display the
    /// primary email address associated with the seller's Square account.
    ///
    /// Default: none; only exists if explicitly set.
    /// </summary>
    [JsonPropertyName("merchant_support_email")]
    public string? MerchantSupportEmail { get; set; }

    /// <summary>
    /// If provided, the buyer's email is prepopulated on the checkout page
    /// as an editable text field.
    ///
    /// Default: none; only exists if explicitly set.
    /// </summary>
    [JsonPropertyName("pre_populate_buyer_email")]
    public string? PrePopulateBuyerEmail { get; set; }

    /// <summary>
    /// If provided, the buyer's shipping information is prepopulated on the
    /// checkout page as editable text fields.
    ///
    /// Default: none; only exists if explicitly set.
    /// </summary>
    [JsonPropertyName("pre_populate_shipping_address")]
    public Address? PrePopulateShippingAddress { get; set; }

    /// <summary>
    /// The URL to redirect to after the checkout is completed with `checkoutId`,
    /// `transactionId`, and `referenceId` appended as URL parameters. For example,
    /// if the provided redirect URL is `http://www.example.com/order-complete`, a
    /// successful transaction redirects the customer to:
    ///
    /// `http://www.example.com/order-complete?checkoutId=xxxxxx&amp;referenceId=xxxxxx&amp;transactionId=xxxxxx`
    ///
    /// If you do not provide a redirect URL, Square Checkout displays an order
    /// confirmation page on your behalf; however, it is strongly recommended that
    /// you provide a redirect URL so you can verify the transaction results and
    /// finalize the order through your existing/normal confirmation workflow.
    ///
    /// Default: none; only exists if explicitly set.
    /// </summary>
    [JsonPropertyName("redirect_url")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// The basic primitive of a multi-party transaction. The value is optional.
    /// The transaction facilitated by you can be split from here.
    ///
    /// If you provide this value, the `amount_money` value in your `additional_recipients` field
    /// cannot be more than 90% of the `total_money` calculated by Square for your order.
    /// The `location_id` must be a valid seller location where the checkout is occurring.
    ///
    /// This field requires `PAYMENTS_WRITE_ADDITIONAL_RECIPIENTS` OAuth permission.
    ///
    /// This field is currently not supported in the Square Sandbox.
    /// </summary>
    [JsonPropertyName("additional_recipients")]
    public IEnumerable<ChargeRequestAdditionalRecipient>? AdditionalRecipients { get; set; }

    /// <summary>
    /// An optional note to associate with the `checkout` object.
    ///
    /// This value cannot exceed 60 characters.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
