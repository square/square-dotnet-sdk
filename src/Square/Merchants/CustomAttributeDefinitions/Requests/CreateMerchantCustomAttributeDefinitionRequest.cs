using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Merchants.CustomAttributeDefinitions;

[Serializable]
public record CreateMerchantCustomAttributeDefinitionRequest
{
    /// <summary>
    /// The custom attribute definition to create. Note the following:
    /// - With the exception of the `Selection` data type, the `schema` is specified as a simple URL to the JSON schema
    /// definition hosted on the Square CDN. For more information, including supported values and constraints, see
    /// [Supported data types](https://developer.squareup.com/docs/devtools/customattributes/overview#supported-data-types).
    /// - `name` is required unless `visibility` is set to `VISIBILITY_HIDDEN`.
    /// </summary>
    [JsonPropertyName("custom_attribute_definition")]
    public required CustomAttributeDefinition CustomAttributeDefinition { get; set; }

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
