using System.Text.Json;
using System.Text.Json.Serialization;
using Square;
using Square.Core;

namespace Square.Default;

/// <summary>
/// The food and beverage-specific details of a `FOOD_AND_BEV` item.
/// </summary>
[Serializable]
public record CatalogItemFoodAndBeverageDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The calorie count (in the unit of kcal) for the `FOOD_AND_BEV` type of items.
    /// </summary>
    [JsonPropertyName("calorie_count")]
    public int? CalorieCount { get; set; }

    /// <summary>
    /// The dietary preferences for the `FOOD_AND_BEV` item.
    /// </summary>
    [JsonPropertyName("dietary_preferences")]
    public IEnumerable<CatalogItemFoodAndBeverageDetailsDietaryPreference>? DietaryPreferences { get; set; }

    /// <summary>
    /// The ingredients for the `FOOD_AND_BEV` type item.
    /// </summary>
    [JsonPropertyName("ingredients")]
    public IEnumerable<CatalogItemFoodAndBeverageDetailsIngredient>? Ingredients { get; set; }

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
