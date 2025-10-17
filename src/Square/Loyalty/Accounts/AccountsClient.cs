using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Loyalty.Accounts;

public partial class AccountsClient
{
    private RawClient _client;

    internal AccountsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a loyalty account. To create a loyalty account, you must provide the `program_id` and a `mapping` with the `phone_number` of the buyer.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Accounts.CreateAsync(
    ///     new CreateLoyaltyAccountRequest
    ///     {
    ///         LoyaltyAccount = new LoyaltyAccount
    ///         {
    ///             ProgramId = "d619f755-2d17-41f3-990d-c04ecedd64dd",
    ///             Mapping = new LoyaltyAccountMapping { PhoneNumber = "+14155551234" },
    ///         },
    ///         IdempotencyKey = "ec78c477-b1c3-4899-a209-a4e71337c996",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateLoyaltyAccountResponse> CreateAsync(
        CreateLoyaltyAccountRequest request,
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
                    Path = "v2/loyalty/accounts",
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
                return JsonUtils.Deserialize<CreateLoyaltyAccountResponse>(responseBody)!;
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
    /// Searches for loyalty accounts in a loyalty program.
    ///
    /// You can search for a loyalty account using the phone number or customer ID associated with the account. To return all loyalty accounts, specify an empty `query` object or omit it entirely.
    ///
    /// Search results are sorted by `created_at` in ascending order.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Accounts.SearchAsync(
    ///     new SearchLoyaltyAccountsRequest
    ///     {
    ///         Query = new SearchLoyaltyAccountsRequestLoyaltyAccountQuery
    ///         {
    ///             Mappings = new List&lt;LoyaltyAccountMapping&gt;()
    ///             {
    ///                 new LoyaltyAccountMapping { PhoneNumber = "+14155551234" },
    ///             },
    ///         },
    ///         Limit = 10,
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchLoyaltyAccountsResponse> SearchAsync(
        SearchLoyaltyAccountsRequest request,
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
                    Path = "v2/loyalty/accounts/search",
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
                return JsonUtils.Deserialize<SearchLoyaltyAccountsResponse>(responseBody)!;
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
    /// Retrieves a loyalty account.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Accounts.GetAsync(new GetAccountsRequest { AccountId = "account_id" });
    /// </code></example>
    public async Task<GetLoyaltyAccountResponse> GetAsync(
        GetAccountsRequest request,
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
                        "v2/loyalty/accounts/{0}",
                        ValueConvert.ToPathParameterString(request.AccountId)
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
                return JsonUtils.Deserialize<GetLoyaltyAccountResponse>(responseBody)!;
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
    /// Adds points earned from a purchase to a [loyalty account](entity:LoyaltyAccount).
    ///
    /// - If you are using the Orders API to manage orders, provide the `order_id`. Square reads the order
    /// to compute the points earned from both the base loyalty program and an associated
    /// [loyalty promotion](entity:LoyaltyPromotion). For purchases that qualify for multiple accrual
    /// rules, Square computes points based on the accrual rule that grants the most points.
    /// For purchases that qualify for multiple promotions, Square computes points based on the most
    /// recently created promotion. A purchase must first qualify for program points to be eligible for promotion points.
    ///
    /// - If you are not using the Orders API to manage orders, provide `points` with the number of points to add.
    /// You must first perform a client-side computation of the points earned from the loyalty program and
    /// loyalty promotion. For spend-based and visit-based programs, you can call [CalculateLoyaltyPoints](api-endpoint:Loyalty-CalculateLoyaltyPoints)
    /// to compute the points earned from the base loyalty program. For information about computing points earned from a loyalty promotion, see
    /// [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Accounts.AccumulatePointsAsync(
    ///     new AccumulateLoyaltyPointsRequest
    ///     {
    ///         AccountId = "account_id",
    ///         AccumulatePoints = new LoyaltyEventAccumulatePoints
    ///         {
    ///             OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
    ///         },
    ///         IdempotencyKey = "58b90739-c3e8-4b11-85f7-e636d48d72cb",
    ///         LocationId = "P034NEENMD09F",
    ///     }
    /// );
    /// </code></example>
    public async Task<AccumulateLoyaltyPointsResponse> AccumulatePointsAsync(
        AccumulateLoyaltyPointsRequest request,
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
                        "v2/loyalty/accounts/{0}/accumulate",
                        ValueConvert.ToPathParameterString(request.AccountId)
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
                return JsonUtils.Deserialize<AccumulateLoyaltyPointsResponse>(responseBody)!;
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
    /// Adds points to or subtracts points from a buyer's account.
    ///
    /// Use this endpoint only when you need to manually adjust points. Otherwise, in your application flow, you call
    /// [AccumulateLoyaltyPoints](api-endpoint:Loyalty-AccumulateLoyaltyPoints)
    /// to add points when a buyer pays for the purchase.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Accounts.AdjustAsync(
    ///     new AdjustLoyaltyPointsRequest
    ///     {
    ///         AccountId = "account_id",
    ///         IdempotencyKey = "bc29a517-3dc9-450e-aa76-fae39ee849d1",
    ///         AdjustPoints = new LoyaltyEventAdjustPoints
    ///         {
    ///             Points = 10,
    ///             Reason = "Complimentary points",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<AdjustLoyaltyPointsResponse> AdjustAsync(
        AdjustLoyaltyPointsRequest request,
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
                        "v2/loyalty/accounts/{0}/adjust",
                        ValueConvert.ToPathParameterString(request.AccountId)
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
                return JsonUtils.Deserialize<AdjustLoyaltyPointsResponse>(responseBody)!;
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
