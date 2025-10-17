using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Labor.BreakTypes;

[Serializable]
public record ListBreakTypesRequest
{
    /// <summary>
    /// Filter the returned `BreakType` results to only those that are associated with the
    /// specified location.
    /// </summary>
    [JsonIgnore]
    public string? LocationId { get; set; }

    /// <summary>
    /// The maximum number of `BreakType` results to return per page. The number can range between 1
    /// and 200. The default is 200.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// A pointer to the next page of `BreakType` results to fetch.
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
