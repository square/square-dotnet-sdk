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
    /// SearchOrdersSort.
    /// </summary>
    public class SearchOrdersSort
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersSort"/> class.
        /// </summary>
        /// <param name="sortField">sort_field.</param>
        /// <param name="sortOrder">sort_order.</param>
        public SearchOrdersSort(
            string sortField,
            string sortOrder = null)
        {
            this.SortField = sortField;
            this.SortOrder = sortOrder;
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersSort : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchOrdersSort other &&
                ((this.SortField == null && other.SortField == null) || (this.SortField?.Equals(other.SortField) == true)) &&
                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 962710037;

            if (this.SortField != null)
            {
               hashCode += this.SortField.GetHashCode();
            }

            if (this.SortOrder != null)
            {
               hashCode += this.SortOrder.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.SortField = {(this.SortField == null ? "null" : this.SortField.ToString())}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.SortField)
                .SortOrder(this.SortOrder);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string sortField;
            private string sortOrder;

            public Builder(
                string sortField)
            {
                this.sortField = sortField;
            }

             /// <summary>
             /// SortField.
             /// </summary>
             /// <param name="sortField"> sortField. </param>
             /// <returns> Builder. </returns>
            public Builder SortField(string sortField)
            {
                this.sortField = sortField;
                return this;
            }

             /// <summary>
             /// SortOrder.
             /// </summary>
             /// <param name="sortOrder"> sortOrder. </param>
             /// <returns> Builder. </returns>
            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchOrdersSort. </returns>
            public SearchOrdersSort Build()
            {
                return new SearchOrdersSort(
                    this.sortField,
                    this.sortOrder);
            }
        }
    }
}