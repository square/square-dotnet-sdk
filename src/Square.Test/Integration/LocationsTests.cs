using NUnit.Framework;

namespace Square.Test.Integration;

[TestFixture]
public class LocationsTests
{
    private SquareClient _client;

    [SetUp]
    public void SetUp()
    {
        _client = Helpers.CreateClient();
    }

    [Test]
    public async Task TestListLocations()
    {
        var response = await _client.Locations.ListAsync();

        Assert.Multiple(() =>
        {
            Assert.That(response.Locations, Is.Not.Null);
            Assert.That(response.Locations, Is.Not.Empty);
        });
    }
}
