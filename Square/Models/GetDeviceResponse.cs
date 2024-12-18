using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Http.Client;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// GetDeviceResponse.
    /// </summary>
    public class GetDeviceResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDeviceResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="device">device.</param>
        public GetDeviceResponse(
            IList<Models.Error> errors = null,
            Models.Device device = null)
        {
            this.Errors = errors;
            this.Device = device;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Gets or sets Device.
        /// </summary>
        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Device Device { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"GetDeviceResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is GetDeviceResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true) &&
                (this.Device == null && other.Device == null ||
                 this.Device?.Equals(other.Device) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 780911297;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.Errors, this.Device);

            return hashCode;
        }

        internal GetDeviceResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.Device = {(this.Device == null ? "null" : this.Device.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .Device(this.Device);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.Device device;

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
             /// Device.
             /// </summary>
             /// <param name="device"> device. </param>
             /// <returns> Builder. </returns>
            public Builder Device(Models.Device device)
            {
                this.device = device;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GetDeviceResponse. </returns>
            public GetDeviceResponse Build()
            {
                return new GetDeviceResponse(
                    this.errors,
                    this.device);
            }
        }
    }
}