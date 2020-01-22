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
        [JsonProperty("cash_drawer_shift")]
        public Models.CashDrawerShift CashDrawerShift { get; }

        /// <summary>
        /// Any errors that occurred during the request.
        /// </summary>
        [JsonProperty("errors")]
        public IList<Models.Error> Errors { get; }

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
            private IList<Models.Error> errors = new List<Models.Error>();

            public Builder() { }
            public Builder CashDrawerShift(Models.CashDrawerShift value)
            {
                cashDrawerShift = value;
                return this;
            }

            public Builder Errors(IList<Models.Error> value)
            {
                errors = value;
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