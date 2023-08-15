namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// TerminalApi.
    /// </summary>
    internal class TerminalApi : BaseApi, ITerminalApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalApi"/> class.
        /// </summary>
        internal TerminalApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Creates a Terminal action request and sends it to the specified device.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTerminalActionResponse response from the API call.</returns>
        public Models.CreateTerminalActionResponse CreateTerminalAction(
                Models.CreateTerminalActionRequest body)
            => CoreHelper.RunTask(CreateTerminalActionAsync(body));

        /// <summary>
        /// Creates a Terminal action request and sends it to the specified device.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateTerminalActionResponse response from the API call.</returns>
        public async Task<Models.CreateTerminalActionResponse> CreateTerminalActionAsync(
                Models.CreateTerminalActionRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateTerminalActionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/actions")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a filtered list of Terminal action requests created by the account making the request. Terminal action requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTerminalActionsResponse response from the API call.</returns>
        public Models.SearchTerminalActionsResponse SearchTerminalActions(
                Models.SearchTerminalActionsRequest body)
            => CoreHelper.RunTask(SearchTerminalActionsAsync(body));

        /// <summary>
        /// Retrieves a filtered list of Terminal action requests created by the account making the request. Terminal action requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTerminalActionsResponse response from the API call.</returns>
        public async Task<Models.SearchTerminalActionsResponse> SearchTerminalActionsAsync(
                Models.SearchTerminalActionsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchTerminalActionsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/actions/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a Terminal action request by `action_id`. Terminal action requests are available for 30 days.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the desired `TerminalAction`..</param>
        /// <returns>Returns the Models.GetTerminalActionResponse response from the API call.</returns>
        public Models.GetTerminalActionResponse GetTerminalAction(
                string actionId)
            => CoreHelper.RunTask(GetTerminalActionAsync(actionId));

        /// <summary>
        /// Retrieves a Terminal action request by `action_id`. Terminal action requests are available for 30 days.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the desired `TerminalAction`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTerminalActionResponse response from the API call.</returns>
        public async Task<Models.GetTerminalActionResponse> GetTerminalActionAsync(
                string actionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetTerminalActionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/terminals/actions/{action_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("action_id", actionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Cancels a Terminal action request if the status of the request permits it.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the desired `TerminalAction`..</param>
        /// <returns>Returns the Models.CancelTerminalActionResponse response from the API call.</returns>
        public Models.CancelTerminalActionResponse CancelTerminalAction(
                string actionId)
            => CoreHelper.RunTask(CancelTerminalActionAsync(actionId));

        /// <summary>
        /// Cancels a Terminal action request if the status of the request permits it.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the desired `TerminalAction`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelTerminalActionResponse response from the API call.</returns>
        public async Task<Models.CancelTerminalActionResponse> CancelTerminalActionAsync(
                string actionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CancelTerminalActionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/actions/{action_id}/cancel")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("action_id", actionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Dismisses a Terminal action request if the status and type of the request permits it.
        /// See [Link and Dismiss Actions](https://developer.squareup.com/docs/terminal-api/advanced-features/custom-workflows/link-and-dismiss-actions) for more details.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the `TerminalAction` associated with the waiting dialog to be dismissed..</param>
        /// <returns>Returns the Models.DismissTerminalActionResponse response from the API call.</returns>
        public Models.DismissTerminalActionResponse DismissTerminalAction(
                string actionId)
            => CoreHelper.RunTask(DismissTerminalActionAsync(actionId));

        /// <summary>
        /// Dismisses a Terminal action request if the status and type of the request permits it.
        /// See [Link and Dismiss Actions](https://developer.squareup.com/docs/terminal-api/advanced-features/custom-workflows/link-and-dismiss-actions) for more details.
        /// </summary>
        /// <param name="actionId">Required parameter: Unique ID for the `TerminalAction` associated with the waiting dialog to be dismissed..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DismissTerminalActionResponse response from the API call.</returns>
        public async Task<Models.DismissTerminalActionResponse> DismissTerminalActionAsync(
                string actionId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DismissTerminalActionResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/actions/{action_id}/dismiss")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("action_id", actionId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates a Terminal checkout request and sends it to the specified device to take a payment.
        /// for the requested amount.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTerminalCheckoutResponse response from the API call.</returns>
        public Models.CreateTerminalCheckoutResponse CreateTerminalCheckout(
                Models.CreateTerminalCheckoutRequest body)
            => CoreHelper.RunTask(CreateTerminalCheckoutAsync(body));

        /// <summary>
        /// Creates a Terminal checkout request and sends it to the specified device to take a payment.
        /// for the requested amount.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateTerminalCheckoutResponse response from the API call.</returns>
        public async Task<Models.CreateTerminalCheckoutResponse> CreateTerminalCheckoutAsync(
                Models.CreateTerminalCheckoutRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateTerminalCheckoutResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/checkouts")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Returns a filtered list of Terminal checkout requests created by the application making the request. Only Terminal checkout requests created for the merchant scoped to the OAuth token are returned. Terminal checkout requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTerminalCheckoutsResponse response from the API call.</returns>
        public Models.SearchTerminalCheckoutsResponse SearchTerminalCheckouts(
                Models.SearchTerminalCheckoutsRequest body)
            => CoreHelper.RunTask(SearchTerminalCheckoutsAsync(body));

        /// <summary>
        /// Returns a filtered list of Terminal checkout requests created by the application making the request. Only Terminal checkout requests created for the merchant scoped to the OAuth token are returned. Terminal checkout requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTerminalCheckoutsResponse response from the API call.</returns>
        public async Task<Models.SearchTerminalCheckoutsResponse> SearchTerminalCheckoutsAsync(
                Models.SearchTerminalCheckoutsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchTerminalCheckoutsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/checkouts/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a Terminal checkout request by `checkout_id`. Terminal checkout requests are available for 30 days.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`..</param>
        /// <returns>Returns the Models.GetTerminalCheckoutResponse response from the API call.</returns>
        public Models.GetTerminalCheckoutResponse GetTerminalCheckout(
                string checkoutId)
            => CoreHelper.RunTask(GetTerminalCheckoutAsync(checkoutId));

        /// <summary>
        /// Retrieves a Terminal checkout request by `checkout_id`. Terminal checkout requests are available for 30 days.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTerminalCheckoutResponse response from the API call.</returns>
        public async Task<Models.GetTerminalCheckoutResponse> GetTerminalCheckoutAsync(
                string checkoutId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetTerminalCheckoutResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/terminals/checkouts/{checkout_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("checkout_id", checkoutId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Cancels a Terminal checkout request if the status of the request permits it.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`..</param>
        /// <returns>Returns the Models.CancelTerminalCheckoutResponse response from the API call.</returns>
        public Models.CancelTerminalCheckoutResponse CancelTerminalCheckout(
                string checkoutId)
            => CoreHelper.RunTask(CancelTerminalCheckoutAsync(checkoutId));

        /// <summary>
        /// Cancels a Terminal checkout request if the status of the request permits it.
        /// </summary>
        /// <param name="checkoutId">Required parameter: The unique ID for the desired `TerminalCheckout`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelTerminalCheckoutResponse response from the API call.</returns>
        public async Task<Models.CancelTerminalCheckoutResponse> CancelTerminalCheckoutAsync(
                string checkoutId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CancelTerminalCheckoutResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/checkouts/{checkout_id}/cancel")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("checkout_id", checkoutId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Creates a request to refund an Interac payment completed on a Square Terminal. Refunds for Interac payments on a Square Terminal are supported only for Interac debit cards in Canada. Other refunds for Terminal payments should use the Refunds API. For more information, see [Refunds API]($e/Refunds).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateTerminalRefundResponse response from the API call.</returns>
        public Models.CreateTerminalRefundResponse CreateTerminalRefund(
                Models.CreateTerminalRefundRequest body)
            => CoreHelper.RunTask(CreateTerminalRefundAsync(body));

        /// <summary>
        /// Creates a request to refund an Interac payment completed on a Square Terminal. Refunds for Interac payments on a Square Terminal are supported only for Interac debit cards in Canada. Other refunds for Terminal payments should use the Refunds API. For more information, see [Refunds API]($e/Refunds).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateTerminalRefundResponse response from the API call.</returns>
        public async Task<Models.CreateTerminalRefundResponse> CreateTerminalRefundAsync(
                Models.CreateTerminalRefundRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateTerminalRefundResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/refunds")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request. Terminal refund requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchTerminalRefundsResponse response from the API call.</returns>
        public Models.SearchTerminalRefundsResponse SearchTerminalRefunds(
                Models.SearchTerminalRefundsRequest body)
            => CoreHelper.RunTask(SearchTerminalRefundsAsync(body));

        /// <summary>
        /// Retrieves a filtered list of Interac Terminal refund requests created by the seller making the request. Terminal refund requests are available for 30 days.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchTerminalRefundsResponse response from the API call.</returns>
        public async Task<Models.SearchTerminalRefundsResponse> SearchTerminalRefundsAsync(
                Models.SearchTerminalRefundsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchTerminalRefundsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/refunds/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves an Interac Terminal refund object by ID. Terminal refund objects are available for 30 days.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`..</param>
        /// <returns>Returns the Models.GetTerminalRefundResponse response from the API call.</returns>
        public Models.GetTerminalRefundResponse GetTerminalRefund(
                string terminalRefundId)
            => CoreHelper.RunTask(GetTerminalRefundAsync(terminalRefundId));

        /// <summary>
        /// Retrieves an Interac Terminal refund object by ID. Terminal refund objects are available for 30 days.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.GetTerminalRefundResponse response from the API call.</returns>
        public async Task<Models.GetTerminalRefundResponse> GetTerminalRefundAsync(
                string terminalRefundId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.GetTerminalRefundResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/terminals/refunds/{terminal_refund_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("terminal_refund_id", terminalRefundId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`..</param>
        /// <returns>Returns the Models.CancelTerminalRefundResponse response from the API call.</returns>
        public Models.CancelTerminalRefundResponse CancelTerminalRefund(
                string terminalRefundId)
            => CoreHelper.RunTask(CancelTerminalRefundAsync(terminalRefundId));

        /// <summary>
        /// Cancels an Interac Terminal refund request by refund request ID if the status of the request permits it.
        /// </summary>
        /// <param name="terminalRefundId">Required parameter: The unique ID for the desired `TerminalRefund`..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelTerminalRefundResponse response from the API call.</returns>
        public async Task<Models.CancelTerminalRefundResponse> CancelTerminalRefundAsync(
                string terminalRefundId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CancelTerminalRefundResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/terminals/refunds/{terminal_refund_id}/cancel")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("terminal_refund_id", terminalRefundId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken);
    }
}