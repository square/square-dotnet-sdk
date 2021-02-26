
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
    public class BankAccount 
    {
        public BankAccount(string id,
            string accountNumberSuffix,
            string country,
            string currency,
            string accountType,
            string holderName,
            string primaryBankIdentificationNumber,
            string status,
            bool creditable,
            bool debitable,
            string secondaryBankIdentificationNumber = null,
            string debitMandateReferenceId = null,
            string referenceId = null,
            string locationId = null,
            string fingerprint = null,
            int? version = null,
            string bankName = null)
        {
            Id = id;
            AccountNumberSuffix = accountNumberSuffix;
            Country = country;
            Currency = currency;
            AccountType = accountType;
            HolderName = holderName;
            PrimaryBankIdentificationNumber = primaryBankIdentificationNumber;
            SecondaryBankIdentificationNumber = secondaryBankIdentificationNumber;
            DebitMandateReferenceId = debitMandateReferenceId;
            ReferenceId = referenceId;
            LocationId = locationId;
            Status = status;
            Creditable = creditable;
            Debitable = debitable;
            Fingerprint = fingerprint;
            Version = version;
            BankName = bankName;
        }

        /// <summary>
        /// The unique, Square-issued identifier for the bank account.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The last few digits of the account number.
        /// </summary>
        [JsonProperty("account_number_suffix")]
        public string AccountNumberSuffix { get; }

        /// <summary>
        /// Indicates the country associated with another entity, such as a business.
        /// Values are in [ISO 3166-1-alpha-2 format](http://www.iso.org/iso/home/standards/country_codes.htm).
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; }

        /// <summary>
        /// Indicates the associated currency for an amount of money. Values correspond
        /// to [ISO 4217](https://wikipedia.org/wiki/ISO_4217).
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; }

        /// <summary>
        /// Indicates the financial purpose of the bank account.
        /// </summary>
        [JsonProperty("account_type")]
        public string AccountType { get; }

        /// <summary>
        /// Name of the account holder. This name must match the name 
        /// on the targeted bank account record.
        /// </summary>
        [JsonProperty("holder_name")]
        public string HolderName { get; }

        /// <summary>
        /// Primary identifier for the bank. For more information, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).
        /// </summary>
        [JsonProperty("primary_bank_identification_number")]
        public string PrimaryBankIdentificationNumber { get; }

        /// <summary>
        /// Secondary identifier for the bank. For more information, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api).
        /// </summary>
        [JsonProperty("secondary_bank_identification_number", NullValueHandling = NullValueHandling.Ignore)]
        public string SecondaryBankIdentificationNumber { get; }

        /// <summary>
        /// Reference identifier that will be displayed to UK bank account owners
        /// when collecting direct debit authorization. Only required for UK bank accounts.
        /// </summary>
        [JsonProperty("debit_mandate_reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string DebitMandateReferenceId { get; }

        /// <summary>
        /// Client-provided identifier for linking the banking account to an entity
        /// in a third-party system (for example, a bank account number or a user identifier).
        /// </summary>
        [JsonProperty("reference_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ReferenceId { get; }

        /// <summary>
        /// The location to which the bank account belongs.
        /// </summary>
        [JsonProperty("location_id", NullValueHandling = NullValueHandling.Ignore)]
        public string LocationId { get; }

        /// <summary>
        /// Indicates the current verification status of a `BankAccount` object.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// Indicates whether it is possible for Square to send money to this bank account.
        /// </summary>
        [JsonProperty("creditable")]
        public bool Creditable { get; }

        /// <summary>
        /// Indicates whether it is possible for Square to take money from this 
        /// bank account.
        /// </summary>
        [JsonProperty("debitable")]
        public bool Debitable { get; }

        /// <summary>
        /// A Square-assigned, unique identifier for the bank account based on the
        /// account information. The account fingerprint can be used to compare account
        /// entries and determine if the they represent the same real-world bank account.
        /// </summary>
        [JsonProperty("fingerprint", NullValueHandling = NullValueHandling.Ignore)]
        public string Fingerprint { get; }

        /// <summary>
        /// The current version of the `BankAccount`.
        /// </summary>
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// Read only. Name of actual financial institution. 
        /// For example "Bank of America".
        /// </summary>
        [JsonProperty("bank_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BankName { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BankAccount : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"AccountNumberSuffix = {(AccountNumberSuffix == null ? "null" : AccountNumberSuffix == string.Empty ? "" : AccountNumberSuffix)}");
            toStringOutput.Add($"Country = {(Country == null ? "null" : Country.ToString())}");
            toStringOutput.Add($"Currency = {(Currency == null ? "null" : Currency.ToString())}");
            toStringOutput.Add($"AccountType = {(AccountType == null ? "null" : AccountType.ToString())}");
            toStringOutput.Add($"HolderName = {(HolderName == null ? "null" : HolderName == string.Empty ? "" : HolderName)}");
            toStringOutput.Add($"PrimaryBankIdentificationNumber = {(PrimaryBankIdentificationNumber == null ? "null" : PrimaryBankIdentificationNumber == string.Empty ? "" : PrimaryBankIdentificationNumber)}");
            toStringOutput.Add($"SecondaryBankIdentificationNumber = {(SecondaryBankIdentificationNumber == null ? "null" : SecondaryBankIdentificationNumber == string.Empty ? "" : SecondaryBankIdentificationNumber)}");
            toStringOutput.Add($"DebitMandateReferenceId = {(DebitMandateReferenceId == null ? "null" : DebitMandateReferenceId == string.Empty ? "" : DebitMandateReferenceId)}");
            toStringOutput.Add($"ReferenceId = {(ReferenceId == null ? "null" : ReferenceId == string.Empty ? "" : ReferenceId)}");
            toStringOutput.Add($"LocationId = {(LocationId == null ? "null" : LocationId == string.Empty ? "" : LocationId)}");
            toStringOutput.Add($"Status = {(Status == null ? "null" : Status.ToString())}");
            toStringOutput.Add($"Creditable = {Creditable}");
            toStringOutput.Add($"Debitable = {Debitable}");
            toStringOutput.Add($"Fingerprint = {(Fingerprint == null ? "null" : Fingerprint == string.Empty ? "" : Fingerprint)}");
            toStringOutput.Add($"Version = {(Version == null ? "null" : Version.ToString())}");
            toStringOutput.Add($"BankName = {(BankName == null ? "null" : BankName == string.Empty ? "" : BankName)}");
        }

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

            return obj is BankAccount other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((AccountNumberSuffix == null && other.AccountNumberSuffix == null) || (AccountNumberSuffix?.Equals(other.AccountNumberSuffix) == true)) &&
                ((Country == null && other.Country == null) || (Country?.Equals(other.Country) == true)) &&
                ((Currency == null && other.Currency == null) || (Currency?.Equals(other.Currency) == true)) &&
                ((AccountType == null && other.AccountType == null) || (AccountType?.Equals(other.AccountType) == true)) &&
                ((HolderName == null && other.HolderName == null) || (HolderName?.Equals(other.HolderName) == true)) &&
                ((PrimaryBankIdentificationNumber == null && other.PrimaryBankIdentificationNumber == null) || (PrimaryBankIdentificationNumber?.Equals(other.PrimaryBankIdentificationNumber) == true)) &&
                ((SecondaryBankIdentificationNumber == null && other.SecondaryBankIdentificationNumber == null) || (SecondaryBankIdentificationNumber?.Equals(other.SecondaryBankIdentificationNumber) == true)) &&
                ((DebitMandateReferenceId == null && other.DebitMandateReferenceId == null) || (DebitMandateReferenceId?.Equals(other.DebitMandateReferenceId) == true)) &&
                ((ReferenceId == null && other.ReferenceId == null) || (ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((LocationId == null && other.LocationId == null) || (LocationId?.Equals(other.LocationId) == true)) &&
                ((Status == null && other.Status == null) || (Status?.Equals(other.Status) == true)) &&
                Creditable.Equals(other.Creditable) &&
                Debitable.Equals(other.Debitable) &&
                ((Fingerprint == null && other.Fingerprint == null) || (Fingerprint?.Equals(other.Fingerprint) == true)) &&
                ((Version == null && other.Version == null) || (Version?.Equals(other.Version) == true)) &&
                ((BankName == null && other.BankName == null) || (BankName?.Equals(other.BankName) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = 424336074;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (AccountNumberSuffix != null)
            {
               hashCode += AccountNumberSuffix.GetHashCode();
            }

            if (Country != null)
            {
               hashCode += Country.GetHashCode();
            }

            if (Currency != null)
            {
               hashCode += Currency.GetHashCode();
            }

            if (AccountType != null)
            {
               hashCode += AccountType.GetHashCode();
            }

            if (HolderName != null)
            {
               hashCode += HolderName.GetHashCode();
            }

            if (PrimaryBankIdentificationNumber != null)
            {
               hashCode += PrimaryBankIdentificationNumber.GetHashCode();
            }

            if (SecondaryBankIdentificationNumber != null)
            {
               hashCode += SecondaryBankIdentificationNumber.GetHashCode();
            }

            if (DebitMandateReferenceId != null)
            {
               hashCode += DebitMandateReferenceId.GetHashCode();
            }

            if (ReferenceId != null)
            {
               hashCode += ReferenceId.GetHashCode();
            }

            if (LocationId != null)
            {
               hashCode += LocationId.GetHashCode();
            }

            if (Status != null)
            {
               hashCode += Status.GetHashCode();
            }
            hashCode += Creditable.GetHashCode();
            hashCode += Debitable.GetHashCode();

            if (Fingerprint != null)
            {
               hashCode += Fingerprint.GetHashCode();
            }

            if (Version != null)
            {
               hashCode += Version.GetHashCode();
            }

            if (BankName != null)
            {
               hashCode += BankName.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder(Id,
                AccountNumberSuffix,
                Country,
                Currency,
                AccountType,
                HolderName,
                PrimaryBankIdentificationNumber,
                Status,
                Creditable,
                Debitable)
                .SecondaryBankIdentificationNumber(SecondaryBankIdentificationNumber)
                .DebitMandateReferenceId(DebitMandateReferenceId)
                .ReferenceId(ReferenceId)
                .LocationId(LocationId)
                .Fingerprint(Fingerprint)
                .Version(Version)
                .BankName(BankName);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string accountNumberSuffix;
            private string country;
            private string currency;
            private string accountType;
            private string holderName;
            private string primaryBankIdentificationNumber;
            private string status;
            private bool creditable;
            private bool debitable;
            private string secondaryBankIdentificationNumber;
            private string debitMandateReferenceId;
            private string referenceId;
            private string locationId;
            private string fingerprint;
            private int? version;
            private string bankName;

            public Builder(string id,
                string accountNumberSuffix,
                string country,
                string currency,
                string accountType,
                string holderName,
                string primaryBankIdentificationNumber,
                string status,
                bool creditable,
                bool debitable)
            {
                this.id = id;
                this.accountNumberSuffix = accountNumberSuffix;
                this.country = country;
                this.currency = currency;
                this.accountType = accountType;
                this.holderName = holderName;
                this.primaryBankIdentificationNumber = primaryBankIdentificationNumber;
                this.status = status;
                this.creditable = creditable;
                this.debitable = debitable;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder AccountNumberSuffix(string accountNumberSuffix)
            {
                this.accountNumberSuffix = accountNumberSuffix;
                return this;
            }

            public Builder Country(string country)
            {
                this.country = country;
                return this;
            }

            public Builder Currency(string currency)
            {
                this.currency = currency;
                return this;
            }

            public Builder AccountType(string accountType)
            {
                this.accountType = accountType;
                return this;
            }

            public Builder HolderName(string holderName)
            {
                this.holderName = holderName;
                return this;
            }

            public Builder PrimaryBankIdentificationNumber(string primaryBankIdentificationNumber)
            {
                this.primaryBankIdentificationNumber = primaryBankIdentificationNumber;
                return this;
            }

            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

            public Builder Creditable(bool creditable)
            {
                this.creditable = creditable;
                return this;
            }

            public Builder Debitable(bool debitable)
            {
                this.debitable = debitable;
                return this;
            }

            public Builder SecondaryBankIdentificationNumber(string secondaryBankIdentificationNumber)
            {
                this.secondaryBankIdentificationNumber = secondaryBankIdentificationNumber;
                return this;
            }

            public Builder DebitMandateReferenceId(string debitMandateReferenceId)
            {
                this.debitMandateReferenceId = debitMandateReferenceId;
                return this;
            }

            public Builder ReferenceId(string referenceId)
            {
                this.referenceId = referenceId;
                return this;
            }

            public Builder LocationId(string locationId)
            {
                this.locationId = locationId;
                return this;
            }

            public Builder Fingerprint(string fingerprint)
            {
                this.fingerprint = fingerprint;
                return this;
            }

            public Builder Version(int? version)
            {
                this.version = version;
                return this;
            }

            public Builder BankName(string bankName)
            {
                this.bankName = bankName;
                return this;
            }

            public BankAccount Build()
            {
                return new BankAccount(id,
                    accountNumberSuffix,
                    country,
                    currency,
                    accountType,
                    holderName,
                    primaryBankIdentificationNumber,
                    status,
                    creditable,
                    debitable,
                    secondaryBankIdentificationNumber,
                    debitMandateReferenceId,
                    referenceId,
                    locationId,
                    fingerprint,
                    version,
                    bankName);
            }
        }
    }
}