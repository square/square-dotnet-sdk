using NUnit.Framework;
using Square.Mobile;

namespace Square.Test.Integration;

[TestFixture]
public class MobileAuthorizationTests
{
    private SquareClient _client;
    private string _locationId;

    [SetUp]
    public async Task SetUp()
    {
        _client = Helpers.CreateClient();
        _locationId = await Helpers.GetDefaultLocationIdAsync(_client);
    }

    [Test]
    public async Task TestCreateMobileAuthorizationCode()
    {
        var request = new CreateMobileAuthorizationCodeRequest { LocationId = _locationId };

        var response = await _client.Mobile.AuthorizationCodeAsync(request);

        Assert.Multiple(() =>
        {
            Assert.That(response.AuthorizationCode, Is.Not.Null);
            Assert.That(response.ExpiresAt, Is.Not.Null);
        });
    }
}
