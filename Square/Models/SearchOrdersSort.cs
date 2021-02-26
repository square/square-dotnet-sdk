
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
    public class SearchOrdersSort 
    {
        public SearchOrdersSort(string sortField,
            string sortOrder = null)
        {
            SortField = sortField;
            SortOrder = sortOrder;
        }

        /// <summary>
        /// Specifies which timestamp to use to sort SearchOrder results.
        /// </summary>
        [JsonProperty("sort_field")]
        public string SortField { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersSort : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"SortField = {(SortField == null ? "null" : SortField.ToString())}");
            toStringOutput.Add($"SortOrder = {(SortOrder == null ? "null" : SortOrder.ToString())}");
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

            return obj is SearchOrdersSort other &&
                ((SortField == null && other.SortField == null) || (SortField?.Equals(other.SortField) == true)) &&
                ((SortOrder == null && other.SortOrder == null) || (SortOrder?.Equals(other.SortOrder) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 962710037;

            if (SortField != null)
            {
               hashCode += SortField.GetHashCode();
            }

            if (SortOrder != null)
            {
               hashCode += SortOrder.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(SortField)
                .SortOrder(SortOrder);
            return builder;
        }

        public class Builder
        {
            private string sortField;
            private string sortOrder;

            public Builder(string sortField)
            {
                this.sortField = sortField;
            }

            public Builder SortField(string sortField)
            {
                this.sortField = sortField;
                return this;
            }

            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            public SearchOrdersSort Build()
            {
                return new SearchOrdersSort(sortField,
                    sortOrder);
            }
        }
    }
}