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
    /// SearchSubscriptionsQuery.
    /// </summary>
    public class SearchSubscriptionsQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchSubscriptionsQuery"/> class.
        /// </summary>
        /// <param name="filter">filter.</param>
        public SearchSubscriptionsQuery(Models.SearchSubscriptionsFilter filter = null)
        {
            this.Filter = filter;
        }

        /// <summary>
        /// Represents a set of query expressions (filters) to narrow the scope of targeted subscriptions returned by
        /// the [SearchSubscriptions]($e/Subscriptions/SearchSubscriptions) endpoint.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchSubscriptionsFilter Filter { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchSubscriptionsQuery : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SearchSubscriptionsQuery other
                && (
                    this.Filter == null && other.Filter == null
                    || this.Filter?.Equals(other.Filter) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1048089078;
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
            var builder = new Builder().Filter(this.Filter);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.SearchSubscriptionsFilter filter;

            /// <summary>
            /// Filter.
            /// </summary>
            /// <param name="filter"> filter. </param>
            /// <returns> Builder. </returns>
            public Builder Filter(Models.SearchSubscriptionsFilter filter)
            {
                this.filter = filter;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchSubscriptionsQuery. </returns>
            public SearchSubscriptionsQuery Build()
            {
                return new SearchSubscriptionsQuery(this.filter);
            }
        }
    }
}
