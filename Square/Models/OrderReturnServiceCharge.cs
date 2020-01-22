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
            IList<Models.OrderReturnTax> returnTaxes = null,
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
            ReturnTaxes = returnTaxes;
            AppliedTaxes = appliedTaxes;
        }

        /// <summary>
        /// Unique ID that identifies the return service charge only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// `uid` of the Service Charge from the Order containing the original
        /// charge of the service charge. `source_service_charge_uid` is `null` for
        /// unlinked returns.
        /// </summary>
        [JsonProperty("source_service_charge_uid")]
        public string SourceServiceChargeUid { get; }

        /// <summary>
        /// The name of the service charge.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The catalog object ID of the associated [CatalogServiceCharge](#type-catalogservicecharge).
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The percentage of the service charge, as a string representation of
        /// a decimal number. For example, a value of `"7.25"` corresponds to a
        /// percentage of 7.25%.
        /// Exactly one of `percentage` or `amount_money` should be set.
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
        /// Indicates whether the surcharge can be taxed. Service charges
        /// calculated in the `TOTAL_PHASE` cannot be marked as taxable.
        /// </summary>
        [JsonProperty("taxable")]
        public bool? Taxable { get; }

        /// <summary>
        /// Taxes applied to the `OrderReturnServiceCharge`. By default, return-level taxes apply to
        /// `OrderReturnServiceCharge`s calculated in the `SUBTOTAL_PHASE` if `taxable` is set to `true`.  On
        /// read or retrieve, this list includes both item-level taxes and any return-level taxes
        /// apportioned to this item.
        /// This field has been deprecated in favour of `applied_taxes`.
        /// </summary>
        [JsonProperty("return_taxes")]
        public IList<Models.OrderReturnTax> ReturnTaxes { get; }

        /// <summary>
        /// The list of references to `OrderReturnTax` entities applied to the
        /// `OrderReturnServiceCharge`. Each `OrderLineItemAppliedTax` has a `tax_uid`
        /// that references the `uid` of a top-level `OrderReturnTax` that is being
        /// applied to the `OrderReturnServiceCharge`. On reads, the amount applied is
        /// populated.
        /// </summary>
        [JsonProperty("applied_taxes")]
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
                .ReturnTaxes(ReturnTaxes)
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
            private IList<Models.OrderReturnTax> returnTaxes = new List<Models.OrderReturnTax>();
            private IList<Models.OrderLineItemAppliedTax> appliedTaxes = new List<Models.OrderLineItemAppliedTax>();

            public Builder() { }
            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public Builder SourceServiceChargeUid(string value)
            {
                sourceServiceChargeUid = value;
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

            public Builder ReturnTaxes(IList<Models.OrderReturnTax> value)
            {
                returnTaxes = value;
                return this;
            }

            public Builder AppliedTaxes(IList<Models.OrderLineItemAppliedTax> value)
            {
                appliedTaxes = value;
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
                    returnTaxes,
                    appliedTaxes);
            }
        }
    }
}