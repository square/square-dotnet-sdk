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
    public class InventoryPhysicalCount 
    {
        public InventoryPhysicalCount(string id = null,
            string referenceId = null,
            string catalogObjectId = null,
            string catalogObjectType = null,
            string state = null,
            string locationId = null,
            string quantity = null,
            Models.SourceApplication source = null,
            string employeeId = null,
            string occurredAt = null,
            string createdAt = null)
        {
            Id = id;
            ReferenceId = referenceId;
            CatalogObjectId = catalogObjectId;
            CatalogObjectType = catalogObjectType;
            State = state;
            LocationId = locationId;
            Quantity = quantity;
            Source = source;
            EmployeeId = employeeId;
            OccurredAt = occurredAt;
            CreatedAt = createdAt;
        }

        /// <summary>
        /// A unique ID generated by Square for the
        /// [InventoryPhysicalCount](#type-inventoryphysicalcount).
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// An optional ID provided by the application to tie the
        /// [InventoryPhysicalCount](#type-inventoryphysicalcount) to an external
        /// system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// The Square generated ID of the
        /// `CatalogObject` being tracked.
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The `CatalogObjectType` of the
        /// `CatalogObject` being tracked. Tracking is only
        /// supported for the `ITEM_VARIATION` type.
        /// </summary>
        [JsonProperty("catalog_object_type")]
        public string CatalogObjectType { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; }

        /// <summary>
        /// The Square ID of the [Location](#type-location) where the related
        /// quantity of items are being tracked.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The number of items affected by the physical count as a decimal string.
        /// Can support up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

        /// <summary>
        /// Provides information about the application used to generate a change.
        /// </summary>
        [JsonProperty("source")]
        public Models.SourceApplication Source { get; }

        /// <summary>
        /// The Square ID of the [Employee](#type-employee) responsible for the
        /// physical count.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// A client-generated timestamp in RFC 3339 format that indicates when
        /// the physical count took place. For write actions, the `occurred_at`
        /// timestamp cannot be older than 24 hours or in the future relative to the
        /// time of the request.
        /// </summary>
        [JsonProperty("occurred_at")]
        public string OccurredAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format that indicates when Square
        /// received the physical count.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .ReferenceId(ReferenceId)
                .CatalogObjectId(CatalogObjectId)
                .CatalogObjectType(CatalogObjectType)
                .State(State)
                .LocationId(LocationId)
                .Quantity(Quantity)
                .Source(Source)
                .EmployeeId(EmployeeId)
                .OccurredAt(OccurredAt)
                .CreatedAt(CreatedAt);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string referenceId;
            private string catalogObjectId;
            private string catalogObjectType;
            private string state;
            private string locationId;
            private string quantity;
            private Models.SourceApplication source;
            private string employeeId;
            private string occurredAt;
            private string createdAt;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder ReferenceId(string value)
            {
                referenceId = value;
                return this;
            }

            public Builder CatalogObjectId(string value)
            {
                catalogObjectId = value;
                return this;
            }

            public Builder CatalogObjectType(string value)
            {
                catalogObjectType = value;
                return this;
            }

            public Builder State(string value)
            {
                state = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Quantity(string value)
            {
                quantity = value;
                return this;
            }

            public Builder Source(Models.SourceApplication value)
            {
                source = value;
                return this;
            }

            public Builder EmployeeId(string value)
            {
                employeeId = value;
                return this;
            }

            public Builder OccurredAt(string value)
            {
                occurredAt = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public InventoryPhysicalCount Build()
            {
                return new InventoryPhysicalCount(id,
                    referenceId,
                    catalogObjectId,
                    catalogObjectType,
                    state,
                    locationId,
                    quantity,
                    source,
                    employeeId,
                    occurredAt,
                    createdAt);
            }
        }
    }
}