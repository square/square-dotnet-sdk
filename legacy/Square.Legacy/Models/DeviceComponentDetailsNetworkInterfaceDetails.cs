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
using Square.Legacy;
using Square.Legacy.Utilities;

namespace Square.Legacy.Models
{
    /// <summary>
    /// DeviceComponentDetailsNetworkInterfaceDetails.
    /// </summary>
    public class DeviceComponentDetailsNetworkInterfaceDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceComponentDetailsNetworkInterfaceDetails"/> class.
        /// </summary>
        /// <param name="ipAddressV4">ip_address_v4.</param>
        public DeviceComponentDetailsNetworkInterfaceDetails(string ipAddressV4 = null)
        {
            shouldSerialize = new Dictionary<string, bool> { { "ip_address_v4", false } };

            if (ipAddressV4 != null)
            {
                shouldSerialize["ip_address_v4"] = true;
                this.IpAddressV4 = ipAddressV4;
            }
        }

        internal DeviceComponentDetailsNetworkInterfaceDetails(
            Dictionary<string, bool> shouldSerialize,
            string ipAddressV4 = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            IpAddressV4 = ipAddressV4;
        }

        /// <summary>
        /// The string representation of the device’s IPv4 address.
        /// </summary>
        [JsonProperty("ip_address_v4")]
        public string IpAddressV4 { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"DeviceComponentDetailsNetworkInterfaceDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIpAddressV4()
        {
            return this.shouldSerialize["ip_address_v4"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is DeviceComponentDetailsNetworkInterfaceDetails other
                && (
                    this.IpAddressV4 == null && other.IpAddressV4 == null
                    || this.IpAddressV4?.Equals(other.IpAddressV4) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 202623540;
            hashCode = HashCode.Combine(hashCode, this.IpAddressV4);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.IpAddressV4 = {this.IpAddressV4 ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().IpAddressV4(this.IpAddressV4);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "ip_address_v4", false },
            };

            private string ipAddressV4;

            /// <summary>
            /// IpAddressV4.
            /// </summary>
            /// <param name="ipAddressV4"> ipAddressV4. </param>
            /// <returns> Builder. </returns>
            public Builder IpAddressV4(string ipAddressV4)
            {
                shouldSerialize["ip_address_v4"] = true;
                this.ipAddressV4 = ipAddressV4;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetIpAddressV4()
            {
                this.shouldSerialize["ip_address_v4"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceComponentDetailsNetworkInterfaceDetails. </returns>
            public DeviceComponentDetailsNetworkInterfaceDetails Build()
            {
                return new DeviceComponentDetailsNetworkInterfaceDetails(
                    shouldSerialize,
                    this.ipAddressV4
                );
            }
        }
    }
}
