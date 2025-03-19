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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// SubscriptionTestResult.
    /// </summary>
    public class SubscriptionTestResult
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionTestResult"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="statusCode">status_code.</param>
        /// <param name="payload">payload.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public SubscriptionTestResult(
            string id = null,
            int? statusCode = null,
            string payload = null,
            string createdAt = null,
            string updatedAt = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "status_code", false },
                { "payload", false },
            };
            this.Id = id;

            if (statusCode != null)
            {
                shouldSerialize["status_code"] = true;
                this.StatusCode = statusCode;
            }

            if (payload != null)
            {
                shouldSerialize["payload"] = true;
                this.Payload = payload;
            }
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        internal SubscriptionTestResult(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            int? statusCode = null,
            string payload = null,
            string createdAt = null,
            string updatedAt = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            StatusCode = statusCode;
            Payload = payload;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// A Square-generated unique ID for the subscription test result.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The status code returned by the subscription notification URL.
        /// </summary>
        [JsonProperty("status_code")]
        public int? StatusCode { get; }

        /// <summary>
        /// An object containing the payload of the test event. For example, a `payment.created` event.
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; }

        /// <summary>
        /// The timestamp of when the subscription was created, in RFC 3339 format.
        /// For example, "2016-09-04T23:59:33.123Z".
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp of when the subscription was updated, in RFC 3339 format. For example, "2016-09-04T23:59:33.123Z".
        /// Because a subscription test result is unique, this field is the same as the `created_at` field.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SubscriptionTestResult : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatusCode()
        {
            return this.shouldSerialize["status_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePayload()
        {
            return this.shouldSerialize["payload"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SubscriptionTestResult other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.StatusCode == null && other.StatusCode == null
                    || this.StatusCode?.Equals(other.StatusCode) == true
                )
                && (
                    this.Payload == null && other.Payload == null
                    || this.Payload?.Equals(other.Payload) == true
                )
                && (
                    this.CreatedAt == null && other.CreatedAt == null
                    || this.CreatedAt?.Equals(other.CreatedAt) == true
                )
                && (
                    this.UpdatedAt == null && other.UpdatedAt == null
                    || this.UpdatedAt?.Equals(other.UpdatedAt) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 675695494;
            hashCode = HashCode.Combine(
                hashCode,
                this.Id,
                this.StatusCode,
                this.Payload,
                this.CreatedAt,
                this.UpdatedAt
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add(
                $"this.StatusCode = {(this.StatusCode == null ? "null" : this.StatusCode.ToString())}"
            );
            toStringOutput.Add($"this.Payload = {this.Payload ?? "null"}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(this.Id)
                .StatusCode(this.StatusCode)
                .Payload(this.Payload)
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
                { "status_code", false },
                { "payload", false },
            };

            private string id;
            private int? statusCode;
            private string payload;
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
            /// StatusCode.
            /// </summary>
            /// <param name="statusCode"> statusCode. </param>
            /// <returns> Builder. </returns>
            public Builder StatusCode(int? statusCode)
            {
                shouldSerialize["status_code"] = true;
                this.statusCode = statusCode;
                return this;
            }

            /// <summary>
            /// Payload.
            /// </summary>
            /// <param name="payload"> payload. </param>
            /// <returns> Builder. </returns>
            public Builder Payload(string payload)
            {
                shouldSerialize["payload"] = true;
                this.payload = payload;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetStatusCode()
            {
                this.shouldSerialize["status_code"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetPayload()
            {
                this.shouldSerialize["payload"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SubscriptionTestResult. </returns>
            public SubscriptionTestResult Build()
            {
                return new SubscriptionTestResult(
                    shouldSerialize,
                    this.id,
                    this.statusCode,
                    this.payload,
                    this.createdAt,
                    this.updatedAt
                );
            }
        }
    }
}
