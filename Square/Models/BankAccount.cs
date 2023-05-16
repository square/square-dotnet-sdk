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
    /// BankAccount.
    /// </summary>
    public class BankAccount
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="accountNumberSuffix">account_number_suffix.</param>
        /// <param name="country">country.</param>
        /// <param name="currency">currency.</param>
        /// <param name="accountType">account_type.</param>
        /// <param name="holderName">holder_name.</param>
        /// <param name="primaryBankIdentificationNumber">primary_bank_identification_number.</param>
        /// <param name="status">status.</param>
        /// <param name="creditable">creditable.</param>
        /// <param name="debitable">debitable.</param>
        /// <param name="secondaryBankIdentificationNumber">secondary_bank_identification_number.</param>
        /// <param name="debitMandateReferenceId">debit_mandate_reference_id.</param>
        /// <param name="referenceId">reference_id.</param>
        /// <param name="locationId">location_id.</param>
        /// <param name="fingerprint">fingerprint.</param>
        /// <param name="version">version.</param>
        /// <param name="bankName">bank_name.</param>
        public BankAccount(
            string id,
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "secondary_bank_identification_number", false },
                { "debit_mandate_reference_id", false },
                { "reference_id", false },
                { "location_id", false },
                { "fingerprint", false },
                { "bank_name", false }
            };

            this.Id = id;
            this.AccountNumberSuffix = accountNumberSuffix;
            this.Country = country;
            this.Currency = currency;
            this.AccountType = accountType;
            this.HolderName = holderName;
            this.PrimaryBankIdentificationNumber = primaryBankIdentificationNumber;
            if (secondaryBankIdentificationNumber != null)
            {
                shouldSerialize["secondary_bank_identification_number"] = true;
                this.SecondaryBankIdentificationNumber = secondaryBankIdentificationNumber;
            }

            if (debitMandateReferenceId != null)
            {
                shouldSerialize["debit_mandate_reference_id"] = true;
                this.DebitMandateReferenceId = debitMandateReferenceId;
            }

            if (referenceId != null)
            {
                shouldSerialize["reference_id"] = true;
                this.ReferenceId = referenceId;
            }

            if (locationId != null)
            {
                shouldSerialize["location_id"] = true;
                this.LocationId = locationId;
            }

            this.Status = status;
            this.Creditable = creditable;
            this.Debitable = debitable;
            if (fingerprint != null)
            {
                shouldSerialize["fingerprint"] = true;
                this.Fingerprint = fingerprint;
            }

            this.Version = version;
            if (bankName != null)
            {
                shouldSerialize["bank_name"] = true;
                this.BankName = bankName;
            }

        }
        internal BankAccount(Dictionary<string, bool> shouldSerialize,
            string id,
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
            this.shouldSerialize = shouldSerialize;
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
        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public int? Version { get; }

        /// <summary>
        /// Read only. Name of actual financial institution.
        /// For example "Bank of America".
        /// </summary>
        [JsonProperty("bank_name")]
        public string BankName { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BankAccount : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSecondaryBankIdentificationNumber()
        {
            return this.shouldSerialize["secondary_bank_identification_number"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeDebitMandateReferenceId()
        {
            return this.shouldSerialize["debit_mandate_reference_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReferenceId()
        {
            return this.shouldSerialize["reference_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeLocationId()
        {
            return this.shouldSerialize["location_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeFingerprint()
        {
            return this.shouldSerialize["fingerprint"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeBankName()
        {
            return this.shouldSerialize["bank_name"];
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
            return obj is BankAccount other &&                ((this.Id == null && other.Id == null) || (this.Id?.Equals(other.Id) == true)) &&
                ((this.AccountNumberSuffix == null && other.AccountNumberSuffix == null) || (this.AccountNumberSuffix?.Equals(other.AccountNumberSuffix) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.Currency == null && other.Currency == null) || (this.Currency?.Equals(other.Currency) == true)) &&
                ((this.AccountType == null && other.AccountType == null) || (this.AccountType?.Equals(other.AccountType) == true)) &&
                ((this.HolderName == null && other.HolderName == null) || (this.HolderName?.Equals(other.HolderName) == true)) &&
                ((this.PrimaryBankIdentificationNumber == null && other.PrimaryBankIdentificationNumber == null) || (this.PrimaryBankIdentificationNumber?.Equals(other.PrimaryBankIdentificationNumber) == true)) &&
                ((this.SecondaryBankIdentificationNumber == null && other.SecondaryBankIdentificationNumber == null) || (this.SecondaryBankIdentificationNumber?.Equals(other.SecondaryBankIdentificationNumber) == true)) &&
                ((this.DebitMandateReferenceId == null && other.DebitMandateReferenceId == null) || (this.DebitMandateReferenceId?.Equals(other.DebitMandateReferenceId) == true)) &&
                ((this.ReferenceId == null && other.ReferenceId == null) || (this.ReferenceId?.Equals(other.ReferenceId) == true)) &&
                ((this.LocationId == null && other.LocationId == null) || (this.LocationId?.Equals(other.LocationId) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                this.Creditable.Equals(other.Creditable) &&
                this.Debitable.Equals(other.Debitable) &&
                ((this.Fingerprint == null && other.Fingerprint == null) || (this.Fingerprint?.Equals(other.Fingerprint) == true)) &&
                ((this.Version == null && other.Version == null) || (this.Version?.Equals(other.Version) == true)) &&
                ((this.BankName == null && other.BankName == null) || (this.BankName?.Equals(other.BankName) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 424336074;
            hashCode = HashCode.Combine(this.Id, this.AccountNumberSuffix, this.Country, this.Currency, this.AccountType, this.HolderName, this.PrimaryBankIdentificationNumber);

            hashCode = HashCode.Combine(hashCode, this.SecondaryBankIdentificationNumber, this.DebitMandateReferenceId, this.ReferenceId, this.LocationId, this.Status, this.Creditable, this.Debitable);

            hashCode = HashCode.Combine(hashCode, this.Fingerprint, this.Version, this.BankName);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Id = {(this.Id == null ? "null" : this.Id == string.Empty ? "" : this.Id)}");
            toStringOutput.Add($"this.AccountNumberSuffix = {(this.AccountNumberSuffix == null ? "null" : this.AccountNumberSuffix == string.Empty ? "" : this.AccountNumberSuffix)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country.ToString())}");
            toStringOutput.Add($"this.Currency = {(this.Currency == null ? "null" : this.Currency.ToString())}");
            toStringOutput.Add($"this.AccountType = {(this.AccountType == null ? "null" : this.AccountType.ToString())}");
            toStringOutput.Add($"this.HolderName = {(this.HolderName == null ? "null" : this.HolderName == string.Empty ? "" : this.HolderName)}");
            toStringOutput.Add($"this.PrimaryBankIdentificationNumber = {(this.PrimaryBankIdentificationNumber == null ? "null" : this.PrimaryBankIdentificationNumber == string.Empty ? "" : this.PrimaryBankIdentificationNumber)}");
            toStringOutput.Add($"this.SecondaryBankIdentificationNumber = {(this.SecondaryBankIdentificationNumber == null ? "null" : this.SecondaryBankIdentificationNumber == string.Empty ? "" : this.SecondaryBankIdentificationNumber)}");
            toStringOutput.Add($"this.DebitMandateReferenceId = {(this.DebitMandateReferenceId == null ? "null" : this.DebitMandateReferenceId == string.Empty ? "" : this.DebitMandateReferenceId)}");
            toStringOutput.Add($"this.ReferenceId = {(this.ReferenceId == null ? "null" : this.ReferenceId == string.Empty ? "" : this.ReferenceId)}");
            toStringOutput.Add($"this.LocationId = {(this.LocationId == null ? "null" : this.LocationId == string.Empty ? "" : this.LocationId)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status.ToString())}");
            toStringOutput.Add($"this.Creditable = {this.Creditable}");
            toStringOutput.Add($"this.Debitable = {this.Debitable}");
            toStringOutput.Add($"this.Fingerprint = {(this.Fingerprint == null ? "null" : this.Fingerprint == string.Empty ? "" : this.Fingerprint)}");
            toStringOutput.Add($"this.Version = {(this.Version == null ? "null" : this.Version.ToString())}");
            toStringOutput.Add($"this.BankName = {(this.BankName == null ? "null" : this.BankName == string.Empty ? "" : this.BankName)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.Id,
                this.AccountNumberSuffix,
                this.Country,
                this.Currency,
                this.AccountType,
                this.HolderName,
                this.PrimaryBankIdentificationNumber,
                this.Status,
                this.Creditable,
                this.Debitable)
                .SecondaryBankIdentificationNumber(this.SecondaryBankIdentificationNumber)
                .DebitMandateReferenceId(this.DebitMandateReferenceId)
                .ReferenceId(this.ReferenceId)
                .LocationId(this.LocationId)
                .Fingerprint(this.Fingerprint)
                .Version(this.Version)
                .BankName(this.BankName);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "secondary_bank_identification_number", false },
                { "debit_mandate_reference_id", false },
                { "reference_id", false },
                { "location_id", false },
                { "fingerprint", false },
                { "bank_name", false },
            };

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

            public Builder(
                string id,
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
             /// AccountNumberSuffix.
             /// </summary>
             /// <param name="accountNumberSuffix"> accountNumberSuffix. </param>
             /// <returns> Builder. </returns>
            public Builder AccountNumberSuffix(string accountNumberSuffix)
            {
                this.accountNumberSuffix = accountNumberSuffix;
                return this;
            }

             /// <summary>
             /// Country.
             /// </summary>
             /// <param name="country"> country. </param>
             /// <returns> Builder. </returns>
            public Builder Country(string country)
            {
                this.country = country;
                return this;
            }

             /// <summary>
             /// Currency.
             /// </summary>
             /// <param name="currency"> currency. </param>
             /// <returns> Builder. </returns>
            public Builder Currency(string currency)
            {
                this.currency = currency;
                return this;
            }

             /// <summary>
             /// AccountType.
             /// </summary>
             /// <param name="accountType"> accountType. </param>
             /// <returns> Builder. </returns>
            public Builder AccountType(string accountType)
            {
                this.accountType = accountType;
                return this;
            }

             /// <summary>
             /// HolderName.
             /// </summary>
             /// <param name="holderName"> holderName. </param>
             /// <returns> Builder. </returns>
            public Builder HolderName(string holderName)
            {
                this.holderName = holderName;
                return this;
            }

             /// <summary>
             /// PrimaryBankIdentificationNumber.
             /// </summary>
             /// <param name="primaryBankIdentificationNumber"> primaryBankIdentificationNumber. </param>
             /// <returns> Builder. </returns>
            public Builder PrimaryBankIdentificationNumber(string primaryBankIdentificationNumber)
            {
                this.primaryBankIdentificationNumber = primaryBankIdentificationNumber;
                return this;
            }

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                this.status = status;
                return this;
            }

             /// <summary>
             /// Creditable.
             /// </summary>
             /// <param name="creditable"> creditable. </param>
             /// <returns> Builder. </returns>
            public Builder Creditable(bool creditable)
            {
                this.creditable = creditable;
                return this;
            }

             /// <summary>
             /// Debitable.
             /// </summary>
             /// <param name="debitable"> debitable. </param>
             /// <returns> Builder. </returns>
            public Builder Debitable(bool debitable)
            {
                this.debitable = debitable;
                return this;
            }

             /// <summary>
             /// SecondaryBankIdentificationNumber.
             /// </summary>
             /// <param name="secondaryBankIdentificationNumber"> secondaryBankIdentificationNumber. </param>
             /// <returns> Builder. </returns>
            public Builder SecondaryBankIdentificationNumber(string secondaryBankIdentificationNumber)
            {
                shouldSerialize["secondary_bank_identification_number"] = true;
                this.secondaryBankIdentificationNumber = secondaryBankIdentificationNumber;
                return this;
            }

             /// <summary>
             /// DebitMandateReferenceId.
             /// </summary>
             /// <param name="debitMandateReferenceId"> debitMandateReferenceId. </param>
             /// <returns> Builder. </returns>
            public Builder DebitMandateReferenceId(string debitMandateReferenceId)
            {
                shouldSerialize["debit_mandate_reference_id"] = true;
                this.debitMandateReferenceId = debitMandateReferenceId;
                return this;
            }

             /// <summary>
             /// ReferenceId.
             /// </summary>
             /// <param name="referenceId"> referenceId. </param>
             /// <returns> Builder. </returns>
            public Builder ReferenceId(string referenceId)
            {
                shouldSerialize["reference_id"] = true;
                this.referenceId = referenceId;
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
             /// Fingerprint.
             /// </summary>
             /// <param name="fingerprint"> fingerprint. </param>
             /// <returns> Builder. </returns>
            public Builder Fingerprint(string fingerprint)
            {
                shouldSerialize["fingerprint"] = true;
                this.fingerprint = fingerprint;
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
             /// BankName.
             /// </summary>
             /// <param name="bankName"> bankName. </param>
             /// <returns> Builder. </returns>
            public Builder BankName(string bankName)
            {
                shouldSerialize["bank_name"] = true;
                this.bankName = bankName;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetSecondaryBankIdentificationNumber()
            {
                this.shouldSerialize["secondary_bank_identification_number"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetDebitMandateReferenceId()
            {
                this.shouldSerialize["debit_mandate_reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetReferenceId()
            {
                this.shouldSerialize["reference_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetLocationId()
            {
                this.shouldSerialize["location_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetFingerprint()
            {
                this.shouldSerialize["fingerprint"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetBankName()
            {
                this.shouldSerialize["bank_name"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BankAccount. </returns>
            public BankAccount Build()
            {
                return new BankAccount(shouldSerialize,
                    this.id,
                    this.accountNumberSuffix,
                    this.country,
                    this.currency,
                    this.accountType,
                    this.holderName,
                    this.primaryBankIdentificationNumber,
                    this.status,
                    this.creditable,
                    this.debitable,
                    this.secondaryBankIdentificationNumber,
                    this.debitMandateReferenceId,
                    this.referenceId,
                    this.locationId,
                    this.fingerprint,
                    this.version,
                    this.bankName);
            }
        }
    }
}