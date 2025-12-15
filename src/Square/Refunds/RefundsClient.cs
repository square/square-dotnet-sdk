using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Refunds;

public partial class RefundsClient
{
    private RawClient _client;

    internal RefundsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Retrieves a list of refunds for the account making the request.
    ///
    /// Results are eventually consistent, and new refunds or changes to refunds might take several
    /// seconds to appear.
    ///
    /// The maximum results per page is 100.
    /// </summary>
    private async Task<ListPaymentRefundsResponse> ListInternalAsync(
        ListRefundsRequest request,
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
        if (request.Status != null)
        {
            _query["status"] = request.Status;
        }
        if (request.SourceType != null)
        {
            _query["source_type"] = request.SourceType;
        }
        if (request.Limit != null)
        {
            _query["limit"] = request.Limit.Value.ToString();
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
                    Path = "v2/refunds",
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
                return JsonUtils.Deserialize<ListPaymentRefundsResponse>(responseBody)!;
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
    /// Retrieves a list of refunds for the account making the request.
    ///
    /// Results are eventually consistent, and new refunds or changes to refunds might take several
    /// seconds to appear.
    ///
    /// The maximum results per page is 100.
    /// </summary>
    /// <example><code>
    /// await client.Refunds.ListAsync(
    ///     new ListRefundsRequest
    ///     {
    ///         BeginTime = "begin_time",
    ///         EndTime = "end_time",
    ///         SortOrder = "sort_order",
    ///         Cursor = "cursor",
    ///         LocationId = "location_id",
    ///         Status = "status",
    ///         SourceType = "source_type",
    ///         Limit = 1,
    ///         UpdatedAtBeginTime = "updated_at_begin_time",
    ///         UpdatedAtEndTime = "updated_at_end_time",
    ///         SortField = ListPaymentRefundsRequestSortField.CreatedAt,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<PaymentRefund>> ListAsync(
        ListRefundsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListRefundsRequest,
            RequestOptions?,
            ListPaymentRefundsResponse,
            string?,
            PaymentRefund
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
                response => response.Refunds?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Refunds a payment. You can refund the entire payment amount or a
    /// portion of it. You can use this endpoint to refund a card payment or record a
    /// refund of a cash or external payment. For more information, see
    /// [Refund Payment](https://developer.squareup.com/docs/payments-api/refund-payments).
    /// </summary>
    /// <example><code>
    /// await client.Refunds.RefundPaymentAsync(
    ///     new RefundPaymentRequest
    ///     {
    ///         IdempotencyKey = "9b7f2dcf-49da-4411-b23e-a2d6af21333a",
    ///         AmountMoney = new Money { Amount = 1000, Currency = Currency.Usd },
    ///         AppFeeMoney = new Money { Amount = 10, Currency = Currency.Usd },
    ///         PaymentId = "R2B3Z8WMVt3EAmzYWLZvz7Y69EbZY",
    ///         Reason = "Example",
    ///     }
    /// );
    /// </code></example>
    public async Task<RefundPaymentResponse> RefundPaymentAsync(
        RefundPaymentRequest request,
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
                    Path = "v2/refunds",
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
                return JsonUtils.Deserialize<RefundPaymentResponse>(responseBody)!;
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
    /// Retrieves a specific refund using the `refund_id`.
    /// </summary>
    /// <example><code>
    /// await client.Refunds.GetAsync(new Square.Refunds.GetRefundsRequest { RefundId = "refund_id" });
    /// </code></example>
    public async Task<GetPaymentRefundResponse> GetAsync(
        GetRefundsRequest request,
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
                        "v2/refunds/{0}",
                        ValueConvert.ToPathParameterString(request.RefundId)
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
                return JsonUtils.Deserialize<GetPaymentRefundResponse>(responseBody)!;
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
