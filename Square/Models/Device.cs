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

namespace Square.Models
{
    /// <summary>
    /// Device.
    /// </summary>
    public class Device
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        /// <param name="attributes">attributes.</param>
        /// <param name="id">id.</param>
        /// <param name="components">components.</param>
        /// <param name="status">status.</param>
        public Device(
            Models.DeviceAttributes attributes,
            string id = null,
            IList<Models.Component> components = null,
            Models.DeviceStatus status = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "components", false }
            };
            this.Id = id;
            this.Attributes = attributes;

            if (components != null)
            {
                shouldSerialize["components"] = true;
                this.Components = components;
            }
            this.Status = status;
        }

        internal Device(
            Dictionary<string, bool> shouldSerialize,
            Models.DeviceAttributes attributes,
            string id = null,
            IList<Models.Component> components = null,
            Models.DeviceStatus status = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Attributes = attributes;
            Components = components;
            Status = status;
        }

        /// <summary>
        /// A synthetic identifier for the device. The identifier includes a standardized prefix and
        /// is otherwise an opaque id generated from key device fields.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Gets or sets Attributes.
        /// </summary>
        [JsonProperty("attributes")]
        public Models.DeviceAttributes Attributes { get; }

        /// <summary>
        /// A list of components applicable to the device.
        /// </summary>
        [JsonProperty("components")]
        public IList<Models.Component> Components { get; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceStatus Status { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"Device : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeComponents()
        {
            return this.shouldSerialize["components"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is Device other &&
                (this.Id == null && other.Id == null ||
                 this.Id?.Equals(other.Id) == true) &&
                (this.Attributes == null && other.Attributes == null ||
                 this.Attributes?.Equals(other.Attributes) == true) &&
                (this.Components == null && other.Components == null ||
                 this.Components?.Equals(other.Components) == true) &&
                (this.Status == null && other.Status == null ||
                 this.Status?.Equals(other.Status) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 936950560;
            hashCode = HashCode.Combine(hashCode, this.Id, this.Attributes, this.Components, this.Status);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.Attributes = {(this.Attributes == null ? "null" : this.Attributes.ToString())}");
            toStringOutput.Add($"this.Components = {(this.Components == null ? "null" : $"[{string.Join(", ", this.Components)} ]")}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Attributes)
                .Id(this.Id)
                .Components(this.Components)
                .Status(this.Status);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "components", false },
            };

            private Models.DeviceAttributes attributes;
            private string id;
            private IList<Models.Component> components;
            private Models.DeviceStatus status;

            /// <summary>
            /// Initialize Builder for Device.
            /// </summary>
            /// <param name="attributes"> attributes. </param>
            public Builder(
                Models.DeviceAttributes attributes)
            {
                this.attributes = attributes;
            }

             /// <summary>
             /// Attributes.
             /// </summary>
             /// <param name="attributes"> attributes. </param>
             /// <returns> Builder. </returns>
            public Builder Attributes(Models.DeviceAttributes attributes)
            {
                this.attributes = attributes;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

             /// <summary>
             /// Components.
             /// </summary>
             /// <param name="components"> components. </param>
             /// <returns> Builder. </returns>
            public Builder Components(IList<Models.Component> components)
            {
                shouldSerialize["components"] = true;
                this.components = components;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(Models.DeviceStatus status)
            {
                this.status = status;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetComponents()
            {
                this.shouldSerialize["components"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Device. </returns>
            public Device Build()
            {
                return new Device(
                    shouldSerialize,
                    this.attributes,
                    this.id,
                    this.components,
                    this.status);
            }
        }
    }
}