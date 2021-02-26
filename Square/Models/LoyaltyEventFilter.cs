
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class LoyaltyEventFilter 
    {
        public LoyaltyEventFilter(Models.LoyaltyEventLoyaltyAccountFilter loyaltyAccountFilter = null,
            Models.LoyaltyEventTypeFilter typeFilter = null,
            Models.LoyaltyEventDateTimeFilter dateTimeFilter = null,
            Models.LoyaltyEventLocationFilter locationFilter = null,
            Models.LoyaltyEventOrderFilter orderFilter = null)
        {
            LoyaltyAccountFilter = loyaltyAccountFilter;
            TypeFilter = typeFilter;
            DateTimeFilter = dateTimeFilter;
            LocationFilter = locationFilter;
            OrderFilter = orderFilter;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"LoyaltyEventFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LoyaltyAccountFilter = {(LoyaltyAccountFilter == null ? "null" : LoyaltyAccountFilter.ToString())}");
            toStringOutput.Add($"TypeFilter = {(TypeFilter == null ? "null" : TypeFilter.ToString())}");
            toStringOutput.Add($"DateTimeFilter = {(DateTimeFilter == null ? "null" : DateTimeFilter.ToString())}");
            toStringOutput.Add($"LocationFilter = {(LocationFilter == null ? "null" : LocationFilter.ToString())}");
            toStringOutput.Add($"OrderFilter = {(OrderFilter == null ? "null" : OrderFilter.ToString())}");
        }

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
                ((LoyaltyAccountFilter == null && other.LoyaltyAccountFilter == null) || (LoyaltyAccountFilter?.Equals(other.LoyaltyAccountFilter) == true)) &&
                ((TypeFilter == null && other.TypeFilter == null) || (TypeFilter?.Equals(other.TypeFilter) == true)) &&
                ((DateTimeFilter == null && other.DateTimeFilter == null) || (DateTimeFilter?.Equals(other.DateTimeFilter) == true)) &&
                ((LocationFilter == null && other.LocationFilter == null) || (LocationFilter?.Equals(other.LocationFilter) == true)) &&
                ((OrderFilter == null && other.OrderFilter == null) || (OrderFilter?.Equals(other.OrderFilter) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1266972041;

            if (LoyaltyAccountFilter != null)
            {
               hashCode += LoyaltyAccountFilter.GetHashCode();
            }

            if (TypeFilter != null)
            {
               hashCode += TypeFilter.GetHashCode();
            }

            if (DateTimeFilter != null)
            {
               hashCode += DateTimeFilter.GetHashCode();
            }

            if (LocationFilter != null)
            {
               hashCode += LocationFilter.GetHashCode();
            }

            if (OrderFilter != null)
            {
               hashCode += OrderFilter.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LoyaltyAccountFilter(LoyaltyAccountFilter)
                .TypeFilter(TypeFilter)
                .DateTimeFilter(DateTimeFilter)
                .LocationFilter(LocationFilter)
                .OrderFilter(OrderFilter);
            return builder;
        }

        public class Builder
        {
            private Models.LoyaltyEventLoyaltyAccountFilter loyaltyAccountFilter;
            private Models.LoyaltyEventTypeFilter typeFilter;
            private Models.LoyaltyEventDateTimeFilter dateTimeFilter;
            private Models.LoyaltyEventLocationFilter locationFilter;
            private Models.LoyaltyEventOrderFilter orderFilter;



            public Builder LoyaltyAccountFilter(Models.LoyaltyEventLoyaltyAccountFilter loyaltyAccountFilter)
            {
                this.loyaltyAccountFilter = loyaltyAccountFilter;
                return this;
            }

            public Builder TypeFilter(Models.LoyaltyEventTypeFilter typeFilter)
            {
                this.typeFilter = typeFilter;
                return this;
            }

            public Builder DateTimeFilter(Models.LoyaltyEventDateTimeFilter dateTimeFilter)
            {
                this.dateTimeFilter = dateTimeFilter;
                return this;
            }

            public Builder LocationFilter(Models.LoyaltyEventLocationFilter locationFilter)
            {
                this.locationFilter = locationFilter;
                return this;
            }

            public Builder OrderFilter(Models.LoyaltyEventOrderFilter orderFilter)
            {
                this.orderFilter = orderFilter;
                return this;
            }

            public LoyaltyEventFilter Build()
            {
                return new LoyaltyEventFilter(loyaltyAccountFilter,
                    typeFilter,
                    dateTimeFilter,
                    locationFilter,
                    orderFilter);
            }
        }
    }
}