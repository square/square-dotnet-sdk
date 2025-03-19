using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CreateOrderRequest
{
    /// <summary>
    /// The order to create. If this field is set, the only other top-level field that can be
    /// set is the `idempotency_key`.
    /// </summary>
    [JsonPropertyName("order")]
    public Order? Order { get; set; }

    /// <summary>
    /// A value you specify that uniquely identifies this
    /// order among orders you have created.
    ///
    /// If you are unsure whether a particular order was created successfully,
    /// you can try it again with the same idempotency key without
    /// worrying about creating duplicate orders.
    ///
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
