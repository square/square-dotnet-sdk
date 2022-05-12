using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Square.Apis;
using Square.Models;
using Square.Utilities;

namespace Square.Tests.Flows
{
    [TestFixture]
    public class CustomersApiFlowTest : ApiTestBase
    {
        private const string CUSTOM_ATTRIBUTE_KEY = "favorite-drink";
        private const string PHONE_NUMBER = "1-212-555-4240";
        private const string POSTAL_CODE = "10003";

        private ICustomersApi controller;
        private ICustomerCustomAttributesApi customAttributesApi;

        private static List<string> _createdCustomerIds = new List<string>();

        [SetUp]
        public async Task Setup()
        {
            this.controller = this.Client.CustomersApi;
            this.customAttributesApi = this.Client.CustomerCustomAttributesApi;

            await DeleteCustomerCustomAttributeDefinition();
        }

        [TearDown]
        public async Task Teardown()
        {
            // Catch any exceptions and try the next record, we will clean up what we can.
            // If anything exists by this point, the test has failed.

            foreach (var customerId in _createdCustomerIds) 
            {
                try
                {
                    await DeleteCustomer(customerId);
                }
                catch {}
            }
            try 
            {
                await DeleteCustomerCustomAttributeDefinition();
            }
            catch {}
        }

        /**
         * A test that goes through the full flow of creating a customer, retrieving and updating,
         * adding and updating custom attribute data, and deleting.
         */
        [Test]
        public async Task CustomerFlowTest()
        {
            var customer = await CreateCustomer();
            await GetCustomer(customer.Id);
            await UpdateCustomer(customer);
            var customAttributeDefinition = await CreateCustomerCustomAttributeDefinition();
            var customAttribute = await CreateCustomerCustomAttribute(customer.Id);
            await UpdateCustomerCustomAttribute(customer.Id, customAttribute);
            await DeleteCustomer(customer.Id);
            await DeleteCustomerCustomAttributeDefinition();
        }

        private async Task<Customer> CreateCustomer()
        {
            var body = new CreateCustomerRequest(
                givenName: "Amelia",
                familyName: "Earhart",
                address: new Address
                (
                    addressLine1: "500 Electric Ave",
                    addressLine2: "Suite 600",
                    locality: "New York",
                    administrativeDistrictLevel1: "NY",
                    postalCode: POSTAL_CODE,
                    country: "US"
                ),
                phoneNumber: PHONE_NUMBER,
                note: "a customer"
            );
            
            var response = await this.controller.CreateCustomerAsync(body);
            _createdCustomerIds.Add(response.Customer?.Id);

            Assert.IsNull(response.Errors);
            Assert.AreEqual(200, response.Context.Response.StatusCode);

            var customer = response.Customer;

            Assert.AreEqual(PHONE_NUMBER, customer.PhoneNumber);
            Assert.AreEqual(POSTAL_CODE, customer.Address.PostalCode);

            return customer;
        }

        private async Task GetCustomer(string customerId)
        {
            var response = await controller.RetrieveCustomerAsync(customerId);

            Assert.IsNull(response.Errors);
            Assert.AreEqual(200, response.Context.Response.StatusCode);

            Assert.AreEqual(PHONE_NUMBER, response.Customer.PhoneNumber);
            Assert.AreEqual(POSTAL_CODE, response.Customer.Address.PostalCode);
        }

        private async Task UpdateCustomer(Customer prevData)
        {
            var newAddress = prevData.Address.ToBuilder().PostalCode("98100");

            var body = new UpdateCustomerRequest(
                phoneNumber: "1-917-500-1000",
                address: newAddress.Build()
            );

            var response = await controller.UpdateCustomerAsync(prevData.Id, body);

            Assert.IsNull(response.Errors);
            Assert.AreEqual(200, response.Context.Response.StatusCode);

            Assert.AreEqual("1-917-500-1000", response.Customer.PhoneNumber);
            Assert.AreEqual("98100", response.Customer.Address.PostalCode);
        }

        /**
         * Delete the `favorite-drink` definition if it exists
         */
        private async Task DeleteCustomerCustomAttributeDefinition()
        {
            var response = await customAttributesApi.DeleteCustomerCustomAttributeDefinitionAsync(CUSTOM_ATTRIBUTE_KEY);

            Assert.IsNull(response.Errors);
            Assert.AreEqual(200, response.Context.Response.StatusCode);
        }

        private async Task<CustomAttributeDefinition> CreateCustomerCustomAttributeDefinition()
        {
            var body = new CreateCustomerCustomAttributeDefinitionRequest(
                new CustomAttributeDefinition(
                    key: CUSTOM_ATTRIBUTE_KEY,
                    schema: JsonObject.FromJsonString("{\"$ref\":\"https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String\"}"),
                    name: "Favorite Drink",
                    description: "The customer's favorite drink",
                    visibility: "VISIBILITY_READ_WRITE_VALUES"
                )
            );

            var response = await customAttributesApi.CreateCustomerCustomAttributeDefinitionAsync(body);

            Assert.IsNull(response.Errors);
            Assert.AreEqual(200, response.Context.Response.StatusCode);

            Assert.AreEqual(CUSTOM_ATTRIBUTE_KEY, response.CustomAttributeDefinition.Key);
            Assert.AreEqual("Favorite Drink", response.CustomAttributeDefinition.Name);
            Assert.AreEqual("The customer's favorite drink", response.CustomAttributeDefinition.Description);
            Assert.NotNull(response.CustomAttributeDefinition.SourceApplication?.ApplicationId);
            Assert.AreEqual("VISIBILITY_READ_WRITE_VALUES", response.CustomAttributeDefinition.Visibility);
            Assert.AreEqual(1, response.CustomAttributeDefinition.Version);
            Assert.AreEqual("{\"$ref\":\"https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String\"}", response.CustomAttributeDefinition.Schema.ToString());

            return response.CustomAttributeDefinition;
        }

        private async Task<CustomAttribute> CreateCustomerCustomAttribute(string customerId)
        {
            var body = new UpsertCustomerCustomAttributeRequest(
                new CustomAttribute(
                    mValue: JsonValue.FromString("Double-shot breve")
                )
            );
            var response = await customAttributesApi.UpsertCustomerCustomAttributeAsync(customerId, CUSTOM_ATTRIBUTE_KEY, body);

            Assert.IsNull(response.Errors);
            Assert.AreEqual(200, response.Context.Response.StatusCode);

            Assert.AreEqual(CUSTOM_ATTRIBUTE_KEY, response.CustomAttribute.Key);
            Assert.AreEqual("\"Double-shot breve\"", response.CustomAttribute.MValue.ToString());
            Assert.AreEqual(1, response.CustomAttribute.Version);
            Assert.AreEqual("VISIBILITY_READ_WRITE_VALUES", response.CustomAttribute.Visibility);
            
            return response.CustomAttribute;
        }

        private async Task UpdateCustomerCustomAttribute(string customerId, CustomAttribute created)
        {
            var body = new UpsertCustomerCustomAttributeRequest(
                new CustomAttribute(
                    mValue: JsonValue.FromString("Black coffee"),
                    version: created.Version
                )
            );
            var response = await customAttributesApi.UpsertCustomerCustomAttributeAsync(customerId, CUSTOM_ATTRIBUTE_KEY, body);

            Assert.IsNull(response.Errors);
            Assert.AreEqual(200, response.Context.Response.StatusCode);

            Assert.AreEqual(CUSTOM_ATTRIBUTE_KEY, response.CustomAttribute.Key);
            Assert.AreEqual("\"Black coffee\"", response.CustomAttribute.MValue.ToString());
            Assert.AreEqual(2, response.CustomAttribute.Version);
            Assert.AreEqual("VISIBILITY_READ_WRITE_VALUES", response.CustomAttribute.Visibility);
        }

        private async Task DeleteCustomer(string customerId)
        {
            var response = await controller.DeleteCustomerAsync(customerId);
            Assert.IsNull(response.Errors);
            Assert.AreEqual(200, response.Context.Response.StatusCode);
        }
    }
}