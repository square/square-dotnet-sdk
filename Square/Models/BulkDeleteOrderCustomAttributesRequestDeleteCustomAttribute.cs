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
    /// BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute.
    /// </summary>
    public class BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute"/> class.
        /// </summary>
        /// <param name="orderId">order_id.</param>
        /// <param name="key">key.</param>
        public BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute(
            string orderId,
            string key = null)
        {
            this.Key = key;
            this.OrderId = orderId;
        }

        /// <summary>
        /// The key of the custom attribute to delete.  This key must match the key
        /// of an existing custom attribute definition.
        /// </summary>
        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; }

        /// <summary>
        /// The ID of the target [order]($m/Order).
        /// </summary>
        [JsonProperty("order_id")]
        public string OrderId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute : ({string.Join(", ", toStringOutput)})";
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

            return obj is BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute other &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.OrderId == null && other.OrderId == null) || (this.OrderId?.Equals(other.OrderId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 882766235;
            hashCode = HashCode.Combine(this.Key, this.OrderId);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
            toStringOutput.Add($"this.OrderId = {(this.OrderId == null ? "null" : this.OrderId == string.Empty ? "" : this.OrderId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.OrderId)
                .Key(this.Key);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string orderId;
            private string key;

            public Builder(
                string orderId)
            {
                this.orderId = orderId;
            }

             /// <summary>
             /// OrderId.
             /// </summary>
             /// <param name="orderId"> orderId. </param>
             /// <returns> Builder. </returns>
            public Builder OrderId(string orderId)
            {
                this.orderId = orderId;
                return this;
            }

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
            /// <returns> BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute. </returns>
            public BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute Build()
            {
                return new BulkDeleteOrderCustomAttributesRequestDeleteCustomAttribute(
                    this.orderId,
                    this.key);
            }
        }
    }
}