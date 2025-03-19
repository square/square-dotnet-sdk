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
    /// SearchAvailabilityQuery.
    /// </summary>
    public class SearchAvailabilityQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAvailabilityQuery"/> class.
        /// </summary>
        /// <param name="filter">filter.</param>
        public SearchAvailabilityQuery(Models.SearchAvailabilityFilter filter)
        {
            this.Filter = filter;
        }

        /// <summary>
        /// A query filter to search for buyer-accessible availabilities by.
        /// </summary>
        [JsonProperty("filter")]
        public Models.SearchAvailabilityFilter Filter { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchAvailabilityQuery : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SearchAvailabilityQuery other
                && (
                    this.Filter == null && other.Filter == null
                    || this.Filter?.Equals(other.Filter) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 2004874460;
            hashCode = HashCode.Combine(hashCode, this.Filter);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Filter = {(this.Filter == null ? "null" : this.Filter.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Filter);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.SearchAvailabilityFilter filter;

            /// <summary>
            /// Initialize Builder for SearchAvailabilityQuery.
            /// </summary>
            /// <param name="filter"> filter. </param>
            public Builder(Models.SearchAvailabilityFilter filter)
            {
                this.filter = filter;
            }

            /// <summary>
            /// Filter.
            /// </summary>
            /// <param name="filter"> filter. </param>
            /// <returns> Builder. </returns>
            public Builder Filter(Models.SearchAvailabilityFilter filter)
            {
                this.filter = filter;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchAvailabilityQuery. </returns>
            public SearchAvailabilityQuery Build()
            {
                return new SearchAvailabilityQuery(this.filter);
            }
        }
    }
}
