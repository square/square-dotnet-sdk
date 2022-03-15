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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// SearchVendorsResponse.
    /// </summary>
    public class SearchVendorsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchVendorsResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="vendors">vendors.</param>
        /// <param name="cursor">cursor.</param>
        public SearchVendorsResponse(
            IList<Models.Error> errors = null,
            IList<Models.Vendor> vendors = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.Vendors = vendors;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Errors encountered when the request fails.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The [Vendor]($m/Vendor) objects matching the specified search filter.
        /// </summary>
        [JsonProperty("vendors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Vendor> Vendors { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset,
        /// this is the final response.
        /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchVendorsResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchVendorsResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Vendors == null && other.Vendors == null) || (this.Vendors?.Equals(other.Vendors) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 445697851;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Vendors, this.Cursor);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Vendors = {(this.Vendors == null ? "null" : $"[{string.Join(", ", this.Vendors)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Vendors(this.Vendors)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Vendor> vendors;
            private string cursor;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// Vendors.
             /// </summary>
             /// <param name="vendors"> vendors. </param>
             /// <returns> Builder. </returns>
            public Builder Vendors(IList<Models.Vendor> vendors)
            {
                this.vendors = vendors;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchVendorsResponse. </returns>
            public SearchVendorsResponse Build()
            {
                return new SearchVendorsResponse(
                    this.errors,
                    this.vendors,
                    this.cursor);
            }
        }
    }
}