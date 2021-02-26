
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
    public class LoyaltyEventLocationFilter 
    {
        public LoyaltyEventLocationFilter(IList<string> locationIds)
        {
            LocationIds = locationIds;
        }

        /// <summary>
        /// The [location](#type-Location) IDs for loyalty events to query.
        /// If multiple values are specified, the endpoint uses 
        /// a logical OR to combine them.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventLocationFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
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

            return obj is LoyaltyEventLocationFilter other &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1253354615;

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationIds);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationIds;

            public Builder(IList<string> locationIds)
            {
                this.locationIds = locationIds;
            }

            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

            public LoyaltyEventLocationFilter Build()
            {
                return new LoyaltyEventLocationFilter(locationIds);
            }
        }
    }
}