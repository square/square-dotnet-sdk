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
    /// OrderReturnTax.
    /// </summary>
    public class OrderReturnTax
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturnTax"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="sourceTaxUid">source_tax_uid.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="name">name.</param>
        /// <param name="type">type.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="scope">scope.</param>
        public OrderReturnTax(
            string uid = null,
            string sourceTaxUid = null,
            string catalogObjectId = null,
            string name = null,
            string type = null,
            string percentage = null,
            Models.Money appliedMoney = null,
            string scope = null)
        {
            this.Uid = uid;
            this.SourceTaxUid = sourceTaxUid;
            this.CatalogObjectId = catalogObjectId;
            this.Name = name;
            this.Type = type;
            this.Percentage = percentage;
            this.AppliedMoney = appliedMoney;
            this.Scope = scope;
        }

        /// <summary>
        /// A unique ID that identifies the returned tax only within this order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// The tax `uid` from the order that contains the original tax charge.
        /// </summary>
        [JsonProperty("source_tax_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceTaxUid { get; }

        /// <summary>
        /// The catalog object ID referencing [CatalogTax]($m/CatalogTax).
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The tax's name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// Indicates how the tax is applied to the associated line item or order.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; }

        /// <summary>
        /// The percentage of the tax, as a string representation of a decimal number.
        /// For example, a value of `"7.25"` corresponds to a percentage of 7.25%.
        /// </summary>
        [JsonProperty("percentage", NullValueHandling = NullValueHandling.Ignore)]
        public string Percentage { get; }

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
        /// Indicates whether this is a line-item or order-level tax.
        /// </summary>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReturnTax : ({string.Join(", ", toStringOutput)})";
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

            return obj is OrderReturnTax other &&
                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.SourceTaxUid == null && other.SourceTaxUid == null) || (this.SourceTaxUid?.Equals(other.SourceTaxUid) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Percentage == null && other.Percentage == null) || (this.Percentage?.Equals(other.Percentage) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.Scope == null && other.Scope == null) || (this.Scope?.Equals(other.Scope) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -778295832;

            if (this.Uid != null)
            {
               hashCode += this.Uid.GetHashCode();
            }

            if (this.SourceTaxUid != null)
            {
               hashCode += this.SourceTaxUid.GetHashCode();
            }

            if (this.CatalogObjectId != null)
            {
               hashCode += this.CatalogObjectId.GetHashCode();
            }

            if (this.Name != null)
            {
               hashCode += this.Name.GetHashCode();
            }

            if (this.Type != null)
            {
               hashCode += this.Type.GetHashCode();
            }

            if (this.Percentage != null)
            {
               hashCode += this.Percentage.GetHashCode();
            }

            if (this.AppliedMoney != null)
            {
               hashCode += this.AppliedMoney.GetHashCode();
            }

            if (this.Scope != null)
            {
               hashCode += this.Scope.GetHashCode();
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
            toStringOutput.Add($"this.SourceTaxUid = {(this.SourceTaxUid == null ? "null" : this.SourceTaxUid == string.Empty ? "" : this.SourceTaxUid)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId == string.Empty ? "" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name == string.Empty ? "" : this.Name)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.Percentage = {(this.Percentage == null ? "null" : this.Percentage == string.Empty ? "" : this.Percentage)}");
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
                .SourceTaxUid(this.SourceTaxUid)
                .CatalogObjectId(this.CatalogObjectId)
                .Name(this.Name)
                .Type(this.Type)
                .Percentage(this.Percentage)
                .AppliedMoney(this.AppliedMoney)
                .Scope(this.Scope);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string uid;
            private string sourceTaxUid;
            private string catalogObjectId;
            private string name;
            private string type;
            private string percentage;
            private Models.Money appliedMoney;
            private string scope;

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
             /// SourceTaxUid.
             /// </summary>
             /// <param name="sourceTaxUid"> sourceTaxUid. </param>
             /// <returns> Builder. </returns>
            public Builder SourceTaxUid(string sourceTaxUid)
            {
                this.sourceTaxUid = sourceTaxUid;
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
                this.percentage = percentage;
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
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturnTax. </returns>
            public OrderReturnTax Build()
            {
                return new OrderReturnTax(
                    this.uid,
                    this.sourceTaxUid,
                    this.catalogObjectId,
                    this.name,
                    this.type,
                    this.percentage,
                    this.appliedMoney,
                    this.scope);
            }
        }
    }
}