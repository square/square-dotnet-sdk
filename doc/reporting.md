# Reporting

```csharp
IReportingApi reportingApi = client.ReportingApi;
```

## Class Name

`ReportingApi`

## Methods

* [List Additional Recipient Receivable Refunds](/doc/reporting.md#list-additional-recipient-receivable-refunds)
* [List Additional Recipient Receivables](/doc/reporting.md#list-additional-recipient-receivables)

## List Additional Recipient Receivable Refunds

Returns a list of refunded transactions (across all possible originating locations) relating to monies
credited to the provided location ID by another Square account using the `additional_recipients` field in a transaction.

Max results per [page](#paginatingresults): 50

```csharp
ListAdditionalRecipientReceivableRefundsAsync(
    string locationId,
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list AdditionalRecipientReceivableRefunds for. |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.<br><br>Default value: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The end of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.<br><br>Default value: The current time. |
| `sortOrder` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which results are listed in the response (`ASC` for<br>oldest first, `DESC` for newest first).<br><br>Default value: `DESC` |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See [Paginating results](#paginatingresults) for more information. |

### Response Type

[`Task<Models.ListAdditionalRecipientReceivableRefundsResponse>`](/doc/models/list-additional-recipient-receivable-refunds-response.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    ListAdditionalRecipientReceivableRefundsResponse result = reportingApi.ListAdditionalRecipientReceivableRefundsAsync(locationId, null, null, null, null).Result;
}
catch (ApiException e){};
```

## List Additional Recipient Receivables

Returns a list of receivables (across all possible sending locations) representing monies credited
to the provided location ID by another Square account using the `additional_recipients` field in a transaction.

Max results per [page](#paginatingresults): 50

```csharp
ListAdditionalRecipientReceivablesAsync(
    string locationId,
    string beginTime = null,
    string endTime = null,
    string sortOrder = null,
    string cursor = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `locationId` | `string` | Template, Required | The ID of the location to list AdditionalRecipientReceivables for. |
| `beginTime` | `string` | Query, Optional | The beginning of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.<br><br>Default value: The current time minus one year. |
| `endTime` | `string` | Query, Optional | The end of the requested reporting period, in RFC 3339 format.<br><br>See [Date ranges](#dateranges) for details on date inclusivity/exclusivity.<br><br>Default value: The current time. |
| `sortOrder` | [`string`](/doc/models/sort-order.md) | Query, Optional | The order in which results are listed in the response (`ASC` for<br>oldest first, `DESC` for newest first).<br><br>Default value: `DESC` |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for your original query.<br><br>See [Paginating results](#paginatingresults) for more information. |

### Response Type

[`Task<Models.ListAdditionalRecipientReceivablesResponse>`](/doc/models/list-additional-recipient-receivables-response.md)

### Example Usage

```csharp
string locationId = "location_id4";

try
{
    ListAdditionalRecipientReceivablesResponse result = reportingApi.ListAdditionalRecipientReceivablesAsync(locationId, null, null, null, null).Result;
}
catch (ApiException e){};
```

