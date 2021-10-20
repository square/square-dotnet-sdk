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
    /// V1ListPaymentsRequest.
    /// </summary>
    public class V1ListPaymentsRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1ListPaymentsRequest"/> class.
        /// </summary>
        /// <param name="order">order.</param>
        /// <param name="beginTime">begin_time.</param>
        /// <param name="endTime">end_time.</param>
        /// <param name="limit">limit.</param>
        /// <param name="batchToken">batch_token.</param>
        /// <param name="includePartial">include_partial.</param>
        public V1ListPaymentsRequest(
            string order = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string batchToken = null,
            bool? includePartial = null)
        {
            this.Order = order;
            this.BeginTime = beginTime;
            this.EndTime = endTime;
            this.Limit = limit;
            this.BatchToken = batchToken;
            this.IncludePartial = includePartial;
        }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public string Order { get; }

        /// <summary>
        /// The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; }

        /// <summary>
        /// The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.
        /// </summary>
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; }

        /// <summary>
        /// The maximum number of payments to return in a single response. This value cannot exceed 200.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint.
        /// </summary>
        [JsonProperty("batch_token", NullValueHandling = NullValueHandling.Ignore)]
        public string BatchToken { get; }

        /// <summary>
        /// Indicates whether or not to include partial payments in the response. Partial payments will have the tenders collected so far, but the itemizations will be empty until the payment is completed.
        /// </summary>
        [JsonProperty("include_partial", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludePartial { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1ListPaymentsRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1ListPaymentsRequest other &&
                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true)) &&
                ((this.BeginTime == null && other.BeginTime == null) || (this.BeginTime?.Equals(other.BeginTime) == true)) &&
                ((this.EndTime == null && other.EndTime == null) || (this.EndTime?.Equals(other.EndTime) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.BatchToken == null && other.BatchToken == null) || (this.BatchToken?.Equals(other.BatchToken) == true)) &&
                ((this.IncludePartial == null && other.IncludePartial == null) || (this.IncludePartial?.Equals(other.IncludePartial) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 358877715;
            hashCode = HashCode.Combine(this.Order, this.BeginTime, this.EndTime, this.Limit, this.BatchToken, this.IncludePartial);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.BeginTime = {(this.BeginTime == null ? "null" : this.BeginTime == string.Empty ? "" : this.BeginTime)}");
            toStringOutput.Add($"this.EndTime = {(this.EndTime == null ? "null" : this.EndTime == string.Empty ? "" : this.EndTime)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.BatchToken = {(this.BatchToken == null ? "null" : this.BatchToken == string.Empty ? "" : this.BatchToken)}");
            toStringOutput.Add($"this.IncludePartial = {(this.IncludePartial == null ? "null" : this.IncludePartial.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(this.Order)
                .BeginTime(this.BeginTime)
                .EndTime(this.EndTime)
                .Limit(this.Limit)
                .BatchToken(this.BatchToken)
                .IncludePartial(this.IncludePartial);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string order;
            private string beginTime;
            private string endTime;
            private int? limit;
            private string batchToken;
            private bool? includePartial;

             /// <summary>
             /// Order.
             /// </summary>
             /// <param name="order"> order. </param>
             /// <returns> Builder. </returns>
            public Builder Order(string order)
            {
                this.order = order;
                return this;
            }

             /// <summary>
             /// BeginTime.
             /// </summary>
             /// <param name="beginTime"> beginTime. </param>
             /// <returns> Builder. </returns>
            public Builder BeginTime(string beginTime)
            {
                this.beginTime = beginTime;
                return this;
            }

             /// <summary>
             /// EndTime.
             /// </summary>
             /// <param name="endTime"> endTime. </param>
             /// <returns> Builder. </returns>
            public Builder EndTime(string endTime)
            {
                this.endTime = endTime;
                return this;
            }

             /// <summary>
             /// Limit.
             /// </summary>
             /// <param name="limit"> limit. </param>
             /// <returns> Builder. </returns>
            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

             /// <summary>
             /// BatchToken.
             /// </summary>
             /// <param name="batchToken"> batchToken. </param>
             /// <returns> Builder. </returns>
            public Builder BatchToken(string batchToken)
            {
                this.batchToken = batchToken;
                return this;
            }

             /// <summary>
             /// IncludePartial.
             /// </summary>
             /// <param name="includePartial"> includePartial. </param>
             /// <returns> Builder. </returns>
            public Builder IncludePartial(bool? includePartial)
            {
                this.includePartial = includePartial;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1ListPaymentsRequest. </returns>
            public V1ListPaymentsRequest Build()
            {
                return new V1ListPaymentsRequest(
                    this.order,
                    this.beginTime,
                    this.endTime,
                    this.limit,
                    this.batchToken,
                    this.includePartial);
            }
        }
    }
}