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
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturnLineItemModifier"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="sourceModifierUid">source_modifier_uid.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        /// <param name="name">name.</param>
        /// <param name="basePriceMoney">base_price_money.</param>
        /// <param name="totalPriceMoney">total_price_money.</param>
        /// <param name="quantity">quantity.</param>
        public OrderReturnLineItemModifier(
            string uid = null,
            string sourceModifierUid = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
            string name = null,
            Models.Money basePriceMoney = null,
            Models.Money totalPriceMoney = null,
            string quantity = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_modifier_uid", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "name", false },
                { "quantity", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (sourceModifierUid != null)
            {
                shouldSerialize["source_modifier_uid"] = true;
                this.SourceModifierUid = sourceModifierUid;
            }

            if (catalogObjectId != null)
            {
                shouldSerialize["catalog_object_id"] = true;
                this.CatalogObjectId = catalogObjectId;
            }

            if (catalogVersion != null)
            {
                shouldSerialize["catalog_version"] = true;
                this.CatalogVersion = catalogVersion;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
            }

            this.BasePriceMoney = basePriceMoney;
            this.TotalPriceMoney = totalPriceMoney;
            if (quantity != null)
            {
                shouldSerialize["quantity"] = true;
                this.Quantity = quantity;
            }

        }
        internal OrderReturnLineItemModifier(Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string sourceModifierUid = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
            string name = null,
            Models.Money basePriceMoney = null,
            Models.Money totalPriceMoney = null,
            string quantity = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            SourceModifierUid = sourceModifierUid;
            CatalogObjectId = catalogObjectId;
            CatalogVersion = catalogVersion;
            Name = name;
            BasePriceMoney = basePriceMoney;
            TotalPriceMoney = totalPriceMoney;
            Quantity = quantity;
        }

        /// <summary>
        /// A unique ID that identifies the return modifier only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The modifier `uid` from the order's line item that contains the
        /// original sale of this line item modifier.
        /// </summary>
        [JsonProperty("source_modifier_uid")]
        public string SourceModifierUid { get; }

        /// <summary>
        /// The catalog object ID referencing [CatalogModifier](entity:CatalogModifier).
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The version of the catalog object that this line item modifier references.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <summary>
        /// The name of the item modifier.
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

        /// <summary>
        /// The quantity of the line item modifier. The modifier quantity can be 0 or more.
        /// For example, suppose a restaurant offers a cheeseburger on the menu. When a buyer orders
        /// this item, the restaurant records the purchase by creating an `Order` object with a line item
        /// for a burger. The line item includes a line item modifier: the name is cheese and the quantity
        /// is 1. The buyer has the option to order extra cheese (or no cheese). If the buyer chooses
        /// the extra cheese option, the modifier quantity increases to 2. If the buyer does not want
        /// any cheese, the modifier quantity is set to 0.
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReturnLineItemModifier : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSourceModifierUid()
        {
            return this.shouldSerialize["source_modifier_uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogObjectId()
        {
            return this.shouldSerialize["catalog_object_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCatalogVersion()
        {
            return this.shouldSerialize["catalog_version"];
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
        public bool ShouldSerializeQuantity()
        {
            return this.shouldSerialize["quantity"];
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
            return obj is OrderReturnLineItemModifier other &&                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.SourceModifierUid == null && other.SourceModifierUid == null) || (this.SourceModifierUid?.Equals(other.SourceModifierUid) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.BasePriceMoney == null && other.BasePriceMoney == null) || (this.BasePriceMoney?.Equals(other.BasePriceMoney) == true)) &&
                ((this.TotalPriceMoney == null && other.TotalPriceMoney == null) || (this.TotalPriceMoney?.Equals(other.TotalPriceMoney) == true)) &&
                ((this.Quantity == null && other.Quantity == null) || (this.Quantity?.Equals(other.Quantity) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1048986708;
            hashCode = HashCode.Combine(this.Uid, this.SourceModifierUid, this.CatalogObjectId, this.CatalogVersion, this.Name, this.BasePriceMoney, this.TotalPriceMoney);

            hashCode = HashCode.Combine(hashCode, this.Quantity);

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
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.BasePriceMoney = {(this.BasePriceMoney == null ? "null" : this.BasePriceMoney.ToString())}");
            toStringOutput.Add($"this.TotalPriceMoney = {(this.TotalPriceMoney == null ? "null" : this.TotalPriceMoney.ToString())}");
            toStringOutput.Add($"this.Quantity = {(this.Quantity == null ? "null" : this.Quantity == string.Empty ? "" : this.Quantity)}");
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
                .CatalogVersion(this.CatalogVersion)
                .Name(this.Name)
                .BasePriceMoney(this.BasePriceMoney)
                .TotalPriceMoney(this.TotalPriceMoney)
                .Quantity(this.Quantity);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_modifier_uid", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "name", false },
                { "quantity", false },
            };

            private string uid;
            private string sourceModifierUid;
            private string catalogObjectId;
            private long? catalogVersion;
            private string name;
            private Models.Money basePriceMoney;
            private Models.Money totalPriceMoney;
            private string quantity;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
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
                shouldSerialize["source_modifier_uid"] = true;
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
                shouldSerialize["catalog_object_id"] = true;
                this.catalogObjectId = catalogObjectId;
                return this;
            }

             /// <summary>
             /// CatalogVersion.
             /// </summary>
             /// <param name="catalogVersion"> catalogVersion. </param>
             /// <returns> Builder. </returns>
            public Builder CatalogVersion(long? catalogVersion)
            {
                shouldSerialize["catalog_version"] = true;
                this.catalogVersion = catalogVersion;
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
             /// Quantity.
             /// </summary>
             /// <param name="quantity"> quantity. </param>
             /// <returns> Builder. </returns>
            public Builder Quantity(string quantity)
            {
                shouldSerialize["quantity"] = true;
                this.quantity = quantity;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSourceModifierUid()
            {
                this.shouldSerialize["source_modifier_uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogObjectId()
            {
                this.shouldSerialize["catalog_object_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCatalogVersion()
            {
                this.shouldSerialize["catalog_version"] = false;
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
            public void UnsetQuantity()
            {
                this.shouldSerialize["quantity"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturnLineItemModifier. </returns>
            public OrderReturnLineItemModifier Build()
            {
                return new OrderReturnLineItemModifier(shouldSerialize,
                    this.uid,
                    this.sourceModifierUid,
                    this.catalogObjectId,
                    this.catalogVersion,
                    this.name,
                    this.basePriceMoney,
                    this.totalPriceMoney,
                    this.quantity);
            }
        }
    }
}