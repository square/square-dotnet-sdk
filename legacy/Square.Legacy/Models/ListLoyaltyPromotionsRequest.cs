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
    /// ListLoyaltyPromotionsRequest.
    /// </summary>
    public class ListLoyaltyPromotionsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListLoyaltyPromotionsRequest"/> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="cursor">cursor.</param>
        /// <param name="limit">limit.</param>
        public ListLoyaltyPromotionsRequest(
            string status = null,
            string cursor = null,
            int? limit = null
        )
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "cursor", false },
                { "limit", false },
            };
            this.Status = status;

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

        internal ListLoyaltyPromotionsRequest(
            Dictionary<string, bool> shouldSerialize,
            string status = null,
            string cursor = null,
            int? limit = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Status = status;
            Cursor = cursor;
            Limit = limit;
        }

        /// <summary>
        /// Indicates the status of a [loyalty promotion]($m/LoyaltyPromotion).
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// The cursor returned in the paged response from the previous call to this endpoint.
        /// Provide this cursor to retrieve the next page of results for your original request.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        /// <summary>
        /// The maximum number of results to return in a single paged response.
        /// The minimum value is 1 and the maximum value is 30. The default value is 30.
        /// For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination).
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"ListLoyaltyPromotionsRequest : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is ListLoyaltyPromotionsRequest other
                && (
                    this.Status == null && other.Status == null
                    || this.Status?.Equals(other.Status) == true
                )
                && (
                    this.Cursor == null && other.Cursor == null
                    || this.Cursor?.Equals(other.Cursor) == true
                )
                && (
                    this.Limit == null && other.Limit == null
                    || this.Limit?.Equals(other.Limit) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -275372364;
            hashCode = HashCode.Combine(hashCode, this.Status, this.Cursor, this.Limit);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add(
                $"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}"
            );
            toStringOutput.Add($"this.Cursor = {this.Cursor ?? "null"}");
            toStringOutput.Add(
                $"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}"
            );
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Status(this.Status).Cursor(this.Cursor).Limit(this.Limit);
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

            private string status;
            private string cursor;
            private int? limit;

            /// <summary>
            /// Status.
            /// </summary>
            /// <param name="status"> status. </param>
            /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetCursor()
            {
                this.shouldSerialize["cursor"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetLimit()
            {
                this.shouldSerialize["limit"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListLoyaltyPromotionsRequest. </returns>
            public ListLoyaltyPromotionsRequest Build()
            {
                return new ListLoyaltyPromotionsRequest(
                    shouldSerialize,
                    this.status,
                    this.cursor,
                    this.limit
                );
            }
        }
    }
}
