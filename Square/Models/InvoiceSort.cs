
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class InvoiceSort 
    {
        public InvoiceSort(string field,
            string order = null)
        {
            Field = field;
            Order = order;
        }

        /// <summary>
        /// Field to use for sorting.
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public string Order { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"InvoiceSort : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Field = {(Field == null ? "null" : Field == string.Empty ? "" : Field)}");
            toStringOutput.Add($"Order = {(Order == null ? "null" : Order.ToString())}");
        }

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

            return obj is InvoiceSort other &&
                ((Field == null && other.Field == null) || (Field?.Equals(other.Field) == true)) &&
                ((Order == null && other.Order == null) || (Order?.Equals(other.Order) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1234776643;

            if (Field != null)
            {
               hashCode += Field.GetHashCode();
            }

            if (Order != null)
            {
               hashCode += Order.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Field)
                .Order(Order);
            return builder;
        }

        public class Builder
        {
            private string field;
            private string order;

            public Builder(string field)
            {
                this.field = field;
            }

            public Builder Field(string field)
            {
                this.field = field;
                return this;
            }

            public Builder Order(string order)
            {
                this.order = order;
                return this;
            }

            public InvoiceSort Build()
            {
                return new InvoiceSort(field,
                    order);
            }
        }
    }
}