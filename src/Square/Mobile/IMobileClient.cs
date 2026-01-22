using Square;

namespace Square.Mobile;

public partial interface IMobileClient
{
    Task AuthorizationCodeAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
