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
    public class V1ListTimecardsRequest 
    {
        public V1ListTimecardsRequest(string order = null,
            string employeeId = null,
            string beginClockinTime = null,
            string endClockinTime = null,
            string beginClockoutTime = null,
            string endClockoutTime = null,
            string beginUpdatedAt = null,
            string endUpdatedAt = null,
            bool? deleted = null,
            int? limit = null,
            string batchToken = null)
        {
            Order = order;
            EmployeeId = employeeId;
            BeginClockinTime = beginClockinTime;
            EndClockinTime = endClockinTime;
            BeginClockoutTime = beginClockoutTime;
            EndClockoutTime = endClockoutTime;
            BeginUpdatedAt = beginUpdatedAt;
            EndUpdatedAt = endUpdatedAt;
            Deleted = deleted;
            Limit = limit;
            BatchToken = batchToken;
        }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public string Order { get; }

        /// <summary>
        /// If provided, the endpoint returns only timecards for the employee with the specified ID.
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        /// <summary>
        /// If filtering results by their clockin_time field, the beginning of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("begin_clockin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginClockinTime { get; }

        /// <summary>
        /// If filtering results by their clockin_time field, the end of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_clockin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndClockinTime { get; }

        /// <summary>
        /// If filtering results by their clockout_time field, the beginning of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("begin_clockout_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginClockoutTime { get; }

        /// <summary>
        /// If filtering results by their clockout_time field, the end of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_clockout_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndClockoutTime { get; }

        /// <summary>
        /// If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("begin_updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginUpdatedAt { get; }

        /// <summary>
        /// If filtering results by their updated_at field, the end of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndUpdatedAt { get; }

        /// <summary>
        /// If true, only deleted timecards are returned. If false, only valid timecards are returned.If you don't provide this parameter, both valid and deleted timecards are returned.
        /// </summary>
        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; }

        /// <summary>
        /// The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint.
        /// </summary>
        [JsonProperty("batch_token", NullValueHandling = NullValueHandling.Ignore)]
        public string BatchToken { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(Order)
                .EmployeeId(EmployeeId)
                .BeginClockinTime(BeginClockinTime)
                .EndClockinTime(EndClockinTime)
                .BeginClockoutTime(BeginClockoutTime)
                .EndClockoutTime(EndClockoutTime)
                .BeginUpdatedAt(BeginUpdatedAt)
                .EndUpdatedAt(EndUpdatedAt)
                .Deleted(Deleted)
                .Limit(Limit)
                .BatchToken(BatchToken);
            return builder;
        }

        public class Builder
        {
            private string order;
            private string employeeId;
            private string beginClockinTime;
            private string endClockinTime;
            private string beginClockoutTime;
            private string endClockoutTime;
            private string beginUpdatedAt;
            private string endUpdatedAt;
            private bool? deleted;
            private int? limit;
            private string batchToken;



            public Builder Order(string order)
            {
                this.order = order;
                return this;
            }

            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

            public Builder BeginClockinTime(string beginClockinTime)
            {
                this.beginClockinTime = beginClockinTime;
                return this;
            }

            public Builder EndClockinTime(string endClockinTime)
            {
                this.endClockinTime = endClockinTime;
                return this;
            }

            public Builder BeginClockoutTime(string beginClockoutTime)
            {
                this.beginClockoutTime = beginClockoutTime;
                return this;
            }

            public Builder EndClockoutTime(string endClockoutTime)
            {
                this.endClockoutTime = endClockoutTime;
                return this;
            }

            public Builder BeginUpdatedAt(string beginUpdatedAt)
            {
                this.beginUpdatedAt = beginUpdatedAt;
                return this;
            }

            public Builder EndUpdatedAt(string endUpdatedAt)
            {
                this.endUpdatedAt = endUpdatedAt;
                return this;
            }

            public Builder Deleted(bool? deleted)
            {
                this.deleted = deleted;
                return this;
            }

            public Builder Limit(int? limit)
            {
                this.limit = limit;
                return this;
            }

            public Builder BatchToken(string batchToken)
            {
                this.batchToken = batchToken;
                return this;
            }

            public V1ListTimecardsRequest Build()
            {
                return new V1ListTimecardsRequest(order,
                    employeeId,
                    beginClockinTime,
                    endClockinTime,
                    beginClockoutTime,
                    endClockoutTime,
                    beginUpdatedAt,
                    endUpdatedAt,
                    deleted,
                    limit,
                    batchToken);
            }
        }
    }
}