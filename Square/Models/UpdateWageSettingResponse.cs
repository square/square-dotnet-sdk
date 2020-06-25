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
    public class UpdateWageSettingResponse 
    {
        public UpdateWageSettingResponse(Models.WageSetting wageSetting = null,
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
        [JsonProperty("wage_setting")]
        public Models.WageSetting WageSetting { get; }

        /// <summary>
        /// The errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

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
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder WageSetting(Models.WageSetting value)
            {
                wageSetting = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public UpdateWageSettingResponse Build()
            {
                return new UpdateWageSettingResponse(wageSetting,
                    errors);
            }
        }
    }
}