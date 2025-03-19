using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Bookings.CustomAttributes;

public partial class CustomAttributesClient
{
    private RawClient _client;

    internal CustomAttributesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists a booking's custom attributes.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    private async Task<ListBookingCustomAttributesResponse> ListInternalAsync(
        ListCustomAttributesRequest request,
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
        if (request.WithDefinitions != null)
        {
            _query["with_definitions"] = JsonUtils.Serialize(request.WithDefinitions.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/bookings/{0}/custom-attributes",
                        ValueConvert.ToPathParameterString(request.BookingId)
                    ),
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
                return JsonUtils.Deserialize<ListBookingCustomAttributesResponse>(responseBody)!;
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
    /// Bulk deletes bookings custom attributes.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributes.BatchDeleteAsync(
    ///     new BulkDeleteBookingCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;string, BookingCustomAttributeDeleteRequest&gt;()
    ///         {
    ///             {
    ///                 "key",
    ///                 new BookingCustomAttributeDeleteRequest { BookingId = "booking_id", Key = "key" }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkDeleteBookingCustomAttributesResponse> BatchDeleteAsync(
        BulkDeleteBookingCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/bookings/custom-attributes/bulk-delete",
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
                return JsonUtils.Deserialize<BulkDeleteBookingCustomAttributesResponse>(
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
    /// Bulk upserts bookings custom attributes.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributes.BatchUpsertAsync(
    ///     new BulkUpsertBookingCustomAttributesRequest
    ///     {
    ///         Values = new Dictionary&lt;string, BookingCustomAttributeUpsertRequest&gt;()
    ///         {
    ///             {
    ///                 "key",
    ///                 new BookingCustomAttributeUpsertRequest
    ///                 {
    ///                     BookingId = "booking_id",
    ///                     CustomAttribute = new CustomAttribute(),
    ///                 }
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkUpsertBookingCustomAttributesResponse> BatchUpsertAsync(
        BulkUpsertBookingCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "v2/bookings/custom-attributes/bulk-upsert",
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
                return JsonUtils.Deserialize<BulkUpsertBookingCustomAttributesResponse>(
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
    /// Lists a booking's custom attributes.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributes.ListAsync(
    ///     new ListCustomAttributesRequest { BookingId = "booking_id" }
    /// );
    /// </code></example>
    public async Task<Pager<CustomAttribute>> ListAsync(
        ListCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListCustomAttributesRequest,
            RequestOptions?,
            ListBookingCustomAttributesResponse,
            string?,
            CustomAttribute
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
                response => response?.CustomAttributes?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Retrieves a bookings custom attribute.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributes.GetAsync(
    ///     new GetCustomAttributesRequest { BookingId = "booking_id", Key = "key" }
    /// );
    /// </code></example>
    public async Task<RetrieveBookingCustomAttributeResponse> GetAsync(
        GetCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.WithDefinition != null)
        {
            _query["with_definition"] = JsonUtils.Serialize(request.WithDefinition.Value);
        }
        if (request.Version != null)
        {
            _query["version"] = request.Version.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/bookings/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.BookingId),
                        ValueConvert.ToPathParameterString(request.Key)
                    ),
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
                return JsonUtils.Deserialize<RetrieveBookingCustomAttributeResponse>(responseBody)!;
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
    /// Upserts a bookings custom attribute.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributes.UpsertAsync(
    ///     new UpsertBookingCustomAttributeRequest
    ///     {
    ///         BookingId = "booking_id",
    ///         Key = "key",
    ///         CustomAttribute = new CustomAttribute(),
    ///     }
    /// );
    /// </code></example>
    public async Task<UpsertBookingCustomAttributeResponse> UpsertAsync(
        UpsertBookingCustomAttributeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "v2/bookings/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.BookingId),
                        ValueConvert.ToPathParameterString(request.Key)
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
                return JsonUtils.Deserialize<UpsertBookingCustomAttributeResponse>(responseBody)!;
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
    /// Deletes a bookings custom attribute.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributes.DeleteAsync(
    ///     new DeleteCustomAttributesRequest { BookingId = "booking_id", Key = "key" }
    /// );
    /// </code></example>
    public async Task<DeleteBookingCustomAttributeResponse> DeleteAsync(
        DeleteCustomAttributesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/bookings/{0}/custom-attributes/{1}",
                        ValueConvert.ToPathParameterString(request.BookingId),
                        ValueConvert.ToPathParameterString(request.Key)
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
                return JsonUtils.Deserialize<DeleteBookingCustomAttributeResponse>(responseBody)!;
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
