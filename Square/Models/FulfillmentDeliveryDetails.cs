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
    /// FulfillmentDeliveryDetails.
    /// </summary>
    public class FulfillmentDeliveryDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="FulfillmentDeliveryDetails"/> class.
        /// </summary>
        /// <param name="recipient">recipient.</param>
        /// <param name="scheduleType">schedule_type.</param>
        /// <param name="placedAt">placed_at.</param>
        /// <param name="deliverAt">deliver_at.</param>
        /// <param name="prepTimeDuration">prep_time_duration.</param>
        /// <param name="deliveryWindowDuration">delivery_window_duration.</param>
        /// <param name="note">note.</param>
        /// <param name="completedAt">completed_at.</param>
        /// <param name="inProgressAt">in_progress_at.</param>
        /// <param name="rejectedAt">rejected_at.</param>
        /// <param name="readyAt">ready_at.</param>
        /// <param name="deliveredAt">delivered_at.</param>
        /// <param name="canceledAt">canceled_at.</param>
        /// <param name="cancelReason">cancel_reason.</param>
        /// <param name="courierPickupAt">courier_pickup_at.</param>
        /// <param name="courierPickupWindowDuration">courier_pickup_window_duration.</param>
        /// <param name="isNoContactDelivery">is_no_contact_delivery.</param>
        /// <param name="dropoffNotes">dropoff_notes.</param>
        /// <param name="courierProviderName">courier_provider_name.</param>
        /// <param name="courierSupportPhoneNumber">courier_support_phone_number.</param>
        /// <param name="squareDeliveryId">square_delivery_id.</param>
        /// <param name="externalDeliveryId">external_delivery_id.</param>
        /// <param name="managedDelivery">managed_delivery.</param>
        public FulfillmentDeliveryDetails(
            Models.FulfillmentRecipient recipient = null,
            string scheduleType = null,
            string placedAt = null,
            string deliverAt = null,
            string prepTimeDuration = null,
            string deliveryWindowDuration = null,
            string note = null,
            string completedAt = null,
            string inProgressAt = null,
            string rejectedAt = null,
            string readyAt = null,
            string deliveredAt = null,
            string canceledAt = null,
            string cancelReason = null,
            string courierPickupAt = null,
            string courierPickupWindowDuration = null,
            bool? isNoContactDelivery = null,
            string dropoffNotes = null,
            string courierProviderName = null,
            string courierSupportPhoneNumber = null,
            string squareDeliveryId = null,
            string externalDeliveryId = null,
            bool? managedDelivery = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "deliver_at", false },
                { "prep_time_duration", false },
                { "delivery_window_duration", false },
                { "note", false },
                { "completed_at", false },
                { "cancel_reason", false },
                { "courier_pickup_at", false },
                { "courier_pickup_window_duration", false },
                { "is_no_contact_delivery", false },
                { "dropoff_notes", false },
                { "courier_provider_name", false },
                { "courier_support_phone_number", false },
                { "square_delivery_id", false },
                { "external_delivery_id", false },
                { "managed_delivery", false }
            };

            this.Recipient = recipient;
            this.ScheduleType = scheduleType;
            this.PlacedAt = placedAt;
            if (deliverAt != null)
            {
                shouldSerialize["deliver_at"] = true;
                this.DeliverAt = deliverAt;
            }

            if (prepTimeDuration != null)
            {
                shouldSerialize["prep_time_duration"] = true;
                this.PrepTimeDuration = prepTimeDuration;
            }

            if (deliveryWindowDuration != null)
            {
                shouldSerialize["delivery_window_duration"] = true;
                this.DeliveryWindowDuration = deliveryWindowDuration;
            }

            if (note != null)
            {
                shouldSerialize["note"] = true;
                this.Note = note;
            }

            if (completedAt != null)
            {
                shouldSerialize["completed_at"] = true;
                this.CompletedAt = completedAt;
            }

            this.InProgressAt = inProgressAt;
            this.RejectedAt = rejectedAt;
            this.ReadyAt = readyAt;
            this.DeliveredAt = deliveredAt;
            this.CanceledAt = canceledAt;
            if (cancelReason != null)
            {
                shouldSerialize["cancel_reason"] = true;
                this.CancelReason = cancelReason;
            }

            if (courierPickupAt != null)
            {
                shouldSerialize["courier_pickup_at"] = true;
                this.CourierPickupAt = courierPickupAt;
            }

            if (courierPickupWindowDuration != null)
            {
                shouldSerialize["courier_pickup_window_duration"] = true;
                this.CourierPickupWindowDuration = courierPickupWindowDuration;
            }

            if (isNoContactDelivery != null)
            {
                shouldSerialize["is_no_contact_delivery"] = true;
                this.IsNoContactDelivery = isNoContactDelivery;
            }

            if (dropoffNotes != null)
            {
                shouldSerialize["dropoff_notes"] = true;
                this.DropoffNotes = dropoffNotes;
            }

            if (courierProviderName != null)
            {
                shouldSerialize["courier_provider_name"] = true;
                this.CourierProviderName = courierProviderName;
            }

            if (courierSupportPhoneNumber != null)
            {
                shouldSerialize["courier_support_phone_number"] = true;
                this.CourierSupportPhoneNumber = courierSupportPhoneNumber;
            }

            if (squareDeliveryId != null)
            {
                shouldSerialize["square_delivery_id"] = true;
                this.SquareDeliveryId = squareDeliveryId;
            }

            if (externalDeliveryId != null)
            {
                shouldSerialize["external_delivery_id"] = true;
                this.ExternalDeliveryId = externalDeliveryId;
            }

            if (managedDelivery != null)
            {
                shouldSerialize["managed_delivery"] = true;
                this.ManagedDelivery = managedDelivery;
            }

        }
        internal FulfillmentDeliveryDetails(Dictionary<string, bool> shouldSerialize,
            Models.FulfillmentRecipient recipient = null,
            string scheduleType = null,
            string placedAt = null,
            string deliverAt = null,
            string prepTimeDuration = null,
            string deliveryWindowDuration = null,
            string note = null,
            string completedAt = null,
            string inProgressAt = null,
            string rejectedAt = null,
            string readyAt = null,
            string deliveredAt = null,
            string canceledAt = null,
            string cancelReason = null,
            string courierPickupAt = null,
            string courierPickupWindowDuration = null,
            bool? isNoContactDelivery = null,
            string dropoffNotes = null,
            string courierProviderName = null,
            string courierSupportPhoneNumber = null,
            string squareDeliveryId = null,
            string externalDeliveryId = null,
            bool? managedDelivery = null)
        {
            this.shouldSerialize = shouldSerialize;
            Recipient = recipient;
            ScheduleType = scheduleType;
            PlacedAt = placedAt;
            DeliverAt = deliverAt;
            PrepTimeDuration = prepTimeDuration;
            DeliveryWindowDuration = deliveryWindowDuration;
            Note = note;
            CompletedAt = completedAt;
            InProgressAt = inProgressAt;
            RejectedAt = rejectedAt;
            ReadyAt = readyAt;
            DeliveredAt = deliveredAt;
            CanceledAt = canceledAt;
            CancelReason = cancelReason;
            CourierPickupAt = courierPickupAt;
            CourierPickupWindowDuration = courierPickupWindowDuration;
            IsNoContactDelivery = isNoContactDelivery;
            DropoffNotes = dropoffNotes;
            CourierProviderName = courierProviderName;
            CourierSupportPhoneNumber = courierSupportPhoneNumber;
            SquareDeliveryId = squareDeliveryId;
            ExternalDeliveryId = externalDeliveryId;
            ManagedDelivery = managedDelivery;
        }

        /// <summary>
        /// Information about the fulfillment recipient.
        /// </summary>
        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FulfillmentRecipient Recipient { get; }

        /// <summary>
        /// The schedule type of the delivery fulfillment.
        /// </summary>
        [JsonProperty("schedule_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ScheduleType { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was placed.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// Must be in RFC 3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("placed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PlacedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// that represents the start of the delivery period.
        /// When the fulfillment `schedule_type` is `ASAP`, the field is automatically
        /// set to the current time plus the `prep_time_duration`.
        /// Otherwise, the application can set this field while the fulfillment `state` is
        /// `PROPOSED`, `RESERVED`, or `PREPARED` (any time before the
        /// terminal state such as `COMPLETED`, `CANCELED`, and `FAILED`).
        /// The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("deliver_at")]
        public string DeliverAt { get; }

        /// <summary>
        /// The duration of time it takes to prepare and deliver this fulfillment.
        /// The duration must be in RFC 3339 format (for example, "P1W3D").
        /// </summary>
        [JsonProperty("prep_time_duration")]
        public string PrepTimeDuration { get; }

        /// <summary>
        /// The time period after `deliver_at` in which to deliver the order.
        /// Applications can set this field when the fulfillment `state` is
        /// `PROPOSED`, `RESERVED`, or `PREPARED` (any time before the terminal state
        /// such as `COMPLETED`, `CANCELED`, and `FAILED`).
        /// The duration must be in RFC 3339 format (for example, "P1W3D").
        /// </summary>
        [JsonProperty("delivery_window_duration")]
        public string DeliveryWindowDuration { get; }

        /// <summary>
        /// Provides additional instructions about the delivery fulfillment.
        /// It is displayed in the Square Point of Sale application and set by the API.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicates when the seller completed the fulfillment.
        /// This field is automatically set when  fulfillment `state` changes to `COMPLETED`.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("completed_at")]
        public string CompletedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicates when the seller started processing the fulfillment.
        /// This field is automatically set when the fulfillment `state` changes to `RESERVED`.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("in_progress_at", NullValueHandling = NullValueHandling.Ignore)]
        public string InProgressAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was rejected. This field is
        /// automatically set when the fulfillment `state` changes to `FAILED`.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("rejected_at", NullValueHandling = NullValueHandling.Ignore)]
        public string RejectedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the seller marked the fulfillment as ready for
        /// courier pickup. This field is automatically set when the fulfillment `state` changes
        /// to PREPARED.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("ready_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ReadyAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was delivered to the recipient.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("delivered_at", NullValueHandling = NullValueHandling.Ignore)]
        public string DeliveredAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was canceled. This field is automatically
        /// set when the fulfillment `state` changes to `CANCELED`.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CanceledAt { get; }

        /// <summary>
        /// The delivery cancellation reason. Max length: 100 characters.
        /// </summary>
        [JsonProperty("cancel_reason")]
        public string CancelReason { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when an order can be picked up by the courier for delivery.
        /// The timestamp must be in RFC 3339 format (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("courier_pickup_at")]
        public string CourierPickupAt { get; }

        /// <summary>
        /// The time period after `courier_pickup_at` in which the courier should pick up the order.
        /// The duration must be in RFC 3339 format (for example, "P1W3D").
        /// </summary>
        [JsonProperty("courier_pickup_window_duration")]
        public string CourierPickupWindowDuration { get; }

        /// <summary>
        /// Whether the delivery is preferred to be no contact.
        /// </summary>
        [JsonProperty("is_no_contact_delivery")]
        public bool? IsNoContactDelivery { get; }

        /// <summary>
        /// A note to provide additional instructions about how to deliver the order.
        /// </summary>
        [JsonProperty("dropoff_notes")]
        public string DropoffNotes { get; }

        /// <summary>
        /// The name of the courier provider.
        /// </summary>
        [JsonProperty("courier_provider_name")]
        public string CourierProviderName { get; }

        /// <summary>
        /// The support phone number of the courier.
        /// </summary>
        [JsonProperty("courier_support_phone_number")]
        public string CourierSupportPhoneNumber { get; }

        /// <summary>
        /// The identifier for the delivery created by Square.
        /// </summary>
        [JsonProperty("square_delivery_id")]
        public string SquareDeliveryId { get; }

        /// <summary>
        /// The identifier for the delivery created by the third-party courier service.
        /// </summary>
        [JsonProperty("external_delivery_id")]
        public string ExternalDeliveryId { get; }

        /// <summary>
        /// The flag to indicate the delivery is managed by a third party (ie DoorDash), which means
        /// we may not receive all recipient information for PII purposes.
        /// </summary>
        [JsonProperty("managed_delivery")]
        public bool? ManagedDelivery { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FulfillmentDeliveryDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeliverAt()
        {
            return this.shouldSerialize["deliver_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePrepTimeDuration()
        {
            return this.shouldSerialize["prep_time_duration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDeliveryWindowDuration()
        {
            return this.shouldSerialize["delivery_window_duration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNote()
        {
            return this.shouldSerialize["note"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCompletedAt()
        {
            return this.shouldSerialize["completed_at"];
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
        public bool ShouldSerializeCourierPickupAt()
        {
            return this.shouldSerialize["courier_pickup_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCourierPickupWindowDuration()
        {
            return this.shouldSerialize["courier_pickup_window_duration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsNoContactDelivery()
        {
            return this.shouldSerialize["is_no_contact_delivery"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDropoffNotes()
        {
            return this.shouldSerialize["dropoff_notes"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCourierProviderName()
        {
            return this.shouldSerialize["courier_provider_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCourierSupportPhoneNumber()
        {
            return this.shouldSerialize["courier_support_phone_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSquareDeliveryId()
        {
            return this.shouldSerialize["square_delivery_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExternalDeliveryId()
        {
            return this.shouldSerialize["external_delivery_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeManagedDelivery()
        {
            return this.shouldSerialize["managed_delivery"];
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
            return obj is FulfillmentDeliveryDetails other &&                ((this.Recipient == null && other.Recipient == null) || (this.Recipient?.Equals(other.Recipient) == true)) &&
                ((this.ScheduleType == null && other.ScheduleType == null) || (this.ScheduleType?.Equals(other.ScheduleType) == true)) &&
                ((this.PlacedAt == null && other.PlacedAt == null) || (this.PlacedAt?.Equals(other.PlacedAt) == true)) &&
                ((this.DeliverAt == null && other.DeliverAt == null) || (this.DeliverAt?.Equals(other.DeliverAt) == true)) &&
                ((this.PrepTimeDuration == null && other.PrepTimeDuration == null) || (this.PrepTimeDuration?.Equals(other.PrepTimeDuration) == true)) &&
                ((this.DeliveryWindowDuration == null && other.DeliveryWindowDuration == null) || (this.DeliveryWindowDuration?.Equals(other.DeliveryWindowDuration) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.CompletedAt == null && other.CompletedAt == null) || (this.CompletedAt?.Equals(other.CompletedAt) == true)) &&
                ((this.InProgressAt == null && other.InProgressAt == null) || (this.InProgressAt?.Equals(other.InProgressAt) == true)) &&
                ((this.RejectedAt == null && other.RejectedAt == null) || (this.RejectedAt?.Equals(other.RejectedAt) == true)) &&
                ((this.ReadyAt == null && other.ReadyAt == null) || (this.ReadyAt?.Equals(other.ReadyAt) == true)) &&
                ((this.DeliveredAt == null && other.DeliveredAt == null) || (this.DeliveredAt?.Equals(other.DeliveredAt) == true)) &&
                ((this.CanceledAt == null && other.CanceledAt == null) || (this.CanceledAt?.Equals(other.CanceledAt) == true)) &&
                ((this.CancelReason == null && other.CancelReason == null) || (this.CancelReason?.Equals(other.CancelReason) == true)) &&
                ((this.CourierPickupAt == null && other.CourierPickupAt == null) || (this.CourierPickupAt?.Equals(other.CourierPickupAt) == true)) &&
                ((this.CourierPickupWindowDuration == null && other.CourierPickupWindowDuration == null) || (this.CourierPickupWindowDuration?.Equals(other.CourierPickupWindowDuration) == true)) &&
                ((this.IsNoContactDelivery == null && other.IsNoContactDelivery == null) || (this.IsNoContactDelivery?.Equals(other.IsNoContactDelivery) == true)) &&
                ((this.DropoffNotes == null && other.DropoffNotes == null) || (this.DropoffNotes?.Equals(other.DropoffNotes) == true)) &&
                ((this.CourierProviderName == null && other.CourierProviderName == null) || (this.CourierProviderName?.Equals(other.CourierProviderName) == true)) &&
                ((this.CourierSupportPhoneNumber == null && other.CourierSupportPhoneNumber == null) || (this.CourierSupportPhoneNumber?.Equals(other.CourierSupportPhoneNumber) == true)) &&
                ((this.SquareDeliveryId == null && other.SquareDeliveryId == null) || (this.SquareDeliveryId?.Equals(other.SquareDeliveryId) == true)) &&
                ((this.ExternalDeliveryId == null && other.ExternalDeliveryId == null) || (this.ExternalDeliveryId?.Equals(other.ExternalDeliveryId) == true)) &&
                ((this.ManagedDelivery == null && other.ManagedDelivery == null) || (this.ManagedDelivery?.Equals(other.ManagedDelivery) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1134318388;
            hashCode = HashCode.Combine(this.Recipient, this.ScheduleType, this.PlacedAt, this.DeliverAt, this.PrepTimeDuration, this.DeliveryWindowDuration, this.Note);

            hashCode = HashCode.Combine(hashCode, this.CompletedAt, this.InProgressAt, this.RejectedAt, this.ReadyAt, this.DeliveredAt, this.CanceledAt, this.CancelReason);

            hashCode = HashCode.Combine(hashCode, this.CourierPickupAt, this.CourierPickupWindowDuration, this.IsNoContactDelivery, this.DropoffNotes, this.CourierProviderName, this.CourierSupportPhoneNumber, this.SquareDeliveryId);

            hashCode = HashCode.Combine(hashCode, this.ExternalDeliveryId, this.ManagedDelivery);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Recipient = {(this.Recipient == null ? "null" : this.Recipient.ToString())}");
            toStringOutput.Add($"this.ScheduleType = {(this.ScheduleType == null ? "null" : this.ScheduleType.ToString())}");
            toStringOutput.Add($"this.PlacedAt = {(this.PlacedAt == null ? "null" : this.PlacedAt)}");
            toStringOutput.Add($"this.DeliverAt = {(this.DeliverAt == null ? "null" : this.DeliverAt)}");
            toStringOutput.Add($"this.PrepTimeDuration = {(this.PrepTimeDuration == null ? "null" : this.PrepTimeDuration)}");
            toStringOutput.Add($"this.DeliveryWindowDuration = {(this.DeliveryWindowDuration == null ? "null" : this.DeliveryWindowDuration)}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note)}");
            toStringOutput.Add($"this.CompletedAt = {(this.CompletedAt == null ? "null" : this.CompletedAt)}");
            toStringOutput.Add($"this.InProgressAt = {(this.InProgressAt == null ? "null" : this.InProgressAt)}");
            toStringOutput.Add($"this.RejectedAt = {(this.RejectedAt == null ? "null" : this.RejectedAt)}");
            toStringOutput.Add($"this.ReadyAt = {(this.ReadyAt == null ? "null" : this.ReadyAt)}");
            toStringOutput.Add($"this.DeliveredAt = {(this.DeliveredAt == null ? "null" : this.DeliveredAt)}");
            toStringOutput.Add($"this.CanceledAt = {(this.CanceledAt == null ? "null" : this.CanceledAt)}");
            toStringOutput.Add($"this.CancelReason = {(this.CancelReason == null ? "null" : this.CancelReason)}");
            toStringOutput.Add($"this.CourierPickupAt = {(this.CourierPickupAt == null ? "null" : this.CourierPickupAt)}");
            toStringOutput.Add($"this.CourierPickupWindowDuration = {(this.CourierPickupWindowDuration == null ? "null" : this.CourierPickupWindowDuration)}");
            toStringOutput.Add($"this.IsNoContactDelivery = {(this.IsNoContactDelivery == null ? "null" : this.IsNoContactDelivery.ToString())}");
            toStringOutput.Add($"this.DropoffNotes = {(this.DropoffNotes == null ? "null" : this.DropoffNotes)}");
            toStringOutput.Add($"this.CourierProviderName = {(this.CourierProviderName == null ? "null" : this.CourierProviderName)}");
            toStringOutput.Add($"this.CourierSupportPhoneNumber = {(this.CourierSupportPhoneNumber == null ? "null" : this.CourierSupportPhoneNumber)}");
            toStringOutput.Add($"this.SquareDeliveryId = {(this.SquareDeliveryId == null ? "null" : this.SquareDeliveryId)}");
            toStringOutput.Add($"this.ExternalDeliveryId = {(this.ExternalDeliveryId == null ? "null" : this.ExternalDeliveryId)}");
            toStringOutput.Add($"this.ManagedDelivery = {(this.ManagedDelivery == null ? "null" : this.ManagedDelivery.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Recipient(this.Recipient)
                .ScheduleType(this.ScheduleType)
                .PlacedAt(this.PlacedAt)
                .DeliverAt(this.DeliverAt)
                .PrepTimeDuration(this.PrepTimeDuration)
                .DeliveryWindowDuration(this.DeliveryWindowDuration)
                .Note(this.Note)
                .CompletedAt(this.CompletedAt)
                .InProgressAt(this.InProgressAt)
                .RejectedAt(this.RejectedAt)
                .ReadyAt(this.ReadyAt)
                .DeliveredAt(this.DeliveredAt)
                .CanceledAt(this.CanceledAt)
                .CancelReason(this.CancelReason)
                .CourierPickupAt(this.CourierPickupAt)
                .CourierPickupWindowDuration(this.CourierPickupWindowDuration)
                .IsNoContactDelivery(this.IsNoContactDelivery)
                .DropoffNotes(this.DropoffNotes)
                .CourierProviderName(this.CourierProviderName)
                .CourierSupportPhoneNumber(this.CourierSupportPhoneNumber)
                .SquareDeliveryId(this.SquareDeliveryId)
                .ExternalDeliveryId(this.ExternalDeliveryId)
                .ManagedDelivery(this.ManagedDelivery);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "deliver_at", false },
                { "prep_time_duration", false },
                { "delivery_window_duration", false },
                { "note", false },
                { "completed_at", false },
                { "cancel_reason", false },
                { "courier_pickup_at", false },
                { "courier_pickup_window_duration", false },
                { "is_no_contact_delivery", false },
                { "dropoff_notes", false },
                { "courier_provider_name", false },
                { "courier_support_phone_number", false },
                { "square_delivery_id", false },
                { "external_delivery_id", false },
                { "managed_delivery", false },
            };

            private Models.FulfillmentRecipient recipient;
            private string scheduleType;
            private string placedAt;
            private string deliverAt;
            private string prepTimeDuration;
            private string deliveryWindowDuration;
            private string note;
            private string completedAt;
            private string inProgressAt;
            private string rejectedAt;
            private string readyAt;
            private string deliveredAt;
            private string canceledAt;
            private string cancelReason;
            private string courierPickupAt;
            private string courierPickupWindowDuration;
            private bool? isNoContactDelivery;
            private string dropoffNotes;
            private string courierProviderName;
            private string courierSupportPhoneNumber;
            private string squareDeliveryId;
            private string externalDeliveryId;
            private bool? managedDelivery;

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
             /// ScheduleType.
             /// </summary>
             /// <param name="scheduleType"> scheduleType. </param>
             /// <returns> Builder. </returns>
            public Builder ScheduleType(string scheduleType)
            {
                this.scheduleType = scheduleType;
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
             /// DeliverAt.
             /// </summary>
             /// <param name="deliverAt"> deliverAt. </param>
             /// <returns> Builder. </returns>
            public Builder DeliverAt(string deliverAt)
            {
                shouldSerialize["deliver_at"] = true;
                this.deliverAt = deliverAt;
                return this;
            }

             /// <summary>
             /// PrepTimeDuration.
             /// </summary>
             /// <param name="prepTimeDuration"> prepTimeDuration. </param>
             /// <returns> Builder. </returns>
            public Builder PrepTimeDuration(string prepTimeDuration)
            {
                shouldSerialize["prep_time_duration"] = true;
                this.prepTimeDuration = prepTimeDuration;
                return this;
            }

             /// <summary>
             /// DeliveryWindowDuration.
             /// </summary>
             /// <param name="deliveryWindowDuration"> deliveryWindowDuration. </param>
             /// <returns> Builder. </returns>
            public Builder DeliveryWindowDuration(string deliveryWindowDuration)
            {
                shouldSerialize["delivery_window_duration"] = true;
                this.deliveryWindowDuration = deliveryWindowDuration;
                return this;
            }

             /// <summary>
             /// Note.
             /// </summary>
             /// <param name="note"> note. </param>
             /// <returns> Builder. </returns>
            public Builder Note(string note)
            {
                shouldSerialize["note"] = true;
                this.note = note;
                return this;
            }

             /// <summary>
             /// CompletedAt.
             /// </summary>
             /// <param name="completedAt"> completedAt. </param>
             /// <returns> Builder. </returns>
            public Builder CompletedAt(string completedAt)
            {
                shouldSerialize["completed_at"] = true;
                this.completedAt = completedAt;
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
             /// RejectedAt.
             /// </summary>
             /// <param name="rejectedAt"> rejectedAt. </param>
             /// <returns> Builder. </returns>
            public Builder RejectedAt(string rejectedAt)
            {
                this.rejectedAt = rejectedAt;
                return this;
            }

             /// <summary>
             /// ReadyAt.
             /// </summary>
             /// <param name="readyAt"> readyAt. </param>
             /// <returns> Builder. </returns>
            public Builder ReadyAt(string readyAt)
            {
                this.readyAt = readyAt;
                return this;
            }

             /// <summary>
             /// DeliveredAt.
             /// </summary>
             /// <param name="deliveredAt"> deliveredAt. </param>
             /// <returns> Builder. </returns>
            public Builder DeliveredAt(string deliveredAt)
            {
                this.deliveredAt = deliveredAt;
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
                shouldSerialize["cancel_reason"] = true;
                this.cancelReason = cancelReason;
                return this;
            }

             /// <summary>
             /// CourierPickupAt.
             /// </summary>
             /// <param name="courierPickupAt"> courierPickupAt. </param>
             /// <returns> Builder. </returns>
            public Builder CourierPickupAt(string courierPickupAt)
            {
                shouldSerialize["courier_pickup_at"] = true;
                this.courierPickupAt = courierPickupAt;
                return this;
            }

             /// <summary>
             /// CourierPickupWindowDuration.
             /// </summary>
             /// <param name="courierPickupWindowDuration"> courierPickupWindowDuration. </param>
             /// <returns> Builder. </returns>
            public Builder CourierPickupWindowDuration(string courierPickupWindowDuration)
            {
                shouldSerialize["courier_pickup_window_duration"] = true;
                this.courierPickupWindowDuration = courierPickupWindowDuration;
                return this;
            }

             /// <summary>
             /// IsNoContactDelivery.
             /// </summary>
             /// <param name="isNoContactDelivery"> isNoContactDelivery. </param>
             /// <returns> Builder. </returns>
            public Builder IsNoContactDelivery(bool? isNoContactDelivery)
            {
                shouldSerialize["is_no_contact_delivery"] = true;
                this.isNoContactDelivery = isNoContactDelivery;
                return this;
            }

             /// <summary>
             /// DropoffNotes.
             /// </summary>
             /// <param name="dropoffNotes"> dropoffNotes. </param>
             /// <returns> Builder. </returns>
            public Builder DropoffNotes(string dropoffNotes)
            {
                shouldSerialize["dropoff_notes"] = true;
                this.dropoffNotes = dropoffNotes;
                return this;
            }

             /// <summary>
             /// CourierProviderName.
             /// </summary>
             /// <param name="courierProviderName"> courierProviderName. </param>
             /// <returns> Builder. </returns>
            public Builder CourierProviderName(string courierProviderName)
            {
                shouldSerialize["courier_provider_name"] = true;
                this.courierProviderName = courierProviderName;
                return this;
            }

             /// <summary>
             /// CourierSupportPhoneNumber.
             /// </summary>
             /// <param name="courierSupportPhoneNumber"> courierSupportPhoneNumber. </param>
             /// <returns> Builder. </returns>
            public Builder CourierSupportPhoneNumber(string courierSupportPhoneNumber)
            {
                shouldSerialize["courier_support_phone_number"] = true;
                this.courierSupportPhoneNumber = courierSupportPhoneNumber;
                return this;
            }

             /// <summary>
             /// SquareDeliveryId.
             /// </summary>
             /// <param name="squareDeliveryId"> squareDeliveryId. </param>
             /// <returns> Builder. </returns>
            public Builder SquareDeliveryId(string squareDeliveryId)
            {
                shouldSerialize["square_delivery_id"] = true;
                this.squareDeliveryId = squareDeliveryId;
                return this;
            }

             /// <summary>
             /// ExternalDeliveryId.
             /// </summary>
             /// <param name="externalDeliveryId"> externalDeliveryId. </param>
             /// <returns> Builder. </returns>
            public Builder ExternalDeliveryId(string externalDeliveryId)
            {
                shouldSerialize["external_delivery_id"] = true;
                this.externalDeliveryId = externalDeliveryId;
                return this;
            }

             /// <summary>
             /// ManagedDelivery.
             /// </summary>
             /// <param name="managedDelivery"> managedDelivery. </param>
             /// <returns> Builder. </returns>
            public Builder ManagedDelivery(bool? managedDelivery)
            {
                shouldSerialize["managed_delivery"] = true;
                this.managedDelivery = managedDelivery;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDeliverAt()
            {
                this.shouldSerialize["deliver_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPrepTimeDuration()
            {
                this.shouldSerialize["prep_time_duration"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDeliveryWindowDuration()
            {
                this.shouldSerialize["delivery_window_duration"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetNote()
            {
                this.shouldSerialize["note"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCompletedAt()
            {
                this.shouldSerialize["completed_at"] = false;
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
            public void UnsetCourierPickupAt()
            {
                this.shouldSerialize["courier_pickup_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCourierPickupWindowDuration()
            {
                this.shouldSerialize["courier_pickup_window_duration"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsNoContactDelivery()
            {
                this.shouldSerialize["is_no_contact_delivery"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDropoffNotes()
            {
                this.shouldSerialize["dropoff_notes"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCourierProviderName()
            {
                this.shouldSerialize["courier_provider_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCourierSupportPhoneNumber()
            {
                this.shouldSerialize["courier_support_phone_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSquareDeliveryId()
            {
                this.shouldSerialize["square_delivery_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetExternalDeliveryId()
            {
                this.shouldSerialize["external_delivery_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetManagedDelivery()
            {
                this.shouldSerialize["managed_delivery"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> FulfillmentDeliveryDetails. </returns>
            public FulfillmentDeliveryDetails Build()
            {
                return new FulfillmentDeliveryDetails(shouldSerialize,
                    this.recipient,
                    this.scheduleType,
                    this.placedAt,
                    this.deliverAt,
                    this.prepTimeDuration,
                    this.deliveryWindowDuration,
                    this.note,
                    this.completedAt,
                    this.inProgressAt,
                    this.rejectedAt,
                    this.readyAt,
                    this.deliveredAt,
                    this.canceledAt,
                    this.cancelReason,
                    this.courierPickupAt,
                    this.courierPickupWindowDuration,
                    this.isNoContactDelivery,
                    this.dropoffNotes,
                    this.courierProviderName,
                    this.courierSupportPhoneNumber,
                    this.squareDeliveryId,
                    this.externalDeliveryId,
                    this.managedDelivery);
            }
        }
    }
}