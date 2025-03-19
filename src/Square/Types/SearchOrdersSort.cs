using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Sorting criteria for a `SearchOrders` request. Results can only be sorted
/// by a timestamp field.
/// </summary>
public record SearchOrdersSort
{
    /// <summary>
    /// The field to sort by.
    ///
    /// __Important:__ When using a [DateTimeFilter](entity:SearchOrdersFilter),
    /// `sort_field` must match the timestamp field that the `DateTimeFilter` uses to
    /// filter. For example, if you set your `sort_field` to `CLOSED_AT` and you use a
    /// `DateTimeFilter`, your `DateTimeFilter` must filter for orders by their `CLOSED_AT` date.
    /// If this field does not match the timestamp field in `DateTimeFilter`,
    /// `SearchOrders` returns an error.
    ///
    /// Default: `CREATED_AT`.
    /// See [SearchOrdersSortField](#type-searchorderssortfield) for possible values
    /// </summary>
    [JsonPropertyName("sort_field")]
    public required SearchOrdersSortField SortField { get; set; }

    /// <summary>
    /// The chronological order in which results are returned. Defaults to `DESC`.
    /// See [SortOrder](#type-sortorder) for possible values
    /// </summary>
    [JsonPropertyName("sort_order")]
    public SortOrder? SortOrder { get; set; }

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
