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
    /// TerminalRefund.
    /// </summary>
    public class TerminalRefund
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="TerminalRefund"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="reason">reason.</param>
        /// <param name="deviceId">device_id.</param>
        /// <param name="id">id.</param>
        /// <param name="refundId">refund_id.</param>
        /// <param name="orderId">order_id.</param>
        /// <param name="deadlineDuration">deadline_duration.</param>
        /// <param name="status">status.</param>
        /// <param name="cancelReason">cancel_reason.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="appId">app_id.</param>
        /// <param name="locationId">location_id.</param>
        public TerminalRefund(
            string paymentId,
            Models.Money amountMoney,
            string reason,
            string deviceId,
            string id = null,
            string refundId = null,
            string orderId = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            string createdAt = null,
            string updatedAt = null,
            string appId = null,
            string locationId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "deadline_duration", false }
            };

            this.Id = id;
            this.RefundId = refundId;
            this.PaymentId = paymentId;
            this.OrderId = orderId;
            this.AmountMoney = amountMoney;
            this.Reason = reason;
            this.DeviceId = deviceId;
            if (deadlineDuration != null)
            {
                shouldSerialize["deadline_duration"] = true;
                this.DeadlineDuration = deadlineDuration;
            }

            this.Status = status;
            this.CancelReason = cancelReason;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.AppId = appId;
            this.LocationId = locationId;
        }
        internal TerminalRefund(Dictionary<string, bool> shouldSerialize,
            string paymentId,
            Models.Money amountMoney,
            string reason,
            string deviceId,
            string id = null,
            string refundId = null,
            string orderId = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            string createdAt = null,
            string updatedAt = null,
            string appId = null,
            string locationId = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            RefundId = refundId;
            PaymentId = paymentId;
            OrderId = orderId;
            AmountMoney = amountMoney;
            Reason = reason;
            DeviceId = deviceId;
            DeadlineDuration = deadlineDuration;
            Status = status;
            CancelReason = cancelReason;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            AppId = appId;
            LocationId = locationId;
        }

        /// <summary>
        /// A unique ID for this `TerminalRefund`.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The reference to the payment refund created by completing this `TerminalRefund`.
        /// </summary>
        [JsonProperty("refund_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundId { get; }

        /// <summary>
        /// The unique ID of the payment being refunded.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// The reference to the Square order ID for the payment identified by the `payment_id`.
        /// </summary>
        [JsonProperty("order_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; }

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
        /// A description of the reason for the refund.
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; }

        /// <summary>
        /// The unique ID of the device intended for this `TerminalRefund`.
        /// The Id can be retrieved from /v2/devices api.
        /// </summary>
        [JsonProperty("device_id")]
        public string DeviceId { get; }

        /// <summary>
        /// The RFC 3339 duration, after which the refund is automatically canceled.
        /// A `TerminalRefund` that is `PENDING` is automatically `CANCELED` and has a cancellation reason
        /// of `TIMED_OUT`.
        /// Default: 5 minutes from creation.
        /// Maximum: 5 minutes
        /// </summary>
        [JsonProperty("deadline_duration")]
        public string DeadlineDuration { get; }

        /// <summary>
        /// The status of the `TerminalRefund`.
        /// Options: `PENDING`, `IN_PROGRESS`, `CANCEL_REQUESTED`, `CANCELED`, or `COMPLETED`.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Gets or sets CancelReason.
        /// </summary>
        [JsonProperty("cancel_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelReason { get; }

        /// <summary>
        /// The time when the `TerminalRefund` was created, as an RFC 3339 timestamp.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the `TerminalRefund` was last updated, as an RFC 3339 timestamp.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The ID of the application that created the refund.
        /// </summary>
        [JsonProperty("app_id", NullValueHandling = NullValueHandling.Ignore)]
        public string AppId { get; }

        /// <summary>
        /// The location of the device where the `TerminalRefund` was directed.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalRefund : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeadlineDuration()
        {
            return this.shouldSerialize["deadline_duration"];
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

            return obj is TerminalRefund other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.RefundId == null && other.RefundId == null) || (this.RefundId?.Equals(other.RefundId) == true)) &&
                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.DeviceId == null && other.DeviceId == null) || (this.DeviceId?.Equals(other.DeviceId) == true)) &&
                ((this.DeadlineDuration == null && other.DeadlineDuration == null) || (this.DeadlineDuration?.Equals(other.DeadlineDuration) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.CancelReason == null && other.CancelReason == null) || (this.CancelReason?.Equals(other.CancelReason) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.AppId == null && other.AppId == null) || (this.AppId?.Equals(other.AppId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 973053086;
            hashCode = HashCode.Combine(this.Id, this.RefundId, this.PaymentId, this.OrderId, this.AmountMoney, this.Reason, this.DeviceId);

            hashCode = HashCode.Combine(hashCode, this.DeadlineDuration, this.Status, this.CancelReason, this.CreatedAt, this.UpdatedAt, this.AppId, this.LocationId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.RefundId = {(this.RefundId == null ? "null" : this.RefundId == string.Empty ? "" : this.RefundId)}");
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId == string.Empty ? "" : this.PaymentId)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason == string.Empty ? "" : this.Reason)}");
            toStringOutput.Add($"this.DeviceId = {(this.DeviceId == null ? "null" : this.DeviceId == string.Empty ? "" : this.DeviceId)}");
            toStringOutput.Add($"this.DeadlineDuration = {(this.DeadlineDuration == null ? "null" : this.DeadlineDuration == string.Empty ? "" : this.DeadlineDuration)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status == string.Empty ? "" : this.Status)}");
            toStringOutput.Add($"this.CancelReason = {(this.CancelReason == null ? "null" : this.CancelReason.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
            toStringOutput.Add($"this.AppId = {(this.AppId == null ? "null" : this.AppId == string.Empty ? "" : this.AppId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.PaymentId,
                this.AmountMoney,
                this.Reason,
                this.DeviceId)
                .Id(this.Id)
                .RefundId(this.RefundId)
                .OrderId(this.OrderId)
                .DeadlineDuration(this.DeadlineDuration)
                .Status(this.Status)
                .CancelReason(this.CancelReason)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .AppId(this.AppId)
                .LocationId(this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "deadline_duration", false },
            };

            private string paymentId;
            private Models.Money amountMoney;
            private string reason;
            private string deviceId;
            private string id;
            private string refundId;
            private string orderId;
            private string deadlineDuration;
            private string status;
            private string cancelReason;
            private string createdAt;
            private string updatedAt;
            private string appId;
            private string locationId;

            public Builder(
                string paymentId,
                Models.Money amountMoney,
                string reason,
                string deviceId)
            {
                this.paymentId = paymentId;
                this.amountMoney = amountMoney;
                this.reason = reason;
                this.deviceId = deviceId;
            }

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
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
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

             /// <summary>
             /// DeviceId.
             /// </summary>
             /// <param name="deviceId"> deviceId. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
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
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

             /// <summary>
             /// DeadlineDuration.
             /// </summary>
             /// <param name="deadlineDuration"> deadlineDuration. </param>
             /// <returns> Builder. </returns>
            public Builder DeadlineDuration(string deadlineDuration)
            {
                shouldSerialize["deadline_duration"] = true;
                this.deadlineDuration = deadlineDuration;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// CancelReason.
             /// </summary>
             /// <param name="cancelReason"> cancelReason. </param>
             /// <returns> Builder. </returns>
            public Builder CancelReason(string cancelReason)
            {
                this.cancelReason = cancelReason;
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
             /// AppId.
             /// </summary>
             /// <param name="appId"> appId. </param>
             /// <returns> Builder. </returns>
            public Builder AppId(string appId)
            {
                this.appId = appId;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDeadlineDuration()
            {
                this.shouldSerialize["deadline_duration"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> TerminalRefund. </returns>
            public TerminalRefund Build()
            {
                return new TerminalRefund(shouldSerialize,
                    this.paymentId,
                    this.amountMoney,
                    this.reason,
                    this.deviceId,
                    this.id,
                    this.refundId,
                    this.orderId,
                    this.deadlineDuration,
                    this.status,
                    this.cancelReason,
                    this.createdAt,
                    this.updatedAt,
                    this.appId,
                    this.locationId);
            }
        }
    }
}