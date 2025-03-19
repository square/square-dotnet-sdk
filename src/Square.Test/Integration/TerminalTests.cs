using NUnit.Framework;
using Square.Terminal.Checkouts;

namespace Square.Test.Integration;

[TestFixture]
public class TerminalTests
{
    private SquareClient _client;
    private string _checkoutId;
    private readonly string _sandboxDeviceId = "da40d603-c2ea-4a65-8cfd-f42e36dab0c7";

    [SetUp]
    public async Task SetUp()
    {
        _client = Helpers.CreateClient();

        // Create terminal checkout for testing
        var checkoutRequest = new CreateTerminalCheckoutRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            Checkout = new TerminalCheckout
            {
                AmountMoney = Helpers.NewTestMoney(),
                DeviceOptions = new DeviceCheckoutOptions { DeviceId = _sandboxDeviceId },
            },
        };
        var checkoutResponse = await _client.Terminal.Checkouts.CreateAsync(checkoutRequest);
        _checkoutId = checkoutResponse.Checkout?.Id ?? throw new Exception("Checkout ID is null.");
    }

    [Test]
    public async Task TestCreateTerminalCheckout()
    {
        var checkoutRequest = new CreateTerminalCheckoutRequest
        {
            IdempotencyKey = Guid.NewGuid().ToString(),
            Checkout = new TerminalCheckout
            {
                AmountMoney = Helpers.NewTestMoney(),
                DeviceOptions = new DeviceCheckoutOptions { DeviceId = _sandboxDeviceId },
            },
        };
        var response = await _client.Terminal.Checkouts.CreateAsync(checkoutRequest);

        Assert.That(response.Checkout, Is.Not.Null);
        Assert.That(response.Checkout.DeviceOptions.DeviceId, Is.EqualTo(_sandboxDeviceId));
        Assert.That(response.Checkout.AmountMoney.Amount, Is.EqualTo(100));
    }

    [Test]
    public async Task TestSearchTerminalCheckouts()
    {
        var searchRequest = new SearchTerminalCheckoutsRequest { Limit = 1 };
        var response = await _client.Terminal.Checkouts.SearchAsync(searchRequest);

        Assert.That(response.Checkouts, Is.Not.Null);
        Assert.That(response.Checkouts.Count, Is.GreaterThan(0));
    }

    [Test]
    public async Task TestGetTerminalCheckout()
    {
        var response = await _client.Terminal.Checkouts.GetAsync(
            new GetCheckoutsRequest { CheckoutId = _checkoutId }
        );

        Assert.That(response.Checkout, Is.Not.Null);
        Assert.That(response.Checkout.Id, Is.EqualTo(_checkoutId));
    }

    [Test]
    public async Task TestCancelTerminalCheckout()
    {
        var response = await _client.Terminal.Checkouts.CancelAsync(
            new CancelCheckoutsRequest { CheckoutId = _checkoutId }
        );

        Assert.That(response.Checkout, Is.Not.Null);
        Assert.That(response.Checkout.Status, Is.EqualTo("CANCELED"));
    }
}
