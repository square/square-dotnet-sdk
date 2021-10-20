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
    /// V1UpdateOrderRequest.
    /// </summary>
    public class V1UpdateOrderRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1UpdateOrderRequest"/> class.
        /// </summary>
        /// <param name="action">action.</param>
        /// <param name="shippedTrackingNumber">shipped_tracking_number.</param>
        /// <param name="completedNote">completed_note.</param>
        /// <param name="refundedNote">refunded_note.</param>
        /// <param name="canceledNote">canceled_note.</param>
        public V1UpdateOrderRequest(
            string action,
            string shippedTrackingNumber = null,
            string completedNote = null,
            string refundedNote = null,
            string canceledNote = null)
        {
            this.Action = action;
            this.ShippedTrackingNumber = shippedTrackingNumber;
            this.CompletedNote = completedNote;
            this.RefundedNote = refundedNote;
            this.CanceledNote = canceledNote;
        }

        /// <summary>
        /// Gets or sets Action.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1UpdateOrderRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1UpdateOrderRequest other &&
                ((this.Action == null && other.Action == null) || (this.Action?.Equals(other.Action) == true)) &&
                ((this.ShippedTrackingNumber == null && other.ShippedTrackingNumber == null) || (this.ShippedTrackingNumber?.Equals(other.ShippedTrackingNumber) == true)) &&
                ((this.CompletedNote == null && other.CompletedNote == null) || (this.CompletedNote?.Equals(other.CompletedNote) == true)) &&
                ((this.RefundedNote == null && other.RefundedNote == null) || (this.RefundedNote?.Equals(other.RefundedNote) == true)) &&
                ((this.CanceledNote == null && other.CanceledNote == null) || (this.CanceledNote?.Equals(other.CanceledNote) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -553282521;
            hashCode = HashCode.Combine(this.Action, this.ShippedTrackingNumber, this.CompletedNote, this.RefundedNote, this.CanceledNote);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Action = {(this.Action == null ? "null" : this.Action.ToString())}");
            toStringOutput.Add($"this.ShippedTrackingNumber = {(this.ShippedTrackingNumber == null ? "null" : this.ShippedTrackingNumber == string.Empty ? "" : this.ShippedTrackingNumber)}");
            toStringOutput.Add($"this.CompletedNote = {(this.CompletedNote == null ? "null" : this.CompletedNote == string.Empty ? "" : this.CompletedNote)}");
            toStringOutput.Add($"this.RefundedNote = {(this.RefundedNote == null ? "null" : this.RefundedNote == string.Empty ? "" : this.RefundedNote)}");
            toStringOutput.Add($"this.CanceledNote = {(this.CanceledNote == null ? "null" : this.CanceledNote == string.Empty ? "" : this.CanceledNote)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Action)
                .ShippedTrackingNumber(this.ShippedTrackingNumber)
                .CompletedNote(this.CompletedNote)
                .RefundedNote(this.RefundedNote)
                .CanceledNote(this.CanceledNote);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string action;
            private string shippedTrackingNumber;
            private string completedNote;
            private string refundedNote;
            private string canceledNote;

            public Builder(
                string action)
            {
                this.action = action;
            }

             /// <summary>
             /// Action.
             /// </summary>
             /// <param name="action"> action. </param>
             /// <returns> Builder. </returns>
            public Builder Action(string action)
            {
                this.action = action;
                return this;
            }

             /// <summary>
             /// ShippedTrackingNumber.
             /// </summary>
             /// <param name="shippedTrackingNumber"> shippedTrackingNumber. </param>
             /// <returns> Builder. </returns>
            public Builder ShippedTrackingNumber(string shippedTrackingNumber)
            {
                this.shippedTrackingNumber = shippedTrackingNumber;
                return this;
            }

             /// <summary>
             /// CompletedNote.
             /// </summary>
             /// <param name="completedNote"> completedNote. </param>
             /// <returns> Builder. </returns>
            public Builder CompletedNote(string completedNote)
            {
                this.completedNote = completedNote;
                return this;
            }

             /// <summary>
             /// RefundedNote.
             /// </summary>
             /// <param name="refundedNote"> refundedNote. </param>
             /// <returns> Builder. </returns>
            public Builder RefundedNote(string refundedNote)
            {
                this.refundedNote = refundedNote;
                return this;
            }

             /// <summary>
             /// CanceledNote.
             /// </summary>
             /// <param name="canceledNote"> canceledNote. </param>
             /// <returns> Builder. </returns>
            public Builder CanceledNote(string canceledNote)
            {
                this.canceledNote = canceledNote;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1UpdateOrderRequest. </returns>
            public V1UpdateOrderRequest Build()
            {
                return new V1UpdateOrderRequest(
                    this.action,
                    this.shippedTrackingNumber,
                    this.completedNote,
                    this.refundedNote,
                    this.canceledNote);
            }
        }
    }
}