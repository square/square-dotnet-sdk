namespace Square.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using APIMatic.Core.Utilities.Converters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Utilities;

    /// <summary>
    /// CardPaymentDetails.
    /// </summary>
    public class CardPaymentDetails
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="CardPaymentDetails"/> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="card">card.</param>
        /// <param name="entryMethod">entry_method.</param>
        /// <param name="cvvStatus">cvv_status.</param>
        /// <param name="avsStatus">avs_status.</param>
        /// <param name="authResultCode">auth_result_code.</param>
        /// <param name="applicationIdentifier">application_identifier.</param>
        /// <param name="applicationName">application_name.</param>
        /// <param name="applicationCryptogram">application_cryptogram.</param>
        /// <param name="verificationMethod">verification_method.</param>
        /// <param name="verificationResults">verification_results.</param>
        /// <param name="statementDescription">statement_description.</param>
        /// <param name="deviceDetails">device_details.</param>
        /// <param name="cardPaymentTimeline">card_payment_timeline.</param>
        /// <param name="refundRequiresCardPresence">refund_requires_card_presence.</param>
        /// <param name="errors">errors.</param>
        public CardPaymentDetails(
            string status = null,
            Models.Card card = null,
            string entryMethod = null,
            string cvvStatus = null,
            string avsStatus = null,
            string authResultCode = null,
            string applicationIdentifier = null,
            string applicationName = null,
            string applicationCryptogram = null,
            string verificationMethod = null,
            string verificationResults = null,
            string statementDescription = null,
            Models.DeviceDetails deviceDetails = null,
            Models.CardPaymentTimeline cardPaymentTimeline = null,
            bool? refundRequiresCardPresence = null,
            IList<Models.Error> errors = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "status", false },
                { "entry_method", false },
                { "cvv_status", false },
                { "avs_status", false },
                { "auth_result_code", false },
                { "application_identifier", false },
                { "application_name", false },
                { "application_cryptogram", false },
                { "verification_method", false },
                { "verification_results", false },
                { "statement_description", false },
                { "refund_requires_card_presence", false },
                { "errors", false }
            };

            if (status != null)
            {
                shouldSerialize["status"] = true;
                this.Status = status;
            }

            this.Card = card;
            if (entryMethod != null)
            {
                shouldSerialize["entry_method"] = true;
                this.EntryMethod = entryMethod;
            }

            if (cvvStatus != null)
            {
                shouldSerialize["cvv_status"] = true;
                this.CvvStatus = cvvStatus;
            }

            if (avsStatus != null)
            {
                shouldSerialize["avs_status"] = true;
                this.AvsStatus = avsStatus;
            }

            if (authResultCode != null)
            {
                shouldSerialize["auth_result_code"] = true;
                this.AuthResultCode = authResultCode;
            }

            if (applicationIdentifier != null)
            {
                shouldSerialize["application_identifier"] = true;
                this.ApplicationIdentifier = applicationIdentifier;
            }

            if (applicationName != null)
            {
                shouldSerialize["application_name"] = true;
                this.ApplicationName = applicationName;
            }

            if (applicationCryptogram != null)
            {
                shouldSerialize["application_cryptogram"] = true;
                this.ApplicationCryptogram = applicationCryptogram;
            }

            if (verificationMethod != null)
            {
                shouldSerialize["verification_method"] = true;
                this.VerificationMethod = verificationMethod;
            }

            if (verificationResults != null)
            {
                shouldSerialize["verification_results"] = true;
                this.VerificationResults = verificationResults;
            }

            if (statementDescription != null)
            {
                shouldSerialize["statement_description"] = true;
                this.StatementDescription = statementDescription;
            }

            this.DeviceDetails = deviceDetails;
            this.CardPaymentTimeline = cardPaymentTimeline;
            if (refundRequiresCardPresence != null)
            {
                shouldSerialize["refund_requires_card_presence"] = true;
                this.RefundRequiresCardPresence = refundRequiresCardPresence;
            }

            if (errors != null)
            {
                shouldSerialize["errors"] = true;
                this.Errors = errors;
            }

        }
        internal CardPaymentDetails(Dictionary<string, bool> shouldSerialize,
            string status = null,
            Models.Card card = null,
            string entryMethod = null,
            string cvvStatus = null,
            string avsStatus = null,
            string authResultCode = null,
            string applicationIdentifier = null,
            string applicationName = null,
            string applicationCryptogram = null,
            string verificationMethod = null,
            string verificationResults = null,
            string statementDescription = null,
            Models.DeviceDetails deviceDetails = null,
            Models.CardPaymentTimeline cardPaymentTimeline = null,
            bool? refundRequiresCardPresence = null,
            IList<Models.Error> errors = null)
        {
            this.shouldSerialize = shouldSerialize;
            Status = status;
            Card = card;
            EntryMethod = entryMethod;
            CvvStatus = cvvStatus;
            AvsStatus = avsStatus;
            AuthResultCode = authResultCode;
            ApplicationIdentifier = applicationIdentifier;
            ApplicationName = applicationName;
            ApplicationCryptogram = applicationCryptogram;
            VerificationMethod = verificationMethod;
            VerificationResults = verificationResults;
            StatementDescription = statementDescription;
            DeviceDetails = deviceDetails;
            CardPaymentTimeline = cardPaymentTimeline;
            RefundRequiresCardPresence = refundRequiresCardPresence;
            Errors = errors;
        }

        /// <summary>
        /// The card payment's current state. The state can be AUTHORIZED, CAPTURED, VOIDED, or
        /// FAILED.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; }

        /// <summary>
        /// Represents the payment details of a card to be used for payments. These
        /// details are determined by the payment token generated by Web Payments SDK.
        /// </summary>
        [JsonProperty("card", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Card Card { get; }

        /// <summary>
        /// The method used to enter the card's details for the payment. The method can be
        /// `KEYED`, `SWIPED`, `EMV`, `ON_FILE`, or `CONTACTLESS`.
        /// </summary>
        [JsonProperty("entry_method")]
        public string EntryMethod { get; }

        /// <summary>
        /// The status code returned from the Card Verification Value (CVV) check. The code can be
        /// `CVV_ACCEPTED`, `CVV_REJECTED`, or `CVV_NOT_CHECKED`.
        /// </summary>
        [JsonProperty("cvv_status")]
        public string CvvStatus { get; }

        /// <summary>
        /// The status code returned from the Address Verification System (AVS) check. The code can be
        /// `AVS_ACCEPTED`, `AVS_REJECTED`, or `AVS_NOT_CHECKED`.
        /// </summary>
        [JsonProperty("avs_status")]
        public string AvsStatus { get; }

        /// <summary>
        /// The status code returned by the card issuer that describes the payment's
        /// authorization status.
        /// </summary>
        [JsonProperty("auth_result_code")]
        public string AuthResultCode { get; }

        /// <summary>
        /// For EMV payments, the application ID identifies the EMV application used for the payment.
        /// </summary>
        [JsonProperty("application_identifier")]
        public string ApplicationIdentifier { get; }

        /// <summary>
        /// For EMV payments, the human-readable name of the EMV application used for the payment.
        /// </summary>
        [JsonProperty("application_name")]
        public string ApplicationName { get; }

        /// <summary>
        /// For EMV payments, the cryptogram generated for the payment.
        /// </summary>
        [JsonProperty("application_cryptogram")]
        public string ApplicationCryptogram { get; }

        /// <summary>
        /// For EMV payments, the method used to verify the cardholder's identity. The method can be
        /// `PIN`, `SIGNATURE`, `PIN_AND_SIGNATURE`, `ON_DEVICE`, or `NONE`.
        /// </summary>
        [JsonProperty("verification_method")]
        public string VerificationMethod { get; }

        /// <summary>
        /// For EMV payments, the results of the cardholder verification. The result can be
        /// `SUCCESS`, `FAILURE`, or `UNKNOWN`.
        /// </summary>
        [JsonProperty("verification_results")]
        public string VerificationResults { get; }

        /// <summary>
        /// The statement description sent to the card networks.
        /// Note: The actual statement description varies and is likely to be truncated and appended with
        /// additional information on a per issuer basis.
        /// </summary>
        [JsonProperty("statement_description")]
        public string StatementDescription { get; }

        /// <summary>
        /// Details about the device that took the payment.
        /// </summary>
        [JsonProperty("device_details", NullValueHandling = NullValueHandling.Ignore)]
        public Models.DeviceDetails DeviceDetails { get; }

        /// <summary>
        /// The timeline for card payments.
        /// </summary>
        [JsonProperty("card_payment_timeline", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CardPaymentTimeline CardPaymentTimeline { get; }

        /// <summary>
        /// Whether the card must be physically present for the payment to
        /// be refunded.  If set to `true`, the card must be present.
        /// </summary>
        [JsonProperty("refund_requires_card_presence")]
        public bool? RefundRequiresCardPresence { get; }

        /// <summary>
        /// Information about errors encountered during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CardPaymentDetails : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatus()
        {
            return this.shouldSerialize["status"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeEntryMethod()
        {
            return this.shouldSerialize["entry_method"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCvvStatus()
        {
            return this.shouldSerialize["cvv_status"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAvsStatus()
        {
            return this.shouldSerialize["avs_status"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAuthResultCode()
        {
            return this.shouldSerialize["auth_result_code"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApplicationIdentifier()
        {
            return this.shouldSerialize["application_identifier"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApplicationName()
        {
            return this.shouldSerialize["application_name"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeApplicationCryptogram()
        {
            return this.shouldSerialize["application_cryptogram"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVerificationMethod()
        {
            return this.shouldSerialize["verification_method"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVerificationResults()
        {
            return this.shouldSerialize["verification_results"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeStatementDescription()
        {
            return this.shouldSerialize["statement_description"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeRefundRequiresCardPresence()
        {
            return this.shouldSerialize["refund_requires_card_presence"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeErrors()
        {
            return this.shouldSerialize["errors"];
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
            return obj is CardPaymentDetails other &&                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Card == null && other.Card == null) || (this.Card?.Equals(other.Card) == true)) &&
                ((this.EntryMethod == null && other.EntryMethod == null) || (this.EntryMethod?.Equals(other.EntryMethod) == true)) &&
                ((this.CvvStatus == null && other.CvvStatus == null) || (this.CvvStatus?.Equals(other.CvvStatus) == true)) &&
                ((this.AvsStatus == null && other.AvsStatus == null) || (this.AvsStatus?.Equals(other.AvsStatus) == true)) &&
                ((this.AuthResultCode == null && other.AuthResultCode == null) || (this.AuthResultCode?.Equals(other.AuthResultCode) == true)) &&
                ((this.ApplicationIdentifier == null && other.ApplicationIdentifier == null) || (this.ApplicationIdentifier?.Equals(other.ApplicationIdentifier) == true)) &&
                ((this.ApplicationName == null && other.ApplicationName == null) || (this.ApplicationName?.Equals(other.ApplicationName) == true)) &&
                ((this.ApplicationCryptogram == null && other.ApplicationCryptogram == null) || (this.ApplicationCryptogram?.Equals(other.ApplicationCryptogram) == true)) &&
                ((this.VerificationMethod == null && other.VerificationMethod == null) || (this.VerificationMethod?.Equals(other.VerificationMethod) == true)) &&
                ((this.VerificationResults == null && other.VerificationResults == null) || (this.VerificationResults?.Equals(other.VerificationResults) == true)) &&
                ((this.StatementDescription == null && other.StatementDescription == null) || (this.StatementDescription?.Equals(other.StatementDescription) == true)) &&
                ((this.DeviceDetails == null && other.DeviceDetails == null) || (this.DeviceDetails?.Equals(other.DeviceDetails) == true)) &&
                ((this.CardPaymentTimeline == null && other.CardPaymentTimeline == null) || (this.CardPaymentTimeline?.Equals(other.CardPaymentTimeline) == true)) &&
                ((this.RefundRequiresCardPresence == null && other.RefundRequiresCardPresence == null) || (this.RefundRequiresCardPresence?.Equals(other.RefundRequiresCardPresence) == true)) &&
                ((this.Errors == null && other.Errors == null) || (this.Errors?.Equals(other.Errors) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 1465447186;
            hashCode = HashCode.Combine(this.Status, this.Card, this.EntryMethod, this.CvvStatus, this.AvsStatus, this.AuthResultCode, this.ApplicationIdentifier);

            hashCode = HashCode.Combine(hashCode, this.ApplicationName, this.ApplicationCryptogram, this.VerificationMethod, this.VerificationResults, this.StatementDescription, this.DeviceDetails, this.CardPaymentTimeline);

            hashCode = HashCode.Combine(hashCode, this.RefundRequiresCardPresence, this.Errors);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status)}");
            toStringOutput.Add($"this.Card = {(this.Card == null ? "null" : this.Card.ToString())}");
            toStringOutput.Add($"this.EntryMethod = {(this.EntryMethod == null ? "null" : this.EntryMethod)}");
            toStringOutput.Add($"this.CvvStatus = {(this.CvvStatus == null ? "null" : this.CvvStatus)}");
            toStringOutput.Add($"this.AvsStatus = {(this.AvsStatus == null ? "null" : this.AvsStatus)}");
            toStringOutput.Add($"this.AuthResultCode = {(this.AuthResultCode == null ? "null" : this.AuthResultCode)}");
            toStringOutput.Add($"this.ApplicationIdentifier = {(this.ApplicationIdentifier == null ? "null" : this.ApplicationIdentifier)}");
            toStringOutput.Add($"this.ApplicationName = {(this.ApplicationName == null ? "null" : this.ApplicationName)}");
            toStringOutput.Add($"this.ApplicationCryptogram = {(this.ApplicationCryptogram == null ? "null" : this.ApplicationCryptogram)}");
            toStringOutput.Add($"this.VerificationMethod = {(this.VerificationMethod == null ? "null" : this.VerificationMethod)}");
            toStringOutput.Add($"this.VerificationResults = {(this.VerificationResults == null ? "null" : this.VerificationResults)}");
            toStringOutput.Add($"this.StatementDescription = {(this.StatementDescription == null ? "null" : this.StatementDescription)}");
            toStringOutput.Add($"this.DeviceDetails = {(this.DeviceDetails == null ? "null" : this.DeviceDetails.ToString())}");
            toStringOutput.Add($"this.CardPaymentTimeline = {(this.CardPaymentTimeline == null ? "null" : this.CardPaymentTimeline.ToString())}");
            toStringOutput.Add($"this.RefundRequiresCardPresence = {(this.RefundRequiresCardPresence == null ? "null" : this.RefundRequiresCardPresence.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Status(this.Status)
                .Card(this.Card)
                .EntryMethod(this.EntryMethod)
                .CvvStatus(this.CvvStatus)
                .AvsStatus(this.AvsStatus)
                .AuthResultCode(this.AuthResultCode)
                .ApplicationIdentifier(this.ApplicationIdentifier)
                .ApplicationName(this.ApplicationName)
                .ApplicationCryptogram(this.ApplicationCryptogram)
                .VerificationMethod(this.VerificationMethod)
                .VerificationResults(this.VerificationResults)
                .StatementDescription(this.StatementDescription)
                .DeviceDetails(this.DeviceDetails)
                .CardPaymentTimeline(this.CardPaymentTimeline)
                .RefundRequiresCardPresence(this.RefundRequiresCardPresence)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "status", false },
                { "entry_method", false },
                { "cvv_status", false },
                { "avs_status", false },
                { "auth_result_code", false },
                { "application_identifier", false },
                { "application_name", false },
                { "application_cryptogram", false },
                { "verification_method", false },
                { "verification_results", false },
                { "statement_description", false },
                { "refund_requires_card_presence", false },
                { "errors", false },
            };

            private string status;
            private Models.Card card;
            private string entryMethod;
            private string cvvStatus;
            private string avsStatus;
            private string authResultCode;
            private string applicationIdentifier;
            private string applicationName;
            private string applicationCryptogram;
            private string verificationMethod;
            private string verificationResults;
            private string statementDescription;
            private Models.DeviceDetails deviceDetails;
            private Models.CardPaymentTimeline cardPaymentTimeline;
            private bool? refundRequiresCardPresence;
            private IList<Models.Error> errors;

             /// <summary>
             /// Status.
             /// </summary>
             /// <param name="status"> status. </param>
             /// <returns> Builder. </returns>
            public Builder Status(string status)
            {
                shouldSerialize["status"] = true;
                this.status = status;
                return this;
            }

             /// <summary>
             /// Card.
             /// </summary>
             /// <param name="card"> card. </param>
             /// <returns> Builder. </returns>
            public Builder Card(Models.Card card)
            {
                this.card = card;
                return this;
            }

             /// <summary>
             /// EntryMethod.
             /// </summary>
             /// <param name="entryMethod"> entryMethod. </param>
             /// <returns> Builder. </returns>
            public Builder EntryMethod(string entryMethod)
            {
                shouldSerialize["entry_method"] = true;
                this.entryMethod = entryMethod;
                return this;
            }

             /// <summary>
             /// CvvStatus.
             /// </summary>
             /// <param name="cvvStatus"> cvvStatus. </param>
             /// <returns> Builder. </returns>
            public Builder CvvStatus(string cvvStatus)
            {
                shouldSerialize["cvv_status"] = true;
                this.cvvStatus = cvvStatus;
                return this;
            }

             /// <summary>
             /// AvsStatus.
             /// </summary>
             /// <param name="avsStatus"> avsStatus. </param>
             /// <returns> Builder. </returns>
            public Builder AvsStatus(string avsStatus)
            {
                shouldSerialize["avs_status"] = true;
                this.avsStatus = avsStatus;
                return this;
            }

             /// <summary>
             /// AuthResultCode.
             /// </summary>
             /// <param name="authResultCode"> authResultCode. </param>
             /// <returns> Builder. </returns>
            public Builder AuthResultCode(string authResultCode)
            {
                shouldSerialize["auth_result_code"] = true;
                this.authResultCode = authResultCode;
                return this;
            }

             /// <summary>
             /// ApplicationIdentifier.
             /// </summary>
             /// <param name="applicationIdentifier"> applicationIdentifier. </param>
             /// <returns> Builder. </returns>
            public Builder ApplicationIdentifier(string applicationIdentifier)
            {
                shouldSerialize["application_identifier"] = true;
                this.applicationIdentifier = applicationIdentifier;
                return this;
            }

             /// <summary>
             /// ApplicationName.
             /// </summary>
             /// <param name="applicationName"> applicationName. </param>
             /// <returns> Builder. </returns>
            public Builder ApplicationName(string applicationName)
            {
                shouldSerialize["application_name"] = true;
                this.applicationName = applicationName;
                return this;
            }

             /// <summary>
             /// ApplicationCryptogram.
             /// </summary>
             /// <param name="applicationCryptogram"> applicationCryptogram. </param>
             /// <returns> Builder. </returns>
            public Builder ApplicationCryptogram(string applicationCryptogram)
            {
                shouldSerialize["application_cryptogram"] = true;
                this.applicationCryptogram = applicationCryptogram;
                return this;
            }

             /// <summary>
             /// VerificationMethod.
             /// </summary>
             /// <param name="verificationMethod"> verificationMethod. </param>
             /// <returns> Builder. </returns>
            public Builder VerificationMethod(string verificationMethod)
            {
                shouldSerialize["verification_method"] = true;
                this.verificationMethod = verificationMethod;
                return this;
            }

             /// <summary>
             /// VerificationResults.
             /// </summary>
             /// <param name="verificationResults"> verificationResults. </param>
             /// <returns> Builder. </returns>
            public Builder VerificationResults(string verificationResults)
            {
                shouldSerialize["verification_results"] = true;
                this.verificationResults = verificationResults;
                return this;
            }

             /// <summary>
             /// StatementDescription.
             /// </summary>
             /// <param name="statementDescription"> statementDescription. </param>
             /// <returns> Builder. </returns>
            public Builder StatementDescription(string statementDescription)
            {
                shouldSerialize["statement_description"] = true;
                this.statementDescription = statementDescription;
                return this;
            }

             /// <summary>
             /// DeviceDetails.
             /// </summary>
             /// <param name="deviceDetails"> deviceDetails. </param>
             /// <returns> Builder. </returns>
            public Builder DeviceDetails(Models.DeviceDetails deviceDetails)
            {
                this.deviceDetails = deviceDetails;
                return this;
            }

             /// <summary>
             /// CardPaymentTimeline.
             /// </summary>
             /// <param name="cardPaymentTimeline"> cardPaymentTimeline. </param>
             /// <returns> Builder. </returns>
            public Builder CardPaymentTimeline(Models.CardPaymentTimeline cardPaymentTimeline)
            {
                this.cardPaymentTimeline = cardPaymentTimeline;
                return this;
            }

             /// <summary>
             /// RefundRequiresCardPresence.
             /// </summary>
             /// <param name="refundRequiresCardPresence"> refundRequiresCardPresence. </param>
             /// <returns> Builder. </returns>
            public Builder RefundRequiresCardPresence(bool? refundRequiresCardPresence)
            {
                shouldSerialize["refund_requires_card_presence"] = true;
                this.refundRequiresCardPresence = refundRequiresCardPresence;
                return this;
            }

             /// <summary>
             /// Errors.
             /// </summary>
             /// <param name="errors"> errors. </param>
             /// <returns> Builder. </returns>
            public Builder Errors(IList<Models.Error> errors)
            {
                shouldSerialize["errors"] = true;
                this.errors = errors;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStatus()
            {
                this.shouldSerialize["status"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetEntryMethod()
            {
                this.shouldSerialize["entry_method"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCvvStatus()
            {
                this.shouldSerialize["cvv_status"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAvsStatus()
            {
                this.shouldSerialize["avs_status"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAuthResultCode()
            {
                this.shouldSerialize["auth_result_code"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetApplicationIdentifier()
            {
                this.shouldSerialize["application_identifier"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetApplicationName()
            {
                this.shouldSerialize["application_name"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetApplicationCryptogram()
            {
                this.shouldSerialize["application_cryptogram"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetVerificationMethod()
            {
                this.shouldSerialize["verification_method"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetVerificationResults()
            {
                this.shouldSerialize["verification_results"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetStatementDescription()
            {
                this.shouldSerialize["statement_description"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetRefundRequiresCardPresence()
            {
                this.shouldSerialize["refund_requires_card_presence"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetErrors()
            {
                this.shouldSerialize["errors"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CardPaymentDetails. </returns>
            public CardPaymentDetails Build()
            {
                return new CardPaymentDetails(shouldSerialize,
                    this.status,
                    this.card,
                    this.entryMethod,
                    this.cvvStatus,
                    this.avsStatus,
                    this.authResultCode,
                    this.applicationIdentifier,
                    this.applicationName,
                    this.applicationCryptogram,
                    this.verificationMethod,
                    this.verificationResults,
                    this.statementDescription,
                    this.deviceDetails,
                    this.cardPaymentTimeline,
                    this.refundRequiresCardPresence,
                    this.errors);
            }
        }
    }
}