
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
    public class UpdateBreakTypeRequest 
    {
        public UpdateBreakTypeRequest(Models.BreakType breakType)
        {
            BreakType = breakType;
        }

        /// <summary>
        /// A defined break template that sets an expectation for possible `Break`
        /// instances on a `Shift`.
        /// </summary>
        [JsonProperty("break_type")]
        public Models.BreakType BreakType { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateBreakTypeRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"BreakType = {(BreakType == null ? "null" : BreakType.ToString())}");
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

            return obj is UpdateBreakTypeRequest other &&
                ((BreakType == null && other.BreakType == null) || (BreakType?.Equals(other.BreakType) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -934394320;

            if (BreakType != null)
            {
               hashCode += BreakType.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(BreakType);
            return builder;
        }

        public class Builder
        {
            private Models.BreakType breakType;

            public Builder(Models.BreakType breakType)
            {
                this.breakType = breakType;
            }

            public Builder BreakType(Models.BreakType breakType)
            {
                this.breakType = breakType;
                return this;
            }

            public UpdateBreakTypeRequest Build()
            {
                return new UpdateBreakTypeRequest(breakType);
            }
        }
    }
}