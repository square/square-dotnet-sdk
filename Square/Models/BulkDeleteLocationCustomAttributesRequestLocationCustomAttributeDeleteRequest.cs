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
    /// BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest.
    /// </summary>
    public class BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        public BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest(
            string key = null)
        {
            this.Key = key;
        }

        /// <summary>
        /// The key of the associated custom attribute definition.
        /// Represented as a qualified key if the requesting app is not the definition owner.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest other &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 180095729;
            hashCode = HashCode.Combine(this.Key);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Key(this.Key);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string key;

             /// <summary>
             /// Key.
             /// </summary>
             /// <param name="key"> key. </param>
             /// <returns> Builder. </returns>
            public Builder Key(string key)
            {
                this.key = key;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest. </returns>
            public BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest Build()
            {
                return new BulkDeleteLocationCustomAttributesRequestLocationCustomAttributeDeleteRequest(
                    this.key);
            }
        }
    }
}