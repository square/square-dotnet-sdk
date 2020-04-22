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
    public class GetDeviceCodeResponse 
    {
        public GetDeviceCodeResponse(IList<Models.Error> errors = null,
            Models.DeviceCode deviceCode = null)
        {
            Errors = errors;
            DeviceCode = deviceCode;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Getter for device_code
        /// </summary>
        [JsonProperty("device_code")]
        public Models.DeviceCode DeviceCode { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .DeviceCode(DeviceCode);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private Models.DeviceCode deviceCode;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder DeviceCode(Models.DeviceCode value)
            {
                deviceCode = value;
                return this;
            }

            public GetDeviceCodeResponse Build()
            {
                return new GetDeviceCodeResponse(errors,
                    deviceCode);
            }
        }
    }
}