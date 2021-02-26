
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Square.Http.Client;
using Square;
using Square.Utilities;

namespace Square.Models
{
    public class CreateLoyaltyAccountResponse 
    {
        public CreateLoyaltyAccountResponse(IList<Models.Error> errors = null,
            Models.LoyaltyAccount loyaltyAccount = null)
        {
            Errors = errors;
            LoyaltyAccount = loyaltyAccount;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        /// <summary>
        /// Describes a loyalty account. For more information, see 
        /// [Loyalty Overview](https://developer.squareup.com/docs/loyalty/overview).
        /// </summary>
        [JsonProperty("loyalty_account", NullValueHandling = NullValueHandling.Ignore)]
        public Models.LoyaltyAccount LoyaltyAccount { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CreateLoyaltyAccountResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
            toStringOutput.Add($"LoyaltyAccount = {(LoyaltyAccount == null ? "null" : LoyaltyAccount.ToString())}");
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

            return obj is CreateLoyaltyAccountResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true)) &&
                ((LoyaltyAccount == null && other.LoyaltyAccount == null) || (LoyaltyAccount?.Equals(other.LoyaltyAccount) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -963021991;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            if (LoyaltyAccount != null)
            {
               hashCode += LoyaltyAccount.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Errors(Errors)
                .LoyaltyAccount(LoyaltyAccount);
            return builder;
        }

        public class Builder
        {
            private IList<Models.Error> errors;
            private Models.LoyaltyAccount loyaltyAccount;



            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public Builder LoyaltyAccount(Models.LoyaltyAccount loyaltyAccount)
            {
                this.loyaltyAccount = loyaltyAccount;
                return this;
            }

            public CreateLoyaltyAccountResponse Build()
            {
                return new CreateLoyaltyAccountResponse(errors,
                    loyaltyAccount);
            }
        }
    }
}