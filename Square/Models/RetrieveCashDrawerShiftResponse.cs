
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
    public class RetrieveCashDrawerShiftResponse 
    {
        public RetrieveCashDrawerShiftResponse(Models.CashDrawerShift cashDrawerShift = null,
            IList<Models.Error> errors = null)
        {
            CashDrawerShift = cashDrawerShift;
            Errors = errors;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// This model gives the details of a cash drawer shift.
        /// The cash_payment_money, cash_refund_money, cash_paid_in_money,
        /// and cash_paid_out_money fields are all computed by summing their respective
        /// event types.
        /// </summary>
        [JsonProperty("cash_drawer_shift", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CashDrawerShift CashDrawerShift { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.Error> Errors { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"RetrieveCashDrawerShiftResponse : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"CashDrawerShift = {(CashDrawerShift == null ? "null" : CashDrawerShift.ToString())}");
            toStringOutput.Add($"Errors = {(Errors == null ? "null" : $"[{ string.Join(", ", Errors)} ]")}");
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

            return obj is RetrieveCashDrawerShiftResponse other &&
                ((Context == null && other.Context == null) || (Context?.Equals(other.Context) == true)) &&
                ((CashDrawerShift == null && other.CashDrawerShift == null) || (CashDrawerShift?.Equals(other.CashDrawerShift) == true)) &&
                ((Errors == null && other.Errors == null) || (Errors?.Equals(other.Errors) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -2011399353;

            if (Context != null)
            {
                hashCode += Context.GetHashCode();
            }

            if (CashDrawerShift != null)
            {
               hashCode += CashDrawerShift.GetHashCode();
            }

            if (Errors != null)
            {
               hashCode += Errors.GetHashCode();
            }

            return hashCode;
        }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CashDrawerShift(CashDrawerShift)
                .Errors(Errors);
            return builder;
        }

        public class Builder
        {
            private Models.CashDrawerShift cashDrawerShift;
            private IList<Models.Error> errors;



            public Builder CashDrawerShift(Models.CashDrawerShift cashDrawerShift)
            {
                this.cashDrawerShift = cashDrawerShift;
                return this;
            }

            public Builder Errors(IList<Models.Error> errors)
            {
                this.errors = errors;
                return this;
            }

            public RetrieveCashDrawerShiftResponse Build()
            {
                return new RetrieveCashDrawerShiftResponse(cashDrawerShift,
                    errors);
            }
        }
    }
}