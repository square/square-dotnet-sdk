using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface ITerminalApi
    {
        /// <summary>
        /// Creates a Terminal checkout request and sends it to the specified device to take a payment
        /// for the requested amount.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateTerminalCheckoutResponse response from the API call</return>
        Models.CreateTerminalCheckoutResponse CreateTerminalCheckout(Models.CreateTerminalCheckoutRequest body);

        /// <summary>
        /// Creates a Terminal checkout request and sends it to the specified device to take a payment
        /// for the requested amount.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateTerminalCheckoutResponse response from the API call</return>
        Task<Models.CreateTerminalCheckoutResponse> CreateTerminalCheckoutAsync(Models.CreateTerminalCheckoutRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a filtered list of Terminal checkout requests created by the account making the request.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchTerminalCheckoutsResponse response from the API call</return>
        Models.SearchTerminalCheckoutsResponse SearchTerminalCheckouts(Models.SearchTerminalCheckoutsRequest body);

        /// <summary>
        /// Retrieves a filtered list of Terminal checkout requests created by the account making the request.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchTerminalCheckoutsResponse response from the API call</return>
        Task<Models.SearchTerminalCheckoutsResponse> SearchTerminalCheckoutsAsync(Models.SearchTerminalCheckoutsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a Terminal checkout request by `checkout_id`.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`.</param>
        /// <return>Returns the Models.GetTerminalCheckoutResponse response from the API call</return>
        Models.GetTerminalCheckoutResponse GetTerminalCheckout(string checkoutId);

        /// <summary>
        /// Retrieves a Terminal checkout request by `checkout_id`.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`.</param>
        /// <return>Returns the Models.GetTerminalCheckoutResponse response from the API call</return>
        Task<Models.GetTerminalCheckoutResponse> GetTerminalCheckoutAsync(string checkoutId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels a Terminal checkout request if the status of the request permits it.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`.</param>
        /// <return>Returns the Models.CancelTerminalCheckoutResponse response from the API call</return>
        Models.CancelTerminalCheckoutResponse CancelTerminalCheckout(string checkoutId);

        /// <summary>
        /// Cancels a Terminal checkout request if the status of the request permits it.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`.</param>
        /// <return>Returns the Models.CancelTerminalCheckoutResponse response from the API call</return>
        Task<Models.CancelTerminalCheckoutResponse> CancelTerminalCheckoutAsync(string checkoutId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a request to refund an Interac payment completed on a Square Terminal.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateTerminalRefundResponse response from the API call</return>
        Models.CreateTerminalRefundResponse CreateTerminalRefund(Models.CreateTerminalRefundRequest body);

        /// <summary>
        /// Creates a request to refund an Interac payment completed on a Square Terminal.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateTerminalRefundResponse response from the API call</return>
        Task<Models.CreateTerminalRefundResponse> CreateTerminalRefundAsync(Models.CreateTerminalRefundRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchTerminalRefundsResponse response from the API call</return>
        Models.SearchTerminalRefundsResponse SearchTerminalRefunds(Models.SearchTerminalRefundsRequest body);

        /// <summary>
        /// Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchTerminalRefundsResponse response from the API call</return>
        Task<Models.SearchTerminalRefundsResponse> SearchTerminalRefundsAsync(Models.SearchTerminalRefundsRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves an Interac Terminal refund object by ID.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`.</param>
        /// <return>Returns the Models.GetTerminalRefundResponse response from the API call</return>
        Models.GetTerminalRefundResponse GetTerminalRefund(string terminalRefundId);

        /// <summary>
        /// Retrieves an Interac Terminal refund object by ID.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`.</param>
        /// <return>Returns the Models.GetTerminalRefundResponse response from the API call</return>
        Task<Models.GetTerminalRefundResponse> GetTerminalRefundAsync(string terminalRefundId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`.</param>
        /// <return>Returns the Models.CancelTerminalRefundResponse response from the API call</return>
        Models.CancelTerminalRefundResponse CancelTerminalRefund(string terminalRefundId);

        /// <summary>
        /// Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`.</param>
        /// <return>Returns the Models.CancelTerminalRefundResponse response from the API call</return>
        Task<Models.CancelTerminalRefundResponse> CancelTerminalRefundAsync(string terminalRefundId, CancellationToken cancellationToken = default);

    }
}