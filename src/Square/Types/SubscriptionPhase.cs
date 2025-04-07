using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes a phase in a subscription plan variation. For more information, see [Subscription Plans and Variations](https://developer.squareup.com/docs/subscriptions-api/plans-and-variations).
/// </summary>
public record SubscriptionPhase
{
    /// <summary>
    /// The Square-assigned ID of the subscription phase. This field cannot be changed after a `SubscriptionPhase` is created.
    /// </summary>
    [JsonPropertyName("uid")]
    public string? Uid { get; set; }

    /// <summary>
    /// The billing cadence of the phase. For example, weekly or monthly. This field cannot be changed after a `SubscriptionPhase` is created.
    /// See [SubscriptionCadence](#type-subscriptioncadence) for possible values
    /// </summary>
    [JsonPropertyName("cadence")]
    public required SubscriptionCadence Cadence { get; set; }

    /// <summary>
    /// The number of `cadence`s the phase lasts. If not set, the phase never ends. Only the last phase can be indefinite. This field cannot be changed after a `SubscriptionPhase` is created.
    /// </summary>
    [JsonPropertyName("periods")]
    public int? Periods { get; set; }

    /// <summary>
    /// The amount to bill for each `cadence`. Failure to specify this field results in a `MISSING_REQUIRED_PARAMETER` error at runtime.
    /// </summary>
    [JsonPropertyName("recurring_price_money")]
    public Money? RecurringPriceMoney { get; set; }

    /// <summary>
    /// The position this phase appears in the sequence of phases defined for the plan, indexed from 0. This field cannot be changed after a `SubscriptionPhase` is created.
    /// </summary>
    [JsonPropertyName("ordinal")]
    public long? Ordinal { get; set; }

    /// <summary>
    /// The subscription pricing.
    /// </summary>
    [JsonPropertyName("pricing")]
    public SubscriptionPricing? Pricing { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
