using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using APIMatic.Core.Utilities;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using Square;
using Square.Apis;
using Square.Exceptions;
using Square.Http.Client;
using Square.Http.Response;
using Square.Utilities;

namespace Square
{
    /// <summary>
    /// LocationsApiTest.
    /// </summary>
    [TestFixture]
    public class LocationsApiTest : ApiTestBase
    {
        /// <summary>
        /// Controller instance (for all tests).
        /// </summary>
        private ILocationsApi controller;

        /// <summary>
        /// Setup test class.
        /// </summary>
        [OneTimeSetUp]
        public void SetUpDerived()
        {
            this.controller = this.Client.LocationsApi;
        }

        /// <summary>
        /// Provides details about all of the seller's [locations](https://developer.squareup.com/docs/locations-api),
        ///including those with an inactive status. Locations are listed alphabetically by `name`..
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task TestListLocations()
        {
            // Perform API call
            Models.ListLocationsResponse result = null;
            try
            {
                result = await this.controller.ListLocationsAsync();
            }
            catch (ApiException)
            {
            }

            // Test response code
            Assert.AreEqual(200, HttpCallBack.Response.StatusCode, "Status should be 200");
        }
    }
}