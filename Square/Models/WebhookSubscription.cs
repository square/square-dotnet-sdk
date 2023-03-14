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
    /// WebhookSubscription.
    /// </summary>
    public class WebhookSubscription
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookSubscription"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        /// <param name="enabled">enabled.</param>
        /// <param name="eventTypes">event_types.</param>
        /// <param name="notificationUrl">notification_url.</param>
        /// <param name="apiVersion">api_version.</param>
        /// <param name="signatureKey">signature_key.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public WebhookSubscription(
            string id = null,
            string name = null,
            bool? enabled = null,
            IList<string> eventTypes = null,
            string notificationUrl = null,
            string apiVersion = null,
            string signatureKey = null,
            string createdAt = null,
            string updatedAt = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "enabled", false },
                { "event_types", false },
                { "notification_url", false },
                { "api_version", false }
            };

            this.Id = id;
            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (enabled != null)
            {
                shouldSerialize["enabled"] = true;
                this.Enabled = enabled;
            }

            if (eventTypes != null)
            {
                shouldSerialize["event_types"] = true;
                this.EventTypes = eventTypes;
            }

            if (notificationUrl != null)
            {
                shouldSerialize["notification_url"] = true;
                this.NotificationUrl = notificationUrl;
            }

            if (apiVersion != null)
            {
                shouldSerialize["api_version"] = true;
                this.ApiVersion = apiVersion;
            }

            this.SignatureKey = signatureKey;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }
        internal WebhookSubscription(Dictionary<string, bool> shouldSerialize,
            string id = null,
            string name = null,
            bool? enabled = null,
            IList<string> eventTypes = null,
            string notificationUrl = null,
            string apiVersion = null,
            string signatureKey = null,
            string createdAt = null,
            string updatedAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Name = name;
            Enabled = enabled;
            EventTypes = eventTypes;
            NotificationUrl = notificationUrl;
            ApiVersion = apiVersion;
            SignatureKey = signatureKey;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// A Square-generated unique ID for the subscription.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The name of this subscription.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Indicates whether the subscription is enabled (`true`) or not (`false`).
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; }

        /// <summary>
        /// The event types associated with this subscription.
        /// </summary>
        [JsonProperty("event_types")]
        public IList<string> EventTypes { get; }

        /// <summary>
        /// The URL to which webhooks are sent.
        /// </summary>
        [JsonProperty("notification_url")]
        public string NotificationUrl { get; }

        /// <summary>
        /// The API version of the subscription.
        /// This field is optional for `CreateWebhookSubscription`.
        /// The value defaults to the API version used by the application.
        /// </summary>
        [JsonProperty("api_version")]
        public string ApiVersion { get; }

        /// <summary>
        /// The Square-generated signature key used to validate the origin of the webhook event.
        /// </summary>
        [JsonProperty("signature_key", NullValueHandling = NullValueHandling.Ignore)]
        public string SignatureKey { get; }

        /// <summary>
        /// The timestamp of when the subscription was created, in RFC 3339 format. For example, "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp of when the subscription was last updated, in RFC 3339 format.
        /// For example, "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"WebhookSubscription : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEnabled()
        {
            return this.shouldSerialize["enabled"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEventTypes()
        {
            return this.shouldSerialize["event_types"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNotificationUrl()
        {
            return this.shouldSerialize["notification_url"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApiVersion()
        {
            return this.shouldSerialize["api_version"];
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

            return obj is WebhookSubscription other &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Enabled == null && other.Enabled == null) || (this.Enabled?.Equals(other.Enabled) == true)) &&
                ((this.EventTypes == null && other.EventTypes == null) || (this.EventTypes?.Equals(other.EventTypes) == true)) &&
                ((this.NotificationUrl == null && other.NotificationUrl == null) || (this.NotificationUrl?.Equals(other.NotificationUrl) == true)) &&
                ((this.ApiVersion == null && other.ApiVersion == null) || (this.ApiVersion?.Equals(other.ApiVersion) == true)) &&
                ((this.SignatureKey == null && other.SignatureKey == null) || (this.SignatureKey?.Equals(other.SignatureKey) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -314056080;
            hashCode = HashCode.Combine(this.Id, this.Name, this.Enabled, this.EventTypes, this.NotificationUrl, this.ApiVersion, this.SignatureKey);

            hashCode = HashCode.Combine(hashCode, this.CreatedAt, this.UpdatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Enabled = {(this.Enabled == null ? "null" : this.Enabled.ToString())}");
            toStringOutput.Add($"this.EventTypes = {(this.EventTypes == null ? "null" : $"[{string.Join(", ", this.EventTypes)} ]")}");
            toStringOutput.Add($"this.NotificationUrl = {(this.NotificationUrl == null ? "null" : this.NotificationUrl == string.Empty ? "" : this.NotificationUrl)}");
            toStringOutput.Add($"this.ApiVersion = {(this.ApiVersion == null ? "null" : this.ApiVersion == string.Empty ? "" : this.ApiVersion)}");
            toStringOutput.Add($"this.SignatureKey = {(this.SignatureKey == null ? "null" : this.SignatureKey == string.Empty ? "" : this.SignatureKey)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt == string.Empty ? "" : this.UpdatedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .Name(this.Name)
                .Enabled(this.Enabled)
                .EventTypes(this.EventTypes)
                .NotificationUrl(this.NotificationUrl)
                .ApiVersion(this.ApiVersion)
                .SignatureKey(this.SignatureKey)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
                { "enabled", false },
                { "event_types", false },
                { "notification_url", false },
                { "api_version", false },
            };

            private string id;
            private string name;
            private bool? enabled;
            private IList<string> eventTypes;
            private string notificationUrl;
            private string apiVersion;
            private string signatureKey;
            private string createdAt;
            private string updatedAt;

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

             /// <summary>
             /// Enabled.
             /// </summary>
             /// <param name="enabled"> enabled. </param>
             /// <returns> Builder. </returns>
            public Builder Enabled(bool? enabled)
            {
                shouldSerialize["enabled"] = true;
                this.enabled = enabled;
                return this;
            }

             /// <summary>
             /// EventTypes.
             /// </summary>
             /// <param name="eventTypes"> eventTypes. </param>
             /// <returns> Builder. </returns>
            public Builder EventTypes(IList<string> eventTypes)
            {
                shouldSerialize["event_types"] = true;
                this.eventTypes = eventTypes;
                return this;
            }

             /// <summary>
             /// NotificationUrl.
             /// </summary>
             /// <param name="notificationUrl"> notificationUrl. </param>
             /// <returns> Builder. </returns>
            public Builder NotificationUrl(string notificationUrl)
            {
                shouldSerialize["notification_url"] = true;
                this.notificationUrl = notificationUrl;
                return this;
            }

             /// <summary>
             /// ApiVersion.
             /// </summary>
             /// <param name="apiVersion"> apiVersion. </param>
             /// <returns> Builder. </returns>
            public Builder ApiVersion(string apiVersion)
            {
                shouldSerialize["api_version"] = true;
                this.apiVersion = apiVersion;
                return this;
            }

             /// <summary>
             /// SignatureKey.
             /// </summary>
             /// <param name="signatureKey"> signatureKey. </param>
             /// <returns> Builder. </returns>
            public Builder SignatureKey(string signatureKey)
            {
                this.signatureKey = signatureKey;
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
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEnabled()
            {
                this.shouldSerialize["enabled"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEventTypes()
            {
                this.shouldSerialize["event_types"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetNotificationUrl()
            {
                this.shouldSerialize["notification_url"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetApiVersion()
            {
                this.shouldSerialize["api_version"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> WebhookSubscription. </returns>
            public WebhookSubscription Build()
            {
                return new WebhookSubscription(shouldSerialize,
                    this.id,
                    this.name,
                    this.enabled,
                    this.eventTypes,
                    this.notificationUrl,
                    this.apiVersion,
                    this.signatureKey,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}