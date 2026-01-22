using Square;
using Square.Core;

namespace Square.Default;

public partial interface IChannelsClient
{
    Task<Pager<Channel>> ListAsync(
        ListChannelsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task<BulkRetrieveChannelsResponse> BulkRetrieveAsync(
        BulkRetrieveChannelsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task<RetrieveChannelResponse> GetAsync(
        GetChannelsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
