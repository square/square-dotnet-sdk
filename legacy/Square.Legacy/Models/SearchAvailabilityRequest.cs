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
    /// SearchAvailabilityRequest.
    /// </summary>
    public class SearchAvailabilityRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAvailabilityRequest"/> class.
        /// </summary>
        /// <param name="query">query.</param>
        public SearchAvailabilityRequest(Models.SearchAvailabilityQuery query)
        {
            this.Query = query;
        }

        /// <summary>
        /// The query used to search for buyer-accessible availabilities of bookings.
        /// </summary>
        [JsonProperty("query")]
        public Models.SearchAvailabilityQuery Query { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchAvailabilityRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SearchAvailabilityRequest other
                && (
                    this.Query == null && other.Query == null
                    || this.Query?.Equals(other.Query) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1074083477;
            hashCode = HashCode.Combine(hashCode, this.Query);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.Query);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.SearchAvailabilityQuery query;

            /// <summary>
            /// Initialize Builder for SearchAvailabilityRequest.
            /// </summary>
            /// <param name="query"> query. </param>
            public Builder(Models.SearchAvailabilityQuery query)
            {
                this.query = query;
            }

            /// <summary>
            /// Query.
            /// </summary>
            /// <param name="query"> query. </param>
            /// <returns> Builder. </returns>
            public Builder Query(Models.SearchAvailabilityQuery query)
            {
                this.query = query;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchAvailabilityRequest. </returns>
            public SearchAvailabilityRequest Build()
            {
                return new SearchAvailabilityRequest(this.query);
            }
        }
    }
}
