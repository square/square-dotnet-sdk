using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Filter by the current order `state`.
/// </summary>
public record SearchOrdersStateFilter
{
    /// <summary>
    /// States to filter for.
    /// See [OrderState](#type-orderstate) for possible values
    /// </summary>
    [JsonPropertyName("states")]
    public IEnumerable<OrderState> States { get; set; } = new List<OrderState>();

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
