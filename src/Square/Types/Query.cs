using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using Square.Core;

namespace Square;

[Serializable]
public record Query : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("measures")]
    public IEnumerable<string>? Measures { get; set; }

    [JsonPropertyName("dimensions")]
    public IEnumerable<string>? Dimensions { get; set; }

    [JsonPropertyName("segments")]
    public IEnumerable<string>? Segments { get; set; }

    [JsonPropertyName("timeDimensions")]
    public IEnumerable<TimeDimension>? TimeDimensions { get; set; }

    [JsonPropertyName("order")]
    public IEnumerable<IEnumerable<string>>? Order { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("offset")]
    public int? Offset { get; set; }

    [JsonPropertyName("filters")]
    public IEnumerable<
        OneOf<QueryFilterCondition, QueryFilterOr, QueryFilterAnd>
    >? Filters { get; set; }

    [JsonPropertyName("ungrouped")]
    public bool? Ungrouped { get; set; }

    [JsonPropertyName("subqueryJoins")]
    public IEnumerable<JoinSubquery>? SubqueryJoins { get; set; }

    [JsonPropertyName("joinHints")]
    public IEnumerable<IEnumerable<string>>? JoinHints { get; set; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

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
