namespace Square.Models
{
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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// ListWebhookEventTypesResponse.
    /// </summary>
    public class ListWebhookEventTypesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListWebhookEventTypesResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="eventTypes">event_types.</param>
        /// <param name="metadata">metadata.</param>
        public ListWebhookEventTypesResponse(
            IList<Models.Error> errors = null,
            IList<string> eventTypes = null,
            IList<Models.EventTypeMetadata> metadata = null)
        {
            this.Errors = errors;
            this.EventTypes = eventTypes;
            this.Metadata = metadata;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information on errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The list of event types.
        /// </summary>
        [JsonProperty("event_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> EventTypes { get; }

        /// <summary>
        /// Contains the metadata of a webhook event type. For more information, see [EventTypeMetadata](entity:EventTypeMetadata).
        /// </summary>
        [JsonProperty("metadata", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.EventTypeMetadata> Metadata { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListWebhookEventTypesResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListWebhookEventTypesResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.EventTypes == null && other.EventTypes == null) || (this.EventTypes?.Equals(other.EventTypes) == true)) &&
                ((this.Metadata == null && other.Metadata == null) || (this.Metadata?.Equals(other.Metadata) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1808511148;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.EventTypes, this.Metadata);

            return hashCode;
        }
        internal ListWebhookEventTypesResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.EventTypes = {(this.EventTypes == null ? "null" : $"[{string.Join(", ", this.EventTypes)} ]")}");
            toStringOutput.Add($"this.Metadata = {(this.Metadata == null ? "null" : $"[{string.Join(", ", this.Metadata)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .EventTypes(this.EventTypes)
                .Metadata(this.Metadata);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<string> eventTypes;
            private IList<Models.EventTypeMetadata> metadata;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// EventTypes.
             /// </summary>
             /// <param name="eventTypes"> eventTypes. </param>
             /// <returns> Builder. </returns>
            public Builder EventTypes(IList<string> eventTypes)
            {
                this.eventTypes = eventTypes;
                return this;
            }

             /// <summary>
             /// Metadata.
             /// </summary>
             /// <param name="metadata"> metadata. </param>
             /// <returns> Builder. </returns>
            public Builder Metadata(IList<Models.EventTypeMetadata> metadata)
            {
                this.metadata = metadata;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListWebhookEventTypesResponse. </returns>
            public ListWebhookEventTypesResponse Build()
            {
                return new ListWebhookEventTypesResponse(
                    this.errors,
                    this.eventTypes,
                    this.metadata);
            }
        }
    }
}