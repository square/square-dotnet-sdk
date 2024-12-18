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

namespace Square.Models
{
    /// <summary>
    /// BreakType.
    /// </summary>
    public class BreakType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BreakType"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="breakName">break_name.</param>
        /// <param name="expectedDuration">expected_duration.</param>
        /// <param name="isPaid">is_paid.</param>
        /// <param name="id">id.</param>
        /// <param name="version">version.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        public BreakType(
            string locationId,
            string breakName,
            string expectedDuration,
            bool isPaid,
            string id = null,
            int? version = null,
            string createdAt = null,
            string updatedAt = null)
        {
            this.Id = id;
            this.LocationId = locationId;
            this.BreakName = breakName;
            this.ExpectedDuration = expectedDuration;
            this.IsPaid = isPaid;
            this.Version = version;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The UUID for this object.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the business location this type of break applies to.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// A human-readable name for this type of break. The name is displayed to
        /// employees in Square products.
        /// </summary>
        [JsonProperty("break_name")]
        public string BreakName { get; }

        /// <summary>
        /// Format: RFC-3339 P[n]Y[n]M[n]DT[n]H[n]M[n]S. The expected length of
        /// this break. Precision less than minutes is truncated.
        /// Example for break expected duration of 15 minutes: T15M
        /// </summary>
        [JsonProperty("expected_duration")]
        public string ExpectedDuration { get; }

        /// <summary>
        /// Whether this break counts towards time worked for compensation
        /// purposes.
        /// </summary>
        [JsonProperty("is_paid")]
        public bool IsPaid { get; }

        /// <summary>
        /// Used for resolving concurrency issues. The request fails if the version
        /// provided does not match the server version at the time of the request. If a value is not
        /// provided, Square's servers execute a "blind" write; potentially
        /// overwriting another writer's data.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"BreakType : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is BreakType other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.LocationId == null && other.LocationId == null ||
                 this.LocationId?.Equals(other.LocationId) == true) &&
                (this.BreakName == null && other.BreakName == null ||
                 this.BreakName?.Equals(other.BreakName) == true) &&
                (this.ExpectedDuration == null && other.ExpectedDuration == null ||
                 this.ExpectedDuration?.Equals(other.ExpectedDuration) == true) &&
                (this.IsPaid.Equals(other.IsPaid)) &&
                (this.Version == null && other.Version == null ||
                 this.Version?.Equals(other.Version) == true) &&
                (this.CreatedAt == null && other.CreatedAt == null ||
                 this.CreatedAt?.Equals(other.CreatedAt) == true) &&
                (this.UpdatedAt == null && other.UpdatedAt == null ||
                 this.UpdatedAt?.Equals(other.UpdatedAt) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1946622093;
            hashCode = HashCode.Combine(hashCode, this.Id, this.LocationId, this.BreakName, this.ExpectedDuration, this.IsPaid, this.Version, this.CreatedAt);

            hashCode = HashCode.Combine(hashCode, this.UpdatedAt);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
            toStringOutput.Add($"this.BreakName = {this.BreakName ?? "null"}");
            toStringOutput.Add($"this.ExpectedDuration = {this.ExpectedDuration ?? "null"}");
            toStringOutput.Add($"this.IsPaid = {this.IsPaid}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {this.CreatedAt ?? "null"}");
            toStringOutput.Add($"this.UpdatedAt = {this.UpdatedAt ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.LocationId,
                this.BreakName,
                this.ExpectedDuration,
                this.IsPaid)
                .Id(this.Id)
                .Version(this.Version)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string locationId;
            private string breakName;
            private string expectedDuration;
            private bool isPaid;
            private string id;
            private int? version;
            private string createdAt;
            private string updatedAt;

            /// <summary>
            /// Initialize Builder for BreakType.
            /// </summary>
            /// <param name="locationId"> locationId. </param>
            /// <param name="breakName"> breakName. </param>
            /// <param name="expectedDuration"> expectedDuration. </param>
            /// <param name="isPaid"> isPaid. </param>
            public Builder(
                string locationId,
                string breakName,
                string expectedDuration,
                bool isPaid)
            {
                this.locationId = locationId;
                this.breakName = breakName;
                this.expectedDuration = expectedDuration;
                this.isPaid = isPaid;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// BreakName.
             /// </summary>
             /// <param name="breakName"> breakName. </param>
             /// <returns> Builder. </returns>
            public Builder BreakName(string breakName)
            {
                this.breakName = breakName;
                return this;
            }

             /// <summary>
             /// ExpectedDuration.
             /// </summary>
             /// <param name="expectedDuration"> expectedDuration. </param>
             /// <returns> Builder. </returns>
            public Builder ExpectedDuration(string expectedDuration)
            {
                this.expectedDuration = expectedDuration;
                return this;
            }

             /// <summary>
             /// IsPaid.
             /// </summary>
             /// <param name="isPaid"> isPaid. </param>
             /// <returns> Builder. </returns>
            public Builder IsPaid(bool isPaid)
            {
                this.isPaid = isPaid;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BreakType. </returns>
            public BreakType Build()
            {
                return new BreakType(
                    this.locationId,
                    this.breakName,
                    this.expectedDuration,
                    this.isPaid,
                    this.id,
                    this.version,
                    this.createdAt,
                    this.updatedAt);
            }
        }
    }
}