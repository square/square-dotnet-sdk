using System.Text.Json;
using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

/// <summary>
/// Dietary preferences that can be assigned to an `FOOD_AND_BEV` item and its ingredients.
/// </summary>
[Serializable]
public record CatalogItemFoodAndBeverageDetailsDietaryPreference : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The dietary preference type. Supported values include `STANDARD` and `CUSTOM` as specified in `FoodAndBeverageDetails.DietaryPreferenceType`.
    /// See [DietaryPreferenceType](#type-dietarypreferencetype) for possible values
    /// </summary>
    [JsonPropertyName("type")]
    public CatalogItemFoodAndBeverageDetailsDietaryPreferenceType? Type { get; set; }

    /// <summary>
    /// The name of the dietary preference from a standard pre-defined list. This should be null if it's a custom dietary preference.
    /// See [StandardDietaryPreference](#type-standarddietarypreference) for possible values
    /// </summary>
    [JsonPropertyName("standard_name")]
    public CatalogItemFoodAndBeverageDetailsDietaryPreferenceStandardDietaryPreference? StandardName { get; set; }

    /// <summary>
    /// The name of a user-defined custom dietary preference. This should be null if it's a standard dietary preference.
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
