using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Team;

[Serializable]
public record ListJobsRequest
{
    /// <summary>
    /// The pagination cursor returned by the previous call to this endpoint. Provide this
    /// cursor to retrieve the next page of results for your original request. For more information,
    /// see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
    /// </summary>
    [JsonIgnore]
    public string? Cursor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
