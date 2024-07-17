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
    /// ReceiptOptions.
    /// </summary>
    public class ReceiptOptions
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptOptions"/> class.
        /// </summary>
        /// <param name="paymentId">payment_id.</param>
        /// <param name="printOnly">print_only.</param>
        /// <param name="isDuplicate">is_duplicate.</param>
        public ReceiptOptions(
            string paymentId,
            bool? printOnly = null,
            bool? isDuplicate = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "print_only", false },
                { "is_duplicate", false }
            };

            this.PaymentId = paymentId;
            if (printOnly != null)
            {
                shouldSerialize["print_only"] = true;
                this.PrintOnly = printOnly;
            }

            if (isDuplicate != null)
            {
                shouldSerialize["is_duplicate"] = true;
                this.IsDuplicate = isDuplicate;
            }

        }
        internal ReceiptOptions(Dictionary<string, bool> shouldSerialize,
            string paymentId,
            bool? printOnly = null,
            bool? isDuplicate = null)
        {
            this.shouldSerialize = shouldSerialize;
            PaymentId = paymentId;
            PrintOnly = printOnly;
            IsDuplicate = isDuplicate;
        }

        /// <summary>
        /// The reference to the Square payment ID for the receipt.
        /// </summary>
        [JsonProperty("payment_id")]
        public string PaymentId { get; }

        /// <summary>
        /// Instructs the device to print the receipt without displaying the receipt selection screen.
        /// Requires `printer_enabled` set to true.
        /// Defaults to false.
        /// </summary>
        [JsonProperty("print_only")]
        public bool? PrintOnly { get; }

        /// <summary>
        /// Identify the receipt as a reprint rather than an original receipt.
        /// Defaults to false.
        /// </summary>
        [JsonProperty("is_duplicate")]
        public bool? IsDuplicate { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"ReceiptOptions : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializePrintOnly()
        {
            return this.shouldSerialize["print_only"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeIsDuplicate()
        {
            return this.shouldSerialize["is_duplicate"];
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
            return obj is ReceiptOptions other &&                ((this.PaymentId == null && other.PaymentId == null) || (this.PaymentId?.Equals(other.PaymentId) == true)) &&
                ((this.PrintOnly == null && other.PrintOnly == null) || (this.PrintOnly?.Equals(other.PrintOnly) == true)) &&
                ((this.IsDuplicate == null && other.IsDuplicate == null) || (this.IsDuplicate?.Equals(other.IsDuplicate) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = 939247501;
            hashCode = HashCode.Combine(this.PaymentId, this.PrintOnly, this.IsDuplicate);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.PaymentId = {(this.PaymentId == null ? "null" : this.PaymentId)}");
            toStringOutput.Add($"this.PrintOnly = {(this.PrintOnly == null ? "null" : this.PrintOnly.ToString())}");
            toStringOutput.Add($"this.IsDuplicate = {(this.IsDuplicate == null ? "null" : this.IsDuplicate.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder(
                this.PaymentId)
                .PrintOnly(this.PrintOnly)
                .IsDuplicate(this.IsDuplicate);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "print_only", false },
                { "is_duplicate", false },
            };

            private string paymentId;
            private bool? printOnly;
            private bool? isDuplicate;

            /// <summary>
            /// Initialize Builder for ReceiptOptions.
            /// </summary>
            /// <param name="paymentId"> paymentId. </param>
            public Builder(
                string paymentId)
            {
                this.paymentId = paymentId;
            }

             /// <summary>
             /// PaymentId.
             /// </summary>
             /// <param name="paymentId"> paymentId. </param>
             /// <returns> Builder. </returns>
            public Builder PaymentId(string paymentId)
            {
                this.paymentId = paymentId;
                return this;
            }

             /// <summary>
             /// PrintOnly.
             /// </summary>
             /// <param name="printOnly"> printOnly. </param>
             /// <returns> Builder. </returns>
            public Builder PrintOnly(bool? printOnly)
            {
                shouldSerialize["print_only"] = true;
                this.printOnly = printOnly;
                return this;
            }

             /// <summary>
             /// IsDuplicate.
             /// </summary>
             /// <param name="isDuplicate"> isDuplicate. </param>
             /// <returns> Builder. </returns>
            public Builder IsDuplicate(bool? isDuplicate)
            {
                shouldSerialize["is_duplicate"] = true;
                this.isDuplicate = isDuplicate;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetPrintOnly()
            {
                this.shouldSerialize["print_only"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetIsDuplicate()
            {
                this.shouldSerialize["is_duplicate"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> ReceiptOptions. </returns>
            public ReceiptOptions Build()
            {
                return new ReceiptOptions(shouldSerialize,
                    this.paymentId,
                    this.printOnly,
                    this.isDuplicate);
            }
        }
    }
}