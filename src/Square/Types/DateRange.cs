using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// A range defined by two dates. Used for filtering a query for Connect v2
/// objects that have date properties.
/// </summary>
public record DateRange
{
    /// <summary>
    /// A string in `YYYY-MM-DD` format, such as `2017-10-31`, per the ISO 8601
    /// extended format for calendar dates.
    /// The beginning of a date range (inclusive).
    /// </summary>
    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    /// <summary>
    /// A string in `YYYY-MM-DD` format, such as `2017-10-31`, per the ISO 8601
    /// extended format for calendar dates.
    /// The end of a date range (inclusive).
    /// </summary>
    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

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
