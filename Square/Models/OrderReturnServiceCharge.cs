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
    /// OrderReturnServiceCharge.
    /// </summary>
    public class OrderReturnServiceCharge
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturnServiceCharge"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="sourceServiceChargeUid">source_service_charge_uid.</param>
        /// <param name="name">name.</param>
        /// <param name="catalogObjectId">catalog_object_id.</param>
        /// <param name="catalogVersion">catalog_version.</param>
        /// <param name="percentage">percentage.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="appliedMoney">applied_money.</param>
        /// <param name="totalMoney">total_money.</param>
        /// <param name="totalTaxMoney">total_tax_money.</param>
        /// <param name="calculationPhase">calculation_phase.</param>
        /// <param name="taxable">taxable.</param>
        /// <param name="appliedTaxes">applied_taxes.</param>
        /// <param name="treatmentType">treatment_type.</param>
        /// <param name="scope">scope.</param>
        public OrderReturnServiceCharge(
            string uid = null,
            string sourceServiceChargeUid = null,
            string name = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
            string percentage = null,
            Models.Money amountMoney = null,
            Models.Money appliedMoney = null,
            Models.Money totalMoney = null,
            Models.Money totalTaxMoney = null,
            string calculationPhase = null,
            bool? taxable = null,
            IList<Models.OrderLineItemAppliedTax> appliedTaxes = null,
            string treatmentType = null,
            string scope = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_service_charge_uid", false },
                { "name", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "percentage", false },
                { "taxable", false },
                { "applied_taxes", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (sourceServiceChargeUid != null)
            {
                shouldSerialize["source_service_charge_uid"] = true;
                this.SourceServiceChargeUid = sourceServiceChargeUid;
            }

            if (name != null)
            {
                shouldSerialize["name"] = true;
                this.Name = name;
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

            if (percentage != null)
            {
                shouldSerialize["percentage"] = true;
                this.Percentage = percentage;
            }

            this.AmountMoney = amountMoney;
            this.AppliedMoney = appliedMoney;
            this.TotalMoney = totalMoney;
            this.TotalTaxMoney = totalTaxMoney;
            this.CalculationPhase = calculationPhase;
            if (taxable != null)
            {
                shouldSerialize["taxable"] = true;
                this.Taxable = taxable;
            }

            if (appliedTaxes != null)
            {
                shouldSerialize["applied_taxes"] = true;
                this.AppliedTaxes = appliedTaxes;
            }

            this.TreatmentType = treatmentType;
            this.Scope = scope;
        }
        internal OrderReturnServiceCharge(Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string sourceServiceChargeUid = null,
            string name = null,
            string catalogObjectId = null,
            long? catalogVersion = null,
            string percentage = null,
            Models.Money amountMoney = null,
            Models.Money appliedMoney = null,
            Models.Money totalMoney = null,
            Models.Money totalTaxMoney = null,
            string calculationPhase = null,
            bool? taxable = null,
            IList<Models.OrderLineItemAppliedTax> appliedTaxes = null,
            string treatmentType = null,
            string scope = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            SourceServiceChargeUid = sourceServiceChargeUid;
            Name = name;
            CatalogObjectId = catalogObjectId;
            CatalogVersion = catalogVersion;
            Percentage = percentage;
            AmountMoney = amountMoney;
            AppliedMoney = appliedMoney;
            TotalMoney = totalMoney;
            TotalTaxMoney = totalTaxMoney;
            CalculationPhase = calculationPhase;
            Taxable = taxable;
            AppliedTaxes = appliedTaxes;
            TreatmentType = treatmentType;
            Scope = scope;
        }

        /// <summary>
        /// A unique ID that identifies the return service charge only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// The service charge `uid` from the order containing the original
        /// service charge. `source_service_charge_uid` is `null` for
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
        /// The catalog object ID of the associated [OrderServiceCharge](entity:OrderServiceCharge).
        /// </summary>
        [JsonProperty("catalog_object_id")]
        public string CatalogObjectId { get; }

        /// <summary>
        /// The version of the catalog object that this service charge references.
        /// </summary>
        [JsonProperty("catalog_version")]
        public long? CatalogVersion { get; }

        /// <summary>
        /// The percentage of the service charge, as a string representation of
        /// a decimal number. For example, a value of `"7.25"` corresponds to a
        /// percentage of 7.25%.
        /// Either `percentage` or `amount_money` should be set, but not both.
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
        /// Service charges are applied after the indicated phase.
        /// [Read more about how order totals are calculated.](https://developer.squareup.com/docs/orders-api/how-it-works#how-totals-are-calculated)
        /// </summary>
        [JsonProperty("calculation_phase", NullValueHandling = NullValueHandling.Ignore)]
        public string CalculationPhase { get; }

        /// <summary>
        /// Indicates whether the surcharge can be taxed. Service charges
        /// calculated in the `TOTAL_PHASE` cannot be marked as taxable.
        /// </summary>
        [JsonProperty("taxable")]
        public bool? Taxable { get; }

        /// <summary>
        /// The list of references to `OrderReturnTax` entities applied to the
        /// `OrderReturnServiceCharge`. Each `OrderLineItemAppliedTax` has a `tax_uid`
        /// that references the `uid` of a top-level `OrderReturnTax` that is being
        /// applied to the `OrderReturnServiceCharge`. On reads, the applied amount is
        /// populated.
        /// </summary>
        [JsonProperty("applied_taxes")]
        public IList<Models.OrderLineItemAppliedTax> AppliedTaxes { get; }

        /// <summary>
        /// Indicates whether the service charge will be treated as a value-holding line item or
        /// apportioned toward a line item.
        /// </summary>
        [JsonProperty("treatment_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TreatmentType { get; }

        /// <summary>
        /// Indicates whether this is a line-item or order-level apportioned
        /// service charge.
        /// </summary>
        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"OrderReturnServiceCharge : ({string.Join(", ", toStringOutput)})";
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
        public bool ShouldSerializeSourceServiceChargeUid()
        {
            return this.shouldSerialize["source_service_charge_uid"];
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
        public bool ShouldSerializePercentage()
        {
            return this.shouldSerialize["percentage"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeTaxable()
        {
            return this.shouldSerialize["taxable"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAppliedTaxes()
        {
            return this.shouldSerialize["applied_taxes"];
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
            return obj is OrderReturnServiceCharge other &&                ((this.Uid == null && other.Uid == null) || (this.Uid?.Equals(other.Uid) == true)) &&
                ((this.SourceServiceChargeUid == null && other.SourceServiceChargeUid == null) || (this.SourceServiceChargeUid?.Equals(other.SourceServiceChargeUid) == true)) &&
                ((this.Name == null && other.Name == null) || (this.Name?.Equals(other.Name) == true)) &&
                ((this.CatalogObjectId == null && other.CatalogObjectId == null) || (this.CatalogObjectId?.Equals(other.CatalogObjectId) == true)) &&
                ((this.CatalogVersion == null && other.CatalogVersion == null) || (this.CatalogVersion?.Equals(other.CatalogVersion) == true)) &&
                ((this.Percentage == null && other.Percentage == null) || (this.Percentage?.Equals(other.Percentage) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.AppliedMoney == null && other.AppliedMoney == null) || (this.AppliedMoney?.Equals(other.AppliedMoney) == true)) &&
                ((this.TotalMoney == null && other.TotalMoney == null) || (this.TotalMoney?.Equals(other.TotalMoney) == true)) &&
                ((this.TotalTaxMoney == null && other.TotalTaxMoney == null) || (this.TotalTaxMoney?.Equals(other.TotalTaxMoney) == true)) &&
                ((this.CalculationPhase == null && other.CalculationPhase == null) || (this.CalculationPhase?.Equals(other.CalculationPhase) == true)) &&
                ((this.Taxable == null && other.Taxable == null) || (this.Taxable?.Equals(other.Taxable) == true)) &&
                ((this.AppliedTaxes == null && other.AppliedTaxes == null) || (this.AppliedTaxes?.Equals(other.AppliedTaxes) == true)) &&
                ((this.TreatmentType == null && other.TreatmentType == null) || (this.TreatmentType?.Equals(other.TreatmentType) == true)) &&
                ((this.Scope == null && other.Scope == null) || (this.Scope?.Equals(other.Scope) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 802596311;
            hashCode = HashCode.Combine(this.Uid, this.SourceServiceChargeUid, this.Name, this.CatalogObjectId, this.CatalogVersion, this.Percentage, this.AmountMoney);

            hashCode = HashCode.Combine(hashCode, this.AppliedMoney, this.TotalMoney, this.TotalTaxMoney, this.CalculationPhase, this.Taxable, this.AppliedTaxes, this.TreatmentType);

            hashCode = HashCode.Combine(hashCode, this.Scope);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {(this.Uid == null ? "null" : this.Uid)}");
            toStringOutput.Add($"this.SourceServiceChargeUid = {(this.SourceServiceChargeUid == null ? "null" : this.SourceServiceChargeUid)}");
            toStringOutput.Add($"this.Name = {(this.Name == null ? "null" : this.Name)}");
            toStringOutput.Add($"this.CatalogObjectId = {(this.CatalogObjectId == null ? "null" : this.CatalogObjectId)}");
            toStringOutput.Add($"this.CatalogVersion = {(this.CatalogVersion == null ? "null" : this.CatalogVersion.ToString())}");
            toStringOutput.Add($"this.Percentage = {(this.Percentage == null ? "null" : this.Percentage)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.AppliedMoney = {(this.AppliedMoney == null ? "null" : this.AppliedMoney.ToString())}");
            toStringOutput.Add($"this.TotalMoney = {(this.TotalMoney == null ? "null" : this.TotalMoney.ToString())}");
            toStringOutput.Add($"this.TotalTaxMoney = {(this.TotalTaxMoney == null ? "null" : this.TotalTaxMoney.ToString())}");
            toStringOutput.Add($"this.CalculationPhase = {(this.CalculationPhase == null ? "null" : this.CalculationPhase.ToString())}");
            toStringOutput.Add($"this.Taxable = {(this.Taxable == null ? "null" : this.Taxable.ToString())}");
            toStringOutput.Add($"this.AppliedTaxes = {(this.AppliedTaxes == null ? "null" : $"[{string.Join(", ", this.AppliedTaxes)} ]")}");
            toStringOutput.Add($"this.TreatmentType = {(this.TreatmentType == null ? "null" : this.TreatmentType.ToString())}");
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
                .SourceServiceChargeUid(this.SourceServiceChargeUid)
                .Name(this.Name)
                .CatalogObjectId(this.CatalogObjectId)
                .CatalogVersion(this.CatalogVersion)
                .Percentage(this.Percentage)
                .AmountMoney(this.AmountMoney)
                .AppliedMoney(this.AppliedMoney)
                .TotalMoney(this.TotalMoney)
                .TotalTaxMoney(this.TotalTaxMoney)
                .CalculationPhase(this.CalculationPhase)
                .Taxable(this.Taxable)
                .AppliedTaxes(this.AppliedTaxes)
                .TreatmentType(this.TreatmentType)
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
                { "source_service_charge_uid", false },
                { "name", false },
                { "catalog_object_id", false },
                { "catalog_version", false },
                { "percentage", false },
                { "taxable", false },
                { "applied_taxes", false },
            };

            private string uid;
            private string sourceServiceChargeUid;
            private string name;
            private string catalogObjectId;
            private long? catalogVersion;
            private string percentage;
            private Models.Money amountMoney;
            private Models.Money appliedMoney;
            private Models.Money totalMoney;
            private Models.Money totalTaxMoney;
            private string calculationPhase;
            private bool? taxable;
            private IList<Models.OrderLineItemAppliedTax> appliedTaxes;
            private string treatmentType;
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
             /// SourceServiceChargeUid.
             /// </summary>
             /// <param name="sourceServiceChargeUid"> sourceServiceChargeUid. </param>
             /// <returns> Builder. </returns>
            public Builder SourceServiceChargeUid(string sourceServiceChargeUid)
            {
                shouldSerialize["source_service_charge_uid"] = true;
                this.sourceServiceChargeUid = sourceServiceChargeUid;
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
             /// TotalMoney.
             /// </summary>
             /// <param name="totalMoney"> totalMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalMoney(Models.Money totalMoney)
            {
                this.totalMoney = totalMoney;
                return this;
            }

             /// <summary>
             /// TotalTaxMoney.
             /// </summary>
             /// <param name="totalTaxMoney"> totalTaxMoney. </param>
             /// <returns> Builder. </returns>
            public Builder TotalTaxMoney(Models.Money totalTaxMoney)
            {
                this.totalTaxMoney = totalTaxMoney;
                return this;
            }

             /// <summary>
             /// CalculationPhase.
             /// </summary>
             /// <param name="calculationPhase"> calculationPhase. </param>
             /// <returns> Builder. </returns>
            public Builder CalculationPhase(string calculationPhase)
            {
                this.calculationPhase = calculationPhase;
                return this;
            }

             /// <summary>
             /// Taxable.
             /// </summary>
             /// <param name="taxable"> taxable. </param>
             /// <returns> Builder. </returns>
            public Builder Taxable(bool? taxable)
            {
                shouldSerialize["taxable"] = true;
                this.taxable = taxable;
                return this;
            }

             /// <summary>
             /// AppliedTaxes.
             /// </summary>
             /// <param name="appliedTaxes"> appliedTaxes. </param>
             /// <returns> Builder. </returns>
            public Builder AppliedTaxes(IList<Models.OrderLineItemAppliedTax> appliedTaxes)
            {
                shouldSerialize["applied_taxes"] = true;
                this.appliedTaxes = appliedTaxes;
                return this;
            }

             /// <summary>
             /// TreatmentType.
             /// </summary>
             /// <param name="treatmentType"> treatmentType. </param>
             /// <returns> Builder. </returns>
            public Builder TreatmentType(string treatmentType)
            {
                this.treatmentType = treatmentType;
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
            public void UnsetSourceServiceChargeUid()
            {
                this.shouldSerialize["source_service_charge_uid"] = false;
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
            public void UnsetPercentage()
            {
                this.shouldSerialize["percentage"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetTaxable()
            {
                this.shouldSerialize["taxable"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAppliedTaxes()
            {
                this.shouldSerialize["applied_taxes"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturnServiceCharge. </returns>
            public OrderReturnServiceCharge Build()
            {
                return new OrderReturnServiceCharge(shouldSerialize,
                    this.uid,
                    this.sourceServiceChargeUid,
                    this.name,
                    this.catalogObjectId,
                    this.catalogVersion,
                    this.percentage,
                    this.amountMoney,
                    this.appliedMoney,
                    this.totalMoney,
                    this.totalTaxMoney,
                    this.calculationPhase,
                    this.taxable,
                    this.appliedTaxes,
                    this.treatmentType,
                    this.scope);
            }
        }
    }
}