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
    /// ListOrderCustomAttributeDefinitionsRequest.
    /// </summary>
    public class ListOrderCustomAttributeDefinitionsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListOrderCustomAttributeDefinitionsRequest"/> class.
        /// </summary>
        /// <param name="visibilityFilter">visibility_filter.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        public ListOrderCustomAttributeDefinitionsRequest(
            string visibilityFilter = null,
            string cursor = null,
            int? limit = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "cursor", false },
                { "limit", false }
            };

            this.VisibilityFilter = visibilityFilter;
            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

        }
        internal ListOrderCustomAttributeDefinitionsRequest(Dictionary<string, bool> shouldSerialize,
            string visibilityFilter = null,
            string cursor = null,
            int? limit = null)
        {
            this.shouldSerialize = shouldSerialize;
            VisibilityFilter = visibilityFilter;
            Cursor = cursor;
            Limit = limit;
        }

        /// <summary>
        /// Enumeration of visibility-filter values used to set the ability to view custom attributes or custom attribute definitions.
        /// </summary>
        [JsonProperty("visibility_filter", NullValueHandling = NullValueHandling.Ignore)]
        public string VisibilityFilter { get; }

        /// <summary>
        /// The cursor returned in the paged response from the previous call to this endpoint.
        /// Provide this cursor to retrieve the next page of results for your original request.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of results to return in a single paged response. This limit is advisory.
        /// The response might contain more or fewer results. The minimum value is 1 and the maximum value is 100.
        /// The default value is 20.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination).
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListOrderCustomAttributeDefinitionsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCursor()
        {
            return this.shouldSerialize["cursor"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLimit()
        {
            return this.shouldSerialize["limit"];
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

            return obj is ListOrderCustomAttributeDefinitionsRequest other &&
                ((this.VisibilityFilter == null && other.VisibilityFilter == null) || (this.VisibilityFilter?.Equals(other.VisibilityFilter) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -253610416;
            hashCode = HashCode.Combine(this.VisibilityFilter, this.Cursor, this.Limit);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.VisibilityFilter = {(this.VisibilityFilter == null ? "null" : this.VisibilityFilter.ToString())}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .VisibilityFilter(this.VisibilityFilter)
                .Cursor(this.Cursor)
                .Limit(this.Limit);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "cursor", false },
                { "limit", false },
            };

            private string visibilityFilter;
            private string cursor;
            private int? limit;

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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListOrderCustomAttributeDefinitionsRequest. </returns>
            public ListOrderCustomAttributeDefinitionsRequest Build()
            {
                return new ListOrderCustomAttributeDefinitionsRequest(shouldSerialize,
                    this.visibilityFilter,
                    this.cursor,
                    this.limit);
            }
        }
    }
}