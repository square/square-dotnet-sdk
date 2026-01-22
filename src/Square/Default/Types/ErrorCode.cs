using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<ErrorCode>))]
[Serializable]
public readonly record struct ErrorCode : IStringEnum
{
    public static readonly ErrorCode InternalServerError = new(Values.InternalServerError);

    public static readonly ErrorCode Unauthorized = new(Values.Unauthorized);

    public static readonly ErrorCode AccessTokenExpired = new(Values.AccessTokenExpired);

    public static readonly ErrorCode AccessTokenRevoked = new(Values.AccessTokenRevoked);

    public static readonly ErrorCode ClientDisabled = new(Values.ClientDisabled);

    public static readonly ErrorCode Forbidden = new(Values.Forbidden);

    public static readonly ErrorCode InsufficientScopes = new(Values.InsufficientScopes);

    public static readonly ErrorCode ApplicationDisabled = new(Values.ApplicationDisabled);

    public static readonly ErrorCode V1Application = new(Values.V1Application);

    public static readonly ErrorCode V1AccessToken = new(Values.V1AccessToken);

    public static readonly ErrorCode CardProcessingNotEnabled = new(
        Values.CardProcessingNotEnabled
    );

    public static readonly ErrorCode MerchantSubscriptionNotFound = new(
        Values.MerchantSubscriptionNotFound
    );

    public static readonly ErrorCode BadRequest = new(Values.BadRequest);

    public static readonly ErrorCode MissingRequiredParameter = new(
        Values.MissingRequiredParameter
    );

    public static readonly ErrorCode IncorrectType = new(Values.IncorrectType);

    public static readonly ErrorCode InvalidTime = new(Values.InvalidTime);

    public static readonly ErrorCode InvalidTimeRange = new(Values.InvalidTimeRange);

    public static readonly ErrorCode InvalidValue = new(Values.InvalidValue);

    public static readonly ErrorCode InvalidCursor = new(Values.InvalidCursor);

    public static readonly ErrorCode UnknownQueryParameter = new(Values.UnknownQueryParameter);

    public static readonly ErrorCode ConflictingParameters = new(Values.ConflictingParameters);

    public static readonly ErrorCode ExpectedJsonBody = new(Values.ExpectedJsonBody);

    public static readonly ErrorCode InvalidSortOrder = new(Values.InvalidSortOrder);

    public static readonly ErrorCode ValueRegexMismatch = new(Values.ValueRegexMismatch);

    public static readonly ErrorCode ValueTooShort = new(Values.ValueTooShort);

    public static readonly ErrorCode ValueTooLong = new(Values.ValueTooLong);

    public static readonly ErrorCode ValueTooLow = new(Values.ValueTooLow);

    public static readonly ErrorCode ValueTooHigh = new(Values.ValueTooHigh);

    public static readonly ErrorCode ValueEmpty = new(Values.ValueEmpty);

    public static readonly ErrorCode ArrayLengthTooLong = new(Values.ArrayLengthTooLong);

    public static readonly ErrorCode ArrayLengthTooShort = new(Values.ArrayLengthTooShort);

    public static readonly ErrorCode ArrayEmpty = new(Values.ArrayEmpty);

    public static readonly ErrorCode ExpectedBoolean = new(Values.ExpectedBoolean);

    public static readonly ErrorCode ExpectedInteger = new(Values.ExpectedInteger);

    public static readonly ErrorCode ExpectedFloat = new(Values.ExpectedFloat);

    public static readonly ErrorCode ExpectedString = new(Values.ExpectedString);

    public static readonly ErrorCode ExpectedObject = new(Values.ExpectedObject);

    public static readonly ErrorCode ExpectedArray = new(Values.ExpectedArray);

    public static readonly ErrorCode ExpectedMap = new(Values.ExpectedMap);

    public static readonly ErrorCode ExpectedBase64EncodedByteArray = new(
        Values.ExpectedBase64EncodedByteArray
    );

    public static readonly ErrorCode InvalidArrayValue = new(Values.InvalidArrayValue);

    public static readonly ErrorCode InvalidEnumValue = new(Values.InvalidEnumValue);

    public static readonly ErrorCode InvalidContentType = new(Values.InvalidContentType);

    public static readonly ErrorCode InvalidFormValue = new(Values.InvalidFormValue);

    public static readonly ErrorCode CustomerNotFound = new(Values.CustomerNotFound);

    public static readonly ErrorCode OneInstrumentExpected = new(Values.OneInstrumentExpected);

    public static readonly ErrorCode NoFieldsSet = new(Values.NoFieldsSet);

    public static readonly ErrorCode TooManyMapEntries = new(Values.TooManyMapEntries);

    public static readonly ErrorCode MapKeyLengthTooShort = new(Values.MapKeyLengthTooShort);

    public static readonly ErrorCode MapKeyLengthTooLong = new(Values.MapKeyLengthTooLong);

    public static readonly ErrorCode CustomerMissingName = new(Values.CustomerMissingName);

    public static readonly ErrorCode CustomerMissingEmail = new(Values.CustomerMissingEmail);

    public static readonly ErrorCode InvalidPauseLength = new(Values.InvalidPauseLength);

    public static readonly ErrorCode InvalidDate = new(Values.InvalidDate);

    public static readonly ErrorCode UnsupportedCountry = new(Values.UnsupportedCountry);

    public static readonly ErrorCode UnsupportedCurrency = new(Values.UnsupportedCurrency);

    public static readonly ErrorCode AppleTtpPinToken = new(Values.AppleTtpPinToken);

    public static readonly ErrorCode CardExpired = new(Values.CardExpired);

    public static readonly ErrorCode InvalidExpiration = new(Values.InvalidExpiration);

    public static readonly ErrorCode InvalidExpirationYear = new(Values.InvalidExpirationYear);

    public static readonly ErrorCode InvalidExpirationDate = new(Values.InvalidExpirationDate);

    public static readonly ErrorCode UnsupportedCardBrand = new(Values.UnsupportedCardBrand);

    public static readonly ErrorCode UnsupportedEntryMethod = new(Values.UnsupportedEntryMethod);

    public static readonly ErrorCode InvalidEncryptedCard = new(Values.InvalidEncryptedCard);

    public static readonly ErrorCode InvalidCard = new(Values.InvalidCard);

    public static readonly ErrorCode PaymentAmountMismatch = new(Values.PaymentAmountMismatch);

    public static readonly ErrorCode GenericDecline = new(Values.GenericDecline);

    public static readonly ErrorCode CvvFailure = new(Values.CvvFailure);

    public static readonly ErrorCode AddressVerificationFailure = new(
        Values.AddressVerificationFailure
    );

    public static readonly ErrorCode InvalidAccount = new(Values.InvalidAccount);

    public static readonly ErrorCode CurrencyMismatch = new(Values.CurrencyMismatch);

    public static readonly ErrorCode InsufficientFunds = new(Values.InsufficientFunds);

    public static readonly ErrorCode InsufficientPermissions = new(Values.InsufficientPermissions);

    public static readonly ErrorCode CardholderInsufficientPermissions = new(
        Values.CardholderInsufficientPermissions
    );

    public static readonly ErrorCode InvalidLocation = new(Values.InvalidLocation);

    public static readonly ErrorCode TransactionLimit = new(Values.TransactionLimit);

    public static readonly ErrorCode VoiceFailure = new(Values.VoiceFailure);

    public static readonly ErrorCode PanFailure = new(Values.PanFailure);

    public static readonly ErrorCode ExpirationFailure = new(Values.ExpirationFailure);

    public static readonly ErrorCode CardNotSupported = new(Values.CardNotSupported);

    public static readonly ErrorCode ReaderDeclined = new(Values.ReaderDeclined);

    public static readonly ErrorCode InvalidPin = new(Values.InvalidPin);

    public static readonly ErrorCode MissingPin = new(Values.MissingPin);

    public static readonly ErrorCode MissingAccountType = new(Values.MissingAccountType);

    public static readonly ErrorCode InvalidPostalCode = new(Values.InvalidPostalCode);

    public static readonly ErrorCode InvalidFees = new(Values.InvalidFees);

    public static readonly ErrorCode ManuallyEnteredPaymentNotSupported = new(
        Values.ManuallyEnteredPaymentNotSupported
    );

    public static readonly ErrorCode PaymentLimitExceeded = new(Values.PaymentLimitExceeded);

    public static readonly ErrorCode GiftCardAvailableAmount = new(Values.GiftCardAvailableAmount);

    public static readonly ErrorCode AccountUnusable = new(Values.AccountUnusable);

    public static readonly ErrorCode BuyerRefusedPayment = new(Values.BuyerRefusedPayment);

    public static readonly ErrorCode DelayedTransactionExpired = new(
        Values.DelayedTransactionExpired
    );

    public static readonly ErrorCode DelayedTransactionCanceled = new(
        Values.DelayedTransactionCanceled
    );

    public static readonly ErrorCode DelayedTransactionCaptured = new(
        Values.DelayedTransactionCaptured
    );

    public static readonly ErrorCode DelayedTransactionFailed = new(
        Values.DelayedTransactionFailed
    );

    public static readonly ErrorCode CardTokenExpired = new(Values.CardTokenExpired);

    public static readonly ErrorCode CardTokenUsed = new(Values.CardTokenUsed);

    public static readonly ErrorCode AmountTooHigh = new(Values.AmountTooHigh);

    public static readonly ErrorCode UnsupportedInstrumentType = new(
        Values.UnsupportedInstrumentType
    );

    public static readonly ErrorCode RefundAmountInvalid = new(Values.RefundAmountInvalid);

    public static readonly ErrorCode RefundAlreadyPending = new(Values.RefundAlreadyPending);

    public static readonly ErrorCode PaymentNotRefundable = new(Values.PaymentNotRefundable);

    public static readonly ErrorCode PaymentNotRefundableDueToDispute = new(
        Values.PaymentNotRefundableDueToDispute
    );

    public static readonly ErrorCode RefundErrorPaymentNeedsCompletion = new(
        Values.RefundErrorPaymentNeedsCompletion
    );

    public static readonly ErrorCode RefundDeclined = new(Values.RefundDeclined);

    public static readonly ErrorCode InsufficientPermissionsForRefund = new(
        Values.InsufficientPermissionsForRefund
    );

    public static readonly ErrorCode InvalidCardData = new(Values.InvalidCardData);

    public static readonly ErrorCode SourceUsed = new(Values.SourceUsed);

    public static readonly ErrorCode SourceExpired = new(Values.SourceExpired);

    public static readonly ErrorCode UnsupportedLoyaltyRewardTier = new(
        Values.UnsupportedLoyaltyRewardTier
    );

    public static readonly ErrorCode LocationMismatch = new(Values.LocationMismatch);

    public static readonly ErrorCode OrderUnpaidNotReturnable = new(
        Values.OrderUnpaidNotReturnable
    );

    public static readonly ErrorCode PartialPaymentDelayCaptureNotSupported = new(
        Values.PartialPaymentDelayCaptureNotSupported
    );

    public static readonly ErrorCode IdempotencyKeyReused = new(Values.IdempotencyKeyReused);

    public static readonly ErrorCode UnexpectedValue = new(Values.UnexpectedValue);

    public static readonly ErrorCode SandboxNotSupported = new(Values.SandboxNotSupported);

    public static readonly ErrorCode InvalidEmailAddress = new(Values.InvalidEmailAddress);

    public static readonly ErrorCode InvalidPhoneNumber = new(Values.InvalidPhoneNumber);

    public static readonly ErrorCode CheckoutExpired = new(Values.CheckoutExpired);

    public static readonly ErrorCode BadCertificate = new(Values.BadCertificate);

    public static readonly ErrorCode InvalidSquareVersionFormat = new(
        Values.InvalidSquareVersionFormat
    );

    public static readonly ErrorCode ApiVersionIncompatible = new(Values.ApiVersionIncompatible);

    public static readonly ErrorCode CardPresenceRequired = new(Values.CardPresenceRequired);

    public static readonly ErrorCode UnsupportedSourceType = new(Values.UnsupportedSourceType);

    public static readonly ErrorCode CardMismatch = new(Values.CardMismatch);

    public static readonly ErrorCode PlaidError = new(Values.PlaidError);

    public static readonly ErrorCode PlaidErrorItemLoginRequired = new(
        Values.PlaidErrorItemLoginRequired
    );

    public static readonly ErrorCode PlaidErrorRateLimit = new(Values.PlaidErrorRateLimit);

    public static readonly ErrorCode PaymentSourceNotEnabledForTarget = new(
        Values.PaymentSourceNotEnabledForTarget
    );

    public static readonly ErrorCode CardDeclined = new(Values.CardDeclined);

    public static readonly ErrorCode VerifyCvvFailure = new(Values.VerifyCvvFailure);

    public static readonly ErrorCode VerifyAvsFailure = new(Values.VerifyAvsFailure);

    public static readonly ErrorCode CardDeclinedCallIssuer = new(Values.CardDeclinedCallIssuer);

    public static readonly ErrorCode CardDeclinedVerificationRequired = new(
        Values.CardDeclinedVerificationRequired
    );

    public static readonly ErrorCode BadExpiration = new(Values.BadExpiration);

    public static readonly ErrorCode ChipInsertionRequired = new(Values.ChipInsertionRequired);

    public static readonly ErrorCode AllowablePinTriesExceeded = new(
        Values.AllowablePinTriesExceeded
    );

    public static readonly ErrorCode ReservationDeclined = new(Values.ReservationDeclined);

    public static readonly ErrorCode UnknownBodyParameter = new(Values.UnknownBodyParameter);

    public static readonly ErrorCode NotFound = new(Values.NotFound);

    public static readonly ErrorCode ApplePaymentProcessingCertificateHashNotFound = new(
        Values.ApplePaymentProcessingCertificateHashNotFound
    );

    public static readonly ErrorCode MethodNotAllowed = new(Values.MethodNotAllowed);

    public static readonly ErrorCode NotAcceptable = new(Values.NotAcceptable);

    public static readonly ErrorCode RequestTimeout = new(Values.RequestTimeout);

    public static readonly ErrorCode Conflict = new(Values.Conflict);

    public static readonly ErrorCode Gone = new(Values.Gone);

    public static readonly ErrorCode RequestEntityTooLarge = new(Values.RequestEntityTooLarge);

    public static readonly ErrorCode UnsupportedMediaType = new(Values.UnsupportedMediaType);

    public static readonly ErrorCode UnprocessableEntity = new(Values.UnprocessableEntity);

    public static readonly ErrorCode RateLimited = new(Values.RateLimited);

    public static readonly ErrorCode NotImplemented = new(Values.NotImplemented);

    public static readonly ErrorCode BadGateway = new(Values.BadGateway);

    public static readonly ErrorCode ServiceUnavailable = new(Values.ServiceUnavailable);

    public static readonly ErrorCode TemporaryError = new(Values.TemporaryError);

    public static readonly ErrorCode GatewayTimeout = new(Values.GatewayTimeout);

    public ErrorCode(string value)
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
    public static ErrorCode FromCustom(string value)
    {
        return new ErrorCode(value);
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

    public static bool operator ==(ErrorCode value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(ErrorCode value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(ErrorCode value) => value.Value;

    public static explicit operator ErrorCode(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string InternalServerError = "INTERNAL_SERVER_ERROR";

        public const string Unauthorized = "UNAUTHORIZED";

        public const string AccessTokenExpired = "ACCESS_TOKEN_EXPIRED";

        public const string AccessTokenRevoked = "ACCESS_TOKEN_REVOKED";

        public const string ClientDisabled = "CLIENT_DISABLED";

        public const string Forbidden = "FORBIDDEN";

        public const string InsufficientScopes = "INSUFFICIENT_SCOPES";

        public const string ApplicationDisabled = "APPLICATION_DISABLED";

        public const string V1Application = "V1_APPLICATION";

        public const string V1AccessToken = "V1_ACCESS_TOKEN";

        public const string CardProcessingNotEnabled = "CARD_PROCESSING_NOT_ENABLED";

        public const string MerchantSubscriptionNotFound = "MERCHANT_SUBSCRIPTION_NOT_FOUND";

        public const string BadRequest = "BAD_REQUEST";

        public const string MissingRequiredParameter = "MISSING_REQUIRED_PARAMETER";

        public const string IncorrectType = "INCORRECT_TYPE";

        public const string InvalidTime = "INVALID_TIME";

        public const string InvalidTimeRange = "INVALID_TIME_RANGE";

        public const string InvalidValue = "INVALID_VALUE";

        public const string InvalidCursor = "INVALID_CURSOR";

        public const string UnknownQueryParameter = "UNKNOWN_QUERY_PARAMETER";

        public const string ConflictingParameters = "CONFLICTING_PARAMETERS";

        public const string ExpectedJsonBody = "EXPECTED_JSON_BODY";

        public const string InvalidSortOrder = "INVALID_SORT_ORDER";

        public const string ValueRegexMismatch = "VALUE_REGEX_MISMATCH";

        public const string ValueTooShort = "VALUE_TOO_SHORT";

        public const string ValueTooLong = "VALUE_TOO_LONG";

        public const string ValueTooLow = "VALUE_TOO_LOW";

        public const string ValueTooHigh = "VALUE_TOO_HIGH";

        public const string ValueEmpty = "VALUE_EMPTY";

        public const string ArrayLengthTooLong = "ARRAY_LENGTH_TOO_LONG";

        public const string ArrayLengthTooShort = "ARRAY_LENGTH_TOO_SHORT";

        public const string ArrayEmpty = "ARRAY_EMPTY";

        public const string ExpectedBoolean = "EXPECTED_BOOLEAN";

        public const string ExpectedInteger = "EXPECTED_INTEGER";

        public const string ExpectedFloat = "EXPECTED_FLOAT";

        public const string ExpectedString = "EXPECTED_STRING";

        public const string ExpectedObject = "EXPECTED_OBJECT";

        public const string ExpectedArray = "EXPECTED_ARRAY";

        public const string ExpectedMap = "EXPECTED_MAP";

        public const string ExpectedBase64EncodedByteArray = "EXPECTED_BASE64_ENCODED_BYTE_ARRAY";

        public const string InvalidArrayValue = "INVALID_ARRAY_VALUE";

        public const string InvalidEnumValue = "INVALID_ENUM_VALUE";

        public const string InvalidContentType = "INVALID_CONTENT_TYPE";

        public const string InvalidFormValue = "INVALID_FORM_VALUE";

        public const string CustomerNotFound = "CUSTOMER_NOT_FOUND";

        public const string OneInstrumentExpected = "ONE_INSTRUMENT_EXPECTED";

        public const string NoFieldsSet = "NO_FIELDS_SET";

        public const string TooManyMapEntries = "TOO_MANY_MAP_ENTRIES";

        public const string MapKeyLengthTooShort = "MAP_KEY_LENGTH_TOO_SHORT";

        public const string MapKeyLengthTooLong = "MAP_KEY_LENGTH_TOO_LONG";

        public const string CustomerMissingName = "CUSTOMER_MISSING_NAME";

        public const string CustomerMissingEmail = "CUSTOMER_MISSING_EMAIL";

        public const string InvalidPauseLength = "INVALID_PAUSE_LENGTH";

        public const string InvalidDate = "INVALID_DATE";

        public const string UnsupportedCountry = "UNSUPPORTED_COUNTRY";

        public const string UnsupportedCurrency = "UNSUPPORTED_CURRENCY";

        public const string AppleTtpPinToken = "APPLE_TTP_PIN_TOKEN";

        public const string CardExpired = "CARD_EXPIRED";

        public const string InvalidExpiration = "INVALID_EXPIRATION";

        public const string InvalidExpirationYear = "INVALID_EXPIRATION_YEAR";

        public const string InvalidExpirationDate = "INVALID_EXPIRATION_DATE";

        public const string UnsupportedCardBrand = "UNSUPPORTED_CARD_BRAND";

        public const string UnsupportedEntryMethod = "UNSUPPORTED_ENTRY_METHOD";

        public const string InvalidEncryptedCard = "INVALID_ENCRYPTED_CARD";

        public const string InvalidCard = "INVALID_CARD";

        public const string PaymentAmountMismatch = "PAYMENT_AMOUNT_MISMATCH";

        public const string GenericDecline = "GENERIC_DECLINE";

        public const string CvvFailure = "CVV_FAILURE";

        public const string AddressVerificationFailure = "ADDRESS_VERIFICATION_FAILURE";

        public const string InvalidAccount = "INVALID_ACCOUNT";

        public const string CurrencyMismatch = "CURRENCY_MISMATCH";

        public const string InsufficientFunds = "INSUFFICIENT_FUNDS";

        public const string InsufficientPermissions = "INSUFFICIENT_PERMISSIONS";

        public const string CardholderInsufficientPermissions =
            "CARDHOLDER_INSUFFICIENT_PERMISSIONS";

        public const string InvalidLocation = "INVALID_LOCATION";

        public const string TransactionLimit = "TRANSACTION_LIMIT";

        public const string VoiceFailure = "VOICE_FAILURE";

        public const string PanFailure = "PAN_FAILURE";

        public const string ExpirationFailure = "EXPIRATION_FAILURE";

        public const string CardNotSupported = "CARD_NOT_SUPPORTED";

        public const string ReaderDeclined = "READER_DECLINED";

        public const string InvalidPin = "INVALID_PIN";

        public const string MissingPin = "MISSING_PIN";

        public const string MissingAccountType = "MISSING_ACCOUNT_TYPE";

        public const string InvalidPostalCode = "INVALID_POSTAL_CODE";

        public const string InvalidFees = "INVALID_FEES";

        public const string ManuallyEnteredPaymentNotSupported =
            "MANUALLY_ENTERED_PAYMENT_NOT_SUPPORTED";

        public const string PaymentLimitExceeded = "PAYMENT_LIMIT_EXCEEDED";

        public const string GiftCardAvailableAmount = "GIFT_CARD_AVAILABLE_AMOUNT";

        public const string AccountUnusable = "ACCOUNT_UNUSABLE";

        public const string BuyerRefusedPayment = "BUYER_REFUSED_PAYMENT";

        public const string DelayedTransactionExpired = "DELAYED_TRANSACTION_EXPIRED";

        public const string DelayedTransactionCanceled = "DELAYED_TRANSACTION_CANCELED";

        public const string DelayedTransactionCaptured = "DELAYED_TRANSACTION_CAPTURED";

        public const string DelayedTransactionFailed = "DELAYED_TRANSACTION_FAILED";

        public const string CardTokenExpired = "CARD_TOKEN_EXPIRED";

        public const string CardTokenUsed = "CARD_TOKEN_USED";

        public const string AmountTooHigh = "AMOUNT_TOO_HIGH";

        public const string UnsupportedInstrumentType = "UNSUPPORTED_INSTRUMENT_TYPE";

        public const string RefundAmountInvalid = "REFUND_AMOUNT_INVALID";

        public const string RefundAlreadyPending = "REFUND_ALREADY_PENDING";

        public const string PaymentNotRefundable = "PAYMENT_NOT_REFUNDABLE";

        public const string PaymentNotRefundableDueToDispute =
            "PAYMENT_NOT_REFUNDABLE_DUE_TO_DISPUTE";

        public const string RefundErrorPaymentNeedsCompletion =
            "REFUND_ERROR_PAYMENT_NEEDS_COMPLETION";

        public const string RefundDeclined = "REFUND_DECLINED";

        public const string InsufficientPermissionsForRefund =
            "INSUFFICIENT_PERMISSIONS_FOR_REFUND";

        public const string InvalidCardData = "INVALID_CARD_DATA";

        public const string SourceUsed = "SOURCE_USED";

        public const string SourceExpired = "SOURCE_EXPIRED";

        public const string UnsupportedLoyaltyRewardTier = "UNSUPPORTED_LOYALTY_REWARD_TIER";

        public const string LocationMismatch = "LOCATION_MISMATCH";

        public const string OrderUnpaidNotReturnable = "ORDER_UNPAID_NOT_RETURNABLE";

        public const string PartialPaymentDelayCaptureNotSupported =
            "PARTIAL_PAYMENT_DELAY_CAPTURE_NOT_SUPPORTED";

        public const string IdempotencyKeyReused = "IDEMPOTENCY_KEY_REUSED";

        public const string UnexpectedValue = "UNEXPECTED_VALUE";

        public const string SandboxNotSupported = "SANDBOX_NOT_SUPPORTED";

        public const string InvalidEmailAddress = "INVALID_EMAIL_ADDRESS";

        public const string InvalidPhoneNumber = "INVALID_PHONE_NUMBER";

        public const string CheckoutExpired = "CHECKOUT_EXPIRED";

        public const string BadCertificate = "BAD_CERTIFICATE";

        public const string InvalidSquareVersionFormat = "INVALID_SQUARE_VERSION_FORMAT";

        public const string ApiVersionIncompatible = "API_VERSION_INCOMPATIBLE";

        public const string CardPresenceRequired = "CARD_PRESENCE_REQUIRED";

        public const string UnsupportedSourceType = "UNSUPPORTED_SOURCE_TYPE";

        public const string CardMismatch = "CARD_MISMATCH";

        public const string PlaidError = "PLAID_ERROR";

        public const string PlaidErrorItemLoginRequired = "PLAID_ERROR_ITEM_LOGIN_REQUIRED";

        public const string PlaidErrorRateLimit = "PLAID_ERROR_RATE_LIMIT";

        public const string PaymentSourceNotEnabledForTarget =
            "PAYMENT_SOURCE_NOT_ENABLED_FOR_TARGET";

        public const string CardDeclined = "CARD_DECLINED";

        public const string VerifyCvvFailure = "VERIFY_CVV_FAILURE";

        public const string VerifyAvsFailure = "VERIFY_AVS_FAILURE";

        public const string CardDeclinedCallIssuer = "CARD_DECLINED_CALL_ISSUER";

        public const string CardDeclinedVerificationRequired =
            "CARD_DECLINED_VERIFICATION_REQUIRED";

        public const string BadExpiration = "BAD_EXPIRATION";

        public const string ChipInsertionRequired = "CHIP_INSERTION_REQUIRED";

        public const string AllowablePinTriesExceeded = "ALLOWABLE_PIN_TRIES_EXCEEDED";

        public const string ReservationDeclined = "RESERVATION_DECLINED";

        public const string UnknownBodyParameter = "UNKNOWN_BODY_PARAMETER";

        public const string NotFound = "NOT_FOUND";

        public const string ApplePaymentProcessingCertificateHashNotFound =
            "APPLE_PAYMENT_PROCESSING_CERTIFICATE_HASH_NOT_FOUND";

        public const string MethodNotAllowed = "METHOD_NOT_ALLOWED";

        public const string NotAcceptable = "NOT_ACCEPTABLE";

        public const string RequestTimeout = "REQUEST_TIMEOUT";

        public const string Conflict = "CONFLICT";

        public const string Gone = "GONE";

        public const string RequestEntityTooLarge = "REQUEST_ENTITY_TOO_LARGE";

        public const string UnsupportedMediaType = "UNSUPPORTED_MEDIA_TYPE";

        public const string UnprocessableEntity = "UNPROCESSABLE_ENTITY";

        public const string RateLimited = "RATE_LIMITED";

        public const string NotImplemented = "NOT_IMPLEMENTED";

        public const string BadGateway = "BAD_GATEWAY";

        public const string ServiceUnavailable = "SERVICE_UNAVAILABLE";

        public const string TemporaryError = "TEMPORARY_ERROR";

        public const string GatewayTimeout = "GATEWAY_TIMEOUT";
    }
}
