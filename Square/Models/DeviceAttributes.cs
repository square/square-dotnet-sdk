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
    /// DeviceAttributes.
    /// </summary>
    public class DeviceAttributes
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceAttributes"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="manufacturer">manufacturer.</param>
        /// <param name="model">model.</param>
        /// <param name="name">name.</param>
        /// <param name="manufacturersId">manufacturers_id.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="version">version.</param>
        /// <param name="merchantToken">merchant_token.</param>
        public DeviceAttributes(
            string type,
            string manufacturer,
            string model = null,
            string name = null,
            string manufacturersId = null,
            string updatedAt = null,
            string version = null,
            string merchantToken = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "model", false },
                { "name", false },
                { "manufacturers_id", false },
                { "merchant_token", false }
            };

            this.Type = type;
            this.Manufacturer = manufacturer;
            if (model != null)
            {
                shouldSerialize["model"] = true;
                this.Model = model;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            if (manufacturersId != null)
            {
                shouldSerialize["manufacturers_id"] = true;
                this.ManufacturersId = manufacturersId;
            }

            this.UpdatedAt = updatedAt;
            this.Version = version;
            if (merchantToken != null)
            {
                shouldSerialize["merchant_token"] = true;
                this.MerchantToken = merchantToken;
            }

        }
        internal DeviceAttributes(Dictionary<string, bool> shouldSerialize,
            string type,
            string manufacturer,
            string model = null,
            string name = null,
            string manufacturersId = null,
            string updatedAt = null,
            string version = null,
            string merchantToken = null)
        {
            this.shouldSerialize = shouldSerialize;
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
            Name = name;
            ManufacturersId = manufacturersId;
            UpdatedAt = updatedAt;
            Version = version;
            MerchantToken = merchantToken;
        }

        /// <summary>
        /// An enum identifier of the device type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The maker of the device.
        /// </summary>
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; }

        /// <summary>
        /// The specific model of the device.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; }

        /// <summary>
        /// A seller-specified name for the device.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The manufacturer-supplied identifier for the device (where available). In many cases,
        /// this identifier will be a serial number.
        /// </summary>
        [JsonProperty("manufacturers_id")]
        public string ManufacturersId { get; }

        /// <summary>
        /// The RFC 3339-formatted value of the most recent update to the device information.
        /// (Could represent any field update on the device.)
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The current version of software installed on the device.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public string Version { get; }

        /// <summary>
        /// The merchant_token identifying the merchant controlling the device.
        /// </summary>
        [JsonProperty("merchant_token")]
        public string MerchantToken { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceAttributes : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeModel()
        {
            return this.shouldSerialize["model"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeManufacturersId()
        {
            return this.shouldSerialize["manufacturers_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeMerchantToken()
        {
            return this.shouldSerialize["merchant_token"];
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
            return obj is DeviceAttributes other &&                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Manufacturer == null && other.Manufacturer == null) || (this.Manufacturer?.Equals(other.Manufacturer) == true)) &&
                ((this.Model == null && other.Model == null) || (this.Model?.Equals(other.Model) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.ManufacturersId == null && other.ManufacturersId == null) || (this.ManufacturersId?.Equals(other.ManufacturersId) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.MerchantToken == null && other.MerchantToken == null) || (this.MerchantToken?.Equals(other.MerchantToken) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1577650539;
            hashCode = HashCode.Combine(this.Type, this.Manufacturer, this.Model, this.Name, this.ManufacturersId, this.UpdatedAt, this.Version);

            hashCode = HashCode.Combine(hashCode, this.MerchantToken);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.Manufacturer = {(this.Manufacturer == null ? "null" : this.Manufacturer)}");
            toStringOutput.Add($"this.Model = {(this.Model == null ? "null" : this.Model)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.ManufacturersId = {(this.ManufacturersId == null ? "null" : this.ManufacturersId)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version)}");
            toStringOutput.Add($"this.MerchantToken = {(this.MerchantToken == null ? "null" : this.MerchantToken)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type,
                this.Manufacturer)
                .Model(this.Model)
                .Name(this.Name)
                .ManufacturersId(this.ManufacturersId)
                .UpdatedAt(this.UpdatedAt)
                .Version(this.Version)
                .MerchantToken(this.MerchantToken);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "model", false },
                { "name", false },
                { "manufacturers_id", false },
                { "merchant_token", false },
            };

            private string type;
            private string manufacturer;
            private string model;
            private string name;
            private string manufacturersId;
            private string updatedAt;
            private string version;
            private string merchantToken;

            /// <summary>
            /// Initialize Builder for DeviceAttributes.
            /// </summary>
            /// <param name="type"> type. </param>
            /// <param name="manufacturer"> manufacturer. </param>
            public Builder(
                string type,
                string manufacturer)
            {
                this.type = type;
                this.manufacturer = manufacturer;
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
             /// Manufacturer.
             /// </summary>
             /// <param name="manufacturer"> manufacturer. </param>
             /// <returns> Builder. </returns>
            public Builder Manufacturer(string manufacturer)
            {
                this.manufacturer = manufacturer;
                return this;
            }

             /// <summary>
             /// Model.
             /// </summary>
             /// <param name="model"> model. </param>
             /// <returns> Builder. </returns>
            public Builder Model(string model)
            {
                shouldSerialize["model"] = true;
                this.model = model;
                return this;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                shouldSerialize["name"] = true;
                this.name = name;
                return this;
            }

             /// <summary>
             /// ManufacturersId.
             /// </summary>
             /// <param name="manufacturersId"> manufacturersId. </param>
             /// <returns> Builder. </returns>
            public Builder ManufacturersId(string manufacturersId)
            {
                shouldSerialize["manufacturers_id"] = true;
                this.manufacturersId = manufacturersId;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(string version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// MerchantToken.
             /// </summary>
             /// <param name="merchantToken"> merchantToken. </param>
             /// <returns> Builder. </returns>
            public Builder MerchantToken(string merchantToken)
            {
                shouldSerialize["merchant_token"] = true;
                this.merchantToken = merchantToken;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetModel()
            {
                this.shouldSerialize["model"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetManufacturersId()
            {
                this.shouldSerialize["manufacturers_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetMerchantToken()
            {
                this.shouldSerialize["merchant_token"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceAttributes. </returns>
            public DeviceAttributes Build()
            {
                return new DeviceAttributes(shouldSerialize,
                    this.type,
                    this.manufacturer,
                    this.model,
                    this.name,
                    this.manufacturersId,
                    this.updatedAt,
                    this.version,
                    this.merchantToken);
            }
        }
    }
}