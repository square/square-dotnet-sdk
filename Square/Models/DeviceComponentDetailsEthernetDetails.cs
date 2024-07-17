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
    /// DeviceComponentDetailsEthernetDetails.
    /// </summary>
    public class DeviceComponentDetailsEthernetDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceComponentDetailsEthernetDetails"/> class.
        /// </summary>
        /// <param name="active">active.</param>
        /// <param name="ipAddressV4">ip_address_v4.</param>
        public DeviceComponentDetailsEthernetDetails(
            bool? active = null,
            string ipAddressV4 = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "active", false },
                { "ip_address_v4", false }
            };

            if (active != null)
            {
                shouldSerialize["active"] = true;
                this.Active = active;
            }

            if (ipAddressV4 != null)
            {
                shouldSerialize["ip_address_v4"] = true;
                this.IpAddressV4 = ipAddressV4;
            }

        }
        internal DeviceComponentDetailsEthernetDetails(Dictionary<string, bool> shouldSerialize,
            bool? active = null,
            string ipAddressV4 = null)
        {
            this.shouldSerialize = shouldSerialize;
            Active = active;
            IpAddressV4 = ipAddressV4;
        }

        /// <summary>
        /// A boolean to represent whether the Ethernet interface is currently active.
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; }

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

            return $"DeviceComponentDetailsEthernetDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeActive()
        {
            return this.shouldSerialize["active"];
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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is DeviceComponentDetailsEthernetDetails other &&                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                ((this.IpAddressV4 == null && other.IpAddressV4 == null) || (this.IpAddressV4?.Equals(other.IpAddressV4) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 672106879;
            hashCode = HashCode.Combine(this.Active, this.IpAddressV4);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.IpAddressV4 = {(this.IpAddressV4 == null ? "null" : this.IpAddressV4)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Active(this.Active)
                .IpAddressV4(this.IpAddressV4);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "active", false },
                { "ip_address_v4", false },
            };

            private bool? active;
            private string ipAddressV4;

             /// <summary>
             /// Active.
             /// </summary>
             /// <param name="active"> active. </param>
             /// <returns> Builder. </returns>
            public Builder Active(bool? active)
            {
                shouldSerialize["active"] = true;
                this.active = active;
                return this;
            }

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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetActive()
            {
                this.shouldSerialize["active"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIpAddressV4()
            {
                this.shouldSerialize["ip_address_v4"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceComponentDetailsEthernetDetails. </returns>
            public DeviceComponentDetailsEthernetDetails Build()
            {
                return new DeviceComponentDetailsEthernetDetails(shouldSerialize,
                    this.active,
                    this.ipAddressV4);
            }
        }
    }
}