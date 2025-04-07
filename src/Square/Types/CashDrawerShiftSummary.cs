using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The summary of a closed cash drawer shift.
/// This model contains only the money counted to start a cash drawer shift, counted
/// at the end of the shift, and the amount that should be in the drawer at shift
/// end based on summing all cash drawer shift events.
/// </summary>
public record CashDrawerShiftSummary
{
    /// <summary>
    /// The shift unique ID.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The shift current state.
    /// See [CashDrawerShiftState](#type-cashdrawershiftstate) for possible values
    /// </summary>
    [JsonPropertyName("state")]
    public CashDrawerShiftState? State { get; set; }

    /// <summary>
    /// The shift start time in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("opened_at")]
    public string? OpenedAt { get; set; }

    /// <summary>
    /// The shift end time in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("ended_at")]
    public string? EndedAt { get; set; }

    /// <summary>
    /// The shift close time in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("closed_at")]
    public string? ClosedAt { get; set; }

    /// <summary>
    /// An employee free-text description of a cash drawer shift.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The amount of money in the cash drawer at the start of the shift. This
    /// must be a positive amount.
    /// </summary>
    [JsonPropertyName("opened_cash_money")]
    public Money? OpenedCashMoney { get; set; }

    /// <summary>
    /// The amount of money that should be in the cash drawer at the end of the
    /// shift, based on the cash drawer events on the shift.
    /// The amount is correct if all shift employees accurately recorded their
    /// cash drawer shift events. Unrecorded events and events with the wrong amount
    /// result in an incorrect expected_cash_money amount that can be negative.
    /// </summary>
    [JsonPropertyName("expected_cash_money")]
    public Money? ExpectedCashMoney { get; set; }

    /// <summary>
    /// The amount of money found in the cash drawer at the end of the shift by
    /// an auditing employee. The amount must be greater than or equal to zero.
    /// </summary>
    [JsonPropertyName("closed_cash_money")]
    public Money? ClosedCashMoney { get; set; }

    /// <summary>
    /// The shift start time in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The shift updated at time in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// The ID of the location the cash drawer shift belongs to.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

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
