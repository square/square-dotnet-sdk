using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// This model gives the details of a cash drawer shift.
/// The cash_payment_money, cash_refund_money, cash_paid_in_money,
/// and cash_paid_out_money fields are all computed by summing their respective
/// event types.
/// </summary>
public record CashDrawerShift
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
    /// The time when the shift began, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("opened_at")]
    public string? OpenedAt { get; set; }

    /// <summary>
    /// The time when the shift ended, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("ended_at")]
    public string? EndedAt { get; set; }

    /// <summary>
    /// The time when the shift was closed, in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("closed_at")]
    public string? ClosedAt { get; set; }

    /// <summary>
    /// The free-form text description of a cash drawer by an employee.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The amount of money in the cash drawer at the start of the shift.
    /// The amount must be greater than or equal to zero.
    /// </summary>
    [JsonPropertyName("opened_cash_money")]
    public Money? OpenedCashMoney { get; set; }

    /// <summary>
    /// The amount of money added to the cash drawer from cash payments.
    /// This is computed by summing all events with the types CASH_TENDER_PAYMENT and
    /// CASH_TENDER_CANCELED_PAYMENT. The amount is always greater than or equal to
    /// zero.
    /// </summary>
    [JsonPropertyName("cash_payment_money")]
    public Money? CashPaymentMoney { get; set; }

    /// <summary>
    /// The amount of money removed from the cash drawer from cash refunds.
    /// It is computed by summing the events of type CASH_TENDER_REFUND. The amount
    /// is always greater than or equal to zero.
    /// </summary>
    [JsonPropertyName("cash_refunds_money")]
    public Money? CashRefundsMoney { get; set; }

    /// <summary>
    /// The amount of money added to the cash drawer for reasons other than cash
    /// payments. It is computed by summing the events of type PAID_IN. The amount is
    /// always greater than or equal to zero.
    /// </summary>
    [JsonPropertyName("cash_paid_in_money")]
    public Money? CashPaidInMoney { get; set; }

    /// <summary>
    /// The amount of money removed from the cash drawer for reasons other than
    /// cash refunds. It is computed by summing the events of type PAID_OUT. The amount
    /// is always greater than or equal to zero.
    /// </summary>
    [JsonPropertyName("cash_paid_out_money")]
    public Money? CashPaidOutMoney { get; set; }

    /// <summary>
    /// The amount of money that should be in the cash drawer at the end of the
    /// shift, based on the shift's other money amounts.
    /// This can be negative if employees have not correctly recorded all the events
    /// on the cash drawer.
    /// cash_paid_out_money is a summation of amounts from cash_payment_money (zero
    /// or positive), cash_refunds_money (zero or negative), cash_paid_in_money (zero
    /// or positive), and cash_paid_out_money (zero or negative) event types.
    /// </summary>
    [JsonPropertyName("expected_cash_money")]
    public Money? ExpectedCashMoney { get; set; }

    /// <summary>
    /// The amount of money found in the cash drawer at the end of the shift
    /// by an auditing employee. The amount should be positive.
    /// </summary>
    [JsonPropertyName("closed_cash_money")]
    public Money? ClosedCashMoney { get; set; }

    /// <summary>
    /// The device running Square Point of Sale that was connected to the cash drawer.
    /// </summary>
    [JsonPropertyName("device")]
    public CashDrawerDevice? Device { get; set; }

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
    /// The IDs of all team members that were logged into Square Point of Sale at any
    /// point while the cash drawer shift was open.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("team_member_ids")]
    public IEnumerable<string>? TeamMemberIds { get; set; }

    /// <summary>
    /// The ID of the team member that started the cash drawer shift.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("opening_team_member_id")]
    public string? OpeningTeamMemberId { get; set; }

    /// <summary>
    /// The ID of the team member that ended the cash drawer shift.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("ending_team_member_id")]
    public string? EndingTeamMemberId { get; set; }

    /// <summary>
    /// The ID of the team member that closed the cash drawer shift by auditing
    /// the cash drawer contents.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("closing_team_member_id")]
    public string? ClosingTeamMemberId { get; set; }

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
