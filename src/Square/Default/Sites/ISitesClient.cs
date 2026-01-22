using Square;

namespace Square.Default;

public partial interface ISitesClient
{
    /// <summary>
    /// Lists the Square Online sites that belong to a seller. Sites are listed in descending order by the `created_at` date.
    ///
    ///
    /// __Note:__ Square Online APIs are publicly available as part of an early access program. For more information, see [Early access program for Square Online APIs](https://developer.squareup.com/docs/online-api#early-access-program-for-square-online-apis).
    /// </summary>
    Task<ListSitesResponse> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
