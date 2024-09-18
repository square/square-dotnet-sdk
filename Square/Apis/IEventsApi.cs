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

namespace Square.Apis
{
    /// <summary>
    /// IEventsApi.
    /// </summary>
    public interface IEventsApi
    {
        /// <summary>
        /// Search for Square API events that occur within a 28-day timeframe.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchEventsResponse response from the API call.</returns>
        Models.SearchEventsResponse SearchEvents(
                Models.SearchEventsRequest body);

        /// <summary>
        /// Search for Square API events that occur within a 28-day timeframe.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchEventsResponse response from the API call.</returns>
        Task<Models.SearchEventsResponse> SearchEventsAsync(
                Models.SearchEventsRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Disables events to prevent them from being searchable.
        /// All events are disabled by default. You must enable events to make them searchable.
        /// Disabling events for a specific time period prevents them from being searchable, even if you re-enable them later.
        /// </summary>
        /// <returns>Returns the Models.DisableEventsResponse response from the API call.</returns>
        Models.DisableEventsResponse DisableEvents();

        /// <summary>
        /// Disables events to prevent them from being searchable.
        /// All events are disabled by default. You must enable events to make them searchable.
        /// Disabling events for a specific time period prevents them from being searchable, even if you re-enable them later.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.DisableEventsResponse response from the API call.</returns>
        Task<Models.DisableEventsResponse> DisableEventsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Enables events to make them searchable. Only events that occur while in the enabled state are searchable.
        /// </summary>
        /// <returns>Returns the Models.EnableEventsResponse response from the API call.</returns>
        Models.EnableEventsResponse EnableEvents();

        /// <summary>
        /// Enables events to make them searchable. Only events that occur while in the enabled state are searchable.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.EnableEventsResponse response from the API call.</returns>
        Task<Models.EnableEventsResponse> EnableEventsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all event types that you can subscribe to as webhooks or query using the Events API.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <returns>Returns the Models.ListEventTypesResponse response from the API call.</returns>
        Models.ListEventTypesResponse ListEventTypes(
                string apiVersion = null);

        /// <summary>
        /// Lists all event types that you can subscribe to as webhooks or query using the Events API.
        /// </summary>
        /// <param name="apiVersion">Optional parameter: The API version for which to list event types. Setting this field overrides the default version used by the application..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListEventTypesResponse response from the API call.</returns>
        Task<Models.ListEventTypesResponse> ListEventTypesAsync(
                string apiVersion = null,
                CancellationToken cancellationToken = default);
    }
}