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
    /// ILocationsApi.
    /// </summary>
    public interface ILocationsApi
    {
        /// <summary>
        /// Provides information of all locations of a business.
        /// Many Square API endpoints require a `location_id` parameter.
        /// The `id` field of the [`Location`]($m/Location) objects returned by this.
        /// endpoint correspond to that `location_id` parameter.
        /// </summary>
        /// <returns>Returns the Models.ListLocationsResponse response from the API call.</returns>
        Models.ListLocationsResponse ListLocations();

        /// <summary>
        /// Provides information of all locations of a business.
        /// Many Square API endpoints require a `location_id` parameter.
        /// The `id` field of the [`Location`]($m/Location) objects returned by this.
        /// endpoint correspond to that `location_id` parameter.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLocationsResponse response from the API call.</returns>
        Task<Models.ListLocationsResponse> ListLocationsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a location.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateLocationResponse response from the API call.</returns>
        Models.CreateLocationResponse CreateLocation(
                Models.CreateLocationRequest body);

        /// <summary>
        /// Creates a location.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateLocationResponse response from the API call.</returns>
        Task<Models.CreateLocationResponse> CreateLocationAsync(
                Models.CreateLocationRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details of a location. You can specify "main" .
        /// as the location ID to retrieve details of the .
        /// main location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve. If you specify the string "main", then the endpoint returns the main location..</param>
        /// <returns>Returns the Models.RetrieveLocationResponse response from the API call.</returns>
        Models.RetrieveLocationResponse RetrieveLocation(
                string locationId);

        /// <summary>
        /// Retrieves details of a location. You can specify "main" .
        /// as the location ID to retrieve details of the .
        /// main location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve. If you specify the string "main", then the endpoint returns the main location..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLocationResponse response from the API call.</returns>
        Task<Models.RetrieveLocationResponse> RetrieveLocationAsync(
                string locationId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateLocationResponse response from the API call.</returns>
        Models.UpdateLocationResponse UpdateLocation(
                string locationId,
                Models.UpdateLocationRequest body);

        /// <summary>
        /// Updates a location.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateLocationResponse response from the API call.</returns>
        Task<Models.UpdateLocationResponse> UpdateLocationAsync(
                string locationId,
                Models.UpdateLocationRequest body,
                CancellationToken cancellationToken = default);
    }
}