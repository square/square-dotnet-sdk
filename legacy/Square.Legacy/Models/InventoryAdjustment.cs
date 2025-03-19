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
    /// InventoryAdjustment.
    /// </summary>
    public class InventoryAdjustment
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryAdjustment"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="fromState">from_state.</param>
        /// <param name="toState">to_state.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogObjectType">catalog_object_type.</param>
        /// <param name="quantity">quantity.</param>
        /// <param name="totalPriceMoney">total_price_money.</param>
        /// <param name="occurredAt">occurred_at.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="source">source.</param>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        /// <param name="transactionId">transaction_id.</param>
        /// <param name="refundId">refund_id.</param>
        /// <param name="purchaseOrderId">purchase_order_id.</param>
        /// <param name="goodsReceiptId">goods_receipt_id.</param>
        /// <param name="adjustmentGroup">adjustment_group.</param>
        public InventoryAdjustment(
            string id = null,
            string referenceId = null,
            string fromState = null,
            string toState = null,
            string locationId = null,
            string catalogObjectId = null,
            string catalogObjectType = null,
            string quantity = null,
            Models.Money totalPriceMoney = null,
            string occurredAt = null,
            string createdAt = null,
            Models.SourceApplication source = null,
            string employeeId = null,
            string teamMemberId = null,
            string transactionId = null,
            string refundId = null,
            string purchaseOrderId = null,
            string goodsReceiptId = null,
            Models.InventoryAdjustmentGroup adjustmentGroup = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "reference_id", false },
                { "location_id", false },
                { "catalog_object_id", false },
                { "catalog_object_type", false },
                { "quantity", false },
                { "occurred_at", false },
                { "employee_id", false },
                { "team_member_id", false },
            };
            this.Id = id;

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }
            this.FromState = fromState;
            this.ToState = toState;

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
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
            this.TotalPriceMoney = totalPriceMoney;

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
            this.TransactionId = transactionId;
            this.RefundId = refundId;
            this.PurchaseOrderId = purchaseOrderId;
            this.GoodsReceiptId = goodsReceiptId;
            this.AdjustmentGroup = adjustmentGroup;
        }

        internal InventoryAdjustment(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string referenceId = null,
            string fromState = null,
            string toState = null,
            string locationId = null,
            string catalogObjectId = null,
            string catalogObjectType = null,
            string quantity = null,
            Models.Money totalPriceMoney = null,
            string occurredAt = null,
            string createdAt = null,
            Models.SourceApplication source = null,
            string employeeId = null,
            string teamMemberId = null,
            string transactionId = null,
            string refundId = null,
            string purchaseOrderId = null,
            string goodsReceiptId = null,
            Models.InventoryAdjustmentGroup adjustmentGroup = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            ReferenceId = referenceId;
            FromState = fromState;
            ToState = toState;
            LocationId = locationId;
            CatalogObjectId = catalogObjectId;
            CatalogObjectType = catalogObjectType;
            Quantity = quantity;
            TotalPriceMoney = totalPriceMoney;
            OccurredAt = occurredAt;
            CreatedAt = createdAt;
            Source = source;
            EmployeeId = employeeId;
            TeamMemberId = teamMemberId;
            TransactionId = transactionId;
            RefundId = refundId;
            PurchaseOrderId = purchaseOrderId;
            GoodsReceiptId = goodsReceiptId;
            AdjustmentGroup = adjustmentGroup;
        }

        /// <summary>
        /// A unique ID generated by Square for the
        /// `InventoryAdjustment`.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// An optional ID provided by the application to tie the
        /// `InventoryAdjustment` to an external
        /// system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("from_state", NullValueHandling = NullValueHandling.Ignore)]
        public string FromState { get; }

        /// <summary>
        /// Indicates the state of a tracked item quantity in the lifecycle of goods.
        /// </summary>
        [JsonProperty("to_state", NullValueHandling = NullValueHandling.Ignore)]
        public string ToState { get; }

        /// <summary>
        /// The Square-generated ID of the [Location](entity:Location) where the related
        /// quantity of items is being tracked.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

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
        /// The number of items affected by the adjustment as a decimal string.
        /// Can support up to 5 digits after the decimal point.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalPriceMoney { get; }

        /// <summary>
        /// A client-generated RFC 3339-formatted timestamp that indicates when
        /// the inventory adjustment took place. For inventory adjustment updates, the `occurred_at`
        /// timestamp cannot be older than 24 hours or in the future relative to the
        /// time of the request.
        /// </summary>
        [JsonProperty("occurred_at")]
        public string OccurredAt { get; }

        /// <summary>
        /// An RFC 3339-formatted timestamp that indicates when the inventory adjustment is received.
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
        /// inventory adjustment.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// The Square-generated ID of the [Team Member](entity:TeamMember) responsible for the
        /// inventory adjustment.
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <summary>
        /// The Square-generated ID of the [Transaction](entity:Transaction) that
        /// caused the adjustment. Only relevant for payment-related state
        /// transitions.
        /// </summary>
        [JsonProperty("transaction_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TransactionId { get; }

        /// <summary>
        /// The Square-generated ID of the [Refund](entity:Refund) that
        /// caused the adjustment. Only relevant for refund-related state
        /// transitions.
        /// </summary>
        [JsonProperty("refund_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundId { get; }

        /// <summary>
        /// The Square-generated ID of the purchase order that caused the
        /// adjustment. Only relevant for state transitions from the Square for Retail
        /// app.
        /// </summary>
        [JsonProperty("purchase_order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string PurchaseOrderId { get; }

        /// <summary>
        /// The Square-generated ID of the goods receipt that caused the
        /// adjustment. Only relevant for state transitions from the Square for Retail
        /// app.
        /// </summary>
        [JsonProperty("goods_receipt_id", NullValueHandling = NullValueHandling.Ignore)]
        public string GoodsReceiptId { get; }

        /// <summary>
        /// Gets or sets AdjustmentGroup.
        /// </summary>
        [JsonProperty("adjustment_group", NullValueHandling = NullValueHandling.Ignore)]
        public Models.InventoryAdjustmentGroup AdjustmentGroup { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"InventoryAdjustment : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is InventoryAdjustment other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.ReferenceId == null && other.ReferenceId == null
                    || this.ReferenceId?.Equals(other.ReferenceId) == true
                )
                && (
                    this.FromState == null && other.FromState == null
                    || this.FromState?.Equals(other.FromState) == true
                )
                && (
                    this.ToState == null && other.ToState == null
                    || this.ToState?.Equals(other.ToState) == true
                )
                && (
                    this.LocationId == null && other.LocationId == null
                    || this.LocationId?.Equals(other.LocationId) == true
                )
                && (
                    this.CatalogObjectId == null && other.CatalogObjectId == null
                    || this.CatalogObjectId?.Equals(other.CatalogObjectId) == true
                )
                && (
                    this.CatalogObjectType == null && other.CatalogObjectType == null
                    || this.CatalogObjectType?.Equals(other.CatalogObjectType) == true
                )
                && (
                    this.Quantity == null && other.Quantity == null
                    || this.Quantity?.Equals(other.Quantity) == true
                )
                && (
                    this.TotalPriceMoney == null && other.TotalPriceMoney == null
                    || this.TotalPriceMoney?.Equals(other.TotalPriceMoney) == true
                )
                && (
                    this.OccurredAt == null && other.OccurredAt == null
                    || this.OccurredAt?.Equals(other.OccurredAt) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.Source == null && other.Source == null
                    || this.Source?.Equals(other.Source) == true
                )
                && (
                    this.EmployeeId == null && other.EmployeeId == null
                    || this.EmployeeId?.Equals(other.EmployeeId) == true
                )
                && (
                    this.TeamMemberId == null && other.TeamMemberId == null
                    || this.TeamMemberId?.Equals(other.TeamMemberId) == true
                )
                && (
                    this.TransactionId == null && other.TransactionId == null
                    || this.TransactionId?.Equals(other.TransactionId) == true
                )
                && (
                    this.RefundId == null && other.RefundId == null
                    || this.RefundId?.Equals(other.RefundId) == true
                )
                && (
                    this.PurchaseOrderId == null && other.PurchaseOrderId == null
                    || this.PurchaseOrderId?.Equals(other.PurchaseOrderId) == true
                )
                && (
                    this.GoodsReceiptId == null && other.GoodsReceiptId == null
                    || this.GoodsReceiptId?.Equals(other.GoodsReceiptId) == true
                )
                && (
                    this.AdjustmentGroup == null && other.AdjustmentGroup == null
                    || this.AdjustmentGroup?.Equals(other.AdjustmentGroup) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1008310977;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.ReferenceId,
                this.FromState,
                this.ToState,
                this.LocationId,
                this.CatalogObjectId,
                this.CatalogObjectType
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.Quantity,
                this.TotalPriceMoney,
                this.OccurredAt,
                this.CreatedAt,
                this.Source,
                this.EmployeeId,
                this.TeamMemberId
            );

            hashCode = HashCode.Combine(
                hashCode,
                this.TransactionId,
                this.RefundId,
                this.PurchaseOrderId,
                this.GoodsReceiptId,
                this.AdjustmentGroup
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.ReferenceId = {this.ReferenceId ?? "null"}");
            toStringOutput.Add(
                $"this.FromState = {(this.FromState == null ? "null" : this.FromState.ToString())}"
            );
            toStringOutput.Add(
                $"this.ToState = {(this.ToState == null ? "null" : this.ToState.ToString())}"
            );
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.CatalogObjectId = {this.CatalogObjectId ?? "null"}");
            toStringOutput.Add($"this.CatalogObjectType = {this.CatalogObjectType ?? "null"}");
            toStringOutput.Add($"this.Quantity = {this.Quantity ?? "null"}");
            toStringOutput.Add(
                $"this.TotalPriceMoney = {(this.TotalPriceMoney == null ? "null" : this.TotalPriceMoney.ToString())}"
            );
            toStringOutput.Add($"this.OccurredAt = {this.OccurredAt ?? "null"}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add(
                $"this.Source = {(this.Source == null ? "null" : this.Source.ToString())}"
            );
            toStringOutput.Add($"this.EmployeeId = {this.EmployeeId ?? "null"}");
            toStringOutput.Add($"this.TeamMemberId = {this.TeamMemberId ?? "null"}");
            toStringOutput.Add($"this.TransactionId = {this.TransactionId ?? "null"}");
            toStringOutput.Add($"this.RefundId = {this.RefundId ?? "null"}");
            toStringOutput.Add($"this.PurchaseOrderId = {this.PurchaseOrderId ?? "null"}");
            toStringOutput.Add($"this.GoodsReceiptId = {this.GoodsReceiptId ?? "null"}");
            toStringOutput.Add(
                $"this.AdjustmentGroup = {(this.AdjustmentGroup == null ? "null" : this.AdjustmentGroup.ToString())}"
            );
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
                .FromState(this.FromState)
                .ToState(this.ToState)
                .LocationId(this.LocationId)
                .CatalogObjectId(this.CatalogObjectId)
                .CatalogObjectType(this.CatalogObjectType)
                .Quantity(this.Quantity)
                .TotalPriceMoney(this.TotalPriceMoney)
                .OccurredAt(this.OccurredAt)
                .CreatedAt(this.CreatedAt)
                .Source(this.Source)
                .EmployeeId(this.EmployeeId)
                .TeamMemberId(this.TeamMemberId)
                .TransactionId(this.TransactionId)
                .RefundId(this.RefundId)
                .PurchaseOrderId(this.PurchaseOrderId)
                .GoodsReceiptId(this.GoodsReceiptId)
                .AdjustmentGroup(this.AdjustmentGroup);
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
                { "location_id", false },
                { "catalog_object_id", false },
                { "catalog_object_type", false },
                { "quantity", false },
                { "occurred_at", false },
                { "employee_id", false },
                { "team_member_id", false },
            };

            private string id;
            private string referenceId;
            private string fromState;
            private string toState;
            private string locationId;
            private string catalogObjectId;
            private string catalogObjectType;
            private string quantity;
            private Models.Money totalPriceMoney;
            private string occurredAt;
            private string createdAt;
            private Models.SourceApplication source;
            private string employeeId;
            private string teamMemberId;
            private string transactionId;
            private string refundId;
            private string purchaseOrderId;
            private string goodsReceiptId;
            private Models.InventoryAdjustmentGroup adjustmentGroup;

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
            /// FromState.
            /// </summary>
            /// <param name="fromState"> fromState. </param>
            /// <returns> Builder. </returns>
            public Builder FromState(string fromState)
            {
                this.fromState = fromState;
                return this;
            }

            /// <summary>
            /// ToState.
            /// </summary>
            /// <param name="toState"> toState. </param>
            /// <returns> Builder. </returns>
            public Builder ToState(string toState)
            {
                this.toState = toState;
                return this;
            }

            /// <summary>
            /// LocationId.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
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
            /// TotalPriceMoney.
            /// </summary>
            /// <param name="totalPriceMoney"> totalPriceMoney. </param>
            /// <returns> Builder. </returns>
            public Builder TotalPriceMoney(Models.Money totalPriceMoney)
            {
                this.totalPriceMoney = totalPriceMoney;
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
            /// TransactionId.
            /// </summary>
            /// <param name="transactionId"> transactionId. </param>
            /// <returns> Builder. </returns>
            public Builder TransactionId(string transactionId)
            {
                this.transactionId = transactionId;
                return this;
            }

            /// <summary>
            /// RefundId.
            /// </summary>
            /// <param name="refundId"> refundId. </param>
            /// <returns> Builder. </returns>
            public Builder RefundId(string refundId)
            {
                this.refundId = refundId;
                return this;
            }

            /// <summary>
            /// PurchaseOrderId.
            /// </summary>
            /// <param name="purchaseOrderId"> purchaseOrderId. </param>
            /// <returns> Builder. </returns>
            public Builder PurchaseOrderId(string purchaseOrderId)
            {
                this.purchaseOrderId = purchaseOrderId;
                return this;
            }

            /// <summary>
            /// GoodsReceiptId.
            /// </summary>
            /// <param name="goodsReceiptId"> goodsReceiptId. </param>
            /// <returns> Builder. </returns>
            public Builder GoodsReceiptId(string goodsReceiptId)
            {
                this.goodsReceiptId = goodsReceiptId;
                return this;
            }

            /// <summary>
            /// AdjustmentGroup.
            /// </summary>
            /// <param name="adjustmentGroup"> adjustmentGroup. </param>
            /// <returns> Builder. </returns>
            public Builder AdjustmentGroup(Models.InventoryAdjustmentGroup adjustmentGroup)
            {
                this.adjustmentGroup = adjustmentGroup;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCatalogObjectId()
            {
                this.shouldSerialize["catalog_object_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCatalogObjectType()
            {
                this.shouldSerialize["catalog_object_type"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetQuantity()
            {
                this.shouldSerialize["quantity"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOccurredAt()
            {
                this.shouldSerialize["occurred_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetEmployeeId()
            {
                this.shouldSerialize["employee_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetTeamMemberId()
            {
                this.shouldSerialize["team_member_id"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InventoryAdjustment. </returns>
            public InventoryAdjustment Build()
            {
                return new InventoryAdjustment(
                    shouldSerialize,
                    this.id,
                    this.referenceId,
                    this.fromState,
                    this.toState,
                    this.locationId,
                    this.catalogObjectId,
                    this.catalogObjectType,
                    this.quantity,
                    this.totalPriceMoney,
                    this.occurredAt,
                    this.createdAt,
                    this.source,
                    this.employeeId,
                    this.teamMemberId,
                    this.transactionId,
                    this.refundId,
                    this.purchaseOrderId,
                    this.goodsReceiptId,
                    this.adjustmentGroup
                );
            }
        }
    }
}
