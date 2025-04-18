using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a filter used in a search for `TeamMember` objects. `AND` logic is applied
/// between the individual fields, and `OR` logic is applied within list-based fields.
/// For example, setting this filter value:
/// ```
/// filter = (locations_ids = ["A", "B"], status = ACTIVE)
/// ```
/// returns only active team members assigned to either location "A" or "B".
/// </summary>
public record SearchTeamMembersFilter
{
    /// <summary>
    /// When present, filters by team members assigned to the specified locations.
    /// When empty, includes team members assigned to any location.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// When present, filters by team members who match the given status.
    /// When empty, includes team members of all statuses.
    /// See [TeamMemberStatus](#type-teammemberstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TeamMemberStatus? Status { get; set; }

    /// <summary>
    /// When present and set to true, returns the team member who is the owner of the Square account.
    /// </summary>
    [JsonPropertyName("is_owner")]
    public bool? IsOwner { get; set; }

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
