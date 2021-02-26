
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ItemVariationLocationOverrides : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"PriceMoney = {(PriceMoney == null ? "null" : PriceMoney.ToString())}");
            toStringOutput.Add($"PricingType = {(PricingType == null ? "null" : PricingType.ToString())}");
            toStringOutput.Add($"TrackInventory = {(TrackInventory == null ? "null" : TrackInventory.ToString())}");
            toStringOutput.Add($"InventoryAlertType = {(InventoryAlertType == null ? "null" : InventoryAlertType.ToString())}");
            toStringOutput.Add($"InventoryAlertThreshold = {(InventoryAlertThreshold == null ? "null" : InventoryAlertThreshold.ToString())}");
        }

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

            return obj is ItemVariationLocationOverrides other &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((PriceMoney == null && other.PriceMoney == null) || (PriceMoney?.Equals(other.PriceMoney) == true)) &&
                ((PricingType == null && other.PricingType == null) || (PricingType?.Equals(other.PricingType) == true)) &&
                ((TrackInventory == null && other.TrackInventory == null) || (TrackInventory?.Equals(other.TrackInventory) == true)) &&
                ((InventoryAlertType == null && other.InventoryAlertType == null) || (InventoryAlertType?.Equals(other.InventoryAlertType) == true)) &&
                ((InventoryAlertThreshold == null && other.InventoryAlertThreshold == null) || (InventoryAlertThreshold?.Equals(other.InventoryAlertThreshold) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -598612092;

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (PriceMoney != null)
            {
               hashCode += PriceMoney.GetHashCode();
            }

            if (PricingType != null)
            {
               hashCode += PricingType.GetHashCode();
            }

            if (TrackInventory != null)
            {
               hashCode += TrackInventory.GetHashCode();
            }

            if (InventoryAlertType != null)
            {
               hashCode += InventoryAlertType.GetHashCode();
            }

            if (InventoryAlertThreshold != null)
            {
               hashCode += InventoryAlertThreshold.GetHashCode();
            }

            return hashCode;
        }

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