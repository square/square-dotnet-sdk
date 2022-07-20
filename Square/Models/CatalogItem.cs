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
        /// <param name="imageIds">image_ids.</param>
        /// <param name="sortName">sort_name.</param>
        /// <param name="descriptionHtml">description_html.</param>
        /// <param name="descriptionPlaintext">description_plaintext.</param>
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
            IList<string> imageIds = null,
            string sortName = null,
            string descriptionHtml = null,
            string descriptionPlaintext = null)
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
            this.ImageIds = imageIds;
            this.SortName = sortName;
            this.DescriptionHtml = descriptionHtml;
            this.DescriptionPlaintext = descriptionPlaintext;
        }

        /// <summary>
        /// The item's name. This is a searchable attribute for use in applicable query filters, its value must not be empty, and the length is of Unicode code points.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The item's description. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// Deprecated at 2022-07-20, this field is planned to retire in 6 months. You should migrate to use `description_html` to set the description
        /// of the [CatalogItem]($m/CatalogItem) instance.  The `description` and `description_html` field values are kept in sync. If you try to
        /// set the both fields, the `description_html` text value overwrites the `description` value. Updates in one field are also reflected in the other,
        /// except for when you use an early version before Square API 2022-07-20 and `description_html` is set to blank, setting the `description` value to null
        /// does not nullify `description_html`.
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
        /// The IDs of images associated with this `CatalogItem` instance.
        /// These images will be shown to customers in Square Online Store.
        /// The first image will show up as the icon for this item in POS.
        /// </summary>
        [JsonProperty("image_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> ImageIds { get; }

        /// <summary>
        /// A name to sort the item by. If this name is unspecified, namely, the `sort_name` field is absent, the regular `name` field is used for sorting.
        /// It is currently supported for sellers of the Japanese locale only.
        /// </summary>
        [JsonProperty("sort_name", NullValueHandling = NullValueHandling.Ignore)]
        public string SortName { get; }

        /// <summary>
        /// The item's description as expressed in valid HTML elements. The length of this field value, including those of HTML tags,
        /// is of Unicode points. With application query filters, the text values of the HTML elements and attributes are searchable. Invalid or
        /// unsupported HTML elements or attributes are ignored.
        /// Supported HTML elements include:
        /// - `a`: Link. Supports linking to website URLs, email address, and telephone numbers.
        /// - `b`, `strong`:  Bold text
        /// - `br`: Line break
        /// - `code`: Computer code
        /// - `div`: Section
        /// - `h1-h6`: Headings
        /// - `i`, `em`: Italics
        /// - `li`: List element
        /// - `ol`: Numbered list
        /// - `p`: Paragraph
        /// - `ul`: Bullet list
        /// - `u`: Underline
        /// Supported HTML attributes include:
        /// - `align`: Alignment of the text content
        /// - `href`: Link destination
        /// - `rel`: Relationship between link's target and source
        /// - `target`: Place to open the linked document
        /// </summary>
        [JsonProperty("description_html", NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionHtml { get; }

        /// <summary>
        /// A server-generated plaintext version of the `description_html` field, without formatting tags.
        /// </summary>
        [JsonProperty("description_plaintext", NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionPlaintext { get; }

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
                ((this.ImageIds == null && other.ImageIds == null) || (this.ImageIds?.Equals(other.ImageIds) == true)) &&
                ((this.SortName == null && other.SortName == null) || (this.SortName?.Equals(other.SortName) == true)) &&
                ((this.DescriptionHtml == null && other.DescriptionHtml == null) || (this.DescriptionHtml?.Equals(other.DescriptionHtml) == true)) &&
                ((this.DescriptionPlaintext == null && other.DescriptionPlaintext == null) || (this.DescriptionPlaintext?.Equals(other.DescriptionPlaintext) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -135597555;
            hashCode = HashCode.Combine(this.Name, this.Description, this.Abbreviation, this.LabelColor, this.AvailableOnline, this.AvailableForPickup, this.AvailableElectronically);

            hashCode = HashCode.Combine(hashCode, this.CategoryId, this.TaxIds, this.ModifierListInfo, this.Variations, this.ProductType, this.SkipModifierScreen, this.ItemOptions);

            hashCode = HashCode.Combine(hashCode, this.ImageIds, this.SortName, this.DescriptionHtml, this.DescriptionPlaintext);

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
            toStringOutput.Add($"this.ImageIds = {(this.ImageIds == null ? "null" : $"[{string.Join(", ", this.ImageIds)} ]")}");
            toStringOutput.Add($"this.SortName = {(this.SortName == null ? "null" : this.SortName == string.Empty ? "" : this.SortName)}");
            toStringOutput.Add($"this.DescriptionHtml = {(this.DescriptionHtml == null ? "null" : this.DescriptionHtml == string.Empty ? "" : this.DescriptionHtml)}");
            toStringOutput.Add($"this.DescriptionPlaintext = {(this.DescriptionPlaintext == null ? "null" : this.DescriptionPlaintext == string.Empty ? "" : this.DescriptionPlaintext)}");
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
                .ImageIds(this.ImageIds)
                .SortName(this.SortName)
                .DescriptionHtml(this.DescriptionHtml)
                .DescriptionPlaintext(this.DescriptionPlaintext);
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
            private IList<string> imageIds;
            private string sortName;
            private string descriptionHtml;
            private string descriptionPlaintext;

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
             /// ImageIds.
             /// </summary>
             /// <param name="imageIds"> imageIds. </param>
             /// <returns> Builder. </returns>
            public Builder ImageIds(IList<string> imageIds)
            {
                this.imageIds = imageIds;
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
             /// DescriptionHtml.
             /// </summary>
             /// <param name="descriptionHtml"> descriptionHtml. </param>
             /// <returns> Builder. </returns>
            public Builder DescriptionHtml(string descriptionHtml)
            {
                this.descriptionHtml = descriptionHtml;
                return this;
            }

             /// <summary>
             /// DescriptionPlaintext.
             /// </summary>
             /// <param name="descriptionPlaintext"> descriptionPlaintext. </param>
             /// <returns> Builder. </returns>
            public Builder DescriptionPlaintext(string descriptionPlaintext)
            {
                this.descriptionPlaintext = descriptionPlaintext;
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
                    this.imageIds,
                    this.sortName,
                    this.descriptionHtml,
                    this.descriptionPlaintext);
            }
        }
    }
}