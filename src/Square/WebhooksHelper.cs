using System.Security.Cryptography;
using System.Text;

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract

namespace Square;

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
    ///         if (!WebhooksHelper.VerifySignature(requestBody, signature, signatureKey, notificationUrl))
    ///         {
    ///             throw new System.Exception("A webhook event was received that was not from Square.");
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </remarks>
    public static bool VerifySignature(
        string requestBody,
        string signatureHeader,
        string signatureKey,
        string notificationUrl
    )
    {
        if (string.IsNullOrEmpty(signatureKey))
        {
            throw new ArgumentNullException(nameof(signatureKey));
        }

        if (string.IsNullOrEmpty(notificationUrl))
        {
            throw new ArgumentNullException(nameof(notificationUrl));
        }

        if (signatureHeader is null)
        {
            return false;
        }

#if NET6_0_OR_GREATER
        return VerifySignature(
            requestBody.AsSpan(),
            signatureHeader.AsSpan(),
            signatureKey.AsSpan(),
            notificationUrl.AsSpan()
        );
#else
        return VerifySignatureOld(requestBody, signatureHeader, signatureKey, notificationUrl);
#endif
    }

    internal static bool VerifySignatureOld(
        string requestBody,
        string signatureHeader,
        string signatureKey,
        string notificationUrl
    )
    {
        // Step 1: concatenate the notification URL and the request body and get bytes
        var payload = $"{notificationUrl}{requestBody}";
        var payloadBytes = Encoding.UTF8.GetBytes(payload);

        // Step 2: Get bytes for secret
        var secret = Encoding.UTF8.GetBytes(signatureKey);

        // Step 3: Compute hash
        using var hmac = new HMACSHA256(secret);
        var hash = hmac.ComputeHash(payloadBytes);

        // Step 4: Decode the signature header from Base64
        byte[] signatureBytes;
        try
        {
            signatureBytes = Convert.FromBase64String(signatureHeader);
        }
        catch (FormatException)
        {
            // Invalid Base64 string
            return false;
        }

        // Step 5: Compare the signature header to the hash using constant-time comparison
        return CryptographicEqual(hash, signatureBytes);
    }

    /// <summary>
    /// Compares two byte arrays in constant time to prevent timing attacks.
    /// </summary>
    /// <param name="a">The first byte array to compare.</param>
    /// <param name="b">The second byte array to compare.</param>
    /// <returns>True if the arrays are equal, false otherwise.</returns>
    private static bool CryptographicEqual(byte[] a, byte[] b)
    {
        // If either array is null or their lengths differ, they can't be equal
        if (a is null || b is null || a.Length != b.Length)
        {
            return false;
        }

        // Different from standard equality check - we always check ALL bytes
        // regardless of whether we've already found a difference
        var result = 0;
        for (var i = 0; i < a.Length; i++)
        {
            // XOR each byte pair and OR the result
            // Any difference makes result non-zero
            result |= a[i] ^ b[i];
        }

        // Only if all bytes were identical will result still be zero
        return result == 0;
    }

#if NET6_0_OR_GREATER
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
    ///     // Get the signature header
    ///     var signature = request.Headers["x-square-hmacsha256-signature"].ToString();
    ///
    ///     // Read the request body
    ///     using (var reader = new System.IO.StreamReader(request.Body, System.Text.Encoding.UTF8))
    ///     {
    ///         var requestBody = await reader.ReadToEndAsync();
    ///
    ///         // Use the span-based verification method
    ///         if (!WebhooksHelper.VerifySignature(
    ///             requestBody.AsSpan(),
    ///             signature.AsSpan(),
    ///             signatureKey.AsSpan(),
    ///             notificationUrl.AsSpan()))
    ///         {
    ///             throw new System.Exception("A webhook event was received that was not from Square.");
    ///         }
    ///     }
    ///
    ///     // Reset stream position if needed
    ///     if (request.Body.CanSeek)
    ///     {
    ///         request.Body.Position = 0;
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </remarks>
    public static bool VerifySignature(
        ReadOnlySpan<char> requestBody,
        ReadOnlySpan<char> signatureHeader,
        ReadOnlySpan<char> signatureKey,
        ReadOnlySpan<char> notificationUrl
    )
    {
        // Convert request body to bytes
        Span<byte> requestBodyBytes = stackalloc byte[Encoding.UTF8.GetByteCount(requestBody)];
        Encoding.UTF8.GetBytes(requestBody, requestBodyBytes);

        // Convert signature header to bytes
        Span<byte> signatureHeaderBytes =
            stackalloc byte[Encoding.UTF8.GetByteCount(signatureHeader)];
        Encoding.UTF8.GetBytes(signatureHeader, signatureHeaderBytes);

        // Convert signature key to bytes
        Span<byte> signatureKeyBytes = stackalloc byte[Encoding.UTF8.GetByteCount(signatureKey)];
        Encoding.UTF8.GetBytes(signatureKey, signatureKeyBytes);

        // Convert notification URL to bytes
        Span<byte> notificationUrlBytes =
            stackalloc byte[Encoding.UTF8.GetByteCount(notificationUrl)];
        Encoding.UTF8.GetBytes(notificationUrl, notificationUrlBytes);

        // Delegate to the byte-based implementation
        return VerifySignature(
            requestBodyBytes,
            signatureHeaderBytes,
            signatureKeyBytes,
            notificationUrlBytes
        );
    }

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
    ///     // Get the signature header
    ///     var signature = request.Headers["x-square-hmacsha256-signature"].ToString();
    ///
    ///     // Read the request body directly into a memory stream
    ///     using var memoryStream = new System.IO.MemoryStream();
    ///     await request.Body.CopyToAsync(memoryStream);
    ///     memoryStream.Position = 0;
    ///
    ///     // Get a span over the raw bytes
    ///     ReadOnlySpan&lt;byte&gt; bodyBytes = memoryStream.GetBuffer().AsSpan(0, (int)memoryStream.Length);
    ///
    ///     // Convert signature header to bytes
    ///     byte[] signatureBytes = System.Text.Encoding.UTF8.GetBytes(signature);
    ///     byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(signatureKey);
    ///     byte[] urlBytes = System.Text.Encoding.UTF8.GetBytes(notificationUrl);
    ///
    ///     // Use the byte-based verification method
    ///     if (!WebhooksHelper.VerifySignature(
    ///         bodyBytes,
    ///         signatureBytes,
    ///         keyBytes,
    ///         urlBytes))
    ///     {
    ///         throw new System.Exception("A webhook event was received that was not from Square.");
    ///     }
    ///
    ///     // Reset stream position if needed
    ///     if (request.Body.CanSeek)
    ///     {
    ///         request.Body.Position = 0;
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </remarks>
    public static bool VerifySignature(
        ReadOnlySpan<byte> requestBody,
        ReadOnlySpan<byte> signatureHeader,
        ReadOnlySpan<byte> signatureKey,
        ReadOnlySpan<byte> notificationUrl
    )
    {
        // Step 1: Concatenate the notification URL and request body bytes
        var urlLength = notificationUrl.Length;
        var bodyLength = requestBody.Length;
        var totalLength = urlLength + bodyLength;

        // Allocate a buffer for the combined payload
        Span<byte> payloadBytes = stackalloc byte[totalLength];

        // Copy both parts directly into the buffer
        notificationUrl.CopyTo(payloadBytes);
        requestBody.CopyTo(payloadBytes.Slice(urlLength));

        // Step 2: Compute the hash
        Span<byte> hashBytes = stackalloc byte[32]; // SHA256 produces 32 bytes
        HMACSHA256.HashData(signatureKey, payloadBytes, hashBytes);

        // Step 3: Convert signature header bytes to char span for Base64 decoding
        // This step is necessary because TryFromBase64Chars works with char spans
        Span<char> signatureChars = stackalloc char[Encoding.UTF8.GetCharCount(signatureHeader)];
        Encoding.UTF8.GetChars(signatureHeader, signatureChars);

        // Step 4: Decode the signature from Base64
        Span<byte> decodedHeader = stackalloc byte[32]; // SHA256 produces 32 bytes
        if (Convert.TryFromBase64Chars(signatureChars, decodedHeader, out var bytesWritten))
        {
            // Step 5: Compare the signature header to the hash
            return CryptographicOperations.FixedTimeEquals(
                hashBytes,
                decodedHeader.Slice(0, bytesWritten)
            );
        }

        // If the Base64 conversion fails, the signature is invalid
        return false;
    }
#endif
}
