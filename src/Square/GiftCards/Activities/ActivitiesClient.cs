using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.GiftCards.Activities;

public partial class ActivitiesClient
{
    private RawClient _client;

    internal ActivitiesClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists gift card activities. By default, you get gift card activities for all
    /// gift cards in the seller's account. You can optionally specify query parameters to
    /// filter the list. For example, you can get a list of gift card activities for a gift card,
    /// for all gift cards in a specific region, or for activities within a time window.
    /// </summary>
    private async Task<ListGiftCardActivitiesResponse> ListInternalAsync(
        ListActivitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.GiftCardId != null)
        {
            _query["gift_card_id"] = request.GiftCardId;
        }
        if (request.Type != null)
        {
            _query["type"] = request.Type;
        }
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
        }
        if (request.BeginTime != null)
        {
            _query["begin_time"] = request.BeginTime;
        }
        if (request.EndTime != null)
        {
            _query["end_time"] = request.EndTime;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder;
        }
        var response = await _client
            .SendRequestAsync(
                new RawClient.JsonApiRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/gift-cards/activities",
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
                return JsonUtils.Deserialize<ListGiftCardActivitiesResponse>(responseBody)!;
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
    /// Lists gift card activities. By default, you get gift card activities for all
    /// gift cards in the seller's account. You can optionally specify query parameters to
    /// filter the list. For example, you can get a list of gift card activities for a gift card,
    /// for all gift cards in a specific region, or for activities within a time window.
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.Activities.ListAsync(new ListActivitiesRequest());
    /// </code></example>
    public async Task<Pager<GiftCardActivity>> ListAsync(
        ListActivitiesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListActivitiesRequest,
            RequestOptions?,
            ListGiftCardActivitiesResponse,
            string?,
            GiftCardActivity
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
                response => response?.GiftCardActivities?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a gift card activity to manage the balance or state of a [gift card](entity:GiftCard).
    /// For example, create an `ACTIVATE` activity to activate a gift card with an initial balance before first use.
    /// </summary>
    /// <example><code>
    /// await client.GiftCards.Activities.CreateAsync(
    ///     new CreateGiftCardActivityRequest
    ///     {
    ///         IdempotencyKey = "U16kfr-kA70er-q4Rsym-7U7NnY",
    ///         GiftCardActivity = new GiftCardActivity
    ///         {
    ///             Type = GiftCardActivityType.Activate,
    ///             LocationId = "81FN9BNFZTKS4",
    ///             GiftCardId = "gftc:6d55a72470d940c6ba09c0ab8ad08d20",
    ///             ActivateActivityDetails = new GiftCardActivityActivate
    ///             {
    ///                 OrderId = "jJNGHm4gLI6XkFbwtiSLqK72KkAZY",
    ///                 LineItemUid = "eIWl7X0nMuO9Ewbh0ChIx",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateGiftCardActivityResponse> CreateAsync(
        CreateGiftCardActivityRequest request,
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
                    Path = "v2/gift-cards/activities",
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
                return JsonUtils.Deserialize<CreateGiftCardActivityResponse>(responseBody)!;
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
