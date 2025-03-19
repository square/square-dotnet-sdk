using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Location-specific overrides for specified properties of a `CatalogModifier` object.
/// </summary>
public record ModifierLocationOverrides
{
    /// <summary>
    /// The ID of the `Location` object representing the location. This can include a deactivated location.
    /// </summary>
    [JsonPropertyName("location_id")]
    public string? LocationId { get; set; }

    /// <summary>
    /// The overridden price at the specified location. If this is unspecified, the modifier price is not overridden.
    /// The modifier becomes free of charge at the specified location, when this `price_money` field is set to 0.
    /// </summary>
    [JsonPropertyName("price_money")]
    public Money? PriceMoney { get; set; }

    /// <summary>
    /// Indicates whether the modifier is sold out at the specified location or not. As an example, for cheese (modifier) burger (item), when the modifier is sold out, it is the cheese, but not the burger, that is sold out.
    /// The seller can manually set this sold out status. Attempts by an application to set this attribute are ignored.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("sold_out")]
    public bool? SoldOut { get; set; }

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
