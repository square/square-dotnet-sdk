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
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The current state of a cash drawer shift.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; }

        /// <summary>
        /// The time when the shift began, in ISO 8601 format.
        /// </summary>
        [JsonProperty("opened_at")]
        public string OpenedAt { get; }

        /// <summary>
        /// The time when the shift ended, in ISO 8601 format.
        /// </summary>
        [JsonProperty("ended_at")]
        public string EndedAt { get; }

        /// <summary>
        /// The time when the shift was closed, in ISO 8601 format.
        /// </summary>
        [JsonProperty("closed_at")]
        public string ClosedAt { get; }

        /// <summary>
        /// The IDs of all employees that were logged into Square Point of Sale at any
        /// point while the cash drawer shift was open.
        /// </summary>
        [JsonProperty("employee_ids")]
        public IList<string> EmployeeIds { get; }

        /// <summary>
        /// The ID of the employee that started the cash drawer shift.
        /// </summary>
        [JsonProperty("opening_employee_id")]
        public string OpeningEmployeeId { get; }

        /// <summary>
        /// The ID of the employee that ended the cash drawer shift.
        /// </summary>
        [JsonProperty("ending_employee_id")]
        public string EndingEmployeeId { get; }

        /// <summary>
        /// The ID of the employee that closed the cash drawer shift by auditing
        /// the cash drawer contents.
        /// </summary>
        [JsonProperty("closing_employee_id")]
        public string ClosingEmployeeId { get; }

        /// <summary>
        /// The free-form text description of a cash drawer by an employee.
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
        [JsonProperty("cash_payment_money")]
        public Models.Money CashPaymentMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_refunds_money")]
        public Models.Money CashRefundsMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_paid_in_money")]
        public Models.Money CashPaidInMoney { get; }

        /// <summary>
        /// Represents an amount of money. `Money` fields can be signed or unsigned.
        /// Fields that do not explicitly define whether they are signed or unsigned are
        /// considered unsigned and can only hold positive amounts. For signed fields, the
        /// sign of the value indicates the purpose of the money transfer. See
        /// [Working with Monetary Amounts](https://developer.squareup.com/docs/build-basics/working-with-monetary-amounts)
        /// for more information.
        /// </summary>
        [JsonProperty("cash_paid_out_money")]
        public Models.Money CashPaidOutMoney { get; }

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

        /// <summary>
        /// Getter for device
        /// </summary>
        [JsonProperty("device")]
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
            private IList<string> employeeIds = new List<string>();
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

            public Builder EmployeeIds(IList<string> value)
            {
                employeeIds = value;
                return this;
            }

            public Builder OpeningEmployeeId(string value)
            {
                openingEmployeeId = value;
                return this;
            }

            public Builder EndingEmployeeId(string value)
            {
                endingEmployeeId = value;
                return this;
            }

            public Builder ClosingEmployeeId(string value)
            {
                closingEmployeeId = value;
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

            public Builder CashPaymentMoney(Models.Money value)
            {
                cashPaymentMoney = value;
                return this;
            }

            public Builder CashRefundsMoney(Models.Money value)
            {
                cashRefundsMoney = value;
                return this;
            }

            public Builder CashPaidInMoney(Models.Money value)
            {
                cashPaidInMoney = value;
                return this;
            }

            public Builder CashPaidOutMoney(Models.Money value)
            {
                cashPaidOutMoney = value;
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

            public Builder Device(Models.CashDrawerDevice value)
            {
                device = value;
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