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
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Http.Request;
    using Square.Http.Response;
    using Square.Utilities;

    /// <summary>
    /// BookingsApi.
    /// </summary>
    internal class BookingsApi : BaseApi, IBookingsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookingsApi"/> class.
        /// </summary>
        /// <param name="config"> config instance. </param>
        /// <param name="httpClient"> httpClient. </param>
        /// <param name="authManagers"> authManager. </param>
        /// <param name="httpCallBack"> httpCallBack. </param>
        internal BookingsApi(IConfiguration config, IHttpClient httpClient, IDictionary<string, IAuthManager> authManagers, HttpCallBack httpCallBack = null)
            : base(config, httpClient, authManagers, httpCallBack)
        {
        }

        /// <summary>
        /// Retrieve a collection of bookings.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results per page to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="teamMemberId">Optional parameter: The team member for whom to retrieve bookings. If this is not set, bookings of all members are retrieved..</param>
        /// <param name="locationId">Optional parameter: The location for which to retrieve bookings. If this is not set, all locations' bookings are retrieved..</param>
        /// <param name="startAtMin">Optional parameter: The RFC 3339 timestamp specifying the earliest of the start time. If this is not set, the current time is used..</param>
        /// <param name="startAtMax">Optional parameter: The RFC 3339 timestamp specifying the latest of the start time. If this is not set, the time of 31 days after `start_at_min` is used..</param>
        /// <returns>Returns the Models.ListBookingsResponse response from the API call.</returns>
        public Models.ListBookingsResponse ListBookings(
                int? limit = null,
                string cursor = null,
                string teamMemberId = null,
                string locationId = null,
                string startAtMin = null,
                string startAtMax = null)
        {
            Task<Models.ListBookingsResponse> t = this.ListBookingsAsync(limit, cursor, teamMemberId, locationId, startAtMin, startAtMax);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieve a collection of bookings.
        /// </summary>
        /// <param name="limit">Optional parameter: The maximum number of results per page to return in a paged response..</param>
        /// <param name="cursor">Optional parameter: The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results..</param>
        /// <param name="teamMemberId">Optional parameter: The team member for whom to retrieve bookings. If this is not set, bookings of all members are retrieved..</param>
        /// <param name="locationId">Optional parameter: The location for which to retrieve bookings. If this is not set, all locations' bookings are retrieved..</param>
        /// <param name="startAtMin">Optional parameter: The RFC 3339 timestamp specifying the earliest of the start time. If this is not set, the current time is used..</param>
        /// <param name="startAtMax">Optional parameter: The RFC 3339 timestamp specifying the latest of the start time. If this is not set, the time of 31 days after `start_at_min` is used..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListBookingsResponse response from the API call.</returns>
        public async Task<Models.ListBookingsResponse> ListBookingsAsync(
                int? limit = null,
                string cursor = null,
                string teamMemberId = null,
                string locationId = null,
                string startAtMin = null,
                string startAtMax = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "limit", limit },
                { "cursor", cursor },
                { "team_member_id", teamMemberId },
                { "location_id", locationId },
                { "start_at_min", startAtMin },
                { "start_at_max", startAtMax },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListBookingsResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Creates a booking.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CreateBookingResponse response from the API call.</returns>
        public Models.CreateBookingResponse CreateBooking(
                Models.CreateBookingRequest body)
        {
            Task<Models.CreateBookingResponse> t = this.CreateBookingAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Creates a booking.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CreateBookingResponse response from the API call.</returns>
        public async Task<Models.CreateBookingResponse> CreateBookingAsync(
                Models.CreateBookingRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CreateBookingResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Searches for availabilities for booking.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.SearchAvailabilityResponse response from the API call.</returns>
        public Models.SearchAvailabilityResponse SearchAvailability(
                Models.SearchAvailabilityRequest body)
        {
            Task<Models.SearchAvailabilityResponse> t = this.SearchAvailabilityAsync(body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Searches for availabilities for booking.
        /// </summary>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchAvailabilityResponse response from the API call.</returns>
        public async Task<Models.SearchAvailabilityResponse> SearchAvailabilityAsync(
                Models.SearchAvailabilityRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/availability/search");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.SearchAvailabilityResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a seller's booking profile.
        /// </summary>
        /// <returns>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call.</returns>
        public Models.RetrieveBusinessBookingProfileResponse RetrieveBusinessBookingProfile()
        {
            Task<Models.RetrieveBusinessBookingProfileResponse> t = this.RetrieveBusinessBookingProfileAsync();
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a seller's booking profile.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBusinessBookingProfileResponse response from the API call.</returns>
        public async Task<Models.RetrieveBusinessBookingProfileResponse> RetrieveBusinessBookingProfileAsync(CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/business-booking-profile");

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveBusinessBookingProfileResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Lists booking profiles for team members.
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return..</param>
        /// <param name="cursor">Optional parameter: The cursor for paginating through the results..</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result..</param>
        /// <returns>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call.</returns>
        public Models.ListTeamMemberBookingProfilesResponse ListTeamMemberBookingProfiles(
                bool? bookableOnly = false,
                int? limit = null,
                string cursor = null,
                string locationId = null)
        {
            Task<Models.ListTeamMemberBookingProfilesResponse> t = this.ListTeamMemberBookingProfilesAsync(bookableOnly, limit, cursor, locationId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Lists booking profiles for team members.
        /// </summary>
        /// <param name="bookableOnly">Optional parameter: Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`)..</param>
        /// <param name="limit">Optional parameter: The maximum number of results to return..</param>
        /// <param name="cursor">Optional parameter: The cursor for paginating through the results..</param>
        /// <param name="locationId">Optional parameter: Indicates whether to include only team members enabled at the given location in the returned result..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListTeamMemberBookingProfilesResponse response from the API call.</returns>
        public async Task<Models.ListTeamMemberBookingProfilesResponse> ListTeamMemberBookingProfilesAsync(
                bool? bookableOnly = false,
                int? limit = null,
                string cursor = null,
                string locationId = null,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/team-member-booking-profiles");

            // prepare specfied query parameters.
            var queryParams = new Dictionary<string, object>()
            {
                { "bookable_only", (bookableOnly != null) ? bookableOnly : false },
                { "limit", limit },
                { "cursor", cursor },
                { "location_id", locationId },
            };

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers, queryParameters: queryParams);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.ListTeamMemberBookingProfilesResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a team member's booking profile.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <returns>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call.</returns>
        public Models.RetrieveTeamMemberBookingProfileResponse RetrieveTeamMemberBookingProfile(
                string teamMemberId)
        {
            Task<Models.RetrieveTeamMemberBookingProfileResponse> t = this.RetrieveTeamMemberBookingProfileAsync(teamMemberId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a team member's booking profile.
        /// </summary>
        /// <param name="teamMemberId">Required parameter: The ID of the team member to retrieve..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveTeamMemberBookingProfileResponse response from the API call.</returns>
        public async Task<Models.RetrieveTeamMemberBookingProfileResponse> RetrieveTeamMemberBookingProfileAsync(
                string teamMemberId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/team-member-booking-profiles/{team_member_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "team_member_id", teamMemberId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveTeamMemberBookingProfileResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Retrieves a booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-retrieved booking..</param>
        /// <returns>Returns the Models.RetrieveBookingResponse response from the API call.</returns>
        public Models.RetrieveBookingResponse RetrieveBooking(
                string bookingId)
        {
            Task<Models.RetrieveBookingResponse> t = this.RetrieveBookingAsync(bookingId);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Retrieves a booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-retrieved booking..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveBookingResponse response from the API call.</returns>
        public async Task<Models.RetrieveBookingResponse> RetrieveBookingAsync(
                string bookingId,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/{booking_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "booking_id", bookingId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().Get(queryBuilder.ToString(), headers);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.RetrieveBookingResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Updates a booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-updated booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.UpdateBookingResponse response from the API call.</returns>
        public Models.UpdateBookingResponse UpdateBooking(
                string bookingId,
                Models.UpdateBookingRequest body)
        {
            Task<Models.UpdateBookingResponse> t = this.UpdateBookingAsync(bookingId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Updates a booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-updated booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.UpdateBookingResponse response from the API call.</returns>
        public async Task<Models.UpdateBookingResponse> UpdateBookingAsync(
                string bookingId,
                Models.UpdateBookingRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/{booking_id}");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "booking_id", bookingId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PutBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.UpdateBookingResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }

        /// <summary>
        /// Cancels an existing booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-cancelled booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <returns>Returns the Models.CancelBookingResponse response from the API call.</returns>
        public Models.CancelBookingResponse CancelBooking(
                string bookingId,
                Models.CancelBookingRequest body)
        {
            Task<Models.CancelBookingResponse> t = this.CancelBookingAsync(bookingId, body);
            ApiHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Cancels an existing booking.
        /// </summary>
        /// <param name="bookingId">Required parameter: The ID of the [Booking]($m/Booking) object representing the to-be-cancelled booking..</param>
        /// <param name="body">Required parameter: An object containing the fields to POST for the request.  See the corresponding object definition for field details..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.CancelBookingResponse response from the API call.</returns>
        public async Task<Models.CancelBookingResponse> CancelBookingAsync(
                string bookingId,
                Models.CancelBookingRequest body,
                CancellationToken cancellationToken = default)
        {
            // the base uri for api requests.
            string baseUri = this.Config.GetBaseUri();

            // prepare query string for API call.
            StringBuilder queryBuilder = new StringBuilder(baseUri);
            queryBuilder.Append("/v2/bookings/{booking_id}/cancel");

            // process optional template parameters.
            ApiHelper.AppendUrlWithTemplateParameters(queryBuilder, new Dictionary<string, object>()
            {
                { "booking_id", bookingId },
            });

            // append request with appropriate headers and parameters
            var headers = new Dictionary<string, string>()
            {
                { "user-agent", this.UserAgent },
                { "accept", "application/json" },
                { "Content-Type", "application/json" },
                { "Square-Version", this.Config.SquareVersion },
            };

            // append body params.
            var bodyText = ApiHelper.JsonSerialize(body);

            // prepare the API call request to fetch the response.
            HttpRequest httpRequest = this.GetClientInstance().PostBody(queryBuilder.ToString(), headers, bodyText);

            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnBeforeHttpRequestEventHandler(this.GetClientInstance(), httpRequest);
            }

            httpRequest = await this.AuthManagers["global"].ApplyAsync(httpRequest).ConfigureAwait(false);

            // invoke request and get response.
            HttpStringResponse response = await this.GetClientInstance().ExecuteAsStringAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            HttpContext context = new HttpContext(httpRequest, response);
            if (this.HttpCallBack != null)
            {
                this.HttpCallBack.OnAfterHttpResponseEventHandler(this.GetClientInstance(), response);
            }

            // handle errors defined at the API level.
            this.ValidateResponse(response, context);

            var responseModel = ApiHelper.JsonDeserialize<Models.CancelBookingResponse>(response.Body);
            responseModel.Context = context;
            return responseModel;
        }
    }
}