using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents scheduling information that determines when purchases can qualify to earn points
/// from a [loyalty promotion](entity:LoyaltyPromotion).
/// </summary>
public record LoyaltyPromotionAvailableTimeData
{
    /// <summary>
    /// The date that the promotion starts, in `YYYY-MM-DD` format. Square populates this field
    /// based on the provided `time_periods`.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    /// <summary>
    /// The date that the promotion ends, in `YYYY-MM-DD` format. Square populates this field
    /// based on the provided `time_periods`. If an end date is not specified, an `ACTIVE` promotion
    /// remains available until it is canceled.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    /// <summary>
    /// A list of [iCalendar (RFC 5545) events](https://tools.ietf.org/html/rfc5545#section-3.6.1)
    /// (`VEVENT`). Each event represents an available time period per day or days of the week.
    /// A day can have a maximum of one available time period.
    ///
    /// Only `DTSTART`, `DURATION`, and `RRULE` are supported. `DTSTART` and `DURATION` are required and
    /// timestamps must be in local (unzoned) time format. Include `RRULE` to specify recurring promotions,
    /// an end date (using the `UNTIL` keyword), or both. For more information, see
    /// [Available time](https://developer.squareup.com/docs/loyalty-api/loyalty-promotions#available-time).
    ///
    /// Note that `BEGIN:VEVENT` and `END:VEVENT` are optional in a `CreateLoyaltyPromotion` request
    /// but are always included in the response.
    /// </summary>
    [JsonPropertyName("time_periods")]
    public IEnumerable<string> TimePeriods { get; set; } = new List<string>();

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
