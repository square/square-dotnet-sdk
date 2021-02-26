
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
        /// A unique string that identifies this CreateDeviceCode request. Keys can
        /// be any valid string but must be unique for every CreateDeviceCode request.
        /// See [Idempotency keys](https://developer.squareup.com/docs/basics/api101/idempotency) for more information.
        /// </summary>
        [JsonProperty("idempotency_key")]
        public string IdempotencyKey { get; }

        /// <summary>
        /// Getter for device_code
        /// </summary>
        [JsonProperty("device_code")]
        public Models.DeviceCode DeviceCode { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateDeviceCodeRequest : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"IdempotencyKey = {(IdempotencyKey == null ? "null" : IdempotencyKey == string.Empty ? "" : IdempotencyKey)}");
            toStringOutput.Add($"DeviceCode = {(DeviceCode == null ? "null" : DeviceCode.ToString())}");
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

            return obj is CreateDeviceCodeRequest other &&
                ((IdempotencyKey == null && other.IdempotencyKey == null) || (IdempotencyKey?.Equals(other.IdempotencyKey) == true)) &&
                ((DeviceCode == null && other.DeviceCode == null) || (DeviceCode?.Equals(other.DeviceCode) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 1794633711;

            if (IdempotencyKey != null)
            {
               hashCode += IdempotencyKey.GetHashCode();
            }

            if (DeviceCode != null)
            {
               hashCode += DeviceCode.GetHashCode();
            }

            return hashCode;
        }

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

            public Builder IdempotencyKey(string idempotencyKey)
            {
                this.idempotencyKey = idempotencyKey;
                return this;
            }

            public Builder DeviceCode(Models.DeviceCode deviceCode)
            {
                this.deviceCode = deviceCode;
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