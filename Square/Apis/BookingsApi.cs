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
    /// BookingsApi.
    /// </summary>
    internal class BookingsApi : BaseApi, IBookingsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingsApi"/> class.
        /// </summary>
        internal BookingsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

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
        public Models.ListBookingsResponse ListBookings(
                int? limit = null,
                string cursor = null,
                string customerId = null,
                string teamMemberId = null,
                string locationId = null,
                string startAtMin = null,
                string startAtMax = null)
            => CoreHelper.RunTask(ListBookingsAsync(limit, cursor, customerId, teamMemberId, locationId, startAtMin, startAtMax));

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
        public async Task<Models.ListBookingsResponse> ListBookingsAsync(
                int? limit = null,
                string cursor = null,
                string customerId = null,
                string teamMemberId = null,
                string locationId = null,
                string startAtMin = null,
                string startAtMax = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListBookingsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("customer_id", customerId))
                      .Query(_query => _query.Setup("team_member_id", teamMemberId))
                      .Query(_query => _query.Setup("location_id", locationId))
                      .Query(_query => _query.Setup("start_at_min", startAtMin))
                      .Query(_query => _query.Setup("start_at_max", startAtMax))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a booking.
        /// The required input must include the following:.
        /// - `Booking.location_id`.
        /// - `Booking.start_at`.
        /// - `Booking.team_member_id`.
        /// - `Booking.AppointmentSegment.service_variation_id`.
        /// - `Booking.AppointmentSegment.service_variation_version`.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
        /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*.
        /// or *Appointments Premium*.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBookingResponse response from the API call.</returns>
        public Models.CreateBookingResponse CreateBooking(
                Models.CreateBookingRequest body)
            => CoreHelper.RunTask(CreateBookingAsync(body));

        /// <summary>
        /// Creates a booking.
        /// The required input must include the following:.
        /// - `Booking.location_id`.
        /// - `Booking.start_at`.
        /// - `Booking.team_member_id`.
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
        public async Task<Models.CreateBookingResponse> CreateBookingAsync(
                Models.CreateBookingRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CreateBookingResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/bookings")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Searches for availabilities for booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchAvailabilityResponse response from the API call.</returns>
        public Models.SearchAvailabilityResponse SearchAvailability(
                Models.SearchAvailabilityRequest body)
            => CoreHelper.RunTask(SearchAvailabilityAsync(body));

        /// <summary>
        /// Searches for availabilities for booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchAvailabilityResponse response from the API call.</returns>
        public async Task<Models.SearchAvailabilityResponse> SearchAvailabilityAsync(
                Models.SearchAvailabilityRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchAvailabilityResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/bookings/availability/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Bulk-Retrieves a list of bookings by booking IDs.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkRetrieveBookingsResponse response from the API call.</returns>
        public Models.BulkRetrieveBookingsResponse BulkRetrieveBookings(
                Models.BulkRetrieveBookingsRequest body)
            => CoreHelper.RunTask(BulkRetrieveBookingsAsync(body));

        /// <summary>
        /// Bulk-Retrieves a list of bookings by booking IDs.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkRetrieveBookingsResponse response from the API call.</returns>
        public async Task<Models.BulkRetrieveBookingsResponse> BulkRetrieveBookingsAsync(
                Models.BulkRetrieveBookingsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkRetrieveBookingsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/bookings/bulk-retrieve")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a seller's booking profile.
        /// </summary>
        /// <returns>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call.</returns>
        public Models.RetrieveBusinessBookingProfileResponse RetrieveBusinessBookingProfile()
            => CoreHelper.RunTask(RetrieveBusinessBookingProfileAsync());

        /// <summary>
        /// Retrieves a seller's booking profile.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call.</returns>
        public async Task<Models.RetrieveBusinessBookingProfileResponse> RetrieveBusinessBookingProfileAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveBusinessBookingProfileResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/business-booking-profile")
                  .WithAuth("global"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Lists location booking profiles of a seller.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <returns>Returns the Models.ListLocationBookingProfilesResponse response from the API call.</returns>
        public Models.ListLocationBookingProfilesResponse ListLocationBookingProfiles(
                int? limit = null,
                string cursor = null)
            => CoreHelper.RunTask(ListLocationBookingProfilesAsync(limit, cursor));

        /// <summary>
        /// Lists location booking profiles of a seller.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListLocationBookingProfilesResponse response from the API call.</returns>
        public async Task<Models.ListLocationBookingProfilesResponse> ListLocationBookingProfilesAsync(
                int? limit = null,
                string cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListLocationBookingProfilesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/location-booking-profiles")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a seller's location booking profile.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve the booking profile..</param>
        /// <returns>Returns the Models.RetrieveLocationBookingProfileResponse response from the API call.</returns>
        public Models.RetrieveLocationBookingProfileResponse RetrieveLocationBookingProfile(
                string locationId)
            => CoreHelper.RunTask(RetrieveLocationBookingProfileAsync(locationId));

        /// <summary>
        /// Retrieves a seller's location booking profile.
        /// </summary>
        /// <param name="locationId">Required parameter: The ID of the location to retrieve the booking profile..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveLocationBookingProfileResponse response from the API call.</returns>
        public async Task<Models.RetrieveLocationBookingProfileResponse> RetrieveLocationBookingProfileAsync(
                string locationId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveLocationBookingProfileResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/location-booking-profiles/{location_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("location_id", locationId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Lists booking profiles for team members.
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result..</param>
        /// <returns>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call.</returns>
        public Models.ListTeamMemberBookingProfilesResponse ListTeamMemberBookingProfiles(
                bool? bookableOnly = false,
                int? limit = null,
                string cursor = null,
                string locationId = null)
            => CoreHelper.RunTask(ListTeamMemberBookingProfilesAsync(bookableOnly, limit, cursor, locationId));

        /// <summary>
        /// Lists booking profiles for team members.
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call.</returns>
        public async Task<Models.ListTeamMemberBookingProfilesResponse> ListTeamMemberBookingProfilesAsync(
                bool? bookableOnly = false,
                int? limit = null,
                string cursor = null,
                string locationId = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListTeamMemberBookingProfilesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/team-member-booking-profiles")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("bookable_only", (bookableOnly != null) ? bookableOnly : false))
                      .Query(_query => _query.Setup("limit", limit))
                      .Query(_query => _query.Setup("cursor", cursor))
                      .Query(_query => _query.Setup("location_id", locationId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves one or more team members' booking profiles.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.BulkRetrieveTeamMemberBookingProfilesResponse response from the API call.</returns>
        public Models.BulkRetrieveTeamMemberBookingProfilesResponse BulkRetrieveTeamMemberBookingProfiles(
                Models.BulkRetrieveTeamMemberBookingProfilesRequest body)
            => CoreHelper.RunTask(BulkRetrieveTeamMemberBookingProfilesAsync(body));

        /// <summary>
        /// Retrieves one or more team members' booking profiles.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BulkRetrieveTeamMemberBookingProfilesResponse response from the API call.</returns>
        public async Task<Models.BulkRetrieveTeamMemberBookingProfilesResponse> BulkRetrieveTeamMemberBookingProfilesAsync(
                Models.BulkRetrieveTeamMemberBookingProfilesRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BulkRetrieveTeamMemberBookingProfilesResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/bookings/team-member-booking-profiles/bulk-retrieve")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a team member's booking profile.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call.</returns>
        public Models.RetrieveTeamMemberBookingProfileResponse RetrieveTeamMemberBookingProfile(
                string teamMemberId)
            => CoreHelper.RunTask(RetrieveTeamMemberBookingProfileAsync(teamMemberId));

        /// <summary>
        /// Retrieves a team member's booking profile.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call.</returns>
        public async Task<Models.RetrieveTeamMemberBookingProfileResponse> RetrieveTeamMemberBookingProfileAsync(
                string teamMemberId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveTeamMemberBookingProfileResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/team-member-booking-profiles/{team_member_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("team_member_id", teamMemberId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieves a booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](entity:Booking) object representing the to-be-retrieved booking..</param>
        /// <returns>Returns the Models.RetrieveBookingResponse response from the API call.</returns>
        public Models.RetrieveBookingResponse RetrieveBooking(
                string bookingId)
            => CoreHelper.RunTask(RetrieveBookingAsync(bookingId));

        /// <summary>
        /// Retrieves a booking.
        /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
        /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking](entity:Booking) object representing the to-be-retrieved booking..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingResponse response from the API call.</returns>
        public async Task<Models.RetrieveBookingResponse> RetrieveBookingAsync(
                string bookingId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveBookingResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/bookings/{booking_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("booking_id", bookingId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
        public Models.UpdateBookingResponse UpdateBooking(
                string bookingId,
                Models.UpdateBookingRequest body)
            => CoreHelper.RunTask(UpdateBookingAsync(bookingId, body));

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
        public async Task<Models.UpdateBookingResponse> UpdateBookingAsync(
                string bookingId,
                Models.UpdateBookingRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.UpdateBookingResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/v2/bookings/{booking_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("booking_id", bookingId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

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
        public Models.CancelBookingResponse CancelBooking(
                string bookingId,
                Models.CancelBookingRequest body)
            => CoreHelper.RunTask(CancelBookingAsync(bookingId, body));

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
        public async Task<Models.CancelBookingResponse> CancelBookingAsync(
                string bookingId,
                Models.CancelBookingRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.CancelBookingResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/v2/bookings/{booking_id}/cancel")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Template(_template => _template.Setup("booking_id", bookingId))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context)))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}