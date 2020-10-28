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
    public class ShiftFilter 
    {
        public ShiftFilter(IList<string> locationIds,
            IList<string> teamMemberIds,
            IList<string> employeeIds = null,
            string status = null,
            Models.TimeRange start = null,
            Models.TimeRange end = null,
            Models.ShiftWorkday workday = null)
        {
            LocationIds = locationIds;
            EmployeeIds = employeeIds;
            Status = status;
            Start = start;
            End = end;
            Workday = workday;
            TeamMemberIds = teamMemberIds;
        }

        /// <summary>
        /// Fetch shifts for the specified location.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// Fetch shifts for the specified employees. DEPRECATED at version 2020-08-26. Use `team_member_ids` instead
        /// </summary>
        [JsonProperty("employee_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> EmployeeIds { get; }

        /// <summary>
        /// Specifies the `status` of `Shift` records to be returned.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TimeRange Start { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC 3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevant endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public Models.TimeRange End { get; }

        /// <summary>
        /// A `Shift` search query filter parameter that sets a range of days that
        /// a `Shift` must start or end in before passing the filter condition.
        /// </summary>
        [JsonProperty("workday", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShiftWorkday Workday { get; }

        /// <summary>
        /// Fetch shifts for the specified team members. Replaced `employee_ids` at version "2020-08-26"
        /// </summary>
        [JsonProperty("team_member_ids")]
        public IList<string> TeamMemberIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(LocationIds,
                TeamMemberIds)
                .EmployeeIds(EmployeeIds)
                .Status(Status)
                .Start(Start)
                .End(End)
                .Workday(Workday);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationIds;
            private IList<string> teamMemberIds;
            private IList<string> employeeIds;
            private string status;
            private Models.TimeRange start;
            private Models.TimeRange end;
            private Models.ShiftWorkday workday;

            public Builder(IList<string> locationIds,
                IList<string> teamMemberIds)
            {
                this.locationIds = locationIds;
                this.teamMemberIds = teamMemberIds;
            }

            public Builder LocationIds(IList<string> locationIds)
            {
                this.locationIds = locationIds;
                return this;
            }

            public Builder TeamMemberIds(IList<string> teamMemberIds)
            {
                this.teamMemberIds = teamMemberIds;
                return this;
            }

            public Builder EmployeeIds(IList<string> employeeIds)
            {
                this.employeeIds = employeeIds;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder Start(Models.TimeRange start)
            {
                this.start = start;
                return this;
            }

            public Builder End(Models.TimeRange end)
            {
                this.end = end;
                return this;
            }

            public Builder Workday(Models.ShiftWorkday workday)
            {
                this.workday = workday;
                return this;
            }

            public ShiftFilter Build()
            {
                return new ShiftFilter(locationIds,
                    teamMemberIds,
                    employeeIds,
                    status,
                    start,
                    end,
                    workday);
            }
        }
    }
}