namespace Square.Models
{
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
    using Square.Utilities;

    /// <summary>
    /// DeviceComponentDetailsMeasurement.
    /// </summary>
    public class DeviceComponentDetailsMeasurement
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceComponentDetailsMeasurement"/> class.
        /// </summary>
        /// <param name="mValue">value.</param>
        public DeviceComponentDetailsMeasurement(
            int? mValue = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "value", false }
            };

            if (mValue != null)
            {
                shouldSerialize["value"] = true;
                this.MValue = mValue;
            }

        }
        internal DeviceComponentDetailsMeasurement(Dictionary<string, bool> shouldSerialize,
            int? mValue = null)
        {
            this.shouldSerialize = shouldSerialize;
            MValue = mValue;
        }

        /// <summary>
        /// Gets or sets MValue.
        /// </summary>
        [JsonProperty("value")]
        public int? MValue { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceComponentDetailsMeasurement : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMValue()
        {
            return this.shouldSerialize["value"];
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
            return obj is DeviceComponentDetailsMeasurement other &&                ((this.MValue == null && other.MValue == null) || (this.MValue?.Equals(other.MValue) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 953563516;
            hashCode = HashCode.Combine(this.MValue);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.MValue = {(this.MValue == null ? "null" : this.MValue.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .MValue(this.MValue);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "value", false },
            };

            private int? mValue;

             /// <summary>
             /// MValue.
             /// </summary>
             /// <param name="mValue"> mValue. </param>
             /// <returns> Builder. </returns>
            public Builder MValue(int? mValue)
            {
                shouldSerialize["value"] = true;
                this.mValue = mValue;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMValue()
            {
                this.shouldSerialize["value"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceComponentDetailsMeasurement. </returns>
            public DeviceComponentDetailsMeasurement Build()
            {
                return new DeviceComponentDetailsMeasurement(shouldSerialize,
                    this.mValue);
            }
        }
    }
}