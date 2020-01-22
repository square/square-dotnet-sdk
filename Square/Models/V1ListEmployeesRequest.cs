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
        [JsonProperty("order")]
        public string Order { get; }

        /// <summary>
        /// If filtering results by their updated_at field, the beginning of the requested reporting period, in ISO 8601 format
        /// </summary>
        [JsonProperty("begin_updated_at")]
        public string BeginUpdatedAt { get; }

        /// <summary>
        /// If filtering results by there updated_at field, the end of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_updated_at")]
        public string EndUpdatedAt { get; }

        /// <summary>
        /// If filtering results by their created_at field, the beginning of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("begin_created_at")]
        public string BeginCreatedAt { get; }

        /// <summary>
        /// If filtering results by their created_at field, the end of the requested reporting period, in ISO 8601 format.
        /// </summary>
        [JsonProperty("end_created_at")]
        public string EndCreatedAt { get; }

        /// <summary>
        /// Getter for status
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// If provided, the endpoint returns only employee entities with the specified external_id.
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; }

        /// <summary>
        /// The maximum integer number of employee entities to return in a single response. Default 100, maximum 200.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint.
        /// </summary>
        [JsonProperty("batch_token")]
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

            public Builder() { }
            public Builder Order(string value)
            {
                order = value;
                return this;
            }

            public Builder BeginUpdatedAt(string value)
            {
                beginUpdatedAt = value;
                return this;
            }

            public Builder EndUpdatedAt(string value)
            {
                endUpdatedAt = value;
                return this;
            }

            public Builder BeginCreatedAt(string value)
            {
                beginCreatedAt = value;
                return this;
            }

            public Builder EndCreatedAt(string value)
            {
                endCreatedAt = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder ExternalId(string value)
            {
                externalId = value;
                return this;
            }

            public Builder Limit(int? value)
            {
                limit = value;
                return this;
            }

            public Builder BatchToken(string value)
            {
                batchToken = value;
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