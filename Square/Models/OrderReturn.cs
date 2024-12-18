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

namespace Square.Models
{
    /// <summary>
    /// OrderReturn.
    /// </summary>
    public class OrderReturn
    {
        private readonly Dictionary<string, bool> shouldSerialize;
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderReturn"/> class.
        /// </summary>
        /// <param name="uid">uid.</param>
        /// <param name="sourceOrderId">source_order_id.</param>
        /// <param name="returnLineItems">return_line_items.</param>
        /// <param name="returnServiceCharges">return_service_charges.</param>
        /// <param name="returnTaxes">return_taxes.</param>
        /// <param name="returnDiscounts">return_discounts.</param>
        /// <param name="returnTips">return_tips.</param>
        /// <param name="roundingAdjustment">rounding_adjustment.</param>
        /// <param name="returnAmounts">return_amounts.</param>
        public OrderReturn(
            string uid = null,
            string sourceOrderId = null,
            IList<Models.OrderReturnLineItem> returnLineItems = null,
            IList<Models.OrderReturnServiceCharge> returnServiceCharges = null,
            IList<Models.OrderReturnTax> returnTaxes = null,
            IList<Models.OrderReturnDiscount> returnDiscounts = null,
            IList<Models.OrderReturnTip> returnTips = null,
            Models.OrderRoundingAdjustment roundingAdjustment = null,
            Models.OrderMoneyAmounts returnAmounts = null)
        {
            shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_order_id", false },
                { "return_line_items", false },
                { "return_service_charges", false },
                { "return_tips", false }
            };

            if (uid != null)
            {
                shouldSerialize["uid"] = true;
                this.Uid = uid;
            }

            if (sourceOrderId != null)
            {
                shouldSerialize["source_order_id"] = true;
                this.SourceOrderId = sourceOrderId;
            }

            if (returnLineItems != null)
            {
                shouldSerialize["return_line_items"] = true;
                this.ReturnLineItems = returnLineItems;
            }

            if (returnServiceCharges != null)
            {
                shouldSerialize["return_service_charges"] = true;
                this.ReturnServiceCharges = returnServiceCharges;
            }
            this.ReturnTaxes = returnTaxes;
            this.ReturnDiscounts = returnDiscounts;

            if (returnTips != null)
            {
                shouldSerialize["return_tips"] = true;
                this.ReturnTips = returnTips;
            }
            this.RoundingAdjustment = roundingAdjustment;
            this.ReturnAmounts = returnAmounts;
        }

        internal OrderReturn(
            Dictionary<string, bool> shouldSerialize,
            string uid = null,
            string sourceOrderId = null,
            IList<Models.OrderReturnLineItem> returnLineItems = null,
            IList<Models.OrderReturnServiceCharge> returnServiceCharges = null,
            IList<Models.OrderReturnTax> returnTaxes = null,
            IList<Models.OrderReturnDiscount> returnDiscounts = null,
            IList<Models.OrderReturnTip> returnTips = null,
            Models.OrderRoundingAdjustment roundingAdjustment = null,
            Models.OrderMoneyAmounts returnAmounts = null)
        {
            this.shouldSerialize = shouldSerialize;
            Uid = uid;
            SourceOrderId = sourceOrderId;
            ReturnLineItems = returnLineItems;
            ReturnServiceCharges = returnServiceCharges;
            ReturnTaxes = returnTaxes;
            ReturnDiscounts = returnDiscounts;
            ReturnTips = returnTips;
            RoundingAdjustment = roundingAdjustment;
            ReturnAmounts = returnAmounts;
        }

        /// <summary>
        /// A unique ID that identifies the return only within this order.
        /// </summary>
        [JsonProperty("uid")]
        public string Uid { get; }

        /// <summary>
        /// An order that contains the original sale of these return line items. This is unset
        /// for unlinked returns.
        /// </summary>
        [JsonProperty("source_order_id")]
        public string SourceOrderId { get; }

        /// <summary>
        /// A collection of line items that are being returned.
        /// </summary>
        [JsonProperty("return_line_items")]
        public IList<Models.OrderReturnLineItem> ReturnLineItems { get; }

        /// <summary>
        /// A collection of service charges that are being returned.
        /// </summary>
        [JsonProperty("return_service_charges")]
        public IList<Models.OrderReturnServiceCharge> ReturnServiceCharges { get; }

        /// <summary>
        /// A collection of references to taxes being returned for an order, including the total
        /// applied tax amount to be returned. The taxes must reference a top-level tax ID from the source
        /// order.
        /// </summary>
        [JsonProperty("return_taxes", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderReturnTax> ReturnTaxes { get; }

        /// <summary>
        /// A collection of references to discounts being returned for an order, including the total
        /// applied discount amount to be returned. The discounts must reference a top-level discount ID
        /// from the source order.
        /// </summary>
        [JsonProperty("return_discounts", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Models.OrderReturnDiscount> ReturnDiscounts { get; }

        /// <summary>
        /// A collection of references to tips being returned for an order.
        /// </summary>
        [JsonProperty("return_tips")]
        public IList<Models.OrderReturnTip> ReturnTips { get; }

        /// <summary>
        /// A rounding adjustment of the money being returned. Commonly used to apply cash rounding
        /// when the minimum unit of the account is smaller than the lowest physical denomination of the currency.
        /// </summary>
        [JsonProperty("rounding_adjustment", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderRoundingAdjustment RoundingAdjustment { get; }

        /// <summary>
        /// A collection of various money amounts.
        /// </summary>
        [JsonProperty("return_amounts", NullValueHandling = NullValueHandling.Ignore)]
        public Models.OrderMoneyAmounts ReturnAmounts { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();
            this.ToString(toStringOutput);
            return $"OrderReturn : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeUid()
        {
            return this.shouldSerialize["uid"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeSourceOrderId()
        {
            return this.shouldSerialize["source_order_id"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReturnLineItems()
        {
            return this.shouldSerialize["return_line_items"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReturnServiceCharges()
        {
            return this.shouldSerialize["return_service_charges"];
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeReturnTips()
        {
            return this.shouldSerialize["return_tips"];
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj is OrderReturn other &&
                (this.Uid == null && other.Uid == null ||
                 this.Uid?.Equals(other.Uid) == true) &&
                (this.SourceOrderId == null && other.SourceOrderId == null ||
                 this.SourceOrderId?.Equals(other.SourceOrderId) == true) &&
                (this.ReturnLineItems == null && other.ReturnLineItems == null ||
                 this.ReturnLineItems?.Equals(other.ReturnLineItems) == true) &&
                (this.ReturnServiceCharges == null && other.ReturnServiceCharges == null ||
                 this.ReturnServiceCharges?.Equals(other.ReturnServiceCharges) == true) &&
                (this.ReturnTaxes == null && other.ReturnTaxes == null ||
                 this.ReturnTaxes?.Equals(other.ReturnTaxes) == true) &&
                (this.ReturnDiscounts == null && other.ReturnDiscounts == null ||
                 this.ReturnDiscounts?.Equals(other.ReturnDiscounts) == true) &&
                (this.ReturnTips == null && other.ReturnTips == null ||
                 this.ReturnTips?.Equals(other.ReturnTips) == true) &&
                (this.RoundingAdjustment == null && other.RoundingAdjustment == null ||
                 this.RoundingAdjustment?.Equals(other.RoundingAdjustment) == true) &&
                (this.ReturnAmounts == null && other.ReturnAmounts == null ||
                 this.ReturnAmounts?.Equals(other.ReturnAmounts) == true);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            var hashCode = 1922557900;
            hashCode = HashCode.Combine(hashCode, this.Uid, this.SourceOrderId, this.ReturnLineItems, this.ReturnServiceCharges, this.ReturnTaxes, this.ReturnDiscounts, this.ReturnTips);

            hashCode = HashCode.Combine(hashCode, this.RoundingAdjustment, this.ReturnAmounts);

            return hashCode;
        }

        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Uid = {this.Uid ?? "null"}");
            toStringOutput.Add($"this.SourceOrderId = {this.SourceOrderId ?? "null"}");
            toStringOutput.Add($"this.ReturnLineItems = {(this.ReturnLineItems == null ? "null" : $"[{string.Join(", ", this.ReturnLineItems)} ]")}");
            toStringOutput.Add($"this.ReturnServiceCharges = {(this.ReturnServiceCharges == null ? "null" : $"[{string.Join(", ", this.ReturnServiceCharges)} ]")}");
            toStringOutput.Add($"this.ReturnTaxes = {(this.ReturnTaxes == null ? "null" : $"[{string.Join(", ", this.ReturnTaxes)} ]")}");
            toStringOutput.Add($"this.ReturnDiscounts = {(this.ReturnDiscounts == null ? "null" : $"[{string.Join(", ", this.ReturnDiscounts)} ]")}");
            toStringOutput.Add($"this.ReturnTips = {(this.ReturnTips == null ? "null" : $"[{string.Join(", ", this.ReturnTips)} ]")}");
            toStringOutput.Add($"this.RoundingAdjustment = {(this.RoundingAdjustment == null ? "null" : this.RoundingAdjustment.ToString())}");
            toStringOutput.Add($"this.ReturnAmounts = {(this.ReturnAmounts == null ? "null" : this.ReturnAmounts.ToString())}");
        }

        /// <summary>
        /// Converts to builder object.
        /// </summary>
        /// <returns> Builder. </returns>
        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Uid(this.Uid)
                .SourceOrderId(this.SourceOrderId)
                .ReturnLineItems(this.ReturnLineItems)
                .ReturnServiceCharges(this.ReturnServiceCharges)
                .ReturnTaxes(this.ReturnTaxes)
                .ReturnDiscounts(this.ReturnDiscounts)
                .ReturnTips(this.ReturnTips)
                .RoundingAdjustment(this.RoundingAdjustment)
                .ReturnAmounts(this.ReturnAmounts);
            return builder;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
            {
                { "uid", false },
                { "source_order_id", false },
                { "return_line_items", false },
                { "return_service_charges", false },
                { "return_tips", false },
            };

            private string uid;
            private string sourceOrderId;
            private IList<Models.OrderReturnLineItem> returnLineItems;
            private IList<Models.OrderReturnServiceCharge> returnServiceCharges;
            private IList<Models.OrderReturnTax> returnTaxes;
            private IList<Models.OrderReturnDiscount> returnDiscounts;
            private IList<Models.OrderReturnTip> returnTips;
            private Models.OrderRoundingAdjustment roundingAdjustment;
            private Models.OrderMoneyAmounts returnAmounts;

             /// <summary>
             /// Uid.
             /// </summary>
             /// <param name="uid"> uid. </param>
             /// <returns> Builder. </returns>
            public Builder Uid(string uid)
            {
                shouldSerialize["uid"] = true;
                this.uid = uid;
                return this;
            }

             /// <summary>
             /// SourceOrderId.
             /// </summary>
             /// <param name="sourceOrderId"> sourceOrderId. </param>
             /// <returns> Builder. </returns>
            public Builder SourceOrderId(string sourceOrderId)
            {
                shouldSerialize["source_order_id"] = true;
                this.sourceOrderId = sourceOrderId;
                return this;
            }

             /// <summary>
             /// ReturnLineItems.
             /// </summary>
             /// <param name="returnLineItems"> returnLineItems. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnLineItems(IList<Models.OrderReturnLineItem> returnLineItems)
            {
                shouldSerialize["return_line_items"] = true;
                this.returnLineItems = returnLineItems;
                return this;
            }

             /// <summary>
             /// ReturnServiceCharges.
             /// </summary>
             /// <param name="returnServiceCharges"> returnServiceCharges. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnServiceCharges(IList<Models.OrderReturnServiceCharge> returnServiceCharges)
            {
                shouldSerialize["return_service_charges"] = true;
                this.returnServiceCharges = returnServiceCharges;
                return this;
            }

             /// <summary>
             /// ReturnTaxes.
             /// </summary>
             /// <param name="returnTaxes"> returnTaxes. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnTaxes(IList<Models.OrderReturnTax> returnTaxes)
            {
                this.returnTaxes = returnTaxes;
                return this;
            }

             /// <summary>
             /// ReturnDiscounts.
             /// </summary>
             /// <param name="returnDiscounts"> returnDiscounts. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnDiscounts(IList<Models.OrderReturnDiscount> returnDiscounts)
            {
                this.returnDiscounts = returnDiscounts;
                return this;
            }

             /// <summary>
             /// ReturnTips.
             /// </summary>
             /// <param name="returnTips"> returnTips. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnTips(IList<Models.OrderReturnTip> returnTips)
            {
                shouldSerialize["return_tips"] = true;
                this.returnTips = returnTips;
                return this;
            }

             /// <summary>
             /// RoundingAdjustment.
             /// </summary>
             /// <param name="roundingAdjustment"> roundingAdjustment. </param>
             /// <returns> Builder. </returns>
            public Builder RoundingAdjustment(Models.OrderRoundingAdjustment roundingAdjustment)
            {
                this.roundingAdjustment = roundingAdjustment;
                return this;
            }

             /// <summary>
             /// ReturnAmounts.
             /// </summary>
             /// <param name="returnAmounts"> returnAmounts. </param>
             /// <returns> Builder. </returns>
            public Builder ReturnAmounts(Models.OrderMoneyAmounts returnAmounts)
            {
                this.returnAmounts = returnAmounts;
                return this;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetUid()
            {
                this.shouldSerialize["uid"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetSourceOrderId()
            {
                this.shouldSerialize["source_order_id"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReturnLineItems()
            {
                this.shouldSerialize["return_line_items"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReturnServiceCharges()
            {
                this.shouldSerialize["return_service_charges"] = false;
            }

            /// <summary>
            /// Marks the field to not be serialized.
            /// </summary>
            public void UnsetReturnTips()
            {
                this.shouldSerialize["return_tips"] = false;
            }


            /// <summary>
            /// Builds class object.
            /// </summary>
            /// <returns> OrderReturn. </returns>
            public OrderReturn Build()
            {
                return new OrderReturn(
                    shouldSerialize,
                    this.uid,
                    this.sourceOrderId,
                    this.returnLineItems,
                    this.returnServiceCharges,
                    this.returnTaxes,
                    this.returnDiscounts,
                    this.returnTips,
                    this.roundingAdjustment,
                    this.returnAmounts);
            }
        }
    }
}