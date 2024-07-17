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
    /// ShippingFee.
    /// </summary>
    public class ShippingFee
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingFee"/> class.
        /// </summary>
        /// <param name="charge">charge.</param>
        /// <param name="name">name.</param>
        public ShippingFee(
            Models.Money charge,
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

            this.Charge = charge;
        }
        internal ShippingFee(Dictionary<string, bool> shouldSerialize,
            Models.Money charge,
            string name = null)
        {
            this.shouldSerialize = shouldSerialize;
            Name = name;
            Charge = charge;
        }

        /// <summary>
        /// The name for the shipping fee.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("charge")]
        public Models.Money Charge { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ShippingFee : ({string.Join(", ", toStringOutput)})";
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
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is ShippingFee other &&                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Charge == null && other.Charge == null) || (this.Charge?.Equals(other.Charge) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 643719762;
            hashCode = HashCode.Combine(this.Name, this.Charge);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.Charge = {(this.Charge == null ? "null" : this.Charge.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Charge)
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

            private Models.Money charge;
            private string name;

            /// <summary>
            /// Initialize Builder for ShippingFee.
            /// </summary>
            /// <param name="charge"> charge. </param>
            public Builder(
                Models.Money charge)
            {
                this.charge = charge;
            }

             /// <summary>
             /// Charge.
             /// </summary>
             /// <param name="charge"> charge. </param>
             /// <returns> Builder. </returns>
            public Builder Charge(Models.Money charge)
            {
                this.charge = charge;
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
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetName()
            {
                this.shouldSerialize["name"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ShippingFee. </returns>
            public ShippingFee Build()
            {
                return new ShippingFee(shouldSerialize,
                    this.charge,
                    this.name);
            }
        }
    }
}