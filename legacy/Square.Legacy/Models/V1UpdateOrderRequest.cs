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
    /// V1UpdateOrderRequest.
    /// </summary>
    public class V1UpdateOrderRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

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
            string canceledNote = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "shipped_tracking_number", false },
                { "completed_note", false },
                { "refunded_note", false },
                { "canceled_note", false },
            };
            this.Action = action;

            if (shippedTrackingNumber != null)
            {
                shouldSerialize["shipped_tracking_number"] = true;
                this.ShippedTrackingNumber = shippedTrackingNumber;
            }

            if (completedNote != null)
            {
                shouldSerialize["completed_note"] = true;
                this.CompletedNote = completedNote;
            }

            if (refundedNote != null)
            {
                shouldSerialize["refunded_note"] = true;
                this.RefundedNote = refundedNote;
            }

            if (canceledNote != null)
            {
                shouldSerialize["canceled_note"] = true;
                this.CanceledNote = canceledNote;
            }
        }

        internal V1UpdateOrderRequest(
            Dictionary<string, bool> shouldSerialize,
            string action,
            string shippedTrackingNumber = null,
            string completedNote = null,
            string refundedNote = null,
            string canceledNote = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Action = action;
            ShippedTrackingNumber = shippedTrackingNumber;
            CompletedNote = completedNote;
            RefundedNote = refundedNote;
            CanceledNote = canceledNote;
        }

        /// <summary>
        /// Gets or sets Action.
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; }

        /// <summary>
        /// The tracking number of the shipment associated with the order. Only valid if action is COMPLETE.
        /// </summary>
        [JsonProperty("shipped_tracking_number")]
        public string ShippedTrackingNumber { get; }

        /// <summary>
        /// A merchant-specified note about the completion of the order. Only valid if action is COMPLETE.
        /// </summary>
        [JsonProperty("completed_note")]
        public string CompletedNote { get; }

        /// <summary>
        /// A merchant-specified note about the refunding of the order. Only valid if action is REFUND.
        /// </summary>
        [JsonProperty("refunded_note")]
        public string RefundedNote { get; }

        /// <summary>
        /// A merchant-specified note about the canceling of the order. Only valid if action is CANCEL.
        /// </summary>
        [JsonProperty("canceled_note")]
        public string CanceledNote { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"V1UpdateOrderRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeShippedTrackingNumber()
        {
            return this.shouldSerialize["shipped_tracking_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCompletedNote()
        {
            return this.shouldSerialize["completed_note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRefundedNote()
        {
            return this.shouldSerialize["refunded_note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCanceledNote()
        {
            return this.shouldSerialize["canceled_note"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is V1UpdateOrderRequest other
                && (
                    this.Action == null && other.Action == null
                    || this.Action?.Equals(other.Action) == true
                )
                && (
                    this.ShippedTrackingNumber == null && other.ShippedTrackingNumber == null
                    || this.ShippedTrackingNumber?.Equals(other.ShippedTrackingNumber) == true
                )
                && (
                    this.CompletedNote == null && other.CompletedNote == null
                    || this.CompletedNote?.Equals(other.CompletedNote) == true
                )
                && (
                    this.RefundedNote == null && other.RefundedNote == null
                    || this.RefundedNote?.Equals(other.RefundedNote) == true
                )
                && (
                    this.CanceledNote == null && other.CanceledNote == null
                    || this.CanceledNote?.Equals(other.CanceledNote) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -553282521;
            hashCode = HashCode.Combine(
                hashCode,
                this.Action,
                this.ShippedTrackingNumber,
                this.CompletedNote,
                this.RefundedNote,
                this.CanceledNote
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Action = {(this.Action == null ? "null" : this.Action.ToString())}"
            );
            toStringOutput.Add(
                $"this.ShippedTrackingNumber = {this.ShippedTrackingNumber ?? "null"}"
            );
            toStringOutput.Add($"this.CompletedNote = {this.CompletedNote ?? "null"}");
            toStringOutput.Add($"this.RefundedNote = {this.RefundedNote ?? "null"}");
            toStringOutput.Add($"this.CanceledNote = {this.CanceledNote ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Action)
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "shipped_tracking_number", false },
                { "completed_note", false },
                { "refunded_note", false },
                { "canceled_note", false },
            };

            private string action;
            private string shippedTrackingNumber;
            private string completedNote;
            private string refundedNote;
            private string canceledNote;

            /// <summary>
            /// Initialize Builder for V1UpdateOrderRequest.
            /// </summary>
            /// <param name="action"> action. </param>
            public Builder(string action)
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
                shouldSerialize["shipped_tracking_number"] = true;
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
                shouldSerialize["completed_note"] = true;
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
                shouldSerialize["refunded_note"] = true;
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
                shouldSerialize["canceled_note"] = true;
                this.canceledNote = canceledNote;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetShippedTrackingNumber()
            {
                this.shouldSerialize["shipped_tracking_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCompletedNote()
            {
                this.shouldSerialize["completed_note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetRefundedNote()
            {
                this.shouldSerialize["refunded_note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCanceledNote()
            {
                this.shouldSerialize["canceled_note"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1UpdateOrderRequest. </returns>
            public V1UpdateOrderRequest Build()
            {
                return new V1UpdateOrderRequest(
                    shouldSerialize,
                    this.action,
                    this.shippedTrackingNumber,
                    this.completedNote,
                    this.refundedNote,
                    this.canceledNote
                );
            }
        }
    }
}
