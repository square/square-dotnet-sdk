using System.Text.Json;
using Square;
using Square.Core;
using Square.Loyalty.Programs.Promotions;

namespace Square.Loyalty.Programs;

public partial class ProgramsClient : IProgramsClient
{
    private RawClient _client;

    internal ProgramsClient(RawClient client)
    {
        _client = client;
        Promotions = new PromotionsClient(_client);
    }

    public PromotionsClient Promotions { get; }

    /// <summary>
    /// Returns a list of loyalty programs in the seller's account.
    /// Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
    ///
    ///
    /// Replaced with [RetrieveLoyaltyProgram](api-endpoint:Loyalty-RetrieveLoyaltyProgram) when used with the keyword `main`.
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Programs.ListAsync();
    /// </code></example>
    public async Task<ListLoyaltyProgramsResponse> ListAsync(
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
                    Path = "v2/loyalty/programs",
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
                return JsonUtils.Deserialize<ListLoyaltyProgramsResponse>(responseBody)!;
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
    /// Retrieves the loyalty program in a seller's account, specified by the program ID or the keyword `main`.
    ///
    /// Loyalty programs define how buyers can earn points and redeem points for rewards. Square sellers can have only one loyalty program, which is created and managed from the Seller Dashboard. For more information, see [Loyalty Program Overview](https://developer.squareup.com/docs/loyalty/overview).
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Programs.GetAsync(new GetProgramsRequest { ProgramId = "program_id" });
    /// </code></example>
    public async Task<GetLoyaltyProgramResponse> GetAsync(
        GetProgramsRequest request,
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
                        "v2/loyalty/programs/{0}",
                        ValueConvert.ToPathParameterString(request.ProgramId)
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
                return JsonUtils.Deserialize<GetLoyaltyProgramResponse>(responseBody)!;
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
    /// Calculates the number of points a buyer can earn from a purchase. Applications might call this endpoint
    /// to display the points to the buyer.
    ///
    /// - If you are using the Orders API to manage orders, provide the `order_id` and (optional) `loyalty_account_id`.
    /// Square reads the order to compute the points earned from the base loyalty program and an associated
    /// [loyalty promotion](entity:LoyaltyPromotion).
    ///
    /// - If you are not using the Orders API to manage orders, provide `transaction_amount_money` with the
    /// purchase amount. Square uses this amount to calculate the points earned from the base loyalty program,
    /// but not points earned from a loyalty promotion. For spend-based and visit-based programs, the `tax_mode`
    /// setting of the accrual rule indicates how taxes should be treated for loyalty points accrual.
    /// If the purchase qualifies for program points, call
    /// [ListLoyaltyPromotions](api-endpoint:Loyalty-ListLoyaltyPromotions) and perform a client-side computation
    /// to calculate whether the purchase also qualifies for promotion points. For more information, see
    /// [Calculating promotion points](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#calculate-promotion-points).
    /// </summary>
    /// <example><code>
    /// await client.Loyalty.Programs.CalculateAsync(
    ///     new CalculateLoyaltyPointsRequest
    ///     {
    ///         ProgramId = "program_id",
    ///         OrderId = "RFZfrdtm3mhO1oGzf5Cx7fEMsmGZY",
    ///         LoyaltyAccountId = "79b807d2-d786-46a9-933b-918028d7a8c5",
    ///     }
    /// );
    /// </code></example>
    public async Task<CalculateLoyaltyPointsResponse> CalculateAsync(
        CalculateLoyaltyPointsRequest request,
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
                        "v2/loyalty/programs/{0}/calculate",
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
                return JsonUtils.Deserialize<CalculateLoyaltyPointsResponse>(responseBody)!;
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
