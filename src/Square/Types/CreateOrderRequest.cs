using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[Serializable]
public record CreateOrderRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
