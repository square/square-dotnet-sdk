using System.Text.Json.Serialization;
using Square.Core;
using Square.Default;

namespace Square.Default.TeamMembers;

[Serializable]
public record SearchTeamMembersRequest
{
    /// <summary>
    /// The query parameters.
    /// </summary>
    [JsonPropertyName("query")]
    public SearchTeamMembersQuery? Query { get; set; }

    /// <summary>
    /// The maximum number of `TeamMember` objects in a page (100 by default).
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// The opaque cursor for fetching the next page. For more information, see
    /// [pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
