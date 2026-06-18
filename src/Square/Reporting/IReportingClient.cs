namespace Square;

public partial interface IReportingClient
{
    /// <summary>
    /// Describes the data available to query: the cubes, views, measures, dimensions, and segments you can reference in a reporting query. Call this first to discover the schema, then pass the members you need to `load`.
    /// </summary>
    Task<MetadataResponse> GetMetadataAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Runs a reporting query against the discovered schema and returns the aggregated results. Long-running queries may return a "Continue wait" response while processing — retry the same request until results are ready.
    /// </summary>
    Task<LoadResponse> LoadAsync(
        LoadRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
