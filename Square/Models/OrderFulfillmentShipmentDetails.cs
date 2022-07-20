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
    /// OrderFulfillmentShipmentDetails.
    /// </summary>
    public class OrderFulfillmentShipmentDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderFulfillmentShipmentDetails"/> class.
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
        public OrderFulfillmentShipmentDetails(
            Models.OrderFulfillmentRecipient recipient = null,
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
            this.Recipient = recipient;
            this.Carrier = carrier;
            this.ShippingNote = shippingNote;
            this.ShippingType = shippingType;
            this.TrackingNumber = trackingNumber;
            this.TrackingUrl = trackingUrl;
            this.PlacedAt = placedAt;
            this.InProgressAt = inProgressAt;
            this.PackagedAt = packagedAt;
            this.ExpectedShippedAt = expectedShippedAt;
            this.ShippedAt = shippedAt;
            this.CanceledAt = canceledAt;
            this.CancelReason = cancelReason;
            this.FailedAt = failedAt;
            this.FailureReason = failureReason;
        }

        /// <summary>
        /// Information about the fulfillment recipient.
        /// </summary>
        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentRecipient Recipient { get; }

        /// <summary>
        /// The shipping carrier being used to ship this fulfillment (such as UPS, FedEx, or USPS).
        /// </summary>
        [JsonProperty("carrier", NullValueHandling = NullValueHandling.Ignore)]
        public string Carrier { get; }

        /// <summary>
        /// A note with additional information for the shipping carrier.
        /// </summary>
        [JsonProperty("shipping_note", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingNote { get; }

        /// <summary>
        /// A description of the type of shipping product purchased from the carrier
        /// (such as First Class, Priority, or Express).
        /// </summary>
        [JsonProperty("shipping_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingType { get; }

        /// <summary>
        /// The reference number provided by the carrier to track the shipment's progress.
        /// </summary>
        [JsonProperty("tracking_number", NullValueHandling = NullValueHandling.Ignore)]
        public string TrackingNumber { get; }

        /// <summary>
        /// A link to the tracking webpage on the carrier's website.
        /// </summary>
        [JsonProperty("tracking_url", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("expected_shipped_at", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CanceledAt { get; }

        /// <summary>
        /// A description of why the shipment was canceled.
        /// </summary>
        [JsonProperty("cancel_reason", NullValueHandling = NullValueHandling.Ignore)]
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
        [JsonProperty("failure_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string FailureReason { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentShipmentDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderFulfillmentShipmentDetails other &&
                ((this.Recipient == null && other.Recipient == null) || (this.Recipient?.Equals(other.Recipient) == true)) &&
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
            int hashCode = 1108362053;
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
            toStringOutput.Add($"this.Carrier = {(this.Carrier == null ? "null" : this.Carrier == string.Empty ? "" : this.Carrier)}");
            toStringOutput.Add($"this.ShippingNote = {(this.ShippingNote == null ? "null" : this.ShippingNote == string.Empty ? "" : this.ShippingNote)}");
            toStringOutput.Add($"this.ShippingType = {(this.ShippingType == null ? "null" : this.ShippingType == string.Empty ? "" : this.ShippingType)}");
            toStringOutput.Add($"this.TrackingNumber = {(this.TrackingNumber == null ? "null" : this.TrackingNumber == string.Empty ? "" : this.TrackingNumber)}");
            toStringOutput.Add($"this.TrackingUrl = {(this.TrackingUrl == null ? "null" : this.TrackingUrl == string.Empty ? "" : this.TrackingUrl)}");
            toStringOutput.Add($"this.PlacedAt = {(this.PlacedAt == null ? "null" : this.PlacedAt == string.Empty ? "" : this.PlacedAt)}");
            toStringOutput.Add($"this.InProgressAt = {(this.InProgressAt == null ? "null" : this.InProgressAt == string.Empty ? "" : this.InProgressAt)}");
            toStringOutput.Add($"this.PackagedAt = {(this.PackagedAt == null ? "null" : this.PackagedAt == string.Empty ? "" : this.PackagedAt)}");
            toStringOutput.Add($"this.ExpectedShippedAt = {(this.ExpectedShippedAt == null ? "null" : this.ExpectedShippedAt == string.Empty ? "" : this.ExpectedShippedAt)}");
            toStringOutput.Add($"this.ShippedAt = {(this.ShippedAt == null ? "null" : this.ShippedAt == string.Empty ? "" : this.ShippedAt)}");
            toStringOutput.Add($"this.CanceledAt = {(this.CanceledAt == null ? "null" : this.CanceledAt == string.Empty ? "" : this.CanceledAt)}");
            toStringOutput.Add($"this.CancelReason = {(this.CancelReason == null ? "null" : this.CancelReason == string.Empty ? "" : this.CancelReason)}");
            toStringOutput.Add($"this.FailedAt = {(this.FailedAt == null ? "null" : this.FailedAt == string.Empty ? "" : this.FailedAt)}");
            toStringOutput.Add($"this.FailureReason = {(this.FailureReason == null ? "null" : this.FailureReason == string.Empty ? "" : this.FailureReason)}");
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
            private Models.OrderFulfillmentRecipient recipient;
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
            public Builder Recipient(Models.OrderFulfillmentRecipient recipient)
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
                this.failureReason = failureReason;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderFulfillmentShipmentDetails. </returns>
            public OrderFulfillmentShipmentDetails Build()
            {
                return new OrderFulfillmentShipmentDetails(
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