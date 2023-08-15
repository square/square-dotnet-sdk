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
    /// Shift.
    /// </summary>
    public class Shift
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Shift"/> class.
        /// </summary>
        /// <param name="startAt">start_at.</param>
        /// <param name="id">id.</param>
        /// <param name="employeeId">employee_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="timezone">timezone.</param>
        /// <param name="endAt">end_at.</param>
        /// <param name="wage">wage.</param>
        /// <param name="breaks">breaks.</param>
        /// <param name="status">status.</param>
        /// <param name="version">version.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="teamMemberId">team_member_id.</param>
        public Shift(
            string startAt,
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "employee_id", false },
                { "location_id", false },
                { "timezone", false },
                { "end_at", false },
                { "breaks", false },
                { "team_member_id", false }
            };

            this.Id = id;
            if (employeeId != null)
            {
                shouldSerialize["employee_id"] = true;
                this.EmployeeId = employeeId;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (timezone != null)
            {
                shouldSerialize["timezone"] = true;
                this.Timezone = timezone;
            }

            this.StartAt = startAt;
            if (endAt != null)
            {
                shouldSerialize["end_at"] = true;
                this.EndAt = endAt;
            }

            this.Wage = wage;
            if (breaks != null)
            {
                shouldSerialize["breaks"] = true;
                this.Breaks = breaks;
            }

            this.Status = status;
            this.Version = version;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            if (teamMemberId != null)
            {
                shouldSerialize["team_member_id"] = true;
                this.TeamMemberId = teamMemberId;
            }

        }
        internal Shift(Dictionary<string, bool> shouldSerialize,
            string startAt,
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
            this.shouldSerialize = shouldSerialize;
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
        /// The UUID for this object.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the employee this shift belongs to. DEPRECATED at version 2020-08-26. Use `team_member_id` instead.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// The ID of the location this shift occurred at. The location should be based on
        /// where the employee clocked in.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The read-only convenience value that is calculated from the location based
        /// on the `location_id`. Format: the IANA timezone database identifier for the
        /// location timezone.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; }

        /// <summary>
        /// RFC 3339; shifted to the location timezone + offset. Precision up to the
        /// minute is respected; seconds are truncated.
        /// </summary>
        [JsonProperty("start_at")]
        public string StartAt { get; }

        /// <summary>
        /// RFC 3339; shifted to the timezone + offset. Precision up to the minute is
        /// respected; seconds are truncated.
        /// </summary>
        [JsonProperty("end_at")]
        public string EndAt { get; }

        /// <summary>
        /// The hourly wage rate used to compensate an employee for this shift.
        /// </summary>
        [JsonProperty("wage", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ShiftWage Wage { get; }

        /// <summary>
        /// A list of all the paid or unpaid breaks that were taken during this shift.
        /// </summary>
        [JsonProperty("breaks")]
        public IList<Models.Break> Breaks { get; }

        /// <summary>
        /// Enumerates the possible status of a `Shift`.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; }

        /// <summary>
        /// Used for resolving concurrency issues. The request fails if the version
        /// provided does not match the server version at the time of the request. If not provided,
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
        /// The ID of the team member this shift belongs to. Replaced `employee_id` at version "2020-08-26".
        /// </summary>
        [JsonProperty("team_member_id")]
        public string TeamMemberId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Shift : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEmployeeId()
        {
            return this.shouldSerialize["employee_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTimezone()
        {
            return this.shouldSerialize["timezone"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEndAt()
        {
            return this.shouldSerialize["end_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBreaks()
        {
            return this.shouldSerialize["breaks"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTeamMemberId()
        {
            return this.shouldSerialize["team_member_id"];
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
            return obj is Shift other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.EmployeeId == null && other.EmployeeId == null) || (this.EmployeeId?.Equals(other.EmployeeId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Timezone == null && other.Timezone == null) || (this.Timezone?.Equals(other.Timezone) == true)) &&
                ((this.StartAt == null && other.StartAt == null) || (this.StartAt?.Equals(other.StartAt) == true)) &&
                ((this.EndAt == null && other.EndAt == null) || (this.EndAt?.Equals(other.EndAt) == true)) &&
                ((this.Wage == null && other.Wage == null) || (this.Wage?.Equals(other.Wage) == true)) &&
                ((this.Breaks == null && other.Breaks == null) || (this.Breaks?.Equals(other.Breaks) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.TeamMemberId == null && other.TeamMemberId == null) || (this.TeamMemberId?.Equals(other.TeamMemberId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1338935965;
            hashCode = HashCode.Combine(this.Id, this.EmployeeId, this.LocationId, this.Timezone, this.StartAt, this.EndAt, this.Wage);

            hashCode = HashCode.Combine(hashCode, this.Breaks, this.Status, this.Version, this.CreatedAt, this.UpdatedAt, this.TeamMemberId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.EmployeeId = {(this.EmployeeId == null ? "null" : this.EmployeeId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.Timezone = {(this.Timezone == null ? "null" : this.Timezone)}");
            toStringOutput.Add($"this.StartAt = {(this.StartAt == null ? "null" : this.StartAt)}");
            toStringOutput.Add($"this.EndAt = {(this.EndAt == null ? "null" : this.EndAt)}");
            toStringOutput.Add($"this.Wage = {(this.Wage == null ? "null" : this.Wage.ToString())}");
            toStringOutput.Add($"this.Breaks = {(this.Breaks == null ? "null" : $"[{string.Join(", ", this.Breaks)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.TeamMemberId = {(this.TeamMemberId == null ? "null" : this.TeamMemberId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.StartAt)
                .Id(this.Id)
                .EmployeeId(this.EmployeeId)
                .LocationId(this.LocationId)
                .Timezone(this.Timezone)
                .EndAt(this.EndAt)
                .Wage(this.Wage)
                .Breaks(this.Breaks)
                .Status(this.Status)
                .Version(this.Version)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .TeamMemberId(this.TeamMemberId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "employee_id", false },
                { "location_id", false },
                { "timezone", false },
                { "end_at", false },
                { "breaks", false },
                { "team_member_id", false },
            };

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

            public Builder(
                string startAt)
            {
                this.startAt = startAt;
            }

             /// <summary>
             /// StartAt.
             /// </summary>
             /// <param name="startAt"> startAt. </param>
             /// <returns> Builder. </returns>
            public Builder StartAt(string startAt)
            {
                this.startAt = startAt;
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
             /// EmployeeId.
             /// </summary>
             /// <param name="employeeId"> employeeId. </param>
             /// <returns> Builder. </returns>
            public Builder EmployeeId(string employeeId)
            {
                shouldSerialize["employee_id"] = true;
                this.employeeId = employeeId;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// Timezone.
             /// </summary>
             /// <param name="timezone"> timezone. </param>
             /// <returns> Builder. </returns>
            public Builder Timezone(string timezone)
            {
                shouldSerialize["timezone"] = true;
                this.timezone = timezone;
                return this;
            }

             /// <summary>
             /// EndAt.
             /// </summary>
             /// <param name="endAt"> endAt. </param>
             /// <returns> Builder. </returns>
            public Builder EndAt(string endAt)
            {
                shouldSerialize["end_at"] = true;
                this.endAt = endAt;
                return this;
            }

             /// <summary>
             /// Wage.
             /// </summary>
             /// <param name="wage"> wage. </param>
             /// <returns> Builder. </returns>
            public Builder Wage(Models.ShiftWage wage)
            {
                this.wage = wage;
                return this;
            }

             /// <summary>
             /// Breaks.
             /// </summary>
             /// <param name="breaks"> breaks. </param>
             /// <returns> Builder. </returns>
            public Builder Breaks(IList<Models.Break> breaks)
            {
                shouldSerialize["breaks"] = true;
                this.breaks = breaks;
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
             /// TeamMemberId.
             /// </summary>
             /// <param name="teamMemberId"> teamMemberId. </param>
             /// <returns> Builder. </returns>
            public Builder TeamMemberId(string teamMemberId)
            {
                shouldSerialize["team_member_id"] = true;
                this.teamMemberId = teamMemberId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEmployeeId()
            {
                this.shouldSerialize["employee_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTimezone()
            {
                this.shouldSerialize["timezone"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEndAt()
            {
                this.shouldSerialize["end_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBreaks()
            {
                this.shouldSerialize["breaks"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTeamMemberId()
            {
                this.shouldSerialize["team_member_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Shift. </returns>
            public Shift Build()
            {
                return new Shift(shouldSerialize,
                    this.startAt,
                    this.id,
                    this.employeeId,
                    this.locationId,
                    this.timezone,
                    this.endAt,
                    this.wage,
                    this.breaks,
                    this.status,
                    this.version,
                    this.createdAt,
                    this.updatedAt,
                    this.teamMemberId);
            }
        }
    }
}