using NUnit.Framework;
using Square.Merchants;

namespace Square.Test.Integration;

[TestFixture]
public class MerchantsTests
{
    private SquareClient _client;
    private string _merchantId;

    [SetUp]
    public async Task SetUp()
    {
        _client = Helpers.CreateClient();

        // Get first merchant ID
        var merchantResponse = await _client.Merchants.ListAsync(new ListMerchantsRequest());
        var merchants = merchantResponse.CurrentPage.Items;
        if (!merchants.Any())
        {
            throw new Exception("No merchants found.");
        }
        _merchantId = merchants[0].Id ?? throw new Exception("Merchant ID is null.");
    }

    [Test]
    public async Task TestListMerchants()
    {
        var response = await _client.Merchants.ListAsync(new ListMerchantsRequest());
        var merchants = response.CurrentPage.Items;

        Assert.Multiple(() =>
        {
            Assert.That(merchants, Is.Not.Null);
            Assert.That(merchants, Is.Not.Empty);
        });
    }

    [Test]
    public async Task TestRetrieveMerchant()
    {
        var response = await _client.Merchants.GetAsync(
            new GetMerchantsRequest { MerchantId = _merchantId }
        );

        Assert.Multiple(() =>
        {
            Assert.That(response.Merchant, Is.Not.Null);
            Assert.That(response.Merchant?.Id, Is.EqualTo(_merchantId));
        });
    }
}
