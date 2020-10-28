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
    public class ListWorkweekConfigsResponse 
    {
        public ListWorkweekConfigsResponse(IList<Models.WorkweekConfig> workweekConfigs = null,
            string cursor = null,
            IList<Models.Error> errors = null)
        {
            WorkweekConfigs = workweekConfigs;
            Cursor = cursor;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A page of Employee Wage results.
        /// </summary>
        [JsonProperty("workweek_configs", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.WorkweekConfig> WorkweekConfigs { get; }

        /// <summary>
        /// Value supplied in the subsequent request to fetch the next page of
        /// Employee Wage results.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .WorkweekConfigs(WorkweekConfigs)
                .Cursor(Cursor)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private IList<Models.WorkweekConfig> workweekConfigs;
            private string cursor;
            private IList<Models.Error> errors;



            public Builder WorkweekConfigs(IList<Models.WorkweekConfig> workweekConfigs)
            {
                this.workweekConfigs = workweekConfigs;
                return this;
            }

            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public ListWorkweekConfigsResponse Build()
            {
                return new ListWorkweekConfigsResponse(workweekConfigs,
                    cursor,
                    errors);
            }
        }
    }
}