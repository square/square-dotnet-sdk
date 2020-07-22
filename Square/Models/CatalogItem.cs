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
    public class CatalogItem 
    {
        public CatalogItem(string name = null,
            string description = null,
            string abbreviation = null,
            string labelColor = null,
            bool? availableOnline = null,
            bool? availableForPickup = null,
            bool? availableElectronically = null,
            string categoryId = null,
            IList<string> taxIds = null,
            IList<Models.CatalogItemModifierListInfo> modifierListInfo = null,
            IList<Models.CatalogObject> variations = null,
            string productType = null,
            bool? skipModifierScreen = null,
            IList<Models.CatalogItemOptionForItem> itemOptions = null)
        {
            Name = name;
            Description = description;
            Abbreviation = abbreviation;
            LabelColor = labelColor;
            AvailableOnline = availableOnline;
            AvailableForPickup = availableForPickup;
            AvailableElectronically = availableElectronically;
            CategoryId = categoryId;
            TaxIds = taxIds;
            ModifierListInfo = modifierListInfo;
            Variations = variations;
            ProductType = productType;
            SkipModifierScreen = skipModifierScreen;
            ItemOptions = itemOptions;
        }

        /// <summary>
        /// The item's name. This is a searchable attribute for use in applicable query filters, its value must not be empty, and the length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The item's description. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// The text of the item's display label in the Square Point of Sale app. Only up to the first five characters of the string are used.
        /// This attribute is searchable, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; }

        /// <summary>
        /// The color of the item's display label in the Square Point of Sale app. This must be a valid hex color code.
        /// </summary>
        [JsonProperty("label_color")]
        public string LabelColor { get; }

        /// <summary>
        /// If `true`, the item can be added to shipping orders from the merchant's online store.
        /// </summary>
        [JsonProperty("available_online")]
        public bool? AvailableOnline { get; }

        /// <summary>
        /// If `true`, the item can be added to pickup orders from the merchant's online store.
        /// </summary>
        [JsonProperty("available_for_pickup")]
        public bool? AvailableForPickup { get; }

        /// <summary>
        /// If `true`, the item can be added to electronically fulfilled orders from the merchant's online store.
        /// </summary>
        [JsonProperty("available_electronically")]
        public bool? AvailableElectronically { get; }

        /// <summary>
        /// The ID of the item's category, if any.
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; }

        /// <summary>
        /// A set of IDs indicating the taxes enabled for
        /// this item. When updating an item, any taxes listed here will be added to the item.
        /// Taxes may also be added to or deleted from an item using `UpdateItemTaxes`.
        /// </summary>
        [JsonProperty("tax_ids")]
        public IList<string> TaxIds { get; }

        /// <summary>
        /// A set of `CatalogItemModifierListInfo` objects
        /// representing the modifier lists that apply to this item, along with the overrides and min
        /// and max limits that are specific to this item. Modifier lists
        /// may also be added to or deleted from an item using `UpdateItemModifierLists`.
        /// </summary>
        [JsonProperty("modifier_list_info")]
        public IList<Models.CatalogItemModifierListInfo> ModifierListInfo { get; }

        /// <summary>
        /// A list of CatalogObjects containing the `CatalogItemVariation`s for this item.
        /// </summary>
        [JsonProperty("variations")]
        public IList<Models.CatalogObject> Variations { get; }

        /// <summary>
        /// The type of a CatalogItem. Connect V2 only allows the creation of `REGULAR` or `APPOINTMENTS_SERVICE` items.
        /// </summary>
        [JsonProperty("product_type")]
        public string ProductType { get; }

        /// <summary>
        /// If `false`, the Square Point of Sale app will present the `CatalogItem`'s
        /// details screen immediately, allowing the merchant to choose `CatalogModifier`s
        /// before adding the item to the cart.  This is the default behavior.
        /// If `true`, the Square Point of Sale app will immediately add the item to the cart with the pre-selected
        /// modifiers, and merchants can edit modifiers by drilling down onto the item's details.
        /// Third-party clients are encouraged to implement similar behaviors.
        /// </summary>
        [JsonProperty("skip_modifier_screen")]
        public bool? SkipModifierScreen { get; }

        /// <summary>
        /// List of item options IDs for this item. Used to manage and group item
        /// variations in a specified order.
        /// Maximum: 6 item options.
        /// </summary>
        [JsonProperty("item_options")]
        public IList<Models.CatalogItemOptionForItem> ItemOptions { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(Name)
                .Description(Description)
                .Abbreviation(Abbreviation)
                .LabelColor(LabelColor)
                .AvailableOnline(AvailableOnline)
                .AvailableForPickup(AvailableForPickup)
                .AvailableElectronically(AvailableElectronically)
                .CategoryId(CategoryId)
                .TaxIds(TaxIds)
                .ModifierListInfo(ModifierListInfo)
                .Variations(Variations)
                .ProductType(ProductType)
                .SkipModifierScreen(SkipModifierScreen)
                .ItemOptions(ItemOptions);
            return builder;
        }

        public class Builder
        {
            private string name;
            private string description;
            private string abbreviation;
            private string labelColor;
            private bool? availableOnline;
            private bool? availableForPickup;
            private bool? availableElectronically;
            private string categoryId;
            private IList<string> taxIds = new List<string>();
            private IList<Models.CatalogItemModifierListInfo> modifierListInfo = new List<Models.CatalogItemModifierListInfo>();
            private IList<Models.CatalogObject> variations = new List<Models.CatalogObject>();
            private string productType;
            private bool? skipModifierScreen;
            private IList<Models.CatalogItemOptionForItem> itemOptions = new List<Models.CatalogItemOptionForItem>();

            public Builder() { }
            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public Builder Abbreviation(string value)
            {
                abbreviation = value;
                return this;
            }

            public Builder LabelColor(string value)
            {
                labelColor = value;
                return this;
            }

            public Builder AvailableOnline(bool? value)
            {
                availableOnline = value;
                return this;
            }

            public Builder AvailableForPickup(bool? value)
            {
                availableForPickup = value;
                return this;
            }

            public Builder AvailableElectronically(bool? value)
            {
                availableElectronically = value;
                return this;
            }

            public Builder CategoryId(string value)
            {
                categoryId = value;
                return this;
            }

            public Builder TaxIds(IList<string> value)
            {
                taxIds = value;
                return this;
            }

            public Builder ModifierListInfo(IList<Models.CatalogItemModifierListInfo> value)
            {
                modifierListInfo = value;
                return this;
            }

            public Builder Variations(IList<Models.CatalogObject> value)
            {
                variations = value;
                return this;
            }

            public Builder ProductType(string value)
            {
                productType = value;
                return this;
            }

            public Builder SkipModifierScreen(bool? value)
            {
                skipModifierScreen = value;
                return this;
            }

            public Builder ItemOptions(IList<Models.CatalogItemOptionForItem> value)
            {
                itemOptions = value;
                return this;
            }

            public CatalogItem Build()
            {
                return new CatalogItem(name,
                    description,
                    abbreviation,
                    labelColor,
                    availableOnline,
                    availableForPickup,
                    availableElectronically,
                    categoryId,
                    taxIds,
                    modifierListInfo,
                    variations,
                    productType,
                    skipModifierScreen,
                    itemOptions);
            }
        }
    }
}