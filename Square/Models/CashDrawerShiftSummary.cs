
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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The current state of a cash drawer shift.
        /// </summary>
        [JsonProperty("state", NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; }

        /// <summary>
        /// The shift start time in ISO 8601 format.
        /// </summary>
        [JsonProperty("opened_at", NullValueHandling = NullValueHandling.Ignore)]
        public string OpenedAt { get; }

        /// <summary>
        /// The shift end time in ISO 8601 format.
        /// </summary>
        [JsonProperty("ended_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndedAt { get; }

        /// <summary>
        /// The shift close time in ISO 8601 format.
        /// </summary>
        [JsonProperty("closed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosedAt { get; }

        /// <summary>
        /// An employee free-text description of a cash drawer shift.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("opened_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money OpenedCashMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("expected_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ExpectedCashMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("closed_cash_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money ClosedCashMoney { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CashDrawerShiftSummary : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"State = {(State == null ? "null" : State.ToString())}");
            toStringOutput.Add($"OpenedAt = {(OpenedAt == null ? "null" : OpenedAt == string.Empty ? "" : OpenedAt)}");
            toStringOutput.Add($"EndedAt = {(EndedAt == null ? "null" : EndedAt == string.Empty ? "" : EndedAt)}");
            toStringOutput.Add($"ClosedAt = {(ClosedAt == null ? "null" : ClosedAt == string.Empty ? "" : ClosedAt)}");
            toStringOutput.Add($"Description = {(Description == null ? "null" : Description == string.Empty ? "" : Description)}");
            toStringOutput.Add($"OpenedCashMoney = {(OpenedCashMoney == null ? "null" : OpenedCashMoney.ToString())}");
            toStringOutput.Add($"ExpectedCashMoney = {(ExpectedCashMoney == null ? "null" : ExpectedCashMoney.ToString())}");
            toStringOutput.Add($"ClosedCashMoney = {(ClosedCashMoney == null ? "null" : ClosedCashMoney.ToString())}");
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

            return obj is CashDrawerShiftSummary other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((State == null && other.State == null) || (State?.Equals(other.State) == true)) &&
                ((OpenedAt == null && other.OpenedAt == null) || (OpenedAt?.Equals(other.OpenedAt) == true)) &&
                ((EndedAt == null && other.EndedAt == null) || (EndedAt?.Equals(other.EndedAt) == true)) &&
                ((ClosedAt == null && other.ClosedAt == null) || (ClosedAt?.Equals(other.ClosedAt) == true)) &&
                ((Description == null && other.Description == null) || (Description?.Equals(other.Description) == true)) &&
                ((OpenedCashMoney == null && other.OpenedCashMoney == null) || (OpenedCashMoney?.Equals(other.OpenedCashMoney) == true)) &&
                ((ExpectedCashMoney == null && other.ExpectedCashMoney == null) || (ExpectedCashMoney?.Equals(other.ExpectedCashMoney) == true)) &&
                ((ClosedCashMoney == null && other.ClosedCashMoney == null) || (ClosedCashMoney?.Equals(other.ClosedCashMoney) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -323366853;

            if (Id != null)
            {
               hashCode += Id.GetHashCode();
            }

            if (State != null)
            {
               hashCode += State.GetHashCode();
            }

            if (OpenedAt != null)
            {
               hashCode += OpenedAt.GetHashCode();
            }

            if (EndedAt != null)
            {
               hashCode += EndedAt.GetHashCode();
            }

            if (ClosedAt != null)
            {
               hashCode += ClosedAt.GetHashCode();
            }

            if (Description != null)
            {
               hashCode += Description.GetHashCode();
            }

            if (OpenedCashMoney != null)
            {
               hashCode += OpenedCashMoney.GetHashCode();
            }

            if (ExpectedCashMoney != null)
            {
               hashCode += ExpectedCashMoney.GetHashCode();
            }

            if (ClosedCashMoney != null)
            {
               hashCode += ClosedCashMoney.GetHashCode();
            }

            return hashCode;
        }

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



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder State(string state)
            {
                this.state = state;
                return this;
            }

            public Builder OpenedAt(string openedAt)
            {
                this.openedAt = openedAt;
                return this;
            }

            public Builder EndedAt(string endedAt)
            {
                this.endedAt = endedAt;
                return this;
            }

            public Builder ClosedAt(string closedAt)
            {
                this.closedAt = closedAt;
                return this;
            }

            public Builder Description(string description)
            {
                this.description = description;
                return this;
            }

            public Builder OpenedCashMoney(Models.Money openedCashMoney)
            {
                this.openedCashMoney = openedCashMoney;
                return this;
            }

            public Builder ExpectedCashMoney(Models.Money expectedCashMoney)
            {
                this.expectedCashMoney = expectedCashMoney;
                return this;
            }

            public Builder ClosedCashMoney(Models.Money closedCashMoney)
            {
                this.closedCashMoney = closedCashMoney;
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