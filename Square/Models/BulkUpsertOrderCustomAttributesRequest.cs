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
    using Square.Utilities;

    /// <summary>
    /// BulkUpsertOrderCustomAttributesRequest.
    /// </summary>
    public class BulkUpsertOrderCustomAttributesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkUpsertOrderCustomAttributesRequest"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        public BulkUpsertOrderCustomAttributesRequest(
            IDictionary<string, Models.BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute> values)
        {
            this.Values = values;
        }

        /// <summary>
        /// A map of requests that correspond to individual upsert operations for custom attributes.
        /// </summary>
        [JsonProperty("values")]
        public IDictionary<string, Models.BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute> Values { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkUpsertOrderCustomAttributesRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is BulkUpsertOrderCustomAttributesRequest other &&                ((this.Values == null && other.Values == null) || (this.Values?.Equals(other.Values) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1862431858;
            hashCode = HashCode.Combine(this.Values);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Values = {(this.Values == null ? "null" : this.Values.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Values);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<string, Models.BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute> values;

            /// <summary>
            /// Initialize Builder for BulkUpsertOrderCustomAttributesRequest.
            /// </summary>
            /// <param name="values"> values. </param>
            public Builder(
                IDictionary<string, Models.BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute> values)
            {
                this.values = values;
            }

             /// <summary>
             /// Values.
             /// </summary>
             /// <param name="values"> values. </param>
             /// <returns> Builder. </returns>
            public Builder Values(IDictionary<string, Models.BulkUpsertOrderCustomAttributesRequestUpsertCustomAttribute> values)
            {
                this.values = values;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkUpsertOrderCustomAttributesRequest. </returns>
            public BulkUpsertOrderCustomAttributesRequest Build()
            {
                return new BulkUpsertOrderCustomAttributesRequest(
                    this.values);
            }
        }
    }
}