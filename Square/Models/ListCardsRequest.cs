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
    /// ListCardsRequest.
    /// </summary>
    public class ListCardsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCardsRequest"/> class.
        /// </summary>
        /// <param name="cursor">cursor.</param>
        /// <param name="customerId">customer_id.</param>
        /// <param name="includeDisabled">include_disabled.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="sortOrder">sort_order.</param>
        public ListCardsRequest(
            string cursor = null,
            string customerId = null,
            bool? includeDisabled = null,
            string referenceId = null,
            string sortOrder = null)
        {
            this.Cursor = cursor;
            this.CustomerId = customerId;
            this.IncludeDisabled = includeDisabled;
            this.ReferenceId = referenceId;
            this.SortOrder = sortOrder;
        }

        /// <summary>
        /// A pagination cursor returned by a previous call to this endpoint.
        /// Provide this to retrieve the next set of results for your original query.
        /// See [Pagination](https://developer.squareup.com/docs/basics/api101/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Limit results to cards associated with the customer supplied.
        /// By default, all cards owned by the merchant are returned.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// Includes disabled cards.
        /// By default, all enabled cards owned by the merchant are returned.
        /// </summary>
        [JsonProperty("include_disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeDisabled { get; }

        /// <summary>
        /// Limit results to cards associated with the reference_id supplied.
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

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

            return $"ListCardsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is ListCardsRequest other &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true)) &&
                ((this.CustomerId == null && other.CustomerId == null) || (this.CustomerId?.Equals(other.CustomerId) == true)) &&
                ((this.IncludeDisabled == null && other.IncludeDisabled == null) || (this.IncludeDisabled?.Equals(other.IncludeDisabled) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.SortOrder == null && other.SortOrder == null) || (this.SortOrder?.Equals(other.SortOrder) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -418405116;

            if (this.Cursor != null)
            {
               hashCode += this.Cursor.GetHashCode();
            }

            if (this.CustomerId != null)
            {
               hashCode += this.CustomerId.GetHashCode();
            }

            if (this.IncludeDisabled != null)
            {
               hashCode += this.IncludeDisabled.GetHashCode();
            }

            if (this.ReferenceId != null)
            {
               hashCode += this.ReferenceId.GetHashCode();
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
            toStringOutput.Add($"this.CustomerId = {(this.CustomerId == null ? "null" : this.CustomerId == string.Empty ? "" : this.CustomerId)}");
            toStringOutput.Add($"this.IncludeDisabled = {(this.IncludeDisabled == null ? "null" : this.IncludeDisabled.ToString())}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
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
                .CustomerId(this.CustomerId)
                .IncludeDisabled(this.IncludeDisabled)
                .ReferenceId(this.ReferenceId)
                .SortOrder(this.SortOrder);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string cursor;
            private string customerId;
            private bool? includeDisabled;
            private string referenceId;
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
             /// CustomerId.
             /// </summary>
             /// <param name="customerId"> customerId. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

             /// <summary>
             /// IncludeDisabled.
             /// </summary>
             /// <param name="includeDisabled"> includeDisabled. </param>
             /// <returns> Builder. </returns>
            public Builder IncludeDisabled(bool? includeDisabled)
            {
                this.includeDisabled = includeDisabled;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
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
            /// <returns> ListCardsRequest. </returns>
            public ListCardsRequest Build()
            {
                return new ListCardsRequest(
                    this.cursor,
                    this.customerId,
                    this.includeDisabled,
                    this.referenceId,
                    this.sortOrder);
            }
        }
    }
}