namespace Square.Models
{
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
    using Square;
    using Square.Utilities;

    /// <summary>
    /// PaymentRefund.
    /// </summary>
    public class PaymentRefund
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentRefund"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="status">status.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="unlinked">unlinked.</param>
        /// <param name="destinationType">destination_type.</param>
        /// <param name="destinationDetails">destination_details.</param>
        /// <param name="appFeeMoney">app_fee_money.</param>
        /// <param name="processingFee">processing_fee.</param>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="reason">reason.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        public PaymentRefund(
            string id,
            Models.Money amountMoney,
            string status = null,
            string locationId = null,
            bool? unlinked = null,
            string destinationType = null,
            Models.DestinationDetails destinationDetails = null,
            Models.Money appFeeMoney = null,
            IList<Models.ProcessingFee> processingFee = null,
            string paymentId = null,
            string orderId = null,
            string reason = null,
            string createdAt = null,
            string updatedAt = null,
            string teamMemberId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "status", false },
                { "location_id", false },
                { "destination_type", false },
                { "processing_fee", false },
                { "payment_id", false },
                { "order_id", false },
                { "reason", false }
            };

            this.Id = id;
            if (status != null)
            {
                shouldSerialize["status"] = true;
                this.Status = status;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            this.Unlinked = unlinked;
            if (destinationType != null)
            {
                shouldSerialize["destination_type"] = true;
                this.DestinationType = destinationType;
            }

            this.DestinationDetails = destinationDetails;
            this.AmountMoney = amountMoney;
            this.AppFeeMoney = appFeeMoney;
            if (processingFee != null)
            {
                shouldSerialize["processing_fee"] = true;
                this.ProcessingFee = processingFee;
            }

            if (paymentId != null)
            {
                shouldSerialize["payment_id"] = true;
                this.PaymentId = paymentId;
            }

            if (orderId != null)
            {
                shouldSerialize["order_id"] = true;
                this.OrderId = orderId;
            }

            if (reason != null)
            {
                shouldSerialize["reason"] = true;
                this.Reason = reason;
            }

            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.TeamMemberId = teamMemberId;
        }
        internal PaymentRefund(Dictionary<string, bool> shouldSerialize,
            string id,
            Models.Money amountMoney,
            string status = null,
            string locationId = null,
            bool? unlinked = null,
            string destinationType = null,
            Models.DestinationDetails destinationDetails = null,
            Models.Money appFeeMoney = null,
            IList<Models.ProcessingFee> processingFee = null,
            string paymentId = null,
            string orderId = null,
            string reason = null,
            string createdAt = null,
            string updatedAt = null,
            string teamMemberId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Status = status;
            LocationId = locationId;
            Unlinked = unlinked;
            DestinationType = destinationType;
            DestinationDetails = destinationDetails;
            AmountMoney = amountMoney;
            AppFeeMoney = appFeeMoney;
            ProcessingFee = processingFee;
            PaymentId = paymentId;
            OrderId = orderId;
            Reason = reason;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            TeamMemberId = teamMemberId;
        }

        /// <summary>
        /// The unique ID for this refund, generated by Square.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The refund's status:
        /// - `PENDING` - Awaiting approval.
        /// - `COMPLETED` - Successfully completed.
        /// - `REJECTED` - The refund was rejected.
        /// - `FAILED` - An error occurred.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The location ID associated with the payment this refund is attached to.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Flag indicating whether or not the refund is linked to an existing payment in Square.
        /// </summary>
        [JsonProperty("unlinked", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Unlinked { get; }

        /// <summary>
        /// The destination type for this refund.
        /// Current values include `CARD`, `BANK_ACCOUNT`, `WALLET`, `BUY_NOW_PAY_LATER`, `CASH`,
        /// `EXTERNAL`, and `SQUARE_ACCOUNT`.
        /// </summary>
        [JsonProperty("destination_type")]
        public string DestinationType { get; }

        /// <summary>
        /// Details about a refund's destination.
        /// </summary>
        [JsonProperty("destination_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DestinationDetails DestinationDetails { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("app_fee_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppFeeMoney { get; }

        /// <summary>
        /// Processing fees and fee adjustments assessed by Square for this refund.
        /// </summary>
        [JsonProperty("processing_fee")]
        public IList<Models.ProcessingFee> ProcessingFee { get; }

        /// <summary>
        /// The ID of the payment associated with this refund.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// The ID of the order associated with the refund.
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <summary>
        /// The reason for the refund.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <summary>
        /// The timestamp of when the refund was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp of when the refund was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// An optional ID of the team member associated with taking the payment.
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"PaymentRefund : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatus()
        {
            return this.shouldSerialize["status"];
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
        public bool ShouldSerializeDestinationType()
        {
            return this.shouldSerialize["destination_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeProcessingFee()
        {
            return this.shouldSerialize["processing_fee"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentId()
        {
            return this.shouldSerialize["payment_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderId()
        {
            return this.shouldSerialize["order_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReason()
        {
            return this.shouldSerialize["reason"];
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
            return obj is PaymentRefund other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Unlinked == null && other.Unlinked == null) || (this.Unlinked?.Equals(other.Unlinked) == true)) &&
                ((this.DestinationType == null && other.DestinationType == null) || (this.DestinationType?.Equals(other.DestinationType) == true)) &&
                ((this.DestinationDetails == null && other.DestinationDetails == null) || (this.DestinationDetails?.Equals(other.DestinationDetails) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.AppFeeMoney == null && other.AppFeeMoney == null) || (this.AppFeeMoney?.Equals(other.AppFeeMoney) == true)) &&
                ((this.ProcessingFee == null && other.ProcessingFee == null) || (this.ProcessingFee?.Equals(other.ProcessingFee) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 181999010;
            hashCode = HashCode.Combine(this.Id, this.Status, this.LocationId, this.Unlinked, this.DestinationType, this.DestinationDetails, this.AmountMoney);

            hashCode = HashCode.Combine(hashCode, this.AppFeeMoney, this.ProcessingFee, this.PaymentId, this.OrderId, this.Reason, this.CreatedAt, this.UpdatedAt);

            hashCode = HashCode.Combine(hashCode, this.TeamMemberId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Unlinked = {(this.Unlinked == null ? "null" : this.Unlinked.ToString())}");
            toStringOutput.Add($"this.DestinationType = {(this.DestinationType == null ? "null" : this.DestinationType)}");
            toStringOutput.Add($"this.DestinationDetails = {(this.DestinationDetails == null ? "null" : this.DestinationDetails.ToString())}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.AppFeeMoney = {(this.AppFeeMoney == null ? "null" : this.AppFeeMoney.ToString())}");
            toStringOutput.Add($"this.ProcessingFee = {(this.ProcessingFee == null ? "null" : $"[{string.Join(", ", this.ProcessingFee)} ]")}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId)}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Id,
                this.AmountMoney)
                .Status(this.Status)
                .LocationId(this.LocationId)
                .Unlinked(this.Unlinked)
                .DestinationType(this.DestinationType)
                .DestinationDetails(this.DestinationDetails)
                .AppFeeMoney(this.AppFeeMoney)
                .ProcessingFee(this.ProcessingFee)
                .PaymentId(this.PaymentId)
                .OrderId(this.OrderId)
                .Reason(this.Reason)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
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
                { "status", false },
                { "location_id", false },
                { "destination_type", false },
                { "processing_fee", false },
                { "payment_id", false },
                { "order_id", false },
                { "reason", false },
            };

            private string id;
            private Models.Money amountMoney;
            private string status;
            private string locationId;
            private bool? unlinked;
            private string destinationType;
            private Models.DestinationDetails destinationDetails;
            private Models.Money appFeeMoney;
            private IList<Models.ProcessingFee> processingFee;
            private string paymentId;
            private string orderId;
            private string reason;
            private string createdAt;
            private string updatedAt;
            private string teamMemberId;

            /// <summary>
            /// Initialize Builder for PaymentRefund.
            /// </summary>
            /// <param name="id"> id. </param>
            /// <param name="amountMoney"> amountMoney. </param>
            public Builder(
                string id,
                Models.Money amountMoney)
            {
                this.id = id;
                this.amountMoney = amountMoney;
            }

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
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                shouldSerialize["status"] = true;
                this.status = status;
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
             /// Unlinked.
             /// </summary>
             /// <param name="unlinked"> unlinked. </param>
             /// <returns> Builder. </returns>
            public Builder Unlinked(bool? unlinked)
            {
                this.unlinked = unlinked;
                return this;
            }

             /// <summary>
             /// DestinationType.
             /// </summary>
             /// <param name="destinationType"> destinationType. </param>
             /// <returns> Builder. </returns>
            public Builder DestinationType(string destinationType)
            {
                shouldSerialize["destination_type"] = true;
                this.destinationType = destinationType;
                return this;
            }

             /// <summary>
             /// DestinationDetails.
             /// </summary>
             /// <param name="destinationDetails"> destinationDetails. </param>
             /// <returns> Builder. </returns>
            public Builder DestinationDetails(Models.DestinationDetails destinationDetails)
            {
                this.destinationDetails = destinationDetails;
                return this;
            }

             /// <summary>
             /// AppFeeMoney.
             /// </summary>
             /// <param name="appFeeMoney"> appFeeMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppFeeMoney(Models.Money appFeeMoney)
            {
                this.appFeeMoney = appFeeMoney;
                return this;
            }

             /// <summary>
             /// ProcessingFee.
             /// </summary>
             /// <param name="processingFee"> processingFee. </param>
             /// <returns> Builder. </returns>
            public Builder ProcessingFee(IList<Models.ProcessingFee> processingFee)
            {
                shouldSerialize["processing_fee"] = true;
                this.processingFee = processingFee;
                return this;
            }

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                shouldSerialize["payment_id"] = true;
                this.paymentId = paymentId;
                return this;
            }

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                shouldSerialize["order_id"] = true;
                this.orderId = orderId;
                return this;
            }

             /// <summary>
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                shouldSerialize["reason"] = true;
                this.reason = reason;
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
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStatus()
            {
                this.shouldSerialize["status"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDestinationType()
            {
                this.shouldSerialize["destination_type"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetProcessingFee()
            {
                this.shouldSerialize["processing_fee"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentId()
            {
                this.shouldSerialize["payment_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOrderId()
            {
                this.shouldSerialize["order_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReason()
            {
                this.shouldSerialize["reason"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaymentRefund. </returns>
            public PaymentRefund Build()
            {
                return new PaymentRefund(shouldSerialize,
                    this.id,
                    this.amountMoney,
                    this.status,
                    this.locationId,
                    this.unlinked,
                    this.destinationType,
                    this.destinationDetails,
                    this.appFeeMoney,
                    this.processingFee,
                    this.paymentId,
                    this.orderId,
                    this.reason,
                    this.createdAt,
                    this.updatedAt,
                    this.teamMemberId);
            }
        }
    }
}