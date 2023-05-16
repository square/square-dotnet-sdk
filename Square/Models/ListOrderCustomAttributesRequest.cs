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
    /// ListOrderCustomAttributesRequest.
    /// </summary>
    public class ListOrderCustomAttributesRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListOrderCustomAttributesRequest"/> class.
        /// </summary>
        /// <param name="visibilityFilter">visibility_filter.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        /// <param name="withDefinitions">with_definitions.</param>
        public ListOrderCustomAttributesRequest(
            string visibilityFilter = null,
            string cursor = null,
            int? limit = null,
            bool? withDefinitions = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "cursor", false },
                { "limit", false },
                { "with_definitions", false }
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

            if (withDefinitions != null)
            {
                shouldSerialize["with_definitions"] = true;
                this.WithDefinitions = withDefinitions;
            }

        }
        internal ListOrderCustomAttributesRequest(Dictionary<string, bool> shouldSerialize,
            string visibilityFilter = null,
            string cursor = null,
            int? limit = null,
            bool? withDefinitions = null)
        {
            this.shouldSerialize = shouldSerialize;
            VisibilityFilter = visibilityFilter;
            Cursor = cursor;
            Limit = limit;
            WithDefinitions = withDefinitions;
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

        /// <summary>
        /// Indicates whether to return the [custom attribute definition](entity:CustomAttributeDefinition) in the `definition` field of each
        /// custom attribute. Set this parameter to `true` to get the name and description of each custom attribute,
        /// information about the data type, or other definition details. The default value is `false`.
        /// </summary>
        [JsonProperty("with_definitions")]
        public bool? WithDefinitions { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListOrderCustomAttributesRequest : ({string.Join(", ", toStringOutput)})";
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

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeWithDefinitions()
        {
            return this.shouldSerialize["with_definitions"];
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
            return obj is ListOrderCustomAttributesRequest other &&                ((this.VisibilityFilter == null && other.VisibilityFilter == null) || (this.VisibilityFilter?.Equals(other.VisibilityFilter) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.WithDefinitions == null && other.WithDefinitions == null) || (this.WithDefinitions?.Equals(other.WithDefinitions) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 57973103;
            hashCode = HashCode.Combine(this.VisibilityFilter, this.Cursor, this.Limit, this.WithDefinitions);

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
            toStringOutput.Add($"this.WithDefinitions = {(this.WithDefinitions == null ? "null" : this.WithDefinitions.ToString())}");
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
                .Limit(this.Limit)
                .WithDefinitions(this.WithDefinitions);
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
                { "with_definitions", false },
            };

            private string visibilityFilter;
            private string cursor;
            private int? limit;
            private bool? withDefinitions;

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
             /// WithDefinitions.
             /// </summary>
             /// <param name="withDefinitions"> withDefinitions. </param>
             /// <returns> Builder. </returns>
            public Builder WithDefinitions(bool? withDefinitions)
            {
                shouldSerialize["with_definitions"] = true;
                this.withDefinitions = withDefinitions;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetWithDefinitions()
            {
                this.shouldSerialize["with_definitions"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListOrderCustomAttributesRequest. </returns>
            public ListOrderCustomAttributesRequest Build()
            {
                return new ListOrderCustomAttributesRequest(shouldSerialize,
                    this.visibilityFilter,
                    this.cursor,
                    this.limit,
                    this.withDefinitions);
            }
        }
    }
}