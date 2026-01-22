using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[Serializable]
public record ListEmployeesRequest
{
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <summary>
    /// Specifies the EmployeeStatus to filter the employee by.
    /// </summary>
    [JsonIgnore]
    public EmployeeStatus? Status { get; set; }

    /// <summary>
    /// The number of employees to be returned on each page.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// The token required to retrieve the specified page of results.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
