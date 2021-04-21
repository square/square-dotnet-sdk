namespace Square
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Converters;
    using NUnit.Framework;
    using Square;
    using Square.Apis;
    using Square.Exceptions;
    using Square.Helpers;
    using Square.Http.Client;
    using Square.Http.Response;
    using Square.Utilities;

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
        /// Provides information of all locations of a business.
        ///
        ///Many Square API endpoints require a `location_id` parameter.
        ///The `id` field of the [`Location`]($m/Location) objects returned by this
        ///endpoint correspond to that `location_id` parameter..
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
            Assert.AreEqual(200, this.HttpCallBackHandler.Response.StatusCode, "Status should be 200");
        }
    }
}