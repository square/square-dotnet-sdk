using System.Text.Json.Serialization;
using Square.Core;

namespace Square.Default;

[JsonConverter(typeof(StringEnumSerializer<CustomerCreationSource>))]
[Serializable]
public readonly record struct CustomerCreationSource : IStringEnum
{
    public static readonly CustomerCreationSource Other = new(Values.Other);

    public static readonly CustomerCreationSource Appointments = new(Values.Appointments);

    public static readonly CustomerCreationSource Coupon = new(Values.Coupon);

    public static readonly CustomerCreationSource DeletionRecovery = new(Values.DeletionRecovery);

    public static readonly CustomerCreationSource Directory = new(Values.Directory);

    public static readonly CustomerCreationSource Egifting = new(Values.Egifting);

    public static readonly CustomerCreationSource EmailCollection = new(Values.EmailCollection);

    public static readonly CustomerCreationSource Feedback = new(Values.Feedback);

    public static readonly CustomerCreationSource Import = new(Values.Import);

    public static readonly CustomerCreationSource Invoices = new(Values.Invoices);

    public static readonly CustomerCreationSource Loyalty = new(Values.Loyalty);

    public static readonly CustomerCreationSource Marketing = new(Values.Marketing);

    public static readonly CustomerCreationSource Merge = new(Values.Merge);

    public static readonly CustomerCreationSource OnlineStore = new(Values.OnlineStore);

    public static readonly CustomerCreationSource InstantProfile = new(Values.InstantProfile);

    public static readonly CustomerCreationSource Terminal = new(Values.Terminal);

    public static readonly CustomerCreationSource ThirdParty = new(Values.ThirdParty);

    public static readonly CustomerCreationSource ThirdPartyImport = new(Values.ThirdPartyImport);

    public static readonly CustomerCreationSource UnmergeRecovery = new(Values.UnmergeRecovery);

    public CustomerCreationSource(string value)
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
    public static CustomerCreationSource FromCustom(string value)
    {
        return new CustomerCreationSource(value);
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

    public static bool operator ==(CustomerCreationSource value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomerCreationSource value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomerCreationSource value) => value.Value;

    public static explicit operator CustomerCreationSource(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Other = "OTHER";

        public const string Appointments = "APPOINTMENTS";

        public const string Coupon = "COUPON";

        public const string DeletionRecovery = "DELETION_RECOVERY";

        public const string Directory = "DIRECTORY";

        public const string Egifting = "EGIFTING";

        public const string EmailCollection = "EMAIL_COLLECTION";

        public const string Feedback = "FEEDBACK";

        public const string Import = "IMPORT";

        public const string Invoices = "INVOICES";

        public const string Loyalty = "LOYALTY";

        public const string Marketing = "MARKETING";

        public const string Merge = "MERGE";

        public const string OnlineStore = "ONLINE_STORE";

        public const string InstantProfile = "INSTANT_PROFILE";

        public const string Terminal = "TERMINAL";

        public const string ThirdParty = "THIRD_PARTY";

        public const string ThirdPartyImport = "THIRD_PARTY_IMPORT";

        public const string UnmergeRecovery = "UNMERGE_RECOVERY";
    }
}
