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
    public class Shift 
    {
        public Shift(string employeeId,
            string startAt,
            string id = null,
            string locationId = null,
            string timezone = null,
            string endAt = null,
            Models.ShiftWage wage = null,
            IList<Models.Break> breaks = null,
            string status = null,
            int? version = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            EmployeeId = employeeId;
            LocationId = locationId;
            Timezone = timezone;
            StartAt = startAt;
            EndAt = endAt;
            Wage = wage;
            Breaks = breaks;
            Status = status;
            Version = version;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// UUID for this object
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The ID of the employee this shift belongs to.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// The ID of the location this shift occurred at. Should be based on
        /// where the employee clocked in.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Read-only convenience value that is calculated from the location based
        /// on `location_id`. Format: the IANA Timezone Database identifier for the
        /// location timezone.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; }

        /// <summary>
        /// RFC 3339; shifted to location timezone + offset. Precision up to the
        /// minute is respected; seconds are truncated.
        /// </summary>
        [JsonProperty("start_at")]
        public string StartAt { get; }

        /// <summary>
        /// RFC 3339; shifted to timezone + offset. Precision up to the minute is
        /// respected; seconds are truncated. The `end_at` minute is not
        /// counted when the shift length is calculated. For example, a shift from `00:00`
        /// to `08:01` is considered an 8 hour shift (midnight to 8am).
        /// </summary>
        [JsonProperty("end_at")]
        public string EndAt { get; }

        /// <summary>
        /// The hourly wage rate used to compensate an employee for this shift.
        /// </summary>
        [JsonProperty("wage")]
        public Models.ShiftWage Wage { get; }

        /// <summary>
        /// A list of any paid or unpaid breaks that were taken during this shift.
        /// </summary>
        [JsonProperty("breaks")]
        public IList<Models.Break> Breaks { get; }

        /// <summary>
        /// Enumerates the possible status of a `Shift`
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// Used for resolving concurrency issues; request will fail if version
        /// provided does not match server version at time of request. If not provided,
        /// Square executes a blind write; potentially overwriting data from another
        /// write.
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format; presented in UTC.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format; presented in UTC.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(EmployeeId,
                StartAt)
                .Id(Id)
                .LocationId(LocationId)
                .Timezone(Timezone)
                .EndAt(EndAt)
                .Wage(Wage)
                .Breaks(Breaks)
                .Status(Status)
                .Version(Version)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private string employeeId;
            private string startAt;
            private string id;
            private string locationId;
            private string timezone;
            private string endAt;
            private Models.ShiftWage wage;
            private IList<Models.Break> breaks;
            private string status;
            private int? version;
            private string createdAt;
            private string updatedAt;

            public Builder(string employeeId,
                string startAt)
            {
                this.employeeId = employeeId;
                this.startAt = startAt;
            }
            public Builder EmployeeId(string value)
            {
                employeeId = value;
                return this;
            }

            public Builder StartAt(string value)
            {
                startAt = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Timezone(string value)
            {
                timezone = value;
                return this;
            }

            public Builder EndAt(string value)
            {
                endAt = value;
                return this;
            }

            public Builder Wage(Models.ShiftWage value)
            {
                wage = value;
                return this;
            }

            public Builder Breaks(IList<Models.Break> value)
            {
                breaks = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
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

            public Shift Build()
            {
                return new Shift(employeeId,
                    startAt,
                    id,
                    locationId,
                    timezone,
                    endAt,
                    wage,
                    breaks,
                    status,
                    version,
                    createdAt,
                    updatedAt);
            }
        }
    }
} 