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
    /// OrderReturnLineItemModifier.
    /// </summary>
    public class OrderReturnLineItemModifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturnLineItemModifier"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="sourceModifierUid">source_modifier_uid.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="name">name.</param>
        /// <param name="basePriceMoney">base_price_money.</param>
        /// <param name="totalPriceMoney">total_price_money.</param>
        public OrderReturnLineItemModifier(
            string uid = null,
            string sourceModifierUid = null,
            string catalogObjectId = null,
            string name = null,
            Models.Money basePriceMoney = null,
            Models.Money totalPriceMoney = null)
        {
            this.Uid = uid;
            this.SourceModifierUid = sourceModifierUid;
            this.CatalogObjectId = catalogObjectId;
            this.Name = name;
            this.BasePriceMoney = basePriceMoney;
            this.TotalPriceMoney = totalPriceMoney;
        }

        /// <summary>
        /// A unique ID that identifies the return modifier only within this order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The modifier `uid` from the order's line item that contains the
        /// original sale of this line item modifier.
        /// </summary>
        [JsonProperty("source_modifier_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceModifierUid { get; }

        /// <summary>
        /// The catalog object ID referencing [CatalogModifier]($m/CatalogModifier).
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The name of the item modifier.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("base_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money BasePriceMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_price_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalPriceMoney { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReturnLineItemModifier : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderReturnLineItemModifier other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.SourceModifierUid == null && other.SourceModifierUid == null) || (this.SourceModifierUid?.Equals(other.SourceModifierUid) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.BasePriceMoney == null && other.BasePriceMoney == null) || (this.BasePriceMoney?.Equals(other.BasePriceMoney) == true)) &&
                ((this.TotalPriceMoney == null && other.TotalPriceMoney == null) || (this.TotalPriceMoney?.Equals(other.TotalPriceMoney) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 909107113;

            if (this.Uid != null)
            {
               hashCode += this.Uid.GetHashCode();
            }

            if (this.SourceModifierUid != null)
            {
               hashCode += this.SourceModifierUid.GetHashCode();
            }

            if (this.CatalogObjectId != null)
            {
               hashCode += this.CatalogObjectId.GetHashCode();
            }

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.BasePriceMoney != null)
            {
               hashCode += this.BasePriceMoney.GetHashCode();
            }

            if (this.TotalPriceMoney != null)
            {
               hashCode += this.TotalPriceMoney.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid == string.Empty ? "" : this.Uid)}");
            toStringOutput.Add($"this.SourceModifierUid = {(this.SourceModifierUid == null ? "null" : this.SourceModifierUid == string.Empty ? "" : this.SourceModifierUid)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.BasePriceMoney = {(this.BasePriceMoney == null ? "null" : this.BasePriceMoney.ToString())}");
            toStringOutput.Add($"this.TotalPriceMoney = {(this.TotalPriceMoney == null ? "null" : this.TotalPriceMoney.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .SourceModifierUid(this.SourceModifierUid)
                .CatalogObjectId(this.CatalogObjectId)
                .Name(this.Name)
                .BasePriceMoney(this.BasePriceMoney)
                .TotalPriceMoney(this.TotalPriceMoney);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string uid;
            private string sourceModifierUid;
            private string catalogObjectId;
            private string name;
            private Models.Money basePriceMoney;
            private Models.Money totalPriceMoney;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

             /// <summary>
             /// SourceModifierUid.
             /// </summary>
             /// <param name="sourceModifierUid"> sourceModifierUid. </param>
             /// <returns> Builder. </returns>
            public Builder SourceModifierUid(string sourceModifierUid)
            {
                this.sourceModifierUid = sourceModifierUid;
                return this;
            }

             /// <summary>
             /// CatalogObjectId.
             /// </summary>
             /// <param name="catalogObjectId"> catalogObjectId. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
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
             /// BasePriceMoney.
             /// </summary>
             /// <param name="basePriceMoney"> basePriceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder BasePriceMoney(Models.Money basePriceMoney)
            {
                this.basePriceMoney = basePriceMoney;
                return this;
            }

             /// <summary>
             /// TotalPriceMoney.
             /// </summary>
             /// <param name="totalPriceMoney"> totalPriceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalPriceMoney(Models.Money totalPriceMoney)
            {
                this.totalPriceMoney = totalPriceMoney;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturnLineItemModifier. </returns>
            public OrderReturnLineItemModifier Build()
            {
                return new OrderReturnLineItemModifier(
                    this.uid,
                    this.sourceModifierUid,
                    this.catalogObjectId,
                    this.name,
                    this.basePriceMoney,
                    this.totalPriceMoney);
            }
        }
    }
}