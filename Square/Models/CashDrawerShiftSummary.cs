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
    public class CashDrawerShiftSummary 
    {
        public CashDrawerShiftSummary(string id = null,
            string state = null,
            string openedAt = null,
            string endedAt = null,
            string closedAt = null,
            string description = null,
            Models.Money openedCashMoney = null,
            Models.Money expectedCashMoney = null,
            Models.Money closedCashMoney = null)
        {
            Id = id;
            State = state;
            OpenedAt = openedAt;
            EndedAt = endedAt;
            ClosedAt = closedAt;
            Description = description;
            OpenedCashMoney = openedCashMoney;
            ExpectedCashMoney = expectedCashMoney;
            ClosedCashMoney = closedCashMoney;
        }

        /// <summary>
        /// The shift unique ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The current state of a cash drawer shift.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; }

        /// <summary>
        /// The shift start time in ISO 8601 format.
        /// </summary>
        [JsonProperty("opened_at")]
        public string OpenedAt { get; }

        /// <summary>
        /// The shift end time in ISO 8601 format.
        /// </summary>
        [JsonProperty("ended_at")]
        public string EndedAt { get; }

        /// <summary>
        /// The shift close time in ISO 8601 format.
        /// </summary>
        [JsonProperty("closed_at")]
        public string ClosedAt { get; }

        /// <summary>
        /// An employee free-text description of a cash drawer shift.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("opened_cash_money")]
        public Models.Money OpenedCashMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("expected_cash_money")]
        public Models.Money ExpectedCashMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("closed_cash_money")]
        public Models.Money ClosedCashMoney { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .State(State)
                .OpenedAt(OpenedAt)
                .EndedAt(EndedAt)
                .ClosedAt(ClosedAt)
                .Description(Description)
                .OpenedCashMoney(OpenedCashMoney)
                .ExpectedCashMoney(ExpectedCashMoney)
                .ClosedCashMoney(ClosedCashMoney);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string state;
            private string openedAt;
            private string endedAt;
            private string closedAt;
            private string description;
            private Models.Money openedCashMoney;
            private Models.Money expectedCashMoney;
            private Models.Money closedCashMoney;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder State(string value)
            {
                state = value;
                return this;
            }

            public Builder OpenedAt(string value)
            {
                openedAt = value;
                return this;
            }

            public Builder EndedAt(string value)
            {
                endedAt = value;
                return this;
            }

            public Builder ClosedAt(string value)
            {
                closedAt = value;
                return this;
            }

            public Builder Description(string value)
            {
                description = value;
                return this;
            }

            public Builder OpenedCashMoney(Models.Money value)
            {
                openedCashMoney = value;
                return this;
            }

            public Builder ExpectedCashMoney(Models.Money value)
            {
                expectedCashMoney = value;
                return this;
            }

            public Builder ClosedCashMoney(Models.Money value)
            {
                closedCashMoney = value;
                return this;
            }

            public CashDrawerShiftSummary Build()
            {
                return new CashDrawerShiftSummary(id,
                    state,
                    openedAt,
                    endedAt,
                    closedAt,
                    description,
                    openedCashMoney,
                    expectedCashMoney,
                    closedCashMoney);
            }
        }
    }
}