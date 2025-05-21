using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Defines sort criteria for a [SearchScheduledShifts](api-endpoint:Labor-SearchScheduledShifts)
/// request.
/// </summary>
public record ScheduledShiftSort
{
    /// <summary>
    /// The field to sort on. The default value is `START_AT`.
    /// See [ScheduledShiftSortField](#type-scheduledshiftsortfield) for possible values
    /// </summary>
    [JsonPropertyName("field")]
    public ScheduledShiftSortField? Field { get; set; }

    /// <summary>
    /// The order in which results are returned. The default value is `ASC`.
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("order")]
    public SortOrder? Order { get; set; }

    /// <summary>
    /// Additional properties received from the response, if any.
    /// </summary>
    /// <remarks>
    /// [EXPERIMENTAL] This API is experimental and may change in future releases.
    /// </remarks>
    [JsonExtensionData]
    public IDictionary<string, JsonElement> AdditionalProperties { get; internal set; } =
        new Dictionary<string, JsonElement>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
