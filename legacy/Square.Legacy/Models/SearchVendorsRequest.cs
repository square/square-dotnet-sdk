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
    /// SearchVendorsRequest.
    /// </summary>
    public class SearchVendorsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchVendorsRequest"/> class.
        /// </summary>
        /// <param name="filter">filter.</param>
        /// <param name="sort">sort.</param>
        /// <param name="cursor">cursor.</param>
        public SearchVendorsRequest(
            Models.SearchVendorsRequestFilter filter = null,
            Models.SearchVendorsRequestSort sort = null,
            string cursor = null
        )
        {
            this.Filter = filter;
            this.Sort = sort;
            this.Cursor = cursor;
        }

        /// <summary>
        /// Defines supported query expressions to search for vendors by.
        /// </summary>
        [JsonProperty("filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchVendorsRequestFilter Filter { get; }

        /// <summary>
        /// Defines a sorter used to sort results from [SearchVendors]($e/Vendors/SearchVendors).
        /// </summary>
        [JsonProperty("sort", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchVendorsRequestSort Sort { get; }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for the original query.
        /// See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SearchVendorsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is SearchVendorsRequest other
                && (
                    this.Filter == null && other.Filter == null
                    || this.Filter?.Equals(other.Filter) == true
                )
                && (
                    this.Sort == null && other.Sort == null || this.Sort?.Equals(other.Sort) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 820396067;
            hashCode = HashCode.Combine(hashCode, this.Filter, this.Sort, this.Cursor);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Filter = {(this.Filter == null ? "null" : this.Filter.ToString())}"
            );
            toStringOutput.Add(
                $"this.Sort = {(this.Sort == null ? "null" : this.Sort.ToString())}"
            );
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Filter(this.Filter).Sort(this.Sort).Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.SearchVendorsRequestFilter filter;
            private Models.SearchVendorsRequestSort sort;
            private string cursor;

            /// <summary>
            /// Filter.
            /// </summary>
            /// <param name="filter"> filter. </param>
            /// <returns> Builder. </returns>
            public Builder Filter(Models.SearchVendorsRequestFilter filter)
            {
                this.filter = filter;
                return this;
            }

            /// <summary>
            /// Sort.
            /// </summary>
            /// <param name="sort"> sort. </param>
            /// <returns> Builder. </returns>
            public Builder Sort(Models.SearchVendorsRequestSort sort)
            {
                this.sort = sort;
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
            /// <returns> SearchVendorsRequest. </returns>
            public SearchVendorsRequest Build()
            {
                return new SearchVendorsRequest(this.filter, this.sort, this.cursor);
            }
        }
    }
}
