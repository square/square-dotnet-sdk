using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Square.Legacy;
using Square.Legacy.Http.Client;
using Square.Legacy.Http.Request;
using Square.Legacy.Http.Response;
using Square.Legacy.Utilities;

namespace Square.Legacy.Apis
{
    /// <summary>
    /// IMerchantsApi.
    /// </summary>
    public interface IMerchantsApi
    {
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
        Models.ListMerchantsResponse ListMerchants(int? cursor = null);

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
        Task<Models.ListMerchantsResponse> ListMerchantsAsync(
            int? cursor = null,
            CancellationToken cancellationToken = default
        );

        /// <summary>
        /// Retrieves the `Merchant` object for the given `merchant_id`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the merchant to retrieve. If the string "me" is supplied as the ID, then retrieve the merchant that is currently accessible to this call..</param>
        /// <returns>Returns the Models.RetrieveMerchantResponse response from the API call.</returns>
        Models.RetrieveMerchantResponse RetrieveMerchant(string merchantId);

        /// <summary>
        /// Retrieves the `Merchant` object for the given `merchant_id`.
        /// </summary>
        /// <param name="merchantId">Required parameter: The ID of the merchant to retrieve. If the string "me" is supplied as the ID, then retrieve the merchant that is currently accessible to this call..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.RetrieveMerchantResponse response from the API call.</returns>
        Task<Models.RetrieveMerchantResponse> RetrieveMerchantAsync(
            string merchantId,
            CancellationToken cancellationToken = default
        );
    }
}
