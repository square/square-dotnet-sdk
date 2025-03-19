using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Merchants.CustomAttributes;

public record UpsertMerchantCustomAttributeRequest
{
    /// <summary>
    /// The ID of the target [merchant](entity:Merchant).
    /// </summary>
    [JsonIgnore]
    public required string MerchantId { get; set; }

    /// <summary>
    /// The key of the custom attribute to create or update. This key must match the `key` of a
    /// custom attribute definition in the Square seller account. If the requesting application is not
    /// the definition owner, you must use the qualified key.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <summary>
    /// The custom attribute to create or update, with the following fields:
    /// - `value`. This value must conform to the `schema` specified by the definition.
    /// For more information, see [Supported data types](https://developer.squareup.com/docs/devtools/customattributes/overview#supported-data-types).
    /// - The version field must match the current version of the custom attribute definition to enable
    /// [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// If this is not important for your application, version can be set to -1. For any other values, the request fails with a BAD_REQUEST error.
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
