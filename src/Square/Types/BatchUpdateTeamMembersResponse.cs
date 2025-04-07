using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response from a bulk update request containing the updated `TeamMember` objects or error messages.
/// </summary>
public record BatchUpdateTeamMembersResponse
{
    /// <summary>
    /// The successfully updated `TeamMember` objects. Each key is the `team_member_id` that maps to the `UpdateTeamMemberRequest`.
    /// </summary>
    [JsonPropertyName("team_members")]
    public Dictionary<string, UpdateTeamMemberResponse>? TeamMembers { get; set; }

    /// <summary>
    /// The errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
