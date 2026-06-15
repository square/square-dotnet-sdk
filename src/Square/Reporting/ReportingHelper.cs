using System.Text.Json;

namespace Square;

/// <summary>
/// Polling configuration for <see cref="ReportingHelper.LoadAndWaitAsync"/>.
/// </summary>
public class LoadAndWaitOptions
{
    /// <summary>Maximum poll attempts before giving up. Default 20.</summary>
    public int MaxAttempts { get; set; } = 20;

    /// <summary>Delay before the first retry. Default 2 seconds.</summary>
    public TimeSpan InitialDelay { get; set; } = TimeSpan.FromSeconds(2);

    /// <summary>Upper bound on the backoff delay. Default 20 seconds.</summary>
    public TimeSpan MaxDelay { get; set; } = TimeSpan.FromSeconds(20);

    /// <summary>Multiplier applied to the delay after each attempt. Default 2.</summary>
    public double BackoffFactor { get; set; } = 2;

    /// <summary>Forwarded to each underlying <c>Reporting.LoadAsync</c> call.</summary>
    public RequestOptions? RequestOptions { get; set; }
}

/// <summary>
/// Utility code to help with the
/// <a href="https://developer.squareup.com/docs/reporting-api/overview">Square Reporting API</a>.
///
/// <para>
/// The <c>/reporting/v1/load</c> endpoint is asynchronous: a query that is still being
/// computed comes back as an HTTP 200 whose body is <c>{ "error": "Continue wait" }</c>
/// rather than the results. Clients are expected to re-send the identical request, with
/// backoff, until real results arrive. This helper owns that retry loop.
/// </para>
/// </summary>
public static class ReportingHelper
{
    /// <summary>
    /// Sentinel returned by the Reporting API on an HTTP 200 while a <c>/v1/load</c>
    /// query is still processing. It is NOT an error — the request should be retried.
    /// </summary>
    private const string ContinueWait = "Continue wait";

    /// <summary>
    /// Runs a reporting query and transparently polls until it resolves, returning the
    /// final <see cref="LoadResponse"/>. Re-sends the identical request with exponential
    /// backoff while the API answers "Continue wait".
    /// </summary>
    /// <param name="reporting">A configured reporting client, e.g. <c>client.Reporting</c>.</param>
    /// <param name="request">The reporting query (same shape as <c>Reporting.LoadAsync</c>).</param>
    /// <param name="options">Polling/backoff configuration.</param>
    /// <param name="cancellationToken">Aborts the poll loop (and any in-flight wait) when signalled.</param>
    /// <returns>The resolved <see cref="LoadResponse"/> (never the "Continue wait" sentinel).</returns>
    /// <exception cref="SquareException">
    /// Thrown if the query does not resolve within <see cref="LoadAndWaitOptions.MaxAttempts"/>.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown if <paramref name="cancellationToken"/> is signalled while polling.
    /// </exception>
    /// <remarks>
    /// <example>
    /// <code>
    /// var response = await ReportingHelper.LoadAndWaitAsync(
    ///     client.Reporting,
    ///     new LoadRequest { Query = new Query { Measures = new List&lt;string&gt; { "Orders.count" } } }
    /// );
    /// </code>
    /// </example>
    /// </remarks>
    public static async Task<LoadResponse> LoadAndWaitAsync(
        IReportingClient reporting,
        LoadRequest? request = null,
        LoadAndWaitOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (reporting is null)
        {
            throw new ArgumentNullException(nameof(reporting));
        }

        request ??= new LoadRequest();
        options ??= new LoadAndWaitOptions();
        if (options.MaxAttempts < 1)
        {
            throw new ArgumentOutOfRangeException(
                nameof(options),
                "MaxAttempts must be at least 1."
            );
        }

        var delay = options.InitialDelay;
        for (var attempt = 1; attempt <= options.MaxAttempts; attempt++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var response = await reporting
                .LoadAsync(request, options.RequestOptions, cancellationToken)
                .ConfigureAwait(false);

            if (!IsContinueWait(response))
            {
                return response;
            }

            if (attempt == options.MaxAttempts)
            {
                break;
            }

            await Task.Delay(delay, cancellationToken).ConfigureAwait(false);
            delay = TimeSpan.FromTicks(
                Math.Min(
                    (long)(delay.Ticks * options.BackoffFactor),
                    options.MaxDelay.Ticks
                )
            );
        }

        throw new SquareException(
            $"Reporting query did not complete after {options.MaxAttempts} attempts (\"{ContinueWait}\")."
        );
    }

    /// <summary>
    /// A "Continue wait" body deserializes into a <see cref="LoadResponse"/> (validation is
    /// skipped) with the <c>error</c> field preserved on <see cref="LoadResponse.AdditionalProperties"/>
    /// and <c>results</c> absent. That's the signal to retry.
    /// </summary>
    private static bool IsContinueWait(LoadResponse response)
    {
        return response.AdditionalProperties.TryGetValue("error", out var error)
            && error.ValueKind == JsonValueKind.String
            && error.GetString() == ContinueWait;
    }
}

public partial class ReportingClient
{
    /// <summary>
    /// Runs a reporting query and transparently polls until it resolves, returning the
    /// final <see cref="LoadResponse"/>. Convenience wrapper over
    /// <see cref="ReportingHelper.LoadAndWaitAsync"/> — re-sends the identical request with
    /// exponential backoff while the Reporting API answers "Continue wait".
    /// </summary>
    /// <param name="request">The reporting query (same shape as <see cref="LoadAsync"/>).</param>
    /// <param name="options">Polling/backoff configuration.</param>
    /// <param name="cancellationToken">Aborts the poll loop (and any in-flight wait) when signalled.</param>
    /// <returns>The resolved <see cref="LoadResponse"/> (never the "Continue wait" sentinel).</returns>
    /// <example><code>
    /// var response = await client.Reporting.LoadAndWaitAsync(
    ///     new LoadRequest { Query = new Query { Measures = new List&lt;string&gt; { "Orders.count" } } }
    /// );
    /// </code></example>
    public Task<LoadResponse> LoadAndWaitAsync(
        LoadRequest? request = null,
        LoadAndWaitOptions? options = null,
        CancellationToken cancellationToken = default
    ) => ReportingHelper.LoadAndWaitAsync(this, request, options, cancellationToken);
}
