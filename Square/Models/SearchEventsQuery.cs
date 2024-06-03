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
    /// SearchEventsQuery.
    /// </summary>
    public class SearchEventsQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchEventsQuery"/> class.
        /// </summary>
        /// <param name="filter">filter.</param>
        /// <param name="sort">sort.</param>
        public SearchEventsQuery(
            Models.SearchEventsFilter filter = null,
            Models.SearchEventsSort sort = null)
        {
            this.Filter = filter;
            this.Sort = sort;
        }

        /// <summary>
        /// Criteria to filter events by.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchEventsFilter Filter { get; }

        /// <summary>
        /// Criteria to sort events by.
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchEventsSort Sort { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchEventsQuery : ({string.Join(", ", toStringOutput)})";
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
            return obj is SearchEventsQuery other &&                ((this.Filter == null && other.Filter == null) || (this.Filter?.Equals(other.Filter) == true)) &&
                ((this.Sort == null && other.Sort == null) || (this.Sort?.Equals(other.Sort) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 867676747;
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
            private Models.SearchEventsFilter filter;
            private Models.SearchEventsSort sort;

             /// <summary>
             /// Filter.
             /// </summary>
             /// <param name="filter"> filter. </param>
             /// <returns> Builder. </returns>
            public Builder Filter(Models.SearchEventsFilter filter)
            {
                this.filter = filter;
                return this;
            }

             /// <summary>
             /// Sort.
             /// </summary>
             /// <param name="sort"> sort. </param>
             /// <returns> Builder. </returns>
            public Builder Sort(Models.SearchEventsSort sort)
            {
                this.sort = sort;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchEventsQuery. </returns>
            public SearchEventsQuery Build()
            {
                return new SearchEventsQuery(
                    this.filter,
                    this.sort);
            }
        }
    }
}