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
    /// SearchOrdersFilter.
    /// </summary>
    public class SearchOrdersFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchOrdersFilter"/> class.
        /// </summary>
        /// <param name="stateFilter">state_filter.</param>
        /// <param name="dateTimeFilter">date_time_filter.</param>
        /// <param name="fulfillmentFilter">fulfillment_filter.</param>
        /// <param name="sourceFilter">source_filter.</param>
        /// <param name="customerFilter">customer_filter.</param>
        public SearchOrdersFilter(
            Models.SearchOrdersStateFilter stateFilter = null,
            Models.SearchOrdersDateTimeFilter dateTimeFilter = null,
            Models.SearchOrdersFulfillmentFilter fulfillmentFilter = null,
            Models.SearchOrdersSourceFilter sourceFilter = null,
            Models.SearchOrdersCustomerFilter customerFilter = null)
        {
            this.StateFilter = stateFilter;
            this.DateTimeFilter = dateTimeFilter;
            this.FulfillmentFilter = fulfillmentFilter;
            this.SourceFilter = sourceFilter;
            this.CustomerFilter = customerFilter;
        }

        /// <summary>
        /// Filter by the current order `state`.
        /// </summary>
        [JsonProperty("state_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersStateFilter StateFilter { get; }

        /// <summary>
        /// Filter for `Order` objects based on whether their `CREATED_AT`,
        /// `CLOSED_AT`, or `UPDATED_AT` timestamps fall within a specified time range.
        /// You can specify the time range and which timestamp to filter for. You can filter
        /// for only one time range at a time.
        /// For each time range, the start time and end time are inclusive. If the end time
        /// is absent, it defaults to the time of the first request for the cursor.
        /// __Important:__ If you use the `DateTimeFilter` in a `SearchOrders` query,
        /// you must set the `sort_field` in [OrdersSort]($m/SearchOrdersSort)
        /// to the same field you filter for. For example, if you set the `CLOSED_AT` field
        /// in `DateTimeFilter`, you must set the `sort_field` in `SearchOrdersSort` to
        /// `CLOSED_AT`. Otherwise, `SearchOrders` throws an error.
        /// [Learn more about filtering orders by time range.](https://developer.squareup.com/docs/orders-api/manage-orders/search-orders#important-note-about-filtering-orders-by-time-range)
        /// </summary>
        [JsonProperty("date_time_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersDateTimeFilter DateTimeFilter { get; }

        /// <summary>
        /// Filter based on [order fulfillment]($m/Fulfillment) information.
        /// </summary>
        [JsonProperty("fulfillment_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersFulfillmentFilter FulfillmentFilter { get; }

        /// <summary>
        /// A filter based on order `source` information.
        /// </summary>
        [JsonProperty("source_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersSourceFilter SourceFilter { get; }

        /// <summary>
        /// A filter based on the order `customer_id` and any tender `customer_id`
        /// associated with the order. It does not filter based on the
        /// [FulfillmentRecipient]($m/FulfillmentRecipient) `customer_id`.
        /// </summary>
        [JsonProperty("customer_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.SearchOrdersCustomerFilter CustomerFilter { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchOrdersFilter : ({string.Join(", ", toStringOutput)})";
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
            return obj is SearchOrdersFilter other &&                ((this.StateFilter == null && other.StateFilter == null) || (this.StateFilter?.Equals(other.StateFilter) == true)) &&
                ((this.DateTimeFilter == null && other.DateTimeFilter == null) || (this.DateTimeFilter?.Equals(other.DateTimeFilter) == true)) &&
                ((this.FulfillmentFilter == null && other.FulfillmentFilter == null) || (this.FulfillmentFilter?.Equals(other.FulfillmentFilter) == true)) &&
                ((this.SourceFilter == null && other.SourceFilter == null) || (this.SourceFilter?.Equals(other.SourceFilter) == true)) &&
                ((this.CustomerFilter == null && other.CustomerFilter == null) || (this.CustomerFilter?.Equals(other.CustomerFilter) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -566134060;
            hashCode = HashCode.Combine(this.StateFilter, this.DateTimeFilter, this.FulfillmentFilter, this.SourceFilter, this.CustomerFilter);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.StateFilter = {(this.StateFilter == null ? "null" : this.StateFilter.ToString())}");
            toStringOutput.Add($"this.DateTimeFilter = {(this.DateTimeFilter == null ? "null" : this.DateTimeFilter.ToString())}");
            toStringOutput.Add($"this.FulfillmentFilter = {(this.FulfillmentFilter == null ? "null" : this.FulfillmentFilter.ToString())}");
            toStringOutput.Add($"this.SourceFilter = {(this.SourceFilter == null ? "null" : this.SourceFilter.ToString())}");
            toStringOutput.Add($"this.CustomerFilter = {(this.CustomerFilter == null ? "null" : this.CustomerFilter.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .StateFilter(this.StateFilter)
                .DateTimeFilter(this.DateTimeFilter)
                .FulfillmentFilter(this.FulfillmentFilter)
                .SourceFilter(this.SourceFilter)
                .CustomerFilter(this.CustomerFilter);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.SearchOrdersStateFilter stateFilter;
            private Models.SearchOrdersDateTimeFilter dateTimeFilter;
            private Models.SearchOrdersFulfillmentFilter fulfillmentFilter;
            private Models.SearchOrdersSourceFilter sourceFilter;
            private Models.SearchOrdersCustomerFilter customerFilter;

             /// <summary>
             /// StateFilter.
             /// </summary>
             /// <param name="stateFilter"> stateFilter. </param>
             /// <returns> Builder. </returns>
            public Builder StateFilter(Models.SearchOrdersStateFilter stateFilter)
            {
                this.stateFilter = stateFilter;
                return this;
            }

             /// <summary>
             /// DateTimeFilter.
             /// </summary>
             /// <param name="dateTimeFilter"> dateTimeFilter. </param>
             /// <returns> Builder. </returns>
            public Builder DateTimeFilter(Models.SearchOrdersDateTimeFilter dateTimeFilter)
            {
                this.dateTimeFilter = dateTimeFilter;
                return this;
            }

             /// <summary>
             /// FulfillmentFilter.
             /// </summary>
             /// <param name="fulfillmentFilter"> fulfillmentFilter. </param>
             /// <returns> Builder. </returns>
            public Builder FulfillmentFilter(Models.SearchOrdersFulfillmentFilter fulfillmentFilter)
            {
                this.fulfillmentFilter = fulfillmentFilter;
                return this;
            }

             /// <summary>
             /// SourceFilter.
             /// </summary>
             /// <param name="sourceFilter"> sourceFilter. </param>
             /// <returns> Builder. </returns>
            public Builder SourceFilter(Models.SearchOrdersSourceFilter sourceFilter)
            {
                this.sourceFilter = sourceFilter;
                return this;
            }

             /// <summary>
             /// CustomerFilter.
             /// </summary>
             /// <param name="customerFilter"> customerFilter. </param>
             /// <returns> Builder. </returns>
            public Builder CustomerFilter(Models.SearchOrdersCustomerFilter customerFilter)
            {
                this.customerFilter = customerFilter;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> SearchOrdersFilter. </returns>
            public SearchOrdersFilter Build()
            {
                return new SearchOrdersFilter(
                    this.stateFilter,
                    this.dateTimeFilter,
                    this.fulfillmentFilter,
                    this.sourceFilter,
                    this.customerFilter);
            }
        }
    }
}