using System.Net.Http;
using System.Text.Json;
using System.Threading;
using Square;
using Square.Core;

namespace Square.Subscriptions;

public partial class SubscriptionsClient
{
    private RawClient _client;

    internal SubscriptionsClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Lists all [events](https://developer.squareup.com/docs/subscriptions-api/actions-events) for a specific subscription.
    /// </summary>
    private async Task<ListSubscriptionEventsResponse> ListEventsInternalAsync(
        ListEventsSubscriptionsRequest request,
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
                    Path = string.Format(
                        "v2/subscriptions/{0}/events",
                        ValueConvert.ToPathParameterString(request.SubscriptionId)
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
                return JsonUtils.Deserialize<ListSubscriptionEventsResponse>(responseBody)!;
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
    /// Enrolls a customer in a subscription.
    ///
    /// If you provide a card on file in the request, Square charges the card for
    /// the subscription. Otherwise, Square sends an invoice to the customer's email
    /// address. The subscription starts immediately, unless the request includes
    /// the optional `start_date`. Each individual subscription is associated with a particular location.
    ///
    /// For more information, see [Create a subscription](https://developer.squareup.com/docs/subscriptions-api/manage-subscriptions#create-a-subscription).
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.CreateAsync(
    ///     new CreateSubscriptionRequest
    ///     {
    ///         IdempotencyKey = "8193148c-9586-11e6-99f9-28cfe92138cf",
    ///         LocationId = "S8GWD5R9QB376",
    ///         PlanVariationId = "6JHXF3B2CW3YKHDV4XEM674H",
    ///         CustomerId = "CHFGVKYY8RSV93M5KCYTG4PN0G",
    ///         StartDate = "2023-06-20",
    ///         CardId = "ccof:qy5x8hHGYsgLrp4Q4GB",
    ///         Timezone = "America/Los_Angeles",
    ///         Source = new SubscriptionSource { Name = "My Application" },
    ///         Phases = new List&lt;Phase&gt;()
    ///         {
    ///             new Phase { Ordinal = 0, OrderTemplateId = "U2NaowWxzXwpsZU697x7ZHOAnCNZY" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<CreateSubscriptionResponse> CreateAsync(
        CreateSubscriptionRequest request,
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
                    Path = "v2/subscriptions",
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
                return JsonUtils.Deserialize<CreateSubscriptionResponse>(responseBody)!;
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
    /// Schedules a plan variation change for all active subscriptions under a given plan
    /// variation. For more information, see [Swap Subscription Plan Variations](https://developer.squareup.com/docs/subscriptions-api/swap-plan-variations).
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.BulkSwapPlanAsync(
    ///     new BulkSwapPlanRequest
    ///     {
    ///         NewPlanVariationId = "FQ7CDXXWSLUJRPM3GFJSJGZ7",
    ///         OldPlanVariationId = "6JHXF3B2CW3YKHDV4XEM674H",
    ///         LocationId = "S8GWD5R9QB376",
    ///     }
    /// );
    /// </code></example>
    public async Task<BulkSwapPlanResponse> BulkSwapPlanAsync(
        BulkSwapPlanRequest request,
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
                    Path = "v2/subscriptions/bulk-swap-plan",
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
                return JsonUtils.Deserialize<BulkSwapPlanResponse>(responseBody)!;
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
    /// Searches for subscriptions.
    ///
    /// Results are ordered chronologically by subscription creation date. If
    /// the request specifies more than one location ID,
    /// the endpoint orders the result
    /// by location ID, and then by creation date within each location. If no locations are given
    /// in the query, all locations are searched.
    ///
    /// You can also optionally specify `customer_ids` to search by customer.
    /// If left unset, all customers
    /// associated with the specified locations are returned.
    /// If the request specifies customer IDs, the endpoint orders results
    /// first by location, within location by customer ID, and within
    /// customer by subscription creation date.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.SearchAsync(
    ///     new SearchSubscriptionsRequest
    ///     {
    ///         Query = new SearchSubscriptionsQuery
    ///         {
    ///             Filter = new SearchSubscriptionsFilter
    ///             {
    ///                 CustomerIds = new List&lt;string&gt;() { "CHFGVKYY8RSV93M5KCYTG4PN0G" },
    ///                 LocationIds = new List&lt;string&gt;() { "S8GWD5R9QB376" },
    ///                 SourceNames = new List&lt;string&gt;() { "My App" },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<SearchSubscriptionsResponse> SearchAsync(
        SearchSubscriptionsRequest request,
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
                    Path = "v2/subscriptions/search",
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
                return JsonUtils.Deserialize<SearchSubscriptionsResponse>(responseBody)!;
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
    /// Retrieves a specific subscription.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.GetAsync(
    ///     new GetSubscriptionsRequest { SubscriptionId = "subscription_id" }
    /// );
    /// </code></example>
    public async Task<GetSubscriptionResponse> GetAsync(
        GetSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Include != null)
        {
            _query["include"] = request.Include;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "v2/subscriptions/{0}",
                        ValueConvert.ToPathParameterString(request.SubscriptionId)
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
                return JsonUtils.Deserialize<GetSubscriptionResponse>(responseBody)!;
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
    /// Updates a subscription by modifying or clearing `subscription` field values.
    /// To clear a field, set its value to `null`.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.UpdateAsync(
    ///     new UpdateSubscriptionRequest
    ///     {
    ///         SubscriptionId = "subscription_id",
    ///         Subscription = new Subscription { CardId = "{NEW CARD ID}" },
    ///     }
    /// );
    /// </code></example>
    public async Task<UpdateSubscriptionResponse> UpdateAsync(
        UpdateSubscriptionRequest request,
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
                        "v2/subscriptions/{0}",
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
                return JsonUtils.Deserialize<UpdateSubscriptionResponse>(responseBody)!;
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
    /// Deletes a scheduled action for a subscription.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.DeleteActionAsync(
    ///     new DeleteActionSubscriptionsRequest
    ///     {
    ///         SubscriptionId = "subscription_id",
    ///         ActionId = "action_id",
    ///     }
    /// );
    /// </code></example>
    public async Task<DeleteSubscriptionActionResponse> DeleteActionAsync(
        DeleteActionSubscriptionsRequest request,
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
                        "v2/subscriptions/{0}/actions/{1}",
                        ValueConvert.ToPathParameterString(request.SubscriptionId),
                        ValueConvert.ToPathParameterString(request.ActionId)
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
                return JsonUtils.Deserialize<DeleteSubscriptionActionResponse>(responseBody)!;
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
    /// Changes the [billing anchor date](https://developer.squareup.com/docs/subscriptions-api/subscription-billing#billing-dates)
    /// for a subscription.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.ChangeBillingAnchorDateAsync(
    ///     new ChangeBillingAnchorDateRequest
    ///     {
    ///         SubscriptionId = "subscription_id",
    ///         MonthlyBillingAnchorDate = 1,
    ///     }
    /// );
    /// </code></example>
    public async Task<ChangeBillingAnchorDateResponse> ChangeBillingAnchorDateAsync(
        ChangeBillingAnchorDateRequest request,
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
                        "v2/subscriptions/{0}/billing-anchor",
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
                return JsonUtils.Deserialize<ChangeBillingAnchorDateResponse>(responseBody)!;
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
    /// Schedules a `CANCEL` action to cancel an active subscription. This
    /// sets the `canceled_date` field to the end of the active billing period. After this date,
    /// the subscription status changes from ACTIVE to CANCELED.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.CancelAsync(
    ///     new CancelSubscriptionsRequest { SubscriptionId = "subscription_id" }
    /// );
    /// </code></example>
    public async Task<CancelSubscriptionResponse> CancelAsync(
        CancelSubscriptionsRequest request,
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
                        "v2/subscriptions/{0}/cancel",
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
                return JsonUtils.Deserialize<CancelSubscriptionResponse>(responseBody)!;
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
    /// Lists all [events](https://developer.squareup.com/docs/subscriptions-api/actions-events) for a specific subscription.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.ListEventsAsync(
    ///     new ListEventsSubscriptionsRequest { SubscriptionId = "subscription_id" }
    /// );
    /// </code></example>
    public async Task<Pager<SubscriptionEvent>> ListEventsAsync(
        ListEventsSubscriptionsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (request is not null)
        {
            request = request with { };
        }
        var pager = await CursorPager<
            ListEventsSubscriptionsRequest,
            RequestOptions?,
            ListSubscriptionEventsResponse,
            string?,
            SubscriptionEvent
        >
            .CreateInstanceAsync(
                request,
                options,
                ListEventsInternalAsync,
                (request, cursor) =>
                {
                    request.Cursor = cursor;
                },
                response => response?.Cursor,
                response => response?.SubscriptionEvents?.ToList(),
                cancellationToken
            )
            .ConfigureAwait(false);
        return pager;
    }

    /// <summary>
    /// Schedules a `PAUSE` action to pause an active subscription.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.PauseAsync(
    ///     new PauseSubscriptionRequest { SubscriptionId = "subscription_id" }
    /// );
    /// </code></example>
    public async Task<PauseSubscriptionResponse> PauseAsync(
        PauseSubscriptionRequest request,
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
                        "v2/subscriptions/{0}/pause",
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
                return JsonUtils.Deserialize<PauseSubscriptionResponse>(responseBody)!;
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
    /// Schedules a `RESUME` action to resume a paused or a deactivated subscription.
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.ResumeAsync(
    ///     new ResumeSubscriptionRequest { SubscriptionId = "subscription_id" }
    /// );
    /// </code></example>
    public async Task<ResumeSubscriptionResponse> ResumeAsync(
        ResumeSubscriptionRequest request,
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
                        "v2/subscriptions/{0}/resume",
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
                return JsonUtils.Deserialize<ResumeSubscriptionResponse>(responseBody)!;
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
    /// Schedules a `SWAP_PLAN` action to swap a subscription plan variation in an existing subscription.
    /// For more information, see [Swap Subscription Plan Variations](https://developer.squareup.com/docs/subscriptions-api/swap-plan-variations).
    /// </summary>
    /// <example><code>
    /// await client.Subscriptions.SwapPlanAsync(
    ///     new SwapPlanRequest
    ///     {
    ///         SubscriptionId = "subscription_id",
    ///         NewPlanVariationId = "FQ7CDXXWSLUJRPM3GFJSJGZ7",
    ///         Phases = new List&lt;PhaseInput&gt;()
    ///         {
    ///             new PhaseInput { Ordinal = 0, OrderTemplateId = "uhhnjH9osVv3shUADwaC0b3hNxQZY" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<SwapPlanResponse> SwapPlanAsync(
        SwapPlanRequest request,
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
                        "v2/subscriptions/{0}/swap-plan",
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
                return JsonUtils.Deserialize<SwapPlanResponse>(responseBody)!;
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
