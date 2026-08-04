using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Webhooks.Subscriptions;

[Serializable]
public record ListSubscriptionsRequest
{
    /// <summary>
    /// A pagination cursor returned by a previous call to this endpoint.
    /// Provide this to retrieve the next set of results for your original query.
    ///
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Includes disabled [Subscription](entity:WebhookSubscription)s.
    /// By default, all enabled [Subscription](entity:WebhookSubscription)s are returned.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeDisabled { get; set; }

    /// <summary>
    /// Sorts the returned list by when the [Subscription](entity:WebhookSubscription) was created with the specified order.
    /// This field defaults to ASC.
    /// </summary>
    [JsonIgnore]
    public SortOrder? SortOrder { get; set; }

    /// <summary>
    /// The maximum number of results to be returned in a single page.
    /// It is possible to receive fewer results than the specified limit on a given page.
    /// The default value of 100 is also the maximum allowed value.
    ///
    /// Default: 100
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
