using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class OrderReturnTax 
    {
        public OrderReturnTax(string uid = null,
            string sourceTaxUid = null,
            string catalogObjectId = null,
            string name = null,
            string type = null,
            string percentage = null,
            Models.Money appliedMoney = null,
            string scope = null)
        {
            Uid = uid;
            SourceTaxUid = sourceTaxUid;
            CatalogObjectId = catalogObjectId;
            Name = name;
            Type = type;
            Percentage = percentage;
            AppliedMoney = appliedMoney;
            Scope = scope;
        }

        /// <summary>
        /// Unique ID that identifies the return tax only within this order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// `uid` of the Tax from the Order which contains the original charge of this tax.
        /// </summary>
        [JsonProperty("source_tax_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceTaxUid { get; }

        /// <summary>
        /// The catalog object id referencing [CatalogTax](#type-catalogtax).
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
        /// Indicates whether this is a line item or order level tax.
        /// </summary>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .SourceTaxUid(SourceTaxUid)
                .CatalogObjectId(CatalogObjectId)
                .Name(Name)
                .Type(Type)
                .Percentage(Percentage)
                .AppliedMoney(AppliedMoney)
                .Scope(Scope);
            return builder;
        }

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



            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder SourceTaxUid(string sourceTaxUid)
            {
                this.sourceTaxUid = sourceTaxUid;
                return this;
            }

            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
                return this;
            }

            public Builder Percentage(string percentage)
            {
                this.percentage = percentage;
                return this;
            }

            public Builder AppliedMoney(Models.Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

            public Builder Scope(string scope)
            {
                this.scope = scope;
                return this;
            }

            public OrderReturnTax Build()
            {
                return new OrderReturnTax(uid,
                    sourceTaxUid,
                    catalogObjectId,
                    name,
                    type,
                    percentage,
                    appliedMoney,
                    scope);
            }
        }
    }
}