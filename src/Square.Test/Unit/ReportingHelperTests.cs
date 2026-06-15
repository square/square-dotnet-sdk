using NUnit.Framework;
using Square;
using Square.Core;

namespace Square.Test.Unit;

/// <summary>
/// The Reporting API answers a still-processing <c>/v1/load</c> query with an HTTP 200
/// whose body is <c>{ "error": "Continue wait" }</c>. <see cref="ReportingHelper.LoadAndWaitAsync"/>
/// owns the retry loop around that sentinel. These tests exercise that loop without a
/// network by scripting <c>Reporting.LoadAsync</c>, plus one test that proves the sentinel
/// actually survives the generated client's deserialization.
/// </summary>
[TestFixture]
public class ReportingHelperTests
{
    private const string ContinueWait = "Continue wait";

    /// <summary>An <see cref="IReportingClient"/> stub whose <c>LoadAsync</c> returns a scripted sequence.</summary>
    private sealed class FakeReportingClient : IReportingClient
    {
        private readonly IReadOnlyList<LoadResponse> _sequence;
        private int _i;

        public FakeReportingClient(params LoadResponse[] sequence) => _sequence = sequence;

        public int CallCount => _i;

        public Task<LoadResponse> LoadAsync(
            LoadRequest request,
            RequestOptions? options = null,
            CancellationToken cancellationToken = default
        )
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = _sequence[Math.Min(_i, _sequence.Count - 1)];
            _i++;
            return Task.FromResult(response);
        }

        public Task<MetadataResponse> GetMetadataAsync(
            RequestOptions? options = null,
            CancellationToken cancellationToken = default
        ) => throw new NotSupportedException();
    }

    private static LoadResponse ContinueWaitResponse() =>
        JsonUtils.Deserialize<LoadResponse>($"{{\"error\":\"{ContinueWait}\"}}")!;

    // A resolved response is simply any LoadResponse lacking the "Continue wait" sentinel.
    private static LoadResponse ResolvedResponse() => new();

    [Test]
    public async Task PollsPastContinueWaitAndReturnsResolvedResult()
    {
        var resolved = ResolvedResponse();
        var fake = new FakeReportingClient(
            ContinueWaitResponse(),
            ContinueWaitResponse(),
            resolved
        );

        var response = await ReportingHelper.LoadAndWaitAsync(
            fake,
            new LoadRequest(),
            new LoadAndWaitOptions
            {
                InitialDelay = TimeSpan.FromMilliseconds(1),
                MaxDelay = TimeSpan.FromMilliseconds(1),
                MaxAttempts = 5,
            }
        );

        Assert.Multiple(() =>
        {
            // The helper must poll through the sentinels and hand back the resolved response.
            Assert.That(response, Is.SameAs(resolved));
            Assert.That(response.AdditionalProperties.ContainsKey("error"), Is.False);
            Assert.That(fake.CallCount, Is.EqualTo(3));
        });
    }

    [Test]
    public async Task ReturnsImmediatelyWhenFirstResponseHasResults()
    {
        var resolved = ResolvedResponse();
        var fake = new FakeReportingClient(resolved);

        var response = await ReportingHelper.LoadAndWaitAsync(
            fake,
            options: new LoadAndWaitOptions { InitialDelay = TimeSpan.FromMilliseconds(1) }
        );

        Assert.Multiple(() =>
        {
            Assert.That(response, Is.SameAs(resolved));
            Assert.That(fake.CallCount, Is.EqualTo(1));
        });
    }

    [Test]
    public void ThrowsOnceMaxAttemptsIsExhaustedWhileStillContinueWait()
    {
        var fake = new FakeReportingClient(ContinueWaitResponse()); // never resolves

        var ex = Assert.ThrowsAsync<SquareException>(
            async () =>
                await ReportingHelper.LoadAndWaitAsync(
                    fake,
                    new LoadRequest(),
                    new LoadAndWaitOptions
                    {
                        InitialDelay = TimeSpan.FromMilliseconds(1),
                        MaxDelay = TimeSpan.FromMilliseconds(1),
                        MaxAttempts = 3,
                    }
                )
        );

        Assert.Multiple(() =>
        {
            Assert.That(ex!.Message, Does.Contain("did not complete after 3 attempts"));
            Assert.That(fake.CallCount, Is.EqualTo(3));
        });
    }

    [Test]
    public void RejectsPromptlyWhenCancellationTokenFires()
    {
        var fake = new FakeReportingClient(ContinueWaitResponse()); // would otherwise poll forever
        using var cts = new CancellationTokenSource();

        var pending = ReportingHelper.LoadAndWaitAsync(
            fake,
            new LoadRequest(),
            new LoadAndWaitOptions
            {
                InitialDelay = TimeSpan.FromSeconds(30),
                MaxAttempts = 10,
            },
            cts.Token
        );
        cts.Cancel();

        // Task.Delay surfaces a TaskCanceledException, which derives from
        // OperationCanceledException — match the base type, not the exact type.
        Assert.That(
            async () => await pending,
            Throws.InstanceOf<OperationCanceledException>()
        );
    }

    [Test]
    public void RealDeserializerContinueWaitBodyIsARetrySignalNotAResult()
    {
        // The crux of the design: the generated LoadResponse deserializes with unknown-key
        // passthrough (via [JsonExtensionData]), so the `error` sentinel survives onto
        // AdditionalProperties while `results` stays empty. If this ever stops being true,
        // LoadAndWaitAsync would mistake "Continue wait" for a real result.
        var parsed = JsonUtils.Deserialize<LoadResponse>($"{{\"error\":\"{ContinueWait}\"}}")!;

        Assert.Multiple(() =>
        {
            Assert.That(parsed.AdditionalProperties.TryGetValue("error", out var error), Is.True);
            Assert.That(error.GetString(), Is.EqualTo(ContinueWait));
            Assert.That(parsed.Results, Is.Empty);
        });
    }
}
