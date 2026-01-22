using Square;
using Square.Core;

namespace Square.Default;

public partial interface IRefundsClient
{
    /// <summary>
    /// Retrieves a list of refunds for the account making the request.
    ///
    /// Results are eventually consistent, and new refunds or changes to refunds might take several
    /// seconds to appear.
    ///
    /// The maximum results per page is 100.
    /// </summary>
    Task<Pager<PaymentRefund>> ListAsync(
        ListRefundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Refunds a payment. You can refund the entire payment amount or a
    /// portion of it. You can use this endpoint to refund a card payment or record a
    /// refund of a cash or external payment. For more information, see
    /// [Refund Payment](https://developer.squareup.com/docs/payments-api/refund-payments).
    /// </summary>
    Task<RefundPaymentResponse> RefundPaymentAsync(
        RefundPaymentRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a specific refund using the `refund_id`.
    /// </summary>
    Task<GetPaymentRefundResponse> GetAsync(
        GetRefundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
