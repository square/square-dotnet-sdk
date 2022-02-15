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
    /// InventoryPhysicalCount.
    /// </summary>
    public class InventoryPhysicalCount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryPhysicalCount"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogObjectType">catalog_object_type.</param>
        /// <param name="state">state.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="source">source.</param>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="occurredAt">occurred_at.</param>
        /// <param name="createdAt">created_at.</param>
        public InventoryPhysicalCount(
            string id = null,
            string referenceId = null,
            string catalogObjectId = null,
            string catalogObjectType = null,
            string state = null,
            string locationId = null,
            string quantity = null,
            Models.SourceApplication source = null,
            string employeeId = null,
            string teamMemberId = null,
            string occurredAt = null,
            string createdAt = null)
        {
            this.Id = id;
            this.ReferenceId = referenceId;
            this.CatalogObjectId = catalogObjectId;
            this.CatalogObjectType = catalogObjectType;
            this.State = state;
            this.LocationId = locationId;
            this.Quantity = quantity;
            this.Source = source;
            this.EmployeeId = employeeId;
            this.TeamMemberId = teamMemberId;
            this.OccurredAt = occurredAt;
            this.CreatedAt = createdAt;
        }

        /// <summary>
        /// A unique Square-generated ID for the
        /// [InventoryPhysicalCount]($m/InventoryPhysicalCount).
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// An optional ID provided by the application to tie the
        /// [InventoryPhysicalCount]($m/InventoryPhysicalCount) to an external
        /// system.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// The Square-generated ID of the
        /// [CatalogObject]($m/CatalogObject) being tracked.
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The [type]($m/CatalogObjectType) of the
        /// [CatalogObject]($m/CatalogObject) being tracked. Tracking is only
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
        /// The Square-generated ID of the [Location]($m/Location) where the related
        /// quantity of items is being tracked.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The number of items affected by the physical count as a decimal string.
        /// The number can support up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("quantity", NullValueHandling = NullValueHandling.Ignore)]
        public string Quantity { get; }

        /// <summary>
        /// Provides information about the application used to generate a change.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SourceApplication Source { get; }

        /// <summary>
        /// The Square-generated ID of the [Employee]($m/Employee) responsible for the
        /// physical count.
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        /// <summary>
        /// The Square-generated ID of the [Team Member]($m/TeamMember) responsible for the
        /// physical count.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <summary>
        /// A client-generated RFC 3339-formatted timestamp that indicates when
        /// the physical count was examined. For physical count updates, the `occurred_at`
        /// timestamp cannot be older than 24 hours or in the future relative to the
        /// time of the request.
        /// </summary>
        [JsonProperty("occurred_at", NullValueHandling = NullValueHandling.Ignore)]
        public string OccurredAt { get; }

        /// <summary>
        /// An RFC 3339-formatted timestamp that indicates when the physical count is received.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InventoryPhysicalCount : ({string.Join(", ", toStringOutput)})";
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

            return obj is InventoryPhysicalCount other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogObjectType == null && other.CatalogObjectType == null) || (this.CatalogObjectType?.Equals(other.CatalogObjectType) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.Source == null && other.Source == null) || (this.Source?.Equals(other.Source) == true)) &&
                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true)) &&
                ((this.OccurredAt == null && other.OccurredAt == null) || (this.OccurredAt?.Equals(other.OccurredAt) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1611758334;
            hashCode = HashCode.Combine(this.Id, this.ReferenceId, this.CatalogObjectId, this.CatalogObjectType, this.State, this.LocationId, this.Quantity);

            hashCode = HashCode.Combine(hashCode, this.Source, this.EmployeeId, this.TeamMemberId, this.OccurredAt, this.CreatedAt);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.CatalogObjectType = {(this.CatalogObjectType == null ? "null" : this.CatalogObjectType == string.Empty ? "" : this.CatalogObjectType)}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity == string.Empty ? "" : this.Quantity)}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source.ToString())}");
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId == string.Empty ? "" : this.EmployeeId)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
            toStringOutput.Add($"this.OccurredAt = {(this.OccurredAt == null ? "null" : this.OccurredAt == string.Empty ? "" : this.OccurredAt)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .ReferenceId(this.ReferenceId)
                .CatalogObjectId(this.CatalogObjectId)
                .CatalogObjectType(this.CatalogObjectType)
                .State(this.State)
                .LocationId(this.LocationId)
                .Quantity(this.Quantity)
                .Source(this.Source)
                .EmployeeId(this.EmployeeId)
                .TeamMemberId(this.TeamMemberId)
                .OccurredAt(this.OccurredAt)
                .CreatedAt(this.CreatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
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
            private string teamMemberId;
            private string occurredAt;
            private string createdAt;

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

             /// <summary>
             /// CatalogObjectId.
             /// </summary>
             /// <param name="catalogObjectId"> catalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

             /// <summary>
             /// CatalogObjectType.
             /// </summary>
             /// <param name="catalogObjectType"> catalogObjectType. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectType(string catalogObjectType)
            {
                this.catalogObjectType = catalogObjectType;
                return this;
            }

             /// <summary>
             /// State.
             /// </summary>
             /// <param name="state"> state. </param>
             /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

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
             /// Quantity.
             /// </summary>
             /// <param name="quantity"> quantity. </param>
             /// <returns> Builder. </returns>
            public Builder Quantity(string quantity)
            {
                this.quantity = quantity;
                return this;
            }

             /// <summary>
             /// Source.
             /// </summary>
             /// <param name="source"> source. </param>
             /// <returns> Builder. </returns>
            public Builder Source(Models.SourceApplication source)
            {
                this.source = source;
                return this;
            }

             /// <summary>
             /// EmployeeId.
             /// </summary>
             /// <param name="employeeId"> employeeId. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

             /// <summary>
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

             /// <summary>
             /// OccurredAt.
             /// </summary>
             /// <param name="occurredAt"> occurredAt. </param>
             /// <returns> Builder. </returns>
            public Builder OccurredAt(string occurredAt)
            {
                this.occurredAt = occurredAt;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InventoryPhysicalCount. </returns>
            public InventoryPhysicalCount Build()
            {
                return new InventoryPhysicalCount(
                    this.id,
                    this.referenceId,
                    this.catalogObjectId,
                    this.catalogObjectType,
                    this.state,
                    this.locationId,
                    this.quantity,
                    this.source,
                    this.employeeId,
                    this.teamMemberId,
                    this.occurredAt,
                    this.createdAt);
            }
        }
    }
}