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
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The number of days before (a negative number) or after (a positive number)
        /// the payment request `due_date` when the reminder is sent. For example, -3 indicates that
        /// the reminder should be sent 3 days before the payment request `due_date`.
        /// </summary>
        [JsonProperty("relative_scheduled_days")]
        public int? RelativeScheduledDays { get; }

        /// <summary>
        /// The reminder message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; }

        /// <summary>
        /// The status of a payment request reminder.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// If sent, the timestamp when the reminder was sent, in RFC 3339 format.
        /// </summary>
        [JsonProperty("sent_at")]
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

            public Builder() { }
            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public Builder RelativeScheduledDays(int? value)
            {
                relativeScheduledDays = value;
                return this;
            }

            public Builder Message(string value)
            {
                message = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder SentAt(string value)
            {
                sentAt = value;
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