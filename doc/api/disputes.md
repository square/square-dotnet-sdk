# Disputes

```csharp
IDisputesApi disputesApi = client.DisputesApi;
```

## Class Name

`DisputesApi`

## Methods

* [List Disputes](../../doc/api/disputes.md#list-disputes)
* [Retrieve Dispute](../../doc/api/disputes.md#retrieve-dispute)
* [Accept Dispute](../../doc/api/disputes.md#accept-dispute)
* [List Dispute Evidence](../../doc/api/disputes.md#list-dispute-evidence)
* [Create Dispute Evidence File](../../doc/api/disputes.md#create-dispute-evidence-file)
* [Create Dispute Evidence Text](../../doc/api/disputes.md#create-dispute-evidence-text)
* [Delete Dispute Evidence](../../doc/api/disputes.md#delete-dispute-evidence)
* [Retrieve Dispute Evidence](../../doc/api/disputes.md#retrieve-dispute-evidence)
* [Submit Evidence](../../doc/api/disputes.md#submit-evidence)


# List Disputes

Returns a list of disputes associated with a particular account.

```csharp
ListDisputesAsync(
    string cursor = null,
    string states = null,
    string locationId = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>For more information, see [Pagination](https://developer.squareup.com/docs/basics/api101/pagination). |
| `states` | [`string`](../../doc/models/dispute-state.md) | Query, Optional | The dispute states used to filter the result. If not specified, the endpoint returns all disputes. |
| `locationId` | `string` | Query, Optional | The ID of the location for which to return a list of disputes.<br>If not specified, the endpoint returns disputes associated with all locations. |

## Response Type

[`Task<Models.ListDisputesResponse>`](../../doc/models/list-disputes-response.md)

## Example Usage

```csharp
try
{
    ListDisputesResponse result = await disputesApi.ListDisputesAsync(null, null, null);
}
catch (ApiException e){};
```


# Retrieve Dispute

Returns details about a specific dispute.

```csharp
RetrieveDisputeAsync(
    string disputeId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute you want more details about. |

## Response Type

[`Task<Models.RetrieveDisputeResponse>`](../../doc/models/retrieve-dispute-response.md)

## Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    RetrieveDisputeResponse result = await disputesApi.RetrieveDisputeAsync(disputeId);
}
catch (ApiException e){};
```


# Accept Dispute

Accepts the loss on a dispute. Square returns the disputed amount to the cardholder and
updates the dispute state to ACCEPTED.

Square debits the disputed amount from the seller’s Square account. If the Square account
does not have sufficient funds, Square debits the associated bank account.

```csharp
AcceptDisputeAsync(
    string disputeId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute you want to accept. |

## Response Type

[`Task<Models.AcceptDisputeResponse>`](../../doc/models/accept-dispute-response.md)

## Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    AcceptDisputeResponse result = await disputesApi.AcceptDisputeAsync(disputeId);
}
catch (ApiException e){};
```


# List Dispute Evidence

Returns a list of evidence associated with a dispute.

```csharp
ListDisputeEvidenceAsync(
    string disputeId,
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute. |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this cursor to retrieve the next set of results for the original query.<br>For more information, see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Response Type

[`Task<Models.ListDisputeEvidenceResponse>`](../../doc/models/list-dispute-evidence-response.md)

## Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    ListDisputeEvidenceResponse result = await disputesApi.ListDisputeEvidenceAsync(disputeId, null);
}
catch (ApiException e){};
```


# Create Dispute Evidence File

Uploads a file to use as evidence in a dispute challenge. The endpoint accepts HTTP
multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG, and TIFF formats.

```csharp
CreateDisputeEvidenceFileAsync(
    string disputeId,
    Models.CreateDisputeEvidenceFileRequest request = null,
    FileStreamInfo imageFile = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute for which you want to upload evidence. |
| `request` | [`Models.CreateDisputeEvidenceFileRequest`](../../doc/models/create-dispute-evidence-file-request.md) | Form (JSON-Encoded), Optional | Defines the parameters for a `CreateDisputeEvidenceFile` request. |
| `imageFile` | `FileStreamInfo` | Form, Optional | - |

## Response Type

[`Task<Models.CreateDisputeEvidenceFileResponse>`](../../doc/models/create-dispute-evidence-file-response.md)

## Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    CreateDisputeEvidenceFileResponse result = await disputesApi.CreateDisputeEvidenceFileAsync(disputeId, null, null);
}
catch (ApiException e){};
```


# Create Dispute Evidence Text

Uploads text to use as evidence for a dispute challenge.

```csharp
CreateDisputeEvidenceTextAsync(
    string disputeId,
    Models.CreateDisputeEvidenceTextRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute for which you want to upload evidence. |
| `body` | [`Models.CreateDisputeEvidenceTextRequest`](../../doc/models/create-dispute-evidence-text-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateDisputeEvidenceTextResponse>`](../../doc/models/create-dispute-evidence-text-response.md)

## Example Usage

```csharp
string disputeId = "dispute_id2";
var body = new CreateDisputeEvidenceTextRequest.Builder(
        "ed3ee3933d946f1514d505d173c82648",
        "1Z8888888888888888")
    .EvidenceType("TRACKING_NUMBER")
    .Build();

try
{
    CreateDisputeEvidenceTextResponse result = await disputesApi.CreateDisputeEvidenceTextAsync(disputeId, body);
}
catch (ApiException e){};
```


# Delete Dispute Evidence

Removes specified evidence from a dispute.
Square does not send the bank any evidence that is removed.

```csharp
DeleteDisputeEvidenceAsync(
    string disputeId,
    string evidenceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute from which you want to remove evidence. |
| `evidenceId` | `string` | Template, Required | The ID of the evidence you want to remove. |

## Response Type

[`Task<Models.DeleteDisputeEvidenceResponse>`](../../doc/models/delete-dispute-evidence-response.md)

## Example Usage

```csharp
string disputeId = "dispute_id2";
string evidenceId = "evidence_id2";

try
{
    DeleteDisputeEvidenceResponse result = await disputesApi.DeleteDisputeEvidenceAsync(disputeId, evidenceId);
}
catch (ApiException e){};
```


# Retrieve Dispute Evidence

Returns the metadata for the evidence specified in the request URL path.

You must maintain a copy of any evidence uploaded if you want to reference it later. Evidence cannot be downloaded after you upload it.

```csharp
RetrieveDisputeEvidenceAsync(
    string disputeId,
    string evidenceId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute from which you want to retrieve evidence metadata. |
| `evidenceId` | `string` | Template, Required | The ID of the evidence to retrieve. |

## Response Type

[`Task<Models.RetrieveDisputeEvidenceResponse>`](../../doc/models/retrieve-dispute-evidence-response.md)

## Example Usage

```csharp
string disputeId = "dispute_id2";
string evidenceId = "evidence_id2";

try
{
    RetrieveDisputeEvidenceResponse result = await disputesApi.RetrieveDisputeEvidenceAsync(disputeId, evidenceId);
}
catch (ApiException e){};
```


# Submit Evidence

Submits evidence to the cardholder's bank.

The evidence submitted by this endpoint includes evidence uploaded
using the [CreateDisputeEvidenceFile](../../doc/api/disputes.md#create-dispute-evidence-file) and
[CreateDisputeEvidenceText](../../doc/api/disputes.md#create-dispute-evidence-text) endpoints and
evidence automatically provided by Square, when available. Evidence cannot be removed from
a dispute after submission.

```csharp
SubmitEvidenceAsync(
    string disputeId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute for which you want to submit evidence. |

## Response Type

[`Task<Models.SubmitEvidenceResponse>`](../../doc/models/submit-evidence-response.md)

## Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    SubmitEvidenceResponse result = await disputesApi.SubmitEvidenceAsync(disputeId);
}
catch (ApiException e){};
```

