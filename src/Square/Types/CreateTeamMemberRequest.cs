using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Represents a create request for a `TeamMember` object.
/// </summary>
public record CreateTeamMemberRequest
{
    /// <summary>
    /// A unique string that identifies this `CreateTeamMember` request.
    /// Keys can be any valid string, but must be unique for every request.
    /// For more information, see [Idempotency](https://developer.squareup.com/docs/build-basics/common-api-patterns/idempotency).
    ///
    /// The minimum length is 1 and the maximum length is 45.
    /// </summary>
    [JsonPropertyName("idempotency_key")]
    public string? IdempotencyKey { get; set; }

    /// <summary>
    /// **Required** The data used to create the `TeamMember` object. If you include `wage_setting`, you must provide
    /// `job_id` for each job assignment. To get job IDs, call [ListJobs](api-endpoint:Team-ListJobs).
    /// </summary>
    [JsonPropertyName("team_member")]
    public TeamMember? TeamMember { get; set; }

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
