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
    /// BankAccountPaymentDetails.
    /// </summary>
    public class BankAccountPaymentDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountPaymentDetails"/> class.
        /// </summary>
        /// <param name="bankName">bank_name.</param>
        /// <param name="transferType">transfer_type.</param>
        /// <param name="accountOwnershipType">account_ownership_type.</param>
        /// <param name="fingerprint">fingerprint.</param>
        /// <param name="country">country.</param>
        /// <param name="statementDescription">statement_description.</param>
        /// <param name="achDetails">ach_details.</param>
        /// <param name="errors">errors.</param>
        public BankAccountPaymentDetails(
            string bankName = null,
            string transferType = null,
            string accountOwnershipType = null,
            string fingerprint = null,
            string country = null,
            string statementDescription = null,
            Models.ACHDetails achDetails = null,
            IList<Models.Error> errors = null)
        {
            this.BankName = bankName;
            this.TransferType = transferType;
            this.AccountOwnershipType = accountOwnershipType;
            this.Fingerprint = fingerprint;
            this.Country = country;
            this.StatementDescription = statementDescription;
            this.AchDetails = achDetails;
            this.Errors = errors;
        }

        /// <summary>
        /// The name of the bank associated with the bank account.
        /// </summary>
        [JsonProperty("bank_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BankName { get; }

        /// <summary>
        /// The type of the bank transfer. The type can be `ACH` or `UNKNOWN`.
        /// </summary>
        [JsonProperty("transfer_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TransferType { get; }

        /// <summary>
        /// The ownership type of the bank account performing the transfer.
        /// The type can be `INDIVIDUAL`, `COMPANY`, or `UNKNOWN`.
        /// </summary>
        [JsonProperty("account_ownership_type", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountOwnershipType { get; }

        /// <summary>
        /// Uniquely identifies the bank account for this seller and can be used
        /// to determine if payments are from the same bank account.
        /// </summary>
        [JsonProperty("fingerprint", NullValueHandling = NullValueHandling.Ignore)]
        public string Fingerprint { get; }

        /// <summary>
        /// The two-letter ISO code representing the country the bank account is located in.
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; }

        /// <summary>
        /// The statement description as sent to the bank.
        /// </summary>
        [JsonProperty("statement_description", NullValueHandling = NullValueHandling.Ignore)]
        public string StatementDescription { get; }

        /// <summary>
        /// ACH-specific details about `BANK_ACCOUNT` type payments with the `transfer_type` of `ACH`.
        /// </summary>
        [JsonProperty("ach_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.ACHDetails AchDetails { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BankAccountPaymentDetails : ({string.Join(", ", toStringOutput)})";
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

            return obj is BankAccountPaymentDetails other &&
                ((this.BankName == null && other.BankName == null) || (this.BankName?.Equals(other.BankName) == true)) &&
                ((this.TransferType == null && other.TransferType == null) || (this.TransferType?.Equals(other.TransferType) == true)) &&
                ((this.AccountOwnershipType == null && other.AccountOwnershipType == null) || (this.AccountOwnershipType?.Equals(other.AccountOwnershipType) == true)) &&
                ((this.Fingerprint == null && other.Fingerprint == null) || (this.Fingerprint?.Equals(other.Fingerprint) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.StatementDescription == null && other.StatementDescription == null) || (this.StatementDescription?.Equals(other.StatementDescription) == true)) &&
                ((this.AchDetails == null && other.AchDetails == null) || (this.AchDetails?.Equals(other.AchDetails) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 863047892;
            hashCode = HashCode.Combine(this.BankName, this.TransferType, this.AccountOwnershipType, this.Fingerprint, this.Country, this.StatementDescription, this.AchDetails);

            hashCode = HashCode.Combine(hashCode, this.Errors);

            return hashCode;
        }
  
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.BankName = {(this.BankName == null ? "null" : this.BankName == string.Empty ? "" : this.BankName)}");
            toStringOutput.Add($"this.TransferType = {(this.TransferType == null ? "null" : this.TransferType == string.Empty ? "" : this.TransferType)}");
            toStringOutput.Add($"this.AccountOwnershipType = {(this.AccountOwnershipType == null ? "null" : this.AccountOwnershipType == string.Empty ? "" : this.AccountOwnershipType)}");
            toStringOutput.Add($"this.Fingerprint = {(this.Fingerprint == null ? "null" : this.Fingerprint == string.Empty ? "" : this.Fingerprint)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country == string.Empty ? "" : this.Country)}");
            toStringOutput.Add($"this.StatementDescription = {(this.StatementDescription == null ? "null" : this.StatementDescription == string.Empty ? "" : this.StatementDescription)}");
            toStringOutput.Add($"this.AchDetails = {(this.AchDetails == null ? "null" : this.AchDetails.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .BankName(this.BankName)
                .TransferType(this.TransferType)
                .AccountOwnershipType(this.AccountOwnershipType)
                .Fingerprint(this.Fingerprint)
                .Country(this.Country)
                .StatementDescription(this.StatementDescription)
                .AchDetails(this.AchDetails)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string bankName;
            private string transferType;
            private string accountOwnershipType;
            private string fingerprint;
            private string country;
            private string statementDescription;
            private Models.ACHDetails achDetails;
            private IList<Models.Error> errors;

             /// <summary>
             /// BankName.
             /// </summary>
             /// <param name="bankName"> bankName. </param>
             /// <returns> Builder. </returns>
            public Builder BankName(string bankName)
            {
                this.bankName = bankName;
                return this;
            }

             /// <summary>
             /// TransferType.
             /// </summary>
             /// <param name="transferType"> transferType. </param>
             /// <returns> Builder. </returns>
            public Builder TransferType(string transferType)
            {
                this.transferType = transferType;
                return this;
            }

             /// <summary>
             /// AccountOwnershipType.
             /// </summary>
             /// <param name="accountOwnershipType"> accountOwnershipType. </param>
             /// <returns> Builder. </returns>
            public Builder AccountOwnershipType(string accountOwnershipType)
            {
                this.accountOwnershipType = accountOwnershipType;
                return this;
            }

             /// <summary>
             /// Fingerprint.
             /// </summary>
             /// <param name="fingerprint"> fingerprint. </param>
             /// <returns> Builder. </returns>
            public Builder Fingerprint(string fingerprint)
            {
                this.fingerprint = fingerprint;
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
             /// StatementDescription.
             /// </summary>
             /// <param name="statementDescription"> statementDescription. </param>
             /// <returns> Builder. </returns>
            public Builder StatementDescription(string statementDescription)
            {
                this.statementDescription = statementDescription;
                return this;
            }

             /// <summary>
             /// AchDetails.
             /// </summary>
             /// <param name="achDetails"> achDetails. </param>
             /// <returns> Builder. </returns>
            public Builder AchDetails(Models.ACHDetails achDetails)
            {
                this.achDetails = achDetails;
                return this;
            }

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> BankAccountPaymentDetails. </returns>
            public BankAccountPaymentDetails Build()
            {
                return new BankAccountPaymentDetails(
                    this.bankName,
                    this.transferType,
                    this.accountOwnershipType,
                    this.fingerprint,
                    this.country,
                    this.statementDescription,
                    this.achDetails,
                    this.errors);
            }
        }
    }
}