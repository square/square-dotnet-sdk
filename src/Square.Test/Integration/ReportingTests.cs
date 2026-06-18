using System.Text.Json;
using NUnit.Framework;
using Square;

namespace Square.Test.Integration;

// The Reporting API is a beta, bespoke offering served ONLY from production
// (connect.squareup.com/reporting) — it is not routed on sandbox (returns 404 there).
// Validating it live therefore needs a production, reporting-provisioned access token,
// supplied via TEST_SQUARE_REPORTING (distinct from the sandbox TEST_SQUARE_TOKEN used by
// the rest of the integration suite). This suite is gated behind TEST_SQUARE_REPORTING and
// skips by default — keeping CI green. The endpoints are read-only (schema discovery +
// queries). The polling *logic* is covered without a live account in
// Unit/ReportingHelperTests.cs.
//
// Run it against a real prod account:
//   TEST_SQUARE_REPORTING=<prod-reporting-token> \
//     dotnet test --filter FullyQualifiedName~Integration.ReportingTests
//   # override the host with TEST_SQUARE_BASE_URL=<url> if reporting moves.
[TestFixture]
public class ReportingTests
{
    private SquareClient _client = null!;

    [SetUp]
    public void SetUp()
    {
        var token = Environment.GetEnvironmentVariable("TEST_SQUARE_REPORTING");
        if (string.IsNullOrEmpty(token))
        {
            Assert.Ignore(
                "Set TEST_SQUARE_REPORTING to a production, reporting-provisioned access token to run the reporting integration suite."
            );
        }
        // Reporting only exists on production; allow overriding the host via TEST_SQUARE_BASE_URL.
        var baseUrl =
            Environment.GetEnvironmentVariable("TEST_SQUARE_BASE_URL") ?? SquareEnvironment.Production;
        TestContext.Out.WriteLine(
            $"[reporting] base URL: {baseUrl}  ->  {baseUrl}/reporting/v1/{{meta,load}}"
        );
        _client = new SquareClient(token!, new ClientOptions { BaseUrl = baseUrl });
    }

    // Resolves the first queryable measure from the live schema, e.g. "Orders.count".
    private async Task<string> FirstMeasureNameAsync()
    {
        var metadata = await _client.Reporting.GetMetadataAsync();
        var measure = metadata.Cubes?.FirstOrDefault()?.Measures.FirstOrDefault()?.Name;
        if (string.IsNullOrEmpty(measure))
        {
            throw new Exception(
                "No cubes/measures are available on the reporting schema for this account."
            );
        }
        return measure!;
    }

    [Test]
    public async Task GetMetadataReturnsTheQueryableSchema()
    {
        var metadata = await _client.Reporting.GetMetadataAsync();

        Assert.That(metadata.Cubes, Is.Not.Null);
        Assert.That(metadata.Cubes, Is.Not.Empty);

        // Surface the live schema so a developer can see what is queryable.
        var summary = (metadata.Cubes ?? new List<Cube>())
            .Take(5)
            .Select(cube => new
            {
                cube = cube.Name,
                measures = cube.Measures.Take(5).Select(measure => measure.Name).ToList(),
            });
        TestContext.Out.WriteLine(
            "Reporting schema (first 5 cubes): "
                + JsonSerializer.Serialize(summary, new JsonSerializerOptions { WriteIndented = true })
        );
    }

    [Test]
    public async Task LoadReturnsResultsOrTheContinueWaitSentinel()
    {
        var measure = await FirstMeasureNameAsync();
        var response = await _client.Reporting.LoadAsync(
            new LoadRequest { Query = new Query { Measures = new List<string> { measure } } }
        );

        if (response.AdditionalProperties.TryGetValue("error", out var sentinel))
        {
            // Documented async behavior: a still-processing query comes back as HTTP 200
            // with { "error": "Continue wait" } instead of results.
            Assert.That(sentinel.GetString(), Is.EqualTo("Continue wait"));
        }
        else
        {
            // Flat LoadResponse: a resolved query carries its payload on `Data`.
            Assert.That(response.Data, Is.Not.Null);
        }
    }

    [Test]
    public async Task LoadAndWaitResolvesAQueryEndToEndWithoutSurfacingContinueWait()
    {
        var measure = await FirstMeasureNameAsync();

        var response = await _client.Reporting.LoadAndWaitAsync(
            new LoadRequest { Query = new Query { Measures = new List<string> { measure } } },
            new LoadAndWaitOptions
            {
                MaxAttempts = 20,
                InitialDelay = TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(20),
            }
        );

        // The polling helper must never hand back the raw "Continue wait" sentinel.
        Assert.That(response.AdditionalProperties.ContainsKey("error"), Is.False);
        // Flat LoadResponse: the resolved query carries its payload on `Data`.
        Assert.That(response.Data, Is.Not.Null);
    }
}
