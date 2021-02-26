
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
    public class UpdateWageSettingRequest 
    {
        public UpdateWageSettingRequest(Models.WageSetting wageSetting)
        {
            WageSetting = wageSetting;
        }

        /// <summary>
        /// An object representing a team member's wage information.
        /// </summary>
        [JsonProperty("wage_setting")]
        public Models.WageSetting WageSetting { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateWageSettingRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"WageSetting = {(WageSetting == null ? "null" : WageSetting.ToString())}");
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

            return obj is UpdateWageSettingRequest other &&
                ((WageSetting == null && other.WageSetting == null) || (WageSetting?.Equals(other.WageSetting) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 316748925;

            if (WageSetting != null)
            {
               hashCode += WageSetting.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(WageSetting);
            return builder;
        }

        public class Builder
        {
            private Models.WageSetting wageSetting;

            public Builder(Models.WageSetting wageSetting)
            {
                this.wageSetting = wageSetting;
            }

            public Builder WageSetting(Models.WageSetting wageSetting)
            {
                this.wageSetting = wageSetting;
                return this;
            }

            public UpdateWageSettingRequest Build()
            {
                return new UpdateWageSettingRequest(wageSetting);
            }
        }
    }
}