using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Bookings;

[Serializable]
public record ListBookingsRequest
{
    /// <summary>
    /// The maximum number of results per page to return in a paged response.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// The [customer](entity:Customer) for whom to retrieve bookings. If this is not set, bookings for all customers are retrieved.
    /// </summary>
    [JsonIgnore]
    public string? CustomerId { get; set; }

    /// <summary>
    /// The team member for whom to retrieve bookings. If this is not set, bookings of all members are retrieved.
    /// </summary>
    [JsonIgnore]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// The location for which to retrieve bookings. If this is not set, all locations' bookings are retrieved.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <summary>
    /// The RFC 3339 timestamp specifying the earliest of the start time. If this is not set, the current time is used.
    /// </summary>
    [JsonIgnore]
    public string? StartAtMin { get; set; }

    /// <summary>
    /// The RFC 3339 timestamp specifying the latest of the start time. If this is not set, the time of 31 days after `start_at_min` is used.
    /// </summary>
    [JsonIgnore]
    public string? StartAtMax { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
