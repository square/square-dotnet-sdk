using NUnit.Framework;
using Square.Customers.Groups;

namespace Square.Test.Integration;

[TestFixture]
public class CustomerGroupsTests
{
    private SquareClient _client;
    private string _groupId;

    [SetUp]
    public async Task SetUp()
    {
        _client = Helpers.CreateClient();
        _groupId = await CreateTestCustomerGroup();
    }

    [TearDown]
    public async Task TearDown()
    {
        await _client.Customers.Groups.DeleteAsync(new DeleteGroupsRequest { GroupId = _groupId });
    }

    [Test]
    public async Task TestCreateAndListCustomerGroup()
    {
        var response = await _client.Customers.Groups.ListAsync(new ListGroupsRequest());
        Assert.That(response, Is.Not.Null);
        var groups = new List<CustomerGroup>();
        int count = 0;
        await foreach (var group in response)
        {
            groups.Add(group);
            Assert.That(group, Is.Not.Null);
            if (++count >= 10)
                break;
        }
        Assert.That(groups, Is.Not.Empty);
    }

    [Test]
    public async Task TestRetrieveCustomerGroup()
    {
        var response = await _client.Customers.Groups.GetAsync(
            new GetGroupsRequest { GroupId = _groupId }
        );
        Assert.That(response.Group, Is.Not.Null);
        Assert.That(response.Group.Id, Is.EqualTo(_groupId));
    }

    [Test]
    public async Task TestUpdateCustomerGroup()
    {
        var newName = "Updated-" + Guid.NewGuid();
        var response = await _client.Customers.Groups.UpdateAsync(
            new UpdateCustomerGroupRequest
            {
                GroupId = _groupId,
                Group = new CustomerGroup { Name = newName },
            }
        );
        Assert.That(response.Group, Is.Not.Null);
        Assert.That(response.Group.Name, Is.EqualTo(newName));
    }

    [Test]
    public void TestRetrieveNonExistentGroup()
    {
        Assert.ThrowsAsync<SquareApiException>(async () =>
        {
            await _client.Customers.Groups.GetAsync(
                new GetGroupsRequest { GroupId = "not existent id" }
            );
        });
    }

    [Test]
    public void TestCreateGroupWithInvalidData()
    {
        Assert.ThrowsAsync<SquareApiException>(async () =>
        {
            await _client.Customers.Groups.CreateAsync(
                new CreateCustomerGroupRequest
                {
                    Group = new CustomerGroup { Name = "" }, // Empty name should be invalid
                    IdempotencyKey = Guid.NewGuid().ToString(),
                }
            );
        });
    }

    private async Task<string> CreateTestCustomerGroup()
    {
        var response = await _client.Customers.Groups.CreateAsync(
            new CreateCustomerGroupRequest
            {
                Group = new CustomerGroup { Name = "Default-" + Guid.NewGuid() },
                IdempotencyKey = Guid.NewGuid().ToString(),
            }
        );
        var group = response.Group ?? throw new Exception("response?.Group is null");
        return group.Id ?? throw new Exception("group.Id is null");
    }
}
