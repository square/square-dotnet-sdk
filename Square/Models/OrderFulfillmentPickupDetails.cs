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
        [JsonProperty("recipient")]
        public Models.OrderFulfillmentRecipient Recipient { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when this fulfillment
        /// will expire if it is not accepted. Must be in RFC 3339 format
        /// e.g., "2016-09-04T23:59:33.123Z". Expiration time can only be set up to 7
        /// days in the future. If `expires_at` is not set, this pickup fulfillment
        /// will be automatically accepted when placed.
        /// </summary>
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; }

        /// <summary>
        /// The duration of time after which an open and accepted pickup fulfillment
        /// will automatically move to the `COMPLETED` state. Must be in RFC3339
        /// duration format e.g., "P1W3D".
        /// If not set, this pickup fulfillment will remain accepted until it is canceled or completed.
        /// </summary>
        [JsonProperty("auto_complete_duration")]
        public string AutoCompleteDuration { get; }

        /// <summary>
        /// The schedule type of the pickup fulfillment.
        /// </summary>
        [JsonProperty("schedule_type")]
        public string ScheduleType { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) that represents the start of the pickup window.
        /// Must be in RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// For fulfillments with the schedule type `ASAP`, this is automatically set
        /// to the current time plus the expected duration to prepare the fulfillment.
        /// </summary>
        [JsonProperty("pickup_at")]
        public string PickupAt { get; }

        /// <summary>
        /// The window of time in which the order should be picked up after the `pickup_at` timestamp.
        /// Must be in RFC3339 duration format, e.g., "P1W3D". Can be used as an
        /// informational guideline for merchants.
        /// </summary>
        [JsonProperty("pickup_window_duration")]
        public string PickupWindowDuration { get; }

        /// <summary>
        /// The duration of time it takes to prepare this fulfillment.
        /// Must be in RFC3339 duration format, e.g., "P1W3D".
        /// </summary>
        [JsonProperty("prep_time_duration")]
        public string PrepTimeDuration { get; }

        /// <summary>
        /// A note meant to provide additional instructions about the pickup
        /// fulfillment displayed in the Square Point of Sale and set by the API.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment
        /// was placed. Must be in RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("placed_at")]
        public string PlacedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment
        /// was accepted. In RFC3339 timestamp format,
        /// e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("accepted_at")]
        public string AcceptedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment
        /// was rejected. In RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("rejected_at")]
        public string RejectedAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment is
        /// marked as ready for pickup. In RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("ready_at")]
        public string ReadyAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment expired.
        /// In RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("expired_at")]
        public string ExpiredAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) indicating when the fulfillment
        /// was picked up by the recipient. In RFC3339 timestamp format,
        /// e.g., "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("picked_up_at")]
        public string PickedUpAt { get; }

        /// <summary>
        /// The [timestamp](#workingwithdates) in RFC3339 timestamp format, e.g., "2016-09-04T23:59:33.123Z",
        /// indicating when the fulfillment was canceled.
        /// </summary>
        [JsonProperty("canceled_at")]
        public string CanceledAt { get; }

        /// <summary>
        /// A description of why the pickup was canceled. Max length: 100 characters.
        /// </summary>
        [JsonProperty("cancel_reason")]
        public string CancelReason { get; }

        /// <summary>
        /// If true, indicates this pickup order is for curbside pickup, not in-store pickup.
        /// </summary>
        [JsonProperty("is_curbside_pickup")]
        public bool? IsCurbsidePickup { get; }

        /// <summary>
        /// Specific details for curbside pickup.
        /// </summary>
        [JsonProperty("curbside_pickup_details")]
        public Models.OrderFulfillmentPickupDetailsCurbsidePickupDetails CurbsidePickupDetails { get; }

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

            public Builder() { }
            public Builder Recipient(Models.OrderFulfillmentRecipient value)
            {
                recipient = value;
                return this;
            }

            public Builder ExpiresAt(string value)
            {
                expiresAt = value;
                return this;
            }

            public Builder AutoCompleteDuration(string value)
            {
                autoCompleteDuration = value;
                return this;
            }

            public Builder ScheduleType(string value)
            {
                scheduleType = value;
                return this;
            }

            public Builder PickupAt(string value)
            {
                pickupAt = value;
                return this;
            }

            public Builder PickupWindowDuration(string value)
            {
                pickupWindowDuration = value;
                return this;
            }

            public Builder PrepTimeDuration(string value)
            {
                prepTimeDuration = value;
                return this;
            }

            public Builder Note(string value)
            {
                note = value;
                return this;
            }

            public Builder PlacedAt(string value)
            {
                placedAt = value;
                return this;
            }

            public Builder AcceptedAt(string value)
            {
                acceptedAt = value;
                return this;
            }

            public Builder RejectedAt(string value)
            {
                rejectedAt = value;
                return this;
            }

            public Builder ReadyAt(string value)
            {
                readyAt = value;
                return this;
            }

            public Builder ExpiredAt(string value)
            {
                expiredAt = value;
                return this;
            }

            public Builder PickedUpAt(string value)
            {
                pickedUpAt = value;
                return this;
            }

            public Builder CanceledAt(string value)
            {
                canceledAt = value;
                return this;
            }

            public Builder CancelReason(string value)
            {
                cancelReason = value;
                return this;
            }

            public Builder IsCurbsidePickup(bool? value)
            {
                isCurbsidePickup = value;
                return this;
            }

            public Builder CurbsidePickupDetails(Models.OrderFulfillmentPickupDetailsCurbsidePickupDetails value)
            {
                curbsidePickupDetails = value;
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