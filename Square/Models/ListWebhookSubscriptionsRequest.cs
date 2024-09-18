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

namespace Square.Models
{
    /// <summary>
    /// ListWebhookSubscriptionsRequest.
    /// </summary>
    public class ListWebhookSubscriptionsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ListWebhookSubscriptionsRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="includeDisabled">include_disabled.</param>
        /// <param name="sortOrder">sort_order.</param>
        /// <param name="limit">limit.</param>
        public ListWebhookSubscriptionsRequest(
            string cursor = null,
            bool? includeDisabled = null,
            string sortOrder = null,
            int? limit = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "cursor", false },
                { "include_disabled", false },
                { "limit", false }
            };

            if (cursor != null)
            {
                shouldSerialize["cursor"] = true;
                this.Cursor = cursor;
            }

            if (includeDisabled != null)
            {
                shouldSerialize["include_disabled"] = true;
                this.IncludeDisabled = includeDisabled;
            }

            this.SortOrder = sortOrder;
            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

        }
        internal ListWebhookSubscriptionsRequest(Dictionary<string, bool> shouldSerialize,
            string cursor = null,
            bool? includeDisabled = null,
            string sortOrder = null,
            int? limit = null)
        {
            this.shouldSerialize = shouldSerialize;
            Cursor = cursor;
            IncludeDisabled = includeDisabled;
            SortOrder = sortOrder;
            Limit = limit;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// Includes disabled [Subscription](entity:WebhookSubscription)s.
        /// By default, all enabled [Subscription](entity:WebhookSubscription)s are returned.
        /// </summary>
        [JsonProperty("include_disabled")]
        public bool? IncludeDisabled { get; }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("sort_order", NullValueHandling = NullValueHandling.Ignore)]
        public string SortOrder { get; }

        /// <summary>
        /// The maximum number of results to be returned in a single page.
        /// It is possible to receive fewer results than the specified limit on a given page.
        /// The default value of 100 is also the maximum allowed value.
        /// Default: 100
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListWebhookSubscriptionsRequest : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeIncludeDisabled()
        {
            return this.shouldSerialize["include_disabled"];
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
            return obj is ListWebhookSubscriptionsRequest other &&                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.IncludeDisabled == null && other.IncludeDisabled == null) || (this.IncludeDisabled?.Equals(other.IncludeDisabled) == true)) &&
                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1378989180;
            hashCode = HashCode.Combine(this.Cursor, this.IncludeDisabled, this.SortOrder, this.Limit);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor)}");
            toStringOutput.Add($"this.IncludeDisabled = {(this.IncludeDisabled == null ? "null" : this.IncludeDisabled.ToString())}");
            toStringOutput.Add($"this.SortOrder = {(this.SortOrder == null ? "null" : this.SortOrder.ToString())}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Cursor(this.Cursor)
                .IncludeDisabled(this.IncludeDisabled)
                .SortOrder(this.SortOrder)
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
                { "include_disabled", false },
                { "limit", false },
            };

            private string cursor;
            private bool? includeDisabled;
            private string sortOrder;
            private int? limit;

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
             /// IncludeDisabled.
             /// </summary>
             /// <param name="includeDisabled"> includeDisabled. </param>
             /// <returns> Builder. </returns>
            public Builder IncludeDisabled(bool? includeDisabled)
            {
                shouldSerialize["include_disabled"] = true;
                this.includeDisabled = includeDisabled;
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
            public void UnsetIncludeDisabled()
            {
                this.shouldSerialize["include_disabled"] = false;
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
            /// <returns> ListWebhookSubscriptionsRequest. </returns>
            public ListWebhookSubscriptionsRequest Build()
            {
                return new ListWebhookSubscriptionsRequest(shouldSerialize,
                    this.cursor,
                    this.includeDisabled,
                    this.sortOrder,
                    this.limit);
            }
        }
    }
}