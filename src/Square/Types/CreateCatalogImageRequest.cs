using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CreateCatalogImageRequest
{
    /// <summary>
    /// A unique string that identifies this CreateCatalogImage request.
    /// Keys can be any valid string but must be unique for every CreateCatalogImage request.
    ///
    /// See [Idempotency keys](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// Unique ID of the `CatalogObject` to attach this `CatalogImage` object to. Leave this
    /// field empty to create unattached images, for example if you are building an integration
    /// where an image can be attached to catalog items at a later time.
    /// </summary>
    [JsonPropertyName("object_id")]
    public string? ObjectId { get; set; }

    /// <summary>
    /// The new `CatalogObject` of the `IMAGE` type, namely, a `CatalogImage` object, to encapsulate the specified image file.
    /// </summary>
    [JsonPropertyName("image")]
    public required CatalogObject Image { get; set; }

    /// <summary>
    /// If this is set to `true`, the image created will be the primary, or first image of the object referenced by `object_id`.
    /// If the `CatalogObject` already has a primary `CatalogImage`, setting this field to `true` will replace the primary image.
    /// If this is set to `false` and you use the Square API version 2021-12-15 or later, the image id will be appended to the list of `image_ids` on the object.
    ///
    /// With Square API version 2021-12-15 or later, the default value is `false`. Otherwise, the effective default value is `true`.
    /// </summary>
    [JsonPropertyName("is_primary")]
    public bool? IsPrimary { get; set; }

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
