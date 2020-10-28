using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CatalogCustomAttributeDefinition 
    {
        public CatalogCustomAttributeDefinition(string type,
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
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// Provides information about the application used to generate a change.
        /// </summary>
        [JsonProperty("source_application", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SourceApplication SourceApplication { get; }

        /// <summary>
        /// The set of Catalog Object Types that this Custom Attribute may be applied to.
        /// Currently, only `ITEM` and `ITEM_VARIATION` are allowed. At least one type must be included.
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
        /// Getter for number_config
        /// </summary>
        [JsonProperty("number_config", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogCustomAttributeDefinitionNumberConfig NumberConfig { get; }

        /// <summary>
        /// Configuration associated with `SELECTION`-type custom attribute definitions.
        /// </summary>
        [JsonProperty("selection_config", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogCustomAttributeDefinitionSelectionConfig SelectionConfig { get; }

        /// <summary>
        /// __Read-only.__ The number of custom attributes that reference this
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
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Type,
                Name,
                AllowedObjectTypes)
                .Description(Description)
                .SourceApplication(SourceApplication)
                .SellerVisibility(SellerVisibility)
                .AppVisibility(AppVisibility)
                .StringConfig(StringConfig)
                .NumberConfig(NumberConfig)
                .SelectionConfig(SelectionConfig)
                .CustomAttributeUsageCount(CustomAttributeUsageCount)
                .Key(Key);
            return builder;
        }

        public class Builder
        {
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

            public Builder(string type,
                string name,
                IList<string> allowedObjectTypes)
            {
                this.type = type;
                this.name = name;
                this.allowedObjectTypes = allowedObjectTypes;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder AllowedObjectTypes(IList<string> allowedObjectTypes)
            {
                this.allowedObjectTypes = allowedObjectTypes;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder SourceApplication(Models.SourceApplication sourceApplication)
            {
                this.sourceApplication = sourceApplication;
                return this;
            }

            public Builder SellerVisibility(string sellerVisibility)
            {
                this.sellerVisibility = sellerVisibility;
                return this;
            }

            public Builder AppVisibility(string appVisibility)
            {
                this.appVisibility = appVisibility;
                return this;
            }

            public Builder StringConfig(Models.CatalogCustomAttributeDefinitionStringConfig stringConfig)
            {
                this.stringConfig = stringConfig;
                return this;
            }

            public Builder NumberConfig(Models.CatalogCustomAttributeDefinitionNumberConfig numberConfig)
            {
                this.numberConfig = numberConfig;
                return this;
            }

            public Builder SelectionConfig(Models.CatalogCustomAttributeDefinitionSelectionConfig selectionConfig)
            {
                this.selectionConfig = selectionConfig;
                return this;
            }

            public Builder CustomAttributeUsageCount(int? customAttributeUsageCount)
            {
                this.customAttributeUsageCount = customAttributeUsageCount;
                return this;
            }

            public Builder Key(string key)
            {
                this.key = key;
                return this;
            }

            public CatalogCustomAttributeDefinition Build()
            {
                return new CatalogCustomAttributeDefinition(type,
                    name,
                    allowedObjectTypes,
                    description,
                    sourceApplication,
                    sellerVisibility,
                    appVisibility,
                    stringConfig,
                    numberConfig,
                    selectionConfig,
                    customAttributeUsageCount,
                    key);
            }
        }
    }
}