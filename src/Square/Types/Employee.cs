using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// An employee object that is used by the external API.
///
/// DEPRECATED at version 2020-08-26. Replaced by [TeamMember](entity:TeamMember).
/// </summary>
public record Employee
{
    /// <summary>
    /// UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The employee's first name.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The employee's last name.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    /// <summary>
    /// The employee's email address
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The employee's phone number in E.164 format, i.e. "+12125554250"
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// A list of location IDs where this employee has access to.
    /// </summary>
    [JsonPropertyName("location_ids")]
    public IEnumerable<string>? LocationIds { get; set; }

    /// <summary>
    /// Specifies the status of the employees being fetched.
    /// See [EmployeeStatus](#type-employeestatus) for possible values
    /// </summary>
    [JsonPropertyName("status")]
    public EmployeeStatus? Status { get; set; }

    /// <summary>
    /// Whether this employee is the owner of the merchant. Each merchant
    /// has one owner employee, and that employee has full authority over
    /// the account.
    /// </summary>
    [JsonPropertyName("is_owner")]
    public bool? IsOwner { get; set; }

    /// <summary>
    /// A read-only timestamp in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// A read-only timestamp in RFC 3339 format.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

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
