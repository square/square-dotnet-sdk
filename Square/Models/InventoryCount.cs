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
    public class InventoryCount 
    {
        public InventoryCount(string catalogObjectId = null,
            string catalogObjectType = null,
            string state = null,
            string locationId = null,
            string quantity = null,
            string calculatedAt = null)
        {
            CatalogObjectId = catalogObjectId;
            CatalogObjectType = catalogObjectType;
            State = state;
            LocationId = locationId;
            Quantity = quantity;
            CalculatedAt = calculatedAt;
        }

        /// <summary>
        /// The Square generated ID of the
        /// `CatalogObject` being tracked.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The `CatalogObjectType` of the
        /// `CatalogObject` being tracked. Tracking is only
        /// supported for the `ITEM_VARIATION` type.
        /// </summary>
        [JsonProperty("catalog_object_type", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectType { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The Square ID of the [Location](#type-location) where the related
        /// quantity of items are being tracked.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The number of items affected by the estimated count as a decimal string.
        /// Can support up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string Quantity { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format that indicates when Square
        /// received the most recent physical count or adjustment that had an affect
        /// on the estimated count.
        /// </summary>
        [JsonProperty("calculated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CalculatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CatalogObjectId(CatalogObjectId)
                .CatalogObjectType(CatalogObjectType)
                .State(State)
                .LocationId(LocationId)
                .Quantity(Quantity)
                .CalculatedAt(CalculatedAt);
            return builder;
        }

        public class Builder
        {
            private string catalogObjectId;
            private string catalogObjectType;
            private string state;
            private string locationId;
            private string quantity;
            private string calculatedAt;



            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

            public Builder CatalogObjectType(string catalogObjectType)
            {
                this.catalogObjectType = catalogObjectType;
                return this;
            }

            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder Quantity(string quantity)
            {
                this.quantity = quantity;
                return this;
            }

            public Builder CalculatedAt(string calculatedAt)
            {
                this.calculatedAt = calculatedAt;
                return this;
            }

            public InventoryCount Build()
            {
                return new InventoryCount(catalogObjectId,
                    catalogObjectType,
                    state,
                    locationId,
                    quantity,
                    calculatedAt);
            }
        }
    }
}