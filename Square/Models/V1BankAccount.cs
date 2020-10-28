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
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The Square-issued ID of the merchant associated with the bank account.
        /// </summary>
        [JsonProperty("merchant_id", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantId { get; }

        /// <summary>
        /// The name of the bank that manages the account.
        /// </summary>
        [JsonProperty("bank_name", NullValueHandling = NullValueHandling.Ignore)]
        public string BankName { get; }

        /// <summary>
        /// The name associated with the bank account.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; }

        /// <summary>
        /// The bank account's routing number.
        /// </summary>
        [JsonProperty("routing_number", NullValueHandling = NullValueHandling.Ignore)]
        public string RoutingNumber { get; }

        /// <summary>
        /// The last few digits of the bank account number.
        /// </summary>
        [JsonProperty("account_number_suffix", NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumberSuffix { get; }

        /// <summary>
        /// The currency code of the currency associated with the bank account, in ISO 4217 format. For example, the currency code for US dollars is USD.
        /// </summary>
        [JsonProperty("currency_code", NullValueHandling = NullValueHandling.Ignore)]
        public string CurrencyCode { get; }

        /// <summary>
        /// Getter for type
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
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



            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder MerchantId(string merchantId)
            {
                this.merchantId = merchantId;
                return this;
            }

            public Builder BankName(string bankName)
            {
                this.bankName = bankName;
                return this;
            }

            public Builder Name(string name)
            {
                this.name = name;
                return this;
            }

            public Builder RoutingNumber(string routingNumber)
            {
                this.routingNumber = routingNumber;
                return this;
            }

            public Builder AccountNumberSuffix(string accountNumberSuffix)
            {
                this.accountNumberSuffix = accountNumberSuffix;
                return this;
            }

            public Builder CurrencyCode(string currencyCode)
            {
                this.currencyCode = currencyCode;
                return this;
            }

            public Builder Type(string type)
            {
                this.type = type;
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