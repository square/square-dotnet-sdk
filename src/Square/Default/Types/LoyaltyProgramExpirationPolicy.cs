using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// Describes when the loyalty program expires.
/// </summary>
[Serializable]
public record LoyaltyProgramExpirationPolicy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The number of months before points expire, in `P[n]M` RFC 3339 duration format. For example, a value of `P12M` represents a duration of 12 months.
    /// Points are valid through the last day of the month in which they are scheduled to expire. For example, with a  `P12M` duration, points earned on July 6, 2020 expire on August 1, 2021.
    /// </summary>
    [JsonPropertyName("expiration_duration")]
    public required string ExpirationDuration { get; set; }

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
