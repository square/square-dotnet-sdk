using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A filter based on the order `customer_id` and any tender `customer_id`
/// associated with the order. It does not filter based on the
/// [FulfillmentRecipient](entity:FulfillmentRecipient) `customer_id`.
/// </summary>
public record SearchOrdersCustomerFilter
{
    /// <summary>
    /// A list of customer IDs to filter by.
    ///
    /// Max: 10 customer ids.
    /// </summary>
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string>? CustomerIds { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
