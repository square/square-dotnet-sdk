using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Bookings.LocationProfiles;

public record ListLocationProfilesRequest
{
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

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
