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
            public Builder WageSetting(Models.WageSetting value)
            {
                wageSetting = value;
                return this;
            }

            public UpdateWageSettingRequest Build()
            {
                return new UpdateWageSettingRequest(wageSetting);
            }
        }
    }
}