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
    public class LoyaltyAccount 
    {
        public LoyaltyAccount(IList<Models.LoyaltyAccountMapping> mappings,
            string programId,
            string id = null,
            int? balance = null,
            int? lifetimePoints = null,
            string customerId = null,
            string enrolledAt = null,
            string createdAt = null,
            string updatedAt = null)
        {
            Id = id;
            Mappings = mappings;
            ProgramId = programId;
            Balance = balance;
            LifetimePoints = lifetimePoints;
            CustomerId = customerId;
            EnrolledAt = enrolledAt;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        /// <summary>
        /// The Square-assigned ID of the loyalty account.
        /// </summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; }

        /// <summary>
        /// The list of mappings that the account is associated with. 
        /// Currently, a buyer can only be mapped to a loyalty account using 
        /// a phone number. Therefore, the list can only have one mapping.
        /// </summary>
        [JsonProperty("mappings")]
        public IList<Models.LoyaltyAccountMapping> Mappings { get; }

        /// <summary>
        /// The Square-assigned ID of the [loyalty program](#type-LoyaltyProgram) to which the account belongs.
        /// </summary>
        [JsonProperty("program_id")]
        public string ProgramId { get; }

        /// <summary>
        /// The available point balance in the loyalty account.  
        /// Your application should be able to handle loyalty accounts that have a negative point balance (`balance` is less than 0). This might occur if a seller makes a manual adjustment or as a result of a refund or exchange.
        /// </summary>
        [JsonProperty("balance", NullValueHandling = NullValueHandling.Ignore)]
        public int? Balance { get; }

        /// <summary>
        /// The total points accrued during the lifetime of the account.
        /// </summary>
        [JsonProperty("lifetime_points", NullValueHandling = NullValueHandling.Ignore)]
        public int? LifetimePoints { get; }

        /// <summary>
        /// The Square-assigned ID of the [customer](#type-Customer) that is associated with the account.
        /// </summary>
        [JsonProperty("customer_id", NullValueHandling = NullValueHandling.Ignore)]
        public string CustomerId { get; }

        /// <summary>
        /// The timestamp when enrollment occurred, in RFC 3339 format.
        /// </summary>
        [JsonProperty("enrolled_at", NullValueHandling = NullValueHandling.Ignore)]
        public string EnrolledAt { get; }

        /// <summary>
        /// The timestamp when the loyalty account was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the loyalty account was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public string UpdatedAt { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder(Mappings,
                ProgramId)
                .Id(Id)
                .Balance(Balance)
                .LifetimePoints(LifetimePoints)
                .CustomerId(CustomerId)
                .EnrolledAt(EnrolledAt)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt);
            return builder;
        }

        public class Builder
        {
            private IList<Models.LoyaltyAccountMapping> mappings;
            private string programId;
            private string id;
            private int? balance;
            private int? lifetimePoints;
            private string customerId;
            private string enrolledAt;
            private string createdAt;
            private string updatedAt;

            public Builder(IList<Models.LoyaltyAccountMapping> mappings,
                string programId)
            {
                this.mappings = mappings;
                this.programId = programId;
            }

            public Builder Mappings(IList<Models.LoyaltyAccountMapping> mappings)
            {
                this.mappings = mappings;
                return this;
            }

            public Builder ProgramId(string programId)
            {
                this.programId = programId;
                return this;
            }

            public Builder Id(string id)
            {
                this.id = id;
                return this;
            }

            public Builder Balance(int? balance)
            {
                this.balance = balance;
                return this;
            }

            public Builder LifetimePoints(int? lifetimePoints)
            {
                this.lifetimePoints = lifetimePoints;
                return this;
            }

            public Builder CustomerId(string customerId)
            {
                this.customerId = customerId;
                return this;
            }

            public Builder EnrolledAt(string enrolledAt)
            {
                this.enrolledAt = enrolledAt;
                return this;
            }

            public Builder CreatedAt(string createdAt)
            {
                this.createdAt = createdAt;
                return this;
            }

            public Builder UpdatedAt(string updatedAt)
            {
                this.updatedAt = updatedAt;
                return this;
            }

            public LoyaltyAccount Build()
            {
                return new LoyaltyAccount(mappings,
                    programId,
                    id,
                    balance,
                    lifetimePoints,
                    customerId,
                    enrolledAt,
                    createdAt,
                    updatedAt);
            }
        }
    }
}