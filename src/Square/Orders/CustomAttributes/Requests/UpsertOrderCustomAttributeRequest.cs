using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Orders.CustomAttributes;

public record UpsertOrderCustomAttributeRequest
{
    /// <summary>
    /// The ID of the target [order](entity:Order).
    /// </summary>
    [JsonIgnore]
    public required string OrderId { get; set; }

    /// <summary>
    /// The key of the custom attribute to create or update.  This key must match the key
    /// of an existing custom attribute definition.
    /// </summary>
    [JsonIgnore]
    public required string CustomAttributeKey { get; set; }

    /// <summary>
    /// The custom attribute to create or update, with the following fields:
    ///
    /// - `value`. This value must conform to the `schema` specified by the definition.
    /// For more information, see [Value data types](https://developer.squareup.com/docs/customer-custom-attributes-api/custom-attributes#value-data-types).
    ///
    /// - `version`. To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control, include this optional field and specify the current version of the custom attribute.
    /// </summary>
    [JsonPropertyName("custom_attribute")]
    public required CustomAttribute CustomAttribute { get; set; }

    /// <summary>
    /// A unique identifier for this request, used to ensure idempotency.
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
