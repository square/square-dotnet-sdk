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
    /// ItemVariationLocationOverrides.
    /// </summary>
    public class ItemVariationLocationOverrides
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemVariationLocationOverrides"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="priceMoney">price_money.</param>
        /// <param name="pricingType">pricing_type.</param>
        /// <param name="trackInventory">track_inventory.</param>
        /// <param name="inventoryAlertType">inventory_alert_type.</param>
        /// <param name="inventoryAlertThreshold">inventory_alert_threshold.</param>
        public ItemVariationLocationOverrides(
            string locationId = null,
            Models.Money priceMoney = null,
            string pricingType = null,
            bool? trackInventory = null,
            string inventoryAlertType = null,
            long? inventoryAlertThreshold = null)
        {
            this.LocationId = locationId;
            this.PriceMoney = priceMoney;
            this.PricingType = pricingType;
            this.TrackInventory = trackInventory;
            this.InventoryAlertType = inventoryAlertType;
            this.InventoryAlertThreshold = inventoryAlertThreshold;
        }

        /// <summary>
        /// The ID of the `Location`. This can include locations that are deactivated.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ItemVariationLocationOverrides : ({string.Join(", ", toStringOutput)})";
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

            return obj is ItemVariationLocationOverrides other &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.PriceMoney == null && other.PriceMoney == null) || (this.PriceMoney?.Equals(other.PriceMoney) == true)) &&
                ((this.PricingType == null && other.PricingType == null) || (this.PricingType?.Equals(other.PricingType) == true)) &&
                ((this.TrackInventory == null && other.TrackInventory == null) || (this.TrackInventory?.Equals(other.TrackInventory) == true)) &&
                ((this.InventoryAlertType == null && other.InventoryAlertType == null) || (this.InventoryAlertType?.Equals(other.InventoryAlertType) == true)) &&
                ((this.InventoryAlertThreshold == null && other.InventoryAlertThreshold == null) || (this.InventoryAlertThreshold?.Equals(other.InventoryAlertThreshold) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -598612092;
            hashCode = HashCode.Combine(this.LocationId, this.PriceMoney, this.PricingType, this.TrackInventory, this.InventoryAlertType, this.InventoryAlertThreshold);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.PriceMoney = {(this.PriceMoney == null ? "null" : this.PriceMoney.ToString())}");
            toStringOutput.Add($"this.PricingType = {(this.PricingType == null ? "null" : this.PricingType.ToString())}");
            toStringOutput.Add($"this.TrackInventory = {(this.TrackInventory == null ? "null" : this.TrackInventory.ToString())}");
            toStringOutput.Add($"this.InventoryAlertType = {(this.InventoryAlertType == null ? "null" : this.InventoryAlertType.ToString())}");
            toStringOutput.Add($"this.InventoryAlertThreshold = {(this.InventoryAlertThreshold == null ? "null" : this.InventoryAlertThreshold.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(this.LocationId)
                .PriceMoney(this.PriceMoney)
                .PricingType(this.PricingType)
                .TrackInventory(this.TrackInventory)
                .InventoryAlertType(this.InventoryAlertType)
                .InventoryAlertThreshold(this.InventoryAlertThreshold);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string locationId;
            private Models.Money priceMoney;
            private string pricingType;
            private bool? trackInventory;
            private string inventoryAlertType;
            private long? inventoryAlertThreshold;

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// PriceMoney.
             /// </summary>
             /// <param name="priceMoney"> priceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder PriceMoney(Models.Money priceMoney)
            {
                this.priceMoney = priceMoney;
                return this;
            }

             /// <summary>
             /// PricingType.
             /// </summary>
             /// <param name="pricingType"> pricingType. </param>
             /// <returns> Builder. </returns>
            public Builder PricingType(string pricingType)
            {
                this.pricingType = pricingType;
                return this;
            }

             /// <summary>
             /// TrackInventory.
             /// </summary>
             /// <param name="trackInventory"> trackInventory. </param>
             /// <returns> Builder. </returns>
            public Builder TrackInventory(bool? trackInventory)
            {
                this.trackInventory = trackInventory;
                return this;
            }

             /// <summary>
             /// InventoryAlertType.
             /// </summary>
             /// <param name="inventoryAlertType"> inventoryAlertType. </param>
             /// <returns> Builder. </returns>
            public Builder InventoryAlertType(string inventoryAlertType)
            {
                this.inventoryAlertType = inventoryAlertType;
                return this;
            }

             /// <summary>
             /// InventoryAlertThreshold.
             /// </summary>
             /// <param name="inventoryAlertThreshold"> inventoryAlertThreshold. </param>
             /// <returns> Builder. </returns>
            public Builder InventoryAlertThreshold(long? inventoryAlertThreshold)
            {
                this.inventoryAlertThreshold = inventoryAlertThreshold;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ItemVariationLocationOverrides. </returns>
            public ItemVariationLocationOverrides Build()
            {
                return new ItemVariationLocationOverrides(
                    this.locationId,
                    this.priceMoney,
                    this.pricingType,
                    this.trackInventory,
                    this.inventoryAlertType,
                    this.inventoryAlertThreshold);
            }
        }
    }
}