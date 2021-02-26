
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
    public class SearchOrdersFulfillmentFilter 
    {
        public SearchOrdersFulfillmentFilter(IList<string> fulfillmentTypes = null,
            IList<string> fulfillmentStates = null)
        {
            FulfillmentTypes = fulfillmentTypes;
            FulfillmentStates = fulfillmentStates;
        }

        /// <summary>
        /// List of [fulfillment types](#type-orderfulfillmenttype) to filter
        /// for. Will return orders if any of its fulfillments match any of the fulfillment types
        /// listed in this field.
        /// See [OrderFulfillmentType](#type-orderfulfillmenttype) for possible values
        /// </summary>
        [JsonProperty("fulfillment_types", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> FulfillmentTypes { get; }

        /// <summary>
        /// List of [fulfillment states](#type-orderfulfillmentstate) to filter
        /// for. Will return orders if any of its fulfillments match any of the
        /// fulfillment states listed in this field.
        /// See [OrderFulfillmentState](#type-orderfulfillmentstate) for possible values
        /// </summary>
        [JsonProperty("fulfillment_states", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> FulfillmentStates { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersFulfillmentFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"FulfillmentTypes = {(FulfillmentTypes == null ? "null" : $"[{ string.Join(", ", FulfillmentTypes)} ]")}");
            toStringOutput.Add($"FulfillmentStates = {(FulfillmentStates == null ? "null" : $"[{ string.Join(", ", FulfillmentStates)} ]")}");
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

            return obj is SearchOrdersFulfillmentFilter other &&
                ((FulfillmentTypes == null && other.FulfillmentTypes == null) || (FulfillmentTypes?.Equals(other.FulfillmentTypes) == true)) &&
                ((FulfillmentStates == null && other.FulfillmentStates == null) || (FulfillmentStates?.Equals(other.FulfillmentStates) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -747213754;

            if (FulfillmentTypes != null)
            {
               hashCode += FulfillmentTypes.GetHashCode();
            }

            if (FulfillmentStates != null)
            {
               hashCode += FulfillmentStates.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .FulfillmentTypes(FulfillmentTypes)
                .FulfillmentStates(FulfillmentStates);
            return builder;
        }

        public class Builder
        {
            private IList<string> fulfillmentTypes;
            private IList<string> fulfillmentStates;



            public Builder FulfillmentTypes(IList<string> fulfillmentTypes)
            {
                this.fulfillmentTypes = fulfillmentTypes;
                return this;
            }

            public Builder FulfillmentStates(IList<string> fulfillmentStates)
            {
                this.fulfillmentStates = fulfillmentStates;
                return this;
            }

            public SearchOrdersFulfillmentFilter Build()
            {
                return new SearchOrdersFulfillmentFilter(fulfillmentTypes,
                    fulfillmentStates);
            }
        }
    }
}