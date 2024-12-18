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

namespace Square.Models
{
    /// <summary>
    /// InvoicePaymentReminder.
    /// </summary>
    public class InvoicePaymentReminder
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicePaymentReminder"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="relativeScheduledDays">relative_scheduled_days.</param>
        /// <param name="message">message.</param>
        /// <param name="status">status.</param>
        /// <param name="sentAt">sent_at.</param>
        public InvoicePaymentReminder(
            string uid = null,
            int? relativeScheduledDays = null,
            string message = null,
            string status = null,
            string sentAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "relative_scheduled_days", false },
                { "message", false }
            };
            this.Uid = uid;

            if (relativeScheduledDays != null)
            {
                shouldSerialize["relative_scheduled_days"] = true;
                this.RelativeScheduledDays = relativeScheduledDays;
            }

            if (message != null)
            {
                shouldSerialize["message"] = true;
                this.Message = message;
            }
            this.Status = status;
            this.SentAt = sentAt;
        }

        internal InvoicePaymentReminder(
            Dictionary<string, bool> shouldSerialize,
            string uid = null,
            int? relativeScheduledDays = null,
            string message = null,
            string status = null,
            string sentAt = null)
        {
            this.shouldSerialize = shouldSerialize;
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
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// If sent, the timestamp when the reminder was sent, in RFC 3339 format.
        /// </summary>
        [JsonProperty("sent_at", NullValueHandling = NullValueHandling.Ignore)]
        public string SentAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"InvoicePaymentReminder : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRelativeScheduledDays()
        {
            return this.shouldSerialize["relative_scheduled_days"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMessage()
        {
            return this.shouldSerialize["message"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is InvoicePaymentReminder other &&
                (this.Uid == null && other.Uid == null ||
                 this.Uid?.Equals(other.Uid) == true) &&
                (this.RelativeScheduledDays == null && other.RelativeScheduledDays == null ||
                 this.RelativeScheduledDays?.Equals(other.RelativeScheduledDays) == true) &&
                (this.Message == null && other.Message == null ||
                 this.Message?.Equals(other.Message) == true) &&
                (this.Status == null && other.Status == null ||
                 this.Status?.Equals(other.Status) == true) &&
                (this.SentAt == null && other.SentAt == null ||
                 this.SentAt?.Equals(other.SentAt) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1406942862;
            hashCode = HashCode.Combine(hashCode, this.Uid, this.RelativeScheduledDays, this.Message, this.Status, this.SentAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add($"this.RelativeScheduledDays = {(this.RelativeScheduledDays == null ? "null" : this.RelativeScheduledDays.ToString())}");
            toStringOutput.Add($"this.Message = {this.Message ?? "null"}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.SentAt = {this.SentAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .RelativeScheduledDays(this.RelativeScheduledDays)
                .Message(this.Message)
                .Status(this.Status)
                .SentAt(this.SentAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "relative_scheduled_days", false },
                { "message", false },
            };

            private string uid;
            private int? relativeScheduledDays;
            private string message;
            private string status;
            private string sentAt;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

             /// <summary>
             /// RelativeScheduledDays.
             /// </summary>
             /// <param name="relativeScheduledDays"> relativeScheduledDays. </param>
             /// <returns> Builder. </returns>
            public Builder RelativeScheduledDays(int? relativeScheduledDays)
            {
                shouldSerialize["relative_scheduled_days"] = true;
                this.relativeScheduledDays = relativeScheduledDays;
                return this;
            }

             /// <summary>
             /// Message.
             /// </summary>
             /// <param name="message"> message. </param>
             /// <returns> Builder. </returns>
            public Builder Message(string message)
            {
                shouldSerialize["message"] = true;
                this.message = message;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// SentAt.
             /// </summary>
             /// <param name="sentAt"> sentAt. </param>
             /// <returns> Builder. </returns>
            public Builder SentAt(string sentAt)
            {
                this.sentAt = sentAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetRelativeScheduledDays()
            {
                this.shouldSerialize["relative_scheduled_days"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetMessage()
            {
                this.shouldSerialize["message"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoicePaymentReminder. </returns>
            public InvoicePaymentReminder Build()
            {
                return new InvoicePaymentReminder(
                    shouldSerialize,
                    this.uid,
                    this.relativeScheduledDays,
                    this.message,
                    this.status,
                    this.sentAt);
            }
        }
    }
}