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
    /// BulkDeleteOrderCustomAttributesRequest.
    /// </summary>
    public class BulkDeleteOrderCustomAttributesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteOrderCustomAttributesRequest"/> class.
        /// </summary>
        /// <param name="values">values.</param>
        public BulkDeleteOrderCustomAttributesRequest(
            IDictionary<
                string,
                Models.BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
            > values
        )
        {
            this.Values = values;
        }

        /// <summary>
        /// A map of requests that correspond to individual delete operations for custom attributes.
        /// </summary>
        [JsonProperty("values")]
        public IDictionary<
            string,
            Models.BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
        > Values { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BulkDeleteOrderCustomAttributesRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is BulkDeleteOrderCustomAttributesRequest other
                && (
                    this.Values == null && other.Values == null
                    || this.Values?.Equals(other.Values) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1665927998;
            hashCode = HashCode.Combine(hashCode, this.Values);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"Values = {(this.Values == null ? "null" : this.Values.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Values);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IDictionary<
                string,
                Models.BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
            > values;

            /// <summary>
            /// Initialize Builder for BulkDeleteOrderCustomAttributesRequest.
            /// </summary>
            /// <param name="values"> values. </param>
            public Builder(
                IDictionary<
                    string,
                    Models.BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
                > values
            )
            {
                this.values = values;
            }

            /// <summary>
            /// Values.
            /// </summary>
            /// <param name="values"> values. </param>
            /// <returns> Builder. </returns>
            public Builder Values(
                IDictionary<
                    string,
                    Models.BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
                > values
            )
            {
                this.values = values;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkDeleteOrderCustomAttributesRequest. </returns>
            public BulkDeleteOrderCustomAttributesRequest Build()
            {
                return new BulkDeleteOrderCustomAttributesRequest(this.values);
            }
        }
    }
}
