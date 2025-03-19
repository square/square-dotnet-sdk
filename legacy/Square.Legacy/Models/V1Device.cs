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
    /// V1Device.
    /// </summary>
    public class V1Device
    {
        private readonly Dictionary<string, bool> shouldSerialize;

        /// <summary>
        /// Initializes a new instance of the <see cref="V1Device"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="name">name.</param>
        public V1Device(string id = null, string name = null)
        {
            shouldSerialize = new Dictionary<string, bool> { { "name", false } };
            this.Id = id;

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }
        }

        internal V1Device(
            Dictionary<string, bool> shouldSerialize,
            string id = null,
            string name = null
        )
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Name = name;
        }

        /// <summary>
        /// The device's Square-issued ID.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The device's merchant-specified name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"V1Device : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeName()
        {
            return this.shouldSerialize["name"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return obj is V1Device other
                && (this.Id == null && other.Id == null || this.Id?.Equals(other.Id) == true)
                && (
                    this.Name == null && other.Name == null || this.Name?.Equals(other.Name) == true
                );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -1502443483;
            hashCode = HashCode.Combine(hashCode, this.Id, this.Name);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {this.Id ?? "null"}");
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder().Id(this.Id).Name(this.Name);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false },
            };

            private string id;
            private string name;

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
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> V1Device. </returns>
            public V1Device Build()
            {
                return new V1Device(shouldSerialize, this.id, this.name);
            }
        }
    }
}
