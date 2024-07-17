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
    /// DeviceComponentDetailsWiFiDetails.
    /// </summary>
    public class DeviceComponentDetailsWiFiDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceComponentDetailsWiFiDetails"/> class.
        /// </summary>
        /// <param name="active">active.</param>
        /// <param name="ssid">ssid.</param>
        /// <param name="ipAddressV4">ip_address_v4.</param>
        /// <param name="secureConnection">secure_connection.</param>
        /// <param name="signalStrength">signal_strength.</param>
        public DeviceComponentDetailsWiFiDetails(
            bool? active = null,
            string ssid = null,
            string ipAddressV4 = null,
            string secureConnection = null,
            Models.DeviceComponentDetailsMeasurement signalStrength = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "active", false },
                { "ssid", false },
                { "ip_address_v4", false },
                { "secure_connection", false }
            };

            if (active != null)
            {
                shouldSerialize["active"] = true;
                this.Active = active;
            }

            if (ssid != null)
            {
                shouldSerialize["ssid"] = true;
                this.Ssid = ssid;
            }

            if (ipAddressV4 != null)
            {
                shouldSerialize["ip_address_v4"] = true;
                this.IpAddressV4 = ipAddressV4;
            }

            if (secureConnection != null)
            {
                shouldSerialize["secure_connection"] = true;
                this.SecureConnection = secureConnection;
            }

            this.SignalStrength = signalStrength;
        }
        internal DeviceComponentDetailsWiFiDetails(Dictionary<string, bool> shouldSerialize,
            bool? active = null,
            string ssid = null,
            string ipAddressV4 = null,
            string secureConnection = null,
            Models.DeviceComponentDetailsMeasurement signalStrength = null)
        {
            this.shouldSerialize = shouldSerialize;
            Active = active;
            Ssid = ssid;
            IpAddressV4 = ipAddressV4;
            SecureConnection = secureConnection;
            SignalStrength = signalStrength;
        }

        /// <summary>
        /// A boolean to represent whether the WiFI interface is currently active.
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; }

        /// <summary>
        /// The name of the connected WIFI network.
        /// </summary>
        [JsonProperty("ssid")]
        public string Ssid { get; }

        /// <summary>
        /// The string representation of the device’s IPv4 address.
        /// </summary>
        [JsonProperty("ip_address_v4")]
        public string IpAddressV4 { get; }

        /// <summary>
        /// The security protocol for a secure connection (e.g. WPA2). None provided if the connection
        /// is unsecured.
        /// </summary>
        [JsonProperty("secure_connection")]
        public string SecureConnection { get; }

        /// <summary>
        /// A value qualified by unit of measure.
        /// </summary>
        [JsonProperty("signal_strength", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceComponentDetailsMeasurement SignalStrength { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceComponentDetailsWiFiDetails : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeSsid()
        {
            return this.shouldSerialize["ssid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIpAddressV4()
        {
            return this.shouldSerialize["ip_address_v4"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSecureConnection()
        {
            return this.shouldSerialize["secure_connection"];
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
            return obj is DeviceComponentDetailsWiFiDetails other &&                ((this.Active == null && other.Active == null) || (this.Active?.Equals(other.Active) == true)) &&
                ((this.Ssid == null && other.Ssid == null) || (this.Ssid?.Equals(other.Ssid) == true)) &&
                ((this.IpAddressV4 == null && other.IpAddressV4 == null) || (this.IpAddressV4?.Equals(other.IpAddressV4) == true)) &&
                ((this.SecureConnection == null && other.SecureConnection == null) || (this.SecureConnection?.Equals(other.SecureConnection) == true)) &&
                ((this.SignalStrength == null && other.SignalStrength == null) || (this.SignalStrength?.Equals(other.SignalStrength) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1526846131;
            hashCode = HashCode.Combine(this.Active, this.Ssid, this.IpAddressV4, this.SecureConnection, this.SignalStrength);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Active = {(this.Active == null ? "null" : this.Active.ToString())}");
            toStringOutput.Add($"this.Ssid = {(this.Ssid == null ? "null" : this.Ssid)}");
            toStringOutput.Add($"this.IpAddressV4 = {(this.IpAddressV4 == null ? "null" : this.IpAddressV4)}");
            toStringOutput.Add($"this.SecureConnection = {(this.SecureConnection == null ? "null" : this.SecureConnection)}");
            toStringOutput.Add($"this.SignalStrength = {(this.SignalStrength == null ? "null" : this.SignalStrength.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Active(this.Active)
                .Ssid(this.Ssid)
                .IpAddressV4(this.IpAddressV4)
                .SecureConnection(this.SecureConnection)
                .SignalStrength(this.SignalStrength);
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
                { "ssid", false },
                { "ip_address_v4", false },
                { "secure_connection", false },
            };

            private bool? active;
            private string ssid;
            private string ipAddressV4;
            private string secureConnection;
            private Models.DeviceComponentDetailsMeasurement signalStrength;

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
             /// Ssid.
             /// </summary>
             /// <param name="ssid"> ssid. </param>
             /// <returns> Builder. </returns>
            public Builder Ssid(string ssid)
            {
                shouldSerialize["ssid"] = true;
                this.ssid = ssid;
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
             /// SecureConnection.
             /// </summary>
             /// <param name="secureConnection"> secureConnection. </param>
             /// <returns> Builder. </returns>
            public Builder SecureConnection(string secureConnection)
            {
                shouldSerialize["secure_connection"] = true;
                this.secureConnection = secureConnection;
                return this;
            }

             /// <summary>
             /// SignalStrength.
             /// </summary>
             /// <param name="signalStrength"> signalStrength. </param>
             /// <returns> Builder. </returns>
            public Builder SignalStrength(Models.DeviceComponentDetailsMeasurement signalStrength)
            {
                this.signalStrength = signalStrength;
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
            public void UnsetSsid()
            {
                this.shouldSerialize["ssid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIpAddressV4()
            {
                this.shouldSerialize["ip_address_v4"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSecureConnection()
            {
                this.shouldSerialize["secure_connection"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceComponentDetailsWiFiDetails. </returns>
            public DeviceComponentDetailsWiFiDetails Build()
            {
                return new DeviceComponentDetailsWiFiDetails(shouldSerialize,
                    this.active,
                    this.ssid,
                    this.ipAddressV4,
                    this.secureConnection,
                    this.signalStrength);
            }
        }
    }
}