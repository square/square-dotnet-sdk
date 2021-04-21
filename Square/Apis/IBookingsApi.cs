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
    /// IBookingsApi.
    /// </summary>
    public interface IBookingsApi
    {
        /// <summary>
        /// Creates a booking..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBookingResponse response from the API call.</returns>
        Models.CreateBookingResponse CreateBooking(
                Models.CreateBookingRequest body);

        /// <summary>
        /// Creates a booking..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateBookingResponse response from the API call.</returns>
        Task<Models.CreateBookingResponse> CreateBookingAsync(
                Models.CreateBookingRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for availabilities for booking..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchAvailabilityResponse response from the API call.</returns>
        Models.SearchAvailabilityResponse SearchAvailability(
                Models.SearchAvailabilityRequest body);

        /// <summary>
        /// Searches for availabilities for booking..
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchAvailabilityResponse response from the API call.</returns>
        Task<Models.SearchAvailabilityResponse> SearchAvailabilityAsync(
                Models.SearchAvailabilityRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a seller's booking profile..
        /// </summary>
        /// <returns>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call.</returns>
        Models.RetrieveBusinessBookingProfileResponse RetrieveBusinessBookingProfile();

        /// <summary>
        /// Retrieves a seller's booking profile..
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call.</returns>
        Task<Models.RetrieveBusinessBookingProfileResponse> RetrieveBusinessBookingProfileAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists booking profiles for team members..
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return..</param>
        /// <param name="cursor">Optional parameter: The cursor for paginating through the results..</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result..</param>
        /// <returns>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call.</returns>
        Models.ListTeamMemberBookingProfilesResponse ListTeamMemberBookingProfiles(
                bool? bookableOnly = false,
                int? limit = null,
                string cursor = null,
                string locationId = null);

        /// <summary>
        /// Lists booking profiles for team members..
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return..</param>
        /// <param name="cursor">Optional parameter: The cursor for paginating through the results..</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call.</returns>
        Task<Models.ListTeamMemberBookingProfilesResponse> ListTeamMemberBookingProfilesAsync(
                bool? bookableOnly = false,
                int? limit = null,
                string cursor = null,
                string locationId = null,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a team member's booking profile..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call.</returns>
        Models.RetrieveTeamMemberBookingProfileResponse RetrieveTeamMemberBookingProfile(
                string teamMemberId);

        /// <summary>
        /// Retrieves a team member's booking profile..
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call.</returns>
        Task<Models.RetrieveTeamMemberBookingProfileResponse> RetrieveTeamMemberBookingProfileAsync(
                string teamMemberId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a booking..
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-retrieved booking..</param>
        /// <returns>Returns the Models.RetrieveBookingResponse response from the API call.</returns>
        Models.RetrieveBookingResponse RetrieveBooking(
                string bookingId);

        /// <summary>
        /// Retrieves a booking..
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-retrieved booking..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingResponse response from the API call.</returns>
        Task<Models.RetrieveBookingResponse> RetrieveBookingAsync(
                string bookingId,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a booking..
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-updated booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateBookingResponse response from the API call.</returns>
        Models.UpdateBookingResponse UpdateBooking(
                string bookingId,
                Models.UpdateBookingRequest body);

        /// <summary>
        /// Updates a booking..
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-updated booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateBookingResponse response from the API call.</returns>
        Task<Models.UpdateBookingResponse> UpdateBookingAsync(
                string bookingId,
                Models.UpdateBookingRequest body,
                CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels an existing booking..
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-cancelled booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CancelBookingResponse response from the API call.</returns>
        Models.CancelBookingResponse CancelBooking(
                string bookingId,
                Models.CancelBookingRequest body);

        /// <summary>
        /// Cancels an existing booking..
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-cancelled booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelBookingResponse response from the API call.</returns>
        Task<Models.CancelBookingResponse> CancelBookingAsync(
                string bookingId,
                Models.CancelBookingRequest body,
                CancellationToken cancellationToken = default);
    }
}