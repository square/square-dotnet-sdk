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
    public class InvoicePaymentReminder 
    {
        public InvoicePaymentReminder(string uid = null,
            int? relativeScheduledDays = null,
            string message = null,
            string status = null,
            string sentAt = null)
        {
            Uid = uid;
            RelativeScheduledDays = relativeScheduledDays;
            Message = message;
            Status = status;
            SentAt = sentAt;
        }

        /// <summary>
        /// A Square-assigned ID that uniquely identifies the reminder within the
        /// `InvoicePaymentRequest`.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The number of days before (a negative number) or after (a positive number)
        /// the payment request `due_date` when the reminder is sent. For example, -3 indicates that
        /// the reminder should be sent 3 days before the payment request `due_date`.
        /// </summary>
        [JsonProperty("relative_scheduled_days", NullValueHandling = NullValueHandling.Ignore)]
        public int? RelativeScheduledDays { get; }

        /// <summary>
        /// The reminder message.
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        /// <summary>
        /// The status of a payment request reminder.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// If sent, the timestamp when the reminder was sent, in RFC 3339 format.
        /// </summary>
        [JsonProperty("sent_at", NullValueHandling = NullValueHandling.Ignore)]
        public string SentAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .RelativeScheduledDays(RelativeScheduledDays)
                .Message(Message)
                .Status(Status)
                .SentAt(SentAt);
            return builder;
        }

        public class Builder
        {
            private string uid;
            private int? relativeScheduledDays;
            private string message;
            private string status;
            private string sentAt;



            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder RelativeScheduledDays(int? relativeScheduledDays)
            {
                this.relativeScheduledDays = relativeScheduledDays;
                return this;
            }

            public Builder Message(string message)
            {
                this.message = message;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder SentAt(string sentAt)
            {
                this.sentAt = sentAt;
                return this;
            }

            public InvoicePaymentReminder Build()
            {
                return new InvoicePaymentReminder(uid,
                    relativeScheduledDays,
                    message,
                    status,
                    sentAt);
            }
        }
    }
}