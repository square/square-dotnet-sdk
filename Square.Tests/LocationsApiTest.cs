using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using Square;
using Square.Utilities; 
using Square.Http.Client;
using Square.Http.Response;
using Square.Helpers;
using NUnit.Framework;
using Square.Apis;
using Square.Exceptions;

namespace Square
{
    [TestFixture]
    public class LocationsApiTest : ApiTestBase
    {
        /// <summary>
        /// Controller instance (for all tests)
        /// </summary>
        private ILocationsApi controller;

        /// <summary>
        /// Setup test class
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            controller = client.LocationsApi;
        }

        /// <summary>
        /// Provides information of all locations of a business.
        ///
        ///Most other Connect API endpoints have a required `location_id` path parameter.
        ///The `id` field of the [`Location`](#type-location) objects returned by this
        ///endpoint correspond to that `location_id` parameter. 
        /// </summary>
        [Test]
        public async Task TestListLocations() 
        {

            // Perform API call
            Models.ListLocationsResponse result = null;

            try
            {
                result = await controller.ListLocationsAsync();
            }
            catch(ApiException) {}

            // Test response code
            Assert.AreEqual(200, httpCallBackHandler.Response.StatusCode,
                    "Status should be 200");

        }

    }
}