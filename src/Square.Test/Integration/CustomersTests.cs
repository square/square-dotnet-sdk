using System.Text.Json;
using NUnit.Framework;
using Square.Customers;
using Square.Customers.Cards;
using Square.Customers.CustomAttributeDefinitions;
using Square.Customers.CustomAttributes;
using Square.Customers.Groups;

namespace Square.Test.Integration;

[TestFixture]
public class CustomersTests
{
    private SquareClient _client;
    private string _customerId;
    private string _customerGroupId;
    private string _customAttributeKey;

    [SetUp]
    public async Task SetUp()
    {
        _client = Helpers.CreateClient();

        // Create test customer
        var customerResponse = await _client.Customers.CreateAsync(
            new CreateCustomerRequest
            {
                IdempotencyKey = Guid.NewGuid().ToString(),
                GivenName = "Amelia",
                FamilyName = "Earhart",
                PhoneNumber = "1-212-555-4240",
                Note = "a customer",
                Address = new Address
                {
                    AddressLine1 = "500 Electric Ave",
                    AddressLine2 = "Suite 600",
                    Locality = "New York",
                    AdministrativeDistrictLevel1 = "NY",
                    PostalCode = "10003",
                    Country = Country.Us,
                },
            }
        );
        var customer =
            customerResponse.Customer ?? throw new Exception("Failed to create test customer.");
        _customerId = customer.Id ?? throw new Exception("Customer ID is null.");

        // Create a customer group for testing
        var createGroupResponse = await _client.Customers.Groups.CreateAsync(
            new CreateCustomerGroupRequest
            {
                Group = new CustomerGroup { Name = "Test Group " + Guid.NewGuid() },
                IdempotencyKey = Guid.NewGuid().ToString(),
            }
        );
        var group =
            createGroupResponse.Group
            ?? throw new Exception("Failed to create test customer group.");
        _customerGroupId = group.Id ?? throw new Exception("Group ID is null.");

        // Create custom attribute definition
        _customAttributeKey = "favorite-drink-" + Guid.NewGuid();
        await _client.Customers.CustomAttributeDefinitions.CreateAsync(
            new CreateCustomerCustomAttributeDefinitionRequest
            {
                CustomAttributeDefinition = new CustomAttributeDefinition
                {
                    Key = _customAttributeKey,
                    Name = "Favorite Drink" + Guid.NewGuid(),
                    Description = "A customer's favorite drink",
                    Visibility = CustomAttributeDefinitionVisibility.VisibilityReadWriteValues,
                    Schema = new Dictionary<string, object>
                    {
                        {
                            "$ref",
                            "https://developer-production-s.squarecdn.com/schemas/v1/common.json#squareup.common.String"
                        },
                    },
                },
            }
        );
    }

    [TearDown]
    public async Task TearDown()
    {
        try
        {
            await _client.Customers.DeleteAsync(
                new DeleteCustomersRequest { CustomerId = _customerId }
            );
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        try
        {
            await _client.Customers.Groups.DeleteAsync(
                new DeleteGroupsRequest { GroupId = _customerGroupId }
            );
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        try
        {
            await _client.Customers.CustomAttributeDefinitions.DeleteAsync(
                new DeleteCustomAttributeDefinitionsRequest { Key = _customAttributeKey }
            );
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    [Test]
    public async Task TestSearchCustomers()
    {
        var searchRequest = new SearchCustomersRequest { Limit = 1 };
        var response = await _client.Customers.SearchAsync(searchRequest);

        Assert.That(response.Customers, Is.Not.Null);
        Assert.That(response.Customers.Count, Is.GreaterThan(0));
    }

    [Test]
    public async Task TestRetrieveCustomer()
    {
        var response = await _client.Customers.GetAsync(
            new GetCustomersRequest { CustomerId = _customerId }
        );

        var customer = response.Customer ?? throw new Exception("Customer is null.");
        Assert.That(customer.Id, Is.EqualTo(_customerId));
    }

    [Test]
    public async Task TestUpdateCustomer()
    {
        var updateRequest = new UpdateCustomerRequest
        {
            CustomerId = _customerId,
            GivenName = "Updated Amelia",
            FamilyName = "Updated Earhart",
        };
        var response = await _client.Customers.UpdateAsync(updateRequest);

        var customer = response.Customer ?? throw new Exception("Failed to update customer.");
        Assert.Multiple(() =>
        {
            Assert.That(customer.GivenName, Is.EqualTo("Updated Amelia"));
            Assert.That(customer.FamilyName, Is.EqualTo("Updated Earhart"));
        });
    }

    [Test]
    public async Task TestCreateCustomerCard()
    {
        var createCardRequest = new CreateCustomerCardRequest
        {
            CustomerId = _customerId,
            CardNonce = "cnon:card-nonce-ok",
        };
        var createCardResponse = await _client.Customers.Cards.CreateAsync(createCardRequest);

        var customerCardId =
            createCardResponse.Card?.Id ?? throw new Exception("Customer card ID is null.");

        var deleteCardResponse = await _client.Customers.Cards.DeleteAsync(
            new DeleteCardsRequest { CustomerId = _customerId, CardId = customerCardId }
        );
        Assert.That(deleteCardResponse, Is.Not.Null);
    }

    [Test]
    public async Task TestAddCustomerToGroup()
    {
        var addGroupResponse = await _client.Customers.Groups.AddAsync(
            new AddGroupsRequest { CustomerId = _customerId, GroupId = _customerGroupId }
        );
        Assert.That(addGroupResponse, Is.Not.Null);

        var removeGroupResponse = await _client.Customers.Groups.RemoveAsync(
            new RemoveGroupsRequest { CustomerId = _customerId, GroupId = _customerGroupId }
        );
        Assert.That(removeGroupResponse, Is.Not.Null);
    }

    [Test]
    public async Task TestCreateCustomerCustomAttribute()
    {
        var createAttrResponse = await _client.Customers.CustomAttributes.UpsertAsync(
            new UpsertCustomerCustomAttributeRequest
            {
                CustomerId = _customerId,
                Key = _customAttributeKey,
                CustomAttribute = new CustomAttribute
                {
                    Value = "Double-shot breve",
                    Key = _customAttributeKey,
                },
            }
        );

        var customAttribute =
            createAttrResponse.CustomAttribute ?? throw new Exception("Custom attribute is null.");
        Assert.That(customAttribute.Value, Is.InstanceOf<JsonElement>());
        var customAttributeValue = ((JsonElement)customAttribute.Value).GetString();
        Assert.That(customAttributeValue, Is.EqualTo("Double-shot breve"));
    }

    [Test]
    public async Task TestUpdateCustomerCustomAttribute()
    {
        var updateAttrResponse = await _client.Customers.CustomAttributes.UpsertAsync(
            new UpsertCustomerCustomAttributeRequest
            {
                CustomerId = _customerId,
                Key = _customAttributeKey,
                CustomAttribute = new CustomAttribute { Value = "Black coffee" },
            }
        );

        var customAttribute =
            updateAttrResponse.CustomAttribute ?? throw new Exception("Custom attribute is null.");
        Assert.That(customAttribute.Value, Is.InstanceOf<JsonElement>());
        var customAttributeValue = ((JsonElement)customAttribute.Value).GetString();
        Assert.That(customAttributeValue, Is.EqualTo("Black coffee"));
    }

    [Test]
    public async Task TestListCustomerCustomAttributes()
    {
        await _client.Customers.CustomAttributes.UpsertAsync(
            new UpsertCustomerCustomAttributeRequest
            {
                CustomerId = _customerId,
                Key = _customAttributeKey,
                CustomAttribute = new CustomAttribute { Value = "Double-shot breve" },
            }
        );

        var pager = await _client.Customers.CustomAttributes.ListAsync(
            new ListCustomAttributesRequest { CustomerId = _customerId, WithDefinitions = true }
        );
        Assert.That(pager, Is.Not.Null);

        var attributes = new List<CustomAttribute>();
        await foreach (var attribute in pager)
        {
            attributes.Add(attribute);
        }
        Assert.That(attributes.Count, Is.GreaterThan(0));

        var deleteAttrResponse = await _client.Customers.CustomAttributes.DeleteAsync(
            new DeleteCustomAttributesRequest
            {
                CustomerId = _customerId,
                Key = _customAttributeKey,
            }
        );
        Assert.That(deleteAttrResponse, Is.Not.Null);
    }

    [Test]
    public async Task TestDeleteCustomerCustomAttribute()
    {
        await _client.Customers.CustomAttributes.UpsertAsync(
            new UpsertCustomerCustomAttributeRequest
            {
                CustomerId = _customerId,
                Key = _customAttributeKey,
                CustomAttribute = new CustomAttribute { Value = "Double-shot breve" },
            }
        );

        var response = await _client.Customers.CustomAttributes.DeleteAsync(
            new DeleteCustomAttributesRequest
            {
                CustomerId = _customerId,
                Key = _customAttributeKey,
            }
        );
        Assert.That(response, Is.Not.Null);
    }
}
