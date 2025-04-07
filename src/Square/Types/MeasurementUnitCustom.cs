using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The information needed to define a custom unit, provided by the seller.
/// </summary>
public record MeasurementUnitCustom
{
    /// <summary>
    /// The name of the custom unit, for example "bushel".
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The abbreviation of the custom unit, such as "bsh" (bushel). This appears
    /// in the cart for the Point of Sale app, and in reports.
    /// </summary>
    [JsonPropertyName("abbreviation")]
    public required string Abbreviation { get; set; }

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
