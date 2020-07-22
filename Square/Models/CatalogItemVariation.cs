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
    public class CatalogItemVariation 
    {
        public CatalogItemVariation(string itemId = null,
            string name = null,
            string sku = null,
            string upc = null,
            int? ordinal = null,
            string pricingType = null,
            Models.Money priceMoney = null,
            IList<Models.ItemVariationLocationOverrides> locationOverrides = null,
            bool? trackInventory = null,
            string inventoryAlertType = null,
            long? inventoryAlertThreshold = null,
            string userData = null,
            long? serviceDuration = null,
            IList<Models.CatalogItemOptionValueForItemVariation> itemOptionValues = null,
            string measurementUnitId = null)
        {
            ItemId = itemId;
            Name = name;
            Sku = sku;
            Upc = upc;
            Ordinal = ordinal;
            PricingType = pricingType;
            PriceMoney = priceMoney;
            LocationOverrides = locationOverrides;
            TrackInventory = trackInventory;
            InventoryAlertType = inventoryAlertType;
            InventoryAlertThreshold = inventoryAlertThreshold;
            UserData = userData;
            ServiceDuration = serviceDuration;
            ItemOptionValues = itemOptionValues;
            MeasurementUnitId = measurementUnitId;
        }

        /// <summary>
        /// The ID of the `CatalogItem` associated with this item variation.
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; }

        /// <summary>
        /// The item variation's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The item variation's SKU, if any. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; }

        /// <summary>
        /// The item variation's UPC, if any. This is a searchable attribute for use in applicable query filters.
        /// It is only accessible through the Square API, and not exposed in the Square Seller Dashboard,
        /// Square Point of Sale or Retail Point of Sale apps.
        /// </summary>
        [JsonProperty("upc")]
        public string Upc { get; }

        /// <summary>
        /// The order in which this item variation should be displayed. This value is read-only. On writes, the ordinal
        /// for each item variation within a parent `CatalogItem` is set according to the item variations's
        /// position. On reads, the value is not guaranteed to be sequential or unique.
        /// </summary>
        [JsonProperty("ordinal")]
        public int? Ordinal { get; }

        /// <summary>
        /// Indicates whether the price of a CatalogItemVariation should be entered manually at the time of sale.
        /// </summary>
        [JsonProperty("pricing_type")]
        public string PricingType { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("price_money")]
        public Models.Money PriceMoney { get; }

        /// <summary>
        /// Per-location price and inventory overrides.
        /// </summary>
        [JsonProperty("location_overrides")]
        public IList<Models.ItemVariationLocationOverrides> LocationOverrides { get; }

        /// <summary>
        /// If `true`, inventory tracking is active for the variation.
        /// </summary>
        [JsonProperty("track_inventory")]
        public bool? TrackInventory { get; }

        /// <summary>
        /// Indicates whether Square should alert the merchant when the inventory quantity of a CatalogItemVariation is low.
        /// </summary>
        [JsonProperty("inventory_alert_type")]
        public string InventoryAlertType { get; }

        /// <summary>
        /// If the inventory quantity for the variation is less than or equal to this value and `inventory_alert_type`
        /// is `LOW_QUANTITY`, the variation displays an alert in the merchant dashboard.
        /// This value is always an integer.
        /// </summary>
        [JsonProperty("inventory_alert_threshold")]
        public long? InventoryAlertThreshold { get; }

        /// <summary>
        /// Arbitrary user metadata to associate with the item variation. This attribute value length is of Unicode code points.
        /// </summary>
        [JsonProperty("user_data")]
        public string UserData { get; }

        /// <summary>
        /// If the `CatalogItem` that owns this item variation is of type
        /// `APPOINTMENTS_SERVICE`, then this is the duration of the service in milliseconds. For
        /// example, a 30 minute appointment would have the value `1800000`, which is equal to
        /// 30 (minutes) * 60 (seconds per minute) * 1000 (milliseconds per second).
        /// </summary>
        [JsonProperty("service_duration")]
        public long? ServiceDuration { get; }

        /// <summary>
        /// List of item option values associated with this item variation. Listed
        /// in the same order as the item options of the parent item.
        /// </summary>
        [JsonProperty("item_option_values")]
        public IList<Models.CatalogItemOptionValueForItemVariation> ItemOptionValues { get; }

        /// <summary>
        /// ID of the ‘CatalogMeasurementUnit’ that is used to measure the quantity
        /// sold of this item variation. If left unset, the item will be sold in
        /// whole quantities.
        /// </summary>
        [JsonProperty("measurement_unit_id")]
        public string MeasurementUnitId { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemId(ItemId)
                .Name(Name)
                .Sku(Sku)
                .Upc(Upc)
                .Ordinal(Ordinal)
                .PricingType(PricingType)
                .PriceMoney(PriceMoney)
                .LocationOverrides(LocationOverrides)
                .TrackInventory(TrackInventory)
                .InventoryAlertType(InventoryAlertType)
                .InventoryAlertThreshold(InventoryAlertThreshold)
                .UserData(UserData)
                .ServiceDuration(ServiceDuration)
                .ItemOptionValues(ItemOptionValues)
                .MeasurementUnitId(MeasurementUnitId);
            return builder;
        }

        public class Builder
        {
            private string itemId;
            private string name;
            private string sku;
            private string upc;
            private int? ordinal;
            private string pricingType;
            private Models.Money priceMoney;
            private IList<Models.ItemVariationLocationOverrides> locationOverrides = new List<Models.ItemVariationLocationOverrides>();
            private bool? trackInventory;
            private string inventoryAlertType;
            private long? inventoryAlertThreshold;
            private string userData;
            private long? serviceDuration;
            private IList<Models.CatalogItemOptionValueForItemVariation> itemOptionValues = new List<Models.CatalogItemOptionValueForItemVariation>();
            private string measurementUnitId;

            public Builder() { }
            public Builder ItemId(string value)
            {
                itemId = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder Sku(string value)
            {
                sku = value;
                return this;
            }

            public Builder Upc(string value)
            {
                upc = value;
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

            public Builder PriceMoney(Models.Money value)
            {
                priceMoney = value;
                return this;
            }

            public Builder LocationOverrides(IList<Models.ItemVariationLocationOverrides> value)
            {
                locationOverrides = value;
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

            public Builder InventoryAlertThreshold(long? value)
            {
                inventoryAlertThreshold = value;
                return this;
            }

            public Builder UserData(string value)
            {
                userData = value;
                return this;
            }

            public Builder ServiceDuration(long? value)
            {
                serviceDuration = value;
                return this;
            }

            public Builder ItemOptionValues(IList<Models.CatalogItemOptionValueForItemVariation> value)
            {
                itemOptionValues = value;
                return this;
            }

            public Builder MeasurementUnitId(string value)
            {
                measurementUnitId = value;
                return this;
            }

            public CatalogItemVariation Build()
            {
                return new CatalogItemVariation(itemId,
                    name,
                    sku,
                    upc,
                    ordinal,
                    pricingType,
                    priceMoney,
                    locationOverrides,
                    trackInventory,
                    inventoryAlertType,
                    inventoryAlertThreshold,
                    userData,
                    serviceDuration,
                    itemOptionValues,
                    measurementUnitId);
            }
        }
    }
}