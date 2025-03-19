using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor.TeamMemberWages;

public record GetTeamMemberWagesRequest
{
    /// <summary>
    /// The UUID for the `TeamMemberWage` being retrieved.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
