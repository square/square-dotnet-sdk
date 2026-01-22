using NUnit.Framework;
using Square.Default;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "bank_accounts": [
                {
                  "id": "bact:OxfBTiXgByaXds1K4GB",
                  "account_number_suffix": "000",
                  "country": "US",
                  "currency": "USD",
                  "account_type": "CHECKING",
                  "holder_name": "Nicola Snow",
                  "primary_bank_identification_number": "011401533",
                  "secondary_bank_identification_number": "secondary_bank_identification_number",
                  "debit_mandate_reference_id": "debit_mandate_reference_id",
                  "reference_id": "reference_id",
                  "location_id": "location_id",
                  "status": "VERIFIED",
                  "creditable": true,
                  "debitable": true,
                  "fingerprint": "sq-1-mO3XNctJpTLL8uYowOWpioS8nQyTc838gcBo90254XonoEJ_c7Uw6yqL6qihFNY8fA",
                  "version": 2,
                  "bank_name": "Citizens Bank",
                  "customer_id": "HM3B2D5JKGZ69359BTEHXM2V8M"
                },
                {
                  "id": "bact:Msdfa2kgUDR9lMgk4GB",
                  "account_number_suffix": "118",
                  "country": "US",
                  "currency": "USD",
                  "account_type": "CHECKING",
                  "holder_name": "Nicola Snow",
                  "primary_bank_identification_number": "100210004",
                  "secondary_bank_identification_number": "secondary_bank_identification_number",
                  "debit_mandate_reference_id": "debit_mandate_reference_id",
                  "reference_id": "reference_id",
                  "location_id": "location_id",
                  "status": "DISABLED",
                  "creditable": true,
                  "debitable": true,
                  "fingerprint": "sq-1-Poacr0bohmds1N--OseZUsG5kPwfCGxqYKlb-Q1Rxwsk0lxd1JLs4yaPDuMqIae7Qg",
                  "version": 3,
                  "bank_name": "Bank of America",
                  "customer_id": "HM3B2D5JKGZ69359BTEHXM2V8M"
                }
              ],
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "cursor": "cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/bank-accounts")
                    .WithParam("cursor", "cursor")
                    .WithParam("limit", "1")
                    .WithParam("location_id", "location_id")
                    .WithParam("customer_id", "customer_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var items = await Client.Default.BankAccounts.ListAsync(
            new ListBankAccountsRequest
            {
                Cursor = "cursor",
                Limit = 1,
                LocationId = "location_id",
                CustomerId = "customer_id",
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
