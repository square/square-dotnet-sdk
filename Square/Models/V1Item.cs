using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Item 
    {
        public V1Item(string id = null,
            string name = null,
            string description = null,
            string type = null,
            string color = null,
            string abbreviation = null,
            string visibility = null,
            bool? availableOnline = null,
            Models.V1ItemImage masterImage = null,
            Models.V1Category category = null,
            IList<Models.V1Variation> variations = null,
            IList<Models.V1ModifierList> modifierLists = null,
            IList<Models.V1Fee> fees = null,
            bool? taxable = null,
            string categoryId = null,
            bool? availableForPickup = null,
            string v2Id = null)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Color = color;
            Abbreviation = abbreviation;
            Visibility = visibility;
            AvailableOnline = availableOnline;
            MasterImage = masterImage;
            Category = category;
            Variations = variations;
            ModifierLists = modifierLists;
            Fees = fees;
            Taxable = taxable;
            CategoryId = categoryId;
            AvailableForPickup = availableForPickup;
            V2Id = v2Id;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The item's ID. Must be unique among all entity IDs ever provided on behalf of the merchant. You can never reuse an ID. This value can include alphanumeric characters, dashes (-), and underscores (_).
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The item's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The item's description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Getter for color
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; }

        /// <summary>
        /// The text of the item's display label in Square Point of Sale. Only up to the first five characters of the string are used.
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; }

        /// <summary>
        /// Getter for visibility
        /// </summary>
        [JsonProperty("visibility")]
        public string Visibility { get; }

        /// <summary>
        /// If true, the item can be added to shipping orders from the merchant's online store.
        /// </summary>
        [JsonProperty("available_online")]
        public bool? AvailableOnline { get; }

        /// <summary>
        /// V1ItemImage
        /// </summary>
        [JsonProperty("master_image")]
        public Models.V1ItemImage MasterImage { get; }

        /// <summary>
        /// V1Category
        /// </summary>
        [JsonProperty("category")]
        public Models.V1Category Category { get; }

        /// <summary>
        /// The item's variations. You must specify at least one variation.
        /// </summary>
        [JsonProperty("variations")]
        public IList<Models.V1Variation> Variations { get; }

        /// <summary>
        /// The modifier lists that apply to the item, if any.
        /// </summary>
        [JsonProperty("modifier_lists")]
        public IList<Models.V1ModifierList> ModifierLists { get; }

        /// <summary>
        /// The fees that apply to the item, if any.
        /// </summary>
        [JsonProperty("fees")]
        public IList<Models.V1Fee> Fees { get; }

        /// <summary>
        /// Deprecated. This field is not used.
        /// </summary>
        [JsonProperty("taxable")]
        public bool? Taxable { get; }

        /// <summary>
        /// The ID of the item's category, if any.
        /// </summary>
        [JsonProperty("category_id")]
        public string CategoryId { get; }

        /// <summary>
        /// If true, the item can be added to pickup orders from the merchant's online store. Default value: false
        /// </summary>
        [JsonProperty("available_for_pickup")]
        public bool? AvailableForPickup { get; }

        /// <summary>
        /// The ID of the CatalogObject in the Connect v2 API. Objects that are shared across multiple locations share the same v2 ID.
        /// </summary>
        [JsonProperty("v2_id")]
        public string V2Id { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .Name(Name)
                .Description(Description)
                .Type(Type)
                .Color(Color)
                .Abbreviation(Abbreviation)
                .Visibility(Visibility)
                .AvailableOnline(AvailableOnline)
                .MasterImage(MasterImage)
                .Category(Category)
                .Variations(Variations)
                .ModifierLists(ModifierLists)
                .Fees(Fees)
                .Taxable(Taxable)
                .CategoryId(CategoryId)
                .AvailableForPickup(AvailableForPickup)
                .V2Id(V2Id);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private string description;
            private string type;
            private string color;
            private string abbreviation;
            private string visibility;
            private bool? availableOnline;
            private Models.V1ItemImage masterImage;
            private Models.V1Category category;
            private IList<Models.V1Variation> variations = new List<Models.V1Variation>();
            private IList<Models.V1ModifierList> modifierLists = new List<Models.V1ModifierList>();
            private IList<Models.V1Fee> fees = new List<Models.V1Fee>();
            private bool? taxable;
            private string categoryId;
            private bool? availableForPickup;
            private string v2Id;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

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

            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public Builder Color(string value)
            {
                color = value;
                return this;
            }

            public Builder Abbreviation(string value)
            {
                abbreviation = value;
                return this;
            }

            public Builder Visibility(string value)
            {
                visibility = value;
                return this;
            }

            public Builder AvailableOnline(bool? value)
            {
                availableOnline = value;
                return this;
            }

            public Builder MasterImage(Models.V1ItemImage value)
            {
                masterImage = value;
                return this;
            }

            public Builder Category(Models.V1Category value)
            {
                category = value;
                return this;
            }

            public Builder Variations(IList<Models.V1Variation> value)
            {
                variations = value;
                return this;
            }

            public Builder ModifierLists(IList<Models.V1ModifierList> value)
            {
                modifierLists = value;
                return this;
            }

            public Builder Fees(IList<Models.V1Fee> value)
            {
                fees = value;
                return this;
            }

            public Builder Taxable(bool? value)
            {
                taxable = value;
                return this;
            }

            public Builder CategoryId(string value)
            {
                categoryId = value;
                return this;
            }

            public Builder AvailableForPickup(bool? value)
            {
                availableForPickup = value;
                return this;
            }

            public Builder V2Id(string value)
            {
                v2Id = value;
                return this;
            }

            public V1Item Build()
            {
                return new V1Item(id,
                    name,
                    description,
                    type,
                    color,
                    abbreviation,
                    visibility,
                    availableOnline,
                    masterImage,
                    category,
                    variations,
                    modifierLists,
                    fees,
                    taxable,
                    categoryId,
                    availableForPickup,
                    v2Id);
            }
        }
    }
}