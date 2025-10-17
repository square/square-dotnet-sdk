using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Loyalty.Programs.Promotions;

public partial class PromotionsClient
{
    private RawClient _client;

    internal PromotionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists the loyalty promotions associated with a [loyalty program](entity:LoyaltyProgram).
    /// Results are sorted by the `created_at` date in descending order (newest to oldest).
    /// </summary>
    private async Task<ListLoyaltyPromotionsResponse> ListInternalAsync(
        ListPromotionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Status != null)
        {
            _query["status"] = request.Status.Value.ToString();
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/loyalty/programs/{0}/promotions",
                        ValueConvert.ToPathParameterString(request.ProgramId)
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
                return JsonUtils.Deserialize<ListLoyaltyPromotionsResponse>(responseBody)!;
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
    /// Lists the loyalty promotions associated with a [loyalty program](entity:LoyaltyProgram).
    /// Results are sorted by the `created_at` date in descending order (newest to oldest).
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Programs.Promotions.ListAsync(
    ///     new ListPromotionsRequest
    ///     {
    ///         ProgramId = "program_id",
    ///         Status = LoyaltyPromotionStatus.Active,
    ///         Cursor = "cursor",
    ///         Limit = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<LoyaltyPromotion>> ListAsync(
        ListPromotionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListPromotionsRequest,
            RequestOptions?,
            ListLoyaltyPromotionsResponse,
            string?,
            LoyaltyPromotion
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
                response => response?.LoyaltyPromotions?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a loyalty promotion for a [loyalty program](entity:LoyaltyProgram). A loyalty promotion
    /// enables buyers to earn points in addition to those earned from the base loyalty program.
    ///
    /// This endpoint sets the loyalty promotion to the `ACTIVE` or `SCHEDULED` status, depending on the
    /// `available_time` setting. A loyalty program can have a maximum of 10 loyalty promotions with an
    /// `ACTIVE` or `SCHEDULED` status.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Programs.Promotions.CreateAsync(
    ///     new CreateLoyaltyPromotionRequest
    ///     {
    ///         ProgramId = "program_id",
    ///         LoyaltyPromotion = new LoyaltyPromotion
    ///         {
    ///             Name = "Tuesday Happy Hour Promo",
    ///             Incentive = new LoyaltyPromotionIncentive
    ///             {
    ///                 Type = LoyaltyPromotionIncentiveType.PointsMultiplier,
    ///                 PointsMultiplierData = new LoyaltyPromotionIncentivePointsMultiplierData
    ///                 {
    ///                     Multiplier = "3.0",
    ///                 },
    ///             },
    ///             AvailableTime = new LoyaltyPromotionAvailableTimeData
    ///             {
    ///                 TimePeriods = new List&lt;string&gt;()
    ///                 {
    ///                     "BEGIN:VEVENT\nDTSTART:20220816T160000\nDURATION:PT2H\nRRULE:FREQ=WEEKLY;BYDAY=TU\nEND:VEVENT",
    ///                 },
    ///             },
    ///             TriggerLimit = new LoyaltyPromotionTriggerLimit
    ///             {
    ///                 Times = 1,
    ///                 Interval = LoyaltyPromotionTriggerLimitInterval.Day,
    ///             },
    ///             MinimumSpendAmountMoney = new Money { Amount = 2000, Currency = Currency.Usd },
    ///             QualifyingCategoryIds = new List&lt;string&gt;() { "XTQPYLR3IIU9C44VRCB3XD12" },
    ///         },
    ///         IdempotencyKey = "ec78c477-b1c3-4899-a209-a4e71337c996",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateLoyaltyPromotionResponse> CreateAsync(
        CreateLoyaltyPromotionRequest request,
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
                        "v2/loyalty/programs/{0}/promotions",
                        ValueConvert.ToPathParameterString(request.ProgramId)
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
                return JsonUtils.Deserialize<CreateLoyaltyPromotionResponse>(responseBody)!;
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
    /// Retrieves a loyalty promotion.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Programs.Promotions.GetAsync(
    ///     new GetPromotionsRequest { ProgramId = "program_id", PromotionId = "promotion_id" }
    /// );
    /// </code></example>
    public async Task<GetLoyaltyPromotionResponse> GetAsync(
        GetPromotionsRequest request,
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
                        "v2/loyalty/programs/{0}/promotions/{1}",
                        ValueConvert.ToPathParameterString(request.ProgramId),
                        ValueConvert.ToPathParameterString(request.PromotionId)
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
                return JsonUtils.Deserialize<GetLoyaltyPromotionResponse>(responseBody)!;
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
    /// Cancels a loyalty promotion. Use this endpoint to cancel an `ACTIVE` promotion earlier than the
    /// end date, cancel an `ACTIVE` promotion when an end date is not specified, or cancel a `SCHEDULED` promotion.
    /// Because updating a promotion is not supported, you can also use this endpoint to cancel a promotion before
    /// you create a new one.
    ///
    /// This endpoint sets the loyalty promotion to the `CANCELED` state
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Programs.Promotions.CancelAsync(
    ///     new CancelPromotionsRequest { ProgramId = "program_id", PromotionId = "promotion_id" }
    /// );
    /// </code></example>
    public async Task<CancelLoyaltyPromotionResponse> CancelAsync(
        CancelPromotionsRequest request,
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
                        "v2/loyalty/programs/{0}/promotions/{1}/cancel",
                        ValueConvert.ToPathParameterString(request.ProgramId),
                        ValueConvert.ToPathParameterString(request.PromotionId)
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
                return JsonUtils.Deserialize<CancelLoyaltyPromotionResponse>(responseBody)!;
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
