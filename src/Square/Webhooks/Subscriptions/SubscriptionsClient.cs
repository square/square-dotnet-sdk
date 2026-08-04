using System.Text.Json;
using Square;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

public partial class SubscriptionsClient : ISubscriptionsClient
{
    private RawClient _client;

    internal SubscriptionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists all webhook subscriptions owned by your application.
    /// </summary>
    private async Task<ListWebhookSubscriptionsResponse> ListInternalAsync(
        ListSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Cursor != null)
        {
            _query["cursor"] = request.Cursor;
        }
        if (request.IncludeDisabled != null)
        {
            _query["include_disabled"] = JsonUtils.Serialize(request.IncludeDisabled.Value);
        }
        if (request.SortOrder != null)
        {
            _query["sort_order"] = request.SortOrder.Value.ToString();
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
                    Path = "v2/webhooks/subscriptions",
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
                return JsonUtils.Deserialize<ListWebhookSubscriptionsResponse>(responseBody)!;
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
    /// Lists all webhook subscriptions owned by your application.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.Subscriptions.ListAsync(
    ///     new ListSubscriptionsRequest
    ///     {
    ///         Cursor = "cursor",
    ///         IncludeDisabled = true,
    ///         SortOrder = SortOrder.Desc,
    ///         Limit = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<Pager<WebhookSubscription>> ListAsync(
        ListSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListSubscriptionsRequest,
            RequestOptions?,
            ListWebhookSubscriptionsResponse,
            string?,
            WebhookSubscription
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
                response => response.Subscriptions?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Creates a webhook subscription.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.Subscriptions.CreateAsync(
    ///     new CreateWebhookSubscriptionRequest
    ///     {
    ///         IdempotencyKey = "63f84c6c-2200-4c99-846c-2670a1311fbf",
    ///         Subscription = new WebhookSubscription
    ///         {
    ///             Name = "Example Webhook Subscription",
    ///             EventTypes = new List&lt;string&gt;() { "payment.created", "payment.updated" },
    ///             NotificationUrl = "https://example-webhook-url.com",
    ///             ApiVersion = "2021-12-15",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateWebhookSubscriptionResponse> CreateAsync(
        CreateWebhookSubscriptionRequest request,
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
                    Path = "v2/webhooks/subscriptions",
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
                return JsonUtils.Deserialize<CreateWebhookSubscriptionResponse>(responseBody)!;
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
    /// Retrieves a webhook subscription identified by its ID.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.Subscriptions.GetAsync(
    ///     new Square.Webhooks.Subscriptions.GetSubscriptionsRequest { SubscriptionId = "subscription_id" }
    /// );
    /// </code></example>
    public async Task<GetWebhookSubscriptionResponse> GetAsync(
        GetSubscriptionsRequest request,
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
                        "v2/webhooks/subscriptions/{0}",
                        ValueConvert.ToPathParameterString(request.SubscriptionId)
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
                return JsonUtils.Deserialize<GetWebhookSubscriptionResponse>(responseBody)!;
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
    /// Updates a webhook subscription.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.Subscriptions.UpdateAsync(
    ///     new UpdateWebhookSubscriptionRequest
    ///     {
    ///         SubscriptionId = "subscription_id",
    ///         Subscription = new WebhookSubscription
    ///         {
    ///             Name = "Updated Example Webhook Subscription",
    ///             Enabled = false,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateWebhookSubscriptionResponse> UpdateAsync(
        UpdateWebhookSubscriptionRequest request,
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
                        "v2/webhooks/subscriptions/{0}",
                        ValueConvert.ToPathParameterString(request.SubscriptionId)
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
                return JsonUtils.Deserialize<UpdateWebhookSubscriptionResponse>(responseBody)!;
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
    /// Deletes a webhook subscription.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.Subscriptions.DeleteAsync(
    ///     new DeleteSubscriptionsRequest { SubscriptionId = "subscription_id" }
    /// );
    /// </code></example>
    public async Task<DeleteWebhookSubscriptionResponse> DeleteAsync(
        DeleteSubscriptionsRequest request,
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
                        "v2/webhooks/subscriptions/{0}",
                        ValueConvert.ToPathParameterString(request.SubscriptionId)
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
                return JsonUtils.Deserialize<DeleteWebhookSubscriptionResponse>(responseBody)!;
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
    /// Updates a webhook subscription by replacing the existing signature key with a new one.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.Subscriptions.UpdateSignatureKeyAsync(
    ///     new UpdateWebhookSubscriptionSignatureKeyRequest
    ///     {
    ///         SubscriptionId = "subscription_id",
    ///         IdempotencyKey = "ed80ae6b-0654-473b-bbab-a39aee89a60d",
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateWebhookSubscriptionSignatureKeyResponse> UpdateSignatureKeyAsync(
        UpdateWebhookSubscriptionSignatureKeyRequest request,
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
                        "v2/webhooks/subscriptions/{0}/signature-key",
                        ValueConvert.ToPathParameterString(request.SubscriptionId)
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
                return JsonUtils.Deserialize<UpdateWebhookSubscriptionSignatureKeyResponse>(
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
    /// Tests a webhook subscription by sending a test event to the notification URL.
    /// </summary>
    /// <example><code>
    /// await client.Webhooks.Subscriptions.TestAsync(
    ///     new TestWebhookSubscriptionRequest
    ///     {
    ///         SubscriptionId = "subscription_id",
    ///         EventType = "payment.created",
    ///     }
    /// );
    /// </code></example>
    public async Task<TestWebhookSubscriptionResponse> TestAsync(
        TestWebhookSubscriptionRequest request,
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
                        "v2/webhooks/subscriptions/{0}/test",
                        ValueConvert.ToPathParameterString(request.SubscriptionId)
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
                return JsonUtils.Deserialize<TestWebhookSubscriptionResponse>(responseBody)!;
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
