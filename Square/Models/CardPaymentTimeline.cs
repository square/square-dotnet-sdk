
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
    public class CardPaymentTimeline 
    {
        public CardPaymentTimeline(string authorizedAt = null,
            string capturedAt = null,
            string voidedAt = null)
        {
            AuthorizedAt = authorizedAt;
            CapturedAt = capturedAt;
            VoidedAt = voidedAt;
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

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CardPaymentTimeline : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"AuthorizedAt = {(AuthorizedAt == null ? "null" : AuthorizedAt == string.Empty ? "" : AuthorizedAt)}");
            toStringOutput.Add($"CapturedAt = {(CapturedAt == null ? "null" : CapturedAt == string.Empty ? "" : CapturedAt)}");
            toStringOutput.Add($"VoidedAt = {(VoidedAt == null ? "null" : VoidedAt == string.Empty ? "" : VoidedAt)}");
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

            return obj is CardPaymentTimeline other &&
                ((AuthorizedAt == null && other.AuthorizedAt == null) || (AuthorizedAt?.Equals(other.AuthorizedAt) == true)) &&
                ((CapturedAt == null && other.CapturedAt == null) || (CapturedAt?.Equals(other.CapturedAt) == true)) &&
                ((VoidedAt == null && other.VoidedAt == null) || (VoidedAt?.Equals(other.VoidedAt) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -1762221342;

            if (AuthorizedAt != null)
            {
               hashCode += AuthorizedAt.GetHashCode();
            }

            if (CapturedAt != null)
            {
               hashCode += CapturedAt.GetHashCode();
            }

            if (VoidedAt != null)
            {
               hashCode += VoidedAt.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .AuthorizedAt(AuthorizedAt)
                .CapturedAt(CapturedAt)
                .VoidedAt(VoidedAt);
            return builder;
        }

        public class Builder
        {
            private string authorizedAt;
            private string capturedAt;
            private string voidedAt;



            public Builder AuthorizedAt(string authorizedAt)
            {
                this.authorizedAt = authorizedAt;
                return this;
            }

            public Builder CapturedAt(string capturedAt)
            {
                this.capturedAt = capturedAt;
                return this;
            }

            public Builder VoidedAt(string voidedAt)
            {
                this.voidedAt = voidedAt;
                return this;
            }

            public CardPaymentTimeline Build()
            {
                return new CardPaymentTimeline(authorizedAt,
                    capturedAt,
                    voidedAt);
            }
        }
    }
}