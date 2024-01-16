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
    /// CatalogItemFoodAndBeverageDetailsIngredient.
    /// </summary>
    public class CatalogItemFoodAndBeverageDetailsIngredient
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemFoodAndBeverageDetailsIngredient"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="standardName">standard_name.</param>
        /// <param name="customName">custom_name.</param>
        public CatalogItemFoodAndBeverageDetailsIngredient(
            string type = null,
            string standardName = null,
            string customName = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "custom_name", false }
            };

            this.Type = type;
            this.StandardName = standardName;
            if (customName != null)
            {
                shouldSerialize["custom_name"] = true;
                this.CustomName = customName;
            }

        }
        internal CatalogItemFoodAndBeverageDetailsIngredient(Dictionary<string, bool> shouldSerialize,
            string type = null,
            string standardName = null,
            string customName = null)
        {
            this.shouldSerialize = shouldSerialize;
            Type = type;
            StandardName = standardName;
            CustomName = customName;
        }

        /// <summary>
        /// The type of dietary preference for the `FOOD_AND_BEV` type of items and integredients.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// Standard ingredients for food and beverage items that are recommended on item creation.
        /// </summary>
        [JsonProperty("standard_name", NullValueHandling = NullValueHandling.Ignore)]
        public string StandardName { get; }

        /// <summary>
        /// The name of a custom user-defined ingredient. This should be null if it's a standard dietary preference.
        /// </summary>
        [JsonProperty("custom_name")]
        public string CustomName { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemFoodAndBeverageDetailsIngredient : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomName()
        {
            return this.shouldSerialize["custom_name"];
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
            return obj is CatalogItemFoodAndBeverageDetailsIngredient other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.StandardName == null && other.StandardName == null) || (this.StandardName?.Equals(other.StandardName) == true)) &&
                ((this.CustomName == null && other.CustomName == null) || (this.CustomName?.Equals(other.CustomName) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 2030150242;
            hashCode = HashCode.Combine(this.Type, this.StandardName, this.CustomName);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.StandardName = {(this.StandardName == null ? "null" : this.StandardName.ToString())}");
            toStringOutput.Add($"this.CustomName = {(this.CustomName == null ? "null" : this.CustomName)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Type(this.Type)
                .StandardName(this.StandardName)
                .CustomName(this.CustomName);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "custom_name", false },
            };

            private string type;
            private string standardName;
            private string customName;

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// StandardName.
             /// </summary>
             /// <param name="standardName"> standardName. </param>
             /// <returns> Builder. </returns>
            public Builder StandardName(string standardName)
            {
                this.standardName = standardName;
                return this;
            }

             /// <summary>
             /// CustomName.
             /// </summary>
             /// <param name="customName"> customName. </param>
             /// <returns> Builder. </returns>
            public Builder CustomName(string customName)
            {
                shouldSerialize["custom_name"] = true;
                this.customName = customName;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCustomName()
            {
                this.shouldSerialize["custom_name"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemFoodAndBeverageDetailsIngredient. </returns>
            public CatalogItemFoodAndBeverageDetailsIngredient Build()
            {
                return new CatalogItemFoodAndBeverageDetailsIngredient(shouldSerialize,
                    this.type,
                    this.standardName,
                    this.customName);
            }
        }
    }
}