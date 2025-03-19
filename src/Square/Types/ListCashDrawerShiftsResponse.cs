using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record ListCashDrawerShiftsResponse
{
    /// <summary>
    /// Opaque cursor for fetching the next page of results. Cursor is not
    /// present in the last page of results.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// A collection of CashDrawerShiftSummary objects for shifts that match
    /// the query.
    /// </summary>
    [JsonPropertyName("cash_drawer_shifts")]
    public IEnumerable<CashDrawerShiftSummary>? CashDrawerShifts { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
