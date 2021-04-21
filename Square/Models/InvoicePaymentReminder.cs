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
    /// InvoicePaymentReminder.
    /// </summary>
    public class InvoicePaymentReminder
    {
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
            this.Uid = uid;
            this.RelativeScheduledDays = relativeScheduledDays;
            this.Message = message;
            this.Status = status;
            this.SentAt = sentAt;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoicePaymentReminder : ({string.Join(", ", toStringOutput)})";
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

            return obj is InvoicePaymentReminder other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.RelativeScheduledDays == null && other.RelativeScheduledDays == null) || (this.RelativeScheduledDays?.Equals(other.RelativeScheduledDays) == true)) &&
                ((this.Message == null && other.Message == null) || (this.Message?.Equals(other.Message) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.SentAt == null && other.SentAt == null) || (this.SentAt?.Equals(other.SentAt) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1406942862;

            if (this.Uid != null)
            {
               hashCode += this.Uid.GetHashCode();
            }

            if (this.RelativeScheduledDays != null)
            {
               hashCode += this.RelativeScheduledDays.GetHashCode();
            }

            if (this.Message != null)
            {
               hashCode += this.Message.GetHashCode();
            }

            if (this.Status != null)
            {
               hashCode += this.Status.GetHashCode();
            }

            if (this.SentAt != null)
            {
               hashCode += this.SentAt.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid == string.Empty ? "" : this.Uid)}");
            toStringOutput.Add($"this.RelativeScheduledDays = {(this.RelativeScheduledDays == null ? "null" : this.RelativeScheduledDays.ToString())}");
            toStringOutput.Add($"this.Message = {(this.Message == null ? "null" : this.Message == string.Empty ? "" : this.Message)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.SentAt = {(this.SentAt == null ? "null" : this.SentAt == string.Empty ? "" : this.SentAt)}");
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
            /// Builds class object.
            /// </summary>
            /// <returns> InvoicePaymentReminder. </returns>
            public InvoicePaymentReminder Build()
            {
                return new InvoicePaymentReminder(
                    this.uid,
                    this.relativeScheduledDays,
                    this.message,
                    this.status,
                    this.sentAt);
            }
        }
    }
}