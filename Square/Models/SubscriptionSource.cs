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
    /// SubscriptionSource.
    /// </summary>
    public class SubscriptionSource
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionSource"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        public SubscriptionSource(
            string name = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "name", false }
            };

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }
        }

        internal SubscriptionSource(
            Dictionary<string, bool> shouldSerialize,
            string name = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
        }

        /// <summary>
        /// The name used to identify the place (physical or digital) that
        /// a subscription originates. If unset, the name defaults to the name
        /// of the application that created the subscription.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"SubscriptionSource : ({string.Join(", ", toStringOutput)})";
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
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is SubscriptionSource other &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1272253068;
            hashCode = HashCode.Combine(hashCode, this.Name);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Name(this.Name);
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

            private string name;

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
            /// <returns> SubscriptionSource. </returns>
            public SubscriptionSource Build()
            {
                return new SubscriptionSource(
                    shouldSerialize,
                    this.name);
            }
        }
    }
}