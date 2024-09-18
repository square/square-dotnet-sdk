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
    /// EventMetadata.
    /// </summary>
    public class EventMetadata
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="EventMetadata"/> class.
        /// </summary>
        /// <param name="eventId">event_id.</param>
        /// <param name="apiVersion">api_version.</param>
        public EventMetadata(
            string eventId = null,
            string apiVersion = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "event_id", false },
                { "api_version", false }
            };

            if (eventId != null)
            {
                shouldSerialize["event_id"] = true;
                this.EventId = eventId;
            }

            if (apiVersion != null)
            {
                shouldSerialize["api_version"] = true;
                this.ApiVersion = apiVersion;
            }

        }
        internal EventMetadata(Dictionary<string, bool> shouldSerialize,
            string eventId = null,
            string apiVersion = null)
        {
            this.shouldSerialize = shouldSerialize;
            EventId = eventId;
            ApiVersion = apiVersion;
        }

        /// <summary>
        /// A unique ID for the event.
        /// </summary>
        [JsonProperty("event_id")]
        public string EventId { get; }

        /// <summary>
        /// The API version of the event. This corresponds to the default API version of the developer application at the time when the event was created.
        /// </summary>
        [JsonProperty("api_version")]
        public string ApiVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"EventMetadata : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEventId()
        {
            return this.shouldSerialize["event_id"];
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
            return obj is EventMetadata other &&                ((this.EventId == null && other.EventId == null) || (this.EventId?.Equals(other.EventId) == true)) &&
                ((this.ApiVersion == null && other.ApiVersion == null) || (this.ApiVersion?.Equals(other.ApiVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 930343962;
            hashCode = HashCode.Combine(this.EventId, this.ApiVersion);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EventId = {(this.EventId == null ? "null" : this.EventId)}");
            toStringOutput.Add($"this.ApiVersion = {(this.ApiVersion == null ? "null" : this.ApiVersion)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EventId(this.EventId)
                .ApiVersion(this.ApiVersion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "event_id", false },
                { "api_version", false },
            };

            private string eventId;
            private string apiVersion;

             /// <summary>
             /// EventId.
             /// </summary>
             /// <param name="eventId"> eventId. </param>
             /// <returns> Builder. </returns>
            public Builder EventId(string eventId)
            {
                shouldSerialize["event_id"] = true;
                this.eventId = eventId;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEventId()
            {
                this.shouldSerialize["event_id"] = false;
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
            /// <returns> EventMetadata. </returns>
            public EventMetadata Build()
            {
                return new EventMetadata(shouldSerialize,
                    this.eventId,
                    this.apiVersion);
            }
        }
    }
}