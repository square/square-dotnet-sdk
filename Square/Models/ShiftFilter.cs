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
        public ShiftFilter(IList<string> locationIds = null,
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
        }

        /// <summary>
        /// Fetch shifts for the specified location.
        /// </summary>
        [JsonProperty("location_ids")]
        public IList<string> LocationIds { get; }

        /// <summary>
        /// Fetch shifts for the specified employee.
        /// </summary>
        [JsonProperty("employee_ids")]
        public IList<string> EmployeeIds { get; }

        /// <summary>
        /// Specifies the `status` of `Shift` records to be returned.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC-3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevent endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("start")]
        public Models.TimeRange Start { get; }

        /// <summary>
        /// Represents a generic time range. The start and end values are
        /// represented in RFC-3339 format. Time ranges are customized to be
        /// inclusive or exclusive based on the needs of a particular endpoint.
        /// Refer to the relevent endpoint-specific documentation to determine
        /// how time ranges are handled.
        /// </summary>
        [JsonProperty("end")]
        public Models.TimeRange End { get; }

        /// <summary>
        /// A `Shift` search query filter parameter that sets a range of days that 
        /// a `Shift` must start or end in before passing the filter condition.
        /// </summary>
        [JsonProperty("workday")]
        public Models.ShiftWorkday Workday { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationIds(LocationIds)
                .EmployeeIds(EmployeeIds)
                .Status(Status)
                .Start(Start)
                .End(End)
                .Workday(Workday);
            return builder;
        }

        public class Builder
        {
            private IList<string> locationIds = new List<string>();
            private IList<string> employeeIds = new List<string>();
            private string status;
            private Models.TimeRange start;
            private Models.TimeRange end;
            private Models.ShiftWorkday workday;

            public Builder() { }
            public Builder LocationIds(IList<string> value)
            {
                locationIds = value;
                return this;
            }

            public Builder EmployeeIds(IList<string> value)
            {
                employeeIds = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder Start(Models.TimeRange value)
            {
                start = value;
                return this;
            }

            public Builder End(Models.TimeRange value)
            {
                end = value;
                return this;
            }

            public Builder Workday(Models.ShiftWorkday value)
            {
                workday = value;
                return this;
            }

            public ShiftFilter Build()
            {
                return new ShiftFilter(locationIds,
                    employeeIds,
                    status,
                    start,
                    end,
                    workday);
            }
        }
    }
}