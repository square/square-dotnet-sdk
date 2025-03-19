using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Employees;

public record GetEmployeesRequest
{
    /// <summary>
    /// UUID for the employee that was requested.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
