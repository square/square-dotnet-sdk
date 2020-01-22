using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square;
using Square.Utilities;
using Square.Http.Request;
using Square.Http.Response;
using Square.Http.Client;

namespace Square.Apis
{
    public interface IV1LocationsApi
    {
        /// <summary>
        /// Get the general information for a business.
        /// ---
        /// - __Deprecation date__: 2019-11-20
        /// - [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
        /// - [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)
        /// ---
        /// </summary>
        /// <return>Returns the Models.V1Merchant response from the API call</return>
        [Obsolete]
        Models.V1Merchant RetrieveBusiness();

        /// <summary>
        /// Get the general information for a business.
        /// ---
        /// - __Deprecation date__: 2019-11-20
        /// - [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
        /// - [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)
        /// ---
        /// </summary>
        /// <return>Returns the Models.V1Merchant response from the API call</return>
        [Obsolete]
        Task<Models.V1Merchant> RetrieveBusinessAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Provides details for all business locations associated with a Square
        /// account, including the Square-assigned object ID for the location.
        /// ---
        /// - __Deprecation date__: 2019-11-20
        /// - [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
        /// - [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)
        /// ---
        /// </summary>
        /// <return>Returns the List<Models.V1Merchant> response from the API call</return>
        [Obsolete]
        List<Models.V1Merchant> ListLocations();

        /// <summary>
        /// Provides details for all business locations associated with a Square
        /// account, including the Square-assigned object ID for the location.
        /// ---
        /// - __Deprecation date__: 2019-11-20
        /// - [__Retirement date__](https://developer.squareup.com/docs/build-basics/api-lifecycle#deprecated): 2020-11-18
        /// - [Migration guide](https://developer.squareup.com/docs/migrate-from-v1/guides/v1-locations)
        /// ---
        /// </summary>
        /// <return>Returns the List<Models.V1Merchant> response from the API call</return>
        [Obsolete]
        Task<List<Models.V1Merchant>> ListLocationsAsync(CancellationToken cancellationToken = default);

    }
}