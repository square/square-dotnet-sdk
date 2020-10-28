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
    public class V1ListEmployeesRequest 
    {
        public V1ListEmployeesRequest(string order = null,
            string beginUpdatedAt = null,
            string endUpdatedAt = null,
            string beginCreatedAt = null,
            string endCreatedAt = null,
            string status = null,
            string externalId = null,
            int? limit = null,
            string batchToken = null)
        {
            Order = order;
            BeginUpdatedAt = beginUpdatedAt;
            EndUpdatedAt = endUpdatedAt;
            BeginCreatedAt = beginCreatedAt;
            EndCreatedAt = endCreatedAt;
            Status = status;
            ExternalId = externalId;
            Limit = limit;
            BatchToken = batchToken;
        }

        /// <summary>
        /// The order (e.g., chronological or alphabetical) in which results from a request are returned.
        /// </summary>
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public string Order { get; }

        /// <summary>
        /// If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format
        /// </summary>
        [JsonProperty("begin_updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginUpdatedAt { get; }

        /// <summary>
        /// If filtering results by there updated_at field, the end of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndUpdatedAt { get; }

        /// <summary>
        /// If filtering results by their created_at field, the beginning of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("begin_created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string BeginCreatedAt { get; }

        /// <summary>
        /// If filtering results by their created_at field, the end of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndCreatedAt { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// If provided, the endpoint returns only employee entities with the specified external_id.
        /// </summary>
        [JsonProperty("external_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalId { get; }

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
                .BeginUpdatedAt(BeginUpdatedAt)
                .EndUpdatedAt(EndUpdatedAt)
                .BeginCreatedAt(BeginCreatedAt)
                .EndCreatedAt(EndCreatedAt)
                .Status(Status)
                .ExternalId(ExternalId)
                .Limit(Limit)
                .BatchToken(BatchToken);
            return builder;
        }

        public class Builder
        {
            private string order;
            private string beginUpdatedAt;
            private string endUpdatedAt;
            private string beginCreatedAt;
            private string endCreatedAt;
            private string status;
            private string externalId;
            private int? limit;
            private string batchToken;



            public Builder Order(string order)
            {
                this.order = order;
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

            public Builder BeginCreatedAt(string beginCreatedAt)
            {
                this.beginCreatedAt = beginCreatedAt;
                return this;
            }

            public Builder EndCreatedAt(string endCreatedAt)
            {
                this.endCreatedAt = endCreatedAt;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder ExternalId(string externalId)
            {
                this.externalId = externalId;
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

            public V1ListEmployeesRequest Build()
            {
                return new V1ListEmployeesRequest(order,
                    beginUpdatedAt,
                    endUpdatedAt,
                    beginCreatedAt,
                    endCreatedAt,
                    status,
                    externalId,
                    limit,
                    batchToken);
            }
        }
    }
}