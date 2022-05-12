namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Square;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// ITerminalApi.
    /// </summary>
    public interface ITerminalApi
    {
        /// <summary>
        /// Creates a Terminal action request and sends it to the specified device to take a payment.
        /// for the requested amount.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTerminalActionResponse response from the API call.</returns>
        Models.CreateTerminalActionResponse CreateTerminalAction(
                Models.CreateTerminalActionRequest body);

        /// <summary>
        /// Creates a Terminal action request and sends it to the specified device to take a payment.
        /// for the requested amount.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateTerminalActionResponse response from the API call.</returns>
        Task<Models.CreateTerminalActionResponse> CreateTerminalActionAsync(
                Models.CreateTerminalActionRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a filtered list of Terminal action requests created by the account making the request. Terminal action requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTerminalActionsResponse response from the API call.</returns>
        Models.SearchTerminalActionsResponse SearchTerminalActions(
                Models.SearchTerminalActionsRequest body);

        /// <summary>
        /// Retrieves a filtered list of Terminal action requests created by the account making the request. Terminal action requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTerminalActionsResponse response from the API call.</returns>
        Task<Models.SearchTerminalActionsResponse> SearchTerminalActionsAsync(
                Models.SearchTerminalActionsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a Terminal action request by `action_id`. Terminal action requests are available for 30 days.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the desired `TerminalAction`.</param>
        /// <returns>Returns the Models.GetTerminalActionResponse response from the API call.</returns>
        Models.GetTerminalActionResponse GetTerminalAction(
                string actionId);

        /// <summary>
        /// Retrieves a Terminal action request by `action_id`. Terminal action requests are available for 30 days.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the desired `TerminalAction`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTerminalActionResponse response from the API call.</returns>
        Task<Models.GetTerminalActionResponse> GetTerminalActionAsync(
                string actionId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels a Terminal action request if the status of the request permits it.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the desired `TerminalAction`.</param>
        /// <returns>Returns the Models.CancelTerminalActionResponse response from the API call.</returns>
        Models.CancelTerminalActionResponse CancelTerminalAction(
                string actionId);

        /// <summary>
        /// Cancels a Terminal action request if the status of the request permits it.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the desired `TerminalAction`.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelTerminalActionResponse response from the API call.</returns>
        Task<Models.CancelTerminalActionResponse> CancelTerminalActionAsync(
                string actionId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a Terminal checkout request and sends it to the specified device to take a payment.
        /// for the requested amount.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTerminalCheckoutResponse response from the API call.</returns>
        Models.CreateTerminalCheckoutResponse CreateTerminalCheckout(
                Models.CreateTerminalCheckoutRequest body);

        /// <summary>
        /// Creates a Terminal checkout request and sends it to the specified device to take a payment.
        /// for the requested amount.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateTerminalCheckoutResponse response from the API call.</returns>
        Task<Models.CreateTerminalCheckoutResponse> CreateTerminalCheckoutAsync(
                Models.CreateTerminalCheckoutRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns a filtered list of Terminal checkout requests created by the application making the request. Only Terminal checkout requests created for the merchant scoped to the OAuth token are returned. Terminal checkout requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTerminalCheckoutsResponse response from the API call.</returns>
        Models.SearchTerminalCheckoutsResponse SearchTerminalCheckouts(
                Models.SearchTerminalCheckoutsRequest body);

        /// <summary>
        /// Returns a filtered list of Terminal checkout requests created by the application making the request. Only Terminal checkout requests created for the merchant scoped to the OAuth token are returned. Terminal checkout requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTerminalCheckoutsResponse response from the API call.</returns>
        Task<Models.SearchTerminalCheckoutsResponse> SearchTerminalCheckoutsAsync(
                Models.SearchTerminalCheckoutsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a Terminal checkout request by `checkout_id`. Terminal checkout requests are available for 30 days.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`..</param>
        /// <returns>Returns the Models.GetTerminalCheckoutResponse response from the API call.</returns>
        Models.GetTerminalCheckoutResponse GetTerminalCheckout(
                string checkoutId);

        /// <summary>
        /// Retrieves a Terminal checkout request by `checkout_id`. Terminal checkout requests are available for 30 days.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTerminalCheckoutResponse response from the API call.</returns>
        Task<Models.GetTerminalCheckoutResponse> GetTerminalCheckoutAsync(
                string checkoutId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels a Terminal checkout request if the status of the request permits it.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`..</param>
        /// <returns>Returns the Models.CancelTerminalCheckoutResponse response from the API call.</returns>
        Models.CancelTerminalCheckoutResponse CancelTerminalCheckout(
                string checkoutId);

        /// <summary>
        /// Cancels a Terminal checkout request if the status of the request permits it.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelTerminalCheckoutResponse response from the API call.</returns>
        Task<Models.CancelTerminalCheckoutResponse> CancelTerminalCheckoutAsync(
                string checkoutId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a request to refund an Interac payment completed on a Square Terminal. Refunds for Interac payments on a Square Terminal are supported only for Interac debit cards in Canada. Other refunds for Terminal payments should use the Refunds API. For more information, see [Refunds API]($e/Refunds).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTerminalRefundResponse response from the API call.</returns>
        Models.CreateTerminalRefundResponse CreateTerminalRefund(
                Models.CreateTerminalRefundRequest body);

        /// <summary>
        /// Creates a request to refund an Interac payment completed on a Square Terminal. Refunds for Interac payments on a Square Terminal are supported only for Interac debit cards in Canada. Other refunds for Terminal payments should use the Refunds API. For more information, see [Refunds API]($e/Refunds).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateTerminalRefundResponse response from the API call.</returns>
        Task<Models.CreateTerminalRefundResponse> CreateTerminalRefundAsync(
                Models.CreateTerminalRefundRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request. Terminal refund requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTerminalRefundsResponse response from the API call.</returns>
        Models.SearchTerminalRefundsResponse SearchTerminalRefunds(
                Models.SearchTerminalRefundsRequest body);

        /// <summary>
        /// Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request. Terminal refund requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTerminalRefundsResponse response from the API call.</returns>
        Task<Models.SearchTerminalRefundsResponse> SearchTerminalRefundsAsync(
                Models.SearchTerminalRefundsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an Interac Terminal refund object by ID. Terminal refund objects are available for 30 days.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`..</param>
        /// <returns>Returns the Models.GetTerminalRefundResponse response from the API call.</returns>
        Models.GetTerminalRefundResponse GetTerminalRefund(
                string terminalRefundId);

        /// <summary>
        /// Retrieves an Interac Terminal refund object by ID. Terminal refund objects are available for 30 days.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTerminalRefundResponse response from the API call.</returns>
        Task<Models.GetTerminalRefundResponse> GetTerminalRefundAsync(
                string terminalRefundId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`..</param>
        /// <returns>Returns the Models.CancelTerminalRefundResponse response from the API call.</returns>
        Models.CancelTerminalRefundResponse CancelTerminalRefund(
                string terminalRefundId);

        /// <summary>
        /// Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelTerminalRefundResponse response from the API call.</returns>
        Task<Models.CancelTerminalRefundResponse> CancelTerminalRefundAsync(
                string terminalRefundId,
                CancellationToken cancellationToken = default);
    }
}