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
    public class V1ListCashDrawerShiftsRequest 
    {
        public V1ListCashDrawerShiftsRequest(string order = null,
            string beginTime = null,
            string endTime = null)
        {
            Order = order;
            BeginTime = beginTime;
            EndTime = endTime;
        }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public string Order { get; }

        /// <summary>
        /// The beginning of the requested reporting period, in ISO 8601 format. Default value: The current time minus 90 days.
        /// </summary>
        [JsonProperty("begin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginTime { get; }

        /// <summary>
        /// The beginning of the requested reporting period, in ISO 8601 format. Default value: The current time.
        /// </summary>
        [JsonProperty("end_time", NullValueHandling = NullValueHandling.Ignore)]
        public string EndTime { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(Order)
                .BeginTime(BeginTime)
                .EndTime(EndTime);
            return builder;
        }

        public class Builder
        {
            private string order;
            private string beginTime;
            private string endTime;



            public Builder Order(string order)
            {
                this.order = order;
                return this;
            }

            public Builder BeginTime(string beginTime)
            {
                this.beginTime = beginTime;
                return this;
            }

            public Builder EndTime(string endTime)
            {
                this.endTime = endTime;
                return this;
            }

            public V1ListCashDrawerShiftsRequest Build()
            {
                return new V1ListCashDrawerShiftsRequest(order,
                    beginTime,
                    endTime);
            }
        }
    }
}