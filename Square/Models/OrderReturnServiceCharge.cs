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
    public class OrderReturnServiceCharge 
    {
        public OrderReturnServiceCharge(string uid = null,
            string sourceServiceChargeUid = null,
            string name = null,
            string catalogObjectId = null,
            string percentage = null,
            Models.Money amountMoney = null,
            Models.Money appliedMoney = null,
            Models.Money totalMoney = null,
            Models.Money totalTaxMoney = null,
            string calculationPhase = null,
            bool? taxable = null,
            IList<Models.OrderLineItemAppliedTax> appliedTaxes = null)
        {
            Uid = uid;
            SourceServiceChargeUid = sourceServiceChargeUid;
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
        }

        /// <summary>
        /// Unique ID that identifies the return service charge only within this order.
        /// </summary>
        [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
        public string Uid { get; }

        /// <summary>
        /// `uid` of the Service Charge from the Order containing the original
        /// charge of the service charge. `source_service_charge_uid` is `null` for
        /// unlinked returns.
        /// </summary>
        [JsonProperty("source_service_charge_uid", NullValueHandling = NullValueHandling.Ignore)]
        public string SourceServiceChargeUid { get; }

        /// <summary>
        /// The name of the service charge.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The catalog object ID of the associated [CatalogServiceCharge](#type-catalogservicecharge).
        /// </summary>
        [JsonProperty("catalog_object_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The percentage of the service charge, as a string representation of
        /// a decimal number. For example, a value of `"7.25"` corresponds to a
        /// percentage of 7.25%.
        /// Exactly one of `percentage` or `amount_money` should be set.
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
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("total_tax_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money TotalTaxMoney { get; }

        /// <summary>
        /// Represents a phase in the process of calculating order totals.
        /// Service charges are applied __after__ the indicated phase.
        /// [Read more about how order totals are calculated.](https://developer.squareup.com/docs/docs/orders-api/how-it-works#how-totals-are-calculated)
        /// </summary>
        [JsonProperty("calculation_phase", NullValueHandling = NullValueHandling.Ignore)]
        public string CalculationPhase { get; }

        /// <summary>
        /// Indicates whether the surcharge can be taxed. Service charges
        /// calculated in the `TOTAL_PHASE` cannot be marked as taxable.
        /// </summary>
        [JsonProperty("taxable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Taxable { get; }

        /// <summary>
        /// The list of references to `OrderReturnTax` entities applied to the
        /// `OrderReturnServiceCharge`. Each `OrderLineItemAppliedTax` has a `tax_uid`
        /// that references the `uid` of a top-level `OrderReturnTax` that is being
        /// applied to the `OrderReturnServiceCharge`. On reads, the amount applied is
        /// populated.
        /// </summary>
        [JsonProperty("applied_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderLineItemAppliedTax> AppliedTaxes { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .SourceServiceChargeUid(SourceServiceChargeUid)
                .Name(Name)
                .CatalogObjectId(CatalogObjectId)
                .Percentage(Percentage)
                .AmountMoney(AmountMoney)
                .AppliedMoney(AppliedMoney)
                .TotalMoney(TotalMoney)
                .TotalTaxMoney(TotalTaxMoney)
                .CalculationPhase(CalculationPhase)
                .Taxable(Taxable)
                .AppliedTaxes(AppliedTaxes);
            return builder;
        }

        public class Builder
        {
            private string uid;
            private string sourceServiceChargeUid;
            private string name;
            private string catalogObjectId;
            private string percentage;
            private Models.Money amountMoney;
            private Models.Money appliedMoney;
            private Models.Money totalMoney;
            private Models.Money totalTaxMoney;
            private string calculationPhase;
            private bool? taxable;
            private IList<Models.OrderLineItemAppliedTax> appliedTaxes;



            public Builder Uid(string uid)
            {
                this.uid = uid;
                return this;
            }

            public Builder SourceServiceChargeUid(string sourceServiceChargeUid)
            {
                this.sourceServiceChargeUid = sourceServiceChargeUid;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder CatalogObjectId(string catalogObjectId)
            {
                this.catalogObjectId = catalogObjectId;
                return this;
            }

            public Builder Percentage(string percentage)
            {
                this.percentage = percentage;
                return this;
            }

            public Builder AmountMoney(Models.Money amountMoney)
            {
                this.amountMoney = amountMoney;
                return this;
            }

            public Builder AppliedMoney(Models.Money appliedMoney)
            {
                this.appliedMoney = appliedMoney;
                return this;
            }

            public Builder TotalMoney(Models.Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

            public Builder TotalTaxMoney(Models.Money totalTaxMoney)
            {
                this.totalTaxMoney = totalTaxMoney;
                return this;
            }

            public Builder CalculationPhase(string calculationPhase)
            {
                this.calculationPhase = calculationPhase;
                return this;
            }

            public Builder Taxable(bool? taxable)
            {
                this.taxable = taxable;
                return this;
            }

            public Builder AppliedTaxes(IList<Models.OrderLineItemAppliedTax> appliedTaxes)
            {
                this.appliedTaxes = appliedTaxes;
                return this;
            }

            public OrderReturnServiceCharge Build()
            {
                return new OrderReturnServiceCharge(uid,
                    sourceServiceChargeUid,
                    name,
                    catalogObjectId,
                    percentage,
                    amountMoney,
                    appliedMoney,
                    totalMoney,
                    totalTaxMoney,
                    calculationPhase,
                    taxable,
                    appliedTaxes);
            }
        }
    }
}