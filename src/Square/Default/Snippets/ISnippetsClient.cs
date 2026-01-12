using Square;
using Square.Default;

namespace Square.Default.Snippets;

public partial interface ISnippetsClient
{
    /// <summary>
    /// Retrieves your snippet from a Square Online site. A site can contain snippets from multiple snippet applications, but you can retrieve only the snippet that was added by your application.
    ///
    /// You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.
    ///
    ///
    /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
    /// </summary>
    Task<GetSnippetResponse> GetAsync(
        GetSnippetsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Adds a snippet to a Square Online site or updates the existing snippet on the site.
    /// The snippet code is appended to the end of the `head` element on every page of the site, except checkout pages. A snippet application can add one snippet to a given site.
    ///
    /// You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.
    ///
    ///
    /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
    /// </summary>
    Task<UpsertSnippetResponse> UpsertAsync(
        UpsertSnippetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes your snippet from a Square Online site.
    ///
    /// You can call [ListSites](api-endpoint:Sites-ListSites) to get the IDs of the sites that belong to a seller.
    ///
    ///
    /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
    /// </summary>
    Task<DeleteSnippetResponse> DeleteAsync(
        DeleteSnippetsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
