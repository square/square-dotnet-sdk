using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A record representing an individual team member for a business.
/// </summary>
public record TeamMember
{
    /// <summary>
    /// The unique ID for the team member.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// A second ID used to associate the team member with an entity in another system.
    /// </summary>
    [JsonPropertyName("reference_id")]
    public string? ReferenceId { get; set; }

    /// <summary>
    /// Whether the team member is the owner of the Square account.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("is_owner")]
    public bool? IsOwner { get; set; }

    /// <summary>
    /// Describes the status of the team member.
    /// See [TeamMemberStatus](#type-teammemberstatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public TeamMemberStatus? Status { get; set; }

    /// <summary>
    /// The given name (that is, the first name) associated with the team member.
    /// </summary>
    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    /// <summary>
    /// The family name (that is, the last name) associated with the team member.
    /// </summary>
    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

    /// <summary>
    /// The email address associated with the team member. After accepting the invitation
    /// from Square, only the team member can change this value.
    /// </summary>
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// The team member's phone number, in E.164 format. For example:
    /// +14155552671 - the country code is 1 for US
    /// +551155256325 - the country code is 55 for BR
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// The timestamp when the team member was created, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the team member was last updated, in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Describes the team member's assigned locations.
    /// </summary>
    [JsonPropertyName("assigned_locations")]
    public TeamMemberAssignedLocations? AssignedLocations { get; set; }

    /// <summary>
    /// Information about the team member's overtime exemption status, job assignments, and compensation.
    /// </summary>
    [JsonPropertyName("wage_setting")]
    public WageSetting? WageSetting { get; set; }

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
