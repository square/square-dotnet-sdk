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
    /// SearchOrdersResponse.
    /// </summary>
    public class SearchOrdersResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersResponse"/> class.
        /// </summary>
        /// <param name="orderEntries">order_entries.</param>
        /// <param name="orders">orders.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="errors">errors.</param>
        public SearchOrdersResponse(
            IList<Models.OrderEntry> orderEntries = null,
            IList<Models.Order> orders = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            this.OrderEntries = orderEntries;
            this.Orders = orders;
            this.Cursor = cursor;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// List of [OrderEntries]($m/OrderEntry) that fit the query
        /// conditions. Populated only if `return_entries` was set to `true` in the request.
        /// </summary>
        [JsonProperty("order_entries", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderEntry> OrderEntries { get; }

        /// <summary>
        /// List of
        /// [Order]($m/Order) objects that match query conditions. Populated only if
        /// `return_entries` in the request is set to `false`.
        /// </summary>
        [JsonProperty("orders", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Order> Orders { get; }

        /// <summary>
        /// The pagination cursor to be used in a subsequent request. If unset,
        /// this is the final response.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more
        /// information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// [Errors]($m/Error) encountered during the search.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is SearchOrdersResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.OrderEntries == null && other.OrderEntries == null) || (this.OrderEntries?.Equals(other.OrderEntries) == true)) &&
                ((this.Orders == null && other.Orders == null) || (this.Orders?.Equals(other.Orders) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1440237817;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }

            if (this.OrderEntries != null)
            {
               hashCode += this.OrderEntries.GetHashCode();
            }

            if (this.Orders != null)
            {
               hashCode += this.Orders.GetHashCode();
            }

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            if (this.Errors != null)
            {
               hashCode += this.Errors.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.OrderEntries = {(this.OrderEntries == null ? "null" : $"[{string.Join(", ", this.OrderEntries)} ]")}");
            toStringOutput.Add($"this.Orders = {(this.Orders == null ? "null" : $"[{string.Join(", ", this.Orders)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .OrderEntries(this.OrderEntries)
                .Orders(this.Orders)
                .Cursor(this.Cursor)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.OrderEntry> orderEntries;
            private IList<Models.Order> orders;
            private string cursor;
            private IList<Models.Error> errors;

             /// <summary>
             /// OrderEntries.
             /// </summary>
             /// <param name="orderEntries"> orderEntries. </param>
             /// <returns> Builder. </returns>
            public Builder OrderEntries(IList<Models.OrderEntry> orderEntries)
            {
                this.orderEntries = orderEntries;
                return this;
            }

             /// <summary>
             /// Orders.
             /// </summary>
             /// <param name="orders"> orders. </param>
             /// <returns> Builder. </returns>
            public Builder Orders(IList<Models.Order> orders)
            {
                this.orders = orders;
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
            /// Builds class object.
            /// </summary>
            /// <returns> SearchOrdersResponse. </returns>
            public SearchOrdersResponse Build()
            {
                return new SearchOrdersResponse(
                    this.orderEntries,
                    this.orders,
                    this.cursor,
                    this.errors);
            }
        }
    }
}