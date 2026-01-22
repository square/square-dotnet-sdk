using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record BulkDeleteCustomersRequest
{
    /// <summary>
    /// The IDs of the [customer profiles](entity:Customer) to delete.
    /// </summary>
    [JsonPropertyName("customer_ids")]
    public IEnumerable<string> CustomerIds { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
