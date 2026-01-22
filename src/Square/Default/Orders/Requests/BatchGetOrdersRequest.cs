using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record BatchGetOrdersRequest
{
    /// <summary>
    /// The ID of the location for these orders. This field is optional: omit it to retrieve
    /// orders within the scope of the current authorization's merchant ID.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The IDs of the orders to retrieve. A maximum of 100 orders can be retrieved per request.
    /// </summary>
    [JsonPropertyName("order_ids")]
    public IEnumerable<string> OrderIds { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
