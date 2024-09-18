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
    /// ILocationsApi.
    /// </summary>
    public interface ILocationsApi
    {
        /// <summary>
        /// Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),.
        /// including those with an inactive status. Locations are listed alphabetically by `name`.
        /// </summary>
        /// <returns>Returns the Models.ListLocationsResponse response from the API call.</returns>
        Models.ListLocationsResponse ListLocations();

        /// <summary>
        /// Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),.
        /// including those with an inactive status. Locations are listed alphabetically by `name`.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLocationsResponse response from the API call.</returns>
        Task<Models.ListLocationsResponse> ListLocationsAsync(CancellationToken cancellationToken = default);

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
        Models.CreateLocationResponse CreateLocation(
                Models.CreateLocationRequest body);

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
        Task<Models.CreateLocationResponse> CreateLocationAsync(
                Models.CreateLocationRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves details of a single location. Specify "main".
        /// as the location ID to retrieve details of the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve. Specify the string "main" to return the main location..</param>
        /// <returns>Returns the Models.RetrieveLocationResponse response from the API call.</returns>
        Models.RetrieveLocationResponse RetrieveLocation(
                string locationId);

        /// <summary>
        /// Retrieves details of a single location. Specify "main".
        /// as the location ID to retrieve details of the [main location](https://developer.squareup.com/docs/locations-api#about-the-main-location).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve. Specify the string "main" to return the main location..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLocationResponse response from the API call.</returns>
        Task<Models.RetrieveLocationResponse> RetrieveLocationAsync(
                string locationId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a [location](https://developer.squareup.com/docs/locations-api).
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to update..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateLocationResponse response from the API call.</returns>
        Models.UpdateLocationResponse UpdateLocation(
                string locationId,
                Models.UpdateLocationRequest body);

        /// <summary>
        /// Updates a [location](https://developer.squareup.com/docs/locations-api).
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