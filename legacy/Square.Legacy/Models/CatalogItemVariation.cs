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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// CatalogItemVariation.
    /// </summary>
    public class CatalogItemVariation
    {
        private readonly Dictionary<string, bool> shouldSerialize;

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
        /// <param name="sellable">sellable.</param>
        /// <param name="stockable">stockable.</param>
        /// <param name="imageIds">image_ids.</param>
        /// <param name="teamMemberIds">team_member_ids.</param>
        /// <param name="stockableConversion">stockable_conversion.</param>
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
            bool? sellable = null,
            bool? stockable = null,
            IList<string> imageIds = null,
            IList<string> teamMemberIds = null,
            Models.CatalogStockConversion stockableConversion = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "item_id", false },
                { "name", false },
                { "sku", false },
                { "upc", false },
                { "location_overrides", false },
                { "track_inventory", false },
                { "inventory_alert_threshold", false },
                { "user_data", false },
                { "service_duration", false },
                { "available_for_booking", false },
                { "item_option_values", false },
                { "measurement_unit_id", false },
                { "sellable", false },
                { "stockable", false },
                { "image_ids", false },
                { "team_member_ids", false },
            };

            if (itemId != null)
            {
                shouldSerialize["item_id"] = true;
                this.ItemId = itemId;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (sku != null)
            {
                shouldSerialize["sku"] = true;
                this.Sku = sku;
            }

            if (upc != null)
            {
                shouldSerialize["upc"] = true;
                this.Upc = upc;
            }
            this.Ordinal = ordinal;
            this.PricingType = pricingType;
            this.PriceMoney = priceMoney;

            if (locationOverrides != null)
            {
                shouldSerialize["location_overrides"] = true;
                this.LocationOverrides = locationOverrides;
            }

            if (trackInventory != null)
            {
                shouldSerialize["track_inventory"] = true;
                this.TrackInventory = trackInventory;
            }
            this.InventoryAlertType = inventoryAlertType;

            if (inventoryAlertThreshold != null)
            {
                shouldSerialize["inventory_alert_threshold"] = true;
                this.InventoryAlertThreshold = inventoryAlertThreshold;
            }

            if (userData != null)
            {
                shouldSerialize["user_data"] = true;
                this.UserData = userData;
            }

            if (serviceDuration != null)
            {
                shouldSerialize["service_duration"] = true;
                this.ServiceDuration = serviceDuration;
            }

            if (availableForBooking != null)
            {
                shouldSerialize["available_for_booking"] = true;
                this.AvailableForBooking = availableForBooking;
            }

            if (itemOptionValues != null)
            {
                shouldSerialize["item_option_values"] = true;
                this.ItemOptionValues = itemOptionValues;
            }

            if (measurementUnitId != null)
            {
                shouldSerialize["measurement_unit_id"] = true;
                this.MeasurementUnitId = measurementUnitId;
            }

            if (sellable != null)
            {
                shouldSerialize["sellable"] = true;
                this.Sellable = sellable;
            }

            if (stockable != null)
            {
                shouldSerialize["stockable"] = true;
                this.Stockable = stockable;
            }

            if (imageIds != null)
            {
                shouldSerialize["image_ids"] = true;
                this.ImageIds = imageIds;
            }

            if (teamMemberIds != null)
            {
                shouldSerialize["team_member_ids"] = true;
                this.TeamMemberIds = teamMemberIds;
            }
            this.StockableConversion = stockableConversion;
        }

        internal CatalogItemVariation(
            Dictionary<string, bool> shouldSerialize,
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
            bool? sellable = null,
            bool? stockable = null,
            IList<string> imageIds = null,
            IList<string> teamMemberIds = null,
            Models.CatalogStockConversion stockableConversion = null
        )
        {
            this.shouldSerialize = shouldSerialize;
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
            AvailableForBooking = availableForBooking;
            ItemOptionValues = itemOptionValues;
            MeasurementUnitId = measurementUnitId;
            Sellable = sellable;
            Stockable = stockable;
            ImageIds = imageIds;
            TeamMemberIds = teamMemberIds;
            StockableConversion = stockableConversion;
        }

        /// <summary>
        /// The ID of the `CatalogItem` associated with this item variation.
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; }

        /// <summary>
        /// The item variation's name. This is a searchable attribute for use in applicable query filters.
        /// Its value has a maximum length of 255 Unicode code points. However, when the parent [item](entity:CatalogItem)
        /// uses [item options](entity:CatalogItemOption), this attribute is auto-generated, read-only, and can be
        /// longer than 255 Unicode code points.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The item variation's SKU, if any. This is a searchable attribute for use in applicable query filters.
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; }

        /// <summary>
        /// The universal product code (UPC) of the item variation, if any. This is a searchable attribute for use in applicable query filters.
        /// The value of this attribute should be a number of 12-14 digits long.  This restriction is enforced on the Square Seller Dashboard,
        /// Square Point of Sale or Retail Point of Sale apps, where this attribute shows in the GTIN field. If a non-compliant UPC value is assigned
        /// to this attribute using the API, the value is not editable on the Seller Dashboard, Square Point of Sale or Retail Point of Sale apps
        /// unless it is updated to fit the expected format.
        /// </summary>
        [JsonProperty("upc")]
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
        [JsonProperty("inventory_alert_type", NullValueHandling = NullValueHandling.Ignore)]
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
        /// If the `CatalogItem` that owns this item variation is of type
        /// `APPOINTMENTS_SERVICE`, a bool representing whether this service is available for booking.
        /// </summary>
        [JsonProperty("available_for_booking")]
        public bool? AvailableForBooking { get; }

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

        /// <summary>
        /// Whether this variation can be sold. The inventory count of a sellable variation indicates
        /// the number of units available for sale. When a variation is both stockable and sellable,
        /// its sellable inventory count can be smaller than or equal to its stockable count.
        /// </summary>
        [JsonProperty("sellable")]
        public bool? Sellable { get; }

        /// <summary>
        /// Whether stock is counted directly on this variation (TRUE) or only on its components (FALSE).
        /// When a variation is both stockable and sellable, the inventory count of a stockable variation keeps track of the number of units of this variation in stock
        /// and is not an indicator of the number of units of the variation that can be sold.
        /// </summary>
        [JsonProperty("stockable")]
        public bool? Stockable { get; }

        /// <summary>
        /// The IDs of images associated with this `CatalogItemVariation` instance.
        /// These images will be shown to customers in Square Online Store.
        /// </summary>
        [JsonProperty("image_ids")]
        public IList<string> ImageIds { get; }

        /// <summary>
        /// Tokens of employees that can perform the service represented by this variation. Only valid for
        /// variations of type `APPOINTMENTS_SERVICE`.
        /// </summary>
        [JsonProperty("team_member_ids")]
        public IList<string> TeamMemberIds { get; }

        /// <summary>
        /// Represents the rule of conversion between a stockable [CatalogItemVariation]($m/CatalogItemVariation)
        /// and a non-stockable sell-by or receive-by `CatalogItemVariation` that
        /// share the same underlying stock.
        /// </summary>
        [JsonProperty("stockable_conversion", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CatalogStockConversion StockableConversion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CatalogItemVariation : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemId()
        {
            return this.shouldSerialize["item_id"];
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
        public bool ShouldSerializeSku()
        {
            return this.shouldSerialize["sku"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUpc()
        {
            return this.shouldSerialize["upc"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationOverrides()
        {
            return this.shouldSerialize["location_overrides"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrackInventory()
        {
            return this.shouldSerialize["track_inventory"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeInventoryAlertThreshold()
        {
            return this.shouldSerialize["inventory_alert_threshold"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUserData()
        {
            return this.shouldSerialize["user_data"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeServiceDuration()
        {
            return this.shouldSerialize["service_duration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAvailableForBooking()
        {
            return this.shouldSerialize["available_for_booking"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeItemOptionValues()
        {
            return this.shouldSerialize["item_option_values"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMeasurementUnitId()
        {
            return this.shouldSerialize["measurement_unit_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSellable()
        {
            return this.shouldSerialize["sellable"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStockable()
        {
            return this.shouldSerialize["stockable"];
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
        public bool ShouldSerializeTeamMemberIds()
        {
            return this.shouldSerialize["team_member_ids"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is CatalogItemVariation other
                && (
                    this.ItemId == null && other.ItemId == null
                    || this.ItemId?.Equals(other.ItemId) == true
                )
                && (
                    this.Name == null && other.Name == null || this.Name?.Equals(other.Name) == true
                )
                && (this.Sku == null && other.Sku == null || this.Sku?.Equals(other.Sku) == true)
                && (this.Upc == null && other.Upc == null || this.Upc?.Equals(other.Upc) == true)
                && (
                    this.Ordinal == null && other.Ordinal == null
                    || this.Ordinal?.Equals(other.Ordinal) == true
                )
                && (
                    this.PricingType == null && other.PricingType == null
                    || this.PricingType?.Equals(other.PricingType) == true
                )
                && (
                    this.PriceMoney == null && other.PriceMoney == null
                    || this.PriceMoney?.Equals(other.PriceMoney) == true
                )
                && (
                    this.LocationOverrides == null && other.LocationOverrides == null
                    || this.LocationOverrides?.Equals(other.LocationOverrides) == true
                )
                && (
                    this.TrackInventory == null && other.TrackInventory == null
                    || this.TrackInventory?.Equals(other.TrackInventory) == true
                )
                && (
                    this.InventoryAlertType == null && other.InventoryAlertType == null
                    || this.InventoryAlertType?.Equals(other.InventoryAlertType) == true
                )
                && (
                    this.InventoryAlertThreshold == null && other.InventoryAlertThreshold == null
                    || this.InventoryAlertThreshold?.Equals(other.InventoryAlertThreshold) == true
                )
                && (
                    this.UserData == null && other.UserData == null
                    || this.UserData?.Equals(other.UserData) == true
                )
                && (
                    this.ServiceDuration == null && other.ServiceDuration == null
                    || this.ServiceDuration?.Equals(other.ServiceDuration) == true
                )
                && (
                    this.AvailableForBooking == null && other.AvailableForBooking == null
                    || this.AvailableForBooking?.Equals(other.AvailableForBooking) == true
                )
                && (
                    this.ItemOptionValues == null && other.ItemOptionValues == null
                    || this.ItemOptionValues?.Equals(other.ItemOptionValues) == true
                )
                && (
                    this.MeasurementUnitId == null && other.MeasurementUnitId == null
                    || this.MeasurementUnitId?.Equals(other.MeasurementUnitId) == true
                )
                && (
                    this.Sellable == null && other.Sellable == null
                    || this.Sellable?.Equals(other.Sellable) == true
                )
                && (
                    this.Stockable == null && other.Stockable == null
                    || this.Stockable?.Equals(other.Stockable) == true
                )
                && (
                    this.ImageIds == null && other.ImageIds == null
                    || this.ImageIds?.Equals(other.ImageIds) == true
                )
                && (
                    this.TeamMemberIds == null && other.TeamMemberIds == null
                    || this.TeamMemberIds?.Equals(other.TeamMemberIds) == true
                )
                && (
                    this.StockableConversion == null && other.StockableConversion == null
                    || this.StockableConversion?.Equals(other.StockableConversion) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1883269802;
            hashCode = HashCode.Combine(
                hashCode,
                this.ItemId,
                this.Name,
                this.Sku,
                this.Upc,
                this.Ordinal,
                this.PricingType,
                this.PriceMoney
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.LocationOverrides,
                this.TrackInventory,
                this.InventoryAlertType,
                this.InventoryAlertThreshold,
                this.UserData,
                this.ServiceDuration,
                this.AvailableForBooking
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.ItemOptionValues,
                this.MeasurementUnitId,
                this.Sellable,
                this.Stockable,
                this.ImageIds,
                this.TeamMemberIds,
                this.StockableConversion
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ItemId = {this.ItemId ?? "null"}");
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
            toStringOutput.Add($"this.Sku = {this.Sku ?? "null"}");
            toStringOutput.Add($"this.Upc = {this.Upc ?? "null"}");
            toStringOutput.Add(
                $"this.Ordinal = {(this.Ordinal == null ? "null" : this.Ordinal.ToString())}"
            );
            toStringOutput.Add(
                $"this.PricingType = {(this.PricingType == null ? "null" : this.PricingType.ToString())}"
            );
            toStringOutput.Add(
                $"this.PriceMoney = {(this.PriceMoney == null ? "null" : this.PriceMoney.ToString())}"
            );
            toStringOutput.Add(
                $"this.LocationOverrides = {(this.LocationOverrides == null ? "null" : $"[{string.Join(", ", this.LocationOverrides)} ]")}"
            );
            toStringOutput.Add(
                $"this.TrackInventory = {(this.TrackInventory == null ? "null" : this.TrackInventory.ToString())}"
            );
            toStringOutput.Add(
                $"this.InventoryAlertType = {(this.InventoryAlertType == null ? "null" : this.InventoryAlertType.ToString())}"
            );
            toStringOutput.Add(
                $"this.InventoryAlertThreshold = {(this.InventoryAlertThreshold == null ? "null" : this.InventoryAlertThreshold.ToString())}"
            );
            toStringOutput.Add($"this.UserData = {this.UserData ?? "null"}");
            toStringOutput.Add(
                $"this.ServiceDuration = {(this.ServiceDuration == null ? "null" : this.ServiceDuration.ToString())}"
            );
            toStringOutput.Add(
                $"this.AvailableForBooking = {(this.AvailableForBooking == null ? "null" : this.AvailableForBooking.ToString())}"
            );
            toStringOutput.Add(
                $"this.ItemOptionValues = {(this.ItemOptionValues == null ? "null" : $"[{string.Join(", ", this.ItemOptionValues)} ]")}"
            );
            toStringOutput.Add($"this.MeasurementUnitId = {this.MeasurementUnitId ?? "null"}");
            toStringOutput.Add(
                $"this.Sellable = {(this.Sellable == null ? "null" : this.Sellable.ToString())}"
            );
            toStringOutput.Add(
                $"this.Stockable = {(this.Stockable == null ? "null" : this.Stockable.ToString())}"
            );
            toStringOutput.Add(
                $"this.ImageIds = {(this.ImageIds == null ? "null" : $"[{string.Join(", ", this.ImageIds)} ]")}"
            );
            toStringOutput.Add(
                $"this.TeamMemberIds = {(this.TeamMemberIds == null ? "null" : $"[{string.Join(", ", this.TeamMemberIds)} ]")}"
            );
            toStringOutput.Add(
                $"this.StockableConversion = {(this.StockableConversion == null ? "null" : this.StockableConversion.ToString())}"
            );
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
                .Sellable(this.Sellable)
                .Stockable(this.Stockable)
                .ImageIds(this.ImageIds)
                .TeamMemberIds(this.TeamMemberIds)
                .StockableConversion(this.StockableConversion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "item_id", false },
                { "name", false },
                { "sku", false },
                { "upc", false },
                { "location_overrides", false },
                { "track_inventory", false },
                { "inventory_alert_threshold", false },
                { "user_data", false },
                { "service_duration", false },
                { "available_for_booking", false },
                { "item_option_values", false },
                { "measurement_unit_id", false },
                { "sellable", false },
                { "stockable", false },
                { "image_ids", false },
                { "team_member_ids", false },
            };

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
            private bool? sellable;
            private bool? stockable;
            private IList<string> imageIds;
            private IList<string> teamMemberIds;
            private Models.CatalogStockConversion stockableConversion;

            /// <summary>
            /// ItemId.
            /// </summary>
            /// <param name="itemId"> itemId. </param>
            /// <returns> Builder. </returns>
            public Builder ItemId(string itemId)
            {
                shouldSerialize["item_id"] = true;
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
                shouldSerialize["name"] = true;
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
                shouldSerialize["sku"] = true;
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
                shouldSerialize["upc"] = true;
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
            public Builder LocationOverrides(
                IList<Models.ItemVariationLocationOverrides> locationOverrides
            )
            {
                shouldSerialize["location_overrides"] = true;
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
                shouldSerialize["track_inventory"] = true;
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
                shouldSerialize["inventory_alert_threshold"] = true;
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
                shouldSerialize["user_data"] = true;
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
                shouldSerialize["service_duration"] = true;
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
                shouldSerialize["available_for_booking"] = true;
                this.availableForBooking = availableForBooking;
                return this;
            }

            /// <summary>
            /// ItemOptionValues.
            /// </summary>
            /// <param name="itemOptionValues"> itemOptionValues. </param>
            /// <returns> Builder. </returns>
            public Builder ItemOptionValues(
                IList<Models.CatalogItemOptionValueForItemVariation> itemOptionValues
            )
            {
                shouldSerialize["item_option_values"] = true;
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
                shouldSerialize["measurement_unit_id"] = true;
                this.measurementUnitId = measurementUnitId;
                return this;
            }

            /// <summary>
            /// Sellable.
            /// </summary>
            /// <param name="sellable"> sellable. </param>
            /// <returns> Builder. </returns>
            public Builder Sellable(bool? sellable)
            {
                shouldSerialize["sellable"] = true;
                this.sellable = sellable;
                return this;
            }

            /// <summary>
            /// Stockable.
            /// </summary>
            /// <param name="stockable"> stockable. </param>
            /// <returns> Builder. </returns>
            public Builder Stockable(bool? stockable)
            {
                shouldSerialize["stockable"] = true;
                this.stockable = stockable;
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
            /// TeamMemberIds.
            /// </summary>
            /// <param name="teamMemberIds"> teamMemberIds. </param>
            /// <returns> Builder. </returns>
            public Builder TeamMemberIds(IList<string> teamMemberIds)
            {
                shouldSerialize["team_member_ids"] = true;
                this.teamMemberIds = teamMemberIds;
                return this;
            }

            /// <summary>
            /// StockableConversion.
            /// </summary>
            /// <param name="stockableConversion"> stockableConversion. </param>
            /// <returns> Builder. </returns>
            public Builder StockableConversion(Models.CatalogStockConversion stockableConversion)
            {
                this.stockableConversion = stockableConversion;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetItemId()
            {
                this.shouldSerialize["item_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSku()
            {
                this.shouldSerialize["sku"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUpc()
            {
                this.shouldSerialize["upc"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationOverrides()
            {
                this.shouldSerialize["location_overrides"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTrackInventory()
            {
                this.shouldSerialize["track_inventory"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetInventoryAlertThreshold()
            {
                this.shouldSerialize["inventory_alert_threshold"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUserData()
            {
                this.shouldSerialize["user_data"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetServiceDuration()
            {
                this.shouldSerialize["service_duration"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetAvailableForBooking()
            {
                this.shouldSerialize["available_for_booking"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetItemOptionValues()
            {
                this.shouldSerialize["item_option_values"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMeasurementUnitId()
            {
                this.shouldSerialize["measurement_unit_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSellable()
            {
                this.shouldSerialize["sellable"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetStockable()
            {
                this.shouldSerialize["stockable"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetImageIds()
            {
                this.shouldSerialize["image_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTeamMemberIds()
            {
                this.shouldSerialize["team_member_ids"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CatalogItemVariation. </returns>
            public CatalogItemVariation Build()
            {
                return new CatalogItemVariation(
                    shouldSerialize,
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
                    this.sellable,
                    this.stockable,
                    this.imageIds,
                    this.teamMemberIds,
                    this.stockableConversion
                );
            }
        }
    }
}
