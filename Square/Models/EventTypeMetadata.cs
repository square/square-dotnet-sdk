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
    /// EventTypeMetadata.
    /// </summary>
    public class EventTypeMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeMetadata"/> class.
        /// </summary>
        /// <param name="eventType">event_type.</param>
        /// <param name="apiVersionIntroduced">api_version_introduced.</param>
        /// <param name="releaseStatus">release_status.</param>
        public EventTypeMetadata(
            string eventType = null,
            string apiVersionIntroduced = null,
            string releaseStatus = null)
        {
            this.EventType = eventType;
            this.ApiVersionIntroduced = apiVersionIntroduced;
            this.ReleaseStatus = releaseStatus;
        }

        /// <summary>
        /// The event type.
        /// </summary>
        [JsonProperty("event_type", NullValueHandling = NullValueHandling.Ignore)]
        public string EventType { get; }

        /// <summary>
        /// The API version at which the event type was introduced.
        /// </summary>
        [JsonProperty("api_version_introduced", NullValueHandling = NullValueHandling.Ignore)]
        public string ApiVersionIntroduced { get; }

        /// <summary>
        /// The release status of the event type.
        /// </summary>
        [JsonProperty("release_status", NullValueHandling = NullValueHandling.Ignore)]
        public string ReleaseStatus { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"EventTypeMetadata : ({string.Join(", ", toStringOutput)})";
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

            return obj is EventTypeMetadata other &&
                ((this.EventType == null && other.EventType == null) || (this.EventType?.Equals(other.EventType) == true)) &&
                ((this.ApiVersionIntroduced == null && other.ApiVersionIntroduced == null) || (this.ApiVersionIntroduced?.Equals(other.ApiVersionIntroduced) == true)) &&
                ((this.ReleaseStatus == null && other.ReleaseStatus == null) || (this.ReleaseStatus?.Equals(other.ReleaseStatus) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 863420362;
            hashCode = HashCode.Combine(this.EventType, this.ApiVersionIntroduced, this.ReleaseStatus);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.EventType = {(this.EventType == null ? "null" : this.EventType == string.Empty ? "" : this.EventType)}");
            toStringOutput.Add($"this.ApiVersionIntroduced = {(this.ApiVersionIntroduced == null ? "null" : this.ApiVersionIntroduced == string.Empty ? "" : this.ApiVersionIntroduced)}");
            toStringOutput.Add($"this.ReleaseStatus = {(this.ReleaseStatus == null ? "null" : this.ReleaseStatus == string.Empty ? "" : this.ReleaseStatus)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .EventType(this.EventType)
                .ApiVersionIntroduced(this.ApiVersionIntroduced)
                .ReleaseStatus(this.ReleaseStatus);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string eventType;
            private string apiVersionIntroduced;
            private string releaseStatus;

             /// <summary>
             /// EventType.
             /// </summary>
             /// <param name="eventType"> eventType. </param>
             /// <returns> Builder. </returns>
            public Builder EventType(string eventType)
            {
                this.eventType = eventType;
                return this;
            }

             /// <summary>
             /// ApiVersionIntroduced.
             /// </summary>
             /// <param name="apiVersionIntroduced"> apiVersionIntroduced. </param>
             /// <returns> Builder. </returns>
            public Builder ApiVersionIntroduced(string apiVersionIntroduced)
            {
                this.apiVersionIntroduced = apiVersionIntroduced;
                return this;
            }

             /// <summary>
             /// ReleaseStatus.
             /// </summary>
             /// <param name="releaseStatus"> releaseStatus. </param>
             /// <returns> Builder. </returns>
            public Builder ReleaseStatus(string releaseStatus)
            {
                this.releaseStatus = releaseStatus;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> EventTypeMetadata. </returns>
            public EventTypeMetadata Build()
            {
                return new EventTypeMetadata(
                    this.eventType,
                    this.apiVersionIntroduced,
                    this.releaseStatus);
            }
        }
    }
}