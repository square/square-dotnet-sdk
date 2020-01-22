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
    public class V1BankAccount 
    {
        public V1BankAccount(string id = null,
            string merchantId = null,
            string bankName = null,
            string name = null,
            string routingNumber = null,
            string accountNumberSuffix = null,
            string currencyCode = null,
            string type = null)
        {
            Id = id;
            MerchantId = merchantId;
            BankName = bankName;
            Name = name;
            RoutingNumber = routingNumber;
            AccountNumberSuffix = accountNumberSuffix;
            CurrencyCode = currencyCode;
            Type = type;
        }

        [JsonIgnore]
        public HttpContext Context { get; internal set; }

        /// <summary>
        /// The bank account's Square-issued ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The Square-issued ID of the merchant associated with the bank account.
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; }

        /// <summary>
        /// The name of the bank that manages the account.
        /// </summary>
        [JsonProperty("bank_name")]
        public string BankName { get; }

        /// <summary>
        /// The name associated with the bank account.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The bank account's routing number.
        /// </summary>
        [JsonProperty("routing_number")]
        public string RoutingNumber { get; }

        /// <summary>
        /// The last few digits of the bank account number.
        /// </summary>
        [JsonProperty("account_number_suffix")]
        public string AccountNumberSuffix { get; }

        /// <summary>
        /// The currency code of the currency associated with the bank account, in ISO 4217 format. For example, the currency code for US dollars is USD.
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .MerchantId(MerchantId)
                .BankName(BankName)
                .Name(Name)
                .RoutingNumber(RoutingNumber)
                .AccountNumberSuffix(AccountNumberSuffix)
                .CurrencyCode(CurrencyCode)
                .Type(Type);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string merchantId;
            private string bankName;
            private string name;
            private string routingNumber;
            private string accountNumberSuffix;
            private string currencyCode;
            private string type;

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder MerchantId(string value)
            {
                merchantId = value;
                return this;
            }

            public Builder BankName(string value)
            {
                bankName = value;
                return this;
            }

            public Builder Name(string value)
            {
                name = value;
                return this;
            }

            public Builder RoutingNumber(string value)
            {
                routingNumber = value;
                return this;
            }

            public Builder AccountNumberSuffix(string value)
            {
                accountNumberSuffix = value;
                return this;
            }

            public Builder CurrencyCode(string value)
            {
                currencyCode = value;
                return this;
            }

            public Builder Type(string value)
            {
                type = value;
                return this;
            }

            public V1BankAccount Build()
            {
                return new V1BankAccount(id,
                    merchantId,
                    bankName,
                    name,
                    routingNumber,
                    accountNumberSuffix,
                    currencyCode,
                    type);
            }
        }
    }
}