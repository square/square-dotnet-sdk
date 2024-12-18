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
using Square;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// CustomerCustomAttributeFilters.
    /// </summary>
    public class CustomerCustomAttributeFilters
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCustomAttributeFilters"/> class.
        /// </summary>
        /// <param name="filters">filters.</param>
        public CustomerCustomAttributeFilters(
            IList<Models.CustomerCustomAttributeFilter> filters = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "filters", false }
            };

            if (filters != null)
            {
                shouldSerialize["filters"] = true;
                this.Filters = filters;
            }
        }

        internal CustomerCustomAttributeFilters(
            Dictionary<string, bool> shouldSerialize,
            IList<Models.CustomerCustomAttributeFilter> filters = null)
        {
            this.shouldSerialize = shouldSerialize;
            Filters = filters;
        }

        /// <summary>
        /// The custom attribute filters. Each filter must specify `key` and include the `filter` field with a type-specific filter,
        /// the `updated_at` field, or both. The provided keys must be unique within the list of custom attribute filters.
        /// </summary>
        [JsonProperty("filters")]
        public IList<Models.CustomerCustomAttributeFilter> Filters { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"CustomerCustomAttributeFilters : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFilters()
        {
            return this.shouldSerialize["filters"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is CustomerCustomAttributeFilters other &&
                (this.Filters == null && other.Filters == null ||
                 this.Filters?.Equals(other.Filters) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1015790427;
            hashCode = HashCode.Combine(hashCode, this.Filters);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Filters = {(this.Filters == null ? "null" : $"[{string.Join(", ", this.Filters)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Filters(this.Filters);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "filters", false },
            };

            private IList<Models.CustomerCustomAttributeFilter> filters;

             /// <summary>
             /// Filters.
             /// </summary>
             /// <param name="filters"> filters. </param>
             /// <returns> Builder. </returns>
            public Builder Filters(IList<Models.CustomerCustomAttributeFilter> filters)
            {
                shouldSerialize["filters"] = true;
                this.filters = filters;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetFilters()
            {
                this.shouldSerialize["filters"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerCustomAttributeFilters. </returns>
            public CustomerCustomAttributeFilters Build()
            {
                return new CustomerCustomAttributeFilters(
                    shouldSerialize,
                    this.filters);
            }
        }
    }
}