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
    /// V1ListEmployeesRequest.
    /// </summary>
    public class V1ListEmployeesRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1ListEmployeesRequest"/> class.
        /// </summary>
        /// <param name="order">order.</param>
        /// <param name="beginUpdatedAt">begin_updated_at.</param>
        /// <param name="endUpdatedAt">end_updated_at.</param>
        /// <param name="beginCreatedAt">begin_created_at.</param>
        /// <param name="endCreatedAt">end_created_at.</param>
        /// <param name="status">status.</param>
        /// <param name="externalId">external_id.</param>
        /// <param name="limit">limit.</param>
        /// <param name="batchToken">batch_token.</param>
        public V1ListEmployeesRequest(
            string order = null,
            string beginUpdatedAt = null,
            string endUpdatedAt = null,
            string beginCreatedAt = null,
            string endCreatedAt = null,
            string status = null,
            string externalId = null,
            int? limit = null,
            string batchToken = null)
        {
            this.Order = order;
            this.BeginUpdatedAt = beginUpdatedAt;
            this.EndUpdatedAt = endUpdatedAt;
            this.BeginCreatedAt = beginCreatedAt;
            this.EndCreatedAt = endCreatedAt;
            this.Status = status;
            this.ExternalId = externalId;
            this.Limit = limit;
            this.BatchToken = batchToken;
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
        /// Gets or sets Status.
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"V1ListEmployeesRequest : ({string.Join(", ", toStringOutput)})";
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

            return obj is V1ListEmployeesRequest other &&
                ((this.Order == null && other.Order == null) || (this.Order?.Equals(other.Order) == true)) &&
                ((this.BeginUpdatedAt == null && other.BeginUpdatedAt == null) || (this.BeginUpdatedAt?.Equals(other.BeginUpdatedAt) == true)) &&
                ((this.EndUpdatedAt == null && other.EndUpdatedAt == null) || (this.EndUpdatedAt?.Equals(other.EndUpdatedAt) == true)) &&
                ((this.BeginCreatedAt == null && other.BeginCreatedAt == null) || (this.BeginCreatedAt?.Equals(other.BeginCreatedAt) == true)) &&
                ((this.EndCreatedAt == null && other.EndCreatedAt == null) || (this.EndCreatedAt?.Equals(other.EndCreatedAt) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.ExternalId == null && other.ExternalId == null) || (this.ExternalId?.Equals(other.ExternalId) == true)) &&
                ((this.Limit == null && other.Limit == null) || (this.Limit?.Equals(other.Limit) == true)) &&
                ((this.BatchToken == null && other.BatchToken == null) || (this.BatchToken?.Equals(other.BatchToken) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1221038871;

            if (this.Order != null)
            {
               hashCode += this.Order.GetHashCode();
            }

            if (this.BeginUpdatedAt != null)
            {
               hashCode += this.BeginUpdatedAt.GetHashCode();
            }

            if (this.EndUpdatedAt != null)
            {
               hashCode += this.EndUpdatedAt.GetHashCode();
            }

            if (this.BeginCreatedAt != null)
            {
               hashCode += this.BeginCreatedAt.GetHashCode();
            }

            if (this.EndCreatedAt != null)
            {
               hashCode += this.EndCreatedAt.GetHashCode();
            }

            if (this.Status != null)
            {
               hashCode += this.Status.GetHashCode();
            }

            if (this.ExternalId != null)
            {
               hashCode += this.ExternalId.GetHashCode();
            }

            if (this.Limit != null)
            {
               hashCode += this.Limit.GetHashCode();
            }

            if (this.BatchToken != null)
            {
               hashCode += this.BatchToken.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Order = {(this.Order == null ? "null" : this.Order.ToString())}");
            toStringOutput.Add($"this.BeginUpdatedAt = {(this.BeginUpdatedAt == null ? "null" : this.BeginUpdatedAt == string.Empty ? "" : this.BeginUpdatedAt)}");
            toStringOutput.Add($"this.EndUpdatedAt = {(this.EndUpdatedAt == null ? "null" : this.EndUpdatedAt == string.Empty ? "" : this.EndUpdatedAt)}");
            toStringOutput.Add($"this.BeginCreatedAt = {(this.BeginCreatedAt == null ? "null" : this.BeginCreatedAt == string.Empty ? "" : this.BeginCreatedAt)}");
            toStringOutput.Add($"this.EndCreatedAt = {(this.EndCreatedAt == null ? "null" : this.EndCreatedAt == string.Empty ? "" : this.EndCreatedAt)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.ExternalId = {(this.ExternalId == null ? "null" : this.ExternalId == string.Empty ? "" : this.ExternalId)}");
            toStringOutput.Add($"this.Limit = {(this.Limit == null ? "null" : this.Limit.ToString())}");
            toStringOutput.Add($"this.BatchToken = {(this.BatchToken == null ? "null" : this.BatchToken == string.Empty ? "" : this.BatchToken)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Order(this.Order)
                .BeginUpdatedAt(this.BeginUpdatedAt)
                .EndUpdatedAt(this.EndUpdatedAt)
                .BeginCreatedAt(this.BeginCreatedAt)
                .EndCreatedAt(this.EndCreatedAt)
                .Status(this.Status)
                .ExternalId(this.ExternalId)
                .Limit(this.Limit)
                .BatchToken(this.BatchToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
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
             /// BeginUpdatedAt.
             /// </summary>
             /// <param name="beginUpdatedAt"> beginUpdatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder BeginUpdatedAt(string beginUpdatedAt)
            {
                this.beginUpdatedAt = beginUpdatedAt;
                return this;
            }

             /// <summary>
             /// EndUpdatedAt.
             /// </summary>
             /// <param name="endUpdatedAt"> endUpdatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder EndUpdatedAt(string endUpdatedAt)
            {
                this.endUpdatedAt = endUpdatedAt;
                return this;
            }

             /// <summary>
             /// BeginCreatedAt.
             /// </summary>
             /// <param name="beginCreatedAt"> beginCreatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder BeginCreatedAt(string beginCreatedAt)
            {
                this.beginCreatedAt = beginCreatedAt;
                return this;
            }

             /// <summary>
             /// EndCreatedAt.
             /// </summary>
             /// <param name="endCreatedAt"> endCreatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder EndCreatedAt(string endCreatedAt)
            {
                this.endCreatedAt = endCreatedAt;
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
             /// ExternalId.
             /// </summary>
             /// <param name="externalId"> externalId. </param>
             /// <returns> Builder. </returns>
            public Builder ExternalId(string externalId)
            {
                this.externalId = externalId;
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
            /// Builds class object.
            /// </summary>
            /// <returns> V1ListEmployeesRequest. </returns>
            public V1ListEmployeesRequest Build()
            {
                return new V1ListEmployeesRequest(
                    this.order,
                    this.beginUpdatedAt,
                    this.endUpdatedAt,
                    this.beginCreatedAt,
                    this.endCreatedAt,
                    this.status,
                    this.externalId,
                    this.limit,
                    this.batchToken);
            }
        }
    }
}