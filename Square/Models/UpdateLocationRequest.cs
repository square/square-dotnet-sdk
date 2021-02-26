
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
    public class UpdateLocationRequest 
    {
        public UpdateLocationRequest(Models.Location location = null)
        {
            Location = location;
        }

        /// <summary>
        /// Getter for location
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Location Location { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateLocationRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Location = {(Location == null ? "null" : Location.ToString())}");
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

            return obj is UpdateLocationRequest other &&
                ((Location == null && other.Location == null) || (Location?.Equals(other.Location) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 687060631;

            if (Location != null)
            {
               hashCode += Location.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Location(Location);
            return builder;
        }

        public class Builder
        {
            private Models.Location location;



            public Builder Location(Models.Location location)
            {
                this.location = location;
                return this;
            }

            public UpdateLocationRequest Build()
            {
                return new UpdateLocationRequest(location);
            }
        }
    }
}