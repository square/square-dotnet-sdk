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
    public class V1Variation 
    {
        public V1Variation(string id = null,
            string name = null,
            string itemId = null,
            int? ordinal = null,
            string pricingType = null,
            Models.V1Money priceMoney = null,
            string sku = null,
            bool? trackInventory = null,
            string inventoryAlertType = null,
            int? inventoryAlertThreshold = null,
            string userData = null,
            string v2Id = null)
        {
            Id = id;
            Name = name;
            ItemId = itemId;
            Ordinal = ordinal;
            PricingType = pricingType;
            PriceMoney = priceMoney;
            Sku = sku;
            TrackInventory = trackInventory;
            InventoryAlertType = inventoryAlertType;
            InventoryAlertThreshold = inventoryAlertThreshold;
            UserData = userData;
            V2Id = v2Id;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The item variation's unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The item variation's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The ID of the variation's associated item.
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; }

        /// <summary>
        /// Indicates the variation's list position when displayed in Square Point of Sale and the merchant dashboard. If more than one variation for the same item has the same ordinal value, those variations are displayed in alphabetical order
        /// </summary>
        [JsonProperty("ordinal")]
        public int? Ordinal { get; }

        /// <summary>
        /// Getter for pricing_type
        /// </summary>
        [JsonProperty("pricing_type")]
        public string PricingType { get; }

        /// <summary>
        /// Getter for price_money
        /// </summary>
        [JsonProperty("price_money")]
        public Models.V1Money PriceMoney { get; }

        /// <summary>
        /// The item variation's SKU, if any.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; }

        /// <summary>
        /// If true, inventory tracking is active for the variation.
        /// </summary>
        [JsonProperty("track_inventory")]
        public bool? TrackInventory { get; }

        /// <summary>
        /// Getter for inventory_alert_type
        /// </summary>
        [JsonProperty("inventory_alert_type")]
        public string InventoryAlertType { get; }

        /// <summary>
        /// If the inventory quantity for the variation is less than or equal to this value and inventory_alert_type is LOW_QUANTITY, the variation displays an alert in the merchant dashboard.
        /// </summary>
        [JsonProperty("inventory_alert_threshold")]
        public int? InventoryAlertThreshold { get; }

        /// <summary>
        /// Arbitrary metadata associated with the variation. Cannot exceed 255 characters.
        /// </summary>
        [JsonProperty("user_data")]
        public string UserData { get; }

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
                .ItemId(ItemId)
                .Ordinal(Ordinal)
                .PricingType(PricingType)
                .PriceMoney(PriceMoney)
                .Sku(Sku)
                .TrackInventory(TrackInventory)
                .InventoryAlertType(InventoryAlertType)
                .InventoryAlertThreshold(InventoryAlertThreshold)
                .UserData(UserData)
                .V2Id(V2Id);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string name;
            private string itemId;
            private int? ordinal;
            private string pricingType;
            private Models.V1Money priceMoney;
            private string sku;
            private bool? trackInventory;
            private string inventoryAlertType;
            private int? inventoryAlertThreshold;
            private string userData;
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

            public Builder ItemId(string value)
            {
                itemId = value;
                return this;
            }

            public Builder Ordinal(int? value)
            {
                ordinal = value;
                return this;
            }

            public Builder PricingType(string value)
            {
                pricingType = value;
                return this;
            }

            public Builder PriceMoney(Models.V1Money value)
            {
                priceMoney = value;
                return this;
            }

            public Builder Sku(string value)
            {
                sku = value;
                return this;
            }

            public Builder TrackInventory(bool? value)
            {
                trackInventory = value;
                return this;
            }

            public Builder InventoryAlertType(string value)
            {
                inventoryAlertType = value;
                return this;
            }

            public Builder InventoryAlertThreshold(int? value)
            {
                inventoryAlertThreshold = value;
                return this;
            }

            public Builder UserData(string value)
            {
                userData = value;
                return this;
            }

            public Builder V2Id(string value)
            {
                v2Id = value;
                return this;
            }

            public V1Variation Build()
            {
                return new V1Variation(id,
                    name,
                    itemId,
                    ordinal,
                    pricingType,
                    priceMoney,
                    sku,
                    trackInventory,
                    inventoryAlertType,
                    inventoryAlertThreshold,
                    userData,
                    v2Id);
            }
        }
    }
}