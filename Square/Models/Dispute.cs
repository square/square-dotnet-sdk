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
    /// Dispute.
    /// </summary>
    public class Dispute
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="Dispute"/> class.
        /// </summary>
        /// <param name="disputeId">dispute_id.</param>
        /// <param name="id">id.</param>
        /// <param name="amountMoney">amount_money.</param>
        /// <param name="reason">reason.</param>
        /// <param name="state">state.</param>
        /// <param name="dueAt">due_at.</param>
        /// <param name="disputedPayment">disputed_payment.</param>
        /// <param name="evidenceIds">evidence_ids.</param>
        /// <param name="cardBrand">card_brand.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="updatedAt">updated_at.</param>
        /// <param name="brandDisputeId">brand_dispute_id.</param>
        /// <param name="reportedDate">reported_date.</param>
        /// <param name="reportedAt">reported_at.</param>
        /// <param name="version">version.</param>
        /// <param name="locationId">location_id.</param>
        public Dispute(
            string disputeId = null,
            string id = null,
            Models.Money amountMoney = null,
            string reason = null,
            string state = null,
            string dueAt = null,
            Models.DisputedPayment disputedPayment = null,
            IList<string> evidenceIds = null,
            string cardBrand = null,
            string createdAt = null,
            string updatedAt = null,
            string brandDisputeId = null,
            string reportedDate = null,
            string reportedAt = null,
            int? version = null,
            string locationId = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "dispute_id", false },
                { "due_at", false },
                { "evidence_ids", false },
                { "brand_dispute_id", false },
                { "reported_date", false },
                { "reported_at", false },
                { "location_id", false }
            };

            if (disputeId != null)
            {
                shouldSerialize["dispute_id"] = true;
                this.DisputeId = disputeId;
            }

            this.Id = id;
            this.AmountMoney = amountMoney;
            this.Reason = reason;
            this.State = state;
            if (dueAt != null)
            {
                shouldSerialize["due_at"] = true;
                this.DueAt = dueAt;
            }

            this.DisputedPayment = disputedPayment;
            if (evidenceIds != null)
            {
                shouldSerialize["evidence_ids"] = true;
                this.EvidenceIds = evidenceIds;
            }

            this.CardBrand = cardBrand;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            if (brandDisputeId != null)
            {
                shouldSerialize["brand_dispute_id"] = true;
                this.BrandDisputeId = brandDisputeId;
            }

            if (reportedDate != null)
            {
                shouldSerialize["reported_date"] = true;
                this.ReportedDate = reportedDate;
            }

            if (reportedAt != null)
            {
                shouldSerialize["reported_at"] = true;
                this.ReportedAt = reportedAt;
            }

            this.Version = version;
            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

        }
        internal Dispute(Dictionary<string, bool> shouldSerialize,
            string disputeId = null,
            string id = null,
            Models.Money amountMoney = null,
            string reason = null,
            string state = null,
            string dueAt = null,
            Models.DisputedPayment disputedPayment = null,
            IList<string> evidenceIds = null,
            string cardBrand = null,
            string createdAt = null,
            string updatedAt = null,
            string brandDisputeId = null,
            string reportedDate = null,
            string reportedAt = null,
            int? version = null,
            string locationId = null)
        {
            this.shouldSerialize = shouldSerialize;
            DisputeId = disputeId;
            Id = id;
            AmountMoney = amountMoney;
            Reason = reason;
            State = state;
            DueAt = dueAt;
            DisputedPayment = disputedPayment;
            EvidenceIds = evidenceIds;
            CardBrand = cardBrand;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            BrandDisputeId = brandDisputeId;
            ReportedDate = reportedDate;
            ReportedAt = reportedAt;
            Version = version;
            LocationId = locationId;
        }

        /// <summary>
        /// The unique ID for this `Dispute`, generated by Square.
        /// </summary>
        [JsonProperty("dispute_id")]
        public string DisputeId { get; }

        /// <summary>
        /// The unique ID for this `Dispute`, generated by Square.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

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
        /// The list of possible reasons why a cardholder might initiate a
        /// dispute with their bank.
        /// </summary>
        [JsonProperty("reason", NullValueHandling = NullValueHandling.Ignore)]
        public string Reason { get; }

        /// <summary>
        /// The list of possible dispute states.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The deadline by which the seller must respond to the dispute, in [RFC 3339 format](https://developer.squareup.com/docs/build-basics/common-data-types/working-with-dates).
        /// </summary>
        [JsonProperty("due_at")]
        public string DueAt { get; }

        /// <summary>
        /// The payment the cardholder disputed.
        /// </summary>
        [JsonProperty("disputed_payment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DisputedPayment DisputedPayment { get; }

        /// <summary>
        /// The IDs of the evidence associated with the dispute.
        /// </summary>
        [JsonProperty("evidence_ids")]
        public IList<string> EvidenceIds { get; }

        /// <summary>
        /// Indicates a card's brand, such as `VISA` or `MASTERCARD`.
        /// </summary>
        [JsonProperty("card_brand", NullValueHandling = NullValueHandling.Ignore)]
        public string CardBrand { get; }

        /// <summary>
        /// The timestamp when the dispute was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the dispute was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        /// <summary>
        /// The ID of the dispute in the card brand system, generated by the card brand.
        /// </summary>
        [JsonProperty("brand_dispute_id")]
        public string BrandDisputeId { get; }

        /// <summary>
        /// The timestamp when the dispute was reported, in RFC 3339 format.
        /// </summary>
        [JsonProperty("reported_date")]
        public string ReportedDate { get; }

        /// <summary>
        /// The timestamp when the dispute was reported, in RFC 3339 format.
        /// </summary>
        [JsonProperty("reported_at")]
        public string ReportedAt { get; }

        /// <summary>
        /// The current version of the `Dispute`.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// The ID of the location where the dispute originated.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Dispute : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDisputeId()
        {
            return this.shouldSerialize["dispute_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDueAt()
        {
            return this.shouldSerialize["due_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEvidenceIds()
        {
            return this.shouldSerialize["evidence_ids"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBrandDisputeId()
        {
            return this.shouldSerialize["brand_dispute_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReportedDate()
        {
            return this.shouldSerialize["reported_date"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReportedAt()
        {
            return this.shouldSerialize["reported_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
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
            return obj is Dispute other &&                ((this.DisputeId == null && other.DisputeId == null) || (this.DisputeId?.Equals(other.DisputeId) == true)) &&
                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.AmountMoney == null && other.AmountMoney == null) || (this.AmountMoney?.Equals(other.AmountMoney) == true)) &&
                ((this.Reason == null && other.Reason == null) || (this.Reason?.Equals(other.Reason) == true)) &&
                ((this.State == null && other.State == null) || (this.State?.Equals(other.State) == true)) &&
                ((this.DueAt == null && other.DueAt == null) || (this.DueAt?.Equals(other.DueAt) == true)) &&
                ((this.DisputedPayment == null && other.DisputedPayment == null) || (this.DisputedPayment?.Equals(other.DisputedPayment) == true)) &&
                ((this.EvidenceIds == null && other.EvidenceIds == null) || (this.EvidenceIds?.Equals(other.EvidenceIds) == true)) &&
                ((this.CardBrand == null && other.CardBrand == null) || (this.CardBrand?.Equals(other.CardBrand) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.UpdatedAt == null && other.UpdatedAt == null) || (this.UpdatedAt?.Equals(other.UpdatedAt) == true)) &&
                ((this.BrandDisputeId == null && other.BrandDisputeId == null) || (this.BrandDisputeId?.Equals(other.BrandDisputeId) == true)) &&
                ((this.ReportedDate == null && other.ReportedDate == null) || (this.ReportedDate?.Equals(other.ReportedDate) == true)) &&
                ((this.ReportedAt == null && other.ReportedAt == null) || (this.ReportedAt?.Equals(other.ReportedAt) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1811133941;
            hashCode = HashCode.Combine(this.DisputeId, this.Id, this.AmountMoney, this.Reason, this.State, this.DueAt, this.DisputedPayment);

            hashCode = HashCode.Combine(hashCode, this.EvidenceIds, this.CardBrand, this.CreatedAt, this.UpdatedAt, this.BrandDisputeId, this.ReportedDate, this.ReportedAt);

            hashCode = HashCode.Combine(hashCode, this.Version, this.LocationId);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.DisputeId = {(this.DisputeId == null ? "null" : this.DisputeId)}");
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id)}");
            toStringOutput.Add($"this.AmountMoney = {(this.AmountMoney == null ? "null" : this.AmountMoney.ToString())}");
            toStringOutput.Add($"this.Reason = {(this.Reason == null ? "null" : this.Reason.ToString())}");
            toStringOutput.Add($"this.State = {(this.State == null ? "null" : this.State.ToString())}");
            toStringOutput.Add($"this.DueAt = {(this.DueAt == null ? "null" : this.DueAt)}");
            toStringOutput.Add($"this.DisputedPayment = {(this.DisputedPayment == null ? "null" : this.DisputedPayment.ToString())}");
            toStringOutput.Add($"this.EvidenceIds = {(this.EvidenceIds == null ? "null" : $"[{string.Join(", ", this.EvidenceIds)} ]")}");
            toStringOutput.Add($"this.CardBrand = {(this.CardBrand == null ? "null" : this.CardBrand.ToString())}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt)}");
            toStringOutput.Add($"this.UpdatedAt = {(this.UpdatedAt == null ? "null" : this.UpdatedAt)}");
            toStringOutput.Add($"this.BrandDisputeId = {(this.BrandDisputeId == null ? "null" : this.BrandDisputeId)}");
            toStringOutput.Add($"this.ReportedDate = {(this.ReportedDate == null ? "null" : this.ReportedDate)}");
            toStringOutput.Add($"this.ReportedAt = {(this.ReportedAt == null ? "null" : this.ReportedAt)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .DisputeId(this.DisputeId)
                .Id(this.Id)
                .AmountMoney(this.AmountMoney)
                .Reason(this.Reason)
                .State(this.State)
                .DueAt(this.DueAt)
                .DisputedPayment(this.DisputedPayment)
                .EvidenceIds(this.EvidenceIds)
                .CardBrand(this.CardBrand)
                .CreatedAt(this.CreatedAt)
                .UpdatedAt(this.UpdatedAt)
                .BrandDisputeId(this.BrandDisputeId)
                .ReportedDate(this.ReportedDate)
                .ReportedAt(this.ReportedAt)
                .Version(this.Version)
                .LocationId(this.LocationId);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "dispute_id", false },
                { "due_at", false },
                { "evidence_ids", false },
                { "brand_dispute_id", false },
                { "reported_date", false },
                { "reported_at", false },
                { "location_id", false },
            };

            private string disputeId;
            private string id;
            private Models.Money amountMoney;
            private string reason;
            private string state;
            private string dueAt;
            private Models.DisputedPayment disputedPayment;
            private IList<string> evidenceIds;
            private string cardBrand;
            private string createdAt;
            private string updatedAt;
            private string brandDisputeId;
            private string reportedDate;
            private string reportedAt;
            private int? version;
            private string locationId;

             /// <summary>
             /// DisputeId.
             /// </summary>
             /// <param name="disputeId"> disputeId. </param>
             /// <returns> Builder. </returns>
            public Builder DisputeId(string disputeId)
            {
                shouldSerialize["dispute_id"] = true;
                this.disputeId = disputeId;
                return this;
            }

             /// <summary>
             /// Id.
             /// </summary>
             /// <param name="id"> id. </param>
             /// <returns> Builder. </returns>
            public Builder Id(string id)
            {
                this.id = id;
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
             /// Reason.
             /// </summary>
             /// <param name="reason"> reason. </param>
             /// <returns> Builder. </returns>
            public Builder Reason(string reason)
            {
                this.reason = reason;
                return this;
            }

             /// <summary>
             /// State.
             /// </summary>
             /// <param name="state"> state. </param>
             /// <returns> Builder. </returns>
            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

             /// <summary>
             /// DueAt.
             /// </summary>
             /// <param name="dueAt"> dueAt. </param>
             /// <returns> Builder. </returns>
            public Builder DueAt(string dueAt)
            {
                shouldSerialize["due_at"] = true;
                this.dueAt = dueAt;
                return this;
            }

             /// <summary>
             /// DisputedPayment.
             /// </summary>
             /// <param name="disputedPayment"> disputedPayment. </param>
             /// <returns> Builder. </returns>
            public Builder DisputedPayment(Models.DisputedPayment disputedPayment)
            {
                this.disputedPayment = disputedPayment;
                return this;
            }

             /// <summary>
             /// EvidenceIds.
             /// </summary>
             /// <param name="evidenceIds"> evidenceIds. </param>
             /// <returns> Builder. </returns>
            public Builder EvidenceIds(IList<string> evidenceIds)
            {
                shouldSerialize["evidence_ids"] = true;
                this.evidenceIds = evidenceIds;
                return this;
            }

             /// <summary>
             /// CardBrand.
             /// </summary>
             /// <param name="cardBrand"> cardBrand. </param>
             /// <returns> Builder. </returns>
            public Builder CardBrand(string cardBrand)
            {
                this.cardBrand = cardBrand;
                return this;
            }

             /// <summary>
             /// CreatedAt.
             /// </summary>
             /// <param name="createdAt"> createdAt. </param>
             /// <returns> Builder. </returns>
            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

             /// <summary>
             /// UpdatedAt.
             /// </summary>
             /// <param name="updatedAt"> updatedAt. </param>
             /// <returns> Builder. </returns>
            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

             /// <summary>
             /// BrandDisputeId.
             /// </summary>
             /// <param name="brandDisputeId"> brandDisputeId. </param>
             /// <returns> Builder. </returns>
            public Builder BrandDisputeId(string brandDisputeId)
            {
                shouldSerialize["brand_dispute_id"] = true;
                this.brandDisputeId = brandDisputeId;
                return this;
            }

             /// <summary>
             /// ReportedDate.
             /// </summary>
             /// <param name="reportedDate"> reportedDate. </param>
             /// <returns> Builder. </returns>
            public Builder ReportedDate(string reportedDate)
            {
                shouldSerialize["reported_date"] = true;
                this.reportedDate = reportedDate;
                return this;
            }

             /// <summary>
             /// ReportedAt.
             /// </summary>
             /// <param name="reportedAt"> reportedAt. </param>
             /// <returns> Builder. </returns>
            public Builder ReportedAt(string reportedAt)
            {
                shouldSerialize["reported_at"] = true;
                this.reportedAt = reportedAt;
                return this;
            }

             /// <summary>
             /// Version.
             /// </summary>
             /// <param name="version"> version. </param>
             /// <returns> Builder. </returns>
            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

             /// <summary>
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                shouldSerialize["location_id"] = true;
                this.locationId = locationId;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDisputeId()
            {
                this.shouldSerialize["dispute_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDueAt()
            {
                this.shouldSerialize["due_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEvidenceIds()
            {
                this.shouldSerialize["evidence_ids"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBrandDisputeId()
            {
                this.shouldSerialize["brand_dispute_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReportedDate()
            {
                this.shouldSerialize["reported_date"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReportedAt()
            {
                this.shouldSerialize["reported_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> Dispute. </returns>
            public Dispute Build()
            {
                return new Dispute(shouldSerialize,
                    this.disputeId,
                    this.id,
                    this.amountMoney,
                    this.reason,
                    this.state,
                    this.dueAt,
                    this.disputedPayment,
                    this.evidenceIds,
                    this.cardBrand,
                    this.createdAt,
                    this.updatedAt,
                    this.brandDisputeId,
                    this.reportedDate,
                    this.reportedAt,
                    this.version,
                    this.locationId);
            }
        }
    }
}