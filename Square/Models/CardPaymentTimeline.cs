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
    /// CardPaymentTimeline.
    /// </summary>
    public class CardPaymentTimeline
    {
        private readonly Dictionary<string, bool> shouldSerialize;
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
            shouldSerialize = new Dictionary<string, bool>
            {
                { "authorized_at", false },
                { "captured_at", false },
                { "voided_at", false }
            };

            if (authorizedAt != null)
            {
                shouldSerialize["authorized_at"] = true;
                this.AuthorizedAt = authorizedAt;
            }

            if (capturedAt != null)
            {
                shouldSerialize["captured_at"] = true;
                this.CapturedAt = capturedAt;
            }

            if (voidedAt != null)
            {
                shouldSerialize["voided_at"] = true;
                this.VoidedAt = voidedAt;
            }

        }
        internal CardPaymentTimeline(Dictionary<string, bool> shouldSerialize,
            string authorizedAt = null,
            string capturedAt = null,
            string voidedAt = null)
        {
            this.shouldSerialize = shouldSerialize;
            AuthorizedAt = authorizedAt;
            CapturedAt = capturedAt;
            VoidedAt = voidedAt;
        }

        /// <summary>
        /// The timestamp when the payment was authorized, in RFC 3339 format.
        /// </summary>
        [JsonProperty("authorized_at")]
        public string AuthorizedAt { get; }

        /// <summary>
        /// The timestamp when the payment was captured, in RFC 3339 format.
        /// </summary>
        [JsonProperty("captured_at")]
        public string CapturedAt { get; }

        /// <summary>
        /// The timestamp when the payment was voided, in RFC 3339 format.
        /// </summary>
        [JsonProperty("voided_at")]
        public string VoidedAt { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CardPaymentTimeline : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeAuthorizedAt()
        {
            return this.shouldSerialize["authorized_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeCapturedAt()
        {
            return this.shouldSerialize["captured_at"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeVoidedAt()
        {
            return this.shouldSerialize["voided_at"];
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
            return obj is CardPaymentTimeline other &&                ((this.AuthorizedAt == null && other.AuthorizedAt == null) || (this.AuthorizedAt?.Equals(other.AuthorizedAt) == true)) &&
                ((this.CapturedAt == null && other.CapturedAt == null) || (this.CapturedAt?.Equals(other.CapturedAt) == true)) &&
                ((this.VoidedAt == null && other.VoidedAt == null) || (this.VoidedAt?.Equals(other.VoidedAt) == true));
        }
        
        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hashCode = -1762221342;
            hashCode = HashCode.Combine(this.AuthorizedAt, this.CapturedAt, this.VoidedAt);

            return hashCode;
        }
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.AuthorizedAt = {(this.AuthorizedAt == null ? "null" : this.AuthorizedAt)}");
            toStringOutput.Add($"this.CapturedAt = {(this.CapturedAt == null ? "null" : this.CapturedAt)}");
            toStringOutput.Add($"this.VoidedAt = {(this.VoidedAt == null ? "null" : this.VoidedAt)}");
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
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "authorized_at", false },
                { "captured_at", false },
                { "voided_at", false },
            };

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
                shouldSerialize["authorized_at"] = true;
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
                shouldSerialize["captured_at"] = true;
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
                shouldSerialize["voided_at"] = true;
                this.voidedAt = voidedAt;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetAuthorizedAt()
            {
                this.shouldSerialize["authorized_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetCapturedAt()
            {
                this.shouldSerialize["captured_at"] = false;
            }

            /// <summary>
            /// Marks the field to not be serailized.
            /// </summary>
            public void UnsetVoidedAt()
            {
                this.shouldSerialize["voided_at"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> CardPaymentTimeline. </returns>
            public CardPaymentTimeline Build()
            {
                return new CardPaymentTimeline(shouldSerialize,
                    this.authorizedAt,
                    this.capturedAt,
                    this.voidedAt);
            }
        }
    }
}