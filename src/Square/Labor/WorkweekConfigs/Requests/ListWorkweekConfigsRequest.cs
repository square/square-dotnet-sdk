using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor.WorkweekConfigs;

public record ListWorkweekConfigsRequest
{
    /// <summary>
    /// The maximum number of `WorkweekConfigs` results to return per page.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// A pointer to the next page of `WorkweekConfig` results to fetch.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
