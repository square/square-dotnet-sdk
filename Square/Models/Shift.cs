
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
        public Shift(string startAt,
            string id = null,
            string employeeId = null,
            string locationId = null,
            string timezone = null,
            string endAt = null,
            Models.ShiftWage wage = null,
            IList<Models.Break> breaks = null,
            string status = null,
            int? version = null,
            string createdAt = null,
            string updatedAt = null,
            string teamMemberId = null)
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
            TeamMemberId = teamMemberId;
        }

        /// <summary>
        /// UUID for this object
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the employee this shift belongs to. DEPRECATED at version 2020-08-26. Use `team_member_id` instead
        /// </summary>
        [JsonProperty("employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EmployeeId { get; }

        /// <summary>
        /// The ID of the location this shift occurred at. Should be based on
        /// where the employee clocked in.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// Read-only convenience value that is calculated from the location based
        /// on `location_id`. Format: the IANA Timezone Database identifier for the
        /// location timezone.
        /// </summary>
        [JsonProperty("timezone", NullValueHandling = NullValueHandling.Ignore)]
        public string Timezone { get; }

        /// <summary>
        /// RFC 3339; shifted to location timezone + offset. Precision up to the
        /// minute is respected; seconds are truncated.
        /// </summary>
        [JsonProperty("start_at")]
        public string StartAt { get; }

        /// <summary>
        /// RFC 3339; shifted to timezone + offset. Precision up to the minute is
        /// respected; seconds are truncated.
        /// </summary>
        [JsonProperty("end_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndAt { get; }

        /// <summary>
        /// The hourly wage rate used to compensate an employee for this shift.
        /// </summary>
        [JsonProperty("wage", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShiftWage Wage { get; }

        /// <summary>
        /// A list of any paid or unpaid breaks that were taken during this shift.
        /// </summary>
        [JsonProperty("breaks", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Break> Breaks { get; }

        /// <summary>
        /// Enumerates the possible status of a `Shift`
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Used for resolving concurrency issues; request will fail if version
        /// provided does not match server version at time of request. If not provided,
        /// Square executes a blind write; potentially overwriting data from another
        /// write.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format; presented in UTC.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// A read-only timestamp in RFC 3339 format; presented in UTC.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The ID of the team member this shift belongs to. Replaced `employee_id` at version "2020-08-26"
        /// </summary>
        [JsonProperty("team_member_id", NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberId { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Shift : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"EmployeeId = {(EmployeeId == null ? "null" : EmployeeId == string.Empty ? "" : EmployeeId)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"Timezone = {(Timezone == null ? "null" : Timezone == string.Empty ? "" : Timezone)}");
            toStringOutput.Add($"StartAt = {(StartAt == null ? "null" : StartAt == string.Empty ? "" : StartAt)}");
            toStringOutput.Add($"EndAt = {(EndAt == null ? "null" : EndAt == string.Empty ? "" : EndAt)}");
            toStringOutput.Add($"Wage = {(Wage == null ? "null" : Wage.ToString())}");
            toStringOutput.Add($"Breaks = {(Breaks == null ? "null" : $"[{ string.Join(", ", Breaks)} ]")}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"Version = {(Version == null ? "null" : Version.ToString())}");
            toStringOutput.Add($"CreatedAt = {(CreatedAt == null ? "null" : CreatedAt == string.Empty ? "" : CreatedAt)}");
            toStringOutput.Add($"UpdatedAt = {(UpdatedAt == null ? "null" : UpdatedAt == string.Empty ? "" : UpdatedAt)}");
            toStringOutput.Add($"TeamMemberId = {(TeamMemberId == null ? "null" : TeamMemberId == string.Empty ? "" : TeamMemberId)}");
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

            return obj is Shift other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((EmployeeId == null && other.EmployeeId == null) || (EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((Timezone == null && other.Timezone == null) || (Timezone?.Equals(other.Timezone) == true)) &&
                ((StartAt == null && other.StartAt == null) || (StartAt?.Equals(other.StartAt) == true)) &&
                ((EndAt == null && other.EndAt == null) || (EndAt?.Equals(other.EndAt) == true)) &&
                ((Wage == null && other.Wage == null) || (Wage?.Equals(other.Wage) == true)) &&
                ((Breaks == null && other.Breaks == null) || (Breaks?.Equals(other.Breaks) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                ((Version == null && other.Version == null) || (Version?.Equals(other.Version) == true)) &&
                ((CreatedAt == null && other.CreatedAt == null) || (CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((UpdatedAt == null && other.UpdatedAt == null) || (UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((TeamMemberId == null && other.TeamMemberId == null) || (TeamMemberId?.Equals(other.TeamMemberId) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1338935965;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (EmployeeId != null)
            {
               hashCode += EmployeeId.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (Timezone != null)
            {
               hashCode += Timezone.GetHashCode();
            }

            if (StartAt != null)
            {
               hashCode += StartAt.GetHashCode();
            }

            if (EndAt != null)
            {
               hashCode += EndAt.GetHashCode();
            }

            if (Wage != null)
            {
               hashCode += Wage.GetHashCode();
            }

            if (Breaks != null)
            {
               hashCode += Breaks.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }

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

            if (TeamMemberId != null)
            {
               hashCode += TeamMemberId.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(StartAt)
                .Id(Id)
                .EmployeeId(EmployeeId)
                .LocationId(LocationId)
                .Timezone(Timezone)
                .EndAt(EndAt)
                .Wage(Wage)
                .Breaks(Breaks)
                .Status(Status)
                .Version(Version)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .TeamMemberId(TeamMemberId);
            return builder;
        }

        public class Builder
        {
            private string startAt;
            private string id;
            private string employeeId;
            private string locationId;
            private string timezone;
            private string endAt;
            private Models.ShiftWage wage;
            private IList<Models.Break> breaks;
            private string status;
            private int? version;
            private string createdAt;
            private string updatedAt;
            private string teamMemberId;

            public Builder(string startAt)
            {
                this.startAt = startAt;
            }

            public Builder StartAt(string startAt)
            {
                this.startAt = startAt;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder Timezone(string timezone)
            {
                this.timezone = timezone;
                return this;
            }

            public Builder EndAt(string endAt)
            {
                this.endAt = endAt;
                return this;
            }

            public Builder Wage(Models.ShiftWage wage)
            {
                this.wage = wage;
                return this;
            }

            public Builder Breaks(IList<Models.Break> breaks)
            {
                this.breaks = breaks;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
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

            public Builder TeamMemberId(string teamMemberId)
            {
                this.teamMemberId = teamMemberId;
                return this;
            }

            public Shift Build()
            {
                return new Shift(startAt,
                    id,
                    employeeId,
                    locationId,
                    timezone,
                    endAt,
                    wage,
                    breaks,
                    status,
                    version,
                    createdAt,
                    updatedAt,
                    teamMemberId);
            }
        }
    }
}