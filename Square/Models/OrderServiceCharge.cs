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
    public class OrderServiceCharge 
    {
        public OrderServiceCharge(string uid = null,
            string name = null,
            string catalogObjectId = null,
            string percentage = null,
            Models.Money amountMoney = null,
            Models.Money appliedMoney = null,
            Models.Money totalMoney = null,
            Models.Money totalTaxMoney = null,
            string calculationPhase = null,
            bool? taxable = null,
            IList<Models.OrderLineItemAppliedTax> appliedTaxes = null,
            IDictionary<string, string> metadata = null)
        {
            Uid = uid;
            Name = name;
            CatalogObjectId = catalogObjectId;
            Percentage = percentage;
            AmountMoney = amountMoney;
            AppliedMoney = appliedMoney;
            TotalMoney = totalMoney;
            TotalTaxMoney = totalTaxMoney;
            CalculationPhase = calculationPhase;
            Taxable = taxable;
            AppliedTaxes = appliedTaxes;
            Metadata = metadata;
        }

        /// <summary>
        /// Unique ID that identifies the service charge only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The name of the service charge.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The catalog object ID referencing the service charge [CatalogObject](#type-catalogobject).
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The service charge percentage as a string representation of a
        /// decimal number. For example, `"7.25"` indicates a service charge of 7.25%.
        /// Exactly 1 of `percentage` or `amount_money` should be set.
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
        [JsonProperty("amount_money")]
        public Models.Money AmountMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("applied_money")]
        public Models.Money AppliedMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_money")]
        public Models.Money TotalMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_tax_money")]
        public Models.Money TotalTaxMoney { get; }

        /// <summary>
        /// Represents a phase in the process of calculating order totals.
        /// Service charges are applied __after__ the indicated phase.
        /// [Read more about how order totals are calculated.](https://developer.squareup.com/docs/docs/orders-api/how-it-works#how-totals-are-calculated)
        /// </summary>
        [JsonProperty("calculation_phase")]
        public string CalculationPhase { get; }

        /// <summary>
        /// Indicates whether the service charge can be taxed. If set to `true`,
        /// order-level taxes automatically apply to the service charge. Note that
        /// service charges calculated in the `TOTAL_PHASE` cannot be marked as taxable.
        /// </summary>
        [JsonProperty("taxable")]
        public bool? Taxable { get; }

        /// <summary>
        /// The list of references to taxes applied to this service charge. Each
        /// `OrderLineItemAppliedTax` has a `tax_uid` that references the `uid` of a top-level
        /// `OrderLineItemTax` that is being applied to this service charge. On reads, the amount applied
        /// is populated.
        /// An `OrderLineItemAppliedTax` will be automatically created on every taxable service charge
        /// for all `ORDER` scoped taxes that are added to the order. `OrderLineItemAppliedTax` records
        /// for `LINE_ITEM` scoped taxes must be added in requests for the tax to apply to any taxable
        /// service charge.  Taxable service charges have the `taxable` field set to true and calculated
        /// in the `SUBTOTAL_PHASE`.
        /// To change the amount of a tax, modify the referenced top-level tax.
        /// </summary>
        [JsonProperty("applied_taxes")]
        public IList<Models.OrderLineItemAppliedTax> AppliedTaxes { get; }

        /// <summary>
        /// Application-defined data attached to this service charge. Metadata fields are intended
        /// to store descriptive references or associations with an entity in another system or store brief
        /// information about the object. Square does not process this field; it only stores and returns it
        /// in relevant API calls. Do not use metadata to store any sensitive information (personally
        /// identifiable information, card details, etc.).
        /// Keys written by applications must be 60 characters or less and must be in the character set
        /// `[a-zA-Z0-9_-]`. Entries may also include metadata generated by Square. These keys are prefixed
        /// with a namespace, separated from the key with a ':' character.
        /// Values have a max length of 255 characters.
        /// An application may have up to 10 entries per metadata field.
        /// Entries written by applications are private and can only be read or modified by the same
        /// application.
        /// See [Metadata](https://developer.squareup.com/docs/build-basics/metadata) for more information.
        /// </summary>
        [JsonProperty("metadata")]
        public IDictionary<string, string> Metadata { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .Name(Name)
                .CatalogObjectId(CatalogObjectId)
                .Percentage(Percentage)
                .AmountMoney(AmountMoney)
                .AppliedMoney(AppliedMoney)
                .TotalMoney(TotalMoney)
                .TotalTaxMoney(TotalTaxMoney)
                .CalculationPhase(CalculationPhase)
                .Taxable(Taxable)
                .AppliedTaxes(AppliedTaxes)
                .Metadata(Metadata);
            return builder;
        }

        public class Builder
        {
            private string uid;
            private string name;
            private string catalogObjectId;
            private string percentage;
            private Models.Money amountMoney;
            private Models.Money appliedMoney;
            private Models.Money totalMoney;
            private Models.Money totalTaxMoney;
            private string calculationPhase;
            private bool? taxable;
            private IList<Models.OrderLineItemAppliedTax> appliedTaxes = new List<Models.OrderLineItemAppliedTax>();
            private IDictionary<string, string> metadata = new Dictionary<string, string>();

            public Builder() { }
            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder CatalogObjectId(string value)
            {
                catalogObjectId = value;
                return this;
            }

            public Builder Percentage(string value)
            {
                percentage = value;
                return this;
            }

            public Builder AmountMoney(Models.Money value)
            {
                amountMoney = value;
                return this;
            }

            public Builder AppliedMoney(Models.Money value)
            {
                appliedMoney = value;
                return this;
            }

            public Builder TotalMoney(Models.Money value)
            {
                totalMoney = value;
                return this;
            }

            public Builder TotalTaxMoney(Models.Money value)
            {
                totalTaxMoney = value;
                return this;
            }

            public Builder CalculationPhase(string value)
            {
                calculationPhase = value;
                return this;
            }

            public Builder Taxable(bool? value)
            {
                taxable = value;
                return this;
            }

            public Builder AppliedTaxes(IList<Models.OrderLineItemAppliedTax> value)
            {
                appliedTaxes = value;
                return this;
            }

            public Builder Metadata(IDictionary<string, string> value)
            {
                metadata = value;
                return this;
            }

            public OrderServiceCharge Build()
            {
                return new OrderServiceCharge(uid,
                    name,
                    catalogObjectId,
                    percentage,
                    amountMoney,
                    appliedMoney,
                    totalMoney,
                    totalTaxMoney,
                    calculationPhase,
                    taxable,
                    appliedTaxes,
                    metadata);
            }
        }
    }
}