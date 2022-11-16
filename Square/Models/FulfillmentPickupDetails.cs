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
    /// FulfillmentPickupDetails.
    /// </summary>
    public class FulfillmentPickupDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="FulfillmentPickupDetails"/> class.
        /// </summary>
        /// <param name="recipient">recipient.</param>
        /// <param name="expiresAt">expires_at.</param>
        /// <param name="autoCompleteDuration">auto_complete_duration.</param>
        /// <param name="scheduleType">schedule_type.</param>
        /// <param name="pickupAt">pickup_at.</param>
        /// <param name="pickupWindowDuration">pickup_window_duration.</param>
        /// <param name="prepTimeDuration">prep_time_duration.</param>
        /// <param name="note">note.</param>
        /// <param name="placedAt">placed_at.</param>
        /// <param name="acceptedAt">accepted_at.</param>
        /// <param name="rejectedAt">rejected_at.</param>
        /// <param name="readyAt">ready_at.</param>
        /// <param name="expiredAt">expired_at.</param>
        /// <param name="pickedUpAt">picked_up_at.</param>
        /// <param name="canceledAt">canceled_at.</param>
        /// <param name="cancelReason">cancel_reason.</param>
        /// <param name="isCurbsidePickup">is_curbside_pickup.</param>
        /// <param name="curbsidePickupDetails">curbside_pickup_details.</param>
        public FulfillmentPickupDetails(
            Models.FulfillmentRecipient recipient = null,
            string expiresAt = null,
            string autoCompleteDuration = null,
            string scheduleType = null,
            string pickupAt = null,
            string pickupWindowDuration = null,
            string prepTimeDuration = null,
            string note = null,
            string placedAt = null,
            string acceptedAt = null,
            string rejectedAt = null,
            string readyAt = null,
            string expiredAt = null,
            string pickedUpAt = null,
            string canceledAt = null,
            string cancelReason = null,
            bool? isCurbsidePickup = null,
            Models.FulfillmentPickupDetailsCurbsidePickupDetails curbsidePickupDetails = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "expires_at", false },
                { "auto_complete_duration", false },
                { "pickup_at", false },
                { "pickup_window_duration", false },
                { "prep_time_duration", false },
                { "note", false },
                { "cancel_reason", false },
                { "is_curbside_pickup", false }
            };

            this.Recipient = recipient;
            if (expiresAt != null)
            {
                shouldSerialize["expires_at"] = true;
                this.ExpiresAt = expiresAt;
            }

            if (autoCompleteDuration != null)
            {
                shouldSerialize["auto_complete_duration"] = true;
                this.AutoCompleteDuration = autoCompleteDuration;
            }

            this.ScheduleType = scheduleType;
            if (pickupAt != null)
            {
                shouldSerialize["pickup_at"] = true;
                this.PickupAt = pickupAt;
            }

            if (pickupWindowDuration != null)
            {
                shouldSerialize["pickup_window_duration"] = true;
                this.PickupWindowDuration = pickupWindowDuration;
            }

            if (prepTimeDuration != null)
            {
                shouldSerialize["prep_time_duration"] = true;
                this.PrepTimeDuration = prepTimeDuration;
            }

            if (note != null)
            {
                shouldSerialize["note"] = true;
                this.Note = note;
            }

            this.PlacedAt = placedAt;
            this.AcceptedAt = acceptedAt;
            this.RejectedAt = rejectedAt;
            this.ReadyAt = readyAt;
            this.ExpiredAt = expiredAt;
            this.PickedUpAt = pickedUpAt;
            this.CanceledAt = canceledAt;
            if (cancelReason != null)
            {
                shouldSerialize["cancel_reason"] = true;
                this.CancelReason = cancelReason;
            }

            if (isCurbsidePickup != null)
            {
                shouldSerialize["is_curbside_pickup"] = true;
                this.IsCurbsidePickup = isCurbsidePickup;
            }

            this.CurbsidePickupDetails = curbsidePickupDetails;
        }
        internal FulfillmentPickupDetails(Dictionary<string, bool> shouldSerialize,
            Models.FulfillmentRecipient recipient = null,
            string expiresAt = null,
            string autoCompleteDuration = null,
            string scheduleType = null,
            string pickupAt = null,
            string pickupWindowDuration = null,
            string prepTimeDuration = null,
            string note = null,
            string placedAt = null,
            string acceptedAt = null,
            string rejectedAt = null,
            string readyAt = null,
            string expiredAt = null,
            string pickedUpAt = null,
            string canceledAt = null,
            string cancelReason = null,
            bool? isCurbsidePickup = null,
            Models.FulfillmentPickupDetailsCurbsidePickupDetails curbsidePickupDetails = null)
        {
            this.shouldSerialize = shouldSerialize;
            Recipient = recipient;
            ExpiresAt = expiresAt;
            AutoCompleteDuration = autoCompleteDuration;
            ScheduleType = scheduleType;
            PickupAt = pickupAt;
            PickupWindowDuration = pickupWindowDuration;
            PrepTimeDuration = prepTimeDuration;
            Note = note;
            PlacedAt = placedAt;
            AcceptedAt = acceptedAt;
            RejectedAt = rejectedAt;
            ReadyAt = readyAt;
            ExpiredAt = expiredAt;
            PickedUpAt = pickedUpAt;
            CanceledAt = canceledAt;
            CancelReason = cancelReason;
            IsCurbsidePickup = isCurbsidePickup;
            CurbsidePickupDetails = curbsidePickupDetails;
        }

        /// <summary>
        /// Information about the fulfillment recipient.
        /// </summary>
        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FulfillmentRecipient Recipient { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when this fulfillment expires if it is not accepted. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z"). The expiration time can only be set up to 7 days in the future.
        /// If `expires_at` is not set, this pickup fulfillment is automatically accepted when
        /// placed.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; }

        /// <summary>
        /// The duration of time after which an open and accepted pickup fulfillment
        /// is automatically moved to the `COMPLETED` state. The duration must be in RFC 3339
        /// format (for example, "P1W3D").
        /// If not set, this pickup fulfillment remains accepted until it is canceled or completed.
        /// </summary>
        [JsonProperty("auto_complete_duration")]
        public string AutoCompleteDuration { get; }

        /// <summary>
        /// The schedule type of the pickup fulfillment.
        /// </summary>
        [JsonProperty("schedule_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ScheduleType { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// that represents the start of the pickup window. Must be in RFC 3339 timestamp format, e.g.,
        /// "2016-09-04T23:59:33.123Z".
        /// For fulfillments with the schedule type `ASAP`, this is automatically set
        /// to the current time plus the expected duration to prepare the fulfillment.
        /// </summary>
        [JsonProperty("pickup_at")]
        public string PickupAt { get; }

        /// <summary>
        /// The window of time in which the order should be picked up after the `pickup_at` timestamp.
        /// Must be in RFC 3339 duration format, e.g., "P1W3D". Can be used as an
        /// informational guideline for merchants.
        /// </summary>
        [JsonProperty("pickup_window_duration")]
        public string PickupWindowDuration { get; }

        /// <summary>
        /// The duration of time it takes to prepare this fulfillment.
        /// The duration must be in RFC 3339 format (for example, "P1W3D").
        /// </summary>
        [JsonProperty("prep_time_duration")]
        public string PrepTimeDuration { get; }

        /// <summary>
        /// A note to provide additional instructions about the pickup
        /// fulfillment displayed in the Square Point of Sale application and set by the API.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was placed. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("placed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PlacedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was accepted. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("accepted_at", NullValueHandling = NullValueHandling.Ignore)]
        public string AcceptedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was rejected. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("rejected_at", NullValueHandling = NullValueHandling.Ignore)]
        public string RejectedAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment is marked as ready for pickup. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("ready_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ReadyAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment expired. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("expired_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiredAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was picked up by the recipient. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("picked_up_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PickedUpAt { get; }

        /// <summary>
        /// The [timestamp](https://developer.squareup.com/docs/build-basics/working-with-dates)
        /// indicating when the fulfillment was canceled. The timestamp must be in RFC 3339 format
        /// (for example, "2016-09-04T23:59:33.123Z").
        /// </summary>
        [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CanceledAt { get; }

        /// <summary>
        /// A description of why the pickup was canceled. The maximum length: 100 characters.
        /// </summary>
        [JsonProperty("cancel_reason")]
        public string CancelReason { get; }

        /// <summary>
        /// If set to `true`, indicates that this pickup order is for curbside pickup, not in-store pickup.
        /// </summary>
        [JsonProperty("is_curbside_pickup")]
        public bool? IsCurbsidePickup { get; }

        /// <summary>
        /// Specific details for curbside pickup.
        /// </summary>
        [JsonProperty("curbside_pickup_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.FulfillmentPickupDetailsCurbsidePickupDetails CurbsidePickupDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"FulfillmentPickupDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeExpiresAt()
        {
            return this.shouldSerialize["expires_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAutoCompleteDuration()
        {
            return this.shouldSerialize["auto_complete_duration"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePickupAt()
        {
            return this.shouldSerialize["pickup_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePickupWindowDuration()
        {
            return this.shouldSerialize["pickup_window_duration"];
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
        public bool ShouldSerializeNote()
        {
            return this.shouldSerialize["note"];
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
        public bool ShouldSerializeIsCurbsidePickup()
        {
            return this.shouldSerialize["is_curbside_pickup"];
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

            return obj is FulfillmentPickupDetails other &&
                ((this.Recipient == null && other.Recipient == null) || (this.Recipient?.Equals(other.Recipient) == true)) &&
                ((this.ExpiresAt == null && other.ExpiresAt == null) || (this.ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((this.AutoCompleteDuration == null && other.AutoCompleteDuration == null) || (this.AutoCompleteDuration?.Equals(other.AutoCompleteDuration) == true)) &&
                ((this.ScheduleType == null && other.ScheduleType == null) || (this.ScheduleType?.Equals(other.ScheduleType) == true)) &&
                ((this.PickupAt == null && other.PickupAt == null) || (this.PickupAt?.Equals(other.PickupAt) == true)) &&
                ((this.PickupWindowDuration == null && other.PickupWindowDuration == null) || (this.PickupWindowDuration?.Equals(other.PickupWindowDuration) == true)) &&
                ((this.PrepTimeDuration == null && other.PrepTimeDuration == null) || (this.PrepTimeDuration?.Equals(other.PrepTimeDuration) == true)) &&
                ((this.Note == null && other.Note == null) || (this.Note?.Equals(other.Note) == true)) &&
                ((this.PlacedAt == null && other.PlacedAt == null) || (this.PlacedAt?.Equals(other.PlacedAt) == true)) &&
                ((this.AcceptedAt == null && other.AcceptedAt == null) || (this.AcceptedAt?.Equals(other.AcceptedAt) == true)) &&
                ((this.RejectedAt == null && other.RejectedAt == null) || (this.RejectedAt?.Equals(other.RejectedAt) == true)) &&
                ((this.ReadyAt == null && other.ReadyAt == null) || (this.ReadyAt?.Equals(other.ReadyAt) == true)) &&
                ((this.ExpiredAt == null && other.ExpiredAt == null) || (this.ExpiredAt?.Equals(other.ExpiredAt) == true)) &&
                ((this.PickedUpAt == null && other.PickedUpAt == null) || (this.PickedUpAt?.Equals(other.PickedUpAt) == true)) &&
                ((this.CanceledAt == null && other.CanceledAt == null) || (this.CanceledAt?.Equals(other.CanceledAt) == true)) &&
                ((this.CancelReason == null && other.CancelReason == null) || (this.CancelReason?.Equals(other.CancelReason) == true)) &&
                ((this.IsCurbsidePickup == null && other.IsCurbsidePickup == null) || (this.IsCurbsidePickup?.Equals(other.IsCurbsidePickup) == true)) &&
                ((this.CurbsidePickupDetails == null && other.CurbsidePickupDetails == null) || (this.CurbsidePickupDetails?.Equals(other.CurbsidePickupDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1772356817;
            hashCode = HashCode.Combine(this.Recipient, this.ExpiresAt, this.AutoCompleteDuration, this.ScheduleType, this.PickupAt, this.PickupWindowDuration, this.PrepTimeDuration);

            hashCode = HashCode.Combine(hashCode, this.Note, this.PlacedAt, this.AcceptedAt, this.RejectedAt, this.ReadyAt, this.ExpiredAt, this.PickedUpAt);

            hashCode = HashCode.Combine(hashCode, this.CanceledAt, this.CancelReason, this.IsCurbsidePickup, this.CurbsidePickupDetails);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Recipient = {(this.Recipient == null ? "null" : this.Recipient.ToString())}");
            toStringOutput.Add($"this.ExpiresAt = {(this.ExpiresAt == null ? "null" : this.ExpiresAt == string.Empty ? "" : this.ExpiresAt)}");
            toStringOutput.Add($"this.AutoCompleteDuration = {(this.AutoCompleteDuration == null ? "null" : this.AutoCompleteDuration == string.Empty ? "" : this.AutoCompleteDuration)}");
            toStringOutput.Add($"this.ScheduleType = {(this.ScheduleType == null ? "null" : this.ScheduleType.ToString())}");
            toStringOutput.Add($"this.PickupAt = {(this.PickupAt == null ? "null" : this.PickupAt == string.Empty ? "" : this.PickupAt)}");
            toStringOutput.Add($"this.PickupWindowDuration = {(this.PickupWindowDuration == null ? "null" : this.PickupWindowDuration == string.Empty ? "" : this.PickupWindowDuration)}");
            toStringOutput.Add($"this.PrepTimeDuration = {(this.PrepTimeDuration == null ? "null" : this.PrepTimeDuration == string.Empty ? "" : this.PrepTimeDuration)}");
            toStringOutput.Add($"this.Note = {(this.Note == null ? "null" : this.Note == string.Empty ? "" : this.Note)}");
            toStringOutput.Add($"this.PlacedAt = {(this.PlacedAt == null ? "null" : this.PlacedAt == string.Empty ? "" : this.PlacedAt)}");
            toStringOutput.Add($"this.AcceptedAt = {(this.AcceptedAt == null ? "null" : this.AcceptedAt == string.Empty ? "" : this.AcceptedAt)}");
            toStringOutput.Add($"this.RejectedAt = {(this.RejectedAt == null ? "null" : this.RejectedAt == string.Empty ? "" : this.RejectedAt)}");
            toStringOutput.Add($"this.ReadyAt = {(this.ReadyAt == null ? "null" : this.ReadyAt == string.Empty ? "" : this.ReadyAt)}");
            toStringOutput.Add($"this.ExpiredAt = {(this.ExpiredAt == null ? "null" : this.ExpiredAt == string.Empty ? "" : this.ExpiredAt)}");
            toStringOutput.Add($"this.PickedUpAt = {(this.PickedUpAt == null ? "null" : this.PickedUpAt == string.Empty ? "" : this.PickedUpAt)}");
            toStringOutput.Add($"this.CanceledAt = {(this.CanceledAt == null ? "null" : this.CanceledAt == string.Empty ? "" : this.CanceledAt)}");
            toStringOutput.Add($"this.CancelReason = {(this.CancelReason == null ? "null" : this.CancelReason == string.Empty ? "" : this.CancelReason)}");
            toStringOutput.Add($"this.IsCurbsidePickup = {(this.IsCurbsidePickup == null ? "null" : this.IsCurbsidePickup.ToString())}");
            toStringOutput.Add($"this.CurbsidePickupDetails = {(this.CurbsidePickupDetails == null ? "null" : this.CurbsidePickupDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Recipient(this.Recipient)
                .ExpiresAt(this.ExpiresAt)
                .AutoCompleteDuration(this.AutoCompleteDuration)
                .ScheduleType(this.ScheduleType)
                .PickupAt(this.PickupAt)
                .PickupWindowDuration(this.PickupWindowDuration)
                .PrepTimeDuration(this.PrepTimeDuration)
                .Note(this.Note)
                .PlacedAt(this.PlacedAt)
                .AcceptedAt(this.AcceptedAt)
                .RejectedAt(this.RejectedAt)
                .ReadyAt(this.ReadyAt)
                .ExpiredAt(this.ExpiredAt)
                .PickedUpAt(this.PickedUpAt)
                .CanceledAt(this.CanceledAt)
                .CancelReason(this.CancelReason)
                .IsCurbsidePickup(this.IsCurbsidePickup)
                .CurbsidePickupDetails(this.CurbsidePickupDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "expires_at", false },
                { "auto_complete_duration", false },
                { "pickup_at", false },
                { "pickup_window_duration", false },
                { "prep_time_duration", false },
                { "note", false },
                { "cancel_reason", false },
                { "is_curbside_pickup", false },
            };

            private Models.FulfillmentRecipient recipient;
            private string expiresAt;
            private string autoCompleteDuration;
            private string scheduleType;
            private string pickupAt;
            private string pickupWindowDuration;
            private string prepTimeDuration;
            private string note;
            private string placedAt;
            private string acceptedAt;
            private string rejectedAt;
            private string readyAt;
            private string expiredAt;
            private string pickedUpAt;
            private string canceledAt;
            private string cancelReason;
            private bool? isCurbsidePickup;
            private Models.FulfillmentPickupDetailsCurbsidePickupDetails curbsidePickupDetails;

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
             /// ExpiresAt.
             /// </summary>
             /// <param name="expiresAt"> expiresAt. </param>
             /// <returns> Builder. </returns>
            public Builder ExpiresAt(string expiresAt)
            {
                shouldSerialize["expires_at"] = true;
                this.expiresAt = expiresAt;
                return this;
            }

             /// <summary>
             /// AutoCompleteDuration.
             /// </summary>
             /// <param name="autoCompleteDuration"> autoCompleteDuration. </param>
             /// <returns> Builder. </returns>
            public Builder AutoCompleteDuration(string autoCompleteDuration)
            {
                shouldSerialize["auto_complete_duration"] = true;
                this.autoCompleteDuration = autoCompleteDuration;
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
             /// PickupAt.
             /// </summary>
             /// <param name="pickupAt"> pickupAt. </param>
             /// <returns> Builder. </returns>
            public Builder PickupAt(string pickupAt)
            {
                shouldSerialize["pickup_at"] = true;
                this.pickupAt = pickupAt;
                return this;
            }

             /// <summary>
             /// PickupWindowDuration.
             /// </summary>
             /// <param name="pickupWindowDuration"> pickupWindowDuration. </param>
             /// <returns> Builder. </returns>
            public Builder PickupWindowDuration(string pickupWindowDuration)
            {
                shouldSerialize["pickup_window_duration"] = true;
                this.pickupWindowDuration = pickupWindowDuration;
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
             /// AcceptedAt.
             /// </summary>
             /// <param name="acceptedAt"> acceptedAt. </param>
             /// <returns> Builder. </returns>
            public Builder AcceptedAt(string acceptedAt)
            {
                this.acceptedAt = acceptedAt;
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
             /// ExpiredAt.
             /// </summary>
             /// <param name="expiredAt"> expiredAt. </param>
             /// <returns> Builder. </returns>
            public Builder ExpiredAt(string expiredAt)
            {
                this.expiredAt = expiredAt;
                return this;
            }

             /// <summary>
             /// PickedUpAt.
             /// </summary>
             /// <param name="pickedUpAt"> pickedUpAt. </param>
             /// <returns> Builder. </returns>
            public Builder PickedUpAt(string pickedUpAt)
            {
                this.pickedUpAt = pickedUpAt;
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
             /// IsCurbsidePickup.
             /// </summary>
             /// <param name="isCurbsidePickup"> isCurbsidePickup. </param>
             /// <returns> Builder. </returns>
            public Builder IsCurbsidePickup(bool? isCurbsidePickup)
            {
                shouldSerialize["is_curbside_pickup"] = true;
                this.isCurbsidePickup = isCurbsidePickup;
                return this;
            }

             /// <summary>
             /// CurbsidePickupDetails.
             /// </summary>
             /// <param name="curbsidePickupDetails"> curbsidePickupDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CurbsidePickupDetails(Models.FulfillmentPickupDetailsCurbsidePickupDetails curbsidePickupDetails)
            {
                this.curbsidePickupDetails = curbsidePickupDetails;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetExpiresAt()
            {
                this.shouldSerialize["expires_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAutoCompleteDuration()
            {
                this.shouldSerialize["auto_complete_duration"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPickupAt()
            {
                this.shouldSerialize["pickup_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPickupWindowDuration()
            {
                this.shouldSerialize["pickup_window_duration"] = false;
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
            public void UnsetNote()
            {
                this.shouldSerialize["note"] = false;
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
            public void UnsetIsCurbsidePickup()
            {
                this.shouldSerialize["is_curbside_pickup"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> FulfillmentPickupDetails. </returns>
            public FulfillmentPickupDetails Build()
            {
                return new FulfillmentPickupDetails(shouldSerialize,
                    this.recipient,
                    this.expiresAt,
                    this.autoCompleteDuration,
                    this.scheduleType,
                    this.pickupAt,
                    this.pickupWindowDuration,
                    this.prepTimeDuration,
                    this.note,
                    this.placedAt,
                    this.acceptedAt,
                    this.rejectedAt,
                    this.readyAt,
                    this.expiredAt,
                    this.pickedUpAt,
                    this.canceledAt,
                    this.cancelReason,
                    this.isCurbsidePickup,
                    this.curbsidePickupDetails);
            }
        }
    }
}