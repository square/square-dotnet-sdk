using NUnit.Framework;
using Square.Apis;
using Square.Exceptions;
using Square.Models;
using System.IO;
using System;

namespace Square.Tests
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

        private static readonly CreateCustomerRequest TestCreateCustomerRequest = new CreateCustomerRequest.Builder()
            .GivenName(TestGivenName)
            .FamilyName(TestFamilyName)
            .Address(TestAddress)
            .Build();

        private static readonly Address TestUpdateAddress = new Address.Builder()
            .AddressLine1(TestAddressLine1)
            .AddressLine2(TestUpdateAddressLine2)
            .Build();

        private static readonly UpdateCustomerRequest TestUpdateCustomerRequest = new UpdateCustomerRequest.Builder()
            .GivenName(TestGivenName)
            .FamilyName(TestUpdateFamilyName)
            .Address(TestUpdateAddress)
            .Build();

        [SetUp]
        public void Init()
        {
        }

        [TearDown]
        public void Cleanup()
        {
        }

        [Test]
        public void TestReturnApiType()
        {
            Assert.IsInstanceOf<LocationsApi>(client.LocationsApi);
            Assert.IsInstanceOf<V1LocationsApi>(client.V1LocationsApi);
        }

        [Test]
        public void TestResponse()
        {
            var api = client.LocationsApi;
            var res = api.ListLocations();
            Assert.AreEqual(res.Context.Response.StatusCode, 200);
        }

        private string GenerateIdempotencyKey()
        {
            return Guid.NewGuid().ToString();
        }

        [Test]
        public void TestFileUpload()
        {   
            var api = client.CatalogApi;

            CreateCatalogImageRequest request = new CreateCatalogImageRequest.Builder(GenerateIdempotencyKey())
                .Image(new CatalogObject.Builder("IMAGE", "#dotnet_sdk_test")
                        .ImageData(new Models.CatalogImage.Builder()
                        .Caption("Image for Test File Upload")
                        .Build()
                    )
                    .Build()
                )
                .Build();
            
            // Using MemoryStream instead of FileStream for testing purpose
            var response = api.CreateCatalogImage(request, new Http.Client.FileStreamInfo(new MemoryStream()));
            Assert.IsNotNull(response.Image.ImageData.Url);

            // Clean up the test
            var createdImageId = response.Image.Id;
            api.DeleteCatalogObject(createdImageId);
        }

        // We are addressing an issue associated with this test at the moment 20191202
        [Test] 
        public void TestV2APIException()
        {
            SquareClient badClient = new SquareClient.Builder()
            .Environment(Environment.Sandbox)
            .AccessToken("BAD_TOKEN")
            .Build();

            var api = badClient.CustomersApi;
            var ex = Assert.Throws<ApiException>(() => api.ListCustomers());
            Assert.AreEqual(ex.ResponseCode, 401);


            var errors = ex.Errors;

            Assert.AreEqual(errors[0].Category, "AUTHENTICATION_ERROR");
            Assert.AreEqual(errors[0].Code, "UNAUTHORIZED");
            Assert.AreEqual(errors[0].Detail, "The `Authorization` http header of your request was malformed. The header value is expected to be of the format \"Bearer TOKEN\" (without quotation marks), where TOKEN is to be replaced with your access token (e.g. \"Bearer ABC123def456GHI789jkl0\"). For more information, see https://docs.connect.squareup.com/api/connect/v2/#requestandresponseheaders. If you are seeing this error message while using one of our officially supported SDKs, please report this to developers@squareup.com.");
        }

        [Test]
        public void TestV1APIException()
        {
            SquareClient badClient = new SquareClient.Builder()
            .Environment(Environment.Production)
            .AccessToken("BAD_TOKEN")
            .Build();

            var api = badClient.V1LocationsApi;

            var ex = Assert.Throws<ApiException>(() => api.ListLocations());
            Assert.AreEqual(ex.ResponseCode, 401);

            var errors = ex.Errors;

            Assert.AreEqual(errors[0].Category, "V1_ERROR");
            Assert.AreEqual(errors[0].Code, "service.not_authorized");
            Assert.AreEqual(errors[0].Detail, "Not Authorized");
        }

        [Test]
        public void TestCustomersCycle()
        {
            var api = client.CustomersApi;

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
            var updateCustomerRes = api.UpdateCustomer(createdCustomerId, TestUpdateCustomerRequest);
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