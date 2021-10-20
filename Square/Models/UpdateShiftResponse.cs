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
    /// UpdateShiftResponse.
    /// </summary>
    public class UpdateShiftResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateShiftResponse"/> class.
        /// </summary>
        /// <param name="shift">shift.</param>
        /// <param name="errors">errors.</param>
        public UpdateShiftResponse(
            Models.Shift shift = null,
            IList<Models.Error> errors = null)
        {
            this.Shift = shift;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// A record of the hourly rate, start, and end times for a single work shift
        /// for an employee. This might include a record of the start and end times for breaks
        /// taken during the shift.
        /// </summary>
        [JsonProperty("shift", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Shift Shift { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateShiftResponse : ({string.Join(", ", toStringOutput)})";
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

            return obj is UpdateShiftResponse other &&
                ((this.Context == null && other.Context == null) || (this.Context?.Equals(other.Context) == true)) &&
                ((this.Shift == null && other.Shift == null) || (this.Shift?.Equals(other.Shift) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1825551550;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(this.Shift, this.Errors);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Shift = {(this.Shift == null ? "null" : this.Shift.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Shift(this.Shift)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Shift shift;
            private IList<Models.Error> errors;

             /// <summary>
             /// Shift.
             /// </summary>
             /// <param name="shift"> shift. </param>
             /// <returns> Builder. </returns>
            public Builder Shift(Models.Shift shift)
            {
                this.shift = shift;
                return this;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateShiftResponse. </returns>
            public UpdateShiftResponse Build()
            {
                return new UpdateShiftResponse(
                    this.shift,
                    this.errors);
            }
        }
    }
}