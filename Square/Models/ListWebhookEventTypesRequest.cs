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
    /// ListWebhookEventTypesRequest.
    /// </summary>
    public class ListWebhookEventTypesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListWebhookEventTypesRequest"/> class.
        /// </summary>
        /// <param name="apiVersion">api_version.</param>
        public ListWebhookEventTypesRequest(
            string apiVersion = null)
        {
            this.ApiVersion = apiVersion;
        }

        /// <summary>
        /// The API version for which to list event types. Setting this field overrides the default version used by the application.
        /// </summary>
        [JsonProperty("api_version", NullValueHandling = NullValueHandling.Ignore)]
        public string ApiVersion { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListWebhookEventTypesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListWebhookEventTypesRequest other &&
                ((this.ApiVersion == null && other.ApiVersion == null) || (this.ApiVersion?.Equals(other.ApiVersion) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1106875761;
            hashCode = HashCode.Combine(this.ApiVersion);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.ApiVersion = {(this.ApiVersion == null ? "null" : this.ApiVersion == string.Empty ? "" : this.ApiVersion)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .ApiVersion(this.ApiVersion);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string apiVersion;

             /// <summary>
             /// ApiVersion.
             /// </summary>
             /// <param name="apiVersion"> apiVersion. </param>
             /// <returns> Builder. </returns>
            public Builder ApiVersion(string apiVersion)
            {
                this.apiVersion = apiVersion;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListWebhookEventTypesRequest. </returns>
            public ListWebhookEventTypesRequest Build()
            {
                return new ListWebhookEventTypesRequest(
                    this.apiVersion);
            }
        }
    }
}