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
    /// CustomerQuery.
    /// </summary>
    public class CustomerQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerQuery"/> class.
        /// </summary>
        /// <param name="filter">filter.</param>
        /// <param name="sort">sort.</param>
        public CustomerQuery(
            Models.CustomerFilter filter = null,
            Models.CustomerSort sort = null)
        {
            this.Filter = filter;
            this.Sort = sort;
        }

        /// <summary>
        /// Represents the filtering criteria in a [search query]($m/CustomerQuery) that defines how to filter
        /// customer profiles returned in [SearchCustomers]($e/Customers/SearchCustomers) results.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerFilter Filter { get; }

        /// <summary>
        /// Represents the sorting criteria in a [search query]($m/CustomerQuery) that defines how to sort
        /// customer profiles returned in [SearchCustomers]($e/Customers/SearchCustomers) results.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerSort Sort { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerQuery : ({string.Join(", ", toStringOutput)})";
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
            return obj is CustomerQuery other &&                ((this.Filter == null && other.Filter == null) || (this.Filter?.Equals(other.Filter) == true)) &&
                ((this.Sort == null && other.Sort == null) || (this.Sort?.Equals(other.Sort) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1206368426;
            hashCode = HashCode.Combine(this.Filter, this.Sort);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Filter = {(this.Filter == null ? "null" : this.Filter.ToString())}");
            toStringOutput.Add($"this.Sort = {(this.Sort == null ? "null" : this.Sort.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filter(this.Filter)
                .Sort(this.Sort);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CustomerFilter filter;
            private Models.CustomerSort sort;

             /// <summary>
             /// Filter.
             /// </summary>
             /// <param name="filter"> filter. </param>
             /// <returns> Builder. </returns>
            public Builder Filter(Models.CustomerFilter filter)
            {
                this.filter = filter;
                return this;
            }

             /// <summary>
             /// Sort.
             /// </summary>
             /// <param name="sort"> sort. </param>
             /// <returns> Builder. </returns>
            public Builder Sort(Models.CustomerSort sort)
            {
                this.sort = sort;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerQuery. </returns>
            public CustomerQuery Build()
            {
                return new CustomerQuery(
                    this.filter,
                    this.sort);
            }
        }
    }
}