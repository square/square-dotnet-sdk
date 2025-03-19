using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor.EmployeeWages;

public record GetEmployeeWagesRequest
{
    /// <summary>
    /// The UUID for the `EmployeeWage` being retrieved.
    /// </summary>
    [JsonIgnore]
    public required string Id { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
