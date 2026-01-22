using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record CloneOrderRequest
{
    /// <summary>
    /// The ID of the order to clone.
    /// </summary>
    [JsonPropertyName("order_id")]
    public required string OrderId { get; set; }

    /// <summary>
    /// An optional order version for concurrency protection.
    ///
    /// If a version is provided, it must match the latest stored version of the order to clone.
    /// If a version is not provided, the API clones the latest version.
    /// </summary>
    [JsonPropertyName("version")]
    public int? Version { get; set; }

    /// <summary>
    /// A value you specify that uniquely identifies this clone request.
    ///
    /// If you are unsure whether a particular order was cloned successfully,
    /// you can reattempt the call with the same idempotency key without
    /// worrying about creating duplicate cloned orders.
    /// The originally cloned order is returned.
    ///
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
