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
        /// Options: `PENDING`, `IN\_PROGRESS`, `CANCELED`, `COMPLETED`
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