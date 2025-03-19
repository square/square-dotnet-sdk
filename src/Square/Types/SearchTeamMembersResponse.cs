using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a response from a search request containing a filtered list of `TeamMember` objects.
/// </summary>
public record SearchTeamMembersResponse
{
    /// <summary>
    /// The filtered list of `TeamMember` objects.
    /// </summary>
    [JsonPropertyName("team_members")]
    public IEnumerable<TeamMember>? TeamMembers { get; set; }

    /// <summary>
    /// The opaque cursor for fetching the next page. For more information, see
    /// [pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

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
