using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response from a bulk create request containing the created `TeamMember` objects or error messages.
/// </summary>
public record BatchCreateTeamMembersResponse
{
    /// <summary>
    /// The successfully created `TeamMember` objects. Each key is the `idempotency_key` that maps to the `CreateTeamMemberRequest`.
    /// </summary>
    [JsonPropertyName("team_members")]
    public Dictionary<string, CreateTeamMemberResponse>? TeamMembers { get; set; }

    /// <summary>
    /// The errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

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
