using System.Text.Json.Serialization;
using Square.Core;

namespace Square;

[JsonConverter(typeof(StringEnumSerializer<ErrorCategory>))]
public readonly record struct ErrorCategory : IStringEnum
{
    public static readonly ErrorCategory ApiError = new(Values.ApiError);

    public static readonly ErrorCategory AuthenticationError = new(Values.AuthenticationError);

    public static readonly ErrorCategory InvalidRequestError = new(Values.InvalidRequestError);

    public static readonly ErrorCategory RateLimitError = new(Values.RateLimitError);

    public static readonly ErrorCategory PaymentMethodError = new(Values.PaymentMethodError);

    public static readonly ErrorCategory RefundError = new(Values.RefundError);

    public static readonly ErrorCategory MerchantSubscriptionError = new(
        Values.MerchantSubscriptionError
    );

    public static readonly ErrorCategory ExternalVendorError = new(Values.ExternalVendorError);

    public ErrorCategory(string value)
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
    public static ErrorCategory FromCustom(string value)
    {
        return new ErrorCategory(value);
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

    public static bool operator ==(ErrorCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ErrorCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ErrorCategory value) => value.Value;

    public static explicit operator ErrorCategory(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    public static class Values
    {
        public const string ApiError = "API_ERROR";

        public const string AuthenticationError = "AUTHENTICATION_ERROR";

        public const string InvalidRequestError = "INVALID_REQUEST_ERROR";

        public const string RateLimitError = "RATE_LIMIT_ERROR";

        public const string PaymentMethodError = "PAYMENT_METHOD_ERROR";

        public const string RefundError = "REFUND_ERROR";

        public const string MerchantSubscriptionError = "MERCHANT_SUBSCRIPTION_ERROR";

        public const string ExternalVendorError = "EXTERNAL_VENDOR_ERROR";
    }
}
