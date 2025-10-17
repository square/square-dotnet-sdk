using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<DisputeEvidenceType>))]
[Serializable]
public readonly record struct DisputeEvidenceType : IStringEnum
{
    public static readonly DisputeEvidenceType GenericEvidence = new(Values.GenericEvidence);

    public static readonly DisputeEvidenceType OnlineOrAppAccessLog = new(
        Values.OnlineOrAppAccessLog
    );

    public static readonly DisputeEvidenceType AuthorizationDocumentation = new(
        Values.AuthorizationDocumentation
    );

    public static readonly DisputeEvidenceType CancellationOrRefundDocumentation = new(
        Values.CancellationOrRefundDocumentation
    );

    public static readonly DisputeEvidenceType CardholderCommunication = new(
        Values.CardholderCommunication
    );

    public static readonly DisputeEvidenceType CardholderInformation = new(
        Values.CardholderInformation
    );

    public static readonly DisputeEvidenceType PurchaseAcknowledgement = new(
        Values.PurchaseAcknowledgement
    );

    public static readonly DisputeEvidenceType DuplicateChargeDocumentation = new(
        Values.DuplicateChargeDocumentation
    );

    public static readonly DisputeEvidenceType ProductOrServiceDescription = new(
        Values.ProductOrServiceDescription
    );

    public static readonly DisputeEvidenceType Receipt = new(Values.Receipt);

    public static readonly DisputeEvidenceType ServiceReceivedDocumentation = new(
        Values.ServiceReceivedDocumentation
    );

    public static readonly DisputeEvidenceType ProofOfDeliveryDocumentation = new(
        Values.ProofOfDeliveryDocumentation
    );

    public static readonly DisputeEvidenceType RelatedTransactionDocumentation = new(
        Values.RelatedTransactionDocumentation
    );

    public static readonly DisputeEvidenceType RebuttalExplanation = new(
        Values.RebuttalExplanation
    );

    public static readonly DisputeEvidenceType TrackingNumber = new(Values.TrackingNumber);

    public DisputeEvidenceType(string value)
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
    public static DisputeEvidenceType FromCustom(string value)
    {
        return new DisputeEvidenceType(value);
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

    public static bool operator ==(DisputeEvidenceType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DisputeEvidenceType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DisputeEvidenceType value) => value.Value;

    public static explicit operator DisputeEvidenceType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string GenericEvidence = "GENERIC_EVIDENCE";

        public const string OnlineOrAppAccessLog = "ONLINE_OR_APP_ACCESS_LOG";

        public const string AuthorizationDocumentation = "AUTHORIZATION_DOCUMENTATION";

        public const string CancellationOrRefundDocumentation =
            "CANCELLATION_OR_REFUND_DOCUMENTATION";

        public const string CardholderCommunication = "CARDHOLDER_COMMUNICATION";

        public const string CardholderInformation = "CARDHOLDER_INFORMATION";

        public const string PurchaseAcknowledgement = "PURCHASE_ACKNOWLEDGEMENT";

        public const string DuplicateChargeDocumentation = "DUPLICATE_CHARGE_DOCUMENTATION";

        public const string ProductOrServiceDescription = "PRODUCT_OR_SERVICE_DESCRIPTION";

        public const string Receipt = "RECEIPT";

        public const string ServiceReceivedDocumentation = "SERVICE_RECEIVED_DOCUMENTATION";

        public const string ProofOfDeliveryDocumentation = "PROOF_OF_DELIVERY_DOCUMENTATION";

        public const string RelatedTransactionDocumentation = "RELATED_TRANSACTION_DOCUMENTATION";

        public const string RebuttalExplanation = "REBUTTAL_EXPLANATION";

        public const string TrackingNumber = "TRACKING_NUMBER";
    }
}
