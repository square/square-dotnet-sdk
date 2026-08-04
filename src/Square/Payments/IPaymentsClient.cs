using Square;
using Square.Core;

namespace Square.Payments;

public partial interface IPaymentsClient
{
    /// <summary>
    /// Retrieves a list of payments taken by the account making the request.
    ///
    /// Results are eventually consistent, and new payments or changes to payments might take several
    /// seconds to appear.
    ///
    /// The maximum results per page is 100.
    /// </summary>
    Task<Pager<Payment>> ListAsync(
        ListPaymentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a payment using the provided source. You can use this endpoint
    /// to charge a card (credit/debit card or
    /// Square gift card) or record a payment that the seller received outside of Square
    /// (cash payment from a buyer or a payment that an external entity
    /// processed on behalf of the seller).
    ///
    /// The endpoint creates a
    /// `Payment` object and returns it in the response.
    /// </summary>
    Task<CreatePaymentResponse> CreateAsync(
        CreatePaymentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels (voids) a payment identified by the idempotency key that is specified in the
    /// request.
    ///
    /// Use this method when the status of a `CreatePayment` request is unknown (for example, after you send a
    /// `CreatePayment` request, a network error occurs and you do not get a response). In this case, you can
    /// direct Square to cancel the payment using this endpoint. In the request, you provide the same
    /// idempotency key that you provided in your `CreatePayment` request that you want to cancel. After
    /// canceling the payment, you can submit your `CreatePayment` request again.
    ///
    /// Note that if no payment with the specified idempotency key is found, no action is taken and the endpoint
    /// returns successfully.
    /// </summary>
    Task<CancelPaymentByIdempotencyKeyResponse> CancelByIdempotencyKeyAsync(
        CancelPaymentByIdempotencyKeyRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves details for a specific payment.
    /// </summary>
    Task<GetPaymentResponse> GetAsync(
        GetPaymentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a payment with the APPROVED status.
    /// You can update the `amount_money` and `tip_money` using this endpoint.
    /// </summary>
    Task<UpdatePaymentResponse> UpdateAsync(
        UpdatePaymentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels (voids) a payment. You can use this endpoint to cancel a payment with
    /// the APPROVED `status`.
    /// </summary>
    Task<CancelPaymentResponse> CancelAsync(
        CancelPaymentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Completes (captures) a payment.
    /// By default, payments are set to complete immediately after they are created.
    ///
    /// You can use this endpoint to complete a payment with the APPROVED `status`.
    /// </summary>
    Task<CompletePaymentResponse> CompleteAsync(
        CompletePaymentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
