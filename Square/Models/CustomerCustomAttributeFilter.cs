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
    /// CustomerCustomAttributeFilter.
    /// </summary>
    public class CustomerCustomAttributeFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCustomAttributeFilter"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        /// <param name="filter">filter.</param>
        /// <param name="updatedAt">updated_at.</param>
        public CustomerCustomAttributeFilter(
            string key,
            Models.CustomerCustomAttributeFilterValue filter = null,
            Models.TimeRange updatedAt = null)
        {
            this.Key = key;
            this.Filter = filter;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The `key` of the [custom attribute]($m/CustomAttribute) to filter by. The key is the identifier of the custom attribute
        /// (and the corresponding custom attribute definition) and can be retrieved using the [Customer Custom Attributes API]($e/CustomerCustomAttributes).
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; }

        /// <summary>
        /// A type-specific filter used in a [custom attribute filter]($m/CustomerCustomAttributeFilter) to search based on the value
        /// of a customer-related [custom attribute]($m/CustomAttribute).
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CustomerCustomAttributeFilterValue Filter { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TimeRange UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CustomerCustomAttributeFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is CustomerCustomAttributeFilter other &&
                ((this.Key == null && other.Key == null) || (this.Key?.Equals(other.Key) == true)) &&
                ((this.Filter == null && other.Filter == null) || (this.Filter?.Equals(other.Filter) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1383258828;
            hashCode = HashCode.Combine(this.Key, this.Filter, this.UpdatedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Key = {(this.Key == null ? "null" : this.Key == string.Empty ? "" : this.Key)}");
            toStringOutput.Add($"this.Filter = {(this.Filter == null ? "null" : this.Filter.ToString())}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Key)
                .Filter(this.Filter)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string key;
            private Models.CustomerCustomAttributeFilterValue filter;
            private Models.TimeRange updatedAt;

            public Builder(
                string key)
            {
                this.key = key;
            }

             /// <summary>
             /// Key.
             /// </summary>
             /// <param name="key"> key. </param>
             /// <returns> Builder. </returns>
            public Builder Key(string key)
            {
                this.key = key;
                return this;
            }

             /// <summary>
             /// Filter.
             /// </summary>
             /// <param name="filter"> filter. </param>
             /// <returns> Builder. </returns>
            public Builder Filter(Models.CustomerCustomAttributeFilterValue filter)
            {
                this.filter = filter;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(Models.TimeRange updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CustomerCustomAttributeFilter. </returns>
            public CustomerCustomAttributeFilter Build()
            {
                return new CustomerCustomAttributeFilter(
                    this.key,
                    this.filter,
                    this.updatedAt);
            }
        }
    }
}