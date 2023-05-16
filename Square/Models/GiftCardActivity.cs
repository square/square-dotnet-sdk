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
    /// GiftCardActivity.
    /// </summary>
    public class GiftCardActivity
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="GiftCardActivity"/> class.
        /// </summary>
        /// <param name="type">type.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="id">id.</param>
        /// <param name="createdAt">created_at.</param>
        /// <param name="giftCardId">gift_card_id.</param>
        /// <param name="giftCardGan">gift_card_gan.</param>
        /// <param name="giftCardBalanceMoney">gift_card_balance_money.</param>
        /// <param name="loadActivityDetails">load_activity_details.</param>
        /// <param name="activateActivityDetails">activate_activity_details.</param>
        /// <param name="redeemActivityDetails">redeem_activity_details.</param>
        /// <param name="clearBalanceActivityDetails">clear_balance_activity_details.</param>
        /// <param name="deactivateActivityDetails">deactivate_activity_details.</param>
        /// <param name="adjustIncrementActivityDetails">adjust_increment_activity_details.</param>
        /// <param name="adjustDecrementActivityDetails">adjust_decrement_activity_details.</param>
        /// <param name="refundActivityDetails">refund_activity_details.</param>
        /// <param name="unlinkedActivityRefundActivityDetails">unlinked_activity_refund_activity_details.</param>
        /// <param name="importActivityDetails">import_activity_details.</param>
        /// <param name="blockActivityDetails">block_activity_details.</param>
        /// <param name="unblockActivityDetails">unblock_activity_details.</param>
        /// <param name="importReversalActivityDetails">import_reversal_activity_details.</param>
        /// <param name="transferBalanceToActivityDetails">transfer_balance_to_activity_details.</param>
        /// <param name="transferBalanceFromActivityDetails">transfer_balance_from_activity_details.</param>
        public GiftCardActivity(
            string type,
            string locationId,
            string id = null,
            string createdAt = null,
            string giftCardId = null,
            string giftCardGan = null,
            Models.Money giftCardBalanceMoney = null,
            Models.GiftCardActivityLoad loadActivityDetails = null,
            Models.GiftCardActivityActivate activateActivityDetails = null,
            Models.GiftCardActivityRedeem redeemActivityDetails = null,
            Models.GiftCardActivityClearBalance clearBalanceActivityDetails = null,
            Models.GiftCardActivityDeactivate deactivateActivityDetails = null,
            Models.GiftCardActivityAdjustIncrement adjustIncrementActivityDetails = null,
            Models.GiftCardActivityAdjustDecrement adjustDecrementActivityDetails = null,
            Models.GiftCardActivityRefund refundActivityDetails = null,
            Models.GiftCardActivityUnlinkedActivityRefund unlinkedActivityRefundActivityDetails = null,
            Models.GiftCardActivityImport importActivityDetails = null,
            Models.GiftCardActivityBlock blockActivityDetails = null,
            Models.GiftCardActivityUnblock unblockActivityDetails = null,
            Models.GiftCardActivityImportReversal importReversalActivityDetails = null,
            Models.GiftCardActivityTransferBalanceTo transferBalanceToActivityDetails = null,
            Models.GiftCardActivityTransferBalanceFrom transferBalanceFromActivityDetails = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "gift_card_id", false },
                { "gift_card_gan", false }
            };

            this.Id = id;
            this.Type = type;
            this.LocationId = locationId;
            this.CreatedAt = createdAt;
            if (giftCardId != null)
            {
                shouldSerialize["gift_card_id"] = true;
                this.GiftCardId = giftCardId;
            }

            if (giftCardGan != null)
            {
                shouldSerialize["gift_card_gan"] = true;
                this.GiftCardGan = giftCardGan;
            }

            this.GiftCardBalanceMoney = giftCardBalanceMoney;
            this.LoadActivityDetails = loadActivityDetails;
            this.ActivateActivityDetails = activateActivityDetails;
            this.RedeemActivityDetails = redeemActivityDetails;
            this.ClearBalanceActivityDetails = clearBalanceActivityDetails;
            this.DeactivateActivityDetails = deactivateActivityDetails;
            this.AdjustIncrementActivityDetails = adjustIncrementActivityDetails;
            this.AdjustDecrementActivityDetails = adjustDecrementActivityDetails;
            this.RefundActivityDetails = refundActivityDetails;
            this.UnlinkedActivityRefundActivityDetails = unlinkedActivityRefundActivityDetails;
            this.ImportActivityDetails = importActivityDetails;
            this.BlockActivityDetails = blockActivityDetails;
            this.UnblockActivityDetails = unblockActivityDetails;
            this.ImportReversalActivityDetails = importReversalActivityDetails;
            this.TransferBalanceToActivityDetails = transferBalanceToActivityDetails;
            this.TransferBalanceFromActivityDetails = transferBalanceFromActivityDetails;
        }
        internal GiftCardActivity(Dictionary<string, bool> shouldSerialize,
            string type,
            string locationId,
            string id = null,
            string createdAt = null,
            string giftCardId = null,
            string giftCardGan = null,
            Models.Money giftCardBalanceMoney = null,
            Models.GiftCardActivityLoad loadActivityDetails = null,
            Models.GiftCardActivityActivate activateActivityDetails = null,
            Models.GiftCardActivityRedeem redeemActivityDetails = null,
            Models.GiftCardActivityClearBalance clearBalanceActivityDetails = null,
            Models.GiftCardActivityDeactivate deactivateActivityDetails = null,
            Models.GiftCardActivityAdjustIncrement adjustIncrementActivityDetails = null,
            Models.GiftCardActivityAdjustDecrement adjustDecrementActivityDetails = null,
            Models.GiftCardActivityRefund refundActivityDetails = null,
            Models.GiftCardActivityUnlinkedActivityRefund unlinkedActivityRefundActivityDetails = null,
            Models.GiftCardActivityImport importActivityDetails = null,
            Models.GiftCardActivityBlock blockActivityDetails = null,
            Models.GiftCardActivityUnblock unblockActivityDetails = null,
            Models.GiftCardActivityImportReversal importReversalActivityDetails = null,
            Models.GiftCardActivityTransferBalanceTo transferBalanceToActivityDetails = null,
            Models.GiftCardActivityTransferBalanceFrom transferBalanceFromActivityDetails = null)
        {
            this.shouldSerialize = shouldSerialize;
            Id = id;
            Type = type;
            LocationId = locationId;
            CreatedAt = createdAt;
            GiftCardId = giftCardId;
            GiftCardGan = giftCardGan;
            GiftCardBalanceMoney = giftCardBalanceMoney;
            LoadActivityDetails = loadActivityDetails;
            ActivateActivityDetails = activateActivityDetails;
            RedeemActivityDetails = redeemActivityDetails;
            ClearBalanceActivityDetails = clearBalanceActivityDetails;
            DeactivateActivityDetails = deactivateActivityDetails;
            AdjustIncrementActivityDetails = adjustIncrementActivityDetails;
            AdjustDecrementActivityDetails = adjustDecrementActivityDetails;
            RefundActivityDetails = refundActivityDetails;
            UnlinkedActivityRefundActivityDetails = unlinkedActivityRefundActivityDetails;
            ImportActivityDetails = importActivityDetails;
            BlockActivityDetails = blockActivityDetails;
            UnblockActivityDetails = unblockActivityDetails;
            ImportReversalActivityDetails = importReversalActivityDetails;
            TransferBalanceToActivityDetails = transferBalanceToActivityDetails;
            TransferBalanceFromActivityDetails = transferBalanceFromActivityDetails;
        }

        /// <summary>
        /// The Square-assigned ID of the gift card activity.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// Indicates the type of [gift card activity]($m/GiftCardActivity).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// The ID of the [business location](entity:Location) where the activity occurred.
        /// </summary>
        [JsonProperty("location_id")]
        public string LocationId { get; }

        /// <summary>
        /// The timestamp when the gift card activity was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The gift card ID. When creating a gift card activity, `gift_card_id` is not required if
        /// `gift_card_gan` is specified.
        /// </summary>
        [JsonProperty("gift_card_id")]
        public string GiftCardId { get; }

        /// <summary>
        /// The gift card account number (GAN). When creating a gift card activity, `gift_card_gan`
        /// is not required if `gift_card_id` is specified.
        /// </summary>
        [JsonProperty("gift_card_gan")]
        public string GiftCardGan { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("gift_card_balance_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money GiftCardBalanceMoney { get; }

        /// <summary>
        /// Represents details about a `LOAD` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("load_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityLoad LoadActivityDetails { get; }

        /// <summary>
        /// Represents details about an `ACTIVATE` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("activate_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityActivate ActivateActivityDetails { get; }

        /// <summary>
        /// Represents details about a `REDEEM` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("redeem_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityRedeem RedeemActivityDetails { get; }

        /// <summary>
        /// Represents details about a `CLEAR_BALANCE` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("clear_balance_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityClearBalance ClearBalanceActivityDetails { get; }

        /// <summary>
        /// Represents details about a `DEACTIVATE` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("deactivate_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityDeactivate DeactivateActivityDetails { get; }

        /// <summary>
        /// Represents details about an `ADJUST_INCREMENT` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("adjust_increment_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityAdjustIncrement AdjustIncrementActivityDetails { get; }

        /// <summary>
        /// Represents details about an `ADJUST_DECREMENT` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("adjust_decrement_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityAdjustDecrement AdjustDecrementActivityDetails { get; }

        /// <summary>
        /// Represents details about a `REFUND` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("refund_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityRefund RefundActivityDetails { get; }

        /// <summary>
        /// Represents details about an `UNLINKED_ACTIVITY_REFUND` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("unlinked_activity_refund_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityUnlinkedActivityRefund UnlinkedActivityRefundActivityDetails { get; }

        /// <summary>
        /// Represents details about an `IMPORT` [gift card activity type]($m/GiftCardActivityType).
        /// This activity type is used when Square imports a third-party gift card, in which case the
        /// `gan_source` of the gift card is set to `OTHER`.
        /// </summary>
        [JsonProperty("import_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityImport ImportActivityDetails { get; }

        /// <summary>
        /// Represents details about a `BLOCK` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("block_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityBlock BlockActivityDetails { get; }

        /// <summary>
        /// Represents details about an `UNBLOCK` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("unblock_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityUnblock UnblockActivityDetails { get; }

        /// <summary>
        /// Represents details about an `IMPORT_REVERSAL` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("import_reversal_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityImportReversal ImportReversalActivityDetails { get; }

        /// <summary>
        /// Represents details about a `TRANSFER_BALANCE_TO` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("transfer_balance_to_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityTransferBalanceTo TransferBalanceToActivityDetails { get; }

        /// <summary>
        /// Represents details about a `TRANSFER_BALANCE_FROM` [gift card activity type]($m/GiftCardActivityType).
        /// </summary>
        [JsonProperty("transfer_balance_from_activity_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.GiftCardActivityTransferBalanceFrom TransferBalanceFromActivityDetails { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"GiftCardActivity : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeGiftCardId()
        {
            return this.shouldSerialize["gift_card_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeGiftCardGan()
        {
            return this.shouldSerialize["gift_card_gan"];
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
            return obj is GiftCardActivity other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.CreatedAt == null && other.CreatedAt == null) || (this.CreatedAt?.Equals(other.CreatedAt) == true)) &&
                ((this.GiftCardId == null && other.GiftCardId == null) || (this.GiftCardId?.Equals(other.GiftCardId) == true)) &&
                ((this.GiftCardGan == null && other.GiftCardGan == null) || (this.GiftCardGan?.Equals(other.GiftCardGan) == true)) &&
                ((this.GiftCardBalanceMoney == null && other.GiftCardBalanceMoney == null) || (this.GiftCardBalanceMoney?.Equals(other.GiftCardBalanceMoney) == true)) &&
                ((this.LoadActivityDetails == null && other.LoadActivityDetails == null) || (this.LoadActivityDetails?.Equals(other.LoadActivityDetails) == true)) &&
                ((this.ActivateActivityDetails == null && other.ActivateActivityDetails == null) || (this.ActivateActivityDetails?.Equals(other.ActivateActivityDetails) == true)) &&
                ((this.RedeemActivityDetails == null && other.RedeemActivityDetails == null) || (this.RedeemActivityDetails?.Equals(other.RedeemActivityDetails) == true)) &&
                ((this.ClearBalanceActivityDetails == null && other.ClearBalanceActivityDetails == null) || (this.ClearBalanceActivityDetails?.Equals(other.ClearBalanceActivityDetails) == true)) &&
                ((this.DeactivateActivityDetails == null && other.DeactivateActivityDetails == null) || (this.DeactivateActivityDetails?.Equals(other.DeactivateActivityDetails) == true)) &&
                ((this.AdjustIncrementActivityDetails == null && other.AdjustIncrementActivityDetails == null) || (this.AdjustIncrementActivityDetails?.Equals(other.AdjustIncrementActivityDetails) == true)) &&
                ((this.AdjustDecrementActivityDetails == null && other.AdjustDecrementActivityDetails == null) || (this.AdjustDecrementActivityDetails?.Equals(other.AdjustDecrementActivityDetails) == true)) &&
                ((this.RefundActivityDetails == null && other.RefundActivityDetails == null) || (this.RefundActivityDetails?.Equals(other.RefundActivityDetails) == true)) &&
                ((this.UnlinkedActivityRefundActivityDetails == null && other.UnlinkedActivityRefundActivityDetails == null) || (this.UnlinkedActivityRefundActivityDetails?.Equals(other.UnlinkedActivityRefundActivityDetails) == true)) &&
                ((this.ImportActivityDetails == null && other.ImportActivityDetails == null) || (this.ImportActivityDetails?.Equals(other.ImportActivityDetails) == true)) &&
                ((this.BlockActivityDetails == null && other.BlockActivityDetails == null) || (this.BlockActivityDetails?.Equals(other.BlockActivityDetails) == true)) &&
                ((this.UnblockActivityDetails == null && other.UnblockActivityDetails == null) || (this.UnblockActivityDetails?.Equals(other.UnblockActivityDetails) == true)) &&
                ((this.ImportReversalActivityDetails == null && other.ImportReversalActivityDetails == null) || (this.ImportReversalActivityDetails?.Equals(other.ImportReversalActivityDetails) == true)) &&
                ((this.TransferBalanceToActivityDetails == null && other.TransferBalanceToActivityDetails == null) || (this.TransferBalanceToActivityDetails?.Equals(other.TransferBalanceToActivityDetails) == true)) &&
                ((this.TransferBalanceFromActivityDetails == null && other.TransferBalanceFromActivityDetails == null) || (this.TransferBalanceFromActivityDetails?.Equals(other.TransferBalanceFromActivityDetails) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1715056739;
            hashCode = HashCode.Combine(this.Id, this.Type, this.LocationId, this.CreatedAt, this.GiftCardId, this.GiftCardGan, this.GiftCardBalanceMoney);

            hashCode = HashCode.Combine(hashCode, this.LoadActivityDetails, this.ActivateActivityDetails, this.RedeemActivityDetails, this.ClearBalanceActivityDetails, this.DeactivateActivityDetails, this.AdjustIncrementActivityDetails, this.AdjustDecrementActivityDetails);

            hashCode = HashCode.Combine(hashCode, this.RefundActivityDetails, this.UnlinkedActivityRefundActivityDetails, this.ImportActivityDetails, this.BlockActivityDetails, this.UnblockActivityDetails, this.ImportReversalActivityDetails, this.TransferBalanceToActivityDetails);

            hashCode = HashCode.Combine(hashCode, this.TransferBalanceFromActivityDetails);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type.ToString())}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.CreatedAt = {(this.CreatedAt == null ? "null" : this.CreatedAt == string.Empty ? "" : this.CreatedAt)}");
            toStringOutput.Add($"this.GiftCardId = {(this.GiftCardId == null ? "null" : this.GiftCardId == string.Empty ? "" : this.GiftCardId)}");
            toStringOutput.Add($"this.GiftCardGan = {(this.GiftCardGan == null ? "null" : this.GiftCardGan == string.Empty ? "" : this.GiftCardGan)}");
            toStringOutput.Add($"this.GiftCardBalanceMoney = {(this.GiftCardBalanceMoney == null ? "null" : this.GiftCardBalanceMoney.ToString())}");
            toStringOutput.Add($"this.LoadActivityDetails = {(this.LoadActivityDetails == null ? "null" : this.LoadActivityDetails.ToString())}");
            toStringOutput.Add($"this.ActivateActivityDetails = {(this.ActivateActivityDetails == null ? "null" : this.ActivateActivityDetails.ToString())}");
            toStringOutput.Add($"this.RedeemActivityDetails = {(this.RedeemActivityDetails == null ? "null" : this.RedeemActivityDetails.ToString())}");
            toStringOutput.Add($"this.ClearBalanceActivityDetails = {(this.ClearBalanceActivityDetails == null ? "null" : this.ClearBalanceActivityDetails.ToString())}");
            toStringOutput.Add($"this.DeactivateActivityDetails = {(this.DeactivateActivityDetails == null ? "null" : this.DeactivateActivityDetails.ToString())}");
            toStringOutput.Add($"this.AdjustIncrementActivityDetails = {(this.AdjustIncrementActivityDetails == null ? "null" : this.AdjustIncrementActivityDetails.ToString())}");
            toStringOutput.Add($"this.AdjustDecrementActivityDetails = {(this.AdjustDecrementActivityDetails == null ? "null" : this.AdjustDecrementActivityDetails.ToString())}");
            toStringOutput.Add($"this.RefundActivityDetails = {(this.RefundActivityDetails == null ? "null" : this.RefundActivityDetails.ToString())}");
            toStringOutput.Add($"this.UnlinkedActivityRefundActivityDetails = {(this.UnlinkedActivityRefundActivityDetails == null ? "null" : this.UnlinkedActivityRefundActivityDetails.ToString())}");
            toStringOutput.Add($"this.ImportActivityDetails = {(this.ImportActivityDetails == null ? "null" : this.ImportActivityDetails.ToString())}");
            toStringOutput.Add($"this.BlockActivityDetails = {(this.BlockActivityDetails == null ? "null" : this.BlockActivityDetails.ToString())}");
            toStringOutput.Add($"this.UnblockActivityDetails = {(this.UnblockActivityDetails == null ? "null" : this.UnblockActivityDetails.ToString())}");
            toStringOutput.Add($"this.ImportReversalActivityDetails = {(this.ImportReversalActivityDetails == null ? "null" : this.ImportReversalActivityDetails.ToString())}");
            toStringOutput.Add($"this.TransferBalanceToActivityDetails = {(this.TransferBalanceToActivityDetails == null ? "null" : this.TransferBalanceToActivityDetails.ToString())}");
            toStringOutput.Add($"this.TransferBalanceFromActivityDetails = {(this.TransferBalanceFromActivityDetails == null ? "null" : this.TransferBalanceFromActivityDetails.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Type,
                this.LocationId)
                .Id(this.Id)
                .CreatedAt(this.CreatedAt)
                .GiftCardId(this.GiftCardId)
                .GiftCardGan(this.GiftCardGan)
                .GiftCardBalanceMoney(this.GiftCardBalanceMoney)
                .LoadActivityDetails(this.LoadActivityDetails)
                .ActivateActivityDetails(this.ActivateActivityDetails)
                .RedeemActivityDetails(this.RedeemActivityDetails)
                .ClearBalanceActivityDetails(this.ClearBalanceActivityDetails)
                .DeactivateActivityDetails(this.DeactivateActivityDetails)
                .AdjustIncrementActivityDetails(this.AdjustIncrementActivityDetails)
                .AdjustDecrementActivityDetails(this.AdjustDecrementActivityDetails)
                .RefundActivityDetails(this.RefundActivityDetails)
                .UnlinkedActivityRefundActivityDetails(this.UnlinkedActivityRefundActivityDetails)
                .ImportActivityDetails(this.ImportActivityDetails)
                .BlockActivityDetails(this.BlockActivityDetails)
                .UnblockActivityDetails(this.UnblockActivityDetails)
                .ImportReversalActivityDetails(this.ImportReversalActivityDetails)
                .TransferBalanceToActivityDetails(this.TransferBalanceToActivityDetails)
                .TransferBalanceFromActivityDetails(this.TransferBalanceFromActivityDetails);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "gift_card_id", false },
                { "gift_card_gan", false },
            };

            private string type;
            private string locationId;
            private string id;
            private string createdAt;
            private string giftCardId;
            private string giftCardGan;
            private Models.Money giftCardBalanceMoney;
            private Models.GiftCardActivityLoad loadActivityDetails;
            private Models.GiftCardActivityActivate activateActivityDetails;
            private Models.GiftCardActivityRedeem redeemActivityDetails;
            private Models.GiftCardActivityClearBalance clearBalanceActivityDetails;
            private Models.GiftCardActivityDeactivate deactivateActivityDetails;
            private Models.GiftCardActivityAdjustIncrement adjustIncrementActivityDetails;
            private Models.GiftCardActivityAdjustDecrement adjustDecrementActivityDetails;
            private Models.GiftCardActivityRefund refundActivityDetails;
            private Models.GiftCardActivityUnlinkedActivityRefund unlinkedActivityRefundActivityDetails;
            private Models.GiftCardActivityImport importActivityDetails;
            private Models.GiftCardActivityBlock blockActivityDetails;
            private Models.GiftCardActivityUnblock unblockActivityDetails;
            private Models.GiftCardActivityImportReversal importReversalActivityDetails;
            private Models.GiftCardActivityTransferBalanceTo transferBalanceToActivityDetails;
            private Models.GiftCardActivityTransferBalanceFrom transferBalanceFromActivityDetails;

            public Builder(
                string type,
                string locationId)
            {
                this.type = type;
                this.locationId = locationId;
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
             /// LocationId.
             /// </summary>
             /// <param name="locationId"> locationId. </param>
             /// <returns> Builder. </returns>
            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
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
             /// GiftCardId.
             /// </summary>
             /// <param name="giftCardId"> giftCardId. </param>
             /// <returns> Builder. </returns>
            public Builder GiftCardId(string giftCardId)
            {
                shouldSerialize["gift_card_id"] = true;
                this.giftCardId = giftCardId;
                return this;
            }

             /// <summary>
             /// GiftCardGan.
             /// </summary>
             /// <param name="giftCardGan"> giftCardGan. </param>
             /// <returns> Builder. </returns>
            public Builder GiftCardGan(string giftCardGan)
            {
                shouldSerialize["gift_card_gan"] = true;
                this.giftCardGan = giftCardGan;
                return this;
            }

             /// <summary>
             /// GiftCardBalanceMoney.
             /// </summary>
             /// <param name="giftCardBalanceMoney"> giftCardBalanceMoney. </param>
             /// <returns> Builder. </returns>
            public Builder GiftCardBalanceMoney(Models.Money giftCardBalanceMoney)
            {
                this.giftCardBalanceMoney = giftCardBalanceMoney;
                return this;
            }

             /// <summary>
             /// LoadActivityDetails.
             /// </summary>
             /// <param name="loadActivityDetails"> loadActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder LoadActivityDetails(Models.GiftCardActivityLoad loadActivityDetails)
            {
                this.loadActivityDetails = loadActivityDetails;
                return this;
            }

             /// <summary>
             /// ActivateActivityDetails.
             /// </summary>
             /// <param name="activateActivityDetails"> activateActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder ActivateActivityDetails(Models.GiftCardActivityActivate activateActivityDetails)
            {
                this.activateActivityDetails = activateActivityDetails;
                return this;
            }

             /// <summary>
             /// RedeemActivityDetails.
             /// </summary>
             /// <param name="redeemActivityDetails"> redeemActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder RedeemActivityDetails(Models.GiftCardActivityRedeem redeemActivityDetails)
            {
                this.redeemActivityDetails = redeemActivityDetails;
                return this;
            }

             /// <summary>
             /// ClearBalanceActivityDetails.
             /// </summary>
             /// <param name="clearBalanceActivityDetails"> clearBalanceActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder ClearBalanceActivityDetails(Models.GiftCardActivityClearBalance clearBalanceActivityDetails)
            {
                this.clearBalanceActivityDetails = clearBalanceActivityDetails;
                return this;
            }

             /// <summary>
             /// DeactivateActivityDetails.
             /// </summary>
             /// <param name="deactivateActivityDetails"> deactivateActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder DeactivateActivityDetails(Models.GiftCardActivityDeactivate deactivateActivityDetails)
            {
                this.deactivateActivityDetails = deactivateActivityDetails;
                return this;
            }

             /// <summary>
             /// AdjustIncrementActivityDetails.
             /// </summary>
             /// <param name="adjustIncrementActivityDetails"> adjustIncrementActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder AdjustIncrementActivityDetails(Models.GiftCardActivityAdjustIncrement adjustIncrementActivityDetails)
            {
                this.adjustIncrementActivityDetails = adjustIncrementActivityDetails;
                return this;
            }

             /// <summary>
             /// AdjustDecrementActivityDetails.
             /// </summary>
             /// <param name="adjustDecrementActivityDetails"> adjustDecrementActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder AdjustDecrementActivityDetails(Models.GiftCardActivityAdjustDecrement adjustDecrementActivityDetails)
            {
                this.adjustDecrementActivityDetails = adjustDecrementActivityDetails;
                return this;
            }

             /// <summary>
             /// RefundActivityDetails.
             /// </summary>
             /// <param name="refundActivityDetails"> refundActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder RefundActivityDetails(Models.GiftCardActivityRefund refundActivityDetails)
            {
                this.refundActivityDetails = refundActivityDetails;
                return this;
            }

             /// <summary>
             /// UnlinkedActivityRefundActivityDetails.
             /// </summary>
             /// <param name="unlinkedActivityRefundActivityDetails"> unlinkedActivityRefundActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder UnlinkedActivityRefundActivityDetails(Models.GiftCardActivityUnlinkedActivityRefund unlinkedActivityRefundActivityDetails)
            {
                this.unlinkedActivityRefundActivityDetails = unlinkedActivityRefundActivityDetails;
                return this;
            }

             /// <summary>
             /// ImportActivityDetails.
             /// </summary>
             /// <param name="importActivityDetails"> importActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder ImportActivityDetails(Models.GiftCardActivityImport importActivityDetails)
            {
                this.importActivityDetails = importActivityDetails;
                return this;
            }

             /// <summary>
             /// BlockActivityDetails.
             /// </summary>
             /// <param name="blockActivityDetails"> blockActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder BlockActivityDetails(Models.GiftCardActivityBlock blockActivityDetails)
            {
                this.blockActivityDetails = blockActivityDetails;
                return this;
            }

             /// <summary>
             /// UnblockActivityDetails.
             /// </summary>
             /// <param name="unblockActivityDetails"> unblockActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder UnblockActivityDetails(Models.GiftCardActivityUnblock unblockActivityDetails)
            {
                this.unblockActivityDetails = unblockActivityDetails;
                return this;
            }

             /// <summary>
             /// ImportReversalActivityDetails.
             /// </summary>
             /// <param name="importReversalActivityDetails"> importReversalActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder ImportReversalActivityDetails(Models.GiftCardActivityImportReversal importReversalActivityDetails)
            {
                this.importReversalActivityDetails = importReversalActivityDetails;
                return this;
            }

             /// <summary>
             /// TransferBalanceToActivityDetails.
             /// </summary>
             /// <param name="transferBalanceToActivityDetails"> transferBalanceToActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TransferBalanceToActivityDetails(Models.GiftCardActivityTransferBalanceTo transferBalanceToActivityDetails)
            {
                this.transferBalanceToActivityDetails = transferBalanceToActivityDetails;
                return this;
            }

             /// <summary>
             /// TransferBalanceFromActivityDetails.
             /// </summary>
             /// <param name="transferBalanceFromActivityDetails"> transferBalanceFromActivityDetails. </param>
             /// <returns> Builder. </returns>
            public Builder TransferBalanceFromActivityDetails(Models.GiftCardActivityTransferBalanceFrom transferBalanceFromActivityDetails)
            {
                this.transferBalanceFromActivityDetails = transferBalanceFromActivityDetails;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetGiftCardId()
            {
                this.shouldSerialize["gift_card_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetGiftCardGan()
            {
                this.shouldSerialize["gift_card_gan"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> GiftCardActivity. </returns>
            public GiftCardActivity Build()
            {
                return new GiftCardActivity(shouldSerialize,
                    this.type,
                    this.locationId,
                    this.id,
                    this.createdAt,
                    this.giftCardId,
                    this.giftCardGan,
                    this.giftCardBalanceMoney,
                    this.loadActivityDetails,
                    this.activateActivityDetails,
                    this.redeemActivityDetails,
                    this.clearBalanceActivityDetails,
                    this.deactivateActivityDetails,
                    this.adjustIncrementActivityDetails,
                    this.adjustDecrementActivityDetails,
                    this.refundActivityDetails,
                    this.unlinkedActivityRefundActivityDetails,
                    this.importActivityDetails,
                    this.blockActivityDetails,
                    this.unblockActivityDetails,
                    this.importReversalActivityDetails,
                    this.transferBalanceToActivityDetails,
                    this.transferBalanceFromActivityDetails);
            }
        }
    }
}