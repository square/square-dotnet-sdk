using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class V1Timecard 
    {
        public V1Timecard(string employeeId,
            string id = null,
            bool? deleted = null,
            string clockinTime = null,
            string clockoutTime = null,
            string clockinLocationId = null,
            string clockoutLocationId = null,
            string createdAt = null,
            string updatedAt = null,
            double? regularSecondsWorked = null,
            double? overtimeSecondsWorked = null,
            double? doubletimeSecondsWorked = null)
        {
            Id = id;
            EmployeeId = employeeId;
            Deleted = deleted;
            ClockinTime = clockinTime;
            ClockoutTime = clockoutTime;
            ClockinLocationId = clockinLocationId;
            ClockoutLocationId = clockoutLocationId;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            RegularSecondsWorked = regularSecondsWorked;
            OvertimeSecondsWorked = overtimeSecondsWorked;
            DoubletimeSecondsWorked = doubletimeSecondsWorked;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The timecard's unique ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The ID of the employee the timecard is associated with.
        /// </summary>
        [JsonProperty("employee_id")]
        public string EmployeeId { get; }

        /// <summary>
        /// If true, the timecard was deleted by the merchant, and it is no longer valid.
        /// </summary>
        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; }

        /// <summary>
        /// The clock-in time for the timecard, in ISO 8601 format.
        /// </summary>
        [JsonProperty("clockin_time", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockinTime { get; }

        /// <summary>
        /// The clock-out time for the timecard, in ISO 8601 format. Provide this value only if importing timecard information from another system.
        /// </summary>
        [JsonProperty("clockout_time", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockoutTime { get; }

        /// <summary>
        /// The ID of the location the employee clocked in from. We strongly reccomend providing a clockin_location_id. Square uses the clockin_location_id to determine a timecard’s timezone and overtime rules.
        /// </summary>
        [JsonProperty("clockin_location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockinLocationId { get; }

        /// <summary>
        /// The ID of the location the employee clocked out from. Provide this value only if importing timecard information from another system.
        /// </summary>
        [JsonProperty("clockout_location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClockoutLocationId { get; }

        /// <summary>
        /// The time when the timecard was created, in ISO 8601 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The time when the timecard was most recently updated, in ISO 8601 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The total number of regular (non-overtime) seconds worked in the timecard.
        /// </summary>
        [JsonProperty("regular_seconds_worked", NullValueHandling = NullValueHandling.Ignore)]
        public double? RegularSecondsWorked { get; }

        /// <summary>
        /// The total number of overtime seconds worked in the timecard.
        /// </summary>
        [JsonProperty("overtime_seconds_worked", NullValueHandling = NullValueHandling.Ignore)]
        public double? OvertimeSecondsWorked { get; }

        /// <summary>
        /// The total number of doubletime seconds worked in the timecard.
        /// </summary>
        [JsonProperty("doubletime_seconds_worked", NullValueHandling = NullValueHandling.Ignore)]
        public double? DoubletimeSecondsWorked { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(EmployeeId)
                .Id(Id)
                .Deleted(Deleted)
                .ClockinTime(ClockinTime)
                .ClockoutTime(ClockoutTime)
                .ClockinLocationId(ClockinLocationId)
                .ClockoutLocationId(ClockoutLocationId)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .RegularSecondsWorked(RegularSecondsWorked)
                .OvertimeSecondsWorked(OvertimeSecondsWorked)
                .DoubletimeSecondsWorked(DoubletimeSecondsWorked);
            return builder;
        }

        public class Builder
        {
            private string employeeId;
            private string id;
            private bool? deleted;
            private string clockinTime;
            private string clockoutTime;
            private string clockinLocationId;
            private string clockoutLocationId;
            private string createdAt;
            private string updatedAt;
            private double? regularSecondsWorked;
            private double? overtimeSecondsWorked;
            private double? doubletimeSecondsWorked;

            public Builder(string employeeId)
            {
                this.employeeId = employeeId;
            }

            public Builder EmployeeId(string employeeId)
            {
                this.employeeId = employeeId;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Deleted(bool? deleted)
            {
                this.deleted = deleted;
                return this;
            }

            public Builder ClockinTime(string clockinTime)
            {
                this.clockinTime = clockinTime;
                return this;
            }

            public Builder ClockoutTime(string clockoutTime)
            {
                this.clockoutTime = clockoutTime;
                return this;
            }

            public Builder ClockinLocationId(string clockinLocationId)
            {
                this.clockinLocationId = clockinLocationId;
                return this;
            }

            public Builder ClockoutLocationId(string clockoutLocationId)
            {
                this.clockoutLocationId = clockoutLocationId;
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

            public Builder RegularSecondsWorked(double? regularSecondsWorked)
            {
                this.regularSecondsWorked = regularSecondsWorked;
                return this;
            }

            public Builder OvertimeSecondsWorked(double? overtimeSecondsWorked)
            {
                this.overtimeSecondsWorked = overtimeSecondsWorked;
                return this;
            }

            public Builder DoubletimeSecondsWorked(double? doubletimeSecondsWorked)
            {
                this.doubletimeSecondsWorked = doubletimeSecondsWorked;
                return this;
            }

            public V1Timecard Build()
            {
                return new V1Timecard(employeeId,
                    id,
                    deleted,
                    clockinTime,
                    clockoutTime,
                    clockinLocationId,
                    clockoutLocationId,
                    createdAt,
                    updatedAt,
                    regularSecondsWorked,
                    overtimeSecondsWorked,
                    doubletimeSecondsWorked);
            }
        }
    }
}