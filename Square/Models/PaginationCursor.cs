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
    /// PaginationCursor.
    /// </summary>
    public class PaginationCursor
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginationCursor"/> class.
        /// </summary>
        /// <param name="orderValue">order_value.</param>
        public PaginationCursor(
            string orderValue = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "order_value", false }
            };

            if (orderValue != null)
            {
                shouldSerialize["order_value"] = true;
                this.OrderValue = orderValue;
            }
        }

        internal PaginationCursor(
            Dictionary<string, bool> shouldSerialize,
            string orderValue = null)
        {
            this.shouldSerialize = shouldSerialize;
            OrderValue = orderValue;
        }

        /// <summary>
        /// The ID of the last resource in the current page. The page can be in an ascending or
        /// descending order
        /// </summary>
        [JsonProperty("order_value")]
        public string OrderValue { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"PaginationCursor : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOrderValue()
        {
            return this.shouldSerialize["order_value"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is PaginationCursor other &&
                (this.OrderValue == null && other.OrderValue == null ||
                 this.OrderValue?.Equals(other.OrderValue) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1764629089;
            hashCode = HashCode.Combine(hashCode, this.OrderValue);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderValue = {this.OrderValue ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderValue(this.OrderValue);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "order_value", false },
            };

            private string orderValue;

             /// <summary>
             /// OrderValue.
             /// </summary>
             /// <param name="orderValue"> orderValue. </param>
             /// <returns> Builder. </returns>
            public Builder OrderValue(string orderValue)
            {
                shouldSerialize["order_value"] = true;
                this.orderValue = orderValue;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetOrderValue()
            {
                this.shouldSerialize["order_value"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> PaginationCursor. </returns>
            public PaginationCursor Build()
            {
                return new PaginationCursor(
                    shouldSerialize,
                    this.orderValue);
            }
        }
    }
}