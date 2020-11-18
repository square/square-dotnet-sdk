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
    public interface IBookingsApi
    {
        /// <summary>
        /// Creates a booking.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateBookingResponse response from the API call</return>
        Models.CreateBookingResponse CreateBooking(Models.CreateBookingRequest body);

        /// <summary>
        /// Creates a booking.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.CreateBookingResponse response from the API call</return>
        Task<Models.CreateBookingResponse> CreateBookingAsync(Models.CreateBookingRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Searches for availabilities for booking.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchAvailabilityResponse response from the API call</return>
        Models.SearchAvailabilityResponse SearchAvailability(Models.SearchAvailabilityRequest body);

        /// <summary>
        /// Searches for availabilities for booking.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.SearchAvailabilityResponse response from the API call</return>
        Task<Models.SearchAvailabilityResponse> SearchAvailabilityAsync(Models.SearchAvailabilityRequest body, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a seller's booking profile.
        /// </summary>
        /// <return>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call</return>
        Models.RetrieveBusinessBookingProfileResponse RetrieveBusinessBookingProfile();

        /// <summary>
        /// Retrieves a seller's booking profile.
        /// </summary>
        /// <return>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call</return>
        Task<Models.RetrieveBusinessBookingProfileResponse> RetrieveBusinessBookingProfileAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists booking profiles for team members.
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`).</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return.</param>
        /// <param name="cursor">Optional parameter: The cursor for paginating through the results.</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result.</param>
        /// <return>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call</return>
        Models.ListTeamMemberBookingProfilesResponse ListTeamMemberBookingProfiles(
                bool? bookableOnly = false,
                int? limit = null,
                string cursor = null,
                string locationId = null);

        /// <summary>
        /// Lists booking profiles for team members.
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`).</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return.</param>
        /// <param name="cursor">Optional parameter: The cursor for paginating through the results.</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result.</param>
        /// <return>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call</return>
        Task<Models.ListTeamMemberBookingProfilesResponse> ListTeamMemberBookingProfilesAsync(
                bool? bookableOnly = false,
                int? limit = null,
                string cursor = null,
                string locationId = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a team member's booking profile.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve.</param>
        /// <return>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call</return>
        Models.RetrieveTeamMemberBookingProfileResponse RetrieveTeamMemberBookingProfile(string teamMemberId);

        /// <summary>
        /// Retrieves a team member's booking profile.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve.</param>
        /// <return>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call</return>
        Task<Models.RetrieveTeamMemberBookingProfileResponse> RetrieveTeamMemberBookingProfileAsync(string teamMemberId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](#type-booking) object representing the to-be-retrieved booking.</param>
        /// <return>Returns the Models.RetrieveBookingResponse response from the API call</return>
        Models.RetrieveBookingResponse RetrieveBooking(string bookingId);

        /// <summary>
        /// Retrieves a booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](#type-booking) object representing the to-be-retrieved booking.</param>
        /// <return>Returns the Models.RetrieveBookingResponse response from the API call</return>
        Task<Models.RetrieveBookingResponse> RetrieveBookingAsync(string bookingId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates a booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](#type-booking) object representing the to-be-updated booking.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateBookingResponse response from the API call</return>
        Models.UpdateBookingResponse UpdateBooking(string bookingId, Models.UpdateBookingRequest body);

        /// <summary>
        /// Updates a booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](#type-booking) object representing the to-be-updated booking.</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details.</param>
        /// <return>Returns the Models.UpdateBookingResponse response from the API call</return>
        Task<Models.UpdateBookingResponse> UpdateBookingAsync(string bookingId, Models.UpdateBookingRequest body, CancellationToken cancellationToken = default);

    }
}