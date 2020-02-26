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
        /// [Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api).
        /// </summary>
        [JsonProperty("primary_bank_identification_number")]
        public string PrimaryBankIdentificationNumber { get; }

        /// <summary>
        /// Secondary identifier for the bank. For more information, see 
        /// [Bank Accounts API](https://developer.squareup.com/docs/docs/bank-accounts-api).
        /// </summary>
        [JsonProperty("secondary_bank_identification_number")]
        public string SecondaryBankIdentificationNumber { get; }

        /// <summary>
        /// Reference identifier that will be displayed to UK bank account owners
        /// when collecting direct debit authorization. Only required for UK bank accounts.
        /// </summary>
        [JsonProperty("debit_mandate_reference_id")]
        public string DebitMandateReferenceId { get; }

        /// <summary>
        /// Client-provided identifier for linking the banking account to an entity
        /// in a third-party system (for example, a bank account number or a user identifier).
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// The location to which the bank account belongs.
        /// </summary>
        [JsonProperty("location_id")]
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
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; }

        /// <summary>
        /// The current version of the `BankAccount`.
        /// </summary>
        [JsonProperty("version")]
        public int? Version { get; }

        /// <summary>
        /// Read only. Name of actual financial institution. 
        /// For example "Bank of America".
        /// </summary>
        [JsonProperty("bank_name")]
        public string BankName { get; }

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
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder AccountNumberSuffix(string value)
            {
                accountNumberSuffix = value;
                return this;
            }

            public Builder Country(string value)
            {
                country = value;
                return this;
            }

            public Builder Currency(string value)
            {
                currency = value;
                return this;
            }

            public Builder AccountType(string value)
            {
                accountType = value;
                return this;
            }

            public Builder HolderName(string value)
            {
                holderName = value;
                return this;
            }

            public Builder PrimaryBankIdentificationNumber(string value)
            {
                primaryBankIdentificationNumber = value;
                return this;
            }

            public Builder Status(string value)
            {
                status = value;
                return this;
            }

            public Builder Creditable(bool value)
            {
                creditable = value;
                return this;
            }

            public Builder Debitable(bool value)
            {
                debitable = value;
                return this;
            }

            public Builder SecondaryBankIdentificationNumber(string value)
            {
                secondaryBankIdentificationNumber = value;
                return this;
            }

            public Builder DebitMandateReferenceId(string value)
            {
                debitMandateReferenceId = value;
                return this;
            }

            public Builder ReferenceId(string value)
            {
                referenceId = value;
                return this;
            }

            public Builder LocationId(string value)
            {
                locationId = value;
                return this;
            }

            public Builder Fingerprint(string value)
            {
                fingerprint = value;
                return this;
            }

            public Builder Version(int? value)
            {
                version = value;
                return this;
            }

            public Builder BankName(string value)
            {
                bankName = value;
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