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
using Square.Http.Client;
using Square.Utilities;

namespace Square.Models
{
    /// <summary>
    /// RetrieveCashDrawerShiftResponse.
    /// </summary>
    public class RetrieveCashDrawerShiftResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RetrieveCashDrawerShiftResponse"/> class.
        /// </summary>
        /// <param name="cashDrawerShift">cash_drawer_shift.</param>
        /// <param name="errors">errors.</param>
        public RetrieveCashDrawerShiftResponse(
            Models.CashDrawerShift cashDrawerShift = null,
            IList<Models.Error> errors = null)
        {
            this.CashDrawerShift = cashDrawerShift;
            this.Errors = errors;
        }

        /// <summary>
        /// Gets http context.
        /// </summary>
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

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"RetrieveCashDrawerShiftResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is RetrieveCashDrawerShiftResponse other && 
                ((this.Context == null && other.Context == null) 
                 || this.Context?.Equals(other.Context) == true) && 
                (this.CashDrawerShift == null && other.CashDrawerShift == null ||
                 this.CashDrawerShift?.Equals(other.CashDrawerShift) == true) &&
                (this.Errors == null && other.Errors == null ||
                 this.Errors?.Equals(other.Errors) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = -2011399353;

            if (this.Context != null)
            {
                hashCode += this.Context.GetHashCode();
            }
            hashCode = HashCode.Combine(hashCode, this.CashDrawerShift, this.Errors);

            return hashCode;
        }

        internal RetrieveCashDrawerShiftResponse ContextSetter(HttpContext context)
        {
            this.Context = context;
            return this;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.CashDrawerShift = {(this.CashDrawerShift == null ? "null" : this.CashDrawerShift.ToString())}");
            toStringOutput.Add($"this.Errors = {(this.Errors == null ? "null" : $"[{string.Join(", ", this.Errors)} ]")}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .CashDrawerShift(this.CashDrawerShift)
                .Errors(this.Errors);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Models.CashDrawerShift cashDrawerShift;
            private IList<Models.Error> errors;

             /// <summary>
             /// CashDrawerShift.
             /// </summary>
             /// <param name="cashDrawerShift"> cashDrawerShift. </param>
             /// <returns> Builder. </returns>
            public Builder CashDrawerShift(Models.CashDrawerShift cashDrawerShift)
            {
                this.cashDrawerShift = cashDrawerShift;
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
            /// <returns> RetrieveCashDrawerShiftResponse. </returns>
            public RetrieveCashDrawerShiftResponse Build()
            {
                return new RetrieveCashDrawerShiftResponse(
                    this.cashDrawerShift,
                    this.errors);
            }
        }
    }
}