using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Either the `order_entries` or `orders` field is set, depending on whether
/// `return_entries` is set on the [SearchOrdersRequest](api-endpoint:Orders-SearchOrders).
/// </summary>
[Serializable]
public record SearchOrdersResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A list of [OrderEntries](entity:OrderEntry) that fit the query
    /// conditions. The list is populated only if `return_entries` is set to `true` in the request.
    /// </summary>
    [JsonPropertyName("order_entries")]
    public IEnumerable<OrderEntry>? OrderEntries { get; set; }

    /// <summary>
    /// A list of
    /// [Order](entity:Order) objects that match the query conditions. The list is populated only if
    /// `return_entries` is set to `false` in the request.
    /// </summary>
    [JsonPropertyName("orders")]
    public IEnumerable<Order>? Orders { get; set; }

    /// <summary>
    /// The pagination cursor to be used in a subsequent request. If unset,
    /// this is the final response.
    /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// [Errors](entity:Error) encountered during the search.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
