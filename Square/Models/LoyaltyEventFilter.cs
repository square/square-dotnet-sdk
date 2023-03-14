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
    /// LoyaltyEventFilter.
    /// </summary>
    public class LoyaltyEventFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoyaltyEventFilter"/> class.
        /// </summary>
        /// <param name="loyaltyAccountFilter">loyalty_account_filter.</param>
        /// <param name="typeFilter">type_filter.</param>
        /// <param name="dateTimeFilter">date_time_filter.</param>
        /// <param name="locationFilter">location_filter.</param>
        /// <param name="orderFilter">order_filter.</param>
        public LoyaltyEventFilter(
            Models.LoyaltyEventLoyaltyAccountFilter loyaltyAccountFilter = null,
            Models.LoyaltyEventTypeFilter typeFilter = null,
            Models.LoyaltyEventDateTimeFilter dateTimeFilter = null,
            Models.LoyaltyEventLocationFilter locationFilter = null,
            Models.LoyaltyEventOrderFilter orderFilter = null)
        {
            this.LoyaltyAccountFilter = loyaltyAccountFilter;
            this.TypeFilter = typeFilter;
            this.DateTimeFilter = dateTimeFilter;
            this.LocationFilter = locationFilter;
            this.OrderFilter = orderFilter;
        }

        /// <summary>
        /// Filter events by loyalty account.
        /// </summary>
        [JsonProperty("loyalty_account_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventLoyaltyAccountFilter LoyaltyAccountFilter { get; }

        /// <summary>
        /// Filter events by event type.
        /// </summary>
        [JsonProperty("type_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventTypeFilter TypeFilter { get; }

        /// <summary>
        /// Filter events by date time range.
        /// </summary>
        [JsonProperty("date_time_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventDateTimeFilter DateTimeFilter { get; }

        /// <summary>
        /// Filter events by location.
        /// </summary>
        [JsonProperty("location_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventLocationFilter LocationFilter { get; }

        /// <summary>
        /// Filter events by the order associated with the event.
        /// </summary>
        [JsonProperty("order_filter", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyEventOrderFilter OrderFilter { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventFilter : ({string.Join(", ", toStringOutput)})";
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

            return obj is LoyaltyEventFilter other &&
                ((this.LoyaltyAccountFilter == null && other.LoyaltyAccountFilter == null) || (this.LoyaltyAccountFilter?.Equals(other.LoyaltyAccountFilter) == true)) &&
                ((this.TypeFilter == null && other.TypeFilter == null) || (this.TypeFilter?.Equals(other.TypeFilter) == true)) &&
                ((this.DateTimeFilter == null && other.DateTimeFilter == null) || (this.DateTimeFilter?.Equals(other.DateTimeFilter) == true)) &&
                ((this.LocationFilter == null && other.LocationFilter == null) || (this.LocationFilter?.Equals(other.LocationFilter) == true)) &&
                ((this.OrderFilter == null && other.OrderFilter == null) || (this.OrderFilter?.Equals(other.OrderFilter) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1266972041;
            hashCode = HashCode.Combine(this.LoyaltyAccountFilter, this.TypeFilter, this.DateTimeFilter, this.LocationFilter, this.OrderFilter);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LoyaltyAccountFilter = {(this.LoyaltyAccountFilter == null ? "null" : this.LoyaltyAccountFilter.ToString())}");
            toStringOutput.Add($"this.TypeFilter = {(this.TypeFilter == null ? "null" : this.TypeFilter.ToString())}");
            toStringOutput.Add($"this.DateTimeFilter = {(this.DateTimeFilter == null ? "null" : this.DateTimeFilter.ToString())}");
            toStringOutput.Add($"this.LocationFilter = {(this.LocationFilter == null ? "null" : this.LocationFilter.ToString())}");
            toStringOutput.Add($"this.OrderFilter = {(this.OrderFilter == null ? "null" : this.OrderFilter.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LoyaltyAccountFilter(this.LoyaltyAccountFilter)
                .TypeFilter(this.TypeFilter)
                .DateTimeFilter(this.DateTimeFilter)
                .LocationFilter(this.LocationFilter)
                .OrderFilter(this.OrderFilter);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.LoyaltyEventLoyaltyAccountFilter loyaltyAccountFilter;
            private Models.LoyaltyEventTypeFilter typeFilter;
            private Models.LoyaltyEventDateTimeFilter dateTimeFilter;
            private Models.LoyaltyEventLocationFilter locationFilter;
            private Models.LoyaltyEventOrderFilter orderFilter;

             /// <summary>
             /// LoyaltyAccountFilter.
             /// </summary>
             /// <param name="loyaltyAccountFilter"> loyaltyAccountFilter. </param>
             /// <returns> Builder. </returns>
            public Builder LoyaltyAccountFilter(Models.LoyaltyEventLoyaltyAccountFilter loyaltyAccountFilter)
            {
                this.loyaltyAccountFilter = loyaltyAccountFilter;
                return this;
            }

             /// <summary>
             /// TypeFilter.
             /// </summary>
             /// <param name="typeFilter"> typeFilter. </param>
             /// <returns> Builder. </returns>
            public Builder TypeFilter(Models.LoyaltyEventTypeFilter typeFilter)
            {
                this.typeFilter = typeFilter;
                return this;
            }

             /// <summary>
             /// DateTimeFilter.
             /// </summary>
             /// <param name="dateTimeFilter"> dateTimeFilter. </param>
             /// <returns> Builder. </returns>
            public Builder DateTimeFilter(Models.LoyaltyEventDateTimeFilter dateTimeFilter)
            {
                this.dateTimeFilter = dateTimeFilter;
                return this;
            }

             /// <summary>
             /// LocationFilter.
             /// </summary>
             /// <param name="locationFilter"> locationFilter. </param>
             /// <returns> Builder. </returns>
            public Builder LocationFilter(Models.LoyaltyEventLocationFilter locationFilter)
            {
                this.locationFilter = locationFilter;
                return this;
            }

             /// <summary>
             /// OrderFilter.
             /// </summary>
             /// <param name="orderFilter"> orderFilter. </param>
             /// <returns> Builder. </returns>
            public Builder OrderFilter(Models.LoyaltyEventOrderFilter orderFilter)
            {
                this.orderFilter = orderFilter;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> LoyaltyEventFilter. </returns>
            public LoyaltyEventFilter Build()
            {
                return new LoyaltyEventFilter(
                    this.loyaltyAccountFilter,
                    this.typeFilter,
                    this.dateTimeFilter,
                    this.locationFilter,
                    this.orderFilter);
            }
        }
    }
}