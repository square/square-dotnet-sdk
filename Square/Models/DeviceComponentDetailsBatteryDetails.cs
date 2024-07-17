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
    /// DeviceComponentDetailsBatteryDetails.
    /// </summary>
    public class DeviceComponentDetailsBatteryDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceComponentDetailsBatteryDetails"/> class.
        /// </summary>
        /// <param name="visiblePercent">visible_percent.</param>
        /// <param name="externalPower">external_power.</param>
        public DeviceComponentDetailsBatteryDetails(
            int? visiblePercent = null,
            string externalPower = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "visible_percent", false }
            };

            if (visiblePercent != null)
            {
                shouldSerialize["visible_percent"] = true;
                this.VisiblePercent = visiblePercent;
            }

            this.ExternalPower = externalPower;
        }
        internal DeviceComponentDetailsBatteryDetails(Dictionary<string, bool> shouldSerialize,
            int? visiblePercent = null,
            string externalPower = null)
        {
            this.shouldSerialize = shouldSerialize;
            VisiblePercent = visiblePercent;
            ExternalPower = externalPower;
        }

        /// <summary>
        /// The battery charge percentage as displayed on the device.
        /// </summary>
        [JsonProperty("visible_percent")]
        public int? VisiblePercent { get; }

        /// <summary>
        /// An enum for ExternalPower.
        /// </summary>
        [JsonProperty("external_power", NullValueHandling = NullValueHandling.Ignore)]
        public string ExternalPower { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceComponentDetailsBatteryDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVisiblePercent()
        {
            return this.shouldSerialize["visible_percent"];
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
            return obj is DeviceComponentDetailsBatteryDetails other &&                ((this.VisiblePercent == null && other.VisiblePercent == null) || (this.VisiblePercent?.Equals(other.VisiblePercent) == true)) &&
                ((this.ExternalPower == null && other.ExternalPower == null) || (this.ExternalPower?.Equals(other.ExternalPower) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -94624096;
            hashCode = HashCode.Combine(this.VisiblePercent, this.ExternalPower);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.VisiblePercent = {(this.VisiblePercent == null ? "null" : this.VisiblePercent.ToString())}");
            toStringOutput.Add($"this.ExternalPower = {(this.ExternalPower == null ? "null" : this.ExternalPower.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .VisiblePercent(this.VisiblePercent)
                .ExternalPower(this.ExternalPower);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "visible_percent", false },
            };

            private int? visiblePercent;
            private string externalPower;

             /// <summary>
             /// VisiblePercent.
             /// </summary>
             /// <param name="visiblePercent"> visiblePercent. </param>
             /// <returns> Builder. </returns>
            public Builder VisiblePercent(int? visiblePercent)
            {
                shouldSerialize["visible_percent"] = true;
                this.visiblePercent = visiblePercent;
                return this;
            }

             /// <summary>
             /// ExternalPower.
             /// </summary>
             /// <param name="externalPower"> externalPower. </param>
             /// <returns> Builder. </returns>
            public Builder ExternalPower(string externalPower)
            {
                this.externalPower = externalPower;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetVisiblePercent()
            {
                this.shouldSerialize["visible_percent"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceComponentDetailsBatteryDetails. </returns>
            public DeviceComponentDetailsBatteryDetails Build()
            {
                return new DeviceComponentDetailsBatteryDetails(shouldSerialize,
                    this.visiblePercent,
                    this.externalPower);
            }
        }
    }
}