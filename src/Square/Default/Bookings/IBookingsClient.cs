using Square;
using Square.Core;
using Square.Default;
using Square.Default.Bookings.LocationProfiles;
using Square.Default.Bookings.TeamMemberProfiles;

namespace Square.Default.Bookings;

public partial interface IBookingsClient
{
    public Square.Default.Bookings.CustomAttributeDefinitions.CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }
    public Square.Default.Bookings.CustomAttributes.CustomAttributesClient CustomAttributes { get; }
    public LocationProfilesClient LocationProfiles { get; }
    public TeamMemberProfilesClient TeamMemberProfiles { get; }

    /// <summary>
    /// Retrieve a collection of bookings.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    Task<Pager<Booking>> ListAsync(
        ListBookingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a booking.
    ///
    /// The required input must include the following:
    /// - `Booking.location_id`
    /// - `Booking.start_at`
    /// - `Booking.AppointmentSegment.team_member_id`
    /// - `Booking.AppointmentSegment.service_variation_id`
    /// - `Booking.AppointmentSegment.service_variation_version`
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    Task<CreateBookingResponse> CreateAsync(
        CreateBookingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for availabilities for booking.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    Task<SearchAvailabilityResponse> SearchAvailabilityAsync(
        SearchAvailabilityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Bulk-Retrieves a list of bookings by booking IDs.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    Task<BulkRetrieveBookingsResponse> BulkRetrieveBookingsAsync(
        BulkRetrieveBookingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a seller's booking profile.
    /// </summary>
    Task<GetBusinessBookingProfileResponse> GetBusinessProfileAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a seller's location booking profile.
    /// </summary>
    Task<RetrieveLocationBookingProfileResponse> RetrieveLocationBookingProfileAsync(
        RetrieveLocationBookingProfileRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves one or more team members' booking profiles.
    /// </summary>
    Task<BulkRetrieveTeamMemberBookingProfilesResponse> BulkRetrieveTeamMemberBookingProfilesAsync(
        BulkRetrieveTeamMemberBookingProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a booking.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    Task<GetBookingResponse> GetAsync(
        GetBookingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a booking.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    Task<UpdateBookingResponse> UpdateAsync(
        UpdateBookingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancels an existing booking.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    Task<CancelBookingResponse> CancelAsync(
        CancelBookingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
