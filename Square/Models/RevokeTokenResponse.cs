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
        [JsonProperty("success")]
        public bool? Success { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Success(Success);
            return builder;
        }

        public class Builder
        {
            private bool? success;

            public Builder() { }
            public Builder Success(bool? value)
            {
                success = value;
                return this;
            }

            public RevokeTokenResponse Build()
            {
                return new RevokeTokenResponse(success);
            }
        }
    }
}