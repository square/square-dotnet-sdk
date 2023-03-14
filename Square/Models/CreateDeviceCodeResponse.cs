namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Http.Client;
    using Square.Utilities;

    /// <summary>
    /// CreateDeviceCodeResponse.
    /// </summary>
    public class CreateDeviceCodeResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateDeviceCodeResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="deviceCode">device_code.</param>
        public CreateDeviceCodeResponse(
            IList<Models.Error> errors = null,
            Models.DeviceCode deviceCode = null)
        {
            this.Errors = errors;
            this.DeviceCode = deviceCode;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Gets or sets DeviceCode.
        /// </summary>
        [JsonProperty("device_code", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceCode DeviceCode { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateDeviceCodeResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
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

            return obj is CreateDeviceCodeResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.DeviceCode == null && other.DeviceCode == null) || (this.DeviceCode?.Equals(other.DeviceCode) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 610510621;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.DeviceCode);

            return hashCode;
        }
        internal CreateDeviceCodeResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
            toStringOutput.Add($"this.DeviceCode = {(this.DeviceCode == null ? "null" : this.DeviceCode.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .DeviceCode(this.DeviceCode);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.DeviceCode deviceCode;

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

             /// <summary>
             /// DeviceCode.
             /// </summary>
             /// <param name="deviceCode"> deviceCode. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceCode(Models.DeviceCode deviceCode)
            {
                this.deviceCode = deviceCode;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CreateDeviceCodeResponse. </returns>
            public CreateDeviceCodeResponse Build()
            {
                return new CreateDeviceCodeResponse(
                    this.errors,
                    this.deviceCode);
            }
        }
    }
}