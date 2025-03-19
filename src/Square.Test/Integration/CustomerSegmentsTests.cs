using NUnit.Framework;
using Square.Customers.Segments;

namespace Square.Test.Integration;

[TestFixture]
public class CustomerSegmentsTests
{
    private SquareClient _client;

    [SetUp]
    public void SetUp()
    {
        _client = Helpers.CreateClient();
    }

    [Test]
    public async Task TestListCustomerSegmentsAsync()
    {
        var request = new ListSegmentsRequest();
        var response = await _client.Customers.Segments.ListAsync(request);
        int count = 0;
        await foreach (var segment in response)
        {
            Assert.That(segment, Is.Not.Null);
            if (++count >= 10)
                break;
        }
    }

    [Test]
    public async Task TestRetrieveCustomerSegmentAsync()
    {
        var listRequest = new ListSegmentsRequest();
        var listResponse = await _client.Customers.Segments.ListAsync(listRequest);
        var enumerator = listResponse.GetAsyncEnumerator();
        await enumerator.MoveNextAsync();
        var segment = enumerator.Current ?? throw new Exception("No segments found.");
        var segmentId = segment.Id ?? throw new Exception("Segment ID is null.");

        var getRequest = new GetSegmentsRequest { SegmentId = segmentId };
        var getResponse = await _client.Customers.Segments.GetAsync(getRequest);

        Assert.Multiple(() =>
        {
            Assert.That(getResponse.Segment, Is.Not.Null);
            Assert.That(getResponse.Segment?.Name, Is.Not.Null);
        });
    }
}
