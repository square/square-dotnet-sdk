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
    using Square.Utilities;

    /// <summary>
    /// ListLocationCustomAttributeDefinitionsRequest.
    /// </summary>
    public class ListLocationCustomAttributeDefinitionsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListLocationCustomAttributeDefinitionsRequest"/> class.
        /// </summary>
        /// <param name="visibilityFilter">visibility_filter.</param>
        /// <param name="limit">limit.</param>
        /// <param name="cursor">cursor.</param>
        public ListLocationCustomAttributeDefinitionsRequest(
            string visibilityFilter = null,
            int? limit = null,
            string cursor = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "limit", false },
                { "cursor", false }
            };

            this.VisibilityFilter = visibilityFilter;
            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

        }
        internal ListLocationCustomAttributeDefinitionsRequest(Dictionary<string, bool> shouldSerialize,
            string visibilityFilter = null,
            int? limit = null,
            string cursor = null)
        {
            this.shouldSerialize = shouldSerialize;
            VisibilityFilter = visibilityFilter;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Enumeration of visibility-filter values used to set the ability to view custom attributes or custom attribute definitions.
        /// </summary>
        [JsonProperty("visibility_filter", NullValueHandling = NullValueHandling.Ignore)]
        public string VisibilityFilter { get; }

        /// <summary>
        /// The maximum number of results to return in a single paged response. This limit is advisory.
        /// The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.
        /// The default value is 20. For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// The cursor returned in the paged response from the previous call to this endpoint.
        /// Provide this cursor to retrieve the next page of results for your original request.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListLocationCustomAttributeDefinitionsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLimit()
        {
            return this.shouldSerialize["limit"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
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
            return obj is ListLocationCustomAttributeDefinitionsRequest other &&                ((this.VisibilityFilter == null && other.VisibilityFilter == null) || (this.VisibilityFilter?.Equals(other.VisibilityFilter) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2038488401;
            hashCode = HashCode.Combine(this.VisibilityFilter, this.Limit, this.Cursor);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.VisibilityFilter = {(this.VisibilityFilter == null ? "null" : this.VisibilityFilter.ToString())}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .VisibilityFilter(this.VisibilityFilter)
                .Limit(this.Limit)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "limit", false },
                { "cursor", false },
            };

            private string visibilityFilter;
            private int? limit;
            private string cursor;

             /// <summary>
             /// VisibilityFilter.
             /// </summary>
             /// <param name="visibilityFilter"> visibilityFilter. </param>
             /// <returns> Builder. </returns>
            public Builder VisibilityFilter(string visibilityFilter)
            {
                this.visibilityFilter = visibilityFilter;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                shouldSerialize["limit"] = true;
                this.limit = limit;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                shouldSerialize["cursor"] = true;
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListLocationCustomAttributeDefinitionsRequest. </returns>
            public ListLocationCustomAttributeDefinitionsRequest Build()
            {
                return new ListLocationCustomAttributeDefinitionsRequest(shouldSerialize,
                    this.visibilityFilter,
                    this.limit,
                    this.cursor);
            }
        }
    }
}