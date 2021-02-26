
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
    public class RetrieveWageSettingResponse 
    {
        public RetrieveWageSettingResponse(Models.WageSetting wageSetting = null,
            IList<Models.Error> errors = null)
        {
            WageSetting = wageSetting;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// An object representing a team member's wage information.
        /// </summary>
        [JsonProperty("wage_setting", NullValueHandling = NullValueHandling.Ignore)]
        public Models.WageSetting WageSetting { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveWageSettingResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"WageSetting = {(WageSetting == null ? "null" : WageSetting.ToString())}");
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

            return obj is RetrieveWageSettingResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((WageSetting == null && other.WageSetting == null) || (WageSetting?.Equals(other.WageSetting) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -635387084;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (WageSetting != null)
            {
               hashCode += WageSetting.GetHashCode();
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
                .WageSetting(WageSetting)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.WageSetting wageSetting;
            private IList<Models.Error> errors;



            public Builder WageSetting(Models.WageSetting wageSetting)
            {
                this.wageSetting = wageSetting;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public RetrieveWageSettingResponse Build()
            {
                return new RetrieveWageSettingResponse(wageSetting,
                    errors);
            }
        }
    }
}