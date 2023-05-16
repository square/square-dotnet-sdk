namespace Square.Apis
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using Square;
    using Square.Authentication;
    using Square.Http.Client;
    using Square.Utilities;
    using System.Net.Http;

    /// <summary>
    /// MerchantsApi.
    /// </summary>
    internal class MerchantsApi : BaseApi, IMerchantsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantsApi"/> class.
        /// </summary>
        internal MerchantsApi(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Provides details about the merchant associated with a given access token.
        /// The access token used to connect your application to a Square seller is associated.
        /// with a single merchant. That means that `ListMerchants` returns a list.
        /// with a single `Merchant` object. You can specify your personal access token.
        /// to get your own merchant information or specify an OAuth token to get the.
        /// information for the merchant that granted your application access.
        /// If you know the merchant ID, you can also use the [RetrieveMerchant]($e/Merchants/RetrieveMerchant).
        /// endpoint to retrieve the merchant information.
        /// </summary>
        /// <param name="cursor">Optional parameter: The cursor generated by the previous response..</param>
        /// <returns>Returns the Models.ListMerchantsResponse response from the API call.</returns>
        public Models.ListMerchantsResponse ListMerchants(
                int? cursor = null)
            => CoreHelper.RunTask(ListMerchantsAsync(cursor));

        /// <summary>
        /// Provides details about the merchant associated with a given access token.
        /// The access token used to connect your application to a Square seller is associated.
        /// with a single merchant. That means that `ListMerchants` returns a list.
        /// with a single `Merchant` object. You can specify your personal access token.
        /// to get your own merchant information or specify an OAuth token to get the.
        /// information for the merchant that granted your application access.
        /// If you know the merchant ID, you can also use the [RetrieveMerchant]($e/Merchants/RetrieveMerchant).
        /// endpoint to retrieve the merchant information.
        /// </summary>
        /// <param name="cursor">Optional parameter: The cursor generated by the previous response..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ListMerchantsResponse response from the API call.</returns>
        public async Task<Models.ListMerchantsResponse> ListMerchantsAsync(
                int? cursor = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ListMerchantsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/merchants")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("cursor", cursor))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.ListMerchantsResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Retrieves the `Merchant` object for the given `merchant_id`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the merchant to retrieve. If the string "me" is supplied as the ID, then retrieve the merchant that is currently accessible to this call..</param>
        /// <returns>Returns the Models.RetrieveMerchantResponse response from the API call.</returns>
        public Models.RetrieveMerchantResponse RetrieveMerchant(
                string merchantId)
            => CoreHelper.RunTask(RetrieveMerchantAsync(merchantId));

        /// <summary>
        /// Retrieves the `Merchant` object for the given `merchant_id`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the merchant to retrieve. If the string "me" is supplied as the ID, then retrieve the merchant that is currently accessible to this call..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveMerchantResponse response from the API call.</returns>
        public async Task<Models.RetrieveMerchantResponse> RetrieveMerchantAsync(
                string merchantId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.RetrieveMerchantResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/v2/merchants/{merchant_id}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("merchant_id", merchantId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ContextAdder((_result, _context) => _result.ContextSetter(_context))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.RetrieveMerchantResponse>(_response)))
              .ExecuteAsync(cancellationToken);
    }
}