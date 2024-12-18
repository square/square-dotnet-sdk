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
    /// InvoiceSort.
    /// </summary>
    public class InvoiceSort
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSort"/> class.
        /// </summary>
        /// <param name="field">field.</param>
        /// <param name="order">order.</param>
        public InvoiceSort(
            string field,
            string order = null)
        {
            this.Field = field;
            this.Order = order;
        }

        /// <summary>
        /// The field to use for sorting.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public string Order { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"InvoiceSort : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is InvoiceSort other &&
                (this.Field == null && other.Field == null ||
                 this.Field?.Equals(other.Field) == true) &&
                (this.Order == null && other.Order == null ||
                 this.Order?.Equals(other.Order) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1234776643;
            hashCode = HashCode.Combine(hashCode, this.Field, this.Order);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Field = {this.Field ?? "null"}");
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Field)
                .Order(this.Order);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string field;
            private string order;

            /// <summary>
            /// Initialize Builder for InvoiceSort.
            /// </summary>
            /// <param name="field"> field. </param>
            public Builder(
                string field)
            {
                this.field = field;
            }

             /// <summary>
             /// Field.
             /// </summary>
             /// <param name="field"> field. </param>
             /// <returns> Builder. </returns>
            public Builder Field(string field)
            {
                this.field = field;
                return this;
            }

             /// <summary>
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(string order)
            {
                this.order = order;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> InvoiceSort. </returns>
            public InvoiceSort Build()
            {
                return new InvoiceSort(
                    this.field,
                    this.order);
            }
        }
    }
}