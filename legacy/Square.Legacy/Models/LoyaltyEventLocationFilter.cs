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
    /// LoyaltyEventLocationFilter.
    /// </summary>
    public class LoyaltyEventLocationFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventLocationFilter"/> class.
        /// </summary>
        /// <param name="locationIds">location_ids.</param>
        public LoyaltyEventLocationFilter(IList<string> locationIds)
        {
            this.LocationIds = locationIds;
        }

        /// <summary>
        /// The [location](entity:Location) IDs for loyalty events to query.
        /// If multiple values are specified, the endpoint uses
        /// a logical OR to combine them.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"LoyaltyEventLocationFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is LoyaltyEventLocationFilter other
                && (
                    this.LocationIds == null && other.LocationIds == null
                    || this.LocationIds?.Equals(other.LocationIds) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1253354615;
            hashCode = HashCode.Combine(hashCode, this.LocationIds);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(this.LocationIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> locationIds;

            /// <summary>
            /// Initialize Builder for LoyaltyEventLocationFilter.
            /// </summary>
            /// <param name="locationIds"> locationIds. </param>
            public Builder(IList<string> locationIds)
            {
                this.locationIds = locationIds;
            }

            /// <summary>
            /// LocationIds.
            /// </summary>
            /// <param name="locationIds"> locationIds. </param>
            /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventLocationFilter. </returns>
            public LoyaltyEventLocationFilter Build()
            {
                return new LoyaltyEventLocationFilter(this.locationIds);
            }
        }
    }
}
