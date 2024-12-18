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
    /// QuickPay.
    /// </summary>
    public class QuickPay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuickPay"/> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="priceMoney">price_money.</param>
        /// <param name="locationId">location_id.</param>
        public QuickPay(
            string name,
            Models.Money priceMoney,
            string locationId)
        {
            this.Name = name;
            this.PriceMoney = priceMoney;
            this.LocationId = locationId;
        }

        /// <summary>
        /// The ad hoc item name. In the resulting `Order`, this name appears as the line item name.
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
        [JsonProperty("price_money")]
        public Models.Money PriceMoney { get; }

        /// <summary>
        /// The ID of the business location the checkout is associated with.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"QuickPay : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is QuickPay other &&
                (this.Name == null && other.Name == null ||
                 this.Name?.Equals(other.Name) == true) &&
                (this.PriceMoney == null && other.PriceMoney == null ||
                 this.PriceMoney?.Equals(other.PriceMoney) == true) &&
                (this.LocationId == null && other.LocationId == null ||
                 this.LocationId?.Equals(other.LocationId) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1438294287;
            hashCode = HashCode.Combine(hashCode, this.Name, this.PriceMoney, this.LocationId);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Name = {this.Name ?? "null"}");
            toStringOutput.Add($"this.PriceMoney = {(this.PriceMoney == null ? "null" : this.PriceMoney.ToString())}");
            toStringOutput.Add($"this.LocationId = {this.LocationId ?? "null"}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Name,
                this.PriceMoney,
                this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string name;
            private Models.Money priceMoney;
            private string locationId;

            /// <summary>
            /// Initialize Builder for QuickPay.
            /// </summary>
            /// <param name="name"> name. </param>
            /// <param name="priceMoney"> priceMoney. </param>
            /// <param name="locationId"> locationId. </param>
            public Builder(
                string name,
                Models.Money priceMoney,
                string locationId)
            {
                this.name = name;
                this.priceMoney = priceMoney;
                this.locationId = locationId;
            }

             /// <summary>
             /// Name.
             /// </summary>
             /// <param name="name"> name. </param>
             /// <returns> Builder. </returns>
            public Builder Name(string name)
            {
                this.name = name;
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
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> QuickPay. </returns>
            public QuickPay Build()
            {
                return new QuickPay(
                    this.name,
                    this.priceMoney,
                    this.locationId);
            }
        }
    }
}