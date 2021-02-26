
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
    public class CashDrawerShift 
    {
        public CashDrawerShift(string id = null,
            string state = null,
            string openedAt = null,
            string endedAt = null,
            string closedAt = null,
            IList<string> employeeIds = null,
            string openingEmployeeId = null,
            string endingEmployeeId = null,
            string closingEmployeeId = null,
            string description = null,
            Models.Money openedCashMoney = null,
            Models.Money cashPaymentMoney = null,
            Models.Money cashRefundsMoney = null,
            Models.Money cashPaidInMoney = null,
            Models.Money cashPaidOutMoney = null,
            Models.Money expectedCashMoney = null,
            Models.Money closedCashMoney = null,
            Models.CashDrawerDevice device = null)
        {
            Id = id;
            State = state;
            OpenedAt = openedAt;
            EndedAt = endedAt;
            ClosedAt = closedAt;
            EmployeeIds = employeeIds;
            OpeningEmployeeId = openingEmployeeId;
            EndingEmployeeId = endingEmployeeId;
            ClosingEmployeeId = closingEmployeeId;
            Description = description;
            OpenedCashMoney = openedCashMoney;
            CashPaymentMoney = cashPaymentMoney;
            CashRefundsMoney = cashRefundsMoney;
            CashPaidInMoney = cashPaidInMoney;
            CashPaidOutMoney = cashPaidOutMoney;
            ExpectedCashMoney = expectedCashMoney;
            ClosedCashMoney = closedCashMoney;
            Device = device;
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
        /// The time when the shift began, in ISO 8601 format.
        /// </summary>
        [JsonProperty("opened_at", NullValueHandling = NullValueHandling.Ignore)]
        public string OpenedAt { get; }

        /// <summary>
        /// The time when the shift ended, in ISO 8601 format.
        /// </summary>
        [JsonProperty("ended_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EndedAt { get; }

        /// <summary>
        /// The time when the shift was closed, in ISO 8601 format.
        /// </summary>
        [JsonProperty("closed_at", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosedAt { get; }

        /// <summary>
        /// The IDs of all employees that were logged into Square Point of Sale at any
        /// point while the cash drawer shift was open.
        /// </summary>
        [JsonProperty("employee_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> EmployeeIds { get; }

        /// <summary>
        /// The ID of the employee that started the cash drawer shift.
        /// </summary>
        [JsonProperty("opening_employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string OpeningEmployeeId { get; }

        /// <summary>
        /// The ID of the employee that ended the cash drawer shift.
        /// </summary>
        [JsonProperty("ending_employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string EndingEmployeeId { get; }

        /// <summary>
        /// The ID of the employee that closed the cash drawer shift by auditing
        /// the cash drawer contents.
        /// </summary>
        [JsonProperty("closing_employee_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClosingEmployeeId { get; }

        /// <summary>
        /// The free-form text description of a cash drawer by an employee.
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
        [JsonProperty("cash_payment_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CashPaymentMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_refunds_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CashRefundsMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_paid_in_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CashPaidInMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_paid_out_money", NullValueHandling = NullValueHandling.Ignore)]
        public Models.Money CashPaidOutMoney { get; }

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

        /// <summary>
        /// Getter for device
        /// </summary>
        [JsonProperty("device", NullValueHandling = NullValueHandling.Ignore)]
        public Models.CashDrawerDevice Device { get; }

        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"CashDrawerShift : ({string.Join(", ", toStringOutput)})";
        }

        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Id = {(Id == null ? "null" : Id == string.Empty ? "" : Id)}");
            toStringOutput.Add($"State = {(State == null ? "null" : State.ToString())}");
            toStringOutput.Add($"OpenedAt = {(OpenedAt == null ? "null" : OpenedAt == string.Empty ? "" : OpenedAt)}");
            toStringOutput.Add($"EndedAt = {(EndedAt == null ? "null" : EndedAt == string.Empty ? "" : EndedAt)}");
            toStringOutput.Add($"ClosedAt = {(ClosedAt == null ? "null" : ClosedAt == string.Empty ? "" : ClosedAt)}");
            toStringOutput.Add($"EmployeeIds = {(EmployeeIds == null ? "null" : $"[{ string.Join(", ", EmployeeIds)} ]")}");
            toStringOutput.Add($"OpeningEmployeeId = {(OpeningEmployeeId == null ? "null" : OpeningEmployeeId == string.Empty ? "" : OpeningEmployeeId)}");
            toStringOutput.Add($"EndingEmployeeId = {(EndingEmployeeId == null ? "null" : EndingEmployeeId == string.Empty ? "" : EndingEmployeeId)}");
            toStringOutput.Add($"ClosingEmployeeId = {(ClosingEmployeeId == null ? "null" : ClosingEmployeeId == string.Empty ? "" : ClosingEmployeeId)}");
            toStringOutput.Add($"Description = {(Description == null ? "null" : Description == string.Empty ? "" : Description)}");
            toStringOutput.Add($"OpenedCashMoney = {(OpenedCashMoney == null ? "null" : OpenedCashMoney.ToString())}");
            toStringOutput.Add($"CashPaymentMoney = {(CashPaymentMoney == null ? "null" : CashPaymentMoney.ToString())}");
            toStringOutput.Add($"CashRefundsMoney = {(CashRefundsMoney == null ? "null" : CashRefundsMoney.ToString())}");
            toStringOutput.Add($"CashPaidInMoney = {(CashPaidInMoney == null ? "null" : CashPaidInMoney.ToString())}");
            toStringOutput.Add($"CashPaidOutMoney = {(CashPaidOutMoney == null ? "null" : CashPaidOutMoney.ToString())}");
            toStringOutput.Add($"ExpectedCashMoney = {(ExpectedCashMoney == null ? "null" : ExpectedCashMoney.ToString())}");
            toStringOutput.Add($"ClosedCashMoney = {(ClosedCashMoney == null ? "null" : ClosedCashMoney.ToString())}");
            toStringOutput.Add($"Device = {(Device == null ? "null" : Device.ToString())}");
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

            return obj is CashDrawerShift other &&
                ((Id == null && other.Id == null) || (Id?.Equals(other.Id) == true)) &&
                ((State == null && other.State == null) || (State?.Equals(other.State) == true)) &&
                ((OpenedAt == null && other.OpenedAt == null) || (OpenedAt?.Equals(other.OpenedAt) == true)) &&
                ((EndedAt == null && other.EndedAt == null) || (EndedAt?.Equals(other.EndedAt) == true)) &&
                ((ClosedAt == null && other.ClosedAt == null) || (ClosedAt?.Equals(other.ClosedAt) == true)) &&
                ((EmployeeIds == null && other.EmployeeIds == null) || (EmployeeIds?.Equals(other.EmployeeIds) == true)) &&
                ((OpeningEmployeeId == null && other.OpeningEmployeeId == null) || (OpeningEmployeeId?.Equals(other.OpeningEmployeeId) == true)) &&
                ((EndingEmployeeId == null && other.EndingEmployeeId == null) || (EndingEmployeeId?.Equals(other.EndingEmployeeId) == true)) &&
                ((ClosingEmployeeId == null && other.ClosingEmployeeId == null) || (ClosingEmployeeId?.Equals(other.ClosingEmployeeId) == true)) &&
                ((Description == null && other.Description == null) || (Description?.Equals(other.Description) == true)) &&
                ((OpenedCashMoney == null && other.OpenedCashMoney == null) || (OpenedCashMoney?.Equals(other.OpenedCashMoney) == true)) &&
                ((CashPaymentMoney == null && other.CashPaymentMoney == null) || (CashPaymentMoney?.Equals(other.CashPaymentMoney) == true)) &&
                ((CashRefundsMoney == null && other.CashRefundsMoney == null) || (CashRefundsMoney?.Equals(other.CashRefundsMoney) == true)) &&
                ((CashPaidInMoney == null && other.CashPaidInMoney == null) || (CashPaidInMoney?.Equals(other.CashPaidInMoney) == true)) &&
                ((CashPaidOutMoney == null && other.CashPaidOutMoney == null) || (CashPaidOutMoney?.Equals(other.CashPaidOutMoney) == true)) &&
                ((ExpectedCashMoney == null && other.ExpectedCashMoney == null) || (ExpectedCashMoney?.Equals(other.ExpectedCashMoney) == true)) &&
                ((ClosedCashMoney == null && other.ClosedCashMoney == null) || (ClosedCashMoney?.Equals(other.ClosedCashMoney) == true)) &&
                ((Device == null && other.Device == null) || (Device?.Equals(other.Device) == true));
        }

        public override int GetHashCode()
        {
            int hashCode = -498109440;

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

            if (EmployeeIds != null)
            {
               hashCode += EmployeeIds.GetHashCode();
            }

            if (OpeningEmployeeId != null)
            {
               hashCode += OpeningEmployeeId.GetHashCode();
            }

            if (EndingEmployeeId != null)
            {
               hashCode += EndingEmployeeId.GetHashCode();
            }

            if (ClosingEmployeeId != null)
            {
               hashCode += ClosingEmployeeId.GetHashCode();
            }

            if (Description != null)
            {
               hashCode += Description.GetHashCode();
            }

            if (OpenedCashMoney != null)
            {
               hashCode += OpenedCashMoney.GetHashCode();
            }

            if (CashPaymentMoney != null)
            {
               hashCode += CashPaymentMoney.GetHashCode();
            }

            if (CashRefundsMoney != null)
            {
               hashCode += CashRefundsMoney.GetHashCode();
            }

            if (CashPaidInMoney != null)
            {
               hashCode += CashPaidInMoney.GetHashCode();
            }

            if (CashPaidOutMoney != null)
            {
               hashCode += CashPaidOutMoney.GetHashCode();
            }

            if (ExpectedCashMoney != null)
            {
               hashCode += ExpectedCashMoney.GetHashCode();
            }

            if (ClosedCashMoney != null)
            {
               hashCode += ClosedCashMoney.GetHashCode();
            }

            if (Device != null)
            {
               hashCode += Device.GetHashCode();
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
                .EmployeeIds(EmployeeIds)
                .OpeningEmployeeId(OpeningEmployeeId)
                .EndingEmployeeId(EndingEmployeeId)
                .ClosingEmployeeId(ClosingEmployeeId)
                .Description(Description)
                .OpenedCashMoney(OpenedCashMoney)
                .CashPaymentMoney(CashPaymentMoney)
                .CashRefundsMoney(CashRefundsMoney)
                .CashPaidInMoney(CashPaidInMoney)
                .CashPaidOutMoney(CashPaidOutMoney)
                .ExpectedCashMoney(ExpectedCashMoney)
                .ClosedCashMoney(ClosedCashMoney)
                .Device(Device);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string state;
            private string openedAt;
            private string endedAt;
            private string closedAt;
            private IList<string> employeeIds;
            private string openingEmployeeId;
            private string endingEmployeeId;
            private string closingEmployeeId;
            private string description;
            private Models.Money openedCashMoney;
            private Models.Money cashPaymentMoney;
            private Models.Money cashRefundsMoney;
            private Models.Money cashPaidInMoney;
            private Models.Money cashPaidOutMoney;
            private Models.Money expectedCashMoney;
            private Models.Money closedCashMoney;
            private Models.CashDrawerDevice device;



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

            public Builder EmployeeIds(IList<string> employeeIds)
            {
                this.employeeIds = employeeIds;
                return this;
            }

            public Builder OpeningEmployeeId(string openingEmployeeId)
            {
                this.openingEmployeeId = openingEmployeeId;
                return this;
            }

            public Builder EndingEmployeeId(string endingEmployeeId)
            {
                this.endingEmployeeId = endingEmployeeId;
                return this;
            }

            public Builder ClosingEmployeeId(string closingEmployeeId)
            {
                this.closingEmployeeId = closingEmployeeId;
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

            public Builder CashPaymentMoney(Models.Money cashPaymentMoney)
            {
                this.cashPaymentMoney = cashPaymentMoney;
                return this;
            }

            public Builder CashRefundsMoney(Models.Money cashRefundsMoney)
            {
                this.cashRefundsMoney = cashRefundsMoney;
                return this;
            }

            public Builder CashPaidInMoney(Models.Money cashPaidInMoney)
            {
                this.cashPaidInMoney = cashPaidInMoney;
                return this;
            }

            public Builder CashPaidOutMoney(Models.Money cashPaidOutMoney)
            {
                this.cashPaidOutMoney = cashPaidOutMoney;
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

            public Builder Device(Models.CashDrawerDevice device)
            {
                this.device = device;
                return this;
            }

            public CashDrawerShift Build()
            {
                return new CashDrawerShift(id,
                    state,
                    openedAt,
                    endedAt,
                    closedAt,
                    employeeIds,
                    openingEmployeeId,
                    endingEmployeeId,
                    closingEmployeeId,
                    description,
                    openedCashMoney,
                    cashPaymentMoney,
                    cashRefundsMoney,
                    cashPaidInMoney,
                    cashPaidOutMoney,
                    expectedCashMoney,
                    closedCashMoney,
                    device);
            }
        }
    }
}