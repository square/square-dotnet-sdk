using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using Newtonsoft.Json.Converters;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// LocationsApi.
    /// </summary>
    internal class LocationsApi : BaseApi, ILocationsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationsApi"/> class.
        /// </summary>
        internal LocationsApi(GlobalConfiguration globalConfiguration)
            : base(globalConfiguration) { }

        /// <summary>
        /// Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),.
        /// including those with an inactive status. Locations are listed alphabetically by `name`.
        /// </summary>
        /// <returns>Returns the Models.ListLocationsResponse response from the API call.</returns>
        public Models.ListLocationsResponse ListLocations() =>
            CoreHelper.RunTask(ListLocationsAsync());

        /// <summary>
        /// Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),.
        /// including those with an inactive status. Locations are listed alphabetically by `name`.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLocationsResponse response from the API call.</returns>
        public async Task<Models.ListLocationsResponse> ListLocationsAsync(
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.ListLocationsResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder.Setup(HttpMethod.Get, "/v2/locations").WithAuth("global")
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Creates a [location](https://developer.squareup.com/docs/locations-api).
        /// Creating new locations allows for separate configuration of receipt layouts, item prices,.
        /// and sales reports. Developers can use locations to separate sales activity through applications.
        /// that integrate with Square from sales activity elsewhere in a seller's account.
        /// Locations created programmatically with the Locations API last forever and.
        /// are visible to the seller for their own management. Therefore, ensure that.
        /// each location has a sensible and unique name.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateLocationResponse response from the API call.</returns>
        public Models.CreateLocationResponse CreateLocation(Models.CreateLocationRequest body) =>
            CoreHelper.RunTask(CreateLocationAsync(body));

        /// <summary>
        /// Creates a [location](https://developer.squareup.com/docs/locations-api).
        /// Creating new locations allows for separate configuration of receipt layouts, item prices,.
        /// and sales reports. Developers can use locations to separate sales activity through applications.
        /// that integrate with Square from sales activity elsewhere in a seller's account.
        /// Locations created programmatically with the Locations API last forever and.
        /// are visible to the seller for their own management. Therefore, ensure that.
        /// each location has a sensible and unique name.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateLocationResponse response from the API call.</returns>
        public async Task<Models.CreateLocationResponse> CreateLocationAsync(
            Models.CreateLocationRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.CreateLocationResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Post, "/v2/locations")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Retrieves details of a single location. Specify "main".
        /// as the location ID to retrieve details of the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve. Specify the string "main" to return the main location..</param>
        /// <returns>Returns the Models.RetrieveLocationResponse response from the API call.</returns>
        public Models.RetrieveLocationResponse RetrieveLocation(string locationId) =>
            CoreHelper.RunTask(RetrieveLocationAsync(locationId));

        /// <summary>
        /// Retrieves details of a single location. Specify "main".
        /// as the location ID to retrieve details of the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve. Specify the string "main" to return the main location..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLocationResponse response from the API call.</returns>
        public async Task<Models.RetrieveLocationResponse> RetrieveLocationAsync(
            string locationId,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.RetrieveLocationResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Get, "/v2/locations/{location_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters.Template(_template =>
                                _template.Setup("location_id", locationId)
                            )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Updates a [location](https://developer.squareup.com/docs/locations-api).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateLocationResponse response from the API call.</returns>
        public Models.UpdateLocationResponse UpdateLocation(
            string locationId,
            Models.UpdateLocationRequest body
        ) => CoreHelper.RunTask(UpdateLocationAsync(locationId, body));

        /// <summary>
        /// Updates a [location](https://developer.squareup.com/docs/locations-api).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateLocationResponse response from the API call.</returns>
        public async Task<Models.UpdateLocationResponse> UpdateLocationAsync(
            string locationId,
            Models.UpdateLocationRequest body,
            CancellationToken cancellationToken = default
        ) =>
            await CreateApiCall<Models.UpdateLocationResponse>()
                .RequestBuilder(_requestBuilder =>
                    _requestBuilder
                        .Setup(HttpMethod.Put, "/v2/locations/{location_id}")
                        .WithAuth("global")
                        .Parameters(_parameters =>
                            _parameters
                                .Body(_bodyParameter => _bodyParameter.Setup(body))
                                .Template(_template => _template.Setup("location_id", locationId))
                                .Header(_header =>
                                    _header.Setup("Content-Type", "application/json")
                                )
                        )
                )
                .ResponseHandler(_responseHandler =>
                    _responseHandler.ContextAdder(
                        (_result, _context) => _result.ContextSetter(_context)
                    )
                )
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
    }
}
