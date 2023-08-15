namespace Square.Models
{
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
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// SearchCustomersResponse.
    /// </summary>
    public class SearchCustomersResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCustomersResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="customers">customers.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="count">count.</param>
        public SearchCustomersResponse(
            IList<Models.Error> errors = null,
            IList<Models.Customer> customers = null,
            string cursor = null,
            long? count = null)
        {
            this.Errors = errors;
            this.Customers = customers;
            this.Cursor = cursor;
            this.Count = count;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The customer profiles that match the search query. If any search condition is not met, the result is an empty object (`{}`).
        /// Only customer profiles with public information (`given_name`, `family_name`, `company_name`, `email_address`, or `phone_number`)
        /// are included in the response.
        /// </summary>
        [JsonProperty("customers", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Customer> Customers { get; }

        /// <summary>
        /// A pagination cursor that can be used during subsequent calls
        /// to `SearchCustomers` to retrieve the next set of results associated
        /// with the original query. Pagination cursors are only present when
        /// a request succeeds and additional results are available.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The total count of customers associated with the Square account that match the search query. Only customer profiles with
        /// public information (`given_name`, `family_name`, `company_name`, `email_address`, or `phone_number`) are counted. This field is
        /// present only if `count` is set to `true` in the request.
        /// </summary>
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchCustomersResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is SearchCustomersResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.Customers == null && other.Customers == null) || (this.Customers?.Equals(other.Customers) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Count == null && other.Count == null) || (this.Count?.Equals(other.Count) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -894792129;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.Customers, this.Cursor, this.Count);

            return hashCode;
        }
        internal SearchCustomersResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.Customers = {(this.Customers == null ? "null" : $"[{string.Join(", ", this.Customers)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.Count = {(this.Count == null ? "null" : this.Count.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Customers(this.Customers)
                .Cursor(this.Cursor)
                .Count(this.Count);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.Customer> customers;
            private string cursor;
            private long? count;

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
             /// Customers.
             /// </summary>
             /// <param name="customers"> customers. </param>
             /// <returns> Builder. </returns>
            public Builder Customers(IList<Models.Customer> customers)
            {
                this.customers = customers;
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
             /// Count.
             /// </summary>
             /// <param name="count"> count. </param>
             /// <returns> Builder. </returns>
            public Builder Count(long? count)
            {
                this.count = count;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchCustomersResponse. </returns>
            public SearchCustomersResponse Build()
            {
                return new SearchCustomersResponse(
                    this.errors,
                    this.customers,
                    this.cursor,
                    this.count);
            }
        }
    }
}