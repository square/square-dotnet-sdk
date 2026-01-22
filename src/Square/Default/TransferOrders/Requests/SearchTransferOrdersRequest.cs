using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record SearchTransferOrdersRequest
{
    /// <summary>
    /// The search query
    /// </summary>
    [JsonPropertyName("query")]
    public TransferOrderQuery? Query { get; set; }

    /// <summary>
    /// Pagination cursor from a previous search response
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Maximum number of results to return (1-100)
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
