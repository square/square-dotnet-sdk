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
    public class ListDeviceCodesResponse 
    {
        public ListDeviceCodesResponse(IList<Models.Error> errors = null,
            IList<Models.DeviceCode> deviceCodes = null,
            string cursor = null)
        {
            Errors = errors;
            DeviceCodes = deviceCodes;
            Cursor = cursor;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// The queried DeviceCode.
        /// </summary>
        [JsonProperty("device_codes")]
        public IList<Models.DeviceCode> DeviceCodes { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint. This value is present only if the request
        /// succeeded and additional results are available.
        /// See [Paginating results](#paginatingresults) for more information.
        /// </summary>
        [JsonProperty("cursor")]
        public string Cursor { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .DeviceCodes(DeviceCodes)
                .Cursor(Cursor);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors = new List<Models.Error>();
            private IList<Models.DeviceCode> deviceCodes = new List<Models.DeviceCode>();
            private string cursor;

            public Builder() { }
            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
                return this;
            }

            public Builder DeviceCodes(IList<Models.DeviceCode> value)
            {
                deviceCodes = value;
                return this;
            }

            public Builder Cursor(string value)
            {
                cursor = value;
                return this;
            }

            public ListDeviceCodesResponse Build()
            {
                return new ListDeviceCodesResponse(errors,
                    deviceCodes,
                    cursor);
            }
        }
    }
}