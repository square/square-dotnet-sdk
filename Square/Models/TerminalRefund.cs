
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
    public class TerminalRefund 
    {
        public TerminalRefund(string paymentId,
            Models.Money amountMoney,
            string id = null,
            string refundId = null,
            string orderId = null,
            string reason = null,
            string deviceId = null,
            string deadlineDuration = null,
            string status = null,
            string cancelReason = null,
            string createdAt = null,
            string updatedAt = null)
        {
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
        }

        /// <summary>
        /// A unique ID for this `TerminalRefund`
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The reference to the payment refund created by completing this `TerminalRefund`.
        /// </summary>
        [JsonProperty("refund_id", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundId { get; }

        /// <summary>
        /// Unique ID of the payment being refunded.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// The reference to the Square order id for the payment identified by the `payment_id`.
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
        /// Note: maximum 192 characters
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; }

        /// <summary>
        /// The unique Id of the device intended for this `TerminalRefund`.
        /// The Id can be retrieved from /v2/devices api.
        /// </summary>
        [JsonProperty("device_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DeviceId { get; }

        /// <summary>
        /// The duration as an RFC 3339 duration, after which the refund will be automatically canceled.
        /// TerminalRefunds that are `PENDING` will be automatically `CANCELED` and have a cancellation reason
        /// of `TIMED_OUT`
        /// Default: 5 minutes from creation
        /// Maximum: 5 minutes
        /// </summary>
        [JsonProperty("deadline_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string DeadlineDuration { get; }

        /// <summary>
        /// The status of the `TerminalRefund`.
        /// Options: `PENDING`, `IN_PROGRESS`, `CANCELED`, `COMPLETED`
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Getter for cancel_reason
        /// </summary>
        [JsonProperty("cancel_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelReason { get; }

        /// <summary>
        /// The time when the `TerminalRefund` was created as an RFC 3339 timestamp.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the `TerminalRefund` was last updated as an RFC 3339 timestamp.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"TerminalRefund : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"RefundId = {(RefundId == null ? "null" : RefundId == string.Empty ? "" : RefundId)}");
            toStringOutput.Add($"PaymentId = {(PaymentId == null ? "null" : PaymentId == string.Empty ? "" : PaymentId)}");
            toStringOutput.Add($"OrderId = {(OrderId == null ? "null" : OrderId == string.Empty ? "" : OrderId)}");
            toStringOutput.Add($"AmountMoney = {(AmountMoney == null ? "null" : AmountMoney.ToString())}");
            toStringOutput.Add($"Reason = {(Reason == null ? "null" : Reason == string.Empty ? "" : Reason)}");
            toStringOutput.Add($"DeviceId = {(DeviceId == null ? "null" : DeviceId == string.Empty ? "" : DeviceId)}");
            toStringOutput.Add($"DeadlineDuration = {(DeadlineDuration == null ? "null" : DeadlineDuration == string.Empty ? "" : DeadlineDuration)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status == string.Empty ? "" : Status)}");
            toStringOutput.Add($"CancelReason = {(CancelReason == null ? "null" : CancelReason.ToString())}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
        }

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
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((RefundId == null && other.RefundId == null) || (RefundId?.Equals(other.RefundId) == true)) &&
                ((PaymentId == null && other.PaymentId == null) || (PaymentId?.Equals(other.PaymentId) == true)) &&
                ((OrderId == null && other.OrderId == null) || (OrderId?.Equals(other.OrderId) == true)) &&
                ((AmountMoney == null && other.AmountMoney == null) || (AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((Reason == null && other.Reason == null) || (Reason?.Equals(other.Reason) == true)) &&
                ((DeviceId == null && other.DeviceId == null) || (DeviceId?.Equals(other.DeviceId) == true)) &&
                ((DeadlineDuration == null && other.DeadlineDuration == null) || (DeadlineDuration?.Equals(other.DeadlineDuration) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((CancelReason == null && other.CancelReason == null) || (CancelReason?.Equals(other.CancelReason) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1855433710;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (RefundId != null)
            {
               hashCode += RefundId.GetHashCode();
            }

            if (PaymentId != null)
            {
               hashCode += PaymentId.GetHashCode();
            }

            if (OrderId != null)
            {
               hashCode += OrderId.GetHashCode();
            }

            if (AmountMoney != null)
            {
               hashCode += AmountMoney.GetHashCode();
            }

            if (Reason != null)
            {
               hashCode += Reason.GetHashCode();
            }

            if (DeviceId != null)
            {
               hashCode += DeviceId.GetHashCode();
            }

            if (DeadlineDuration != null)
            {
               hashCode += DeadlineDuration.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (CancelReason != null)
            {
               hashCode += CancelReason.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(PaymentId,
                AmountMoney)
                .Id(Id)
                .RefundId(RefundId)
                .OrderId(OrderId)
                .Reason(Reason)
                .DeviceId(DeviceId)
                .DeadlineDuration(DeadlineDuration)
                .Status(Status)
                .CancelReason(CancelReason)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string paymentId;
            private Models.Money amountMoney;
            private string id;
            private string refundId;
            private string orderId;
            private string reason;
            private string deviceId;
            private string deadlineDuration;
            private string status;
            private string cancelReason;
            private string createdAt;
            private string updatedAt;

            public Builder(string paymentId,
                Models.Money amountMoney)
            {
                this.paymentId = paymentId;
                this.amountMoney = amountMoney;
            }

            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder RefundId(string refundId)
            {
                this.refundId = refundId;
                return this;
            }

            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

            public Builder DeviceId(string deviceId)
            {
                this.deviceId = deviceId;
                return this;
            }

            public Builder DeadlineDuration(string deadlineDuration)
            {
                this.deadlineDuration = deadlineDuration;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder CancelReason(string cancelReason)
            {
                this.cancelReason = cancelReason;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public TerminalRefund Build()
            {
                return new TerminalRefund(paymentId,
                    amountMoney,
                    id,
                    refundId,
                    orderId,
                    reason,
                    deviceId,
                    deadlineDuration,
                    status,
                    cancelReason,
                    createdAt,
                    updatedAt);
            }
        }
    }
}