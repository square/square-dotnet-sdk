using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Bookings.CustomAttributeDefinitions;

public record UpdateBookingCustomAttributeDefinitionRequest
{
    /// <summary>
    /// The key of the custom attribute definition to update.
    /// </summary>
    [JsonIgnore]
    public required string Key { get; set; }

    /// <summary>
    /// The custom attribute definition that contains the fields to update. Only the following fields can be updated:
    /// - `name`
    /// - `description`
    /// - `visibility`
    /// - `schema` for a `Selection` data type. Only changes to the named options or the maximum number of allowed
    /// selections are supported.
    ///
    /// For more information, see
    /// [Updatable definition fields](https://developer.squareup.com/docs/booking-custom-attributes-api/custom-attribute-definitions#updatable-definition-fields).
    ///
    /// To enable [optimistic concurrency](https://developer.squareup.com/docs/build-basics/common-api-patterns/optimistic-concurrency)
    /// control, include the optional `version` field and specify the current version of the custom attribute definition.
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
