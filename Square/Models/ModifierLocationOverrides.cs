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
    /// ModifierLocationOverrides.
    /// </summary>
    public class ModifierLocationOverrides
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifierLocationOverrides"/> class.
        /// </summary>
        /// <param name="locationId">location_id.</param>
        /// <param name="priceMoney">price_money.</param>
        /// <param name="soldOut">sold_out.</param>
        public ModifierLocationOverrides(
            string locationId = null,
            Models.Money priceMoney = null,
            bool? soldOut = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false }
            };

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            this.PriceMoney = priceMoney;
            this.SoldOut = soldOut;
        }
        internal ModifierLocationOverrides(Dictionary<string, bool> shouldSerialize,
            string locationId = null,
            Models.Money priceMoney = null,
            bool? soldOut = null)
        {
            this.shouldSerialize = shouldSerialize;
            LocationId = locationId;
            PriceMoney = priceMoney;
            SoldOut = soldOut;
        }

        /// <summary>
        /// The ID of the `Location` object representing the location. This can include a deactivated location.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money PriceMoney { get; }

        /// <summary>
        /// Indicates whether the modifier is sold out at the specified location or not. As an example, for cheese (modifier) burger (item), when the modifier is sold out, it is the cheese, but not the burger, that is sold out.
        /// The seller can manually set this sold out status. Attempts by an application to set this attribute are ignored.
        /// </summary>
        [JsonProperty("sold_out", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SoldOut { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ModifierLocationOverrides : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
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
            return obj is ModifierLocationOverrides other &&                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.PriceMoney == null && other.PriceMoney == null) || (this.PriceMoney?.Equals(other.PriceMoney) == true)) &&
                ((this.SoldOut == null && other.SoldOut == null) || (this.SoldOut?.Equals(other.SoldOut) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1732964243;
            hashCode = HashCode.Combine(this.LocationId, this.PriceMoney, this.SoldOut);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
            toStringOutput.Add($"this.PriceMoney = {(this.PriceMoney == null ? "null" : this.PriceMoney.ToString())}");
            toStringOutput.Add($"this.SoldOut = {(this.SoldOut == null ? "null" : this.SoldOut.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .LocationId(this.LocationId)
                .PriceMoney(this.PriceMoney)
                .SoldOut(this.SoldOut);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "location_id", false },
            };

            private string locationId;
            private Models.Money priceMoney;
            private bool? soldOut;

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
             /// PriceMoney.
             /// </summary>
             /// <param name="priceMoney"> priceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder PriceMoney(Models.Money priceMoney)
            {
                this.priceMoney = priceMoney;
                return this;
            }

             /// <summary>
             /// SoldOut.
             /// </summary>
             /// <param name="soldOut"> soldOut. </param>
             /// <returns> Builder. </returns>
            public Builder SoldOut(bool? soldOut)
            {
                this.soldOut = soldOut;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ModifierLocationOverrides. </returns>
            public ModifierLocationOverrides Build()
            {
                return new ModifierLocationOverrides(shouldSerialize,
                    this.locationId,
                    this.priceMoney,
                    this.soldOut);
            }
        }
    }
}