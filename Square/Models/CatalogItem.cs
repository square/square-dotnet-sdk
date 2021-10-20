namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CatalogItem.
    /// </summary>
    public class CatalogItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItem"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="abbreviation">abbreviation.</param>
        /// <param name="labelColor">label_color.</param>
        /// <param name="availableOnline">available_online.</param>
        /// <param name="availableForPickup">available_for_pickup.</param>
        /// <param name="availableElectronically">available_electronically.</param>
        /// <param name="categoryId">category_id.</param>
        /// <param name="taxIds">tax_ids.</param>
        /// <param name="modifierListInfo">modifier_list_info.</param>
        /// <param name="variations">variations.</param>
        /// <param name="productType">product_type.</param>
        /// <param name="skipModifierScreen">skip_modifier_screen.</param>
        /// <param name="itemOptions">item_options.</param>
        /// <param name="sortName">sort_name.</param>
        public CatalogItem(
            string name = null,
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
            IList<Models.CatalogItemOptionForItem> itemOptions = null,
            string sortName = null)
        {
            this.Name = name;
            this.Description = description;
            this.Abbreviation = abbreviation;
            this.LabelColor = labelColor;
            this.AvailableOnline = availableOnline;
            this.AvailableForPickup = availableForPickup;
            this.AvailableElectronically = availableElectronically;
            this.CategoryId = categoryId;
            this.TaxIds = taxIds;
            this.ModifierListInfo = modifierListInfo;
            this.Variations = variations;
            this.ProductType = productType;
            this.SkipModifierScreen = skipModifierScreen;
            this.ItemOptions = itemOptions;
            this.SortName = sortName;
        }

        /// <summary>
        /// The item's name. This is a searchable attribute for use in applicable query filters, its value must not be empty, and the length is of Unicode code points.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The item's description. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// The text of the item's display label in the Square Point of Sale app. Only up to the first five characters of the string are used.
        /// This attribute is searchable, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("abbreviation", NullValueHandling = NullValueHandling.Ignore)]
        public string Abbreviation { get; }

        /// <summary>
        /// The color of the item's display label in the Square Point of Sale app. This must be a valid hex color code.
        /// </summary>
        [JsonProperty("label_color", NullValueHandling = NullValueHandling.Ignore)]
        public string LabelColor { get; }

        /// <summary>
        /// If `true`, the item can be added to shipping orders from the merchant's online store.
        /// </summary>
        [JsonProperty("available_online", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AvailableOnline { get; }

        /// <summary>
        /// If `true`, the item can be added to pickup orders from the merchant's online store.
        /// </summary>
        [JsonProperty("available_for_pickup", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AvailableForPickup { get; }

        /// <summary>
        /// If `true`, the item can be added to electronically fulfilled orders from the merchant's online store.
        /// </summary>
        [JsonProperty("available_electronically", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AvailableElectronically { get; }

        /// <summary>
        /// The ID of the item's category, if any.
        /// </summary>
        [JsonProperty("category_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CategoryId { get; }

        /// <summary>
        /// A set of IDs indicating the taxes enabled for
        /// this item. When updating an item, any taxes listed here will be added to the item.
        /// Taxes may also be added to or deleted from an item using `UpdateItemTaxes`.
        /// </summary>
        [JsonProperty("tax_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TaxIds { get; }

        /// <summary>
        /// A set of `CatalogItemModifierListInfo` objects
        /// representing the modifier lists that apply to this item, along with the overrides and min
        /// and max limits that are specific to this item. Modifier lists
        /// may also be added to or deleted from an item using `UpdateItemModifierLists`.
        /// </summary>
        [JsonProperty("modifier_list_info", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogItemModifierListInfo> ModifierListInfo { get; }

        /// <summary>
        /// A list of [CatalogItemVariation]($m/CatalogItemVariation) objects for this item. An item must have
        /// at least one variation.
        /// </summary>
        [JsonProperty("variations", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogObject> Variations { get; }

        /// <summary>
        /// The type of a CatalogItem. Connect V2 only allows the creation of `REGULAR` or `APPOINTMENTS_SERVICE` items.
        /// </summary>
        [JsonProperty("product_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductType { get; }

        /// <summary>
        /// If `false`, the Square Point of Sale app will present the `CatalogItem`'s
        /// details screen immediately, allowing the merchant to choose `CatalogModifier`s
        /// before adding the item to the cart.  This is the default behavior.
        /// If `true`, the Square Point of Sale app will immediately add the item to the cart with the pre-selected
        /// modifiers, and merchants can edit modifiers by drilling down onto the item's details.
        /// Third-party clients are encouraged to implement similar behaviors.
        /// </summary>
        [JsonProperty("skip_modifier_screen", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SkipModifierScreen { get; }

        /// <summary>
        /// List of item options IDs for this item. Used to manage and group item
        /// variations in a specified order.
        /// Maximum: 6 item options.
        /// </summary>
        [JsonProperty("item_options", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogItemOptionForItem> ItemOptions { get; }

        /// <summary>
        /// A name to sort the item by. If this name is unspecified, namely, the `sort_name` field is absent, the regular `name` field is used for sorting.
        /// It is currently supported for sellers of the Japanese locale only.
        /// </summary>
        [JsonProperty("sort_name", NullValueHandling = NullValueHandling.Ignore)]
        public string SortName { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItem : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogItem other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.Abbreviation == null && other.Abbreviation == null) || (this.Abbreviation?.Equals(other.Abbreviation) == true)) &&
                ((this.LabelColor == null && other.LabelColor == null) || (this.LabelColor?.Equals(other.LabelColor) == true)) &&
                ((this.AvailableOnline == null && other.AvailableOnline == null) || (this.AvailableOnline?.Equals(other.AvailableOnline) == true)) &&
                ((this.AvailableForPickup == null && other.AvailableForPickup == null) || (this.AvailableForPickup?.Equals(other.AvailableForPickup) == true)) &&
                ((this.AvailableElectronically == null && other.AvailableElectronically == null) || (this.AvailableElectronically?.Equals(other.AvailableElectronically) == true)) &&
                ((this.CategoryId == null && other.CategoryId == null) || (this.CategoryId?.Equals(other.CategoryId) == true)) &&
                ((this.TaxIds == null && other.TaxIds == null) || (this.TaxIds?.Equals(other.TaxIds) == true)) &&
                ((this.ModifierListInfo == null && other.ModifierListInfo == null) || (this.ModifierListInfo?.Equals(other.ModifierListInfo) == true)) &&
                ((this.Variations == null && other.Variations == null) || (this.Variations?.Equals(other.Variations) == true)) &&
                ((this.ProductType == null && other.ProductType == null) || (this.ProductType?.Equals(other.ProductType) == true)) &&
                ((this.SkipModifierScreen == null && other.SkipModifierScreen == null) || (this.SkipModifierScreen?.Equals(other.SkipModifierScreen) == true)) &&
                ((this.ItemOptions == null && other.ItemOptions == null) || (this.ItemOptions?.Equals(other.ItemOptions) == true)) &&
                ((this.SortName == null && other.SortName == null) || (this.SortName?.Equals(other.SortName) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -608183061;
            hashCode = HashCode.Combine(this.Name, this.Description, this.Abbreviation, this.LabelColor, this.AvailableOnline, this.AvailableForPickup, this.AvailableElectronically);

            hashCode = HashCode.Combine(hashCode, this.CategoryId, this.TaxIds, this.ModifierListInfo, this.Variations, this.ProductType, this.SkipModifierScreen, this.ItemOptions);

            hashCode = HashCode.Combine(hashCode, this.SortName);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description == string.Empty ? "" : this.Description)}");
            toStringOutput.Add($"this.Abbreviation = {(this.Abbreviation == null ? "null" : this.Abbreviation == string.Empty ? "" : this.Abbreviation)}");
            toStringOutput.Add($"this.LabelColor = {(this.LabelColor == null ? "null" : this.LabelColor == string.Empty ? "" : this.LabelColor)}");
            toStringOutput.Add($"this.AvailableOnline = {(this.AvailableOnline == null ? "null" : this.AvailableOnline.ToString())}");
            toStringOutput.Add($"this.AvailableForPickup = {(this.AvailableForPickup == null ? "null" : this.AvailableForPickup.ToString())}");
            toStringOutput.Add($"this.AvailableElectronically = {(this.AvailableElectronically == null ? "null" : this.AvailableElectronically.ToString())}");
            toStringOutput.Add($"this.CategoryId = {(this.CategoryId == null ? "null" : this.CategoryId == string.Empty ? "" : this.CategoryId)}");
            toStringOutput.Add($"this.TaxIds = {(this.TaxIds == null ? "null" : $"[{string.Join(", ", this.TaxIds)} ]")}");
            toStringOutput.Add($"this.ModifierListInfo = {(this.ModifierListInfo == null ? "null" : $"[{string.Join(", ", this.ModifierListInfo)} ]")}");
            toStringOutput.Add($"this.Variations = {(this.Variations == null ? "null" : $"[{string.Join(", ", this.Variations)} ]")}");
            toStringOutput.Add($"this.ProductType = {(this.ProductType == null ? "null" : this.ProductType.ToString())}");
            toStringOutput.Add($"this.SkipModifierScreen = {(this.SkipModifierScreen == null ? "null" : this.SkipModifierScreen.ToString())}");
            toStringOutput.Add($"this.ItemOptions = {(this.ItemOptions == null ? "null" : $"[{string.Join(", ", this.ItemOptions)} ]")}");
            toStringOutput.Add($"this.SortName = {(this.SortName == null ? "null" : this.SortName == string.Empty ? "" : this.SortName)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .Description(this.Description)
                .Abbreviation(this.Abbreviation)
                .LabelColor(this.LabelColor)
                .AvailableOnline(this.AvailableOnline)
                .AvailableForPickup(this.AvailableForPickup)
                .AvailableElectronically(this.AvailableElectronically)
                .CategoryId(this.CategoryId)
                .TaxIds(this.TaxIds)
                .ModifierListInfo(this.ModifierListInfo)
                .Variations(this.Variations)
                .ProductType(this.ProductType)
                .SkipModifierScreen(this.SkipModifierScreen)
                .ItemOptions(this.ItemOptions)
                .SortName(this.SortName);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
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
            private IList<string> taxIds;
            private IList<Models.CatalogItemModifierListInfo> modifierListInfo;
            private IList<Models.CatalogObject> variations;
            private string productType;
            private bool? skipModifierScreen;
            private IList<Models.CatalogItemOptionForItem> itemOptions;
            private string sortName;

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
             /// Description.
             /// </summary>
             /// <param name="description"> description. </param>
             /// <returns> Builder. </returns>
            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

             /// <summary>
             /// Abbreviation.
             /// </summary>
             /// <param name="abbreviation"> abbreviation. </param>
             /// <returns> Builder. </returns>
            public Builder Abbreviation(string abbreviation)
            {
                this.abbreviation = abbreviation;
                return this;
            }

             /// <summary>
             /// LabelColor.
             /// </summary>
             /// <param name="labelColor"> labelColor. </param>
             /// <returns> Builder. </returns>
            public Builder LabelColor(string labelColor)
            {
                this.labelColor = labelColor;
                return this;
            }

             /// <summary>
             /// AvailableOnline.
             /// </summary>
             /// <param name="availableOnline"> availableOnline. </param>
             /// <returns> Builder. </returns>
            public Builder AvailableOnline(bool? availableOnline)
            {
                this.availableOnline = availableOnline;
                return this;
            }

             /// <summary>
             /// AvailableForPickup.
             /// </summary>
             /// <param name="availableForPickup"> availableForPickup. </param>
             /// <returns> Builder. </returns>
            public Builder AvailableForPickup(bool? availableForPickup)
            {
                this.availableForPickup = availableForPickup;
                return this;
            }

             /// <summary>
             /// AvailableElectronically.
             /// </summary>
             /// <param name="availableElectronically"> availableElectronically. </param>
             /// <returns> Builder. </returns>
            public Builder AvailableElectronically(bool? availableElectronically)
            {
                this.availableElectronically = availableElectronically;
                return this;
            }

             /// <summary>
             /// CategoryId.
             /// </summary>
             /// <param name="categoryId"> categoryId. </param>
             /// <returns> Builder. </returns>
            public Builder CategoryId(string categoryId)
            {
                this.categoryId = categoryId;
                return this;
            }

             /// <summary>
             /// TaxIds.
             /// </summary>
             /// <param name="taxIds"> taxIds. </param>
             /// <returns> Builder. </returns>
            public Builder TaxIds(IList<string> taxIds)
            {
                this.taxIds = taxIds;
                return this;
            }

             /// <summary>
             /// ModifierListInfo.
             /// </summary>
             /// <param name="modifierListInfo"> modifierListInfo. </param>
             /// <returns> Builder. </returns>
            public Builder ModifierListInfo(IList<Models.CatalogItemModifierListInfo> modifierListInfo)
            {
                this.modifierListInfo = modifierListInfo;
                return this;
            }

             /// <summary>
             /// Variations.
             /// </summary>
             /// <param name="variations"> variations. </param>
             /// <returns> Builder. </returns>
            public Builder Variations(IList<Models.CatalogObject> variations)
            {
                this.variations = variations;
                return this;
            }

             /// <summary>
             /// ProductType.
             /// </summary>
             /// <param name="productType"> productType. </param>
             /// <returns> Builder. </returns>
            public Builder ProductType(string productType)
            {
                this.productType = productType;
                return this;
            }

             /// <summary>
             /// SkipModifierScreen.
             /// </summary>
             /// <param name="skipModifierScreen"> skipModifierScreen. </param>
             /// <returns> Builder. </returns>
            public Builder SkipModifierScreen(bool? skipModifierScreen)
            {
                this.skipModifierScreen = skipModifierScreen;
                return this;
            }

             /// <summary>
             /// ItemOptions.
             /// </summary>
             /// <param name="itemOptions"> itemOptions. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptions(IList<Models.CatalogItemOptionForItem> itemOptions)
            {
                this.itemOptions = itemOptions;
                return this;
            }

             /// <summary>
             /// SortName.
             /// </summary>
             /// <param name="sortName"> sortName. </param>
             /// <returns> Builder. </returns>
            public Builder SortName(string sortName)
            {
                this.sortName = sortName;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItem. </returns>
            public CatalogItem Build()
            {
                return new CatalogItem(
                    this.name,
                    this.description,
                    this.abbreviation,
                    this.labelColor,
                    this.availableOnline,
                    this.availableForPickup,
                    this.availableElectronically,
                    this.categoryId,
                    this.taxIds,
                    this.modifierListInfo,
                    this.variations,
                    this.productType,
                    this.skipModifierScreen,
                    this.itemOptions,
                    this.sortName);
            }
        }
    }
}