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
    public class OrderReturn 
    {
        public OrderReturn(string uid = null,
            string sourceOrderId = null,
            IList<Models.OrderReturnLineItem> returnLineItems = null,
            IList<Models.OrderReturnServiceCharge> returnServiceCharges = null,
            IList<Models.OrderReturnTax> returnTaxes = null,
            IList<Models.OrderReturnDiscount> returnDiscounts = null,
            Models.OrderRoundingAdjustment roundingAdjustment = null,
            Models.OrderMoneyAmounts returnAmounts = null)
        {
            Uid = uid;
            SourceOrderId = sourceOrderId;
            ReturnLineItems = returnLineItems;
            ReturnServiceCharges = returnServiceCharges;
            ReturnTaxes = returnTaxes;
            ReturnDiscounts = returnDiscounts;
            RoundingAdjustment = roundingAdjustment;
            ReturnAmounts = returnAmounts;
        }

        /// <summary>
        /// Unique ID that identifies the return only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// Order which contains the original sale of these returned line items. This will be unset
        /// for unlinked returns.
        /// </summary>
        [JsonProperty("source_order_id")]
        public string SourceOrderId { get; }

        /// <summary>
        /// Collection of line items which are being returned.
        /// </summary>
        [JsonProperty("return_line_items")]
        public IList<Models.OrderReturnLineItem> ReturnLineItems { get; }

        /// <summary>
        /// Collection of service charges which are being returned.
        /// </summary>
        [JsonProperty("return_service_charges")]
        public IList<Models.OrderReturnServiceCharge> ReturnServiceCharges { get; }

        /// <summary>
        /// Collection of references to taxes being returned for an order, including the total
        /// applied tax amount to be returned. The taxes must reference a top-level tax ID from the source
        /// order.
        /// </summary>
        [JsonProperty("return_taxes")]
        public IList<Models.OrderReturnTax> ReturnTaxes { get; }

        /// <summary>
        /// Collection of references to discounts being returned for an order, including the total
        /// applied discount amount to be returned. The discounts must reference a top-level discount ID
        /// from the source order.
        /// </summary>
        [JsonProperty("return_discounts")]
        public IList<Models.OrderReturnDiscount> ReturnDiscounts { get; }

        /// <summary>
        /// A rounding adjustment of the money being returned. Commonly used to apply Cash Rounding
        /// when the minimum unit of account is smaller than the lowest physical denomination of currency.
        /// </summary>
        [JsonProperty("rounding_adjustment")]
        public Models.OrderRoundingAdjustment RoundingAdjustment { get; }

        /// <summary>
        /// A collection of various money amounts.
        /// </summary>
        [JsonProperty("return_amounts")]
        public Models.OrderMoneyAmounts ReturnAmounts { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(Uid)
                .SourceOrderId(SourceOrderId)
                .ReturnLineItems(ReturnLineItems)
                .ReturnServiceCharges(ReturnServiceCharges)
                .ReturnTaxes(ReturnTaxes)
                .ReturnDiscounts(ReturnDiscounts)
                .RoundingAdjustment(RoundingAdjustment)
                .ReturnAmounts(ReturnAmounts);
            return builder;
        }

        public class Builder
        {
            private string uid;
            private string sourceOrderId;
            private IList<Models.OrderReturnLineItem> returnLineItems = new List<Models.OrderReturnLineItem>();
            private IList<Models.OrderReturnServiceCharge> returnServiceCharges = new List<Models.OrderReturnServiceCharge>();
            private IList<Models.OrderReturnTax> returnTaxes = new List<Models.OrderReturnTax>();
            private IList<Models.OrderReturnDiscount> returnDiscounts = new List<Models.OrderReturnDiscount>();
            private Models.OrderRoundingAdjustment roundingAdjustment;
            private Models.OrderMoneyAmounts returnAmounts;

            public Builder() { }
            public Builder Uid(string value)
            {
                uid = value;
                return this;
            }

            public Builder SourceOrderId(string value)
            {
                sourceOrderId = value;
                return this;
            }

            public Builder ReturnLineItems(IList<Models.OrderReturnLineItem> value)
            {
                returnLineItems = value;
                return this;
            }

            public Builder ReturnServiceCharges(IList<Models.OrderReturnServiceCharge> value)
            {
                returnServiceCharges = value;
                return this;
            }

            public Builder ReturnTaxes(IList<Models.OrderReturnTax> value)
            {
                returnTaxes = value;
                return this;
            }

            public Builder ReturnDiscounts(IList<Models.OrderReturnDiscount> value)
            {
                returnDiscounts = value;
                return this;
            }

            public Builder RoundingAdjustment(Models.OrderRoundingAdjustment value)
            {
                roundingAdjustment = value;
                return this;
            }

            public Builder ReturnAmounts(Models.OrderMoneyAmounts value)
            {
                returnAmounts = value;
                return this;
            }

            public OrderReturn Build()
            {
                return new OrderReturn(uid,
                    sourceOrderId,
                    returnLineItems,
                    returnServiceCharges,
                    returnTaxes,
                    returnDiscounts,
                    roundingAdjustment,
                    returnAmounts);
            }
        }
    }
}