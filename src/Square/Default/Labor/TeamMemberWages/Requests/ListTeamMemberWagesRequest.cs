using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default.Labor.TeamMemberWages;

[Serializable]
public record ListTeamMemberWagesRequest
{
    /// <summary>
    /// Filter the returned wages to only those that are associated with the
    /// specified team member.
    /// </summary>
    [JsonIgnore]
    public string? TeamMemberId { get; set; }

    /// <summary>
    /// The maximum number of `TeamMemberWage` results to return per page. The number can range between
    /// 1 and 200. The default is 200.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// A pointer to the next page of `EmployeeWage` results to fetch.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
