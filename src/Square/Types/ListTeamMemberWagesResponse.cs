using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The response to a request for a set of `TeamMemberWage` objects. The response contains
/// a set of `TeamMemberWage` objects.
/// </summary>
public record ListTeamMemberWagesResponse
{
    /// <summary>
    /// A page of `TeamMemberWage` results.
    /// </summary>
    [JsonPropertyName("team_member_wages")]
    public IEnumerable<TeamMemberWage>? TeamMemberWages { get; set; }

    /// <summary>
    /// The value supplied in the subsequent request to fetch the next page
    /// of `TeamMemberWage` results.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; }

    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
