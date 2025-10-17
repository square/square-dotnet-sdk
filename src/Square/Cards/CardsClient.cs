using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Cards;

public partial class CardsClient
{
    private RawClient _client;

    internal CardsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves a list of cards owned by the account making the request.
    /// A max of 25 cards will be returned.
    /// </summary>
    private async Task<ListCardsResponse> ListInternalAsync(
        ListCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.CustomerId != null)
        {
            _query["customer_id"] = request.CustomerId;
        }
        if (request.IncludeDisabled != null)
        {
            _query["include_disabled"] = JsonUtils.Serialize(request.IncludeDisabled.Value);
        }
        if (request.ReferenceId != null)
        {
            _query["reference_id"] = request.ReferenceId;
        }
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/cards",
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
                return JsonUtils.Deserialize<ListCardsResponse>(responseBody)!;
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
    /// Retrieves a list of cards owned by the account making the request.
    /// A max of 25 cards will be returned.
    /// </summary>
    /// <example><code>
    /// await client.Cards.ListAsync(
    ///     new ListCardsRequest
    ///     {
    ///         Cursor = "cursor",
    ///         CustomerId = "customer_id",
    ///         IncludeDisabled = true,
    ///         ReferenceId = "reference_id",
    ///         SortOrder = SortOrder.Desc,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Card>> ListAsync(
        ListCardsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListCardsRequest,
            RequestOptions?,
            ListCardsResponse,
            string?,
            Card
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
                response => response?.Cards?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Adds a card on file to an existing merchant.
    /// </summary>
    /// <example><code>
    /// await client.Cards.CreateAsync(
    ///     new CreateCardRequest
    ///     {
    ///         IdempotencyKey = "4935a656-a929-4792-b97c-8848be85c27c",
    ///         SourceId = "cnon:uIbfJXhXETSP197M3GB",
    ///         Card = new Card
    ///         {
    ///             CardholderName = "Amelia Earhart",
    ///             BillingAddress = new Address
    ///             {
    ///                 AddressLine1 = "500 Electric Ave",
    ///                 AddressLine2 = "Suite 600",
    ///                 Locality = "New York",
    ///                 AdministrativeDistrictLevel1 = "NY",
    ///                 PostalCode = "10003",
    ///                 Country = Country.Us,
    ///             },
    ///             CustomerId = "VDKXEEKPJN48QDG3BGGFAK05P8",
    ///             ReferenceId = "user-id-1",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateCardResponse> CreateAsync(
        CreateCardRequest request,
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
                    Path = "v2/cards",
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
                return JsonUtils.Deserialize<CreateCardResponse>(responseBody)!;
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
    /// Retrieves details for a specific Card.
    /// </summary>
    /// <example><code>
    /// await client.Cards.GetAsync(new GetCardsRequest { CardId = "card_id" });
    /// </code></example>
    public async Task<GetCardResponse> GetAsync(
        GetCardsRequest request,
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
                        "v2/cards/{0}",
                        ValueConvert.ToPathParameterString(request.CardId)
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
                return JsonUtils.Deserialize<GetCardResponse>(responseBody)!;
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
    /// Disables the card, preventing any further updates or charges.
    /// Disabling an already disabled card is allowed but has no effect.
    /// </summary>
    /// <example><code>
    /// await client.Cards.DisableAsync(new DisableCardsRequest { CardId = "card_id" });
    /// </code></example>
    public async Task<DisableCardResponse> DisableAsync(
        DisableCardsRequest request,
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
                        "v2/cards/{0}/disable",
                        ValueConvert.ToPathParameterString(request.CardId)
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
                return JsonUtils.Deserialize<DisableCardResponse>(responseBody)!;
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
