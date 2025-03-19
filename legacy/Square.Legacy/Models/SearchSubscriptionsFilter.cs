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
    /// SearchSubscriptionsFilter.
    /// </summary>
    public class SearchSubscriptionsFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchSubscriptionsFilter"/> class.
        /// </summary>
        /// <param name="customerIds">customer_ids.</param>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="sourceNames">source_names.</param>
        public SearchSubscriptionsFilter(
            IList<string> customerIds = null,
            IList<string> locationIds = null,
            IList<string> sourceNames = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_ids", false },
                { "location_ids", false },
                { "source_names", false },
            };

            if (customerIds != null)
            {
                shouldSerialize["customer_ids"] = true;
                this.CustomerIds = customerIds;
            }

            if (locationIds != null)
            {
                shouldSerialize["location_ids"] = true;
                this.LocationIds = locationIds;
            }

            if (sourceNames != null)
            {
                shouldSerialize["source_names"] = true;
                this.SourceNames = sourceNames;
            }
        }

        internal SearchSubscriptionsFilter(
            Dictionary<string, bool> shouldSerialize,
            IList<string> customerIds = null,
            IList<string> locationIds = null,
            IList<string> sourceNames = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            CustomerIds = customerIds;
            LocationIds = locationIds;
            SourceNames = sourceNames;
        }

        /// <summary>
        /// A filter to select subscriptions based on the subscribing customer IDs.
        /// </summary>
        [JsonProperty("customer_ids")]
        public IList<string> CustomerIds { get; }

        /// <summary>
        /// A filter to select subscriptions based on the location.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// A filter to select subscriptions based on the source application.
        /// </summary>
        [JsonProperty("source_names")]
        public IList<string> SourceNames { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchSubscriptionsFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCustomerIds()
        {
            return this.shouldSerialize["customer_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationIds()
        {
            return this.shouldSerialize["location_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSourceNames()
        {
            return this.shouldSerialize["source_names"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SearchSubscriptionsFilter other
                && (
                    this.CustomerIds == null && other.CustomerIds == null
                    || this.CustomerIds?.Equals(other.CustomerIds) == true
                )
                && (
                    this.LocationIds == null && other.LocationIds == null
                    || this.LocationIds?.Equals(other.LocationIds) == true
                )
                && (
                    this.SourceNames == null && other.SourceNames == null
                    || this.SourceNames?.Equals(other.SourceNames) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 951931587;
            hashCode = HashCode.Combine(
                hashCode,
                this.CustomerIds,
                this.LocationIds,
                this.SourceNames
            );

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.CustomerIds = {(this.CustomerIds == null ? "null" : $"[{string.Join(", ", this.CustomerIds)} ]")}"
            );
            toStringOutput.Add(
                $"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}"
            );
            toStringOutput.Add(
                $"this.SourceNames = {(this.SourceNames == null ? "null" : $"[{string.Join(", ", this.SourceNames)} ]")}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CustomerIds(this.CustomerIds)
                .LocationIds(this.LocationIds)
                .SourceNames(this.SourceNames);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "customer_ids", false },
                { "location_ids", false },
                { "source_names", false },
            };

            private IList<string> customerIds;
            private IList<string> locationIds;
            private IList<string> sourceNames;

            /// <summary>
            /// CustomerIds.
            /// </summary>
            /// <param name="customerIds"> customerIds. </param>
            /// <returns> Builder. </returns>
            public Builder CustomerIds(IList<string> customerIds)
            {
                shouldSerialize["customer_ids"] = true;
                this.customerIds = customerIds;
                return this;
            }

            /// <summary>
            /// LocationIds.
            /// </summary>
            /// <param name="locationIds"> locationIds. </param>
            /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                shouldSerialize["location_ids"] = true;
                this.locationIds = locationIds;
                return this;
            }

            /// <summary>
            /// SourceNames.
            /// </summary>
            /// <param name="sourceNames"> sourceNames. </param>
            /// <returns> Builder. </returns>
            public Builder SourceNames(IList<string> sourceNames)
            {
                shouldSerialize["source_names"] = true;
                this.sourceNames = sourceNames;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCustomerIds()
            {
                this.shouldSerialize["customer_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLocationIds()
            {
                this.shouldSerialize["location_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSourceNames()
            {
                this.shouldSerialize["source_names"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchSubscriptionsFilter. </returns>
            public SearchSubscriptionsFilter Build()
            {
                return new SearchSubscriptionsFilter(
                    shouldSerialize,
                    this.customerIds,
                    this.locationIds,
                    this.sourceNames
                );
            }
        }
    }
}
