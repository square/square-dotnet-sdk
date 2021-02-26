
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShiftFilter : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"LocationIds = {(LocationIds == null ? "null" : $"[{ string.Join(", ", LocationIds)} ]")}");
            toStringOutput.Add($"EmployeeIds = {(EmployeeIds == null ? "null" : $"[{ string.Join(", ", EmployeeIds)} ]")}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"Start = {(Start == null ? "null" : Start.ToString())}");
            toStringOutput.Add($"End = {(End == null ? "null" : End.ToString())}");
            toStringOutput.Add($"Workday = {(Workday == null ? "null" : Workday.ToString())}");
            toStringOutput.Add($"TeamMemberIds = {(TeamMemberIds == null ? "null" : $"[{ string.Join(", ", TeamMemberIds)} ]")}");
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

            return obj is ShiftFilter other &&
                ((LocationIds == null && other.LocationIds == null) || (LocationIds?.Equals(other.LocationIds) == true)) &&
                ((EmployeeIds == null && other.EmployeeIds == null) || (EmployeeIds?.Equals(other.EmployeeIds) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((Start == null && other.Start == null) || (Start?.Equals(other.Start) == true)) &&
                ((End == null && other.End == null) || (End?.Equals(other.End) == true)) &&
                ((Workday == null && other.Workday == null) || (Workday?.Equals(other.Workday) == true)) &&
                ((TeamMemberIds == null && other.TeamMemberIds == null) || (TeamMemberIds?.Equals(other.TeamMemberIds) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 432854802;

            if (LocationIds != null)
            {
               hashCode += LocationIds.GetHashCode();
            }

            if (EmployeeIds != null)
            {
               hashCode += EmployeeIds.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

            if (Start != null)
            {
               hashCode += Start.GetHashCode();
            }

            if (End != null)
            {
               hashCode += End.GetHashCode();
            }

            if (Workday != null)
            {
               hashCode += Workday.GetHashCode();
            }

            if (TeamMemberIds != null)
            {
               hashCode += TeamMemberIds.GetHashCode();
            }

            return hashCode;
        }

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