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
using Square.Legacy.Http.Client;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// ListCustomersResponse.
    /// </summary>
    public class ListCustomersResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCustomersResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="customers">customers.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="count">count.</param>
        public ListCustomersResponse(
            IList<Models.Error> errors = null,
            IList<Models.Customer> customers = null,
            string cursor = null,
            long? count = null
        )
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
        /// The customer profiles associated with the Square account or an empty object (`{}`) if none are found.
        /// Only customer profiles with public information (`given_name`, `family_name`, `company_name`, `email_address`, or
        /// `phone_number`) are included in the response.
        /// </summary>
        [JsonProperty("customers", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Customer> Customers { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for the
        /// original query. A cursor is only present if the request succeeded and additional results
        /// are available.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The total count of customers associated with the Square account. Only customer profiles with public information
        /// (`given_name`, `family_name`, `company_name`, `email_address`, or `phone_number`) are counted. This field is present
        /// only if `count` is set to `true` in the request.
        /// </summary>
        [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
        public long? Count { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListCustomersResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ListCustomersResponse other
                && (
                    (this.Context == null && other.Context == null)
                    || this.Context?.Equals(other.Context) == true
                )
                && (
                    this.Errors == null && other.Errors == null
                    || this.Errors?.Equals(other.Errors) == true
                )
                && (
                    this.Customers == null && other.Customers == null
                    || this.Customers?.Equals(other.Customers) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                )
                && (
                    this.Count == null && other.Count == null
                    || this.Count?.Equals(other.Count) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1586473133;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(
                hashCode,
                this.Errors,
                this.Customers,
                this.Cursor,
                this.Count
            );

            return hashCode;
        }

        internal ListCustomersResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add(
                $"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}"
            );
            toStringOutput.Add(
                $"this.Customers = {(this.Customers == null ? "null" : $"[{string.Join(", ", this.Customers)} ]")}"
            );
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add(
                $"this.Count = {(this.Count == null ? "null" : this.Count.ToString())}"
            );
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
            /// <returns> ListCustomersResponse. </returns>
            public ListCustomersResponse Build()
            {
                return new ListCustomersResponse(
                    this.errors,
                    this.customers,
                    this.cursor,
                    this.count
                );
            }
        }
    }
}
