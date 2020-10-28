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
    public class ItemVariationLocationOverrides 
    {
        public ItemVariationLocationOverrides(string locationId = null,
            Models.Money priceMoney = null,
            string pricingType = null,
            bool? trackInventory = null,
            string inventoryAlertType = null,
            long? inventoryAlertThreshold = null)
        {
            LocationId = locationId;
            PriceMoney = priceMoney;
            PricingType = pricingType;
            TrackInventory = trackInventory;
            InventoryAlertType = inventoryAlertType;
            InventoryAlertThreshold = inventoryAlertThreshold;
        }

        /// <summary>
        /// The ID of the `Location`.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money PriceMoney { get; }

        /// <summary>
        /// Indicates whether the price of a CatalogItemVariation should be entered manually at the time of sale.
        /// </summary>
        [JsonProperty("pricing_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PricingType { get; }

        /// <summary>
        /// If `true`, inventory tracking is active for the `CatalogItemVariation` at this `Location`.
        /// </summary>
        [JsonProperty("track_inventory", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TrackInventory { get; }

        /// <summary>
        /// Indicates whether Square should alert the merchant when the inventory quantity of a CatalogItemVariation is low.
        /// </summary>
        [JsonProperty("inventory_alert_type", NullValueHandling = NullValueHandling.Ignore)]
        public string InventoryAlertType { get; }

        /// <summary>
        /// If the inventory quantity for the variation is less than or equal to this value and `inventory_alert_type`
        /// is `LOW_QUANTITY`, the variation displays an alert in the merchant dashboard.
        /// This value is always an integer.
        /// </summary>
        [JsonProperty("inventory_alert_threshold", NullValueHandling = NullValueHandling.Ignore)]
        public long? InventoryAlertThreshold { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(LocationId)
                .PriceMoney(PriceMoney)
                .PricingType(PricingType)
                .TrackInventory(TrackInventory)
                .InventoryAlertType(InventoryAlertType)
                .InventoryAlertThreshold(InventoryAlertThreshold);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private Models.Money priceMoney;
            private string pricingType;
            private bool? trackInventory;
            private string inventoryAlertType;
            private long? inventoryAlertThreshold;



            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder PriceMoney(Models.Money priceMoney)
            {
                this.priceMoney = priceMoney;
                return this;
            }

            public Builder PricingType(string pricingType)
            {
                this.pricingType = pricingType;
                return this;
            }

            public Builder TrackInventory(bool? trackInventory)
            {
                this.trackInventory = trackInventory;
                return this;
            }

            public Builder InventoryAlertType(string inventoryAlertType)
            {
                this.inventoryAlertType = inventoryAlertType;
                return this;
            }

            public Builder InventoryAlertThreshold(long? inventoryAlertThreshold)
            {
                this.inventoryAlertThreshold = inventoryAlertThreshold;
                return this;
            }

            public ItemVariationLocationOverrides Build()
            {
                return new ItemVariationLocationOverrides(locationId,
                    priceMoney,
                    pricingType,
                    trackInventory,
                    inventoryAlertType,
                    inventoryAlertThreshold);
            }
        }
    }
}