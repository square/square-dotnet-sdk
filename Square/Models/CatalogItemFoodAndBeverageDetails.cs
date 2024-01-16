namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CatalogItemFoodAndBeverageDetails.
    /// </summary>
    public class CatalogItemFoodAndBeverageDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemFoodAndBeverageDetails"/> class.
        /// </summary>
        /// <param name="calorieCount">calorie_count.</param>
        /// <param name="dietaryPreferences">dietary_preferences.</param>
        /// <param name="ingredients">ingredients.</param>
        public CatalogItemFoodAndBeverageDetails(
            int? calorieCount = null,
            IList<Models.CatalogItemFoodAndBeverageDetailsDietaryPreference> dietaryPreferences = null,
            IList<Models.CatalogItemFoodAndBeverageDetailsIngredient> ingredients = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "calorie_count", false },
                { "dietary_preferences", false },
                { "ingredients", false }
            };

            if (calorieCount != null)
            {
                shouldSerialize["calorie_count"] = true;
                this.CalorieCount = calorieCount;
            }

            if (dietaryPreferences != null)
            {
                shouldSerialize["dietary_preferences"] = true;
                this.DietaryPreferences = dietaryPreferences;
            }

            if (ingredients != null)
            {
                shouldSerialize["ingredients"] = true;
                this.Ingredients = ingredients;
            }

        }
        internal CatalogItemFoodAndBeverageDetails(Dictionary<string, bool> shouldSerialize,
            int? calorieCount = null,
            IList<Models.CatalogItemFoodAndBeverageDetailsDietaryPreference> dietaryPreferences = null,
            IList<Models.CatalogItemFoodAndBeverageDetailsIngredient> ingredients = null)
        {
            this.shouldSerialize = shouldSerialize;
            CalorieCount = calorieCount;
            DietaryPreferences = dietaryPreferences;
            Ingredients = ingredients;
        }

        /// <summary>
        /// The calorie count (in the unit of kcal) for the `FOOD_AND_BEV` type of items.
        /// </summary>
        [JsonProperty("calorie_count")]
        public int? CalorieCount { get; }

        /// <summary>
        /// The dietary preferences for the `FOOD_AND_BEV` item.
        /// </summary>
        [JsonProperty("dietary_preferences")]
        public IList<Models.CatalogItemFoodAndBeverageDetailsDietaryPreference> DietaryPreferences { get; }

        /// <summary>
        /// The ingredients for the `FOOD_AND_BEV` type item.
        /// </summary>
        [JsonProperty("ingredients")]
        public IList<Models.CatalogItemFoodAndBeverageDetailsIngredient> Ingredients { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemFoodAndBeverageDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCalorieCount()
        {
            return this.shouldSerialize["calorie_count"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDietaryPreferences()
        {
            return this.shouldSerialize["dietary_preferences"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIngredients()
        {
            return this.shouldSerialize["ingredients"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is CatalogItemFoodAndBeverageDetails other &&                ((this.CalorieCount == null && other.CalorieCount == null) || (this.CalorieCount?.Equals(other.CalorieCount) == true)) &&
                ((this.DietaryPreferences == null && other.DietaryPreferences == null) || (this.DietaryPreferences?.Equals(other.DietaryPreferences) == true)) &&
                ((this.Ingredients == null && other.Ingredients == null) || (this.Ingredients?.Equals(other.Ingredients) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 137316348;
            hashCode = HashCode.Combine(this.CalorieCount, this.DietaryPreferences, this.Ingredients);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CalorieCount = {(this.CalorieCount == null ? "null" : this.CalorieCount.ToString())}");
            toStringOutput.Add($"this.DietaryPreferences = {(this.DietaryPreferences == null ? "null" : $"[{string.Join(", ", this.DietaryPreferences)} ]")}");
            toStringOutput.Add($"this.Ingredients = {(this.Ingredients == null ? "null" : $"[{string.Join(", ", this.Ingredients)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CalorieCount(this.CalorieCount)
                .DietaryPreferences(this.DietaryPreferences)
                .Ingredients(this.Ingredients);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "calorie_count", false },
                { "dietary_preferences", false },
                { "ingredients", false },
            };

            private int? calorieCount;
            private IList<Models.CatalogItemFoodAndBeverageDetailsDietaryPreference> dietaryPreferences;
            private IList<Models.CatalogItemFoodAndBeverageDetailsIngredient> ingredients;

             /// <summary>
             /// CalorieCount.
             /// </summary>
             /// <param name="calorieCount"> calorieCount. </param>
             /// <returns> Builder. </returns>
            public Builder CalorieCount(int? calorieCount)
            {
                shouldSerialize["calorie_count"] = true;
                this.calorieCount = calorieCount;
                return this;
            }

             /// <summary>
             /// DietaryPreferences.
             /// </summary>
             /// <param name="dietaryPreferences"> dietaryPreferences. </param>
             /// <returns> Builder. </returns>
            public Builder DietaryPreferences(IList<Models.CatalogItemFoodAndBeverageDetailsDietaryPreference> dietaryPreferences)
            {
                shouldSerialize["dietary_preferences"] = true;
                this.dietaryPreferences = dietaryPreferences;
                return this;
            }

             /// <summary>
             /// Ingredients.
             /// </summary>
             /// <param name="ingredients"> ingredients. </param>
             /// <returns> Builder. </returns>
            public Builder Ingredients(IList<Models.CatalogItemFoodAndBeverageDetailsIngredient> ingredients)
            {
                shouldSerialize["ingredients"] = true;
                this.ingredients = ingredients;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCalorieCount()
            {
                this.shouldSerialize["calorie_count"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDietaryPreferences()
            {
                this.shouldSerialize["dietary_preferences"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIngredients()
            {
                this.shouldSerialize["ingredients"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemFoodAndBeverageDetails. </returns>
            public CatalogItemFoodAndBeverageDetails Build()
            {
                return new CatalogItemFoodAndBeverageDetails(shouldSerialize,
                    this.calorieCount,
                    this.dietaryPreferences,
                    this.ingredients);
            }
        }
    }
}