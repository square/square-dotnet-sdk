using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Orders.CustomAttributeDefinitions;

public record UpdateOrderCustomAttributeDefinitionRequest
{
    /// <summary>
    /// The key of the custom attribute definition to update.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <summary>
    /// The custom attribute definition that contains the fields to update. This endpoint supports sparse updates,
    /// so only new or changed fields need to be included in the request.  For more information, see
    /// [Updatable definition fields](https://developer.squareup.com/docs/orders-custom-attributes-api/custom-attribute-definitions#updatable-definition-fields).
    ///
    /// To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency) control, include the optional `version` field and specify the current version of the custom attribute definition.
    /// </summary>
    [JsonPropertyName("custom_attribute_definition")]
    public required CustomAttributeDefinition CustomAttributeDefinition { get; set; }

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
