using Square;
using Square.Core;

namespace Square.Checkout.PaymentLinks;

public partial interface IPaymentLinksClient
{
    /// <summary>
    /// Lists all payment links.
    /// </summary>
    Task<Pager<PaymentLink>> ListAsync(
        ListPaymentLinksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a Square-hosted checkout page. Applications can share the resulting payment link with their buyer to pay for goods and services.
    /// </summary>
    Task<CreatePaymentLinkResponse> CreateAsync(
        CreatePaymentLinkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a payment link.
    /// </summary>
    Task<GetPaymentLinkResponse> GetAsync(
        GetPaymentLinksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a payment link. You can update the `payment_link` fields such as
    /// `description`, `checkout_options`, and  `pre_populated_data`.
    /// You cannot update other fields such as the `order_id`, `version`, `URL`, or `timestamp` field.
    /// </summary>
    Task<UpdatePaymentLinkResponse> UpdateAsync(
        UpdatePaymentLinkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a payment link.
    /// </summary>
    Task<DeletePaymentLinkResponse> DeleteAsync(
        DeletePaymentLinksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
