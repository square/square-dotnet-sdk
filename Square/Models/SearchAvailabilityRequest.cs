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
    /// SearchAvailabilityRequest.
    /// </summary>
    public class SearchAvailabilityRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchAvailabilityRequest"/> class.
        /// </summary>
        /// <param name="query">query.</param>
        public SearchAvailabilityRequest(
            Models.SearchAvailabilityQuery query)
        {
            this.Query = query;
        }

        /// <summary>
        /// Query conditions to search for availabilities of bookings.
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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is SearchAvailabilityRequest other &&
                ((this.Query == null && other.Query == null) || (this.Query?.Equals(other.Query) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1074083477;

            if (this.Query != null)
            {
               hashCode += this.Query.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Query = {(this.Query == null ? "null" : this.Query.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Query);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.SearchAvailabilityQuery query;

            public Builder(
                Models.SearchAvailabilityQuery query)
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
                return new SearchAvailabilityRequest(
                    this.query);
            }
        }
    }
}