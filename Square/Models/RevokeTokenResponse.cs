
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
    public class RevokeTokenResponse 
    {
        public RevokeTokenResponse(bool? success = null)
        {
            Success = success;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// If the request is successful, this is true.
        /// </summary>
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Success { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RevokeTokenResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Success = {(Success == null ? "null" : Success.ToString())}");
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

            return obj is RevokeTokenResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Success == null && other.Success == null) || (Success?.Equals(other.Success) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1055186132;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Success != null)
            {
               hashCode += Success.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Success(Success);
            return builder;
        }

        public class Builder
        {
            private bool? success;



            public Builder Success(bool? success)
            {
                this.success = success;
                return this;
            }

            public RevokeTokenResponse Build()
            {
                return new RevokeTokenResponse(success);
            }
        }
    }
}