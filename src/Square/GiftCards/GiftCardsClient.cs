using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;
using Square.GiftCards.Activities;

namespace Square.GiftCards;

public partial class GiftCardsClient
{
    private RawClient _client;

    internal GiftCardsClient(RawClient client)
    {
        _client = client;
        Activities = new ActivitiesClient(_client);
    }

    public ActivitiesClient Activities { get; }

    /// <summary>
    /// Lists all gift cards. You can specify optional filters to retrieve
    /// a subset of the gift cards. Results are sorted by `created_at` in ascending order.
    /// </summary>
    private async Task<ListGiftCardsResponse> ListInternalAsync(
        ListGiftCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Type != null)
        {
            _query["type"] = request.Type;
        }
        if (request.State != null)
        {
            _query["state"] = request.State;
        }
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
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/gift-cards",
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
                return JsonUtils.Deserialize<ListGiftCardsResponse>(responseBody)!;
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
    /// Lists all gift cards. You can specify optional filters to retrieve
    /// a subset of the gift cards. Results are sorted by `created_at` in ascending order.
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.ListAsync(new ListGiftCardsRequest());
    /// </code></example>
    public async Task<Pager<GiftCard>> ListAsync(
        ListGiftCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListGiftCardsRequest,
            RequestOptions?,
            ListGiftCardsResponse,
            string?,
            GiftCard
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
                response => response?.GiftCards?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a digital gift card or registers a physical (plastic) gift card. The resulting gift card
    /// has a `PENDING` state. To activate a gift card so that it can be redeemed for purchases, call
    /// [CreateGiftCardActivity](api-endpoint:GiftCardActivities-CreateGiftCardActivity) and create an `ACTIVATE`
    /// activity with the initial balance. Alternatively, you can use [RefundPayment](api-endpoint:Refunds-RefundPayment)
    /// to refund a payment to the new gift card.
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.CreateAsync(
    ///     new CreateGiftCardRequest
    ///     {
    ///         IdempotencyKey = "NC9Tm69EjbjtConu",
    ///         LocationId = "81FN9BNFZTKS4",
    ///         GiftCard = new GiftCard { Type = GiftCardType.Digital },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateGiftCardResponse> CreateAsync(
        CreateGiftCardRequest request,
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
                    Path = "v2/gift-cards",
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
                return JsonUtils.Deserialize<CreateGiftCardResponse>(responseBody)!;
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
    /// Retrieves a gift card using the gift card account number (GAN).
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.GetFromGanAsync(new GetGiftCardFromGanRequest { Gan = "7783320001001635" });
    /// </code></example>
    public async Task<GetGiftCardFromGanResponse> GetFromGanAsync(
        GetGiftCardFromGanRequest request,
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
                    Path = "v2/gift-cards/from-gan",
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
                return JsonUtils.Deserialize<GetGiftCardFromGanResponse>(responseBody)!;
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
    /// Retrieves a gift card using a secure payment token that represents the gift card.
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.GetFromNonceAsync(
    ///     new GetGiftCardFromNonceRequest { Nonce = "cnon:7783322135245171" }
    /// );
    /// </code></example>
    public async Task<GetGiftCardFromNonceResponse> GetFromNonceAsync(
        GetGiftCardFromNonceRequest request,
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
                    Path = "v2/gift-cards/from-nonce",
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
                return JsonUtils.Deserialize<GetGiftCardFromNonceResponse>(responseBody)!;
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
    /// Links a customer to a gift card, which is also referred to as adding a card on file.
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.LinkCustomerAsync(
    ///     new LinkCustomerToGiftCardRequest
    ///     {
    ///         GiftCardId = "gift_card_id",
    ///         CustomerId = "GKY0FZ3V717AH8Q2D821PNT2ZW",
    ///     }
    /// );
    /// </code></example>
    public async Task<LinkCustomerToGiftCardResponse> LinkCustomerAsync(
        LinkCustomerToGiftCardRequest request,
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
                    Path = string.Format(
                        "v2/gift-cards/{0}/link-customer",
                        ValueConvert.ToPathParameterString(request.GiftCardId)
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
                return JsonUtils.Deserialize<LinkCustomerToGiftCardResponse>(responseBody)!;
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
    /// Unlinks a customer from a gift card, which is also referred to as removing a card on file.
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.UnlinkCustomerAsync(
    ///     new UnlinkCustomerFromGiftCardRequest
    ///     {
    ///         GiftCardId = "gift_card_id",
    ///         CustomerId = "GKY0FZ3V717AH8Q2D821PNT2ZW",
    ///     }
    /// );
    /// </code></example>
    public async Task<UnlinkCustomerFromGiftCardResponse> UnlinkCustomerAsync(
        UnlinkCustomerFromGiftCardRequest request,
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
                    Path = string.Format(
                        "v2/gift-cards/{0}/unlink-customer",
                        ValueConvert.ToPathParameterString(request.GiftCardId)
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
                return JsonUtils.Deserialize<UnlinkCustomerFromGiftCardResponse>(responseBody)!;
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
    /// Retrieves a gift card using the gift card ID.
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.GetAsync(new GetGiftCardsRequest { Id = "id" });
    /// </code></example>
    public async Task<GetGiftCardResponse> GetAsync(
        GetGiftCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/gift-cards/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                return JsonUtils.Deserialize<GetGiftCardResponse>(responseBody)!;
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
