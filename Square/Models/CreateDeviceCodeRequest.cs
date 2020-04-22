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
    public class CreateDeviceCodeRequest 
    {
        public CreateDeviceCodeRequest(string idempotencyKey,
            Models.DeviceCode deviceCode)
        {
            IdempotencyKey = idempotencyKey;
            DeviceCode = deviceCode;
        }

        /// <summary>
        /// A unique string that identifies this CreateCheckout request. Keys can be any valid string but
        /// must be unique for every CreateCheckout request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Getter for device_code
        /// </summary>
        [JsonProperty("device_code")]
        public Models.DeviceCode DeviceCode { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(IdempotencyKey,
                DeviceCode);
            return builder;
        }

        public class Builder
        {
            private string idempotencyKey;
            private Models.DeviceCode deviceCode;

            public Builder(string idempotencyKey,
                Models.DeviceCode deviceCode)
            {
                this.idempotencyKey = idempotencyKey;
                this.deviceCode = deviceCode;
            }
            public Builder IdempotencyKey(string value)
            {
                idempotencyKey = value;
                return this;
            }

            public Builder DeviceCode(Models.DeviceCode value)
            {
                deviceCode = value;
                return this;
            }

            public CreateDeviceCodeRequest Build()
            {
                return new CreateDeviceCodeRequest(idempotencyKey,
                    deviceCode);
            }
        }
    }
}