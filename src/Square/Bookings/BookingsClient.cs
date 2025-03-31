using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Bookings.CustomAttributeDefinitions;
using Square.Bookings.CustomAttributes;
using Square.Bookings.LocationProfiles;
using Square.Bookings.TeamMemberProfiles;
using Square.Core;

namespace Square.Bookings;

public partial class BookingsClient
{
    private RawClient _client;

    internal BookingsClient(RawClient client)
    {
        _client = client;
        CustomAttributeDefinitions = new CustomAttributeDefinitionsClient(_client);
        CustomAttributes = new CustomAttributesClient(_client);
        LocationProfiles = new LocationProfilesClient(_client);
        TeamMemberProfiles = new TeamMemberProfilesClient(_client);
    }

    public CustomAttributeDefinitionsClient CustomAttributeDefinitions { get; }

    public CustomAttributesClient CustomAttributes { get; }

    public LocationProfilesClient LocationProfiles { get; }

    public TeamMemberProfilesClient TeamMemberProfiles { get; }

    /// <summary>
    /// Retrieve a collection of bookings.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    private async Task<ListBookingsResponse> ListInternalAsync(
        ListBookingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.CustomerId != null)
        {
            _query["customer_id"] = request.CustomerId;
        }
        if (request.TeamMemberId != null)
        {
            _query["team_member_id"] = request.TeamMemberId;
        }
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
        }
        if (request.StartAtMin != null)
        {
            _query["start_at_min"] = request.StartAtMin;
        }
        if (request.StartAtMax != null)
        {
            _query["start_at_max"] = request.StartAtMax;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/bookings",
                    Query = _query,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<ListBookingsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieve a collection of bookings.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.ListAsync(new ListBookingsRequest());
    /// </code></example>
    public async Task<Pager<Booking>> ListAsync(
        ListBookingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListBookingsRequest,
            RequestOptions?,
            ListBookingsResponse,
            string?,
            Booking
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.Bookings?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

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
    /// <example><code>
    /// await client.Bookings.CreateAsync(new CreateBookingRequest { Booking = new Booking() });
    /// </code></example>
    public async Task<CreateBookingResponse> CreateAsync(
        CreateBookingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/bookings",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CreateBookingResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Searches for availabilities for booking.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.SearchAvailabilityAsync(
    ///     new SearchAvailabilityRequest
    ///     {
    ///         Query = new SearchAvailabilityQuery
    ///         {
    ///             Filter = new SearchAvailabilityFilter { StartAtRange = new TimeRange() },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchAvailabilityResponse> SearchAvailabilityAsync(
        SearchAvailabilityRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/bookings/availability/search",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<SearchAvailabilityResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Bulk-Retrieves a list of bookings by booking IDs.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.BulkRetrieveBookingsAsync(
    ///     new BulkRetrieveBookingsRequest { BookingIds = new List&lt;string&gt;() { "booking_ids" } }
    /// );
    /// </code></example>
    public async Task<BulkRetrieveBookingsResponse> BulkRetrieveBookingsAsync(
        BulkRetrieveBookingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/bookings/bulk-retrieve",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<BulkRetrieveBookingsResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves a seller's booking profile.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.GetBusinessProfileAsync();
    /// </code></example>
    public async Task<GetBusinessBookingProfileResponse> GetBusinessProfileAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/bookings/business-booking-profile",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<GetBusinessBookingProfileResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves a seller's location booking profile.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.RetrieveLocationBookingProfileAsync(
    ///     new RetrieveLocationBookingProfileRequest { LocationId = "location_id" }
    /// );
    /// </code></example>
    public async Task<RetrieveLocationBookingProfileResponse> RetrieveLocationBookingProfileAsync(
        RetrieveLocationBookingProfileRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/bookings/location-booking-profiles/{0}",
                        ValueConvert.ToPathParameterString(request.LocationId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<RetrieveLocationBookingProfileResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves one or more team members' booking profiles.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.BulkRetrieveTeamMemberBookingProfilesAsync(
    ///     new BulkRetrieveTeamMemberBookingProfilesRequest
    ///     {
    ///         TeamMemberIds = new List&lt;string&gt;() { "team_member_ids" },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkRetrieveTeamMemberBookingProfilesResponse> BulkRetrieveTeamMemberBookingProfilesAsync(
        BulkRetrieveTeamMemberBookingProfilesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/bookings/team-member-booking-profiles/bulk-retrieve",
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<BulkRetrieveTeamMemberBookingProfilesResponse>(
                    responseBody
                )!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Retrieves a booking.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.GetAsync(new GetBookingsRequest { BookingId = "booking_id" });
    /// </code></example>
    public async Task<GetBookingResponse> GetAsync(
        GetBookingsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/bookings/{0}",
                        ValueConvert.ToPathParameterString(request.BookingId)
                    ),
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<GetBookingResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Updates a booking.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.UpdateAsync(
    ///     new UpdateBookingRequest { BookingId = "booking_id", Booking = new Booking() }
    /// );
    /// </code></example>
    public async Task<UpdateBookingResponse> UpdateAsync(
        UpdateBookingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/bookings/{0}",
                        ValueConvert.ToPathParameterString(request.BookingId)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<UpdateBookingResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Cancels an existing booking.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CancelAsync(new CancelBookingRequest { BookingId = "booking_id" });
    /// </code></example>
    public async Task<CancelBookingResponse> CancelAsync(
        CancelBookingRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "v2/bookings/{0}/cancel",
                        ValueConvert.ToPathParameterString(request.BookingId)
                    ),
                    Body = request,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                return JsonUtils.Deserialize<CancelBookingResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new SquareException("Failed to deserialize response", e);
            }
        }

        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new SquareApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }
}
