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
    using Square.Utilities;

    /// <summary>
    /// UpdateShiftRequest.
    /// </summary>
    public class UpdateShiftRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateShiftRequest"/> class.
        /// </summary>
        /// <param name="shift">shift.</param>
        public UpdateShiftRequest(
            Models.Shift shift)
        {
            this.Shift = shift;
        }

        /// <summary>
        /// A record of the hourly rate, start, and end times for a single work shift
        /// for an employee. This might include a record of the start and end times for breaks
        /// taken during the shift.
        /// </summary>
        [JsonProperty("shift")]
        public Models.Shift Shift { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateShiftRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateShiftRequest other &&                ((this.Shift == null && other.Shift == null) || (this.Shift?.Equals(other.Shift) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1511413014;
            hashCode = HashCode.Combine(this.Shift);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Shift = {(this.Shift == null ? "null" : this.Shift.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Shift);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.Shift shift;

            public Builder(
                Models.Shift shift)
            {
                this.shift = shift;
            }

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
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateShiftRequest. </returns>
            public UpdateShiftRequest Build()
            {
                return new UpdateShiftRequest(
                    this.shift);
            }
        }
    }
}