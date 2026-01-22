using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record V1RetrieveOrderRequest
{
    /// <summary>
    /// The ID of the order's associated location.
    /// </summary>
    [JsonIgnore]
    public required string LocationId { get; set; }

    /// <summary>
    /// The order's Square-issued ID. You obtain this value from Order objects returned by the List Orders endpoint
    /// </summary>
    [JsonIgnore]
    public required string OrderId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
