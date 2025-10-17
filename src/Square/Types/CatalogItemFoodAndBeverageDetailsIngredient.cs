using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Describes the ingredient used in a `FOOD_AND_BEV` item.
/// </summary>
[Serializable]
public record CatalogItemFoodAndBeverageDetailsIngredient : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The dietary preference type of the ingredient. Supported values include `STANDARD` and `CUSTOM` as specified in `FoodAndBeverageDetails.DietaryPreferenceType`.
    /// See [DietaryPreferenceType](#type-dietarypreferencetype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public CatalogItemFoodAndBeverageDetailsDietaryPreferenceType? Type { get; set; }

    /// <summary>
    /// The name of the ingredient from a standard pre-defined list. This should be null if it's a custom dietary preference.
    /// See [StandardIngredient](#type-standardingredient) for possible values
    /// </summary>
    [JsonPropertyName("standard_name")]
    public CatalogItemFoodAndBeverageDetailsIngredientStandardIngredient? StandardName { get; set; }

    /// <summary>
    /// The name of a custom user-defined ingredient. This should be null if it's a standard dietary preference.
    /// </summary>
    [JsonPropertyName("custom_name")]
    public string? CustomName { get; set; }

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
