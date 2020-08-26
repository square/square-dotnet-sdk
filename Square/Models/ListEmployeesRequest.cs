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
    public class ListEmployeesRequest 
    {
        public ListEmployeesRequest(string locationId = null,
            string status = null,
            int? limit = null,
            string cursor = null)
        {
            LocationId = locationId;
            Status = status;
            Limit = limit;
            Cursor = cursor;
        }

        /// <summary>
        /// Getter for location_id
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The status of the Employee being retrieved.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// The number of employees to be returned on each page.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; }

        /// <summary>
        /// The token required to retrieve the specified page of results.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(LocationId)
                .Status(Status)
                .Limit(Limit)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private string locationId;
            private string status;
            private int? limit;
            private string cursor;

            public Builder() { }
            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder Limit(int? value)
            {
                limit = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public ListEmployeesRequest Build()
            {
                return new ListEmployeesRequest(locationId,
                    status,
                    limit,
                    cursor);
            }
        }
    }
}