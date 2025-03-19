using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Customers.CustomAttributes;

public record UpsertCustomerCustomAttributeRequest
{
    /// <summary>
    /// The ID of the target [customer profile](entity:Customer).
    /// </summary>
    [JsonIgnore]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The key of the custom attribute to create or update. This key must match the `key` of a
    /// custom attribute definition in the Square seller account. If the requesting application is not
    /// the definition owner, you must use the qualified key.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <summary>
    /// The custom attribute to create or update, with the following fields:
    ///
    /// - `value`. This value must conform to the `schema` specified by the definition.
    /// For more information, see [Value data types](https://developer.squareup.com/docs/customer-custom-attributes-api/custom-attributes#value-data-types).
    ///
    /// - `version`. To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control for an update operation, include this optional field and specify the current version
    /// of the custom attribute.
    /// </summary>
    [JsonPropertyName("custom_attribute")]
    public required CustomAttribute CustomAttribute { get; set; }

    /// <summary>
    /// A unique identifier for this request, used to ensure idempotency. For more information,
    /// see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
