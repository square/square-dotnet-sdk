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
    public class V1UpdateOrderRequest 
    {
        public V1UpdateOrderRequest(string action,
            string shippedTrackingNumber = null,
            string completedNote = null,
            string refundedNote = null,
            string canceledNote = null)
        {
            Action = action;
            ShippedTrackingNumber = shippedTrackingNumber;
            CompletedNote = completedNote;
            RefundedNote = refundedNote;
            CanceledNote = canceledNote;
        }

        /// <summary>
        /// Getter for action
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; }

        /// <summary>
        /// The tracking number of the shipment associated with the order. Only valid if action is COMPLETE.
        /// </summary>
        [JsonProperty("shipped_tracking_number", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippedTrackingNumber { get; }

        /// <summary>
        /// A merchant-specified note about the completion of the order. Only valid if action is COMPLETE.
        /// </summary>
        [JsonProperty("completed_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CompletedNote { get; }

        /// <summary>
        /// A merchant-specified note about the refunding of the order. Only valid if action is REFUND.
        /// </summary>
        [JsonProperty("refunded_note", NullValueHandling = NullValueHandling.Ignore)]
        public string RefundedNote { get; }

        /// <summary>
        /// A merchant-specified note about the canceling of the order. Only valid if action is CANCEL.
        /// </summary>
        [JsonProperty("canceled_note", NullValueHandling = NullValueHandling.Ignore)]
        public string CanceledNote { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Action)
                .ShippedTrackingNumber(ShippedTrackingNumber)
                .CompletedNote(CompletedNote)
                .RefundedNote(RefundedNote)
                .CanceledNote(CanceledNote);
            return builder;
        }

        public class Builder
        {
            private string action;
            private string shippedTrackingNumber;
            private string completedNote;
            private string refundedNote;
            private string canceledNote;

            public Builder(string action)
            {
                this.action = action;
            }

            public Builder Action(string action)
            {
                this.action = action;
                return this;
            }

            public Builder ShippedTrackingNumber(string shippedTrackingNumber)
            {
                this.shippedTrackingNumber = shippedTrackingNumber;
                return this;
            }

            public Builder CompletedNote(string completedNote)
            {
                this.completedNote = completedNote;
                return this;
            }

            public Builder RefundedNote(string refundedNote)
            {
                this.refundedNote = refundedNote;
                return this;
            }

            public Builder CanceledNote(string canceledNote)
            {
                this.canceledNote = canceledNote;
                return this;
            }

            public V1UpdateOrderRequest Build()
            {
                return new V1UpdateOrderRequest(action,
                    shippedTrackingNumber,
                    completedNote,
                    refundedNote,
                    canceledNote);
            }
        }
    }
}