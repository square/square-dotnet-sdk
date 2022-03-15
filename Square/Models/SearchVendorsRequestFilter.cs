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
    /// SearchVendorsRequestFilter.
    /// </summary>
    public class SearchVendorsRequestFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchVendorsRequestFilter"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="status">status.</param>
        public SearchVendorsRequestFilter(
            IList<string> name = null,
            IList<string> status = null)
        {
            this.Name = name;
            this.Status = status;
        }

        /// <summary>
        /// The names of the [Vendor]($m/Vendor) objects to retrieve.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Name { get; }

        /// <summary>
        /// The statuses of the [Vendor]($m/Vendor) objects to retrieve.
        /// See [VendorStatus](#type-vendorstatus) for possible values
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Status { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchVendorsRequestFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchVendorsRequestFilter other &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1208306439;
            hashCode = HashCode.Combine(this.Name, this.Status);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : $"[{string.Join(", ", this.Name)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : $"[{string.Join(", ", this.Status)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name)
                .Status(this.Status);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<string> name;
            private IList<string> status;

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(IList<string> name)
            {
                this.name = name;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(IList<string> status)
            {
                this.status = status;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchVendorsRequestFilter. </returns>
            public SearchVendorsRequestFilter Build()
            {
                return new SearchVendorsRequestFilter(
                    this.name,
                    this.status);
            }
        }
    }
}