using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Core;

namespace Square.Checkout.PaymentLinks;

public partial class PaymentLinksClient
{
    private RawClient _client;

    internal PaymentLinksClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists all payment links.
    /// </summary>
    private async Task<ListPaymentLinksResponse> ListInternalAsync(
        ListPaymentLinksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
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
                    Path = "v2/online-checkout/payment-links",
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
                return JsonUtils.Deserialize<ListPaymentLinksResponse>(responseBody)!;
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
    /// Lists all payment links.
    /// </summary>
    /// <example><code>
    /// await client.Checkout.PaymentLinks.ListAsync(
    ///     new ListPaymentLinksRequest { Cursor = "cursor", Limit = 1 }
    /// );
    /// </code></example>
    public async Task<Pager<PaymentLink>> ListAsync(
        ListPaymentLinksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListPaymentLinksRequest,
            RequestOptions?,
            ListPaymentLinksResponse,
            string?,
            PaymentLink
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
                response => response?.PaymentLinks?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a Square-hosted checkout page. Applications can share the resulting payment link with their buyer to pay for goods and services.
    /// </summary>
    /// <example><code>
    /// await client.Checkout.PaymentLinks.CreateAsync(
    ///     new CreatePaymentLinkRequest
    ///     {
    ///         IdempotencyKey = "cd9e25dc-d9f2-4430-aedb-61605070e95f",
    ///         QuickPay = new QuickPay
    ///         {
    ///             Name = "Auto Detailing",
    ///             PriceMoney = new Money { Amount = 10000, Currency = Currency.Usd },
    ///             LocationId = "A9Y43N9ABXZBP",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreatePaymentLinkResponse> CreateAsync(
        CreatePaymentLinkRequest request,
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
                    Path = "v2/online-checkout/payment-links",
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
                return JsonUtils.Deserialize<CreatePaymentLinkResponse>(responseBody)!;
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
    /// Retrieves a payment link.
    /// </summary>
    /// <example><code>
    /// await client.Checkout.PaymentLinks.GetAsync(new GetPaymentLinksRequest { Id = "id" });
    /// </code></example>
    public async Task<GetPaymentLinkResponse> GetAsync(
        GetPaymentLinksRequest request,
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
                        "v2/online-checkout/payment-links/{0}",
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
                return JsonUtils.Deserialize<GetPaymentLinkResponse>(responseBody)!;
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
    /// Updates a payment link. You can update the `payment_link` fields such as
    /// `description`, `checkout_options`, and  `pre_populated_data`.
    /// You cannot update other fields such as the `order_id`, `version`, `URL`, or `timestamp` field.
    /// </summary>
    /// <example><code>
    /// await client.Checkout.PaymentLinks.UpdateAsync(
    ///     new UpdatePaymentLinkRequest
    ///     {
    ///         Id = "id",
    ///         PaymentLink = new PaymentLink
    ///         {
    ///             Version = 1,
    ///             CheckoutOptions = new CheckoutOptions { AskForShippingAddress = true },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdatePaymentLinkResponse> UpdateAsync(
        UpdatePaymentLinkRequest request,
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
                        "v2/online-checkout/payment-links/{0}",
                        ValueConvert.ToPathParameterString(request.Id)
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
                return JsonUtils.Deserialize<UpdatePaymentLinkResponse>(responseBody)!;
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
    /// Deletes a payment link.
    /// </summary>
    /// <example><code>
    /// await client.Checkout.PaymentLinks.DeleteAsync(new DeletePaymentLinksRequest { Id = "id" });
    /// </code></example>
    public async Task<DeletePaymentLinkResponse> DeleteAsync(
        DeletePaymentLinksRequest request,
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
                        "v2/online-checkout/payment-links/{0}",
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
                return JsonUtils.Deserialize<DeletePaymentLinkResponse>(responseBody)!;
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
