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
    /// CatalogItem.
    /// </summary>
    public class CatalogItem
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItem"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="description">description.</param>
        /// <param name="abbreviation">abbreviation.</param>
        /// <param name="labelColor">label_color.</param>
        /// <param name="isTaxable">is_taxable.</param>
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
        /// <param name="categories">categories.</param>
        /// <param name="descriptionHtml">description_html.</param>
        /// <param name="descriptionPlaintext">description_plaintext.</param>
        /// <param name="channels">channels.</param>
        /// <param name="isArchived">is_archived.</param>
        /// <param name="ecomSeoData">ecom_seo_data.</param>
        /// <param name="foodAndBeverageDetails">food_and_beverage_details.</param>
        /// <param name="reportingCategory">reporting_category.</param>
        public CatalogItem(
            string name = null,
            string description = null,
            string abbreviation = null,
            string labelColor = null,
            bool? isTaxable = null,
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
            IList<Models.CatalogObjectCategory> categories = null,
            string descriptionHtml = null,
            string descriptionPlaintext = null,
            IList<string> channels = null,
            bool? isArchived = null,
            Models.CatalogEcomSeoData ecomSeoData = null,
            Models.CatalogItemFoodAndBeverageDetails foodAndBeverageDetails = null,
            Models.CatalogObjectCategory reportingCategory = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "description", false },
                { "abbreviation", false },
                { "label_color", false },
                { "is_taxable", false },
                { "available_online", false },
                { "available_for_pickup", false },
                { "available_electronically", false },
                { "category_id", false },
                { "tax_ids", false },
                { "modifier_list_info", false },
                { "variations", false },
                { "skip_modifier_screen", false },
                { "item_options", false },
                { "image_ids", false },
                { "sort_name", false },
                { "categories", false },
                { "description_html", false },
                { "channels", false },
                { "is_archived", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (description != null)
            {
                shouldSerialize["description"] = true;
                this.Description = description;
            }

            if (abbreviation != null)
            {
                shouldSerialize["abbreviation"] = true;
                this.Abbreviation = abbreviation;
            }

            if (labelColor != null)
            {
                shouldSerialize["label_color"] = true;
                this.LabelColor = labelColor;
            }

            if (isTaxable != null)
            {
                shouldSerialize["is_taxable"] = true;
                this.IsTaxable = isTaxable;
            }

            if (availableOnline != null)
            {
                shouldSerialize["available_online"] = true;
                this.AvailableOnline = availableOnline;
            }

            if (availableForPickup != null)
            {
                shouldSerialize["available_for_pickup"] = true;
                this.AvailableForPickup = availableForPickup;
            }

            if (availableElectronically != null)
            {
                shouldSerialize["available_electronically"] = true;
                this.AvailableElectronically = availableElectronically;
            }

            if (categoryId != null)
            {
                shouldSerialize["category_id"] = true;
                this.CategoryId = categoryId;
            }

            if (taxIds != null)
            {
                shouldSerialize["tax_ids"] = true;
                this.TaxIds = taxIds;
            }

            if (modifierListInfo != null)
            {
                shouldSerialize["modifier_list_info"] = true;
                this.ModifierListInfo = modifierListInfo;
            }

            if (variations != null)
            {
                shouldSerialize["variations"] = true;
                this.Variations = variations;
            }

            this.ProductType = productType;
            if (skipModifierScreen != null)
            {
                shouldSerialize["skip_modifier_screen"] = true;
                this.SkipModifierScreen = skipModifierScreen;
            }

            if (itemOptions != null)
            {
                shouldSerialize["item_options"] = true;
                this.ItemOptions = itemOptions;
            }

            if (imageIds != null)
            {
                shouldSerialize["image_ids"] = true;
                this.ImageIds = imageIds;
            }

            if (sortName != null)
            {
                shouldSerialize["sort_name"] = true;
                this.SortName = sortName;
            }

            if (categories != null)
            {
                shouldSerialize["categories"] = true;
                this.Categories = categories;
            }

            if (descriptionHtml != null)
            {
                shouldSerialize["description_html"] = true;
                this.DescriptionHtml = descriptionHtml;
            }

            this.DescriptionPlaintext = descriptionPlaintext;
            if (channels != null)
            {
                shouldSerialize["channels"] = true;
                this.Channels = channels;
            }

            if (isArchived != null)
            {
                shouldSerialize["is_archived"] = true;
                this.IsArchived = isArchived;
            }

            this.EcomSeoData = ecomSeoData;
            this.FoodAndBeverageDetails = foodAndBeverageDetails;
            this.ReportingCategory = reportingCategory;
        }
        internal CatalogItem(Dictionary<string, bool> shouldSerialize,
            string name = null,
            string description = null,
            string abbreviation = null,
            string labelColor = null,
            bool? isTaxable = null,
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
            IList<Models.CatalogObjectCategory> categories = null,
            string descriptionHtml = null,
            string descriptionPlaintext = null,
            IList<string> channels = null,
            bool? isArchived = null,
            Models.CatalogEcomSeoData ecomSeoData = null,
            Models.CatalogItemFoodAndBeverageDetails foodAndBeverageDetails = null,
            Models.CatalogObjectCategory reportingCategory = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Description = description;
            Abbreviation = abbreviation;
            LabelColor = labelColor;
            IsTaxable = isTaxable;
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
            ImageIds = imageIds;
            SortName = sortName;
            Categories = categories;
            DescriptionHtml = descriptionHtml;
            DescriptionPlaintext = descriptionPlaintext;
            Channels = channels;
            IsArchived = isArchived;
            EcomSeoData = ecomSeoData;
            FoodAndBeverageDetails = foodAndBeverageDetails;
            ReportingCategory = reportingCategory;
        }

        /// <summary>
        /// The item's name. This is a searchable attribute for use in applicable query filters, its value must not be empty, and the length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The item's description. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// Deprecated at 2022-07-20, this field is planned to retire in 6 months. You should migrate to use `description_html` to set the description
        /// of the [CatalogItem](entity:CatalogItem) instance.  The `description` and `description_html` field values are kept in sync. If you try to
        /// set the both fields, the `description_html` text value overwrites the `description` value. Updates in one field are also reflected in the other,
        /// except for when you use an early version before Square API 2022-07-20 and `description_html` is set to blank, setting the `description` value to null
        /// does not nullify `description_html`.
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
        /// Indicates whether the item is taxable (`true`) or non-taxable (`false`). Default is `true`.
        /// </summary>
        [JsonProperty("is_taxable")]
        public bool? IsTaxable { get; }

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
        /// The ID of the item's category, if any. Deprecated since 2023-12-13. Use `CatalogItem.categories`, instead.
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
        /// A list of [CatalogItemVariation](entity:CatalogItemVariation) objects for this item. An item must have
        /// at least one variation.
        /// </summary>
        [JsonProperty("variations")]
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
        [JsonProperty("skip_modifier_screen")]
        public bool? SkipModifierScreen { get; }

        /// <summary>
        /// List of item options IDs for this item. Used to manage and group item
        /// variations in a specified order.
        /// Maximum: 6 item options.
        /// </summary>
        [JsonProperty("item_options")]
        public IList<Models.CatalogItemOptionForItem> ItemOptions { get; }

        /// <summary>
        /// The IDs of images associated with this `CatalogItem` instance.
        /// These images will be shown to customers in Square Online Store.
        /// The first image will show up as the icon for this item in POS.
        /// </summary>
        [JsonProperty("image_ids")]
        public IList<string> ImageIds { get; }

        /// <summary>
        /// A name to sort the item by. If this name is unspecified, namely, the `sort_name` field is absent, the regular `name` field is used for sorting.
        /// Its value must not be empty.
        /// It is currently supported for sellers of the Japanese locale only.
        /// </summary>
        [JsonProperty("sort_name")]
        public string SortName { get; }

        /// <summary>
        /// The list of categories.
        /// </summary>
        [JsonProperty("categories")]
        public IList<Models.CatalogObjectCategory> Categories { get; }

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
        [JsonProperty("description_html")]
        public string DescriptionHtml { get; }

        /// <summary>
        /// A server-generated plaintext version of the `description_html` field, without formatting tags.
        /// </summary>
        [JsonProperty("description_plaintext", NullValueHandling = NullValueHandling.Ignore)]
        public string DescriptionPlaintext { get; }

        /// <summary>
        /// A list of IDs representing channels, such as a Square Online site, where the item can be made visible or available.
        /// </summary>
        [JsonProperty("channels")]
        public IList<string> Channels { get; }

        /// <summary>
        /// Indicates whether this item is archived (`true`) or not (`false`).
        /// </summary>
        [JsonProperty("is_archived")]
        public bool? IsArchived { get; }

        /// <summary>
        /// SEO data for for a seller's Square Online store.
        /// </summary>
        [JsonProperty("ecom_seo_data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogEcomSeoData EcomSeoData { get; }

        /// <summary>
        /// The food and beverage-specific details of a `FOOD_AND_BEV` item.
        /// </summary>
        [JsonProperty("food_and_beverage_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogItemFoodAndBeverageDetails FoodAndBeverageDetails { get; }

        /// <summary>
        /// A category that can be assigned to an item or a parent category that can be assigned
        /// to another category. For example, a clothing category can be assigned to a t-shirt item or
        /// be made as the parent category to the pants category.
        /// </summary>
        [JsonProperty("reporting_category", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogObjectCategory ReportingCategory { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItem : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
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
        public bool ShouldSerializeAbbreviation()
        {
            return this.shouldSerialize["abbreviation"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLabelColor()
        {
            return this.shouldSerialize["label_color"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsTaxable()
        {
            return this.shouldSerialize["is_taxable"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAvailableOnline()
        {
            return this.shouldSerialize["available_online"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAvailableForPickup()
        {
            return this.shouldSerialize["available_for_pickup"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAvailableElectronically()
        {
            return this.shouldSerialize["available_electronically"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCategoryId()
        {
            return this.shouldSerialize["category_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxIds()
        {
            return this.shouldSerialize["tax_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModifierListInfo()
        {
            return this.shouldSerialize["modifier_list_info"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVariations()
        {
            return this.shouldSerialize["variations"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSkipModifierScreen()
        {
            return this.shouldSerialize["skip_modifier_screen"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemOptions()
        {
            return this.shouldSerialize["item_options"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeImageIds()
        {
            return this.shouldSerialize["image_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSortName()
        {
            return this.shouldSerialize["sort_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCategories()
        {
            return this.shouldSerialize["categories"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDescriptionHtml()
        {
            return this.shouldSerialize["description_html"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeChannels()
        {
            return this.shouldSerialize["channels"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsArchived()
        {
            return this.shouldSerialize["is_archived"];
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
            return obj is CatalogItem other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Description == null && other.Description == null) || (this.Description?.Equals(other.Description) == true)) &&
                ((this.Abbreviation == null && other.Abbreviation == null) || (this.Abbreviation?.Equals(other.Abbreviation) == true)) &&
                ((this.LabelColor == null && other.LabelColor == null) || (this.LabelColor?.Equals(other.LabelColor) == true)) &&
                ((this.IsTaxable == null && other.IsTaxable == null) || (this.IsTaxable?.Equals(other.IsTaxable) == true)) &&
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
                ((this.Categories == null && other.Categories == null) || (this.Categories?.Equals(other.Categories) == true)) &&
                ((this.DescriptionHtml == null && other.DescriptionHtml == null) || (this.DescriptionHtml?.Equals(other.DescriptionHtml) == true)) &&
                ((this.DescriptionPlaintext == null && other.DescriptionPlaintext == null) || (this.DescriptionPlaintext?.Equals(other.DescriptionPlaintext) == true)) &&
                ((this.Channels == null && other.Channels == null) || (this.Channels?.Equals(other.Channels) == true)) &&
                ((this.IsArchived == null && other.IsArchived == null) || (this.IsArchived?.Equals(other.IsArchived) == true)) &&
                ((this.EcomSeoData == null && other.EcomSeoData == null) || (this.EcomSeoData?.Equals(other.EcomSeoData) == true)) &&
                ((this.FoodAndBeverageDetails == null && other.FoodAndBeverageDetails == null) || (this.FoodAndBeverageDetails?.Equals(other.FoodAndBeverageDetails) == true)) &&
                ((this.ReportingCategory == null && other.ReportingCategory == null) || (this.ReportingCategory?.Equals(other.ReportingCategory) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -671057138;
            hashCode = HashCode.Combine(this.Name, this.Description, this.Abbreviation, this.LabelColor, this.IsTaxable, this.AvailableOnline, this.AvailableForPickup);

            hashCode = HashCode.Combine(hashCode, this.AvailableElectronically, this.CategoryId, this.TaxIds, this.ModifierListInfo, this.Variations, this.ProductType, this.SkipModifierScreen);

            hashCode = HashCode.Combine(hashCode, this.ItemOptions, this.ImageIds, this.SortName, this.Categories, this.DescriptionHtml, this.DescriptionPlaintext, this.Channels);

            hashCode = HashCode.Combine(hashCode, this.IsArchived, this.EcomSeoData, this.FoodAndBeverageDetails, this.ReportingCategory);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Description = {(this.Description == null ? "null" : this.Description)}");
            toStringOutput.Add($"this.Abbreviation = {(this.Abbreviation == null ? "null" : this.Abbreviation)}");
            toStringOutput.Add($"this.LabelColor = {(this.LabelColor == null ? "null" : this.LabelColor)}");
            toStringOutput.Add($"this.IsTaxable = {(this.IsTaxable == null ? "null" : this.IsTaxable.ToString())}");
            toStringOutput.Add($"this.AvailableOnline = {(this.AvailableOnline == null ? "null" : this.AvailableOnline.ToString())}");
            toStringOutput.Add($"this.AvailableForPickup = {(this.AvailableForPickup == null ? "null" : this.AvailableForPickup.ToString())}");
            toStringOutput.Add($"this.AvailableElectronically = {(this.AvailableElectronically == null ? "null" : this.AvailableElectronically.ToString())}");
            toStringOutput.Add($"this.CategoryId = {(this.CategoryId == null ? "null" : this.CategoryId)}");
            toStringOutput.Add($"this.TaxIds = {(this.TaxIds == null ? "null" : $"[{string.Join(", ", this.TaxIds)} ]")}");
            toStringOutput.Add($"this.ModifierListInfo = {(this.ModifierListInfo == null ? "null" : $"[{string.Join(", ", this.ModifierListInfo)} ]")}");
            toStringOutput.Add($"this.Variations = {(this.Variations == null ? "null" : $"[{string.Join(", ", this.Variations)} ]")}");
            toStringOutput.Add($"this.ProductType = {(this.ProductType == null ? "null" : this.ProductType.ToString())}");
            toStringOutput.Add($"this.SkipModifierScreen = {(this.SkipModifierScreen == null ? "null" : this.SkipModifierScreen.ToString())}");
            toStringOutput.Add($"this.ItemOptions = {(this.ItemOptions == null ? "null" : $"[{string.Join(", ", this.ItemOptions)} ]")}");
            toStringOutput.Add($"this.ImageIds = {(this.ImageIds == null ? "null" : $"[{string.Join(", ", this.ImageIds)} ]")}");
            toStringOutput.Add($"this.SortName = {(this.SortName == null ? "null" : this.SortName)}");
            toStringOutput.Add($"this.Categories = {(this.Categories == null ? "null" : $"[{string.Join(", ", this.Categories)} ]")}");
            toStringOutput.Add($"this.DescriptionHtml = {(this.DescriptionHtml == null ? "null" : this.DescriptionHtml)}");
            toStringOutput.Add($"this.DescriptionPlaintext = {(this.DescriptionPlaintext == null ? "null" : this.DescriptionPlaintext)}");
            toStringOutput.Add($"this.Channels = {(this.Channels == null ? "null" : $"[{string.Join(", ", this.Channels)} ]")}");
            toStringOutput.Add($"this.IsArchived = {(this.IsArchived == null ? "null" : this.IsArchived.ToString())}");
            toStringOutput.Add($"this.EcomSeoData = {(this.EcomSeoData == null ? "null" : this.EcomSeoData.ToString())}");
            toStringOutput.Add($"this.FoodAndBeverageDetails = {(this.FoodAndBeverageDetails == null ? "null" : this.FoodAndBeverageDetails.ToString())}");
            toStringOutput.Add($"this.ReportingCategory = {(this.ReportingCategory == null ? "null" : this.ReportingCategory.ToString())}");
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
                .IsTaxable(this.IsTaxable)
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
                .Categories(this.Categories)
                .DescriptionHtml(this.DescriptionHtml)
                .DescriptionPlaintext(this.DescriptionPlaintext)
                .Channels(this.Channels)
                .IsArchived(this.IsArchived)
                .EcomSeoData(this.EcomSeoData)
                .FoodAndBeverageDetails(this.FoodAndBeverageDetails)
                .ReportingCategory(this.ReportingCategory);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "description", false },
                { "abbreviation", false },
                { "label_color", false },
                { "is_taxable", false },
                { "available_online", false },
                { "available_for_pickup", false },
                { "available_electronically", false },
                { "category_id", false },
                { "tax_ids", false },
                { "modifier_list_info", false },
                { "variations", false },
                { "skip_modifier_screen", false },
                { "item_options", false },
                { "image_ids", false },
                { "sort_name", false },
                { "categories", false },
                { "description_html", false },
                { "channels", false },
                { "is_archived", false },
            };

            private string name;
            private string description;
            private string abbreviation;
            private string labelColor;
            private bool? isTaxable;
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
            private IList<Models.CatalogObjectCategory> categories;
            private string descriptionHtml;
            private string descriptionPlaintext;
            private IList<string> channels;
            private bool? isArchived;
            private Models.CatalogEcomSeoData ecomSeoData;
            private Models.CatalogItemFoodAndBeverageDetails foodAndBeverageDetails;
            private Models.CatalogObjectCategory reportingCategory;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
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
                shouldSerialize["description"] = true;
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
                shouldSerialize["abbreviation"] = true;
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
                shouldSerialize["label_color"] = true;
                this.labelColor = labelColor;
                return this;
            }

             /// <summary>
             /// IsTaxable.
             /// </summary>
             /// <param name="isTaxable"> isTaxable. </param>
             /// <returns> Builder. </returns>
            public Builder IsTaxable(bool? isTaxable)
            {
                shouldSerialize["is_taxable"] = true;
                this.isTaxable = isTaxable;
                return this;
            }

             /// <summary>
             /// AvailableOnline.
             /// </summary>
             /// <param name="availableOnline"> availableOnline. </param>
             /// <returns> Builder. </returns>
            public Builder AvailableOnline(bool? availableOnline)
            {
                shouldSerialize["available_online"] = true;
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
                shouldSerialize["available_for_pickup"] = true;
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
                shouldSerialize["available_electronically"] = true;
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
                shouldSerialize["category_id"] = true;
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
                shouldSerialize["tax_ids"] = true;
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
                shouldSerialize["modifier_list_info"] = true;
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
                shouldSerialize["variations"] = true;
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
                shouldSerialize["skip_modifier_screen"] = true;
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
                shouldSerialize["item_options"] = true;
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
                shouldSerialize["image_ids"] = true;
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
                shouldSerialize["sort_name"] = true;
                this.sortName = sortName;
                return this;
            }

             /// <summary>
             /// Categories.
             /// </summary>
             /// <param name="categories"> categories. </param>
             /// <returns> Builder. </returns>
            public Builder Categories(IList<Models.CatalogObjectCategory> categories)
            {
                shouldSerialize["categories"] = true;
                this.categories = categories;
                return this;
            }

             /// <summary>
             /// DescriptionHtml.
             /// </summary>
             /// <param name="descriptionHtml"> descriptionHtml. </param>
             /// <returns> Builder. </returns>
            public Builder DescriptionHtml(string descriptionHtml)
            {
                shouldSerialize["description_html"] = true;
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
             /// Channels.
             /// </summary>
             /// <param name="channels"> channels. </param>
             /// <returns> Builder. </returns>
            public Builder Channels(IList<string> channels)
            {
                shouldSerialize["channels"] = true;
                this.channels = channels;
                return this;
            }

             /// <summary>
             /// IsArchived.
             /// </summary>
             /// <param name="isArchived"> isArchived. </param>
             /// <returns> Builder. </returns>
            public Builder IsArchived(bool? isArchived)
            {
                shouldSerialize["is_archived"] = true;
                this.isArchived = isArchived;
                return this;
            }

             /// <summary>
             /// EcomSeoData.
             /// </summary>
             /// <param name="ecomSeoData"> ecomSeoData. </param>
             /// <returns> Builder. </returns>
            public Builder EcomSeoData(Models.CatalogEcomSeoData ecomSeoData)
            {
                this.ecomSeoData = ecomSeoData;
                return this;
            }

             /// <summary>
             /// FoodAndBeverageDetails.
             /// </summary>
             /// <param name="foodAndBeverageDetails"> foodAndBeverageDetails. </param>
             /// <returns> Builder. </returns>
            public Builder FoodAndBeverageDetails(Models.CatalogItemFoodAndBeverageDetails foodAndBeverageDetails)
            {
                this.foodAndBeverageDetails = foodAndBeverageDetails;
                return this;
            }

             /// <summary>
             /// ReportingCategory.
             /// </summary>
             /// <param name="reportingCategory"> reportingCategory. </param>
             /// <returns> Builder. </returns>
            public Builder ReportingCategory(Models.CatalogObjectCategory reportingCategory)
            {
                this.reportingCategory = reportingCategory;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
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
            public void UnsetAbbreviation()
            {
                this.shouldSerialize["abbreviation"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLabelColor()
            {
                this.shouldSerialize["label_color"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsTaxable()
            {
                this.shouldSerialize["is_taxable"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAvailableOnline()
            {
                this.shouldSerialize["available_online"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAvailableForPickup()
            {
                this.shouldSerialize["available_for_pickup"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAvailableElectronically()
            {
                this.shouldSerialize["available_electronically"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCategoryId()
            {
                this.shouldSerialize["category_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTaxIds()
            {
                this.shouldSerialize["tax_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetModifierListInfo()
            {
                this.shouldSerialize["modifier_list_info"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetVariations()
            {
                this.shouldSerialize["variations"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSkipModifierScreen()
            {
                this.shouldSerialize["skip_modifier_screen"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetItemOptions()
            {
                this.shouldSerialize["item_options"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetImageIds()
            {
                this.shouldSerialize["image_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSortName()
            {
                this.shouldSerialize["sort_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCategories()
            {
                this.shouldSerialize["categories"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDescriptionHtml()
            {
                this.shouldSerialize["description_html"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetChannels()
            {
                this.shouldSerialize["channels"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsArchived()
            {
                this.shouldSerialize["is_archived"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItem. </returns>
            public CatalogItem Build()
            {
                return new CatalogItem(shouldSerialize,
                    this.name,
                    this.description,
                    this.abbreviation,
                    this.labelColor,
                    this.isTaxable,
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
                    this.categories,
                    this.descriptionHtml,
                    this.descriptionPlaintext,
                    this.channels,
                    this.isArchived,
                    this.ecomSeoData,
                    this.foodAndBeverageDetails,
                    this.reportingCategory);
            }
        }
    }
}