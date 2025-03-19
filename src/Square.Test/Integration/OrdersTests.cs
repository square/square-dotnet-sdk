using NUnit.Framework;
using Square.Orders;

namespace Square.Test.Integration;

[TestFixture]
public class OrdersTests
{
    private SquareClient client;
    private string locationId;
    private string orderId;
    private string lineItemUid;

    [SetUp]
    public async Task SetUp()
    {
        client = Helpers.CreateClient();
        locationId = await Helpers.GetDefaultLocationIdAsync(client);

        // Create initial order for testing
        var orderResponse = await client.Orders.CreateAsync(
            new CreateOrderRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                Order = new Order
                {
                    LocationId = locationId,
                    LineItems =
                    [
                        new OrderLineItem
                        {
                            Quantity = "1",
                            Name = "New Item",
                            BasePriceMoney = new Money { Amount = 100, Currency = Currency.Usd },
                        },
                    ],
                },
            }
        );
        var order = orderResponse.Order ?? throw new Exception("Order is null.");
        orderId = order.Id ?? throw new Exception("Order ID is null.");
        var lineItems = order.LineItems ?? throw new Exception("Line items are null or empty.");
        lineItemUid = lineItems.First().Uid ?? throw new Exception("Line item UID is null.");
    }

    [Test]
    public async Task TestCreateOrder()
    {
        var response = await client.Orders.CreateAsync(
            new CreateOrderRequest
            {
                Order = new Order
                {
                    LocationId = locationId,
                    LineItems =
                    [
                        new OrderLineItem
                        {
                            Quantity = "1",
                            Name = "New Item",
                            BasePriceMoney = new Money { Amount = 100, Currency = Currency.Usd },
                        },
                    ],
                },
            }
        );

        Assert.That(response.Order, Is.Not.Null);
        Assert.That(response.Order.LocationId, Is.EqualTo(locationId));
        var lineItems =
            response.Order.LineItems ?? throw new Exception("Line items are null or empty.");
        Assert.That(lineItems.First().Name, Is.EqualTo("New Item"));
    }

    [Test]
    public async Task TestBatchRetrieveOrders()
    {
        var response = await client.Orders.BatchGetAsync(
            new BatchGetOrdersRequest { OrderIds = [orderId] }
        );

        Assert.That(response.Orders, Is.Not.Null);
        Assert.That(response.Orders.First().Id, Is.EqualTo(orderId));
    }

    [Test]
    public async Task TestSearchOrders()
    {
        var response = await client.Orders.SearchAsync(
            new SearchOrdersRequest { Limit = 1, LocationIds = [locationId] }
        );

        Assert.That(response.Orders, Is.Not.Null);
        Assert.That(response.Orders, Is.Not.Empty);
    }

    [Test]
    public async Task TestUpdateOrder()
    {
        var response = await client.Orders.UpdateAsync(
            new UpdateOrderRequest
            {
                OrderId = orderId,
                IdempotencyKey = Guid.NewGuid().ToString(),
                Order = new Order
                {
                    LocationId = locationId,
                    LineItems =
                    [
                        new OrderLineItem
                        {
                            Quantity = "1",
                            Name = "Updated Item",
                            BasePriceMoney = new Money { Amount = 0, Currency = Currency.Usd },
                            Note = null,
                        },
                    ],
                    Version = 1,
                },
                FieldsToClear = [$"line_items[{lineItemUid}]"],
            }
        );

        Assert.That(response.Order, Is.Not.Null);
        Assert.That(response.Order.Id, Is.EqualTo(orderId));
        var lineItems =
            response.Order.LineItems ?? throw new Exception("Line items are null or empty.");
        Assert.That(lineItems.First().Name, Is.EqualTo("Updated Item"));
    }

    [Test]
    public async Task TestPayOrder()
    {
        await TestUpdateOrder();

        var response = await client.Orders.PayAsync(
            new PayOrderRequest
            {
                OrderId = orderId,
                IdempotencyKey = Guid.NewGuid().ToString(),
                OrderVersion = 2,
                PaymentIds = [],
            }
        );

        Assert.That(response.Order, Is.Not.Null);
        Assert.That(response.Order.Id, Is.EqualTo(orderId));
    }

    [Test]
    public async Task TestCalculateOrder()
    {
        var response = await client.Orders.CalculateAsync(
            new CalculateOrderRequest
            {
                Order = new Order
                {
                    LocationId = locationId,
                    LineItems =
                    [
                        new OrderLineItem
                        {
                            Quantity = "1",
                            Name = "New Item",
                            BasePriceMoney = new Money { Amount = 100, Currency = Currency.Usd },
                        },
                    ],
                },
            }
        );

        Assert.That(response.Order, Is.Not.Null);
        Assert.That(response.Order.TotalMoney, Is.Not.Null);
    }
}
