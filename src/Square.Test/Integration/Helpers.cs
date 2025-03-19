using Square.Customers;

namespace Square.Test.Integration;

public static class Helpers
{
    public static SquareClient CreateClient() =>
        new(
            Environment.GetEnvironmentVariable("TEST_SQUARE_TOKEN")
                ?? "EAAAl1Amw3X5ehjO35kGzL9XuiB-Luh7UqPZGhr5gRu5PNxUvD00maDcx7-StIIk"
                ?? throw new Exception("TEST_SQUARE_TOKEN environment variable is not set"),
            new ClientOptions { BaseUrl = SquareEnvironment.Sandbox }
        );

    public static async Task<string> GetDefaultLocationIdAsync(SquareClient client)
    {
        var locations = await client.Locations.ListAsync();
        return locations.Locations?.First().Id
            ?? throw new Exception("locations.Locations is null");
    }

    public static async Task<Customer> CreateTestCustomerAsync(SquareClient client)
    {
        var request = new CreateCustomerRequest
        {
            GivenName = "Test",
            FamilyName = "Customer",
            EmailAddress = $"test{Guid.NewGuid():N}@example.com",
        };
        var response = await client.Customers.CreateAsync(request);
        return response.Customer ?? throw new Exception("Customer creation failed");
    }

    public static CatalogObject CreateTestCatalogItem(CreateCatalogItemOptions options)
    {
        var variation = new CatalogObject(
            new CatalogObjectItemVariation
            {
                Id = NewTestSquareId(),
                PresentAtAllLocations = true,
                ItemVariationData = new CatalogItemVariation
                {
                    Name = options.VariationName ?? $"Variation {NewTestSquareId()}",
                    PricingType = CatalogPricingType.FixedPricing,
                    PriceMoney = new Money
                    {
                        Amount = options.Price ?? 1000,
                        Currency = options.Currency ?? Currency.Usd,
                    },
                },
            }
        );

        return new CatalogObject(
            new CatalogObjectItem
            {
                Id = NewTestSquareId(),
                PresentAtAllLocations = true,
                ItemData = new CatalogItem
                {
                    Name = options.Name ?? $"Item {NewTestSquareId()}",
                    Description = options.Description ?? "Test item description",
                    Abbreviation = options.Abbreviation ?? "TST",
                    Variations = new List<CatalogObject> { variation },
                },
            }
        );
    }

    public static Money NewTestMoney(long amount = 100, Currency? currency = null)
    {
        return new Money { Amount = amount, Currency = currency ?? Currency.Usd };
    }

    public static FileParameter GetTestFile()
    {
        return new FileParameter
        {
            Stream = File.OpenRead("./Files/image.jpeg"),
            FileName = "image.jpeg",
            ContentType = "image/jpeg",
        };
    }

    public static string NewTestSquareId()
    {
        return $"#{Guid.NewGuid():N}";
    }

    public class CreateCatalogItemOptions
    {
        public string? Name { get; set; } = $"Item {Guid.NewGuid():N}";
        public string? Description { get; set; } = "Test item description";
        public string? Abbreviation { get; set; } = "TST";
        public IList<CatalogObject>? Variations { get; set; }
        public long? Price { get; set; } = 100;
        public Currency? Currency { get; set; } = Square.Currency.Usd;
        public string? VariationName { get; set; } = "Regular";
    }
}
