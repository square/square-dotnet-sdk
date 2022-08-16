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
    /// CustomerCustomAttributeFilters.
    /// </summary>
    public class CustomerCustomAttributeFilters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCustomAttributeFilters"/> class.
        /// </summary>
        /// <param name="filters">filters.</param>
        public CustomerCustomAttributeFilters(
            IList<Models.CustomerCustomAttributeFilter> filters = null)
        {
            this.Filters = filters;
        }

        /// <summary>
        /// The custom attribute filters. Each filter must specify `key` and include the `filter` field with a type-specific filter,
        /// the `updated_at` field, or both. The provided keys must be unique within the list of custom attribute filters.
        /// </summary>
        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.CustomerCustomAttributeFilter> Filters { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerCustomAttributeFilters : ({string.Join(", ", toStringOutput)})";
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

            return obj is CustomerCustomAttributeFilters other &&
                ((this.Filters == null && other.Filters == null) || (this.Filters?.Equals(other.Filters) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1015790427;
            hashCode = HashCode.Combine(this.Filters);

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
            private IList<Models.CustomerCustomAttributeFilter> filters;

             /// <summary>
             /// Filters.
             /// </summary>
             /// <param name="filters"> filters. </param>
             /// <returns> Builder. </returns>
            public Builder Filters(IList<Models.CustomerCustomAttributeFilter> filters)
            {
                this.filters = filters;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerCustomAttributeFilters. </returns>
            public CustomerCustomAttributeFilters Build()
            {
                return new CustomerCustomAttributeFilters(
                    this.filters);
            }
        }
    }
}