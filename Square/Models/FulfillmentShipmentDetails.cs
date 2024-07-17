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
    /// FulfillmentShipmentDetails.
    /// </summary>
    public class FulfillmentShipmentDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="FulfillmentShipmentDetails"/> class.
        /// </summary>
        /// <param name="recipient">recipient.</param>
        /// <param name="carrier">carrier.</param>
        /// <param name="shippingNote">shipping_note.</param>
        /// <param name="shippingType">shipping_type.</param>
        /// <param name="trackingNumber">tracking_number.</param>
        /// <param name="trackingUrl">tracking_url.</param>
        /// <param name="placedAt">placed_at.</param>
        /// <param name="inProgressAt">in_progress_at.</param>
        /// <param name="packagedAt">packaged_at.</param>
        /// <param name="expectedShippedAt">expected_shipped_at.</param>
        /// <param name="shippedAt">shipped_at.</param>
        /// <param name="canceledAt">canceled_at.</param>
        /// <param name="cancelReason">cancel_reason.</param>
        /// <param name="failedAt">failed_at.</param>
        /// <param name="failureReason">failure_reason.</param>
        public FulfillmentShipmentDetails(
            Models.FulfillmentRecipient recipient = null,
            string carrier = null,
            string shippingNote = null,
            string shippingType = null,
            string trackingNumber = null,
            string trackingUrl = null,
            string placedAt = null,
            string inProgressAt = null,
            string packagedAt = null,
            string expectedShippedAt = null,
            string shippedAt = null,
            string canceledAt = null,
            string cancelReason = null,
            string failedAt = null,
            string failureReason = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "carrier", false },
                { "shipping_note", false },
                { "shipping_type", false },
                { "tracking_number", false },
                { "tracking_url", false },
                { "expected_shipped_at", false },
                { "canceled_at", false },
                { "cancel_reason", false },
                { "failure_reason", false }
            };

            this.Recipient = recipient;
            if (carrier != null)
            {
                shouldSerialize["carrier"] = true;
                this.Carrier = carrier;
            }

            if (shippingNote != null)
            {
                shouldSerialize["shipping_note"] = true;
                this.ShippingNote = shippingNote;
            }

            if (shippingType != null)
            {
                shouldSerialize["shipping_type"] = true;
                this.ShippingType = shippingType;
            }

            if (trackingNumber != null)
            {
                shouldSerialize["tracking_number"] = true;
                this.TrackingNumber = trackingNumber;
            }

            if (trackingUrl != null)
            {
                shouldSerialize["tracking_url"] = true;
                this.TrackingUrl = trackingUrl;
            }

            this.PlacedAt = placedAt;
            this.InProgressAt = inProgressAt;
            this.PackagedAt = packagedAt;
            if (expectedShippedAt != null)
            {
                shouldSerialize["expected_shipped_at"] = true;
                this.ExpectedShippedAt = expectedShippedAt;
            }

            this.ShippedAt = shippedAt;
            if (canceledAt != null)
            {
                shouldSerialize["canceled_at"] = true;
                this.CanceledAt = canceledAt;
            }

            if (cancelReason != null)
            {
                shouldSerialize["cancel_reason"] = true;
                this.CancelReason = cancelReason;
            }

            this.FailedAt = failedAt;
            if (failureReason != null)
            {
                shouldSerialize["failure_reason"] = true;
                this.FailureReason = failureReason;
            }

        }
        internal FulfillmentShipmentDetails(Dictionary<string, bool> shouldSerialize,
            Models.FulfillmentRecipient recipient = null,
            string carrier = null,
            string shippingNote = null,
            string shippingType = null,
            string trackingNumber = null,
            string trackingUrl = null,
            string placedAt = null,
            string inProgressAt = null,
            string packagedAt = null,
            string expectedShippedAt = null,
            string shippedAt = null,
            string canceledAt = null,
            string cancelReason = null,
            string failedAt = null,
            string failureReason = null)
        {
            this.shouldSerialize = shouldSerialize;
            Recipient = recipient;
            Carrier = carrier;
            ShippingNote = shippingNote;
            ShippingType = shippingType;
            TrackingNumber = trackingNumber;
            TrackingUrl = trackingUrl;
            PlacedAt = placedAt;
            InProgressAt = inProgressAt;
            PackagedAt = packagedAt;
            ExpectedShippedAt = expectedShippedAt;
            ShippedAt = shippedAt;
            CanceledAt = canceledAt;
            CancelReason = cancelReason;
            FailedAt = failedAt;
            FailureReason = failureReason;
        }

        /// <summary>
        /// Information about the fulfillment recipient.
        /// </summary>
        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FulfillmentRecipient Recipient { get; }

        /// <summary>
        /// The shipping carrier being used to ship this fulfillment (such as UPS, FedEx, or USPS).
        /// </summary>
        [JsonProperty("carrier")]
        public string Carrier { get; }

        /// <summary>
        /// A note with additional information for the shipping carrier.
        /// </summary>
        [JsonProperty("shipping_note")]
        public string ShippingNote { get; }

        /// <summary>
        /// A description of the type of shipping product purchased from the carrier
        /// (such as First Class, Priority, or Express).
        /// </summary>
        [JsonProperty("shipping_type")]
        public string ShippingType { get; }

        /// <summary>
        /// The reference number provided by the carrier to track the shipment's progress.
        /// </summary>
        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; }

        /// <summary>
        /// A link to the tracking webpage on the carrier's website.
        /// </summary>
        [JsonProperty("tracking_url")]
        public string TrackingUrl { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the shipment was requested. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("placed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PlacedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when this fulfillment was moved to the `RESERVED` state, which  indicates that preparation
        /// of this shipment has begun. The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("in_progress_at", NullValueHandling = NullValueHandling.Ignore)]
        public string InProgressAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when this fulfillment was moved to the `PREPARED` state, which indicates that the
        /// fulfillment is packaged. The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("packaged_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PackagedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the shipment is expected to be delivered to the shipping carrier.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("expected_shipped_at")]
        public string ExpectedShippedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when this fulfillment was moved to the `COMPLETED` state, which indicates that
        /// the fulfillment has been given to the shipping carrier. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("shipped_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating the shipment was canceled.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("canceled_at")]
        public string CanceledAt { get; }

        /// <summary>
        /// A description of why the shipment was canceled.
        /// </summary>
        [JsonProperty("cancel_reason")]
        public string CancelReason { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the shipment failed to be completed. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("failed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string FailedAt { get; }

        /// <summary>
        /// A description of why the shipment failed to be completed.
        /// </summary>
        [JsonProperty("failure_reason")]
        public string FailureReason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FulfillmentShipmentDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCarrier()
        {
            return this.shouldSerialize["carrier"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeShippingNote()
        {
            return this.shouldSerialize["shipping_note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeShippingType()
        {
            return this.shouldSerialize["shipping_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrackingNumber()
        {
            return this.shouldSerialize["tracking_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTrackingUrl()
        {
            return this.shouldSerialize["tracking_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpectedShippedAt()
        {
            return this.shouldSerialize["expected_shipped_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCanceledAt()
        {
            return this.shouldSerialize["canceled_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCancelReason()
        {
            return this.shouldSerialize["cancel_reason"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFailureReason()
        {
            return this.shouldSerialize["failure_reason"];
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
            return obj is FulfillmentShipmentDetails other &&                ((this.Recipient == null && other.Recipient == null) || (this.Recipient?.Equals(other.Recipient) == true)) &&
                ((this.Carrier == null && other.Carrier == null) || (this.Carrier?.Equals(other.Carrier) == true)) &&
                ((this.ShippingNote == null && other.ShippingNote == null) || (this.ShippingNote?.Equals(other.ShippingNote) == true)) &&
                ((this.ShippingType == null && other.ShippingType == null) || (this.ShippingType?.Equals(other.ShippingType) == true)) &&
                ((this.TrackingNumber == null && other.TrackingNumber == null) || (this.TrackingNumber?.Equals(other.TrackingNumber) == true)) &&
                ((this.TrackingUrl == null && other.TrackingUrl == null) || (this.TrackingUrl?.Equals(other.TrackingUrl) == true)) &&
                ((this.PlacedAt == null && other.PlacedAt == null) || (this.PlacedAt?.Equals(other.PlacedAt) == true)) &&
                ((this.InProgressAt == null && other.InProgressAt == null) || (this.InProgressAt?.Equals(other.InProgressAt) == true)) &&
                ((this.PackagedAt == null && other.PackagedAt == null) || (this.PackagedAt?.Equals(other.PackagedAt) == true)) &&
                ((this.ExpectedShippedAt == null && other.ExpectedShippedAt == null) || (this.ExpectedShippedAt?.Equals(other.ExpectedShippedAt) == true)) &&
                ((this.ShippedAt == null && other.ShippedAt == null) || (this.ShippedAt?.Equals(other.ShippedAt) == true)) &&
                ((this.CanceledAt == null && other.CanceledAt == null) || (this.CanceledAt?.Equals(other.CanceledAt) == true)) &&
                ((this.CancelReason == null && other.CancelReason == null) || (this.CancelReason?.Equals(other.CancelReason) == true)) &&
                ((this.FailedAt == null && other.FailedAt == null) || (this.FailedAt?.Equals(other.FailedAt) == true)) &&
                ((this.FailureReason == null && other.FailureReason == null) || (this.FailureReason?.Equals(other.FailureReason) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1267453331;
            hashCode = HashCode.Combine(this.Recipient, this.Carrier, this.ShippingNote, this.ShippingType, this.TrackingNumber, this.TrackingUrl, this.PlacedAt);

            hashCode = HashCode.Combine(hashCode, this.InProgressAt, this.PackagedAt, this.ExpectedShippedAt, this.ShippedAt, this.CanceledAt, this.CancelReason, this.FailedAt);

            hashCode = HashCode.Combine(hashCode, this.FailureReason);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Recipient = {(this.Recipient == null ? "null" : this.Recipient.ToString())}");
            toStringOutput.Add($"this.Carrier = {(this.Carrier == null ? "null" : this.Carrier)}");
            toStringOutput.Add($"this.ShippingNote = {(this.ShippingNote == null ? "null" : this.ShippingNote)}");
            toStringOutput.Add($"this.ShippingType = {(this.ShippingType == null ? "null" : this.ShippingType)}");
            toStringOutput.Add($"this.TrackingNumber = {(this.TrackingNumber == null ? "null" : this.TrackingNumber)}");
            toStringOutput.Add($"this.TrackingUrl = {(this.TrackingUrl == null ? "null" : this.TrackingUrl)}");
            toStringOutput.Add($"this.PlacedAt = {(this.PlacedAt == null ? "null" : this.PlacedAt)}");
            toStringOutput.Add($"this.InProgressAt = {(this.InProgressAt == null ? "null" : this.InProgressAt)}");
            toStringOutput.Add($"this.PackagedAt = {(this.PackagedAt == null ? "null" : this.PackagedAt)}");
            toStringOutput.Add($"this.ExpectedShippedAt = {(this.ExpectedShippedAt == null ? "null" : this.ExpectedShippedAt)}");
            toStringOutput.Add($"this.ShippedAt = {(this.ShippedAt == null ? "null" : this.ShippedAt)}");
            toStringOutput.Add($"this.CanceledAt = {(this.CanceledAt == null ? "null" : this.CanceledAt)}");
            toStringOutput.Add($"this.CancelReason = {(this.CancelReason == null ? "null" : this.CancelReason)}");
            toStringOutput.Add($"this.FailedAt = {(this.FailedAt == null ? "null" : this.FailedAt)}");
            toStringOutput.Add($"this.FailureReason = {(this.FailureReason == null ? "null" : this.FailureReason)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Recipient(this.Recipient)
                .Carrier(this.Carrier)
                .ShippingNote(this.ShippingNote)
                .ShippingType(this.ShippingType)
                .TrackingNumber(this.TrackingNumber)
                .TrackingUrl(this.TrackingUrl)
                .PlacedAt(this.PlacedAt)
                .InProgressAt(this.InProgressAt)
                .PackagedAt(this.PackagedAt)
                .ExpectedShippedAt(this.ExpectedShippedAt)
                .ShippedAt(this.ShippedAt)
                .CanceledAt(this.CanceledAt)
                .CancelReason(this.CancelReason)
                .FailedAt(this.FailedAt)
                .FailureReason(this.FailureReason);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "carrier", false },
                { "shipping_note", false },
                { "shipping_type", false },
                { "tracking_number", false },
                { "tracking_url", false },
                { "expected_shipped_at", false },
                { "canceled_at", false },
                { "cancel_reason", false },
                { "failure_reason", false },
            };

            private Models.FulfillmentRecipient recipient;
            private string carrier;
            private string shippingNote;
            private string shippingType;
            private string trackingNumber;
            private string trackingUrl;
            private string placedAt;
            private string inProgressAt;
            private string packagedAt;
            private string expectedShippedAt;
            private string shippedAt;
            private string canceledAt;
            private string cancelReason;
            private string failedAt;
            private string failureReason;

             /// <summary>
             /// Recipient.
             /// </summary>
             /// <param name="recipient"> recipient. </param>
             /// <returns> Builder. </returns>
            public Builder Recipient(Models.FulfillmentRecipient recipient)
            {
                this.recipient = recipient;
                return this;
            }

             /// <summary>
             /// Carrier.
             /// </summary>
             /// <param name="carrier"> carrier. </param>
             /// <returns> Builder. </returns>
            public Builder Carrier(string carrier)
            {
                shouldSerialize["carrier"] = true;
                this.carrier = carrier;
                return this;
            }

             /// <summary>
             /// ShippingNote.
             /// </summary>
             /// <param name="shippingNote"> shippingNote. </param>
             /// <returns> Builder. </returns>
            public Builder ShippingNote(string shippingNote)
            {
                shouldSerialize["shipping_note"] = true;
                this.shippingNote = shippingNote;
                return this;
            }

             /// <summary>
             /// ShippingType.
             /// </summary>
             /// <param name="shippingType"> shippingType. </param>
             /// <returns> Builder. </returns>
            public Builder ShippingType(string shippingType)
            {
                shouldSerialize["shipping_type"] = true;
                this.shippingType = shippingType;
                return this;
            }

             /// <summary>
             /// TrackingNumber.
             /// </summary>
             /// <param name="trackingNumber"> trackingNumber. </param>
             /// <returns> Builder. </returns>
            public Builder TrackingNumber(string trackingNumber)
            {
                shouldSerialize["tracking_number"] = true;
                this.trackingNumber = trackingNumber;
                return this;
            }

             /// <summary>
             /// TrackingUrl.
             /// </summary>
             /// <param name="trackingUrl"> trackingUrl. </param>
             /// <returns> Builder. </returns>
            public Builder TrackingUrl(string trackingUrl)
            {
                shouldSerialize["tracking_url"] = true;
                this.trackingUrl = trackingUrl;
                return this;
            }

             /// <summary>
             /// PlacedAt.
             /// </summary>
             /// <param name="placedAt"> placedAt. </param>
             /// <returns> Builder. </returns>
            public Builder PlacedAt(string placedAt)
            {
                this.placedAt = placedAt;
                return this;
            }

             /// <summary>
             /// InProgressAt.
             /// </summary>
             /// <param name="inProgressAt"> inProgressAt. </param>
             /// <returns> Builder. </returns>
            public Builder InProgressAt(string inProgressAt)
            {
                this.inProgressAt = inProgressAt;
                return this;
            }

             /// <summary>
             /// PackagedAt.
             /// </summary>
             /// <param name="packagedAt"> packagedAt. </param>
             /// <returns> Builder. </returns>
            public Builder PackagedAt(string packagedAt)
            {
                this.packagedAt = packagedAt;
                return this;
            }

             /// <summary>
             /// ExpectedShippedAt.
             /// </summary>
             /// <param name="expectedShippedAt"> expectedShippedAt. </param>
             /// <returns> Builder. </returns>
            public Builder ExpectedShippedAt(string expectedShippedAt)
            {
                shouldSerialize["expected_shipped_at"] = true;
                this.expectedShippedAt = expectedShippedAt;
                return this;
            }

             /// <summary>
             /// ShippedAt.
             /// </summary>
             /// <param name="shippedAt"> shippedAt. </param>
             /// <returns> Builder. </returns>
            public Builder ShippedAt(string shippedAt)
            {
                this.shippedAt = shippedAt;
                return this;
            }

             /// <summary>
             /// CanceledAt.
             /// </summary>
             /// <param name="canceledAt"> canceledAt. </param>
             /// <returns> Builder. </returns>
            public Builder CanceledAt(string canceledAt)
            {
                shouldSerialize["canceled_at"] = true;
                this.canceledAt = canceledAt;
                return this;
            }

             /// <summary>
             /// CancelReason.
             /// </summary>
             /// <param name="cancelReason"> cancelReason. </param>
             /// <returns> Builder. </returns>
            public Builder CancelReason(string cancelReason)
            {
                shouldSerialize["cancel_reason"] = true;
                this.cancelReason = cancelReason;
                return this;
            }

             /// <summary>
             /// FailedAt.
             /// </summary>
             /// <param name="failedAt"> failedAt. </param>
             /// <returns> Builder. </returns>
            public Builder FailedAt(string failedAt)
            {
                this.failedAt = failedAt;
                return this;
            }

             /// <summary>
             /// FailureReason.
             /// </summary>
             /// <param name="failureReason"> failureReason. </param>
             /// <returns> Builder. </returns>
            public Builder FailureReason(string failureReason)
            {
                shouldSerialize["failure_reason"] = true;
                this.failureReason = failureReason;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCarrier()
            {
                this.shouldSerialize["carrier"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetShippingNote()
            {
                this.shouldSerialize["shipping_note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetShippingType()
            {
                this.shouldSerialize["shipping_type"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTrackingNumber()
            {
                this.shouldSerialize["tracking_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTrackingUrl()
            {
                this.shouldSerialize["tracking_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetExpectedShippedAt()
            {
                this.shouldSerialize["expected_shipped_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCanceledAt()
            {
                this.shouldSerialize["canceled_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCancelReason()
            {
                this.shouldSerialize["cancel_reason"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFailureReason()
            {
                this.shouldSerialize["failure_reason"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> FulfillmentShipmentDetails. </returns>
            public FulfillmentShipmentDetails Build()
            {
                return new FulfillmentShipmentDetails(shouldSerialize,
                    this.recipient,
                    this.carrier,
                    this.shippingNote,
                    this.shippingType,
                    this.trackingNumber,
                    this.trackingUrl,
                    this.placedAt,
                    this.inProgressAt,
                    this.packagedAt,
                    this.expectedShippedAt,
                    this.shippedAt,
                    this.canceledAt,
                    this.cancelReason,
                    this.failedAt,
                    this.failureReason);
            }
        }
    }
}