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
    public interface ILocationsApi
    {
        /// <summary>
        /// Provides information of all locations of a business.
        /// Most other Connect API endpoints have a required `location_id` path parameter.
        /// The `id` field of the [`Location`](#type-location) objects returned by this
        /// endpoint correspond to that `location_id` parameter.
        /// </summary>
        /// <return>Returns the Models.ListLocationsResponse response from the API call</return>
        Models.ListLocationsResponse ListLocations();

        /// <summary>
        /// Provides information of all locations of a business.
        /// Most other Connect API endpoints have a required `location_id` path parameter.
        /// The `id` field of the [`Location`](#type-location) objects returned by this
        /// endpoint correspond to that `location_id` parameter.
        /// </summary>
        /// <return>Returns the Models.ListLocationsResponse response from the API call</return>
        Task<Models.ListLocationsResponse> ListLocationsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a location.
        /// For more information about locations, see [Locations API Overview](https://developer.squareup.com/docs/locations-api).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLocationResponse response from the API call</return>
        Models.CreateLocationResponse CreateLocation(Models.CreateLocationRequest body);

        /// <summary>
        /// Creates a location.
        /// For more information about locations, see [Locations API Overview](https://developer.squareup.com/docs/locations-api).
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateLocationResponse response from the API call</return>
        Task<Models.CreateLocationResponse> CreateLocationAsync(Models.CreateLocationRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details of a location. You can specify "main" 
        /// as the location ID to retrieve details of the 
        /// main location. For more information, 
        /// see [Locations API Overview](https://developer.squareup.com/docs/docs/locations-api).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve. If you specify the string "main", then the endpoint returns the main location.</param>
        /// <return>Returns the Models.RetrieveLocationResponse response from the API call</return>
        Models.RetrieveLocationResponse RetrieveLocation(string locationId);

        /// <summary>
        /// Retrieves details of a location. You can specify "main" 
        /// as the location ID to retrieve details of the 
        /// main location. For more information, 
        /// see [Locations API Overview](https://developer.squareup.com/docs/docs/locations-api).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve. If you specify the string "main", then the endpoint returns the main location.</param>
        /// <return>Returns the Models.RetrieveLocationResponse response from the API call</return>
        Task<Models.RetrieveLocationResponse> RetrieveLocationAsync(string locationId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateLocationResponse response from the API call</return>
        Models.UpdateLocationResponse UpdateLocation(string locationId, Models.UpdateLocationRequest body);

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to update.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateLocationResponse response from the API call</return>
        Task<Models.UpdateLocationResponse> UpdateLocationAsync(string locationId, Models.UpdateLocationRequest body, CancellationToken cancellationToken = default);

    }
}