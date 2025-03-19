using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Http.Request;
using Square.Legacy.Http.Response;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// IBookingsApi.
    /// </summary>
    public interface IBookingsApi
    {
        /// <summary>
        /// Retrieve a collection of bookings.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results per page to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="customerId">Optional parameter: The [customer](entity:Customer) for whom to retrieve bookings. If this is not set, bookings for all customers are retrieved..</param>
        /// <param name="teamMemberId">Optional parameter: The team member for whom to retrieve bookings. If this is not set, bookings of all members are retrieved..</param>
        /// <param name="locationId">Optional parameter: The location for which to retrieve bookings. If this is not set, all locations' bookings are retrieved..</param>
        /// <param name="startAtMin">Optional parameter: The RFC 3339 timestamp specifying the earliest of the start time. If this is not set, the current time is used..</param>
        /// <param name="startAtMax">Optional parameter: The RFC 3339 timestamp specifying the latest of the start time. If this is not set, the time of 31 days after `start_at_min` is used..</param>
        /// <returns>Returns the Models.ListBookingsResponse response from the API call.</returns>
        Models.ListBookingsResponse ListBookings(
            int? limit = null,
            string cursor = null,
            string customerId = null,
            string teamMemberId = null,
            string locationId = null,
            string startAtMin = null,
            string startAtMax = null
        );

        /// <summary>
        /// Retrieve a collection of bookings.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results per page to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="customerId">Optional parameter: The [customer](entity:Customer) for whom to retrieve bookings. If this is not set, bookings for all customers are retrieved..</param>
        /// <param name="teamMemberId">Optional parameter: The team member for whom to retrieve bookings. If this is not set, bookings of all members are retrieved..</param>
        /// <param name="locationId">Optional parameter: The location for which to retrieve bookings. If this is not set, all locations' bookings are retrieved..</param>
        /// <param name="startAtMin">Optional parameter: The RFC 3339 timestamp specifying the earliest of the start time. If this is not set, the current time is used..</param>
        /// <param name="startAtMax">Optional parameter: The RFC 3339 timestamp specifying the latest of the start time. If this is not set, the time of 31 days after `start_at_min` is used..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBookingsResponse response from the API call.</returns>
        Task<Models.ListBookingsResponse> ListBookingsAsync(
            int? limit = null,
            string cursor = null,
            string customerId = null,
            string teamMemberId = null,
            string locationId = null,
            string startAtMin = null,
            string startAtMax = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Creates a booking.
        /// The required input must include the following:.
        /// - `Booking.location_id`.
        /// - `Booking.start_at`.
        /// - `Booking.AppointmentSegment.team_member_id`.
        /// - `Booking.AppointmentSegment.service_variation_id`.
        /// - `Booking.AppointmentSegment.service_variation_version`.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBookingResponse response from the API call.</returns>
        Models.CreateBookingResponse CreateBooking(Models.CreateBookingRequest body);

        /// <summary>
        /// Creates a booking.
        /// The required input must include the following:.
        /// - `Booking.location_id`.
        /// - `Booking.start_at`.
        /// - `Booking.AppointmentSegment.team_member_id`.
        /// - `Booking.AppointmentSegment.service_variation_id`.
        /// - `Booking.AppointmentSegment.service_variation_version`.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateBookingResponse response from the API call.</returns>
        Task<Models.CreateBookingResponse> CreateBookingAsync(
            Models.CreateBookingRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Searches for availabilities for booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchAvailabilityResponse response from the API call.</returns>
        Models.SearchAvailabilityResponse SearchAvailability(Models.SearchAvailabilityRequest body);

        /// <summary>
        /// Searches for availabilities for booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchAvailabilityResponse response from the API call.</returns>
        Task<Models.SearchAvailabilityResponse> SearchAvailabilityAsync(
            Models.SearchAvailabilityRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Bulk-Retrieves a list of bookings by booking IDs.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkRetrieveBookingsResponse response from the API call.</returns>
        Models.BulkRetrieveBookingsResponse BulkRetrieveBookings(
            Models.BulkRetrieveBookingsRequest body
        );

        /// <summary>
        /// Bulk-Retrieves a list of bookings by booking IDs.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkRetrieveBookingsResponse response from the API call.</returns>
        Task<Models.BulkRetrieveBookingsResponse> BulkRetrieveBookingsAsync(
            Models.BulkRetrieveBookingsRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves a seller's booking profile.
        /// </summary>
        /// <returns>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call.</returns>
        Models.RetrieveBusinessBookingProfileResponse RetrieveBusinessBookingProfile();

        /// <summary>
        /// Retrieves a seller's booking profile.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call.</returns>
        Task<Models.RetrieveBusinessBookingProfileResponse> RetrieveBusinessBookingProfileAsync(
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Lists location booking profiles of a seller.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <returns>Returns the Models.ListLocationBookingProfilesResponse response from the API call.</returns>
        Models.ListLocationBookingProfilesResponse ListLocationBookingProfiles(
            int? limit = null,
            string cursor = null
        );

        /// <summary>
        /// Lists location booking profiles of a seller.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLocationBookingProfilesResponse response from the API call.</returns>
        Task<Models.ListLocationBookingProfilesResponse> ListLocationBookingProfilesAsync(
            int? limit = null,
            string cursor = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves a seller's location booking profile.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve the booking profile..</param>
        /// <returns>Returns the Models.RetrieveLocationBookingProfileResponse response from the API call.</returns>
        Models.RetrieveLocationBookingProfileResponse RetrieveLocationBookingProfile(
            string locationId
        );

        /// <summary>
        /// Retrieves a seller's location booking profile.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve the booking profile..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLocationBookingProfileResponse response from the API call.</returns>
        Task<Models.RetrieveLocationBookingProfileResponse> RetrieveLocationBookingProfileAsync(
            string locationId,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Lists booking profiles for team members.
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result..</param>
        /// <returns>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call.</returns>
        Models.ListTeamMemberBookingProfilesResponse ListTeamMemberBookingProfiles(
            bool? bookableOnly = false,
            int? limit = null,
            string cursor = null,
            string locationId = null
        );

        /// <summary>
        /// Lists booking profiles for team members.
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call.</returns>
        Task<Models.ListTeamMemberBookingProfilesResponse> ListTeamMemberBookingProfilesAsync(
            bool? bookableOnly = false,
            int? limit = null,
            string cursor = null,
            string locationId = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves one or more team members' booking profiles.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkRetrieveTeamMemberBookingProfilesResponse response from the API call.</returns>
        Models.BulkRetrieveTeamMemberBookingProfilesResponse BulkRetrieveTeamMemberBookingProfiles(
            Models.BulkRetrieveTeamMemberBookingProfilesRequest body
        );

        /// <summary>
        /// Retrieves one or more team members' booking profiles.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkRetrieveTeamMemberBookingProfilesResponse response from the API call.</returns>
        Task<Models.BulkRetrieveTeamMemberBookingProfilesResponse> BulkRetrieveTeamMemberBookingProfilesAsync(
            Models.BulkRetrieveTeamMemberBookingProfilesRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves a team member's booking profile.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call.</returns>
        Models.RetrieveTeamMemberBookingProfileResponse RetrieveTeamMemberBookingProfile(
            string teamMemberId
        );

        /// <summary>
        /// Retrieves a team member's booking profile.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call.</returns>
        Task<Models.RetrieveTeamMemberBookingProfileResponse> RetrieveTeamMemberBookingProfileAsync(
            string teamMemberId,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves a booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](entity:Booking) object representing the to-be-retrieved booking..</param>
        /// <returns>Returns the Models.RetrieveBookingResponse response from the API call.</returns>
        Models.RetrieveBookingResponse RetrieveBooking(string bookingId);

        /// <summary>
        /// Retrieves a booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](entity:Booking) object representing the to-be-retrieved booking..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingResponse response from the API call.</returns>
        Task<Models.RetrieveBookingResponse> RetrieveBookingAsync(
            string bookingId,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Updates a booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](entity:Booking) object representing the to-be-updated booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateBookingResponse response from the API call.</returns>
        Models.UpdateBookingResponse UpdateBooking(
            string bookingId,
            Models.UpdateBookingRequest body
        );

        /// <summary>
        /// Updates a booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](entity:Booking) object representing the to-be-updated booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateBookingResponse response from the API call.</returns>
        Task<Models.UpdateBookingResponse> UpdateBookingAsync(
            string bookingId,
            Models.UpdateBookingRequest body,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Cancels an existing booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](entity:Booking) object representing the to-be-cancelled booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CancelBookingResponse response from the API call.</returns>
        Models.CancelBookingResponse CancelBooking(
            string bookingId,
            Models.CancelBookingRequest body
        );

        /// <summary>
        /// Cancels an existing booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](entity:Booking) object representing the to-be-cancelled booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelBookingResponse response from the API call.</returns>
        Task<Models.CancelBookingResponse> CancelBookingAsync(
            string bookingId,
            Models.CancelBookingRequest body,
            CancellationToken cancellationToken = default
        );
    }
}
