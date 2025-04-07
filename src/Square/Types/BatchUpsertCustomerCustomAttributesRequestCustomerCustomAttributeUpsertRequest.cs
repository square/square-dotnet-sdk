using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an individual upsert request in a [BulkUpsertCustomerCustomAttributes](api-endpoint:CustomerCustomAttributes-BulkUpsertCustomerCustomAttributes)
/// request. An individual request contains a customer ID, the custom attribute to create or update,
/// and an optional idempotency key.
/// </summary>
public record BatchUpsertCustomerCustomAttributesRequestCustomerCustomAttributeUpsertRequest
{
    /// <summary>
    /// The ID of the target [customer profile](entity:Customer).
    /// </summary>
    [JsonPropertyName("customer_id")]
    public required string CustomerId { get; set; }

    /// <summary>
    /// The custom attribute to create or update, with following fields:
    ///
    /// - `key`. This key must match the `key` of a custom attribute definition in the Square seller
    /// account. If the requesting application is not the definition owner, you must provide the qualified key.
    ///
    /// - `value`. This value must conform to the `schema` specified by the definition.
    /// For more information, see [Value data types](https://developer.squareup.com/docs/customer-custom-attributes-api/custom-attributes#value-data-types).
    ///
    /// - `version`. To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control for update operations, include this optional field in the request and set the
    /// value to the current version of the custom attribute.
    /// </summary>
    [JsonPropertyName("custom_attribute")]
    public required CustomAttribute CustomAttribute { get; set; }

    /// <summary>
    /// A unique identifier for this individual upsert request, used to ensure idempotency.
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

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
