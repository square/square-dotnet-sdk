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
    /// InventoryTransfer.
    /// </summary>
    public class InventoryTransfer
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryTransfer"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="state">state.</param>
        /// <param name="fromLocationId">from_location_id.</param>
        /// <param name="toLocationId">to_location_id.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogObjectType">catalog_object_type.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="occurredAt">occurred_at.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="source">source.</param>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        public InventoryTransfer(
            string id = null,
            string referenceId = null,
            string state = null,
            string fromLocationId = null,
            string toLocationId = null,
            string catalogObjectId = null,
            string catalogObjectType = null,
            string quantity = null,
            string occurredAt = null,
            string createdAt = null,
            Models.SourceApplication source = null,
            string employeeId = null,
            string teamMemberId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "from_location_id", false },
                { "to_location_id", false },
                { "catalog_object_id", false },
                { "catalog_object_type", false },
                { "quantity", false },
                { "occurred_at", false },
                { "employee_id", false },
                { "team_member_id", false }
            };

            this.Id = id;
            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }

            this.State = state;
            if (fromLocationId != null)
            {
                shouldSerialize["from_location_id"] = true;
                this.FromLocationId = fromLocationId;
            }

            if (toLocationId != null)
            {
                shouldSerialize["to_location_id"] = true;
                this.ToLocationId = toLocationId;
            }

            if (catalogObjectId != null)
            {
                shouldSerialize["catalog_object_id"] = true;
                this.CatalogObjectId = catalogObjectId;
            }

            if (catalogObjectType != null)
            {
                shouldSerialize["catalog_object_type"] = true;
                this.CatalogObjectType = catalogObjectType;
            }

            if (quantity != null)
            {
                shouldSerialize["quantity"] = true;
                this.Quantity = quantity;
            }

            if (occurredAt != null)
            {
                shouldSerialize["occurred_at"] = true;
                this.OccurredAt = occurredAt;
            }

            this.CreatedAt = createdAt;
            this.Source = source;
            if (employeeId != null)
            {
                shouldSerialize["employee_id"] = true;
                this.EmployeeId = employeeId;
            }

            if (teamMemberId != null)
            {
                shouldSerialize["team_member_id"] = true;
                this.TeamMemberId = teamMemberId;
            }

        }
        internal InventoryTransfer(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string referenceId = null,
            string state = null,
            string fromLocationId = null,
            string toLocationId = null,
            string catalogObjectId = null,
            string catalogObjectType = null,
            string quantity = null,
            string occurredAt = null,
            string createdAt = null,
            Models.SourceApplication source = null,
            string employeeId = null,
            string teamMemberId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            ReferenceId = referenceId;
            State = state;
            FromLocationId = fromLocationId;
            ToLocationId = toLocationId;
            CatalogObjectId = catalogObjectId;
            CatalogObjectType = catalogObjectType;
            Quantity = quantity;
            OccurredAt = occurredAt;
            CreatedAt = createdAt;
            Source = source;
            EmployeeId = employeeId;
            TeamMemberId = teamMemberId;
        }

        /// <summary>
        /// A unique ID generated by Square for the
        /// `InventoryTransfer`.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// An optional ID provided by the application to tie the
        /// `InventoryTransfer` to an external system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The Square-generated ID of the [Location](entity:Location) where the related
        /// quantity of items was tracked before the transfer.
        /// </summary>
        [JsonProperty("from_location_id")]
        public string FromLocationId { get; }

        /// <summary>
        /// The Square-generated ID of the [Location](entity:Location) where the related
        /// quantity of items was tracked after the transfer.
        /// </summary>
        [JsonProperty("to_location_id")]
        public string ToLocationId { get; }

        /// <summary>
        /// The Square-generated ID of the
        /// [CatalogObject](entity:CatalogObject) being tracked.
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The [type](entity:CatalogObjectType) of the [CatalogObject](entity:CatalogObject) being tracked.
        /// The Inventory API supports setting and reading the `"catalog_object_type": "ITEM_VARIATION"` field value.
        /// In addition, it can also read the `"catalog_object_type": "ITEM"` field value that is set by the Square Restaurants app.
        /// </summary>
        [JsonProperty("catalog_object_type")]
        public string CatalogObjectType { get; }

        /// <summary>
        /// The number of items affected by the transfer as a decimal string.
        /// Can support up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

        /// <summary>
        /// A client-generated RFC 3339-formatted timestamp that indicates when
        /// the transfer took place. For write actions, the `occurred_at` timestamp
        /// cannot be older than 24 hours or in the future relative to the time of the
        /// request.
        /// </summary>
        [JsonProperty("occurred_at")]
        public string OccurredAt { get; }

        /// <summary>
        /// An RFC 3339-formatted timestamp that indicates when Square
        /// received the transfer request.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Represents information about the application used to generate a change.
        /// </summary>
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SourceApplication Source { get; }

        /// <summary>
        /// The Square-generated ID of the [Employee](entity:Employee) responsible for the
        /// inventory transfer.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// The Square-generated ID of the [Team Member](entity:TeamMember) responsible for the
        /// inventory transfer.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InventoryTransfer : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFromLocationId()
        {
            return this.shouldSerialize["from_location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeToLocationId()
        {
            return this.shouldSerialize["to_location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogObjectId()
        {
            return this.shouldSerialize["catalog_object_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogObjectType()
        {
            return this.shouldSerialize["catalog_object_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeQuantity()
        {
            return this.shouldSerialize["quantity"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOccurredAt()
        {
            return this.shouldSerialize["occurred_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmployeeId()
        {
            return this.shouldSerialize["employee_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTeamMemberId()
        {
            return this.shouldSerialize["team_member_id"];
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

            return obj is InventoryTransfer other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.FromLocationId == null && other.FromLocationId == null) || (this.FromLocationId?.Equals(other.FromLocationId) == true)) &&
                ((this.ToLocationId == null && other.ToLocationId == null) || (this.ToLocationId?.Equals(other.ToLocationId) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogObjectType == null && other.CatalogObjectType == null) || (this.CatalogObjectType?.Equals(other.CatalogObjectType) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true)) &&
                ((this.OccurredAt == null && other.OccurredAt == null) || (this.OccurredAt?.Equals(other.OccurredAt) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.Source == null && other.Source == null) || (this.Source?.Equals(other.Source) == true)) &&
                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -116753516;
            hashCode = HashCode.Combine(this.Id, this.ReferenceId, this.State, this.FromLocationId, this.ToLocationId, this.CatalogObjectId, this.CatalogObjectType);

            hashCode = HashCode.Combine(hashCode, this.Quantity, this.OccurredAt, this.CreatedAt, this.Source, this.EmployeeId, this.TeamMemberId);

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
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.FromLocationId = {(this.FromLocationId == null ? "null" : this.FromLocationId == string.Empty ? "" : this.FromLocationId)}");
            toStringOutput.Add($"this.ToLocationId = {(this.ToLocationId == null ? "null" : this.ToLocationId == string.Empty ? "" : this.ToLocationId)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.CatalogObjectType = {(this.CatalogObjectType == null ? "null" : this.CatalogObjectType == string.Empty ? "" : this.CatalogObjectType)}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity == string.Empty ? "" : this.Quantity)}");
            toStringOutput.Add($"this.OccurredAt = {(this.OccurredAt == null ? "null" : this.OccurredAt == string.Empty ? "" : this.OccurredAt)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.Source = {(this.Source == null ? "null" : this.Source.ToString())}");
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId == string.Empty ? "" : this.EmployeeId)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId == string.Empty ? "" : this.TeamMemberId)}");
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
                .State(this.State)
                .FromLocationId(this.FromLocationId)
                .ToLocationId(this.ToLocationId)
                .CatalogObjectId(this.CatalogObjectId)
                .CatalogObjectType(this.CatalogObjectType)
                .Quantity(this.Quantity)
                .OccurredAt(this.OccurredAt)
                .CreatedAt(this.CreatedAt)
                .Source(this.Source)
                .EmployeeId(this.EmployeeId)
                .TeamMemberId(this.TeamMemberId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "from_location_id", false },
                { "to_location_id", false },
                { "catalog_object_id", false },
                { "catalog_object_type", false },
                { "quantity", false },
                { "occurred_at", false },
                { "employee_id", false },
                { "team_member_id", false },
            };

            private string id;
            private string referenceId;
            private string state;
            private string fromLocationId;
            private string toLocationId;
            private string catalogObjectId;
            private string catalogObjectType;
            private string quantity;
            private string occurredAt;
            private string createdAt;
            private Models.SourceApplication source;
            private string employeeId;
            private string teamMemberId;

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
                shouldSerialize["reference_id"] = true;
                this.referenceId = referenceId;
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
             /// FromLocationId.
             /// </summary>
             /// <param name="fromLocationId"> fromLocationId. </param>
             /// <returns> Builder. </returns>
            public Builder FromLocationId(string fromLocationId)
            {
                shouldSerialize["from_location_id"] = true;
                this.fromLocationId = fromLocationId;
                return this;
            }

             /// <summary>
             /// ToLocationId.
             /// </summary>
             /// <param name="toLocationId"> toLocationId. </param>
             /// <returns> Builder. </returns>
            public Builder ToLocationId(string toLocationId)
            {
                shouldSerialize["to_location_id"] = true;
                this.toLocationId = toLocationId;
                return this;
            }

             /// <summary>
             /// CatalogObjectId.
             /// </summary>
             /// <param name="catalogObjectId"> catalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectId(string catalogObjectId)
            {
                shouldSerialize["catalog_object_id"] = true;
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
                shouldSerialize["catalog_object_type"] = true;
                this.catalogObjectType = catalogObjectType;
                return this;
            }

             /// <summary>
             /// Quantity.
             /// </summary>
             /// <param name="quantity"> quantity. </param>
             /// <returns> Builder. </returns>
            public Builder Quantity(string quantity)
            {
                shouldSerialize["quantity"] = true;
                this.quantity = quantity;
                return this;
            }

             /// <summary>
             /// OccurredAt.
             /// </summary>
             /// <param name="occurredAt"> occurredAt. </param>
             /// <returns> Builder. </returns>
            public Builder OccurredAt(string occurredAt)
            {
                shouldSerialize["occurred_at"] = true;
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
                shouldSerialize["employee_id"] = true;
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
                shouldSerialize["team_member_id"] = true;
                this.teamMemberId = teamMemberId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFromLocationId()
            {
                this.shouldSerialize["from_location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetToLocationId()
            {
                this.shouldSerialize["to_location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogObjectId()
            {
                this.shouldSerialize["catalog_object_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogObjectType()
            {
                this.shouldSerialize["catalog_object_type"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetQuantity()
            {
                this.shouldSerialize["quantity"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOccurredAt()
            {
                this.shouldSerialize["occurred_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEmployeeId()
            {
                this.shouldSerialize["employee_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTeamMemberId()
            {
                this.shouldSerialize["team_member_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InventoryTransfer. </returns>
            public InventoryTransfer Build()
            {
                return new InventoryTransfer(shouldSerialize,
                    this.id,
                    this.referenceId,
                    this.state,
                    this.fromLocationId,
                    this.toLocationId,
                    this.catalogObjectId,
                    this.catalogObjectType,
                    this.quantity,
                    this.occurredAt,
                    this.createdAt,
                    this.source,
                    this.employeeId,
                    this.teamMemberId);
            }
        }
    }
}