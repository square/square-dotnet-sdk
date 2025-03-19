using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

public record CatalogInfoResponse
{
    /// <summary>
    /// Any errors that occurred during the request.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<Error>? Errors { get; set; }

    /// <summary>
    /// Limits that apply to this API.
    /// </summary>
    [JsonPropertyName("limits")]
    public CatalogInfoResponseLimits? Limits { get; set; }

    /// <summary>
    /// Names and abbreviations for standard units.
    /// </summary>
    [JsonPropertyName("standard_unit_description_group")]
    public StandardUnitDescriptionGroup? StandardUnitDescriptionGroup { get; set; }

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
