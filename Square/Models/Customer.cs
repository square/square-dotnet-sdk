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
    public class Customer 
    {
        public Customer(string id = null,
            string createdAt = null,
            string updatedAt = null,
            IList<Models.Card> cards = null,
            string givenName = null,
            string familyName = null,
            string nickname = null,
            string companyName = null,
            string emailAddress = null,
            Models.Address address = null,
            string phoneNumber = null,
            string birthday = null,
            string referenceId = null,
            string note = null,
            Models.CustomerPreferences preferences = null,
            IList<Models.CustomerGroupInfo> groups = null,
            string creationSource = null,
            IList<string> groupIds = null,
            IList<string> segmentIds = null)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Cards = cards;
            GivenName = givenName;
            FamilyName = familyName;
            Nickname = nickname;
            CompanyName = companyName;
            EmailAddress = emailAddress;
            Address = address;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
            ReferenceId = referenceId;
            Note = note;
            Preferences = preferences;
            Groups = groups;
            CreationSource = creationSource;
            GroupIds = groupIds;
            SegmentIds = segmentIds;
        }

        /// <summary>
        /// A unique Square-assigned ID for the customer profile.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// The timestamp when the customer profile was created, in RFC 3339 format.
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; }

        /// <summary>
        /// The timestamp when the customer profile was last updated, in RFC 3339 format.
        /// </summary>
        [JsonProperty("updated_at")]
        public string UpdatedAt { get; }

        /// <summary>
        /// Payment details of cards stored on file for the customer profile.
        /// </summary>
        [JsonProperty("cards")]
        public IList<Models.Card> Cards { get; }

        /// <summary>
        /// The given (i.e., first) name associated with the customer profile.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; }

        /// <summary>
        /// The family (i.e., last) name associated with the customer profile.
        /// </summary>
        [JsonProperty("family_name")]
        public string FamilyName { get; }

        /// <summary>
        /// A nickname for the customer profile.
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; }

        /// <summary>
        /// A business name associated with the customer profile.
        /// </summary>
        [JsonProperty("company_name")]
        public string CompanyName { get; }

        /// <summary>
        /// The email address associated with the customer profile.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; }

        /// <summary>
        /// Represents a physical address.
        /// </summary>
        [JsonProperty("address")]
        public Models.Address Address { get; }

        /// <summary>
        /// The 11-digit phone number associated with the customer profile.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; }

        /// <summary>
        /// The birthday associated with the customer profile, in RFC-3339 format.
        /// Year is optional, timezone and times are not allowed.
        /// For example: `0000-09-01T00:00:00-00:00` indicates a birthday on September 1st.
        /// `1998-09-01T00:00:00-00:00` indications a birthday on September 1st __1998__.
        /// </summary>
        [JsonProperty("birthday")]
        public string Birthday { get; }

        /// <summary>
        /// An optional, second ID used to associate the customer profile with an
        /// entity in another system.
        /// </summary>
        [JsonProperty("reference_id")]
        public string ReferenceId { get; }

        /// <summary>
        /// A custom note associated with the customer profile.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; }

        /// <summary>
        /// Represents communication preferences for the customer profile.
        /// </summary>
        [JsonProperty("preferences")]
        public Models.CustomerPreferences Preferences { get; }

        /// <summary>
        /// The customer groups and segments the customer belongs to. This deprecated field has been replaced with  the dedicated `group_ids` for customer groups and the dedicated `segment_ids` field for customer segments. You can retrieve information about a given customer group and segment respectively using the Customer Groups API and Customer Segments API.
        /// </summary>
        [JsonProperty("groups")]
        public IList<Models.CustomerGroupInfo> Groups { get; }

        /// <summary>
        /// Indicates the method used to create the customer profile.
        /// </summary>
        [JsonProperty("creation_source")]
        public string CreationSource { get; }

        /// <summary>
        /// The IDs of customer groups the customer belongs to.
        /// </summary>
        [JsonProperty("group_ids")]
        public IList<string> GroupIds { get; }

        /// <summary>
        /// The IDs of segments the customer belongs to.
        /// </summary>
        [JsonProperty("segment_ids")]
        public IList<string> SegmentIds { get; }

        public Builder ToBuilder()
        {
            var builder = new Builder()
                .Id(Id)
                .CreatedAt(CreatedAt)
                .UpdatedAt(UpdatedAt)
                .Cards(Cards)
                .GivenName(GivenName)
                .FamilyName(FamilyName)
                .Nickname(Nickname)
                .CompanyName(CompanyName)
                .EmailAddress(EmailAddress)
                .Address(Address)
                .PhoneNumber(PhoneNumber)
                .Birthday(Birthday)
                .ReferenceId(ReferenceId)
                .Note(Note)
                .Preferences(Preferences)
                .Groups(Groups)
                .CreationSource(CreationSource)
                .GroupIds(GroupIds)
                .SegmentIds(SegmentIds);
            return builder;
        }

        public class Builder
        {
            private string id;
            private string createdAt;
            private string updatedAt;
            private IList<Models.Card> cards = new List<Models.Card>();
            private string givenName;
            private string familyName;
            private string nickname;
            private string companyName;
            private string emailAddress;
            private Models.Address address;
            private string phoneNumber;
            private string birthday;
            private string referenceId;
            private string note;
            private Models.CustomerPreferences preferences;
            private IList<Models.CustomerGroupInfo> groups = new List<Models.CustomerGroupInfo>();
            private string creationSource;
            private IList<string> groupIds = new List<string>();
            private IList<string> segmentIds = new List<string>();

            public Builder() { }
            public Builder Id(string value)
            {
                id = value;
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

            public Builder Cards(IList<Models.Card> value)
            {
                cards = value;
                return this;
            }

            public Builder GivenName(string value)
            {
                givenName = value;
                return this;
            }

            public Builder FamilyName(string value)
            {
                familyName = value;
                return this;
            }

            public Builder Nickname(string value)
            {
                nickname = value;
                return this;
            }

            public Builder CompanyName(string value)
            {
                companyName = value;
                return this;
            }

            public Builder EmailAddress(string value)
            {
                emailAddress = value;
                return this;
            }

            public Builder Address(Models.Address value)
            {
                address = value;
                return this;
            }

            public Builder PhoneNumber(string value)
            {
                phoneNumber = value;
                return this;
            }

            public Builder Birthday(string value)
            {
                birthday = value;
                return this;
            }

            public Builder ReferenceId(string value)
            {
                referenceId = value;
                return this;
            }

            public Builder Note(string value)
            {
                note = value;
                return this;
            }

            public Builder Preferences(Models.CustomerPreferences value)
            {
                preferences = value;
                return this;
            }

            public Builder Groups(IList<Models.CustomerGroupInfo> value)
            {
                groups = value;
                return this;
            }

            public Builder CreationSource(string value)
            {
                creationSource = value;
                return this;
            }

            public Builder GroupIds(IList<string> value)
            {
                groupIds = value;
                return this;
            }

            public Builder SegmentIds(IList<string> value)
            {
                segmentIds = value;
                return this;
            }

            public Customer Build()
            {
                return new Customer(id,
                    createdAt,
                    updatedAt,
                    cards,
                    givenName,
                    familyName,
                    nickname,
                    companyName,
                    emailAddress,
                    address,
                    phoneNumber,
                    birthday,
                    referenceId,
                    note,
                    preferences,
                    groups,
                    creationSource,
                    groupIds,
                    segmentIds);
            }
        }
    }
}