
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
    public class OrderFulfillmentPickupDetails 
    {
        public OrderFulfillmentPickupDetails(Models.OrderFulfillmentRecipient recipient = null,
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
            Models.OrderFulfillmentPickupDetailsCurbsidePickupDetails curbsidePickupDetails = null)
        {
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
        /// Contains information on the recipient of a fulfillment.
        /// </summary>
        [JsonProperty("recipient", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentRecipient Recipient { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when this fulfillment
        /// will expire if it is not accepted. Must be in RFC 3339 format
        /// e.g., "2016-09-04T23:59:33.123Z". Expiration time can only be set up to 7
        /// days in the future. If `expires_at` is not set, this pickup fulfillment
        /// will be automatically accepted when placed.
        /// </summary>
        [JsonProperty("expires_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresAt { get; }

        /// <summary>
        /// The duration of time after which an open and accepted pickup fulfillment
        /// will automatically move to the `COMPLETED` state. Must be in RFC3339
        /// duration format e.g., "P1W3D".
        /// If not set, this pickup fulfillment will remain accepted until it is canceled or completed.
        /// </summary>
        [JsonProperty("auto_complete_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string AutoCompleteDuration { get; }

        /// <summary>
        /// The schedule type of the pickup fulfillment.
        /// </summary>
        [JsonProperty("schedule_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ScheduleType { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) that represents the start of the pickup window.
        /// Must be in RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// For fulfillments with the schedule type `ASAP`, this is automatically set
        /// to the current time plus the expected duration to prepare the fulfillment.
        /// </summary>
        [JsonProperty("pickup_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PickupAt { get; }

        /// <summary>
        /// The window of time in which the order should be picked up after the `pickup_at` timestamp.
        /// Must be in RFC3339 duration format, e.g., "P1W3D". Can be used as an
        /// informational guideline for merchants.
        /// </summary>
        [JsonProperty("pickup_window_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string PickupWindowDuration { get; }

        /// <summary>
        /// The duration of time it takes to prepare this fulfillment.
        /// Must be in RFC3339 duration format, e.g., "P1W3D".
        /// </summary>
        [JsonProperty("prep_time_duration", NullValueHandling = NullValueHandling.Ignore)]
        public string PrepTimeDuration { get; }

        /// <summary>
        /// A note meant to provide additional instructions about the pickup
        /// fulfillment displayed in the Square Point of Sale and set by the API.
        /// </summary>
        [JsonProperty("note", NullValueHandling = NullValueHandling.Ignore)]
        public string Note { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment
        /// was placed. Must be in RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("placed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PlacedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment
        /// was accepted. In RFC3339 timestamp format,
        /// e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("accepted_at", NullValueHandling = NullValueHandling.Ignore)]
        public string AcceptedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment
        /// was rejected. In RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("rejected_at", NullValueHandling = NullValueHandling.Ignore)]
        public string RejectedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment is
        /// marked as ready for pickup. In RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("ready_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ReadyAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment expired.
        /// In RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("expired_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiredAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment
        /// was picked up by the recipient. In RFC3339 timestamp format,
        /// e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("picked_up_at", NullValueHandling = NullValueHandling.Ignore)]
        public string PickedUpAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) in RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z",
        /// indicating when the fulfillment was canceled.
        /// </summary>
        [JsonProperty("canceled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CanceledAt { get; }

        /// <summary>
        /// A description of why the pickup was canceled. Max length: 100 characters.
        /// </summary>
        [JsonProperty("cancel_reason", NullValueHandling = NullValueHandling.Ignore)]
        public string CancelReason { get; }

        /// <summary>
        /// If true, indicates this pickup order is for curbside pickup, not in-store pickup.
        /// </summary>
        [JsonProperty("is_curbside_pickup", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsCurbsidePickup { get; }

        /// <summary>
        /// Specific details for curbside pickup.
        /// </summary>
        [JsonProperty("curbside_pickup_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderFulfillmentPickupDetailsCurbsidePickupDetails CurbsidePickupDetails { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderFulfillmentPickupDetails : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Recipient = {(Recipient == null ? "null" : Recipient.ToString())}");
            toStringOutput.Add($"ExpiresAt = {(ExpiresAt == null ? "null" : ExpiresAt == string.Empty ? "" : ExpiresAt)}");
            toStringOutput.Add($"AutoCompleteDuration = {(AutoCompleteDuration == null ? "null" : AutoCompleteDuration == string.Empty ? "" : AutoCompleteDuration)}");
            toStringOutput.Add($"ScheduleType = {(ScheduleType == null ? "null" : ScheduleType.ToString())}");
            toStringOutput.Add($"PickupAt = {(PickupAt == null ? "null" : PickupAt == string.Empty ? "" : PickupAt)}");
            toStringOutput.Add($"PickupWindowDuration = {(PickupWindowDuration == null ? "null" : PickupWindowDuration == string.Empty ? "" : PickupWindowDuration)}");
            toStringOutput.Add($"PrepTimeDuration = {(PrepTimeDuration == null ? "null" : PrepTimeDuration == string.Empty ? "" : PrepTimeDuration)}");
            toStringOutput.Add($"Note = {(Note == null ? "null" : Note == string.Empty ? "" : Note)}");
            toStringOutput.Add($"PlacedAt = {(PlacedAt == null ? "null" : PlacedAt == string.Empty ? "" : PlacedAt)}");
            toStringOutput.Add($"AcceptedAt = {(AcceptedAt == null ? "null" : AcceptedAt == string.Empty ? "" : AcceptedAt)}");
            toStringOutput.Add($"RejectedAt = {(RejectedAt == null ? "null" : RejectedAt == string.Empty ? "" : RejectedAt)}");
            toStringOutput.Add($"ReadyAt = {(ReadyAt == null ? "null" : ReadyAt == string.Empty ? "" : ReadyAt)}");
            toStringOutput.Add($"ExpiredAt = {(ExpiredAt == null ? "null" : ExpiredAt == string.Empty ? "" : ExpiredAt)}");
            toStringOutput.Add($"PickedUpAt = {(PickedUpAt == null ? "null" : PickedUpAt == string.Empty ? "" : PickedUpAt)}");
            toStringOutput.Add($"CanceledAt = {(CanceledAt == null ? "null" : CanceledAt == string.Empty ? "" : CanceledAt)}");
            toStringOutput.Add($"CancelReason = {(CancelReason == null ? "null" : CancelReason == string.Empty ? "" : CancelReason)}");
            toStringOutput.Add($"IsCurbsidePickup = {(IsCurbsidePickup == null ? "null" : IsCurbsidePickup.ToString())}");
            toStringOutput.Add($"CurbsidePickupDetails = {(CurbsidePickupDetails == null ? "null" : CurbsidePickupDetails.ToString())}");
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

            return obj is OrderFulfillmentPickupDetails other &&
                ((Recipient == null && other.Recipient == null) || (Recipient?.Equals(other.Recipient) == true)) &&
                ((ExpiresAt == null && other.ExpiresAt == null) || (ExpiresAt?.Equals(other.ExpiresAt) == true)) &&
                ((AutoCompleteDuration == null && other.AutoCompleteDuration == null) || (AutoCompleteDuration?.Equals(other.AutoCompleteDuration) == true)) &&
                ((ScheduleType == null && other.ScheduleType == null) || (ScheduleType?.Equals(other.ScheduleType) == true)) &&
                ((PickupAt == null && other.PickupAt == null) || (PickupAt?.Equals(other.PickupAt) == true)) &&
                ((PickupWindowDuration == null && other.PickupWindowDuration == null) || (PickupWindowDuration?.Equals(other.PickupWindowDuration) == true)) &&
                ((PrepTimeDuration == null && other.PrepTimeDuration == null) || (PrepTimeDuration?.Equals(other.PrepTimeDuration) == true)) &&
                ((Note == null && other.Note == null) || (Note?.Equals(other.Note) == true)) &&
                ((PlacedAt == null && other.PlacedAt == null) || (PlacedAt?.Equals(other.PlacedAt) == true)) &&
                ((AcceptedAt == null && other.AcceptedAt == null) || (AcceptedAt?.Equals(other.AcceptedAt) == true)) &&
                ((RejectedAt == null && other.RejectedAt == null) || (RejectedAt?.Equals(other.RejectedAt) == true)) &&
                ((ReadyAt == null && other.ReadyAt == null) || (ReadyAt?.Equals(other.ReadyAt) == true)) &&
                ((ExpiredAt == null && other.ExpiredAt == null) || (ExpiredAt?.Equals(other.ExpiredAt) == true)) &&
                ((PickedUpAt == null && other.PickedUpAt == null) || (PickedUpAt?.Equals(other.PickedUpAt) == true)) &&
                ((CanceledAt == null && other.CanceledAt == null) || (CanceledAt?.Equals(other.CanceledAt) == true)) &&
                ((CancelReason == null && other.CancelReason == null) || (CancelReason?.Equals(other.CancelReason) == true)) &&
                ((IsCurbsidePickup == null && other.IsCurbsidePickup == null) || (IsCurbsidePickup?.Equals(other.IsCurbsidePickup) == true)) &&
                ((CurbsidePickupDetails == null && other.CurbsidePickupDetails == null) || (CurbsidePickupDetails?.Equals(other.CurbsidePickupDetails) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -657729285;

            if (Recipient != null)
            {
               hashCode += Recipient.GetHashCode();
            }

            if (ExpiresAt != null)
            {
               hashCode += ExpiresAt.GetHashCode();
            }

            if (AutoCompleteDuration != null)
            {
               hashCode += AutoCompleteDuration.GetHashCode();
            }

            if (ScheduleType != null)
            {
               hashCode += ScheduleType.GetHashCode();
            }

            if (PickupAt != null)
            {
               hashCode += PickupAt.GetHashCode();
            }

            if (PickupWindowDuration != null)
            {
               hashCode += PickupWindowDuration.GetHashCode();
            }

            if (PrepTimeDuration != null)
            {
               hashCode += PrepTimeDuration.GetHashCode();
            }

            if (Note != null)
            {
               hashCode += Note.GetHashCode();
            }

            if (PlacedAt != null)
            {
               hashCode += PlacedAt.GetHashCode();
            }

            if (AcceptedAt != null)
            {
               hashCode += AcceptedAt.GetHashCode();
            }

            if (RejectedAt != null)
            {
               hashCode += RejectedAt.GetHashCode();
            }

            if (ReadyAt != null)
            {
               hashCode += ReadyAt.GetHashCode();
            }

            if (ExpiredAt != null)
            {
               hashCode += ExpiredAt.GetHashCode();
            }

            if (PickedUpAt != null)
            {
               hashCode += PickedUpAt.GetHashCode();
            }

            if (CanceledAt != null)
            {
               hashCode += CanceledAt.GetHashCode();
            }

            if (CancelReason != null)
            {
               hashCode += CancelReason.GetHashCode();
            }

            if (IsCurbsidePickup != null)
            {
               hashCode += IsCurbsidePickup.GetHashCode();
            }

            if (CurbsidePickupDetails != null)
            {
               hashCode += CurbsidePickupDetails.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Recipient(Recipient)
                .ExpiresAt(ExpiresAt)
                .AutoCompleteDuration(AutoCompleteDuration)
                .ScheduleType(ScheduleType)
                .PickupAt(PickupAt)
                .PickupWindowDuration(PickupWindowDuration)
                .PrepTimeDuration(PrepTimeDuration)
                .Note(Note)
                .PlacedAt(PlacedAt)
                .AcceptedAt(AcceptedAt)
                .RejectedAt(RejectedAt)
                .ReadyAt(ReadyAt)
                .ExpiredAt(ExpiredAt)
                .PickedUpAt(PickedUpAt)
                .CanceledAt(CanceledAt)
                .CancelReason(CancelReason)
                .IsCurbsidePickup(IsCurbsidePickup)
                .CurbsidePickupDetails(CurbsidePickupDetails);
            return builder;
        }

        public class Builder
        {
            private Models.OrderFulfillmentRecipient recipient;
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
            private Models.OrderFulfillmentPickupDetailsCurbsidePickupDetails curbsidePickupDetails;



            public Builder Recipient(Models.OrderFulfillmentRecipient recipient)
            {
                this.recipient = recipient;
                return this;
            }

            public Builder ExpiresAt(string expiresAt)
            {
                this.expiresAt = expiresAt;
                return this;
            }

            public Builder AutoCompleteDuration(string autoCompleteDuration)
            {
                this.autoCompleteDuration = autoCompleteDuration;
                return this;
            }

            public Builder ScheduleType(string scheduleType)
            {
                this.scheduleType = scheduleType;
                return this;
            }

            public Builder PickupAt(string pickupAt)
            {
                this.pickupAt = pickupAt;
                return this;
            }

            public Builder PickupWindowDuration(string pickupWindowDuration)
            {
                this.pickupWindowDuration = pickupWindowDuration;
                return this;
            }

            public Builder PrepTimeDuration(string prepTimeDuration)
            {
                this.prepTimeDuration = prepTimeDuration;
                return this;
            }

            public Builder Note(string note)
            {
                this.note = note;
                return this;
            }

            public Builder PlacedAt(string placedAt)
            {
                this.placedAt = placedAt;
                return this;
            }

            public Builder AcceptedAt(string acceptedAt)
            {
                this.acceptedAt = acceptedAt;
                return this;
            }

            public Builder RejectedAt(string rejectedAt)
            {
                this.rejectedAt = rejectedAt;
                return this;
            }

            public Builder ReadyAt(string readyAt)
            {
                this.readyAt = readyAt;
                return this;
            }

            public Builder ExpiredAt(string expiredAt)
            {
                this.expiredAt = expiredAt;
                return this;
            }

            public Builder PickedUpAt(string pickedUpAt)
            {
                this.pickedUpAt = pickedUpAt;
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

            public Builder IsCurbsidePickup(bool? isCurbsidePickup)
            {
                this.isCurbsidePickup = isCurbsidePickup;
                return this;
            }

            public Builder CurbsidePickupDetails(Models.OrderFulfillmentPickupDetailsCurbsidePickupDetails curbsidePickupDetails)
            {
                this.curbsidePickupDetails = curbsidePickupDetails;
                return this;
            }

            public OrderFulfillmentPickupDetails Build()
            {
                return new OrderFulfillmentPickupDetails(recipient,
                    expiresAt,
                    autoCompleteDuration,
                    scheduleType,
                    pickupAt,
                    pickupWindowDuration,
                    prepTimeDuration,
                    note,
                    placedAt,
                    acceptedAt,
                    rejectedAt,
                    readyAt,
                    expiredAt,
                    pickedUpAt,
                    canceledAt,
                    cancelReason,
                    isCurbsidePickup,
                    curbsidePickupDetails);
            }
        }
    }
}