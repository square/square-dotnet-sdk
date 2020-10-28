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