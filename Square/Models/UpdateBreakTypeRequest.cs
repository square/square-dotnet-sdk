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
    /// UpdateBreakTypeRequest.
    /// </summary>
    public class UpdateBreakTypeRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateBreakTypeRequest"/> class.
        /// </summary>
        /// <param name="breakType">break_type.</param>
        public UpdateBreakTypeRequest(
            Models.BreakType breakType)
        {
            this.BreakType = breakType;
        }

        /// <summary>
        /// A defined break template that sets an expectation for possible `Break`
        /// instances on a `Shift`.
        /// </summary>
        [JsonProperty("break_type")]
        public Models.BreakType BreakType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"UpdateBreakTypeRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is UpdateBreakTypeRequest other &&                ((this.BreakType == null && other.BreakType == null) || (this.BreakType?.Equals(other.BreakType) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -934394320;
            hashCode = HashCode.Combine(this.BreakType);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BreakType = {(this.BreakType == null ? "null" : this.BreakType.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.BreakType);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.BreakType breakType;

            public Builder(
                Models.BreakType breakType)
            {
                this.breakType = breakType;
            }

             /// <summary>
             /// BreakType.
             /// </summary>
             /// <param name="breakType"> breakType. </param>
             /// <returns> Builder. </returns>
            public Builder BreakType(Models.BreakType breakType)
            {
                this.breakType = breakType;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> UpdateBreakTypeRequest. </returns>
            public UpdateBreakTypeRequest Build()
            {
                return new UpdateBreakTypeRequest(
                    this.breakType);
            }
        }
    }
}