using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Bookings.CustomAttributeDefinitions;

public partial class CustomAttributeDefinitionsClient
{
    private RawClient _client;

    internal CustomAttributeDefinitionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Get all bookings custom attribute definitions.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    private async Task<ListBookingCustomAttributeDefinitionsResponse> ListInternalAsync(
        ListCustomAttributeDefinitionsRequest request,
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/bookings/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<ListBookingCustomAttributeDefinitionsResponse>(
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
    /// Get all bookings custom attribute definitions.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributeDefinitions.ListAsync(
    ///     new Square.Bookings.CustomAttributeDefinitions.ListCustomAttributeDefinitionsRequest
    ///     {
    ///         Limit = 1,
    ///         Cursor = "cursor",
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<CustomAttributeDefinition>> ListAsync(
        ListCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListCustomAttributeDefinitionsRequest,
            RequestOptions?,
            ListBookingCustomAttributeDefinitionsResponse,
            string?,
            CustomAttributeDefinition
        >
            .CreateInstanceAsync(
                request,
                options,
                ListInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response.Cursor,
                response => response.CustomAttributeDefinitions?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a bookings custom attribute definition.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributeDefinitions.CreateAsync(
    ///     new CreateBookingCustomAttributeDefinitionRequest
    ///     {
    ///         CustomAttributeDefinition = new CustomAttributeDefinition(),
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateBookingCustomAttributeDefinitionResponse> CreateAsync(
        CreateBookingCustomAttributeDefinitionRequest request,
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
                    Path = "v2/bookings/custom-attribute-definitions",
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
                return JsonUtils.Deserialize<CreateBookingCustomAttributeDefinitionResponse>(
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
    /// Retrieves a bookings custom attribute definition.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_READ` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_READ` and `APPOINTMENTS_READ` for the OAuth scope.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributeDefinitions.GetAsync(
    ///     new Square.Bookings.CustomAttributeDefinitions.GetCustomAttributeDefinitionsRequest
    ///     {
    ///         Key = "key",
    ///         Version = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<RetrieveBookingCustomAttributeDefinitionResponse> GetAsync(
        GetCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Version != null)
        {
            _query["version"] = request.Version.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/bookings/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<RetrieveBookingCustomAttributeDefinitionResponse>(
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
    /// Updates a bookings custom attribute definition.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributeDefinitions.UpdateAsync(
    ///     new UpdateBookingCustomAttributeDefinitionRequest
    ///     {
    ///         Key = "key",
    ///         CustomAttributeDefinition = new CustomAttributeDefinition(),
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateBookingCustomAttributeDefinitionResponse> UpdateAsync(
        UpdateBookingCustomAttributeDefinitionRequest request,
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
                        "v2/bookings/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<UpdateBookingCustomAttributeDefinitionResponse>(
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
    /// Deletes a bookings custom attribute definition.
    ///
    /// To call this endpoint with buyer-level permissions, set `APPOINTMENTS_WRITE` for the OAuth scope.
    /// To call this endpoint with seller-level permissions, set `APPOINTMENTS_ALL_WRITE` and `APPOINTMENTS_WRITE` for the OAuth scope.
    ///
    /// For calls to this endpoint with seller-level permissions to succeed, the seller must have subscribed to *Appointments Plus*
    /// or *Appointments Premium*.
    /// </summary>
    /// <example><code>
    /// await client.Bookings.CustomAttributeDefinitions.DeleteAsync(
    ///     new Square.Bookings.CustomAttributeDefinitions.DeleteCustomAttributeDefinitionsRequest
    ///     {
    ///         Key = "key",
    ///     }
    /// );
    /// </code></example>
    public async Task<DeleteBookingCustomAttributeDefinitionResponse> DeleteAsync(
        DeleteCustomAttributeDefinitionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "v2/bookings/custom-attribute-definitions/{0}",
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
                return JsonUtils.Deserialize<DeleteBookingCustomAttributeDefinitionResponse>(
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
}
