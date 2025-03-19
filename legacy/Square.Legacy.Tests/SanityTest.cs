using System;
using System.IO;
using NUnit.Framework;
using Square.Legacy.Apis;
using Square.Legacy.Authentication;
using Square.Legacy.Exceptions;
using Square.Legacy.Models;

namespace Square.Legacy.Tests
{
    [TestFixture]
    public class SanityTest : ApiTestBase
    {
        private static readonly string TestGivenName = "John";
        private static readonly string TestFamilyName = "Smith";
        private static readonly string TestAddressLine1 = "1455 Market St";
        private static readonly string TestAddressLine2 = "San Francisco, CA 94103";

        private static readonly string TestUpdateFamilyName = "Jackson";
        private static readonly string TestUpdateAddressLine2 = "Seattle, WA";

        private static readonly Address TestAddress = new Address.Builder()
            .AddressLine1(TestAddressLine1)
            .AddressLine2(TestAddressLine2)
            .Build();

        private static readonly CreateCustomerRequest TestCreateCustomerRequest =
            new CreateCustomerRequest.Builder()
                .GivenName(TestGivenName)
                .FamilyName(TestFamilyName)
                .Address(TestAddress)
                .Build();

        private static readonly Address TestUpdateAddress = new Address.Builder()
            .AddressLine1(TestAddressLine1)
            .AddressLine2(TestUpdateAddressLine2)
            .Build();

        private static readonly UpdateCustomerRequest TestUpdateCustomerRequest =
            new UpdateCustomerRequest.Builder()
                .GivenName(TestGivenName)
                .FamilyName(TestUpdateFamilyName)
                .Address(TestUpdateAddress)
                .Build();

        [SetUp]
        public void Init() { }

        [TearDown]
        public void Cleanup() { }

        [Test]
        public void TestReturnApiType()
        {
            Assert.IsInstanceOf<LocationsApi>(this.Client.LocationsApi);
        }

        [Test]
        public void TestResponse()
        {
            var api = this.Client.LocationsApi;
            var res = api.ListLocations();
            Assert.AreEqual(res.Context.Response.StatusCode, 200);
        }

        private string GenerateIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }

        private CatalogObject GenerateCatalogImage()
        {
            return new CatalogObject.Builder("IMAGE", "#dotnet_sdk_test")
                .ImageData(
                    new Models.CatalogImage.Builder().Caption("Image for Test File Upload").Build()
                )
                .Build();
        }

        [Test]
        public void TestFileUpload()
        {
            var api = this.Client.CatalogApi;

            CreateCatalogImageRequest request = new CreateCatalogImageRequest.Builder(
                GenerateIdempotencyKey(),
                GenerateCatalogImage()
            ).Build();

            using (FileStream fs = File.OpenRead("../../../resources/square.png"))
            {
                var response = api.CreateCatalogImage(request, new Http.Client.FileStreamInfo(fs));
                Assert.IsNotNull(response.Image.ImageData.Url);

                // Clean up the test
                var createdImageId = response.Image.Id;
                api.DeleteCatalogObject(createdImageId);
            }
        }

        // We are addressing an issue associated with this test at the moment 20191202
        [Test]
        public void TestV2APIException()
        {
            SquareClient badClient = new SquareClient.Builder()
                .Environment(Environment.Sandbox)
                .BearerAuthCredentials(new BearerAuthModel.Builder("BAD_TOKEN").Build())
                .Build();

            var api = badClient.LocationsApi;
            var ex = Assert.Throws<ApiException>(() => api.ListLocations());
            Assert.AreEqual(ex.ResponseCode, 401);

            var errors = ex.Errors;

            Assert.AreEqual(errors[0].Category, "AUTHENTICATION_ERROR");
            Assert.AreEqual(errors[0].Code, "UNAUTHORIZED");
        }

        [Test]
        public void TestCustomersCycle()
        {
            var api = this.Client.CustomersApi;

            // Create Customer
            var createCustomerRes = api.CreateCustomer(TestCreateCustomerRequest);
            var createdCustomer = createCustomerRes.Customer;
            var createdCustomerId = createdCustomer.Id;
            Assert.AreEqual(createdCustomer.Address.AddressLine1, TestAddressLine1);
            Assert.AreEqual(createdCustomer.Address.AddressLine2, TestAddressLine2);
            Assert.AreEqual(createdCustomer.GivenName, TestGivenName);
            Assert.AreEqual(createdCustomer.FamilyName, TestFamilyName);

            // Retrieve Customer
            var retrieveCustomerRes = api.RetrieveCustomer(createdCustomerId);
            var retrieveCustomer = retrieveCustomerRes.Customer;
            Assert.AreEqual(retrieveCustomer.Address.AddressLine1, TestAddressLine1);
            Assert.AreEqual(retrieveCustomer.Address.AddressLine2, TestAddressLine2);
            Assert.AreEqual(retrieveCustomer.GivenName, TestGivenName);
            Assert.AreEqual(retrieveCustomer.FamilyName, TestFamilyName);

            // List Customer
            var listCustomersRes = api.ListCustomers();

            // Update Customer
            var updateCustomerRes = api.UpdateCustomer(
                createdCustomerId,
                TestUpdateCustomerRequest
            );
            var updatedCustomer = updateCustomerRes.Customer;
            Assert.AreEqual(updatedCustomer.Address.AddressLine1, TestAddressLine1);
            Assert.AreEqual(updatedCustomer.Address.AddressLine2, TestUpdateAddressLine2);
            Assert.AreEqual(updatedCustomer.GivenName, TestGivenName);
            Assert.AreEqual(updatedCustomer.FamilyName, TestUpdateFamilyName);

            // Delete Customer
            var deleteCustomerRes = api.DeleteCustomer(createdCustomerId);
            Assert.AreEqual(deleteCustomerRes.Errors, null);
        }
    }
}
