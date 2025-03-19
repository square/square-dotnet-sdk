using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents an individual upsert request in a [BulkUpsertMerchantCustomAttributes](api-endpoint:MerchantCustomAttributes-BulkUpsertMerchantCustomAttributes)
/// request. An individual request contains a merchant ID, the custom attribute to create or update,
/// and an optional idempotency key.
/// </summary>
public record BulkUpsertMerchantCustomAttributesRequestMerchantCustomAttributeUpsertRequest
{
    /// <summary>
    /// The ID of the target [merchant](entity:Merchant).
    /// </summary>
    [JsonPropertyName("merchant_id")]
    public required string MerchantId { get; set; }

    /// <summary>
    /// The custom attribute to create or update, with following fields:
    /// - `key`. This key must match the `key` of a custom attribute definition in the Square seller
    /// account. If the requesting application is not the definition owner, you must provide the qualified key.
    /// - `value`. This value must conform to the `schema` specified by the definition.
    /// For more information, see [Supported data types](https://developer.squareup.com/docs/devtools/customattributes/overview#supported-data-types).
    /// - The version field must match the current version of the custom attribute definition to enable
    /// [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// If this is not important for your application, version can be set to -1. For any other values, the request fails with a BAD_REQUEST error.
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
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
