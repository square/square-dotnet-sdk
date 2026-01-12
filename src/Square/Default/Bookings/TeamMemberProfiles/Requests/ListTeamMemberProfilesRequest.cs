using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Bookings.TeamMemberProfiles;

[Serializable]
public record ListTeamMemberProfilesRequest
{
    /// <summary>
    /// Indicates whether to include only bookable team members in the returned result (`true`) or not (`false`).
    /// </summary>
    [JsonIgnore]
    public bool? BookableOnly { get; set; }

    /// <summary>
    /// The maximum number of results to return in a paged response.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The pagination cursor from the preceding response to return the next page of the results. Do not set this when retrieving the first page of the results.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <summary>
    /// Indicates whether to include only team members enabled at the given location in the returned result.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
