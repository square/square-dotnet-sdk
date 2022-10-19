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
    /// SearchOrdersFulfillmentFilter.
    /// </summary>
    public class SearchOrdersFulfillmentFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersFulfillmentFilter"/> class.
        /// </summary>
        /// <param name="fulfillmentTypes">fulfillment_types.</param>
        /// <param name="fulfillmentStates">fulfillment_states.</param>
        public SearchOrdersFulfillmentFilter(
            IList<string> fulfillmentTypes = null,
            IList<string> fulfillmentStates = null)
        {
            this.FulfillmentTypes = fulfillmentTypes;
            this.FulfillmentStates = fulfillmentStates;
        }

        /// <summary>
        /// A list of [fulfillment types]($m/FulfillmentType) to filter
        /// for. The list returns orders if any of its fulfillments match any of the fulfillment types
        /// listed in this field.
        /// See [FulfillmentType](#type-fulfillmenttype) for possible values
        /// </summary>
        [JsonProperty("fulfillment_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> FulfillmentTypes { get; }

        /// <summary>
        /// A list of [fulfillment states]($m/FulfillmentState) to filter
        /// for. The list returns orders if any of its fulfillments match any of the
        /// fulfillment states listed in this field.
        /// See [FulfillmentState](#type-fulfillmentstate) for possible values
        /// </summary>
        [JsonProperty("fulfillment_states", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> FulfillmentStates { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersFulfillmentFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchOrdersFulfillmentFilter other &&
                ((this.FulfillmentTypes == null && other.FulfillmentTypes == null) || (this.FulfillmentTypes?.Equals(other.FulfillmentTypes) == true)) &&
                ((this.FulfillmentStates == null && other.FulfillmentStates == null) || (this.FulfillmentStates?.Equals(other.FulfillmentStates) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -747213754;
            hashCode = HashCode.Combine(this.FulfillmentTypes, this.FulfillmentStates);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.FulfillmentTypes = {(this.FulfillmentTypes == null ? "null" : $"[{string.Join(", ", this.FulfillmentTypes)} ]")}");
            toStringOutput.Add($"this.FulfillmentStates = {(this.FulfillmentStates == null ? "null" : $"[{string.Join(", ", this.FulfillmentStates)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .FulfillmentTypes(this.FulfillmentTypes)
                .FulfillmentStates(this.FulfillmentStates);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> fulfillmentTypes;
            private IList<string> fulfillmentStates;

             /// <summary>
             /// FulfillmentTypes.
             /// </summary>
             /// <param name="fulfillmentTypes"> fulfillmentTypes. </param>
             /// <returns> Builder. </returns>
            public Builder FulfillmentTypes(IList<string> fulfillmentTypes)
            {
                this.fulfillmentTypes = fulfillmentTypes;
                return this;
            }

             /// <summary>
             /// FulfillmentStates.
             /// </summary>
             /// <param name="fulfillmentStates"> fulfillmentStates. </param>
             /// <returns> Builder. </returns>
            public Builder FulfillmentStates(IList<string> fulfillmentStates)
            {
                this.fulfillmentStates = fulfillmentStates;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchOrdersFulfillmentFilter. </returns>
            public SearchOrdersFulfillmentFilter Build()
            {
                return new SearchOrdersFulfillmentFilter(
                    this.fulfillmentTypes,
                    this.fulfillmentStates);
            }
        }
    }
}