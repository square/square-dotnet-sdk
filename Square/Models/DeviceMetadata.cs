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
    /// DeviceMetadata.
    /// </summary>
    public class DeviceMetadata
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceMetadata"/> class.
        /// </summary>
        /// <param name="batteryPercentage">battery_percentage.</param>
        /// <param name="chargingState">charging_state.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="merchantId">merchant_id.</param>
        /// <param name="networkConnectionType">network_connection_type.</param>
        /// <param name="paymentRegion">payment_region.</param>
        /// <param name="serialNumber">serial_number.</param>
        /// <param name="osVersion">os_version.</param>
        /// <param name="appVersion">app_version.</param>
        /// <param name="wifiNetworkName">wifi_network_name.</param>
        /// <param name="wifiNetworkStrength">wifi_network_strength.</param>
        /// <param name="ipAddress">ip_address.</param>
        public DeviceMetadata(
            string batteryPercentage = null,
            string chargingState = null,
            string locationId = null,
            string merchantId = null,
            string networkConnectionType = null,
            string paymentRegion = null,
            string serialNumber = null,
            string osVersion = null,
            string appVersion = null,
            string wifiNetworkName = null,
            string wifiNetworkStrength = null,
            string ipAddress = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "battery_percentage", false },
                { "charging_state", false },
                { "location_id", false },
                { "merchant_id", false },
                { "network_connection_type", false },
                { "payment_region", false },
                { "serial_number", false },
                { "os_version", false },
                { "app_version", false },
                { "wifi_network_name", false },
                { "wifi_network_strength", false },
                { "ip_address", false }
            };

            if (batteryPercentage != null)
            {
                shouldSerialize["battery_percentage"] = true;
                this.BatteryPercentage = batteryPercentage;
            }

            if (chargingState != null)
            {
                shouldSerialize["charging_state"] = true;
                this.ChargingState = chargingState;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            if (merchantId != null)
            {
                shouldSerialize["merchant_id"] = true;
                this.MerchantId = merchantId;
            }

            if (networkConnectionType != null)
            {
                shouldSerialize["network_connection_type"] = true;
                this.NetworkConnectionType = networkConnectionType;
            }

            if (paymentRegion != null)
            {
                shouldSerialize["payment_region"] = true;
                this.PaymentRegion = paymentRegion;
            }

            if (serialNumber != null)
            {
                shouldSerialize["serial_number"] = true;
                this.SerialNumber = serialNumber;
            }

            if (osVersion != null)
            {
                shouldSerialize["os_version"] = true;
                this.OsVersion = osVersion;
            }

            if (appVersion != null)
            {
                shouldSerialize["app_version"] = true;
                this.AppVersion = appVersion;
            }

            if (wifiNetworkName != null)
            {
                shouldSerialize["wifi_network_name"] = true;
                this.WifiNetworkName = wifiNetworkName;
            }

            if (wifiNetworkStrength != null)
            {
                shouldSerialize["wifi_network_strength"] = true;
                this.WifiNetworkStrength = wifiNetworkStrength;
            }

            if (ipAddress != null)
            {
                shouldSerialize["ip_address"] = true;
                this.IpAddress = ipAddress;
            }

        }
        internal DeviceMetadata(Dictionary<string, bool> shouldSerialize,
            string batteryPercentage = null,
            string chargingState = null,
            string locationId = null,
            string merchantId = null,
            string networkConnectionType = null,
            string paymentRegion = null,
            string serialNumber = null,
            string osVersion = null,
            string appVersion = null,
            string wifiNetworkName = null,
            string wifiNetworkStrength = null,
            string ipAddress = null)
        {
            this.shouldSerialize = shouldSerialize;
            BatteryPercentage = batteryPercentage;
            ChargingState = chargingState;
            LocationId = locationId;
            MerchantId = merchantId;
            NetworkConnectionType = networkConnectionType;
            PaymentRegion = paymentRegion;
            SerialNumber = serialNumber;
            OsVersion = osVersion;
            AppVersion = appVersion;
            WifiNetworkName = wifiNetworkName;
            WifiNetworkStrength = wifiNetworkStrength;
            IpAddress = ipAddress;
        }

        /// <summary>
        /// The Terminal’s remaining battery percentage, between 1-100.
        /// </summary>
        [JsonProperty("battery_percentage")]
        public string BatteryPercentage { get; }

        /// <summary>
        /// The current charging state of the Terminal.
        /// Options: `CHARGING`, `NOT_CHARGING`
        /// </summary>
        [JsonProperty("charging_state")]
        public string ChargingState { get; }

        /// <summary>
        /// The ID of the Square seller business location associated with the Terminal.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The ID of the Square merchant account that is currently signed-in to the Terminal.
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// The Terminal’s current network connection type.
        /// Options: `WIFI`, `ETHERNET`
        /// </summary>
        [JsonProperty("network_connection_type")]
        public string NetworkConnectionType { get; }

        /// <summary>
        /// The country in which the Terminal is authorized to take payments.
        /// </summary>
        [JsonProperty("payment_region")]
        public string PaymentRegion { get; }

        /// <summary>
        /// The unique identifier assigned to the Terminal, which can be found on the lower back
        /// of the device.
        /// </summary>
        [JsonProperty("serial_number")]
        public string SerialNumber { get; }

        /// <summary>
        /// The current version of the Terminal’s operating system.
        /// </summary>
        [JsonProperty("os_version")]
        public string OsVersion { get; }

        /// <summary>
        /// The current version of the application running on the Terminal.
        /// </summary>
        [JsonProperty("app_version")]
        public string AppVersion { get; }

        /// <summary>
        /// The name of the Wi-Fi network to which the Terminal is connected.
        /// </summary>
        [JsonProperty("wifi_network_name")]
        public string WifiNetworkName { get; }

        /// <summary>
        /// The signal strength of the Wi-FI network connection.
        /// Options: `POOR`, `FAIR`, `GOOD`, `EXCELLENT`
        /// </summary>
        [JsonProperty("wifi_network_strength")]
        public string WifiNetworkStrength { get; }

        /// <summary>
        /// The IP address of the Terminal.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceMetadata : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBatteryPercentage()
        {
            return this.shouldSerialize["battery_percentage"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeChargingState()
        {
            return this.shouldSerialize["charging_state"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantId()
        {
            return this.shouldSerialize["merchant_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeNetworkConnectionType()
        {
            return this.shouldSerialize["network_connection_type"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePaymentRegion()
        {
            return this.shouldSerialize["payment_region"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSerialNumber()
        {
            return this.shouldSerialize["serial_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeOsVersion()
        {
            return this.shouldSerialize["os_version"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAppVersion()
        {
            return this.shouldSerialize["app_version"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeWifiNetworkName()
        {
            return this.shouldSerialize["wifi_network_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeWifiNetworkStrength()
        {
            return this.shouldSerialize["wifi_network_strength"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIpAddress()
        {
            return this.shouldSerialize["ip_address"];
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

            return obj is DeviceMetadata other &&
                ((this.BatteryPercentage == null && other.BatteryPercentage == null) || (this.BatteryPercentage?.Equals(other.BatteryPercentage) == true)) &&
                ((this.ChargingState == null && other.ChargingState == null) || (this.ChargingState?.Equals(other.ChargingState) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.MerchantId == null && other.MerchantId == null) || (this.MerchantId?.Equals(other.MerchantId) == true)) &&
                ((this.NetworkConnectionType == null && other.NetworkConnectionType == null) || (this.NetworkConnectionType?.Equals(other.NetworkConnectionType) == true)) &&
                ((this.PaymentRegion == null && other.PaymentRegion == null) || (this.PaymentRegion?.Equals(other.PaymentRegion) == true)) &&
                ((this.SerialNumber == null && other.SerialNumber == null) || (this.SerialNumber?.Equals(other.SerialNumber) == true)) &&
                ((this.OsVersion == null && other.OsVersion == null) || (this.OsVersion?.Equals(other.OsVersion) == true)) &&
                ((this.AppVersion == null && other.AppVersion == null) || (this.AppVersion?.Equals(other.AppVersion) == true)) &&
                ((this.WifiNetworkName == null && other.WifiNetworkName == null) || (this.WifiNetworkName?.Equals(other.WifiNetworkName) == true)) &&
                ((this.WifiNetworkStrength == null && other.WifiNetworkStrength == null) || (this.WifiNetworkStrength?.Equals(other.WifiNetworkStrength) == true)) &&
                ((this.IpAddress == null && other.IpAddress == null) || (this.IpAddress?.Equals(other.IpAddress) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1914687649;
            hashCode = HashCode.Combine(this.BatteryPercentage, this.ChargingState, this.LocationId, this.MerchantId, this.NetworkConnectionType, this.PaymentRegion, this.SerialNumber);

            hashCode = HashCode.Combine(hashCode, this.OsVersion, this.AppVersion, this.WifiNetworkName, this.WifiNetworkStrength, this.IpAddress);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BatteryPercentage = {(this.BatteryPercentage == null ? "null" : this.BatteryPercentage == string.Empty ? "" : this.BatteryPercentage)}");
            toStringOutput.Add($"this.ChargingState = {(this.ChargingState == null ? "null" : this.ChargingState == string.Empty ? "" : this.ChargingState)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.MerchantId = {(this.MerchantId == null ? "null" : this.MerchantId == string.Empty ? "" : this.MerchantId)}");
            toStringOutput.Add($"this.NetworkConnectionType = {(this.NetworkConnectionType == null ? "null" : this.NetworkConnectionType == string.Empty ? "" : this.NetworkConnectionType)}");
            toStringOutput.Add($"this.PaymentRegion = {(this.PaymentRegion == null ? "null" : this.PaymentRegion == string.Empty ? "" : this.PaymentRegion)}");
            toStringOutput.Add($"this.SerialNumber = {(this.SerialNumber == null ? "null" : this.SerialNumber == string.Empty ? "" : this.SerialNumber)}");
            toStringOutput.Add($"this.OsVersion = {(this.OsVersion == null ? "null" : this.OsVersion == string.Empty ? "" : this.OsVersion)}");
            toStringOutput.Add($"this.AppVersion = {(this.AppVersion == null ? "null" : this.AppVersion == string.Empty ? "" : this.AppVersion)}");
            toStringOutput.Add($"this.WifiNetworkName = {(this.WifiNetworkName == null ? "null" : this.WifiNetworkName == string.Empty ? "" : this.WifiNetworkName)}");
            toStringOutput.Add($"this.WifiNetworkStrength = {(this.WifiNetworkStrength == null ? "null" : this.WifiNetworkStrength == string.Empty ? "" : this.WifiNetworkStrength)}");
            toStringOutput.Add($"this.IpAddress = {(this.IpAddress == null ? "null" : this.IpAddress == string.Empty ? "" : this.IpAddress)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BatteryPercentage(this.BatteryPercentage)
                .ChargingState(this.ChargingState)
                .LocationId(this.LocationId)
                .MerchantId(this.MerchantId)
                .NetworkConnectionType(this.NetworkConnectionType)
                .PaymentRegion(this.PaymentRegion)
                .SerialNumber(this.SerialNumber)
                .OsVersion(this.OsVersion)
                .AppVersion(this.AppVersion)
                .WifiNetworkName(this.WifiNetworkName)
                .WifiNetworkStrength(this.WifiNetworkStrength)
                .IpAddress(this.IpAddress);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "battery_percentage", false },
                { "charging_state", false },
                { "location_id", false },
                { "merchant_id", false },
                { "network_connection_type", false },
                { "payment_region", false },
                { "serial_number", false },
                { "os_version", false },
                { "app_version", false },
                { "wifi_network_name", false },
                { "wifi_network_strength", false },
                { "ip_address", false },
            };

            private string batteryPercentage;
            private string chargingState;
            private string locationId;
            private string merchantId;
            private string networkConnectionType;
            private string paymentRegion;
            private string serialNumber;
            private string osVersion;
            private string appVersion;
            private string wifiNetworkName;
            private string wifiNetworkStrength;
            private string ipAddress;

             /// <summary>
             /// BatteryPercentage.
             /// </summary>
             /// <param name="batteryPercentage"> batteryPercentage. </param>
             /// <returns> Builder. </returns>
            public Builder BatteryPercentage(string batteryPercentage)
            {
                shouldSerialize["battery_percentage"] = true;
                this.batteryPercentage = batteryPercentage;
                return this;
            }

             /// <summary>
             /// ChargingState.
             /// </summary>
             /// <param name="chargingState"> chargingState. </param>
             /// <returns> Builder. </returns>
            public Builder ChargingState(string chargingState)
            {
                shouldSerialize["charging_state"] = true;
                this.chargingState = chargingState;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

             /// <summary>
             /// MerchantId.
             /// </summary>
             /// <param name="merchantId"> merchantId. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantId(string merchantId)
            {
                shouldSerialize["merchant_id"] = true;
                this.merchantId = merchantId;
                return this;
            }

             /// <summary>
             /// NetworkConnectionType.
             /// </summary>
             /// <param name="networkConnectionType"> networkConnectionType. </param>
             /// <returns> Builder. </returns>
            public Builder NetworkConnectionType(string networkConnectionType)
            {
                shouldSerialize["network_connection_type"] = true;
                this.networkConnectionType = networkConnectionType;
                return this;
            }

             /// <summary>
             /// PaymentRegion.
             /// </summary>
             /// <param name="paymentRegion"> paymentRegion. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentRegion(string paymentRegion)
            {
                shouldSerialize["payment_region"] = true;
                this.paymentRegion = paymentRegion;
                return this;
            }

             /// <summary>
             /// SerialNumber.
             /// </summary>
             /// <param name="serialNumber"> serialNumber. </param>
             /// <returns> Builder. </returns>
            public Builder SerialNumber(string serialNumber)
            {
                shouldSerialize["serial_number"] = true;
                this.serialNumber = serialNumber;
                return this;
            }

             /// <summary>
             /// OsVersion.
             /// </summary>
             /// <param name="osVersion"> osVersion. </param>
             /// <returns> Builder. </returns>
            public Builder OsVersion(string osVersion)
            {
                shouldSerialize["os_version"] = true;
                this.osVersion = osVersion;
                return this;
            }

             /// <summary>
             /// AppVersion.
             /// </summary>
             /// <param name="appVersion"> appVersion. </param>
             /// <returns> Builder. </returns>
            public Builder AppVersion(string appVersion)
            {
                shouldSerialize["app_version"] = true;
                this.appVersion = appVersion;
                return this;
            }

             /// <summary>
             /// WifiNetworkName.
             /// </summary>
             /// <param name="wifiNetworkName"> wifiNetworkName. </param>
             /// <returns> Builder. </returns>
            public Builder WifiNetworkName(string wifiNetworkName)
            {
                shouldSerialize["wifi_network_name"] = true;
                this.wifiNetworkName = wifiNetworkName;
                return this;
            }

             /// <summary>
             /// WifiNetworkStrength.
             /// </summary>
             /// <param name="wifiNetworkStrength"> wifiNetworkStrength. </param>
             /// <returns> Builder. </returns>
            public Builder WifiNetworkStrength(string wifiNetworkStrength)
            {
                shouldSerialize["wifi_network_strength"] = true;
                this.wifiNetworkStrength = wifiNetworkStrength;
                return this;
            }

             /// <summary>
             /// IpAddress.
             /// </summary>
             /// <param name="ipAddress"> ipAddress. </param>
             /// <returns> Builder. </returns>
            public Builder IpAddress(string ipAddress)
            {
                shouldSerialize["ip_address"] = true;
                this.ipAddress = ipAddress;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBatteryPercentage()
            {
                this.shouldSerialize["battery_percentage"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetChargingState()
            {
                this.shouldSerialize["charging_state"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMerchantId()
            {
                this.shouldSerialize["merchant_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetNetworkConnectionType()
            {
                this.shouldSerialize["network_connection_type"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPaymentRegion()
            {
                this.shouldSerialize["payment_region"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSerialNumber()
            {
                this.shouldSerialize["serial_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetOsVersion()
            {
                this.shouldSerialize["os_version"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAppVersion()
            {
                this.shouldSerialize["app_version"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetWifiNetworkName()
            {
                this.shouldSerialize["wifi_network_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetWifiNetworkStrength()
            {
                this.shouldSerialize["wifi_network_strength"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIpAddress()
            {
                this.shouldSerialize["ip_address"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceMetadata. </returns>
            public DeviceMetadata Build()
            {
                return new DeviceMetadata(shouldSerialize,
                    this.batteryPercentage,
                    this.chargingState,
                    this.locationId,
                    this.merchantId,
                    this.networkConnectionType,
                    this.paymentRegion,
                    this.serialNumber,
                    this.osVersion,
                    this.appVersion,
                    this.wifiNetworkName,
                    this.wifiNetworkStrength,
                    this.ipAddress);
            }
        }
    }
}