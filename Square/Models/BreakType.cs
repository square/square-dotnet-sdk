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
        [JsonProperty("id")]
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
        [JsonProperty("version")]
        public int? Version { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

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
            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder BreakName(string value)
            {
                breakName = value;
                return this;
            }

            public Builder ExpectedDuration(string value)
            {
                expectedDuration = value;
                return this;
            }

            public Builder IsPaid(bool value)
            {
                isPaid = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Version(int? value)
            {
                version = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
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