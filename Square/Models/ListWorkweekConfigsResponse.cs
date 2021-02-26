
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListWorkweekConfigsResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"WorkweekConfigs = {(WorkweekConfigs == null ? "null" : $"[{ string.Join(", ", WorkweekConfigs)} ]")}");
            toStringOutput.Add($"Cursor = {(Cursor == null ? "null" : Cursor == string.Empty ? "" : Cursor)}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is ListWorkweekConfigsResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((WorkweekConfigs == null && other.WorkweekConfigs == null) || (WorkweekConfigs?.Equals(other.WorkweekConfigs) == true)) &&
                ((Cursor == null && other.Cursor == null) || (Cursor?.Equals(other.Cursor) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 232618959;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (WorkweekConfigs != null)
            {
               hashCode += WorkweekConfigs.GetHashCode();
            }

            if (Cursor != null)
            {
               hashCode += Cursor.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

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