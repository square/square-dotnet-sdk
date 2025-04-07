using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record ListCashDrawerShiftEventsResponse
{
    /// <summary>
    /// Opaque cursor for fetching the next page. Cursor is not present in
    /// the last page of results.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// All of the events (payments, refunds, etc.) for a cash drawer during
    /// the shift.
    /// </summary>
    [JsonPropertyName("cash_drawer_shift_events")]
    public IEnumerable<CashDrawerShiftEvent>? CashDrawerShiftEvents { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
