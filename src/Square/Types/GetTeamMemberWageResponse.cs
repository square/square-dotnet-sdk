using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A response to a request to get a `TeamMemberWage`. The response contains
/// the requested `TeamMemberWage` objects and might contain a set of `Error` objects if
/// the request resulted in errors.
/// </summary>
public record GetTeamMemberWageResponse
{
    /// <summary>
    /// The requested `TeamMemberWage` object.
    /// </summary>
    [JsonPropertyName("team_member_wage")]
    public TeamMemberWage? TeamMemberWage { get; set; }

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
