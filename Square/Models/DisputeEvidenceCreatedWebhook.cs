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
    /// DisputeEvidenceCreatedWebhook.
    /// </summary>
    public class DisputeEvidenceCreatedWebhook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisputeEvidenceCreatedWebhook"/> class.
        /// </summary>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="type">type.</param>
        /// <param name="eventId">event_id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="data">data.</param>
        public DisputeEvidenceCreatedWebhook(
            string merchantId = null,
            string locationId = null,
            string type = null,
            string eventId = null,
            string createdAt = null,
            Models.DisputeEvidenceCreatedWebhookData data = null)
        {
            this.MerchantId = merchantId;
            this.LocationId = locationId;
            this.Type = type;
            this.EventId = eventId;
            this.CreatedAt = createdAt;
            this.Data = data;
        }

        /// <summary>
        /// The ID of the target merchant associated with the event.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// The ID of the target location associated with the event.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// The type of event this represents.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// A unique ID for the webhook event.
        /// </summary>
        [JsonProperty("event_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EventId { get; }

        /// <summary>
        /// Timestamp of when the webhook event was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// Gets or sets Data.
        /// </summary>
        [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DisputeEvidenceCreatedWebhookData Data { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DisputeEvidenceCreatedWebhook : ({string.Join(", ", toStringOutput)})";
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

            return obj is DisputeEvidenceCreatedWebhook other &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.EventId == null && other.EventId == null) || (this.EventId?.Equals(other.EventId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.Data == null && other.Data == null) || (this.Data?.Equals(other.Data) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1543364320;

            if (this.MerchantId != null)
            {
               hashCode += this.MerchantId.GetHashCode();
            }

            if (this.LocationId != null)
            {
               hashCode += this.LocationId.GetHashCode();
            }

            if (this.Type != null)
            {
               hashCode += this.Type.GetHashCode();
            }

            if (this.EventId != null)
            {
               hashCode += this.EventId.GetHashCode();
            }

            if (this.CreatedAt != null)
            {
               hashCode += this.CreatedAt.GetHashCode();
            }

            if (this.Data != null)
            {
               hashCode += this.Data.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId == string.Empty ? "" : this.MerchantId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type == string.Empty ? "" : this.Type)}");
            toStringOutput.Add($"this.EventId = {(this.EventId == null ? "null" : this.EventId == string.Empty ? "" : this.EventId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.Data = {(this.Data == null ? "null" : this.Data.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MerchantId(this.MerchantId)
                .LocationId(this.LocationId)
                .Type(this.Type)
                .EventId(this.EventId)
                .CreatedAt(this.CreatedAt)
                .Data(this.Data);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string merchantId;
            private string locationId;
            private string type;
            private string eventId;
            private string createdAt;
            private Models.DisputeEvidenceCreatedWebhookData data;

             /// <summary>
             /// MerchantId.
             /// </summary>
             /// <param name="merchantId"> merchantId. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// EventId.
             /// </summary>
             /// <param name="eventId"> eventId. </param>
             /// <returns> Builder. </returns>
            public Builder EventId(string eventId)
            {
                this.eventId = eventId;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// Data.
             /// </summary>
             /// <param name="data"> data. </param>
             /// <returns> Builder. </returns>
            public Builder Data(Models.DisputeEvidenceCreatedWebhookData data)
            {
                this.data = data;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DisputeEvidenceCreatedWebhook. </returns>
            public DisputeEvidenceCreatedWebhook Build()
            {
                return new DisputeEvidenceCreatedWebhook(
                    this.merchantId,
                    this.locationId,
                    this.type,
                    this.eventId,
                    this.createdAt,
                    this.data);
            }
        }
    }
}