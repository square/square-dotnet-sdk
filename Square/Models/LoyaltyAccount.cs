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
        [JsonProperty("id")]
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
        /// </summary>
        [JsonProperty("balance")]
        public int? Balance { get; }

        /// <summary>
        /// The total points accrued during the lifetime of the account.
        /// </summary>
        [JsonProperty("lifetime_points")]
        public int? LifetimePoints { get; }

        /// <summary>
        /// The Square-assigned ID of the [customer](#type-Customer) that is associated with the account.
        /// </summary>
        [JsonProperty("customer_id")]
        public string CustomerId { get; }

        /// <summary>
        /// The timestamp when enrollment occurred, in RFC 3339 format.
        /// </summary>
        [JsonProperty("enrolled_at")]
        public string EnrolledAt { get; }

        /// <summary>
        /// The timestamp when the loyalty account was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the loyalty account was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
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
            public Builder Mappings(IList<Models.LoyaltyAccountMapping> value)
            {
                mappings = value;
                return this;
            }

            public Builder ProgramId(string value)
            {
                programId = value;
                return this;
            }

            public Builder Id(string value)
            {
                id = value;
                return this;
            }

            public Builder Balance(int? value)
            {
                balance = value;
                return this;
            }

            public Builder LifetimePoints(int? value)
            {
                lifetimePoints = value;
                return this;
            }

            public Builder CustomerId(string value)
            {
                customerId = value;
                return this;
            }

            public Builder EnrolledAt(string value)
            {
                enrolledAt = value;
                return this;
            }

            public Builder CreatedAt(string value)
            {
                createdAt = value;
                return this;
            }

            public Builder UpdatedAt(string value)
            {
                updatedAt = value;
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