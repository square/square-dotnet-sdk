# Disputes

```csharp
IDisputesApi disputesApi = client.DisputesApi;
```

## Class Name

`DisputesApi`

## Methods

* [List Disputes](/doc/disputes.md#list-disputes)
* [Retrieve Dispute](/doc/disputes.md#retrieve-dispute)
* [Accept Dispute](/doc/disputes.md#accept-dispute)
* [List Dispute Evidence](/doc/disputes.md#list-dispute-evidence)
* [Remove Dispute Evidence](/doc/disputes.md#remove-dispute-evidence)
* [Retrieve Dispute Evidence](/doc/disputes.md#retrieve-dispute-evidence)
* [Create Dispute Evidence File](/doc/disputes.md#create-dispute-evidence-file)
* [Create Dispute Evidence Text](/doc/disputes.md#create-dispute-evidence-text)
* [Submit Evidence](/doc/disputes.md#submit-evidence)

## List Disputes

Returns a list of disputes associated
with a particular account.

```csharp
ListDisputesAsync(string cursor = null, string states = null, string locationId = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | A pagination cursor returned by a previous call to this endpoint.<br>Provide this to retrieve the next set of results for the original query.<br>For more information, see [Paginating](https://developer.squareup.com/docs/basics/api101/pagination). |
| `states` | [`string`](/doc/models/dispute-state.md) | Query, Optional | The dispute states to filter the result.<br>If not specified, the endpoint<br>returns all open disputes (dispute status is not<br>`INQUIRY_CLOSED`, `WON`, or `LOST`). |
| `locationId` | `string` | Query, Optional | The ID of the location for which to return <br>a list of disputes. If not specified,<br>the endpoint returns all open disputes<br>(dispute status is not `INQUIRY_CLOSED`, `WON`, or <br>`LOST`) associated with all locations. |

### Response Type

[`Task<Models.ListDisputesResponse>`](/doc/models/list-disputes-response.md)

### Example Usage

```csharp
string cursor = "cursor6";
string states = "EVIDENCE_REQUIRED";
string locationId = "location_id4";

try
{
    ListDisputesResponse result = await disputesApi.ListDisputesAsync(cursor, states, locationId);
}
catch (ApiException e){};
```

## Retrieve Dispute

Returns details of a specific dispute.

```csharp
RetrieveDisputeAsync(string disputeId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute you want more details about. |

### Response Type

[`Task<Models.RetrieveDisputeResponse>`](/doc/models/retrieve-dispute-response.md)

### Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    RetrieveDisputeResponse result = await disputesApi.RetrieveDisputeAsync(disputeId);
}
catch (ApiException e){};
```

## Accept Dispute

Accepts loss on a dispute. Square returns
the disputed amount to the cardholder and updates the
dispute state to ACCEPTED.

Square debits the disputed amount from the seller’s Square
account. If the Square account balance does not have
sufficient funds, Square debits the associated bank account.
For an overview of the Disputes API, see [Overview](https://developer.squareup.com/docs/docs/disputes-api/overview).

```csharp
AcceptDisputeAsync(string disputeId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | ID of the dispute you want to accept. |

### Response Type

[`Task<Models.AcceptDisputeResponse>`](/doc/models/accept-dispute-response.md)

### Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    AcceptDisputeResponse result = await disputesApi.AcceptDisputeAsync(disputeId);
}
catch (ApiException e){};
```

## List Dispute Evidence

Returns a list of evidence associated with a dispute.

```csharp
ListDisputeEvidenceAsync(string disputeId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute. |

### Response Type

[`Task<Models.ListDisputeEvidenceResponse>`](/doc/models/list-dispute-evidence-response.md)

### Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    ListDisputeEvidenceResponse result = await disputesApi.ListDisputeEvidenceAsync(disputeId);
}
catch (ApiException e){};
```

## Remove Dispute Evidence

Removes specified evidence from a dispute.

Square does not send the bank any evidence that
is removed. Also, you cannot remove evidence after
submitting it to the bank using [SubmitEvidence](https://developer.squareup.com/docs/reference/square/disputes-api/submit-evidence).

```csharp
RemoveDisputeEvidenceAsync(string disputeId, string evidenceId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute you want to remove evidence from. |
| `evidenceId` | `string` | Template, Required | The ID of the evidence you want to remove. |

### Response Type

[`Task<Models.RemoveDisputeEvidenceResponse>`](/doc/models/remove-dispute-evidence-response.md)

### Example Usage

```csharp
string disputeId = "dispute_id2";
string evidenceId = "evidence_id2";

try
{
    RemoveDisputeEvidenceResponse result = await disputesApi.RemoveDisputeEvidenceAsync(disputeId, evidenceId);
}
catch (ApiException e){};
```

## Retrieve Dispute Evidence

Returns the specific evidence metadata associated with a specific dispute.

You must maintain a copy of the evidence you upload if you want to
reference it later. You cannot download the evidence
after you upload it.

```csharp
RetrieveDisputeEvidenceAsync(string disputeId, string evidenceId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute that you want to retrieve evidence from. |
| `evidenceId` | `string` | Template, Required | The ID of the evidence to retrieve. |

### Response Type

[`Task<Models.RetrieveDisputeEvidenceResponse>`](/doc/models/retrieve-dispute-evidence-response.md)

### Example Usage

```csharp
string disputeId = "dispute_id2";
string evidenceId = "evidence_id2";

try
{
    RetrieveDisputeEvidenceResponse result = await disputesApi.RetrieveDisputeEvidenceAsync(disputeId, evidenceId);
}
catch (ApiException e){};
```

## Create Dispute Evidence File

Uploads a file to use as evidence in a dispute challenge. The endpoint accepts
HTTP multipart/form-data file uploads in HEIC, HEIF, JPEG, PDF, PNG,
and TIFF formats.
For more information, see [Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).

```csharp
CreateDisputeEvidenceFileAsync(string disputeId, Models.CreateDisputeEvidenceFileRequest request = null, FileStreamInfo imageFile = null)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | ID of the dispute you want to upload evidence for. |
| `request` | [`Models.CreateDisputeEvidenceFileRequest`](/doc/models/create-dispute-evidence-file-request.md) | Form, Optional | Defines parameters for a CreateDisputeEvidenceFile request. |
| `imageFile` | `FileStreamInfo` | Form, Optional | - |

### Response Type

[`Task<Models.CreateDisputeEvidenceFileResponse>`](/doc/models/create-dispute-evidence-file-response.md)

### Example Usage

```csharp
string disputeId = "dispute_id2";
var request = new CreateDisputeEvidenceFileRequest.Builder(
        "idempotency_key2")
    .EvidenceType("REBUTTAL_EXPLANATION")
    .ContentType("content_type0")
    .Build();
FileStreamInfo imageFile = new FileStreamInfo(new FileStream("dummy_file",FileMode.Open));

try
{
    CreateDisputeEvidenceFileResponse result = await disputesApi.CreateDisputeEvidenceFileAsync(disputeId, request, imageFile);
}
catch (ApiException e){};
```

## Create Dispute Evidence Text

Uploads text to use as evidence for a dispute challenge. For more information, see
[Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).

```csharp
CreateDisputeEvidenceTextAsync(string disputeId, Models.CreateDisputeEvidenceTextRequest body)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute you want to upload evidence for. |
| `body` | [`Models.CreateDisputeEvidenceTextRequest`](/doc/models/create-dispute-evidence-text-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

### Response Type

[`Task<Models.CreateDisputeEvidenceTextResponse>`](/doc/models/create-dispute-evidence-text-response.md)

### Example Usage

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

## Submit Evidence

Submits evidence to the cardholder's bank.

Before submitting evidence, Square compiles all available evidence. This includes
evidence uploaded using the
[CreateDisputeEvidenceFile](https://developer.squareup.com/docs/reference/square/disputes-api/create-dispute-evidence-file) and
[CreateDisputeEvidenceText](https://developer.squareup.com/docs/reference/square/disputes-api/create-dispute-evidence-text) endpoints,
and evidence automatically provided by Square, when
available. For more information, see
[Challenge a Dispute](https://developer.squareup.com/docs/docs/disputes-api/process-disputes#challenge-a-dispute).

```csharp
SubmitEvidenceAsync(string disputeId)
```

### Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `disputeId` | `string` | Template, Required | The ID of the dispute you want to submit evidence for. |

### Response Type

[`Task<Models.SubmitEvidenceResponse>`](/doc/models/submit-evidence-response.md)

### Example Usage

```csharp
string disputeId = "dispute_id2";

try
{
    SubmitEvidenceResponse result = await disputesApi.SubmitEvidenceAsync(disputeId);
}
catch (ApiException e){};
```

