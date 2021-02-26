
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
    public class BreakType 
    {
        public BreakType(string locationId,
            string breakName,
            string expectedDuration,
            bool isPaid,
            string id = null,
            int? version = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            LocationId = locationId;
            BreakName = breakName;
            ExpectedDuration = expectedDuration;
            IsPaid = isPaid;
            Version = version;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// UUID for this object.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the business location this type of break applies to.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// A human-readable name for this type of break. Will be displayed to
        /// employees in Square products.
        /// </summary>
        [JsonProperty("break_name")]
        public string BreakName { get; }

        /// <summary>
        /// Format: RFC-3339 P[n]Y[n]M[n]DT[n]H[n]M[n]S. The expected length of
        /// this break. Precision below minutes is truncated.
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
        /// Used for resolving concurrency issues; request will fail if version
        /// provided does not match server version at time of request. If a value is not
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BreakType : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"BreakName = {(BreakName == null ? "null" : BreakName == string.Empty ? "" : BreakName)}");
            toStringOutput.Add($"ExpectedDuration = {(ExpectedDuration == null ? "null" : ExpectedDuration == string.Empty ? "" : ExpectedDuration)}");
            toStringOutput.Add($"IsPaid = {IsPaid}");
            toStringOutput.Add($"Version = {(Version == null ? "null" : Version.ToString())}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
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

            return obj is BreakType other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((BreakName == null && other.BreakName == null) || (BreakName?.Equals(other.BreakName) == true)) &&
                ((ExpectedDuration == null && other.ExpectedDuration == null) || (ExpectedDuration?.Equals(other.ExpectedDuration) == true)) &&
                IsPaid.Equals(other.IsPaid) &&
                ((Version == null && other.Version == null) || (Version?.Equals(other.Version) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1946622093;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (BreakName != null)
            {
               hashCode += BreakName.GetHashCode();
            }

            if (ExpectedDuration != null)
            {
               hashCode += ExpectedDuration.GetHashCode();
            }
            hashCode += IsPaid.GetHashCode();

            if (Version != null)
            {
               hashCode += Version.GetHashCode();
            }

            if (CreatedAt != null)
            {
               hashCode += CreatedAt.GetHashCode();
            }

            if (UpdatedAt != null)
            {
               hashCode += UpdatedAt.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationId,
                BreakName,
                ExpectedDuration,
                IsPaid)
                .Id(Id)
                .Version(Version)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

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

            public Builder(string locationId,
                string breakName,
                string expectedDuration,
                bool isPaid)
            {
                this.locationId = locationId;
                this.breakName = breakName;
                this.expectedDuration = expectedDuration;
                this.isPaid = isPaid;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder BreakName(string breakName)
            {
                this.breakName = breakName;
                return this;
            }

            public Builder ExpectedDuration(string expectedDuration)
            {
                this.expectedDuration = expectedDuration;
                return this;
            }

            public Builder IsPaid(bool isPaid)
            {
                this.isPaid = isPaid;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public BreakType Build()
            {
                return new BreakType(locationId,
                    breakName,
                    expectedDuration,
                    isPaid,
                    id,
                    version,
                    createdAt,
                    updatedAt);
            }
        }
    }
}