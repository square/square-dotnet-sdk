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
    /// CatalogItemVariation.
    /// </summary>
    public class CatalogItemVariation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogItemVariation"/> class.
        /// </summary>
        /// <param name="itemId">item_id.</param>
        /// <param name="name">name.</param>
        /// <param name="sku">sku.</param>
        /// <param name="upc">upc.</param>
        /// <param name="ordinal">ordinal.</param>
        /// <param name="pricingType">pricing_type.</param>
        /// <param name="priceMoney">price_money.</param>
        /// <param name="locationOverrides">location_overrides.</param>
        /// <param name="trackInventory">track_inventory.</param>
        /// <param name="inventoryAlertType">inventory_alert_type.</param>
        /// <param name="inventoryAlertThreshold">inventory_alert_threshold.</param>
        /// <param name="userData">user_data.</param>
        /// <param name="serviceDuration">service_duration.</param>
        /// <param name="availableForBooking">available_for_booking.</param>
        /// <param name="itemOptionValues">item_option_values.</param>
        /// <param name="measurementUnitId">measurement_unit_id.</param>
        /// <param name="teamMemberIds">team_member_ids.</param>
        public CatalogItemVariation(
            string itemId = null,
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
            bool? availableForBooking = null,
            IList<Models.CatalogItemOptionValueForItemVariation> itemOptionValues = null,
            string measurementUnitId = null,
            IList<string> teamMemberIds = null)
        {
            this.ItemId = itemId;
            this.Name = name;
            this.Sku = sku;
            this.Upc = upc;
            this.Ordinal = ordinal;
            this.PricingType = pricingType;
            this.PriceMoney = priceMoney;
            this.LocationOverrides = locationOverrides;
            this.TrackInventory = trackInventory;
            this.InventoryAlertType = inventoryAlertType;
            this.InventoryAlertThreshold = inventoryAlertThreshold;
            this.UserData = userData;
            this.ServiceDuration = serviceDuration;
            this.AvailableForBooking = availableForBooking;
            this.ItemOptionValues = itemOptionValues;
            this.MeasurementUnitId = measurementUnitId;
            this.TeamMemberIds = teamMemberIds;
        }

        /// <summary>
        /// The ID of the `CatalogItem` associated with this item variation.
        /// </summary>
        [JsonProperty("item_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemId { get; }

        /// <summary>
        /// The item variation's name. This is a searchable attribute for use in applicable query filters, and its value length is of Unicode code points.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The item variation's SKU, if any. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("sku", NullValueHandling = NullValueHandling.Ignore)]
        public string Sku { get; }

        /// <summary>
        /// The universal product code (UPC) of the item variation, if any. This is a searchable attribute for use in applicable query filters.
        /// The value of this attribute should be a number of 12-14 digits long.  This restriction is enforced on the Square Seller Dashboard,
        /// Square Point of Sale or Retail Point of Sale apps, where this attribute shows in the GTIN field. If a non-compliant UPC value is assigned
        /// to this attribute using the API, the value is not editable on the Seller Dashboard, Square Point of Sale or Retail Point of Sale apps
        /// unless it is updated to fit the expected format.
        /// </summary>
        [JsonProperty("upc", NullValueHandling = NullValueHandling.Ignore)]
        public string Upc { get; }

        /// <summary>
        /// The order in which this item variation should be displayed. This value is read-only. On writes, the ordinal
        /// for each item variation within a parent `CatalogItem` is set according to the item variations's
        /// position. On reads, the value is not guaranteed to be sequential or unique.
        /// </summary>
        [JsonProperty("ordinal", NullValueHandling = NullValueHandling.Ignore)]
        public int? Ordinal { get; }

        /// <summary>
        /// Indicates whether the price of a CatalogItemVariation should be entered manually at the time of sale.
        /// </summary>
        [JsonProperty("pricing_type", NullValueHandling = NullValueHandling.Ignore)]
        public string PricingType { get; }

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
        /// Per-location price and inventory overrides.
        /// </summary>
        [JsonProperty("location_overrides", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.ItemVariationLocationOverrides> LocationOverrides { get; }

        /// <summary>
        /// If `true`, inventory tracking is active for the variation.
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

        /// <summary>
        /// Arbitrary user metadata to associate with the item variation. This attribute value length is of Unicode code points.
        /// </summary>
        [JsonProperty("user_data", NullValueHandling = NullValueHandling.Ignore)]
        public string UserData { get; }

        /// <summary>
        /// If the `CatalogItem` that owns this item variation is of type
        /// `APPOINTMENTS_SERVICE`, then this is the duration of the service in milliseconds. For
        /// example, a 30 minute appointment would have the value `1800000`, which is equal to
        /// 30 (minutes) * 60 (seconds per minute) * 1000 (milliseconds per second).
        /// </summary>
        [JsonProperty("service_duration", NullValueHandling = NullValueHandling.Ignore)]
        public long? ServiceDuration { get; }

        /// <summary>
        /// If the `CatalogItem` that owns this item variation is of type
        /// `APPOINTMENTS_SERVICE`, a bool representing whether this service is available for booking.
        /// </summary>
        [JsonProperty("available_for_booking", NullValueHandling = NullValueHandling.Ignore)]
        public bool? AvailableForBooking { get; }

        /// <summary>
        /// List of item option values associated with this item variation. Listed
        /// in the same order as the item options of the parent item.
        /// </summary>
        [JsonProperty("item_option_values", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CatalogItemOptionValueForItemVariation> ItemOptionValues { get; }

        /// <summary>
        /// ID of the ‘CatalogMeasurementUnit’ that is used to measure the quantity
        /// sold of this item variation. If left unset, the item will be sold in
        /// whole quantities.
        /// </summary>
        [JsonProperty("measurement_unit_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MeasurementUnitId { get; }

        /// <summary>
        /// Tokens of employees that can perform the service represented by this variation. Only valid for
        /// variations of type `APPOINTMENTS_SERVICE`.
        /// </summary>
        [JsonProperty("team_member_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> TeamMemberIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CatalogItemVariation : ({string.Join(", ", toStringOutput)})";
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

            return obj is CatalogItemVariation other &&
                ((this.ItemId == null && other.ItemId == null) || (this.ItemId?.Equals(other.ItemId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Sku == null && other.Sku == null) || (this.Sku?.Equals(other.Sku) == true)) &&
                ((this.Upc == null && other.Upc == null) || (this.Upc?.Equals(other.Upc) == true)) &&
                ((this.Ordinal == null && other.Ordinal == null) || (this.Ordinal?.Equals(other.Ordinal) == true)) &&
                ((this.PricingType == null && other.PricingType == null) || (this.PricingType?.Equals(other.PricingType) == true)) &&
                ((this.PriceMoney == null && other.PriceMoney == null) || (this.PriceMoney?.Equals(other.PriceMoney) == true)) &&
                ((this.LocationOverrides == null && other.LocationOverrides == null) || (this.LocationOverrides?.Equals(other.LocationOverrides) == true)) &&
                ((this.TrackInventory == null && other.TrackInventory == null) || (this.TrackInventory?.Equals(other.TrackInventory) == true)) &&
                ((this.InventoryAlertType == null && other.InventoryAlertType == null) || (this.InventoryAlertType?.Equals(other.InventoryAlertType) == true)) &&
                ((this.InventoryAlertThreshold == null && other.InventoryAlertThreshold == null) || (this.InventoryAlertThreshold?.Equals(other.InventoryAlertThreshold) == true)) &&
                ((this.UserData == null && other.UserData == null) || (this.UserData?.Equals(other.UserData) == true)) &&
                ((this.ServiceDuration == null && other.ServiceDuration == null) || (this.ServiceDuration?.Equals(other.ServiceDuration) == true)) &&
                ((this.AvailableForBooking == null && other.AvailableForBooking == null) || (this.AvailableForBooking?.Equals(other.AvailableForBooking) == true)) &&
                ((this.ItemOptionValues == null && other.ItemOptionValues == null) || (this.ItemOptionValues?.Equals(other.ItemOptionValues) == true)) &&
                ((this.MeasurementUnitId == null && other.MeasurementUnitId == null) || (this.MeasurementUnitId?.Equals(other.MeasurementUnitId) == true)) &&
                ((this.TeamMemberIds == null && other.TeamMemberIds == null) || (this.TeamMemberIds?.Equals(other.TeamMemberIds) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1155387790;

            if (this.ItemId != null)
            {
               hashCode += this.ItemId.GetHashCode();
            }

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Sku != null)
            {
               hashCode += this.Sku.GetHashCode();
            }

            if (this.Upc != null)
            {
               hashCode += this.Upc.GetHashCode();
            }

            if (this.Ordinal != null)
            {
               hashCode += this.Ordinal.GetHashCode();
            }

            if (this.PricingType != null)
            {
               hashCode += this.PricingType.GetHashCode();
            }

            if (this.PriceMoney != null)
            {
               hashCode += this.PriceMoney.GetHashCode();
            }

            if (this.LocationOverrides != null)
            {
               hashCode += this.LocationOverrides.GetHashCode();
            }

            if (this.TrackInventory != null)
            {
               hashCode += this.TrackInventory.GetHashCode();
            }

            if (this.InventoryAlertType != null)
            {
               hashCode += this.InventoryAlertType.GetHashCode();
            }

            if (this.InventoryAlertThreshold != null)
            {
               hashCode += this.InventoryAlertThreshold.GetHashCode();
            }

            if (this.UserData != null)
            {
               hashCode += this.UserData.GetHashCode();
            }

            if (this.ServiceDuration != null)
            {
               hashCode += this.ServiceDuration.GetHashCode();
            }

            if (this.AvailableForBooking != null)
            {
               hashCode += this.AvailableForBooking.GetHashCode();
            }

            if (this.ItemOptionValues != null)
            {
               hashCode += this.ItemOptionValues.GetHashCode();
            }

            if (this.MeasurementUnitId != null)
            {
               hashCode += this.MeasurementUnitId.GetHashCode();
            }

            if (this.TeamMemberIds != null)
            {
               hashCode += this.TeamMemberIds.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemId = {(this.ItemId == null ? "null" : this.ItemId == string.Empty ? "" : this.ItemId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Sku = {(this.Sku == null ? "null" : this.Sku == string.Empty ? "" : this.Sku)}");
            toStringOutput.Add($"this.Upc = {(this.Upc == null ? "null" : this.Upc == string.Empty ? "" : this.Upc)}");
            toStringOutput.Add($"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}");
            toStringOutput.Add($"this.PricingType = {(this.PricingType == null ? "null" : this.PricingType.ToString())}");
            toStringOutput.Add($"this.PriceMoney = {(this.PriceMoney == null ? "null" : this.PriceMoney.ToString())}");
            toStringOutput.Add($"this.LocationOverrides = {(this.LocationOverrides == null ? "null" : $"[{string.Join(", ", this.LocationOverrides)} ]")}");
            toStringOutput.Add($"this.TrackInventory = {(this.TrackInventory == null ? "null" : this.TrackInventory.ToString())}");
            toStringOutput.Add($"this.InventoryAlertType = {(this.InventoryAlertType == null ? "null" : this.InventoryAlertType.ToString())}");
            toStringOutput.Add($"this.InventoryAlertThreshold = {(this.InventoryAlertThreshold == null ? "null" : this.InventoryAlertThreshold.ToString())}");
            toStringOutput.Add($"this.UserData = {(this.UserData == null ? "null" : this.UserData == string.Empty ? "" : this.UserData)}");
            toStringOutput.Add($"this.ServiceDuration = {(this.ServiceDuration == null ? "null" : this.ServiceDuration.ToString())}");
            toStringOutput.Add($"this.AvailableForBooking = {(this.AvailableForBooking == null ? "null" : this.AvailableForBooking.ToString())}");
            toStringOutput.Add($"this.ItemOptionValues = {(this.ItemOptionValues == null ? "null" : $"[{string.Join(", ", this.ItemOptionValues)} ]")}");
            toStringOutput.Add($"this.MeasurementUnitId = {(this.MeasurementUnitId == null ? "null" : this.MeasurementUnitId == string.Empty ? "" : this.MeasurementUnitId)}");
            toStringOutput.Add($"this.TeamMemberIds = {(this.TeamMemberIds == null ? "null" : $"[{string.Join(", ", this.TeamMemberIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ItemId(this.ItemId)
                .Name(this.Name)
                .Sku(this.Sku)
                .Upc(this.Upc)
                .Ordinal(this.Ordinal)
                .PricingType(this.PricingType)
                .PriceMoney(this.PriceMoney)
                .LocationOverrides(this.LocationOverrides)
                .TrackInventory(this.TrackInventory)
                .InventoryAlertType(this.InventoryAlertType)
                .InventoryAlertThreshold(this.InventoryAlertThreshold)
                .UserData(this.UserData)
                .ServiceDuration(this.ServiceDuration)
                .AvailableForBooking(this.AvailableForBooking)
                .ItemOptionValues(this.ItemOptionValues)
                .MeasurementUnitId(this.MeasurementUnitId)
                .TeamMemberIds(this.TeamMemberIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string itemId;
            private string name;
            private string sku;
            private string upc;
            private int? ordinal;
            private string pricingType;
            private Models.Money priceMoney;
            private IList<Models.ItemVariationLocationOverrides> locationOverrides;
            private bool? trackInventory;
            private string inventoryAlertType;
            private long? inventoryAlertThreshold;
            private string userData;
            private long? serviceDuration;
            private bool? availableForBooking;
            private IList<Models.CatalogItemOptionValueForItemVariation> itemOptionValues;
            private string measurementUnitId;
            private IList<string> teamMemberIds;

             /// <summary>
             /// ItemId.
             /// </summary>
             /// <param name="itemId"> itemId. </param>
             /// <returns> Builder. </returns>
            public Builder ItemId(string itemId)
            {
                this.itemId = itemId;
                return this;
            }

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
             /// Sku.
             /// </summary>
             /// <param name="sku"> sku. </param>
             /// <returns> Builder. </returns>
            public Builder Sku(string sku)
            {
                this.sku = sku;
                return this;
            }

             /// <summary>
             /// Upc.
             /// </summary>
             /// <param name="upc"> upc. </param>
             /// <returns> Builder. </returns>
            public Builder Upc(string upc)
            {
                this.upc = upc;
                return this;
            }

             /// <summary>
             /// Ordinal.
             /// </summary>
             /// <param name="ordinal"> ordinal. </param>
             /// <returns> Builder. </returns>
            public Builder Ordinal(int? ordinal)
            {
                this.ordinal = ordinal;
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
             /// LocationOverrides.
             /// </summary>
             /// <param name="locationOverrides"> locationOverrides. </param>
             /// <returns> Builder. </returns>
            public Builder LocationOverrides(IList<Models.ItemVariationLocationOverrides> locationOverrides)
            {
                this.locationOverrides = locationOverrides;
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
             /// UserData.
             /// </summary>
             /// <param name="userData"> userData. </param>
             /// <returns> Builder. </returns>
            public Builder UserData(string userData)
            {
                this.userData = userData;
                return this;
            }

             /// <summary>
             /// ServiceDuration.
             /// </summary>
             /// <param name="serviceDuration"> serviceDuration. </param>
             /// <returns> Builder. </returns>
            public Builder ServiceDuration(long? serviceDuration)
            {
                this.serviceDuration = serviceDuration;
                return this;
            }

             /// <summary>
             /// AvailableForBooking.
             /// </summary>
             /// <param name="availableForBooking"> availableForBooking. </param>
             /// <returns> Builder. </returns>
            public Builder AvailableForBooking(bool? availableForBooking)
            {
                this.availableForBooking = availableForBooking;
                return this;
            }

             /// <summary>
             /// ItemOptionValues.
             /// </summary>
             /// <param name="itemOptionValues"> itemOptionValues. </param>
             /// <returns> Builder. </returns>
            public Builder ItemOptionValues(IList<Models.CatalogItemOptionValueForItemVariation> itemOptionValues)
            {
                this.itemOptionValues = itemOptionValues;
                return this;
            }

             /// <summary>
             /// MeasurementUnitId.
             /// </summary>
             /// <param name="measurementUnitId"> measurementUnitId. </param>
             /// <returns> Builder. </returns>
            public Builder MeasurementUnitId(string measurementUnitId)
            {
                this.measurementUnitId = measurementUnitId;
                return this;
            }

             /// <summary>
             /// TeamMemberIds.
             /// </summary>
             /// <param name="teamMemberIds"> teamMemberIds. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberIds(IList<string> teamMemberIds)
            {
                this.teamMemberIds = teamMemberIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemVariation. </returns>
            public CatalogItemVariation Build()
            {
                return new CatalogItemVariation(
                    this.itemId,
                    this.name,
                    this.sku,
                    this.upc,
                    this.ordinal,
                    this.pricingType,
                    this.priceMoney,
                    this.locationOverrides,
                    this.trackInventory,
                    this.inventoryAlertType,
                    this.inventoryAlertThreshold,
                    this.userData,
                    this.serviceDuration,
                    this.availableForBooking,
                    this.itemOptionValues,
                    this.measurementUnitId,
                    this.teamMemberIds);
            }
        }
    }
}