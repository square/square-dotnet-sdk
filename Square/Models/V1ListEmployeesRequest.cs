
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1ListEmployeesRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Order = {(Order == null ? "null" : Order.ToString())}");
            toStringOutput.Add($"BeginUpdatedAt = {(BeginUpdatedAt == null ? "null" : BeginUpdatedAt == string.Empty ? "" : BeginUpdatedAt)}");
            toStringOutput.Add($"EndUpdatedAt = {(EndUpdatedAt == null ? "null" : EndUpdatedAt == string.Empty ? "" : EndUpdatedAt)}");
            toStringOutput.Add($"BeginCreatedAt = {(BeginCreatedAt == null ? "null" : BeginCreatedAt == string.Empty ? "" : BeginCreatedAt)}");
            toStringOutput.Add($"EndCreatedAt = {(EndCreatedAt == null ? "null" : EndCreatedAt == string.Empty ? "" : EndCreatedAt)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"ExternalId = {(ExternalId == null ? "null" : ExternalId == string.Empty ? "" : ExternalId)}");
            toStringOutput.Add($"Limit = {(Limit == null ? "null" : Limit.ToString())}");
            toStringOutput.Add($"BatchToken = {(BatchToken == null ? "null" : BatchToken == string.Empty ? "" : BatchToken)}");
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

            return obj is V1ListEmployeesRequest other &&
                ((Order == null && other.Order == null) || (Order?.Equals(other.Order) == true)) &&
                ((BeginUpdatedAt == null && other.BeginUpdatedAt == null) || (BeginUpdatedAt?.Equals(other.BeginUpdatedAt) == true)) &&
                ((EndUpdatedAt == null && other.EndUpdatedAt == null) || (EndUpdatedAt?.Equals(other.EndUpdatedAt) == true)) &&
                ((BeginCreatedAt == null && other.BeginCreatedAt == null) || (BeginCreatedAt?.Equals(other.BeginCreatedAt) == true)) &&
                ((EndCreatedAt == null && other.EndCreatedAt == null) || (EndCreatedAt?.Equals(other.EndCreatedAt) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((ExternalId == null && other.ExternalId == null) || (ExternalId?.Equals(other.ExternalId) == true)) &&
                ((Limit == null && other.Limit == null) || (Limit?.Equals(other.Limit) == true)) &&
                ((BatchToken == null && other.BatchToken == null) || (BatchToken?.Equals(other.BatchToken) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1221038871;

            if (Order != null)
            {
               hashCode += Order.GetHashCode();
            }

            if (BeginUpdatedAt != null)
            {
               hashCode += BeginUpdatedAt.GetHashCode();
            }

            if (EndUpdatedAt != null)
            {
               hashCode += EndUpdatedAt.GetHashCode();
            }

            if (BeginCreatedAt != null)
            {
               hashCode += BeginCreatedAt.GetHashCode();
            }

            if (EndCreatedAt != null)
            {
               hashCode += EndCreatedAt.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (ExternalId != null)
            {
               hashCode += ExternalId.GetHashCode();
            }

            if (Limit != null)
            {
               hashCode += Limit.GetHashCode();
            }

            if (BatchToken != null)
            {
               hashCode += BatchToken.GetHashCode();
            }

            return hashCode;
        }

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