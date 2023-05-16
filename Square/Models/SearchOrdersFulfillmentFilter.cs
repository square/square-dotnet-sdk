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
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersFulfillmentFilter"/> class.
        /// </summary>
        /// <param name="fulfillmentTypes">fulfillment_types.</param>
        /// <param name="fulfillmentStates">fulfillment_states.</param>
        public SearchOrdersFulfillmentFilter(
            IList<string> fulfillmentTypes = null,
            IList<string> fulfillmentStates = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "fulfillment_types", false },
                { "fulfillment_states", false }
            };

            if (fulfillmentTypes != null)
            {
                shouldSerialize["fulfillment_types"] = true;
                this.FulfillmentTypes = fulfillmentTypes;
            }

            if (fulfillmentStates != null)
            {
                shouldSerialize["fulfillment_states"] = true;
                this.FulfillmentStates = fulfillmentStates;
            }

        }
        internal SearchOrdersFulfillmentFilter(Dictionary<string, bool> shouldSerialize,
            IList<string> fulfillmentTypes = null,
            IList<string> fulfillmentStates = null)
        {
            this.shouldSerialize = shouldSerialize;
            FulfillmentTypes = fulfillmentTypes;
            FulfillmentStates = fulfillmentStates;
        }

        /// <summary>
        /// A list of [fulfillment types](entity:FulfillmentType) to filter
        /// for. The list returns orders if any of its fulfillments match any of the fulfillment types
        /// listed in this field.
        /// See [FulfillmentType](#type-fulfillmenttype) for possible values
        /// </summary>
        [JsonProperty("fulfillment_types")]
        public IList<string> FulfillmentTypes { get; }

        /// <summary>
        /// A list of [fulfillment states](entity:FulfillmentState) to filter
        /// for. The list returns orders if any of its fulfillments match any of the
        /// fulfillment states listed in this field.
        /// See [FulfillmentState](#type-fulfillmentstate) for possible values
        /// </summary>
        [JsonProperty("fulfillment_states")]
        public IList<string> FulfillmentStates { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersFulfillmentFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFulfillmentTypes()
        {
            return this.shouldSerialize["fulfillment_types"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFulfillmentStates()
        {
            return this.shouldSerialize["fulfillment_states"];
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
            return obj is SearchOrdersFulfillmentFilter other &&                ((this.FulfillmentTypes == null && other.FulfillmentTypes == null) || (this.FulfillmentTypes?.Equals(other.FulfillmentTypes) == true)) &&
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "fulfillment_types", false },
                { "fulfillment_states", false },
            };

            private IList<string> fulfillmentTypes;
            private IList<string> fulfillmentStates;

             /// <summary>
             /// FulfillmentTypes.
             /// </summary>
             /// <param name="fulfillmentTypes"> fulfillmentTypes. </param>
             /// <returns> Builder. </returns>
            public Builder FulfillmentTypes(IList<string> fulfillmentTypes)
            {
                shouldSerialize["fulfillment_types"] = true;
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
                shouldSerialize["fulfillment_states"] = true;
                this.fulfillmentStates = fulfillmentStates;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFulfillmentTypes()
            {
                this.shouldSerialize["fulfillment_types"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFulfillmentStates()
            {
                this.shouldSerialize["fulfillment_states"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchOrdersFulfillmentFilter. </returns>
            public SearchOrdersFulfillmentFilter Build()
            {
                return new SearchOrdersFulfillmentFilter(shouldSerialize,
                    this.fulfillmentTypes,
                    this.fulfillmentStates);
            }
        }
    }
}