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
    /// ListCustomersRequest.
    /// </summary>
    public class ListCustomersRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCustomersRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        /// <param name="sortField">sort_field.</param>
        /// <param name="sortOrder">sort_order.</param>
        public ListCustomersRequest(
            string cursor = null,
            int? limit = null,
            string sortField = null,
            string sortOrder = null)
        {
            this.Cursor = cursor;
            this.Limit = limit;
            this.SortField = sortField;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this cursor to retrieve the next set of results for your original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of results to return in a single page. This limit is advisory. The response might contain more or fewer results.
        /// The limit is ignored if it is less than 1 or greater than 100. The default value is 100.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// Specifies customer attributes as the sort key to customer profiles returned from a search.
        /// </summary>
        [JsonProperty("sort_field", NullValueHandling = NullValueHandling.Ignore)]
        public string SortField { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListCustomersRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListCustomersRequest other &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.SortField == null && other.SortField == null) || (this.SortField?.Equals(other.SortField) == true)) &&
                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1279199220;

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            if (this.Limit != null)
            {
               hashCode += this.Limit.GetHashCode();
            }

            if (this.SortField != null)
            {
               hashCode += this.SortField.GetHashCode();
            }

            if (this.SortOrder != null)
            {
               hashCode += this.SortOrder.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.SortField = {(this.SortField == null ? "null" : this.SortField.ToString())}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .Limit(this.Limit)
                .SortField(this.SortField)
                .SortOrder(this.SortOrder);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private int? limit;
            private string sortField;
            private string sortOrder;

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
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

             /// <summary>
             /// SortField.
             /// </summary>
             /// <param name="sortField"> sortField. </param>
             /// <returns> Builder. </returns>
            public Builder SortField(string sortField)
            {
                this.sortField = sortField;
                return this;
            }

             /// <summary>
             /// SortOrder.
             /// </summary>
             /// <param name="sortOrder"> sortOrder. </param>
             /// <returns> Builder. </returns>
            public Builder SortOrder(string sortOrder)
            {
                this.sortOrder = sortOrder;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListCustomersRequest. </returns>
            public ListCustomersRequest Build()
            {
                return new ListCustomersRequest(
                    this.cursor,
                    this.limit,
                    this.sortField,
                    this.sortOrder);
            }
        }
    }
}