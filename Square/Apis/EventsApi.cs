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
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// EventsApi.
    /// </summary>
    internal class EventsApi : BaseApi, IEventsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventsApi"/> class.
        /// </summary>
        internal EventsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Search for Square API events that occur within a 28-day timeframe.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchEventsResponse response from the API call.</returns>
        public Models.SearchEventsResponse SearchEvents(
                Models.SearchEventsRequest body)
            => CoreHelper.RunTask(SearchEventsAsync(body));

        /// <summary>
        /// Search for Square API events that occur within a 28-day timeframe.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchEventsResponse response from the API call.</returns>
        public async Task<Models.SearchEventsResponse> SearchEventsAsync(
                Models.SearchEventsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchEventsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/events")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Disables events to prevent them from being searchable.
        /// All events are disabled by default. You must enable events to make them searchable.
        /// Disabling events for a specific time period prevents them from being searchable, even if you re-enable them later.
        /// </summary>
        /// <returns>Returns the Models.DisableEventsResponse response from the API call.</returns>
        public Models.DisableEventsResponse DisableEvents()
            => CoreHelper.RunTask(DisableEventsAsync());

        /// <summary>
        /// Disables events to prevent them from being searchable.
        /// All events are disabled by default. You must enable events to make them searchable.
        /// Disabling events for a specific time period prevents them from being searchable, even if you re-enable them later.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DisableEventsResponse response from the API call.</returns>
        public async Task<Models.DisableEventsResponse> DisableEventsAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.DisableEventsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/events/disable")
                  .WithAuth("global"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Enables events to make them searchable. Only events that occur while in the enabled state are searchable.
        /// </summary>
        /// <returns>Returns the Models.EnableEventsResponse response from the API call.</returns>
        public Models.EnableEventsResponse EnableEvents()
            => CoreHelper.RunTask(EnableEventsAsync());

        /// <summary>
        /// Enables events to make them searchable. Only events that occur while in the enabled state are searchable.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.EnableEventsResponse response from the API call.</returns>
        public async Task<Models.EnableEventsResponse> EnableEventsAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.EnableEventsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/events/enable")
                  .WithAuth("global"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Lists all event types that you can subscribe to as webhooks or query using the Events API.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <returns>Returns the Models.ListEventTypesResponse response from the API call.</returns>
        public Models.ListEventTypesResponse ListEventTypes(
                string apiVersion = null)
            => CoreHelper.RunTask(ListEventTypesAsync(apiVersion));

        /// <summary>
        /// Lists all event types that you can subscribe to as webhooks or query using the Events API.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListEventTypesResponse response from the API call.</returns>
        public async Task<Models.ListEventTypesResponse> ListEventTypesAsync(
                string apiVersion = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListEventTypesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/events/types")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("api_version", apiVersion))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}