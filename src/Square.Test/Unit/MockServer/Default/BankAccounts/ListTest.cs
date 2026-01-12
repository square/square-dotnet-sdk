using NUnit.Framework;
using Square.Default.BankAccounts;
using Square.Test.Unit.MockServer;

namespace Square.Test.Unit.MockServer.Default.BankAccounts;

[TestFixture]
public class ListTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "errors": [
                {
                  "category": "API_ERROR",
                  "code": "INTERNAL_SERVER_ERROR",
                  "detail": "detail",
                  "field": "field"
                }
              ],
              "bank_accounts": [
                {
                  "id": "ao6iaQ9vhDiaQD7n3GB",
                  "account_number_suffix": "971",
                  "country": "US",
                  "currency": "USD",
                  "account_type": "CHECKING",
                  "holder_name": "Jane Doe",
                  "primary_bank_identification_number": "112200303",
                  "secondary_bank_identification_number": "secondary_bank_identification_number",
                  "debit_mandate_reference_id": "debit_mandate_reference_id",
                  "reference_id": "reference_id",
                  "location_id": "S8GWD5example",
                  "status": "VERIFICATION_IN_PROGRESS",
                  "creditable": false,
                  "debitable": false,
                  "fingerprint": "fingerprint",
                  "version": 5,
                  "bank_name": "Bank Name"
                },
                {
                  "id": "4x7WXuaxrkQkVlka3GB",
                  "account_number_suffix": "972",
                  "country": "US",
                  "currency": "USD",
                  "account_type": "CHECKING",
                  "holder_name": "Jane Doe",
                  "primary_bank_identification_number": "112200303",
                  "secondary_bank_identification_number": "secondary_bank_identification_number",
                  "debit_mandate_reference_id": "debit_mandate_reference_id",
                  "reference_id": "reference_id",
                  "location_id": "S8GWD5example",
                  "status": "VERIFICATION_IN_PROGRESS",
                  "creditable": false,
                  "debitable": false,
                  "fingerprint": "fingerprint",
                  "version": 5,
                  "bank_name": "Bank Name"
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
            }
        );
        await foreach (var item in items)
        {
            Assert.That(item, Is.Not.Null);
            break; // Only check the first item
        }
    }
}
