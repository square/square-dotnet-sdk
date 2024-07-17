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
    /// DeviceStatus.
    /// </summary>
    public class DeviceStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceStatus"/> class.
        /// </summary>
        /// <param name="category">category.</param>
        public DeviceStatus(
            string category = null)
        {
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets Category.
        /// </summary>
        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"DeviceStatus : ({string.Join(", ", toStringOutput)})";
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
            return obj is DeviceStatus other &&                ((this.Category == null && other.Category == null) || (this.Category?.Equals(other.Category) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -44529295;
            hashCode = HashCode.Combine(this.Category);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Category = {(this.Category == null ? "null" : this.Category.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Category(this.Category);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string category;

             /// <summary>
             /// Category.
             /// </summary>
             /// <param name="category"> category. </param>
             /// <returns> Builder. </returns>
            public Builder Category(string category)
            {
                this.category = category;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> DeviceStatus. </returns>
            public DeviceStatus Build()
            {
                return new DeviceStatus(
                    this.category);
            }
        }
    }
}