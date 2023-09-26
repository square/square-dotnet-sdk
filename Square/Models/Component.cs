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
    /// Component.
    /// </summary>
    public class Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="applicationDetails">application_details.</param>
        /// <param name="cardReaderDetails">card_reader_details.</param>
        /// <param name="batteryDetails">battery_details.</param>
        /// <param name="wifiDetails">wifi_details.</param>
        /// <param name="ethernetDetails">ethernet_details.</param>
        public Component(
            string type,
            Models.DeviceComponentDetailsApplicationDetails applicationDetails = null,
            Models.DeviceComponentDetailsCardReaderDetails cardReaderDetails = null,
            Models.DeviceComponentDetailsBatteryDetails batteryDetails = null,
            Models.DeviceComponentDetailsWiFiDetails wifiDetails = null,
            Models.DeviceComponentDetailsEthernetDetails ethernetDetails = null)
        {
            this.Type = type;
            this.ApplicationDetails = applicationDetails;
            this.CardReaderDetails = cardReaderDetails;
            this.BatteryDetails = batteryDetails;
            this.WifiDetails = wifiDetails;
            this.EthernetDetails = ethernetDetails;
        }

        /// <summary>
        /// An enum for ComponentType.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Gets or sets ApplicationDetails.
        /// </summary>
        [JsonProperty("application_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceComponentDetailsApplicationDetails ApplicationDetails { get; }

        /// <summary>
        /// Gets or sets CardReaderDetails.
        /// </summary>
        [JsonProperty("card_reader_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceComponentDetailsCardReaderDetails CardReaderDetails { get; }

        /// <summary>
        /// Gets or sets BatteryDetails.
        /// </summary>
        [JsonProperty("battery_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceComponentDetailsBatteryDetails BatteryDetails { get; }

        /// <summary>
        /// Gets or sets WifiDetails.
        /// </summary>
        [JsonProperty("wifi_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceComponentDetailsWiFiDetails WifiDetails { get; }

        /// <summary>
        /// Gets or sets EthernetDetails.
        /// </summary>
        [JsonProperty("ethernet_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceComponentDetailsEthernetDetails EthernetDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Component : ({string.Join(", ", toStringOutput)})";
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
            return obj is Component other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.ApplicationDetails == null && other.ApplicationDetails == null) || (this.ApplicationDetails?.Equals(other.ApplicationDetails) == true)) &&
                ((this.CardReaderDetails == null && other.CardReaderDetails == null) || (this.CardReaderDetails?.Equals(other.CardReaderDetails) == true)) &&
                ((this.BatteryDetails == null && other.BatteryDetails == null) || (this.BatteryDetails?.Equals(other.BatteryDetails) == true)) &&
                ((this.WifiDetails == null && other.WifiDetails == null) || (this.WifiDetails?.Equals(other.WifiDetails) == true)) &&
                ((this.EthernetDetails == null && other.EthernetDetails == null) || (this.EthernetDetails?.Equals(other.EthernetDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 958922299;
            hashCode = HashCode.Combine(this.Type, this.ApplicationDetails, this.CardReaderDetails, this.BatteryDetails, this.WifiDetails, this.EthernetDetails);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.ApplicationDetails = {(this.ApplicationDetails == null ? "null" : this.ApplicationDetails.ToString())}");
            toStringOutput.Add($"this.CardReaderDetails = {(this.CardReaderDetails == null ? "null" : this.CardReaderDetails.ToString())}");
            toStringOutput.Add($"this.BatteryDetails = {(this.BatteryDetails == null ? "null" : this.BatteryDetails.ToString())}");
            toStringOutput.Add($"this.WifiDetails = {(this.WifiDetails == null ? "null" : this.WifiDetails.ToString())}");
            toStringOutput.Add($"this.EthernetDetails = {(this.EthernetDetails == null ? "null" : this.EthernetDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type)
                .ApplicationDetails(this.ApplicationDetails)
                .CardReaderDetails(this.CardReaderDetails)
                .BatteryDetails(this.BatteryDetails)
                .WifiDetails(this.WifiDetails)
                .EthernetDetails(this.EthernetDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string type;
            private Models.DeviceComponentDetailsApplicationDetails applicationDetails;
            private Models.DeviceComponentDetailsCardReaderDetails cardReaderDetails;
            private Models.DeviceComponentDetailsBatteryDetails batteryDetails;
            private Models.DeviceComponentDetailsWiFiDetails wifiDetails;
            private Models.DeviceComponentDetailsEthernetDetails ethernetDetails;

            public Builder(
                string type)
            {
                this.type = type;
            }

             /// <summary>
             /// Type.
             /// </summary>
             /// <param name="type"> type. </param>
             /// <returns> Builder. </returns>
            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

             /// <summary>
             /// ApplicationDetails.
             /// </summary>
             /// <param name="applicationDetails"> applicationDetails. </param>
             /// <returns> Builder. </returns>
            public Builder ApplicationDetails(Models.DeviceComponentDetailsApplicationDetails applicationDetails)
            {
                this.applicationDetails = applicationDetails;
                return this;
            }

             /// <summary>
             /// CardReaderDetails.
             /// </summary>
             /// <param name="cardReaderDetails"> cardReaderDetails. </param>
             /// <returns> Builder. </returns>
            public Builder CardReaderDetails(Models.DeviceComponentDetailsCardReaderDetails cardReaderDetails)
            {
                this.cardReaderDetails = cardReaderDetails;
                return this;
            }

             /// <summary>
             /// BatteryDetails.
             /// </summary>
             /// <param name="batteryDetails"> batteryDetails. </param>
             /// <returns> Builder. </returns>
            public Builder BatteryDetails(Models.DeviceComponentDetailsBatteryDetails batteryDetails)
            {
                this.batteryDetails = batteryDetails;
                return this;
            }

             /// <summary>
             /// WifiDetails.
             /// </summary>
             /// <param name="wifiDetails"> wifiDetails. </param>
             /// <returns> Builder. </returns>
            public Builder WifiDetails(Models.DeviceComponentDetailsWiFiDetails wifiDetails)
            {
                this.wifiDetails = wifiDetails;
                return this;
            }

             /// <summary>
             /// EthernetDetails.
             /// </summary>
             /// <param name="ethernetDetails"> ethernetDetails. </param>
             /// <returns> Builder. </returns>
            public Builder EthernetDetails(Models.DeviceComponentDetailsEthernetDetails ethernetDetails)
            {
                this.ethernetDetails = ethernetDetails;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Component. </returns>
            public Component Build()
            {
                return new Component(
                    this.type,
                    this.applicationDetails,
                    this.cardReaderDetails,
                    this.batteryDetails,
                    this.wifiDetails,
                    this.ethernetDetails);
            }
        }
    }
}