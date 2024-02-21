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
    /// CatalogCustomAttributeDefinition.
    /// </summary>
    public class CatalogCustomAttributeDefinition
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogCustomAttributeDefinition"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="name">name.</param>
        /// <param name="allowedObjectTypes">allowed_object_types.</param>
        /// <param name="description">description.</param>
        /// <param name="sourceApplication">source_application.</param>
        /// <param name="sellerVisibility">seller_visibility.</param>
        /// <param name="appVisibility">app_visibility.</param>
        /// <param name="stringConfig">string_config.</param>
        /// <param name="numberConfig">number_config.</param>
        /// <param name="selectionConfig">selection_config.</param>
        /// <param name="customAttributeUsageCount">custom_attribute_usage_count.</param>
        /// <param name="key">key.</param>
        public CatalogCustomAttributeDefinition(
            string type,
            string name,
            IList<string> allowedObjectTypes,
            string description = null,
            Models.SourceApplication sourceApplication = null,
            string sellerVisibility = null,
            string appVisibility = null,
            Models.CatalogCustomAttributeDefinitionStringConfig stringConfig = null,
            Models.CatalogCustomAttributeDefinitionNumberConfig numberConfig = null,
            Models.CatalogCustomAttributeDefinitionSelectionConfig selectionConfig = null,
            int? customAttributeUsageCount = null,
            string key = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "description", false },
                { "key", false }
            };

            this.Type = type;
            this.Name = name;
            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            this.SourceApplication = sourceApplication;
            this.AllowedObjectTypes = allowedObjectTypes;
            this.SellerVisibility = sellerVisibility;
            this.AppVisibility = appVisibility;
            this.StringConfig = stringConfig;
            this.NumberConfig = numberConfig;
            this.SelectionConfig = selectionConfig;
            this.CustomAttributeUsageCount = customAttributeUsageCount;
            if (key != null)
            {
                shouldSerialize["key"] = true;
                this.Key = key;
            }

        }
        internal CatalogCustomAttributeDefinition(Dictionary<string, bool> shouldSerialize,
            string type,
            string name,
            IList<string> allowedObjectTypes,
            string description = null,
            Models.SourceApplication sourceApplication = null,
            string sellerVisibility = null,
            string appVisibility = null,
            Models.CatalogCustomAttributeDefinitionStringConfig stringConfig = null,
            Models.CatalogCustomAttributeDefinitionNumberConfig numberConfig = null,
            Models.CatalogCustomAttributeDefinitionSelectionConfig selectionConfig = null,
            int? customAttributeUsageCount = null,
            string key = null)
        {
            this.shouldSerialize = shouldSerialize;
            Type = type;
            Name = name;
            Description = description;
            SourceApplication = sourceApplication;
            AllowedObjectTypes = allowedObjectTypes;
            SellerVisibility = sellerVisibility;
            AppVisibility = appVisibility;
            StringConfig = stringConfig;
            NumberConfig = numberConfig;
            SelectionConfig = selectionConfig;
            CustomAttributeUsageCount = customAttributeUsageCount;
            Key = key;
        }

        /// <summary>
        /// Defines the possible types for a custom attribute.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The name of this definition for API and seller-facing UI purposes.
        /// The name must be unique within the (merchant, application) pair. Required.
        /// May not be empty and may not exceed 255 characters. Can be modified after creation.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Seller-oriented description of the meaning of this Custom Attribute,
        /// any constraints that the seller should observe, etc. May be displayed as a tooltip in Square UIs.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Represents information about the application used to generate a change.
        /// </summary>
        [JsonProperty("source_application", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SourceApplication SourceApplication { get; }

        /// <summary>
        /// The set of `CatalogObject` types that this custom atttribute may be applied to.
        /// Currently, only `ITEM`, `ITEM_VARIATION`, and `MODIFIER` are allowed. At least one type must be included.
        /// See [CatalogObjectType](#type-catalogobjecttype) for possible values
        /// </summary>
        [JsonProperty("allowed_object_types")]
        public IList<string> AllowedObjectTypes { get; }

        /// <summary>
        /// Defines the visibility of a custom attribute to sellers in Square
        /// client applications, Square APIs or in Square UIs (including Square Point
        /// of Sale applications and Square Dashboard).
        /// </summary>
        [JsonProperty("seller_visibility", NullValueHandling = NullValueHandling.Ignore)]
        public string SellerVisibility { get; }

        /// <summary>
        /// Defines the visibility of a custom attribute to applications other than their
        /// creating application.
        /// </summary>
        [JsonProperty("app_visibility", NullValueHandling = NullValueHandling.Ignore)]
        public string AppVisibility { get; }

        /// <summary>
        /// Configuration associated with Custom Attribute Definitions of type `STRING`.
        /// </summary>
        [JsonProperty("string_config", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogCustomAttributeDefinitionStringConfig StringConfig { get; }

        /// <summary>
        /// Gets or sets NumberConfig.
        /// </summary>
        [JsonProperty("number_config", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogCustomAttributeDefinitionNumberConfig NumberConfig { get; }

        /// <summary>
        /// Configuration associated with `SELECTION`-type custom attribute definitions.
        /// </summary>
        [JsonProperty("selection_config", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogCustomAttributeDefinitionSelectionConfig SelectionConfig { get; }

        /// <summary>
        /// The number of custom attributes that reference this
        /// custom attribute definition. Set by the server in response to a ListCatalog
        /// request with `include_counts` set to `true`.  If the actual count is greater
        /// than 100, `custom_attribute_usage_count` will be set to `100`.
        /// </summary>
        [JsonProperty("custom_attribute_usage_count", NullValueHandling = NullValueHandling.Ignore)]
        public int? CustomAttributeUsageCount { get; }

        /// <summary>
        /// The name of the desired custom attribute key that can be used to access
        /// the custom attribute value on catalog objects. Cannot be modified after the
        /// custom attribute definition has been created.
        /// Must be between 1 and 60 characters, and may only contain the characters `[a-zA-Z0-9_-]`.
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogCustomAttributeDefinition : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescription()
        {
            return this.shouldSerialize["description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeKey()
        {
            return this.shouldSerialize["key"];
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
            return obj is CatalogCustomAttributeDefinition other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.SourceApplication == null && other.SourceApplication == null) || (this.SourceApplication?.Equals(other.SourceApplication) == true)) &&
                ((this.AllowedObjectTypes == null && other.AllowedObjectTypes == null) || (this.AllowedObjectTypes?.Equals(other.AllowedObjectTypes) == true)) &&
                ((this.SellerVisibility == null && other.SellerVisibility == null) || (this.SellerVisibility?.Equals(other.SellerVisibility) == true)) &&
                ((this.AppVisibility == null && other.AppVisibility == null) || (this.AppVisibility?.Equals(other.AppVisibility) == true)) &&
                ((this.StringConfig == null && other.StringConfig == null) || (this.StringConfig?.Equals(other.StringConfig) == true)) &&
                ((this.NumberConfig == null && other.NumberConfig == null) || (this.NumberConfig?.Equals(other.NumberConfig) == true)) &&
                ((this.SelectionConfig == null && other.SelectionConfig == null) || (this.SelectionConfig?.Equals(other.SelectionConfig) == true)) &&
                ((this.CustomAttributeUsageCount == null && other.CustomAttributeUsageCount == null) || (this.CustomAttributeUsageCount?.Equals(other.CustomAttributeUsageCount) == true)) &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1892852076;
            hashCode = HashCode.Combine(this.Type, this.Name, this.Description, this.SourceApplication, this.AllowedObjectTypes, this.SellerVisibility, this.AppVisibility);

            hashCode = HashCode.Combine(hashCode, this.StringConfig, this.NumberConfig, this.SelectionConfig, this.CustomAttributeUsageCount, this.Key);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.SourceApplication = {(this.SourceApplication == null ? "null" : this.SourceApplication.ToString())}");
            toStringOutput.Add($"this.AllowedObjectTypes = {(this.AllowedObjectTypes == null ? "null" : $"[{string.Join(", ", this.AllowedObjectTypes)} ]")}");
            toStringOutput.Add($"this.SellerVisibility = {(this.SellerVisibility == null ? "null" : this.SellerVisibility.ToString())}");
            toStringOutput.Add($"this.AppVisibility = {(this.AppVisibility == null ? "null" : this.AppVisibility.ToString())}");
            toStringOutput.Add($"this.StringConfig = {(this.StringConfig == null ? "null" : this.StringConfig.ToString())}");
            toStringOutput.Add($"this.NumberConfig = {(this.NumberConfig == null ? "null" : this.NumberConfig.ToString())}");
            toStringOutput.Add($"this.SelectionConfig = {(this.SelectionConfig == null ? "null" : this.SelectionConfig.ToString())}");
            toStringOutput.Add($"this.CustomAttributeUsageCount = {(this.CustomAttributeUsageCount == null ? "null" : this.CustomAttributeUsageCount.ToString())}");
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type,
                this.Name,
                this.AllowedObjectTypes)
                .Description(this.Description)
                .SourceApplication(this.SourceApplication)
                .SellerVisibility(this.SellerVisibility)
                .AppVisibility(this.AppVisibility)
                .StringConfig(this.StringConfig)
                .NumberConfig(this.NumberConfig)
                .SelectionConfig(this.SelectionConfig)
                .CustomAttributeUsageCount(this.CustomAttributeUsageCount)
                .Key(this.Key);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "description", false },
                { "key", false },
            };

            private string type;
            private string name;
            private IList<string> allowedObjectTypes;
            private string description;
            private Models.SourceApplication sourceApplication;
            private string sellerVisibility;
            private string appVisibility;
            private Models.CatalogCustomAttributeDefinitionStringConfig stringConfig;
            private Models.CatalogCustomAttributeDefinitionNumberConfig numberConfig;
            private Models.CatalogCustomAttributeDefinitionSelectionConfig selectionConfig;
            private int? customAttributeUsageCount;
            private string key;

            /// <summary>
            /// Initialize Builder for CatalogCustomAttributeDefinition.
            /// </summary>
            /// <param name="type"> type. </param>
            /// <param name="name"> name. </param>
            /// <param name="allowedObjectTypes"> allowedObjectTypes. </param>
            public Builder(
                string type,
                string name,
                IList<string> allowedObjectTypes)
            {
                this.type = type;
                this.name = name;
                this.allowedObjectTypes = allowedObjectTypes;
            }

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
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// AllowedObjectTypes.
             /// </summary>
             /// <param name="allowedObjectTypes"> allowedObjectTypes. </param>
             /// <returns> Builder. </returns>
            public Builder AllowedObjectTypes(IList<string> allowedObjectTypes)
            {
                this.allowedObjectTypes = allowedObjectTypes;
                return this;
            }

             /// <summary>
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                shouldSerialize["description"] = true;
                this.description = description;
                return this;
            }

             /// <summary>
             /// SourceApplication.
             /// </summary>
             /// <param name="sourceApplication"> sourceApplication. </param>
             /// <returns> Builder. </returns>
            public Builder SourceApplication(Models.SourceApplication sourceApplication)
            {
                this.sourceApplication = sourceApplication;
                return this;
            }

             /// <summary>
             /// SellerVisibility.
             /// </summary>
             /// <param name="sellerVisibility"> sellerVisibility. </param>
             /// <returns> Builder. </returns>
            public Builder SellerVisibility(string sellerVisibility)
            {
                this.sellerVisibility = sellerVisibility;
                return this;
            }

             /// <summary>
             /// AppVisibility.
             /// </summary>
             /// <param name="appVisibility"> appVisibility. </param>
             /// <returns> Builder. </returns>
            public Builder AppVisibility(string appVisibility)
            {
                this.appVisibility = appVisibility;
                return this;
            }

             /// <summary>
             /// StringConfig.
             /// </summary>
             /// <param name="stringConfig"> stringConfig. </param>
             /// <returns> Builder. </returns>
            public Builder StringConfig(Models.CatalogCustomAttributeDefinitionStringConfig stringConfig)
            {
                this.stringConfig = stringConfig;
                return this;
            }

             /// <summary>
             /// NumberConfig.
             /// </summary>
             /// <param name="numberConfig"> numberConfig. </param>
             /// <returns> Builder. </returns>
            public Builder NumberConfig(Models.CatalogCustomAttributeDefinitionNumberConfig numberConfig)
            {
                this.numberConfig = numberConfig;
                return this;
            }

             /// <summary>
             /// SelectionConfig.
             /// </summary>
             /// <param name="selectionConfig"> selectionConfig. </param>
             /// <returns> Builder. </returns>
            public Builder SelectionConfig(Models.CatalogCustomAttributeDefinitionSelectionConfig selectionConfig)
            {
                this.selectionConfig = selectionConfig;
                return this;
            }

             /// <summary>
             /// CustomAttributeUsageCount.
             /// </summary>
             /// <param name="customAttributeUsageCount"> customAttributeUsageCount. </param>
             /// <returns> Builder. </returns>
            public Builder CustomAttributeUsageCount(int? customAttributeUsageCount)
            {
                this.customAttributeUsageCount = customAttributeUsageCount;
                return this;
            }

             /// <summary>
             /// Key.
             /// </summary>
             /// <param name="key"> key. </param>
             /// <returns> Builder. </returns>
            public Builder Key(string key)
            {
                shouldSerialize["key"] = true;
                this.key = key;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDescription()
            {
                this.shouldSerialize["description"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetKey()
            {
                this.shouldSerialize["key"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogCustomAttributeDefinition. </returns>
            public CatalogCustomAttributeDefinition Build()
            {
                return new CatalogCustomAttributeDefinition(shouldSerialize,
                    this.type,
                    this.name,
                    this.allowedObjectTypes,
                    this.description,
                    this.sourceApplication,
                    this.sellerVisibility,
                    this.appVisibility,
                    this.stringConfig,
                    this.numberConfig,
                    this.selectionConfig,
                    this.customAttributeUsageCount,
                    this.key);
            }
        }
    }
}