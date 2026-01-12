using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// A range defined by two dates. Used for filtering a query for Connect v2
/// objects that have date properties.
/// </summary>
[Serializable]
public record DateRange : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
