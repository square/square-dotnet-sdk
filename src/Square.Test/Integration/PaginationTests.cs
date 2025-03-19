using NUnit.Framework;
using Square.Catalog;
using Square.Catalog.Object;

namespace Square.Test.Integration;

[TestFixture]
public class PaginationTests
{
    private SquareClient client;

    [SetUp]
    public void SetUp()
    {
        client = Helpers.CreateClient();
    }

    [Test]
    public async Task TestCustomersPaginationAsync()
    {
        // Setup: Create 5 customers
        for (int i = 0; i < 5; i++)
        {
            await Helpers.CreateTestCustomerAsync(client);
        }

        var pager = await client.Customers.ListAsync(new Customers.ListCustomersRequest());
        int count = 0;
        await foreach (var customer in pager)
        {
            Assert.That(customer, Is.Not.Null);
            Assert.That(customer.Id, Is.Not.Null);
            count++;
        }

        Assert.That(count, Is.GreaterThan(4));
    }

    [Test]
    [Ignore("Disabled because it occasionally throws 500s")]
    public async Task TestCatalogPaginationAsync()
    {
        // Setup: Create 5 catalog items
        for (int i = 0; i < 5; i++)
        {
            var request = new UpsertCatalogObjectRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Object = Helpers.CreateTestCatalogItem(new Helpers.CreateCatalogItemOptions()),
            };
            await client.Catalog.Object.UpsertAsync(request);
        }

        var pager = await client.Catalog.ListAsync(new ListCatalogRequest());
        int count = 0;
        await foreach (var catalogObject in pager)
        {
            Assert.That(catalogObject, Is.Not.Null);
            count++;
        }

        Assert.That(count, Is.GreaterThan(4));
    }
}
