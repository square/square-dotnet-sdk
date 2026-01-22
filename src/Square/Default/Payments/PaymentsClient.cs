using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Default;

public partial class PaymentsClient : IPaymentsClient
{
    private RawClient _client;

    internal PaymentsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves a list of payments taken by the account making the request.
    ///
    /// Results are eventually consistent, and new payments or changes to payments might take several
    /// seconds to appear.
    ///
    /// The maximum results per page is 100.
    /// </summary>
    private async Task<ListPaymentsResponse> ListInternalAsync(
        ListPaymentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.BeginTime != null)
        {
            _query["begin_time"] = request.BeginTime;
        }
        if (request.EndTime != null)
        {
            _query["end_time"] = request.EndTime;
        }
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder;
        }
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.LocationId != null)
        {
            _query["location_id"] = request.LocationId;
        }
        if (request.Total != null)
        {
            _query["total"] = request.Total.Value.ToString();
        }
        if (request.Last4 != null)
        {
            _query["last_4"] = request.Last4;
        }
        if (request.CardBrand != null)
        {
            _query["card_brand"] = request.CardBrand;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
        }
        if (request.IsOfflinePayment != null)
        {
            _query["is_offline_payment"] = JsonUtils.Serialize(request.IsOfflinePayment.Value);
        }
        if (request.OfflineBeginTime != null)
        {
            _query["offline_begin_time"] = request.OfflineBeginTime;
        }
        if (request.OfflineEndTime != null)
        {
            _query["offline_end_time"] = request.OfflineEndTime;
        }
        if (request.UpdatedAtBeginTime != null)
        {
            _query["updated_at_begin_time"] = request.UpdatedAtBeginTime;
        }
        if (request.UpdatedAtEndTime != null)
        {
            _query["updated_at_end_time"] = request.UpdatedAtEndTime;
        }
        if (request.SortField != null)
        {
            _query["sort_field"] = request.SortField.Value.ToString();
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = "v2/payments",
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
                return JsonUtils.Deserialize<ListPaymentsResponse>(responseBody)!;
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
    /// Retrieves a list of payments taken by the account making the request.
    ///
    /// Results are eventually consistent, and new payments or changes to payments might take several
    /// seconds to appear.
    ///
    /// The maximum results per page is 100.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payments.ListAsync(
    ///     new ListPaymentsRequest
    ///     {
    ///         BeginTime = "begin_time",
    ///         EndTime = "end_time",
    ///         SortOrder = "sort_order",
    ///         Cursor = "cursor",
    ///         LocationId = "location_id",
    ///         Total = 1000000,
    ///         Last4 = "last_4",
    ///         CardBrand = "card_brand",
    ///         Limit = 1,
    ///         IsOfflinePayment = true,
    ///         OfflineBeginTime = "offline_begin_time",
    ///         OfflineEndTime = "offline_end_time",
    ///         UpdatedAtBeginTime = "updated_at_begin_time",
    ///         UpdatedAtEndTime = "updated_at_end_time",
    ///         SortField = ListPaymentsRequestSortField.CreatedAt,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<Payment>> ListAsync(
        ListPaymentsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListPaymentsRequest,
            RequestOptions?,
            ListPaymentsResponse,
            string?,
            Payment
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
                response => response.Payments?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a payment using the provided source. You can use this endpoint
    /// to charge a card (credit/debit card or
    /// Square gift card) or record a payment that the seller received outside of Square
    /// (cash payment from a buyer or a payment that an external entity
    /// processed on behalf of the seller).
    ///
    /// The endpoint creates a
    /// `Payment` object and returns it in the response.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payments.CreateAsync(
    ///     new CreatePaymentRequest
    ///     {
    ///         SourceId = "ccof:GaJGNaZa8x4OgDJn4GB",
    ///         IdempotencyKey = "7b0f3ec5-086a-4871-8f13-3c81b3875218",
    ///         AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
    ///         AppFeeMoney = new Money { Amount = 10, Currency = Currency.Usd },
    ///         Autocomplete = true,
    ///         CustomerId = "W92WH6P11H4Z77CTET0RNTGFW8",
    ///         LocationId = "L88917AVBK2S5",
    ///         ReferenceId = "123456",
    ///         Note = "Brief description",
    ///     }
    /// );
    /// </code></example>
    public async Task<CreatePaymentResponse> CreateAsync(
        CreatePaymentRequest request,
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
                    Path = "v2/payments",
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
                return JsonUtils.Deserialize<CreatePaymentResponse>(responseBody)!;
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
    /// Cancels (voids) a payment identified by the idempotency key that is specified in the
    /// request.
    ///
    /// Use this method when the status of a `CreatePayment` request is unknown (for example, after you send a
    /// `CreatePayment` request, a network error occurs and you do not get a response). In this case, you can
    /// direct Square to cancel the payment using this endpoint. In the request, you provide the same
    /// idempotency key that you provided in your `CreatePayment` request that you want to cancel. After
    /// canceling the payment, you can submit your `CreatePayment` request again.
    ///
    /// Note that if no payment with the specified idempotency key is found, no action is taken and the endpoint
    /// returns successfully.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payments.CancelByIdempotencyKeyAsync(
    ///     new CancelPaymentByIdempotencyKeyRequest
    ///     {
    ///         IdempotencyKey = "a7e36d40-d24b-11e8-b568-0800200c9a66",
    ///     }
    /// );
    /// </code></example>
    public async Task<CancelPaymentByIdempotencyKeyResponse> CancelByIdempotencyKeyAsync(
        CancelPaymentByIdempotencyKeyRequest request,
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
                    Path = "v2/payments/cancel",
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
                return JsonUtils.Deserialize<CancelPaymentByIdempotencyKeyResponse>(responseBody)!;
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
    /// Retrieves details for a specific payment.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payments.GetAsync(new GetPaymentsRequest { PaymentId = "payment_id" });
    /// </code></example>
    public async Task<GetPaymentResponse> GetAsync(
        GetPaymentsRequest request,
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
                        "v2/payments/{0}",
                        ValueConvert.ToPathParameterString(request.PaymentId)
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
                return JsonUtils.Deserialize<GetPaymentResponse>(responseBody)!;
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
    /// Updates a payment with the APPROVED status.
    /// You can update the `amount_money` and `tip_money` using this endpoint.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payments.UpdateAsync(
    ///     new UpdatePaymentRequest
    ///     {
    ///         PaymentId = "payment_id",
    ///         Payment = new Payment
    ///         {
    ///             AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
    ///             TipMoney = new Money { Amount = 100, Currency = Currency.Usd },
    ///             VersionToken = "ODhwVQ35xwlzRuoZEwKXucfu7583sPTzK48c5zoGd0g6o",
    ///         },
    ///         IdempotencyKey = "956f8b13-e4ec-45d6-85e8-d1d95ef0c5de",
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdatePaymentResponse> UpdateAsync(
        UpdatePaymentRequest request,
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
                        "v2/payments/{0}",
                        ValueConvert.ToPathParameterString(request.PaymentId)
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
                return JsonUtils.Deserialize<UpdatePaymentResponse>(responseBody)!;
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
    /// Cancels (voids) a payment. You can use this endpoint to cancel a payment with
    /// the APPROVED `status`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payments.CancelAsync(new CancelPaymentsRequest { PaymentId = "payment_id" });
    /// </code></example>
    public async Task<CancelPaymentResponse> CancelAsync(
        CancelPaymentsRequest request,
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
                        "v2/payments/{0}/cancel",
                        ValueConvert.ToPathParameterString(request.PaymentId)
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
                return JsonUtils.Deserialize<CancelPaymentResponse>(responseBody)!;
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
    /// Completes (captures) a payment.
    /// By default, payments are set to complete immediately after they are created.
    ///
    /// You can use this endpoint to complete a payment with the APPROVED `status`.
    /// </summary>
    /// <example><code>
    /// await client.Default.Payments.CompleteAsync(
    ///     new CompletePaymentRequest { PaymentId = "payment_id" }
    /// );
    /// </code></example>
    public async Task<CompletePaymentResponse> CompleteAsync(
        CompletePaymentRequest request,
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
                        "v2/payments/{0}/complete",
                        ValueConvert.ToPathParameterString(request.PaymentId)
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
                return JsonUtils.Deserialize<CompletePaymentResponse>(responseBody)!;
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
