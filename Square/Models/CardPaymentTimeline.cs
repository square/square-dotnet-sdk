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
    /// CardPaymentTimeline.
    /// </summary>
    public class CardPaymentTimeline
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardPaymentTimeline"/> class.
        /// </summary>
        /// <param name="authorizedAt">authorized_at.</param>
        /// <param name="capturedAt">captured_at.</param>
        /// <param name="voidedAt">voided_at.</param>
        public CardPaymentTimeline(
            string authorizedAt = null,
            string capturedAt = null,
            string voidedAt = null)
        {
            this.AuthorizedAt = authorizedAt;
            this.CapturedAt = capturedAt;
            this.VoidedAt = voidedAt;
        }

        /// <summary>
        /// The timestamp when the payment was authorized, in RFC 3339 format.
        /// </summary>
        [JsonProperty("authorized_at", NullValueHandling = NullValueHandling.Ignore)]
        public string AuthorizedAt { get; }

        /// <summary>
        /// The timestamp when the payment was captured, in RFC 3339 format.
        /// </summary>
        [JsonProperty("captured_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CapturedAt { get; }

        /// <summary>
        /// The timestamp when the payment was voided, in RFC 3339 format.
        /// </summary>
        [JsonProperty("voided_at", NullValueHandling = NullValueHandling.Ignore)]
        public string VoidedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CardPaymentTimeline : ({string.Join(", ", toStringOutput)})";
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

            return obj is CardPaymentTimeline other &&
                ((this.AuthorizedAt == null && other.AuthorizedAt == null) || (this.AuthorizedAt?.Equals(other.AuthorizedAt) == true)) &&
                ((this.CapturedAt == null && other.CapturedAt == null) || (this.CapturedAt?.Equals(other.CapturedAt) == true)) &&
                ((this.VoidedAt == null && other.VoidedAt == null) || (this.VoidedAt?.Equals(other.VoidedAt) == true));
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1762221342;

            if (this.AuthorizedAt != null)
            {
               hashCode += this.AuthorizedAt.GetHashCode();
            }

            if (this.CapturedAt != null)
            {
               hashCode += this.CapturedAt.GetHashCode();
            }

            if (this.VoidedAt != null)
            {
               hashCode += this.VoidedAt.GetHashCode();
            }

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AuthorizedAt = {(this.AuthorizedAt == null ? "null" : this.AuthorizedAt == string.Empty ? "" : this.AuthorizedAt)}");
            toStringOutput.Add($"this.CapturedAt = {(this.CapturedAt == null ? "null" : this.CapturedAt == string.Empty ? "" : this.CapturedAt)}");
            toStringOutput.Add($"this.VoidedAt = {(this.VoidedAt == null ? "null" : this.VoidedAt == string.Empty ? "" : this.VoidedAt)}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AuthorizedAt(this.AuthorizedAt)
                .CapturedAt(this.CapturedAt)
                .VoidedAt(this.VoidedAt);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private string authorizedAt;
            private string capturedAt;
            private string voidedAt;

             /// <summary>
             /// AuthorizedAt.
             /// </summary>
             /// <param name="authorizedAt"> authorizedAt. </param>
             /// <returns> Builder. </returns>
            public Builder AuthorizedAt(string authorizedAt)
            {
                this.authorizedAt = authorizedAt;
                return this;
            }

             /// <summary>
             /// CapturedAt.
             /// </summary>
             /// <param name="capturedAt"> capturedAt. </param>
             /// <returns> Builder. </returns>
            public Builder CapturedAt(string capturedAt)
            {
                this.capturedAt = capturedAt;
                return this;
            }

             /// <summary>
             /// VoidedAt.
             /// </summary>
             /// <param name="voidedAt"> voidedAt. </param>
             /// <returns> Builder. </returns>
            public Builder VoidedAt(string voidedAt)
            {
                this.voidedAt = voidedAt;
                return this;
            }

            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CardPaymentTimeline. </returns>
            public CardPaymentTimeline Build()
            {
                return new CardPaymentTimeline(
                    this.authorizedAt,
                    this.capturedAt,
                    this.voidedAt);
            }
        }
    }
}