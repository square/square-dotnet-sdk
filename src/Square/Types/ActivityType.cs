using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ActivityType>))]
[Serializable]
public readonly record struct ActivityType : IStringEnum
{
    public static readonly ActivityType Adjustment = new(Values.Adjustment);

    public static readonly ActivityType AppFeeRefund = new(Values.AppFeeRefund);

    public static readonly ActivityType AppFeeRevenue = new(Values.AppFeeRevenue);

    public static readonly ActivityType AutomaticSavings = new(Values.AutomaticSavings);

    public static readonly ActivityType AutomaticSavingsReversed = new(
        Values.AutomaticSavingsReversed
    );

    public static readonly ActivityType Charge = new(Values.Charge);

    public static readonly ActivityType DepositFee = new(Values.DepositFee);

    public static readonly ActivityType DepositFeeReversed = new(Values.DepositFeeReversed);

    public static readonly ActivityType Dispute = new(Values.Dispute);

    public static readonly ActivityType Escheatment = new(Values.Escheatment);

    public static readonly ActivityType Fee = new(Values.Fee);

    public static readonly ActivityType FreeProcessing = new(Values.FreeProcessing);

    public static readonly ActivityType HoldAdjustment = new(Values.HoldAdjustment);

    public static readonly ActivityType InitialBalanceChange = new(Values.InitialBalanceChange);

    public static readonly ActivityType MoneyTransfer = new(Values.MoneyTransfer);

    public static readonly ActivityType MoneyTransferReversal = new(Values.MoneyTransferReversal);

    public static readonly ActivityType OpenDispute = new(Values.OpenDispute);

    public static readonly ActivityType Other = new(Values.Other);

    public static readonly ActivityType OtherAdjustment = new(Values.OtherAdjustment);

    public static readonly ActivityType PaidServiceFee = new(Values.PaidServiceFee);

    public static readonly ActivityType PaidServiceFeeRefund = new(Values.PaidServiceFeeRefund);

    public static readonly ActivityType RedemptionCode = new(Values.RedemptionCode);

    public static readonly ActivityType Refund = new(Values.Refund);

    public static readonly ActivityType ReleaseAdjustment = new(Values.ReleaseAdjustment);

    public static readonly ActivityType ReserveHold = new(Values.ReserveHold);

    public static readonly ActivityType ReserveRelease = new(Values.ReserveRelease);

    public static readonly ActivityType ReturnedPayout = new(Values.ReturnedPayout);

    public static readonly ActivityType SquareCapitalPayment = new(Values.SquareCapitalPayment);

    public static readonly ActivityType SquareCapitalReversedPayment = new(
        Values.SquareCapitalReversedPayment
    );

    public static readonly ActivityType SubscriptionFee = new(Values.SubscriptionFee);

    public static readonly ActivityType SubscriptionFeePaidRefund = new(
        Values.SubscriptionFeePaidRefund
    );

    public static readonly ActivityType SubscriptionFeeRefund = new(Values.SubscriptionFeeRefund);

    public static readonly ActivityType TaxOnFee = new(Values.TaxOnFee);

    public static readonly ActivityType ThirdPartyFee = new(Values.ThirdPartyFee);

    public static readonly ActivityType ThirdPartyFeeRefund = new(Values.ThirdPartyFeeRefund);

    public static readonly ActivityType Payout = new(Values.Payout);

    public static readonly ActivityType AutomaticBitcoinConversions = new(
        Values.AutomaticBitcoinConversions
    );

    public static readonly ActivityType AutomaticBitcoinConversionsReversed = new(
        Values.AutomaticBitcoinConversionsReversed
    );

    public static readonly ActivityType CreditCardRepayment = new(Values.CreditCardRepayment);

    public static readonly ActivityType CreditCardRepaymentReversed = new(
        Values.CreditCardRepaymentReversed
    );

    public static readonly ActivityType LocalOffersCashback = new(Values.LocalOffersCashback);

    public static readonly ActivityType LocalOffersFee = new(Values.LocalOffersFee);

    public static readonly ActivityType PercentageProcessingEnrollment = new(
        Values.PercentageProcessingEnrollment
    );

    public static readonly ActivityType PercentageProcessingDeactivation = new(
        Values.PercentageProcessingDeactivation
    );

    public static readonly ActivityType PercentageProcessingRepayment = new(
        Values.PercentageProcessingRepayment
    );

    public static readonly ActivityType PercentageProcessingRepaymentReversed = new(
        Values.PercentageProcessingRepaymentReversed
    );

    public static readonly ActivityType ProcessingFee = new(Values.ProcessingFee);

    public static readonly ActivityType ProcessingFeeRefund = new(Values.ProcessingFeeRefund);

    public static readonly ActivityType UndoProcessingFeeRefund = new(
        Values.UndoProcessingFeeRefund
    );

    public static readonly ActivityType GiftCardLoadFee = new(Values.GiftCardLoadFee);

    public static readonly ActivityType GiftCardLoadFeeRefund = new(Values.GiftCardLoadFeeRefund);

    public static readonly ActivityType UndoGiftCardLoadFeeRefund = new(
        Values.UndoGiftCardLoadFeeRefund
    );

    public static readonly ActivityType BalanceFoldersTransfer = new(Values.BalanceFoldersTransfer);

    public static readonly ActivityType BalanceFoldersTransferReversed = new(
        Values.BalanceFoldersTransferReversed
    );

    public static readonly ActivityType GiftCardPoolTransfer = new(Values.GiftCardPoolTransfer);

    public static readonly ActivityType GiftCardPoolTransferReversed = new(
        Values.GiftCardPoolTransferReversed
    );

    public static readonly ActivityType SquarePayrollTransfer = new(Values.SquarePayrollTransfer);

    public static readonly ActivityType SquarePayrollTransferReversed = new(
        Values.SquarePayrollTransferReversed
    );

    public ActivityType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static ActivityType FromCustom(string value)
    {
        return new ActivityType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(ActivityType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActivityType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActivityType value) => value.Value;

    public static explicit operator ActivityType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Adjustment = "ADJUSTMENT";

        public const string AppFeeRefund = "APP_FEE_REFUND";

        public const string AppFeeRevenue = "APP_FEE_REVENUE";

        public const string AutomaticSavings = "AUTOMATIC_SAVINGS";

        public const string AutomaticSavingsReversed = "AUTOMATIC_SAVINGS_REVERSED";

        public const string Charge = "CHARGE";

        public const string DepositFee = "DEPOSIT_FEE";

        public const string DepositFeeReversed = "DEPOSIT_FEE_REVERSED";

        public const string Dispute = "DISPUTE";

        public const string Escheatment = "ESCHEATMENT";

        public const string Fee = "FEE";

        public const string FreeProcessing = "FREE_PROCESSING";

        public const string HoldAdjustment = "HOLD_ADJUSTMENT";

        public const string InitialBalanceChange = "INITIAL_BALANCE_CHANGE";

        public const string MoneyTransfer = "MONEY_TRANSFER";

        public const string MoneyTransferReversal = "MONEY_TRANSFER_REVERSAL";

        public const string OpenDispute = "OPEN_DISPUTE";

        public const string Other = "OTHER";

        public const string OtherAdjustment = "OTHER_ADJUSTMENT";

        public const string PaidServiceFee = "PAID_SERVICE_FEE";

        public const string PaidServiceFeeRefund = "PAID_SERVICE_FEE_REFUND";

        public const string RedemptionCode = "REDEMPTION_CODE";

        public const string Refund = "REFUND";

        public const string ReleaseAdjustment = "RELEASE_ADJUSTMENT";

        public const string ReserveHold = "RESERVE_HOLD";

        public const string ReserveRelease = "RESERVE_RELEASE";

        public const string ReturnedPayout = "RETURNED_PAYOUT";

        public const string SquareCapitalPayment = "SQUARE_CAPITAL_PAYMENT";

        public const string SquareCapitalReversedPayment = "SQUARE_CAPITAL_REVERSED_PAYMENT";

        public const string SubscriptionFee = "SUBSCRIPTION_FEE";

        public const string SubscriptionFeePaidRefund = "SUBSCRIPTION_FEE_PAID_REFUND";

        public const string SubscriptionFeeRefund = "SUBSCRIPTION_FEE_REFUND";

        public const string TaxOnFee = "TAX_ON_FEE";

        public const string ThirdPartyFee = "THIRD_PARTY_FEE";

        public const string ThirdPartyFeeRefund = "THIRD_PARTY_FEE_REFUND";

        public const string Payout = "PAYOUT";

        public const string AutomaticBitcoinConversions = "AUTOMATIC_BITCOIN_CONVERSIONS";

        public const string AutomaticBitcoinConversionsReversed =
            "AUTOMATIC_BITCOIN_CONVERSIONS_REVERSED";

        public const string CreditCardRepayment = "CREDIT_CARD_REPAYMENT";

        public const string CreditCardRepaymentReversed = "CREDIT_CARD_REPAYMENT_REVERSED";

        public const string LocalOffersCashback = "LOCAL_OFFERS_CASHBACK";

        public const string LocalOffersFee = "LOCAL_OFFERS_FEE";

        public const string PercentageProcessingEnrollment = "PERCENTAGE_PROCESSING_ENROLLMENT";

        public const string PercentageProcessingDeactivation = "PERCENTAGE_PROCESSING_DEACTIVATION";

        public const string PercentageProcessingRepayment = "PERCENTAGE_PROCESSING_REPAYMENT";

        public const string PercentageProcessingRepaymentReversed =
            "PERCENTAGE_PROCESSING_REPAYMENT_REVERSED";

        public const string ProcessingFee = "PROCESSING_FEE";

        public const string ProcessingFeeRefund = "PROCESSING_FEE_REFUND";

        public const string UndoProcessingFeeRefund = "UNDO_PROCESSING_FEE_REFUND";

        public const string GiftCardLoadFee = "GIFT_CARD_LOAD_FEE";

        public const string GiftCardLoadFeeRefund = "GIFT_CARD_LOAD_FEE_REFUND";

        public const string UndoGiftCardLoadFeeRefund = "UNDO_GIFT_CARD_LOAD_FEE_REFUND";

        public const string BalanceFoldersTransfer = "BALANCE_FOLDERS_TRANSFER";

        public const string BalanceFoldersTransferReversed = "BALANCE_FOLDERS_TRANSFER_REVERSED";

        public const string GiftCardPoolTransfer = "GIFT_CARD_POOL_TRANSFER";

        public const string GiftCardPoolTransferReversed = "GIFT_CARD_POOL_TRANSFER_REVERSED";

        public const string SquarePayrollTransfer = "SQUARE_PAYROLL_TRANSFER";

        public const string SquarePayrollTransferReversed = "SQUARE_PAYROLL_TRANSFER_REVERSED";
    }
}
