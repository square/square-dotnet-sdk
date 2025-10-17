using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An object that represents a team member's assignment to locations.
/// </summary>
[Serializable]
public record TeamMemberAssignedLocations : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
