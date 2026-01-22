using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.Catalog;

[Serializable]
public record UpsertCatalogObjectRequest
{
    /// <summary>
    /// A value you specify that uniquely identifies this
    /// request among all your requests. A common way to create
    /// a valid idempotency key is to use a Universally unique
    /// identifier (UUID).
    ///
    /// If you're unsure whether a particular request was successful,
    /// you can reattempt it with the same idempotency key without
    /// worrying about creating duplicate objects.
    ///
    /// See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) for more information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// A CatalogObject to be created or updated.
    ///
    /// - For updates, the object must be active (the `is_deleted` field is not `true`).
    /// - For creates, the object ID must start with `#`. The provided ID is replaced with a server-generated ID.
    /// </summary>
    [JsonPropertyName("object")]
    public required CatalogObject Object { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
