# Bank Accounts

```csharp
IBankAccountsApi bankAccountsApi = client.BankAccountsApi;
```

## Class Name

`BankAccountsApi`

## Methods

* [List Bank Accounts](../../doc/api/bank-accounts.md#list-bank-accounts)
* [Get Bank Account by V1 Id](../../doc/api/bank-accounts.md#get-bank-account-by-v1-id)
* [Get Bank Account](../../doc/api/bank-accounts.md#get-bank-account)


# List Bank Accounts

Returns a list of [BankAccount](../../doc/models/bank-account.md) objects linked to a Square account.

```csharp
ListBankAccountsAsync(
    string cursor = null,
    int? limit = null,
    string locationId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | The pagination cursor returned by a previous call to this endpoint.<br>Use it in the next `ListBankAccounts` request to retrieve the next set<br>of results.<br><br>See the [Pagination](https://developer.squareup.com/docs/working-with-apis/pagination) guide for more information. |
| `limit` | `int?` | Query, Optional | Upper limit on the number of bank accounts to return in the response.<br>Currently, 1000 is the largest supported limit. You can specify a limit<br>of up to 1000 bank accounts. This is also the default limit. |
| `locationId` | `string` | Query, Optional | Location ID. You can specify this optional filter<br>to retrieve only the linked bank accounts belonging to a specific location. |

## Response Type

[`Task<Models.ListBankAccountsResponse>`](../../doc/models/list-bank-accounts-response.md)

## Example Usage

```csharp
try
{
    ListBankAccountsResponse result = await bankAccountsApi.ListBankAccountsAsync(null, null, null);
}
catch (ApiException e){};
```


# Get Bank Account by V1 Id

Returns details of a [BankAccount](../../doc/models/bank-account.md) identified by V1 bank account ID.

```csharp
GetBankAccountByV1IdAsync(
    string v1BankAccountId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `v1BankAccountId` | `string` | Template, Required | Connect V1 ID of the desired `BankAccount`. For more information, see<br>[Retrieve a bank account by using an ID issued by V1 Bank Accounts API](https://developer.squareup.com/docs/bank-accounts-api#retrieve-a-bank-account-by-using-an-id-issued-by-v1-bank-accounts-api). |

## Response Type

[`Task<Models.GetBankAccountByV1IdResponse>`](../../doc/models/get-bank-account-by-v1-id-response.md)

## Example Usage

```csharp
string v1BankAccountId = "v1_bank_account_id8";

try
{
    GetBankAccountByV1IdResponse result = await bankAccountsApi.GetBankAccountByV1IdAsync(v1BankAccountId);
}
catch (ApiException e){};
```


# Get Bank Account

Returns details of a [BankAccount](../../doc/models/bank-account.md)
linked to a Square account.

```csharp
GetBankAccountAsync(
    string bankAccountId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `bankAccountId` | `string` | Template, Required | Square-issued ID of the desired `BankAccount`. |

## Response Type

[`Task<Models.GetBankAccountResponse>`](../../doc/models/get-bank-account-response.md)

## Example Usage

```csharp
string bankAccountId = "bank_account_id0";

try
{
    GetBankAccountResponse result = await bankAccountsApi.GetBankAccountAsync(bankAccountId);
}
catch (ApiException e){};
```

