using System;
using System.Security.Cryptography;
using System.Text;

namespace Square.Utilities
{
    /// <summary>
    /// Utility code to help with <a href="https://developer.squareup.com/docs/webhooks/overview">Square Webhooks</a>.
    /// </summary>
    public static class WebhooksHelper
    {
        /// <summary>
        /// Verify and Validate an Event Notification. See 
        /// <a href="https://developer.squareup.com/docs/webhooks/step3validate">documentation</a> for more details.
        /// </summary>
        /// <param name="requestBody">The JSON body of the request.</param>
        /// <param name="signatureHeader">The value for the <c>x-square-hmacsha256-signature</c> header.</param>
        /// <param name="signatureKey">The signature key from the Square Developer portal for the webhook subscription.</param>
        /// <param name="notificationUrl">The notification endpoint URL as defined in the Square Developer portal for the webhook subscription.</param>
        /// <returns>
        /// <c>true</c> if the signature is valid, indicating that the event can be trusted as it came from Square.
        /// <c>false</c> if the signature validation fails, indicating the event did not come from Square so may be malicious and should be discarded.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="signatureKey"/> or <paramref name="notificationUrl"/> are not set.
        /// </exception>
        /// <remarks>
        /// <example>
        /// For example, if you wanted to verify a webhook notification that was sent to an ASP.NET endpoint
        /// in your app, you could do the following:
        /// <code>
        /// public static async System.Threading.Tasks.Task CheckWebhooksEvent(
        ///     Microsoft.AspNetCore.Http.HttpRequest request,
        ///     string signatureKey,
        ///     string notificationUrl
        /// )
        /// {
        ///     var signature = request.Headers["x-square-hmacsha256-signature"].ToString();
        ///     using (var reader = new System.IO.StreamReader(request.Body, System.Text.Encoding.UTF8))
        ///     {
        ///         var requestBody = await reader.ReadToEndAsync();
        ///         if (!WebhooksHelper.IsValidWebhookEventSignature(requestBody, signature, signatureKey, notificationUrl))
        ///         {
        ///             // TODO handle malicious request appropriately
        ///             throw new System.Exception("A webhook event was received that was not from Square.");
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        /// </remarks>
        public static bool IsValidWebhookEventSignature(string requestBody, string signatureHeader, string signatureKey, string notificationUrl)
        {
            if (string.IsNullOrEmpty(signatureKey))
            {
                throw new ArgumentNullException(nameof(signatureKey));
            }
            if (string.IsNullOrEmpty(notificationUrl))
            {
                throw new ArgumentNullException(nameof(notificationUrl));
            }

            var payload = $"{notificationUrl}{requestBody}";
            var payloadBytes = Encoding.UTF8.GetBytes(payload);
            var secret = Encoding.UTF8.GetBytes(signatureKey);

            using (var hmac = new HMACSHA256(secret))
            {
                var hash = hmac.ComputeHash(payloadBytes);
                var hashString = Convert.ToBase64String(hash);
                return hashString.Equals(signatureHeader);
            }
        }
    }
}
