using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that represents a team member's assignment to locations.
/// </summary>
public record TeamMemberAssignedLocations
{
    /// <summary>
    /// The current assignment type of the team member.
    /// See [TeamMemberAssignedLocationsAssignmentType](#type-teammemberassignedlocationsassignmenttype) for possible values
    /// </summary>
    [JsonPropertyName("assignment_type")]
    public TeamMemberAssignedLocationsAssignmentType? AssignmentType { get; set; }

    /// <summary>
    /// The explicit locations that the team member is assigned to.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
