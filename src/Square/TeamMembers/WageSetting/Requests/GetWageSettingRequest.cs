using System.Text.Json.Serialization;
using Square.Core;

namespace Square.TeamMembers.WageSetting;

public record GetWageSettingRequest
{
    /// <summary>
    /// The ID of the team member for which to retrieve the wage setting.
    /// </summary>
    [JsonIgnore]
    public required string TeamMemberId { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
