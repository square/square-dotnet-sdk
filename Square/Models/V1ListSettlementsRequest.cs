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
    /// V1ListSettlementsRequest.
    /// </summary>
    public class V1ListSettlementsRequest
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="V1ListSettlementsRequest"/> class.
        /// </summary>
        /// <param name="order">order.</param>
        /// <param name="beginTime">begin_time.</param>
        /// <param name="endTime">end_time.</param>
        /// <param name="limit">limit.</param>
        /// <param name="status">status.</param>
        /// <param name="batchToken">batch_token.</param>
        public V1ListSettlementsRequest(
            string order = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string status = null,
            string batchToken = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "begin_time", false },
                { "end_time", false },
                { "limit", false },
                { "batch_token", false }
            };

            this.Order = order;
            if (beginTime != null)
            {
                shouldSerialize["begin_time"] = true;
                this.BeginTime = beginTime;
            }

            if (endTime != null)
            {
                shouldSerialize["end_time"] = true;
                this.EndTime = endTime;
            }

            if (limit != null)
            {
                shouldSerialize["limit"] = true;
                this.Limit = limit;
            }

            this.Status = status;
            if (batchToken != null)
            {
                shouldSerialize["batch_token"] = true;
                this.BatchToken = batchToken;
            }

        }
        internal V1ListSettlementsRequest(Dictionary<string, bool> shouldSerialize,
            string order = null,
            string beginTime = null,
            string endTime = null,
            int? limit = null,
            string status = null,
            string batchToken = null)
        {
            this.shouldSerialize = shouldSerialize;
            Order = order;
            BeginTime = beginTime;
            EndTime = endTime;
            Limit = limit;
            Status = status;
            BatchToken = batchToken;
        }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public string Order { get; }

        /// <summary>
        /// The beginning of the requested reporting period, in ISO 8601 format. If this value is before January 1, 2013 (2013-01-01T00:00:00Z), this endpoint returns an error. Default value: The current time minus one year.
        /// </summary>
        [JsonProperty("begin_time")]
        public string BeginTime { get; }

        /// <summary>
        /// The end of the requested reporting period, in ISO 8601 format. If this value is more than one year greater than begin_time, this endpoint returns an error. Default value: The current time.
        /// </summary>
        [JsonProperty("end_time")]
        public string EndTime { get; }

        /// <summary>
        /// The maximum number of settlements to return in a single response. This value cannot exceed 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint.
        /// </summary>
        [JsonProperty("batch_token")]
        public string BatchToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1ListSettlementsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBeginTime()
        {
            return this.shouldSerialize["begin_time"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndTime()
        {
            return this.shouldSerialize["end_time"];
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
        public bool ShouldSerializeBatchToken()
        {
            return this.shouldSerialize["batch_token"];
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
            return obj is V1ListSettlementsRequest other &&                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true)) &&
                ((this.BeginTime == null && other.BeginTime == null) || (this.BeginTime?.Equals(other.BeginTime) == true)) &&
                ((this.EndTime == null && other.EndTime == null) || (this.EndTime?.Equals(other.EndTime) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.BatchToken == null && other.BatchToken == null) || (this.BatchToken?.Equals(other.BatchToken) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 331726736;
            hashCode = HashCode.Combine(this.Order, this.BeginTime, this.EndTime, this.Limit, this.Status, this.BatchToken);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.BeginTime = {(this.BeginTime == null ? "null" : this.BeginTime)}");
            toStringOutput.Add($"this.EndTime = {(this.EndTime == null ? "null" : this.EndTime)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.BatchToken = {(this.BatchToken == null ? "null" : this.BatchToken)}");
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
                .Status(this.Status)
                .BatchToken(this.BatchToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "begin_time", false },
                { "end_time", false },
                { "limit", false },
                { "batch_token", false },
            };

            private string order;
            private string beginTime;
            private string endTime;
            private int? limit;
            private string status;
            private string batchToken;

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
                shouldSerialize["begin_time"] = true;
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
                shouldSerialize["end_time"] = true;
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
                shouldSerialize["limit"] = true;
                this.limit = limit;
                return this;
            }

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
             /// BatchToken.
             /// </summary>
             /// <param name="batchToken"> batchToken. </param>
             /// <returns> Builder. </returns>
            public Builder BatchToken(string batchToken)
            {
                shouldSerialize["batch_token"] = true;
                this.batchToken = batchToken;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBeginTime()
            {
                this.shouldSerialize["begin_time"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEndTime()
            {
                this.shouldSerialize["end_time"] = false;
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
            public void UnsetBatchToken()
            {
                this.shouldSerialize["batch_token"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1ListSettlementsRequest. </returns>
            public V1ListSettlementsRequest Build()
            {
                return new V1ListSettlementsRequest(shouldSerialize,
                    this.order,
                    this.beginTime,
                    this.endTime,
                    this.limit,
                    this.status,
                    this.batchToken);
            }
        }
    }
}