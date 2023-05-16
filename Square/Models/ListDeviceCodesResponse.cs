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
    /// ListDeviceCodesResponse.
    /// </summary>
    public class ListDeviceCodesResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListDeviceCodesResponse"/> class.
        /// </summary>
        /// <param name="errors">errors.</param>
        /// <param name="deviceCodes">device_codes.</param>
        /// <param name="cursor">cursor.</param>
        public ListDeviceCodesResponse(
            IList<Models.Error> errors = null,
            IList<Models.DeviceCode> deviceCodes = null,
            string cursor = null)
        {
            this.Errors = errors;
            this.DeviceCodes = deviceCodes;
            this.Cursor = cursor;
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
        /// The queried DeviceCode.
        /// </summary>
        [JsonProperty("device_codes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.DeviceCode> DeviceCodes { get; }

        /// <summary>
        /// A pagination cursor to retrieve the next set of results for your
        /// original query to the endpoint. This value is present only if the request
        /// succeeded and additional results are available.
        /// See [Paginating results](https://developer.squareup.com/docs/working-with-apis/pagination) for more information.
        /// </summary>
        [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
        public string Cursor { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ListDeviceCodesResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is ListDeviceCodesResponse other &&                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true)) &&
                ((this.DeviceCodes == null && other.DeviceCodes == null) || (this.DeviceCodes?.Equals(other.DeviceCodes) == true)) &&
                ((this.Cursor == null && other.Cursor == null) || (this.Cursor?.Equals(other.Cursor) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 456544551;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Errors, this.DeviceCodes, this.Cursor);

            return hashCode;
        }
        internal ListDeviceCodesResponse ContextSetter(HttpContext context)
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
            toStringOutput.Add($"this.DeviceCodes = {(this.DeviceCodes == null ? "null" : $"[{string.Join(", ", this.DeviceCodes)} ]")}");
            toStringOutput.Add($"this.Cursor = {(this.Cursor == null ? "null" : this.Cursor == string.Empty ? "" : this.Cursor)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(this.Errors)
                .DeviceCodes(this.DeviceCodes)
                .Cursor(this.Cursor);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private IList<Models.Error> errors;
            private IList<Models.DeviceCode> deviceCodes;
            private string cursor;

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
             /// DeviceCodes.
             /// </summary>
             /// <param name="deviceCodes"> deviceCodes. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceCodes(IList<Models.DeviceCode> deviceCodes)
            {
                this.deviceCodes = deviceCodes;
                return this;
            }

             /// <summary>
             /// Cursor.
             /// </summary>
             /// <param name="cursor"> cursor. </param>
             /// <returns> Builder. </returns>
            public Builder Cursor(string cursor)
            {
                this.cursor = cursor;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ListDeviceCodesResponse. </returns>
            public ListDeviceCodesResponse Build()
            {
                return new ListDeviceCodesResponse(
                    this.errors,
                    this.deviceCodes,
                    this.cursor);
            }
        }
    }
}