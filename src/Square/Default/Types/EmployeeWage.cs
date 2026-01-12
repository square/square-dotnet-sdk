using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The hourly wage rate that an employee earns on a `Shift` for doing the job specified by the `title` property of this object. Deprecated at version 2020-08-26. Use [TeamMemberWage](entity:TeamMemberWage).
/// </summary>
[Serializable]
public record EmployeeWage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The UUID for this object.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The `Employee` that this wage is assigned to.
    /// </summary>
    [JsonPropertyName("employee_id")]
    public string? EmployeeId { get; set; }

    /// <summary>
    /// The job title that this wage relates to.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// Can be a custom-set hourly wage or the calculated effective hourly
    /// wage based on the annual wage and hours worked per week.
    /// </summary>
    [JsonPropertyName("hourly_rate")]
    public Money? HourlyRate { get; set; }

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
