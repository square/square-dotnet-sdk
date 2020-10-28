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
    public class OrderFulfillmentShipmentDetails 
    {
        public OrderFulfillmentShipmentDetails(Models.OrderFulfillmentRecipient recipient = null,
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
        /// Contains information on the recipient of a fulfillment.
        /// </summary>
        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentRecipient Recipient { get; }

        /// <summary>
        /// The shipping carrier being used to ship this fulfillment
        /// e.g. UPS, FedEx, USPS, etc.
        /// </summary>
        [JsonProperty("carrier", NullValueHandling = NullValueHandling.Ignore)]
        public string Carrier { get; }

        /// <summary>
        /// A note with additional information for the shipping carrier.
        /// </summary>
        [JsonProperty("shipping_note", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippingNote { get; }

        /// <summary>
        /// A description of the type of shipping product purchased from the carrier.
        /// e.g. First Class, Priority, Express
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
        /// The [timestamp](#workingwithdates) indicating when the shipment was
        /// requested. Must be in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("placed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PlacedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when this fulfillment was
        /// moved to the `RESERVED` state. Indicates that preparation of this shipment has begun.
        /// Must be in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("in_progress_at", NullValueHandling = NullValueHandling.Ignore)]
        public string InProgressAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when this fulfillment
        /// was moved to the `PREPARED` state. Indicates that the fulfillment is packaged.
        /// Must be in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("packaged_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PackagedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the shipment is
        /// expected to be delivered to the shipping carrier. Must be in RFC 3339 timestamp
        /// format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("expected_shipped_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpectedShippedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when this fulfillment
        /// was moved to the `COMPLETED`state. Indicates that the fulfillment has been given
        /// to the shipping carrier. Must be in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("shipped_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ShippedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating the shipment was canceled.
        /// Must be in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CanceledAt { get; }

        /// <summary>
        /// A description of why the shipment was canceled.
        /// </summary>
        [JsonProperty("cancel_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelReason { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the shipment
        /// failed to be completed. Must be in RFC 3339 timestamp format, e.g.,
        /// "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("failed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string FailedAt { get; }

        /// <summary>
        /// A description of why the shipment failed to be completed.
        /// </summary>
        [JsonProperty("failure_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string FailureReason { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Recipient(Recipient)
                .Carrier(Carrier)
                .ShippingNote(ShippingNote)
                .ShippingType(ShippingType)
                .TrackingNumber(TrackingNumber)
                .TrackingUrl(TrackingUrl)
                .PlacedAt(PlacedAt)
                .InProgressAt(InProgressAt)
                .PackagedAt(PackagedAt)
                .ExpectedShippedAt(ExpectedShippedAt)
                .ShippedAt(ShippedAt)
                .CanceledAt(CanceledAt)
                .CancelReason(CancelReason)
                .FailedAt(FailedAt)
                .FailureReason(FailureReason);
            return builder;
        }

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



            public Builder Recipient(Models.OrderFulfillmentRecipient recipient)
            {
                this.recipient = recipient;
                return this;
            }

            public Builder Carrier(string carrier)
            {
                this.carrier = carrier;
                return this;
            }

            public Builder ShippingNote(string shippingNote)
            {
                this.shippingNote = shippingNote;
                return this;
            }

            public Builder ShippingType(string shippingType)
            {
                this.shippingType = shippingType;
                return this;
            }

            public Builder TrackingNumber(string trackingNumber)
            {
                this.trackingNumber = trackingNumber;
                return this;
            }

            public Builder TrackingUrl(string trackingUrl)
            {
                this.trackingUrl = trackingUrl;
                return this;
            }

            public Builder PlacedAt(string placedAt)
            {
                this.placedAt = placedAt;
                return this;
            }

            public Builder InProgressAt(string inProgressAt)
            {
                this.inProgressAt = inProgressAt;
                return this;
            }

            public Builder PackagedAt(string packagedAt)
            {
                this.packagedAt = packagedAt;
                return this;
            }

            public Builder ExpectedShippedAt(string expectedShippedAt)
            {
                this.expectedShippedAt = expectedShippedAt;
                return this;
            }

            public Builder ShippedAt(string shippedAt)
            {
                this.shippedAt = shippedAt;
                return this;
            }

            public Builder CanceledAt(string canceledAt)
            {
                this.canceledAt = canceledAt;
                return this;
            }

            public Builder CancelReason(string cancelReason)
            {
                this.cancelReason = cancelReason;
                return this;
            }

            public Builder FailedAt(string failedAt)
            {
                this.failedAt = failedAt;
                return this;
            }

            public Builder FailureReason(string failureReason)
            {
                this.failureReason = failureReason;
                return this;
            }

            public OrderFulfillmentShipmentDetails Build()
            {
                return new OrderFulfillmentShipmentDetails(recipient,
                    carrier,
                    shippingNote,
                    shippingType,
                    trackingNumber,
                    trackingUrl,
                    placedAt,
                    inProgressAt,
                    packagedAt,
                    expectedShippedAt,
                    shippedAt,
                    canceledAt,
                    cancelReason,
                    failedAt,
                    failureReason);
            }
        }
    }
}