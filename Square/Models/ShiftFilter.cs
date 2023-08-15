namespace Square.Models
{
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

    /// <summary>
    /// ShiftFilter.
    /// </summary>
    public class ShiftFilter
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShiftFilter"/> class.
        /// </summary>
        /// <param name="locationIds">location_ids.</param>
        /// <param name="employeeIds">employee_ids.</param>
        /// <param name="status">status.</param>
        /// <param name="start">start.</param>
        /// <param name="end">end.</param>
        /// <param name="workday">workday.</param>
        /// <param name="teamMemberIds">team_member_ids.</param>
        public ShiftFilter(
            IList<string> locationIds = null,
            IList<string> employeeIds = null,
            string status = null,
            Models.TimeRange start = null,
            Models.TimeRange end = null,
            Models.ShiftWorkday workday = null,
            IList<string> teamMemberIds = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_ids", false },
                { "employee_ids", false },
                { "team_member_ids", false }
            };

            if (locationIds != null)
            {
                shouldSerialize["location_ids"] = true;
                this.LocationIds = locationIds;
            }

            if (employeeIds != null)
            {
                shouldSerialize["employee_ids"] = true;
                this.EmployeeIds = employeeIds;
            }

            this.Status = status;
            this.Start = start;
            this.End = end;
            this.Workday = workday;
            if (teamMemberIds != null)
            {
                shouldSerialize["team_member_ids"] = true;
                this.TeamMemberIds = teamMemberIds;
            }

        }
        internal ShiftFilter(Dictionary<string, bool> shouldSerialize,
            IList<string> locationIds = null,
            IList<string> employeeIds = null,
            string status = null,
            Models.TimeRange start = null,
            Models.TimeRange end = null,
            Models.ShiftWorkday workday = null,
            IList<string> teamMemberIds = null)
        {
            this.shouldSerialize = shouldSerialize;
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
        /// Fetch shifts for the specified employees. DEPRECATED at version 2020-08-26. Use `team_member_ids` instead.
        /// </summary>
        [JsonProperty("employee_ids")]
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
        /// Fetch shifts for the specified team members. Replaced `employee_ids` at version "2020-08-26".
        /// </summary>
        [JsonProperty("team_member_ids")]
        public IList<string> TeamMemberIds { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShiftFilter : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationIds()
        {
            return this.shouldSerialize["location_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmployeeIds()
        {
            return this.shouldSerialize["employee_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTeamMemberIds()
        {
            return this.shouldSerialize["team_member_ids"];
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
            return obj is ShiftFilter other &&                ((this.LocationIds == null && other.LocationIds == null) || (this.LocationIds?.Equals(other.LocationIds) == true)) &&
                ((this.EmployeeIds == null && other.EmployeeIds == null) || (this.EmployeeIds?.Equals(other.EmployeeIds) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Start == null && other.Start == null) || (this.Start?.Equals(other.Start) == true)) &&
                ((this.End == null && other.End == null) || (this.End?.Equals(other.End) == true)) &&
                ((this.Workday == null && other.Workday == null) || (this.Workday?.Equals(other.Workday) == true)) &&
                ((this.TeamMemberIds == null && other.TeamMemberIds == null) || (this.TeamMemberIds?.Equals(other.TeamMemberIds) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 432854802;
            hashCode = HashCode.Combine(this.LocationIds, this.EmployeeIds, this.Status, this.Start, this.End, this.Workday, this.TeamMemberIds);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationIds = {(this.LocationIds == null ? "null" : $"[{string.Join(", ", this.LocationIds)} ]")}");
            toStringOutput.Add($"this.EmployeeIds = {(this.EmployeeIds == null ? "null" : $"[{string.Join(", ", this.EmployeeIds)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.Start = {(this.Start == null ? "null" : this.Start.ToString())}");
            toStringOutput.Add($"this.End = {(this.End == null ? "null" : this.End.ToString())}");
            toStringOutput.Add($"this.Workday = {(this.Workday == null ? "null" : this.Workday.ToString())}");
            toStringOutput.Add($"this.TeamMemberIds = {(this.TeamMemberIds == null ? "null" : $"[{string.Join(", ", this.TeamMemberIds)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationIds(this.LocationIds)
                .EmployeeIds(this.EmployeeIds)
                .Status(this.Status)
                .Start(this.Start)
                .End(this.End)
                .Workday(this.Workday)
                .TeamMemberIds(this.TeamMemberIds);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_ids", false },
                { "employee_ids", false },
                { "team_member_ids", false },
            };

            private IList<string> locationIds;
            private IList<string> employeeIds;
            private string status;
            private Models.TimeRange start;
            private Models.TimeRange end;
            private Models.ShiftWorkday workday;
            private IList<string> teamMemberIds;

             /// <summary>
             /// LocationIds.
             /// </summary>
             /// <param name="locationIds"> locationIds. </param>
             /// <returns> Builder. </returns>
            public Builder LocationIds(IList<string> locationIds)
            {
                shouldSerialize["location_ids"] = true;
                this.locationIds = locationIds;
                return this;
            }

             /// <summary>
             /// EmployeeIds.
             /// </summary>
             /// <param name="employeeIds"> employeeIds. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeIds(IList<string> employeeIds)
            {
                shouldSerialize["employee_ids"] = true;
                this.employeeIds = employeeIds;
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
             /// Start.
             /// </summary>
             /// <param name="start"> start. </param>
             /// <returns> Builder. </returns>
            public Builder Start(Models.TimeRange start)
            {
                this.start = start;
                return this;
            }

             /// <summary>
             /// End.
             /// </summary>
             /// <param name="end"> end. </param>
             /// <returns> Builder. </returns>
            public Builder End(Models.TimeRange end)
            {
                this.end = end;
                return this;
            }

             /// <summary>
             /// Workday.
             /// </summary>
             /// <param name="workday"> workday. </param>
             /// <returns> Builder. </returns>
            public Builder Workday(Models.ShiftWorkday workday)
            {
                this.workday = workday;
                return this;
            }

             /// <summary>
             /// TeamMemberIds.
             /// </summary>
             /// <param name="teamMemberIds"> teamMemberIds. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberIds(IList<string> teamMemberIds)
            {
                shouldSerialize["team_member_ids"] = true;
                this.teamMemberIds = teamMemberIds;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationIds()
            {
                this.shouldSerialize["location_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEmployeeIds()
            {
                this.shouldSerialize["employee_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTeamMemberIds()
            {
                this.shouldSerialize["team_member_ids"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ShiftFilter. </returns>
            public ShiftFilter Build()
            {
                return new ShiftFilter(shouldSerialize,
                    this.locationIds,
                    this.employeeIds,
                    this.status,
                    this.start,
                    this.end,
                    this.workday,
                    this.teamMemberIds);
            }
        }
    }
}