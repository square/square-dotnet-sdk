using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record BatchChangeInventoryRequest
{
    /// <summary>
    /// A client-supplied, universally unique identifier (UUID) for the
    /// request.
    ///
    /// See [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency) in the
    /// [API Development 101](https://developer.squareup.com/docs/buildbasics) section for more
    /// information.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public required string IdempotencyKey { get; set; }

    /// <summary>
    /// The set of physical counts and inventory adjustments to be made.
    /// Changes are applied based on the client-supplied timestamp and may be sent
    /// out of order.
    /// </summary>
    [JsonPropertyName("changes")]
    public IEnumerable<InventoryChange>? Changes { get; set; }

    /// <summary>
    /// Indicates whether the current physical count should be ignored if
    /// the quantity is unchanged since the last physical count. Default: `true`.
    /// </summary>
    [JsonPropertyName("ignore_unchanged_counts")]
    public bool? IgnoreUnchangedCounts { get; set; }

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
