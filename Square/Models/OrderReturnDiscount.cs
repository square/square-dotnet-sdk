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
    /// OrderReturnDiscount.
    /// </summary>
    public class OrderReturnDiscount
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturnDiscount"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="sourceDiscountUid">source_discount_uid.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        /// <param name="name">name.</param>
        /// <param name="type">type.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="scope">scope.</param>
        public OrderReturnDiscount(
            string uid = null,
            string sourceDiscountUid = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
            string name = null,
            string type = null,
            string percentage = null,
            Models.Money amountMoney = null,
            Models.Money appliedMoney = null,
            string scope = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_discount_uid", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "name", false },
                { "percentage", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (sourceDiscountUid != null)
            {
                shouldSerialize["source_discount_uid"] = true;
                this.SourceDiscountUid = sourceDiscountUid;
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

            this.Type = type;
            if (percentage != null)
            {
                shouldSerialize["percentage"] = true;
                this.Percentage = percentage;
            }

            this.AmountMoney = amountMoney;
            this.AppliedMoney = appliedMoney;
            this.Scope = scope;
        }
        internal OrderReturnDiscount(Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string sourceDiscountUid = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
            string name = null,
            string type = null,
            string percentage = null,
            Models.Money amountMoney = null,
            Models.Money appliedMoney = null,
            string scope = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            SourceDiscountUid = sourceDiscountUid;
            CatalogObjectId = catalogObjectId;
            CatalogVersion = catalogVersion;
            Name = name;
            Type = type;
            Percentage = percentage;
            AmountMoney = amountMoney;
            AppliedMoney = appliedMoney;
            Scope = scope;
        }

        /// <summary>
        /// A unique ID that identifies the returned discount only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The discount `uid` from the order that contains the original application of this discount.
        /// </summary>
        [JsonProperty("source_discount_uid")]
        public string SourceDiscountUid { get; }

        /// <summary>
        /// The catalog object ID referencing [CatalogDiscount]($m/CatalogDiscount).
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The version of the catalog object that this discount references.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <summary>
        /// The discount's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Indicates how the discount is applied to the associated line item or order.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The percentage of the tax, as a string representation of a decimal number.
        /// A value of `"7.25"` corresponds to a percentage of 7.25%.
        /// `percentage` is not set for amount-based discounts.
        /// </summary>
        [JsonProperty("percentage")]
        public string Percentage { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("amount_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("applied_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money AppliedMoney { get; }

        /// <summary>
        /// Indicates whether this is a line-item or order-level discount.
        /// </summary>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReturnDiscount : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeSourceDiscountUid()
        {
            return this.shouldSerialize["source_discount_uid"];
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
        public bool ShouldSerializePercentage()
        {
            return this.shouldSerialize["percentage"];
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

            return obj is OrderReturnDiscount other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.SourceDiscountUid == null && other.SourceDiscountUid == null) || (this.SourceDiscountUid?.Equals(other.SourceDiscountUid) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Percentage == null && other.Percentage == null) || (this.Percentage?.Equals(other.Percentage) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.Scope == null && other.Scope == null) || (this.Scope?.Equals(other.Scope) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -2080508300;
            hashCode = HashCode.Combine(this.Uid, this.SourceDiscountUid, this.CatalogObjectId, this.CatalogVersion, this.Name, this.Type, this.Percentage);

            hashCode = HashCode.Combine(hashCode, this.AmountMoney, this.AppliedMoney, this.Scope);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid == string.Empty ? "" : this.Uid)}");
            toStringOutput.Add($"this.SourceDiscountUid = {(this.SourceDiscountUid == null ? "null" : this.SourceDiscountUid == string.Empty ? "" : this.SourceDiscountUid)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Percentage = {(this.Percentage == null ? "null" : this.Percentage == string.Empty ? "" : this.Percentage)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
            toStringOutput.Add($"this.Scope = {(this.Scope == null ? "null" : this.Scope.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .SourceDiscountUid(this.SourceDiscountUid)
                .CatalogObjectId(this.CatalogObjectId)
                .CatalogVersion(this.CatalogVersion)
                .Name(this.Name)
                .Type(this.Type)
                .Percentage(this.Percentage)
                .AmountMoney(this.AmountMoney)
                .AppliedMoney(this.AppliedMoney)
                .Scope(this.Scope);
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
                { "source_discount_uid", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "name", false },
                { "percentage", false },
            };

            private string uid;
            private string sourceDiscountUid;
            private string catalogObjectId;
            private long? catalogVersion;
            private string name;
            private string type;
            private string percentage;
            private Models.Money amountMoney;
            private Models.Money appliedMoney;
            private string scope;

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
             /// SourceDiscountUid.
             /// </summary>
             /// <param name="sourceDiscountUid"> sourceDiscountUid. </param>
             /// <returns> Builder. </returns>
            public Builder SourceDiscountUid(string sourceDiscountUid)
            {
                shouldSerialize["source_discount_uid"] = true;
                this.sourceDiscountUid = sourceDiscountUid;
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
             /// Percentage.
             /// </summary>
             /// <param name="percentage"> percentage. </param>
             /// <returns> Builder. </returns>
            public Builder Percentage(string percentage)
            {
                shouldSerialize["percentage"] = true;
                this.percentage = percentage;
                return this;
            }

             /// <summary>
             /// AmountMoney.
             /// </summary>
             /// <param name="amountMoney"> amountMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

             /// <summary>
             /// AppliedMoney.
             /// </summary>
             /// <param name="appliedMoney"> appliedMoney. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedMoney(Models.Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

             /// <summary>
             /// Scope.
             /// </summary>
             /// <param name="scope"> scope. </param>
             /// <returns> Builder. </returns>
            public Builder Scope(string scope)
            {
                this.scope = scope;
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
            public void UnsetSourceDiscountUid()
            {
                this.shouldSerialize["source_discount_uid"] = false;
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
            public void UnsetPercentage()
            {
                this.shouldSerialize["percentage"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturnDiscount. </returns>
            public OrderReturnDiscount Build()
            {
                return new OrderReturnDiscount(shouldSerialize,
                    this.uid,
                    this.sourceDiscountUid,
                    this.catalogObjectId,
                    this.catalogVersion,
                    this.name,
                    this.type,
                    this.percentage,
                    this.amountMoney,
                    this.appliedMoney,
                    this.scope);
            }
        }
    }
}