using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Orders;

[Serializable]
public record CreateOrderCustomAttributeDefinitionRequest
{
    /// <summary>
    /// The custom attribute definition to create. Note the following:
    /// - With the exception of the `Selection` data type, the `schema` is specified as a simple URL to the JSON schema
    /// definition hosted on the Square CDN. For more information, including supported values and constraints, see
    /// [Specifying the schema](https://developer.squareup.com/docs/customer-custom-attributes-api/custom-attribute-definitions#specify-schema).
    /// - If provided, `name` must be unique (case-sensitive) across all visible customer-related custom attribute definitions for the seller.
    /// - All custom attributes are visible in exported customer data, including those set to `VISIBILITY_HIDDEN`.
    /// </summary>
    [JsonPropertyName("custom_attribute_definition")]
    public required CustomAttributeDefinition CustomAttributeDefinition { get; set; }

    /// <summary>
    /// A unique identifier for this request, used to ensure idempotency.
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
