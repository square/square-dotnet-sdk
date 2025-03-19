using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// The food and beverage-specific details of a `FOOD_AND_BEV` item.
/// </summary>
public record CatalogItemFoodAndBeverageDetails
{
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
