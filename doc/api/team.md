# Team

```csharp
ITeamApi teamApi = client.TeamApi;
```

## Class Name

`TeamApi`

## Methods

* [Create Team Member](../../doc/api/team.md#create-team-member)
* [Bulk Create Team Members](../../doc/api/team.md#bulk-create-team-members)
* [Bulk Update Team Members](../../doc/api/team.md#bulk-update-team-members)
* [List Jobs](../../doc/api/team.md#list-jobs)
* [Create Job](../../doc/api/team.md#create-job)
* [Retrieve Job](../../doc/api/team.md#retrieve-job)
* [Update Job](../../doc/api/team.md#update-job)
* [Search Team Members](../../doc/api/team.md#search-team-members)
* [Retrieve Team Member](../../doc/api/team.md#retrieve-team-member)
* [Update Team Member](../../doc/api/team.md#update-team-member)
* [Retrieve Wage Setting](../../doc/api/team.md#retrieve-wage-setting)
* [Update Wage Setting](../../doc/api/team.md#update-wage-setting)


# Create Team Member

Creates a single `TeamMember` object. The `TeamMember` object is returned on successful creates.
You must provide the following values in your request to this endpoint:

- `given_name`
- `family_name`

Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#createteammember).

```csharp
CreateTeamMemberAsync(
    Models.CreateTeamMemberRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateTeamMemberRequest`](../../doc/models/create-team-member-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateTeamMemberResponse>`](../../doc/models/create-team-member-response.md)

## Example Usage

```csharp
CreateTeamMemberRequest body = new CreateTeamMemberRequest.Builder()
.IdempotencyKey("idempotency-key-0")
.TeamMember(
    new TeamMember.Builder()
    .ReferenceId("reference_id_1")
    .Status("ACTIVE")
    .GivenName("Joe")
    .FamilyName("Doe")
    .EmailAddress("joe_doe@gmail.com")
    .PhoneNumber("+14159283333")
    .AssignedLocations(
        new TeamMemberAssignedLocations.Builder()
        .AssignmentType("EXPLICIT_LOCATIONS")
        .LocationIds(
            new List<string>
            {
                "YSGH2WBKG94QZ",
                "GA2Y9HSJ8KRYT",
            })
        .Build())
    .WageSetting(
        new WageSetting.Builder()
        .JobAssignments(
            new List<JobAssignment>
            {
                new JobAssignment.Builder(
                    "SALARY"
                )
                .AnnualRate(
                    new Money.Builder()
                    .Amount(3000000L)
                    .Currency("USD")
                    .Build())
                .WeeklyHours(40)
                .JobId("FjS8x95cqHiMenw4f1NAUH4P")
                .Build(),
                new JobAssignment.Builder(
                    "HOURLY"
                )
                .HourlyRate(
                    new Money.Builder()
                    .Amount(2000L)
                    .Currency("USD")
                    .Build())
                .JobId("VDNpRv8da51NU8qZFC5zDWpF")
                .Build(),
            })
        .IsOvertimeExempt(true)
        .Build())
    .Build())
.Build();

try
{
    CreateTeamMemberResponse result = await teamApi.CreateTeamMemberAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Create Team Members

Creates multiple `TeamMember` objects. The created `TeamMember` objects are returned on successful creates.
This process is non-transactional and processes as much of the request as possible. If one of the creates in
the request cannot be successfully processed, the request is not marked as failed, but the body of the response
contains explicit error information for the failed create.

Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-create-team-members).

```csharp
BulkCreateTeamMembersAsync(
    Models.BulkCreateTeamMembersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkCreateTeamMembersRequest`](../../doc/models/bulk-create-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkCreateTeamMembersResponse>`](../../doc/models/bulk-create-team-members-response.md)

## Example Usage

```csharp
BulkCreateTeamMembersRequest body = new BulkCreateTeamMembersRequest.Builder(
    new Dictionary<string, CreateTeamMemberRequest>
    {
        ["idempotency-key-1"] = new CreateTeamMemberRequest.Builder()
        .TeamMember(
            new TeamMember.Builder()
            .ReferenceId("reference_id_1")
            .GivenName("Joe")
            .FamilyName("Doe")
            .EmailAddress("joe_doe@gmail.com")
            .PhoneNumber("+14159283333")
            .AssignedLocations(
                new TeamMemberAssignedLocations.Builder()
                .AssignmentType("EXPLICIT_LOCATIONS")
                .LocationIds(
                    new List<string>
                    {
                        "YSGH2WBKG94QZ",
                        "GA2Y9HSJ8KRYT",
                    })
                .Build())
            .Build())
        .Build(),
        ["idempotency-key-2"] = new CreateTeamMemberRequest.Builder()
        .TeamMember(
            new TeamMember.Builder()
            .ReferenceId("reference_id_2")
            .GivenName("Jane")
            .FamilyName("Smith")
            .EmailAddress("jane_smith@gmail.com")
            .PhoneNumber("+14159223334")
            .AssignedLocations(
                new TeamMemberAssignedLocations.Builder()
                .AssignmentType("ALL_CURRENT_AND_FUTURE_LOCATIONS")
                .Build())
            .Build())
        .Build(),
    }
)
.Build();

try
{
    BulkCreateTeamMembersResponse result = await teamApi.BulkCreateTeamMembersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Bulk Update Team Members

Updates multiple `TeamMember` objects. The updated `TeamMember` objects are returned on successful updates.
This process is non-transactional and processes as much of the request as possible. If one of the updates in
the request cannot be successfully processed, the request is not marked as failed, but the body of the response
contains explicit error information for the failed update.
Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#bulk-update-team-members).

```csharp
BulkUpdateTeamMembersAsync(
    Models.BulkUpdateTeamMembersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`BulkUpdateTeamMembersRequest`](../../doc/models/bulk-update-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.BulkUpdateTeamMembersResponse>`](../../doc/models/bulk-update-team-members-response.md)

## Example Usage

```csharp
BulkUpdateTeamMembersRequest body = new BulkUpdateTeamMembersRequest.Builder(
    new Dictionary<string, UpdateTeamMemberRequest>
    {
        ["AFMwA08kR-MIF-3Vs0OE"] = new UpdateTeamMemberRequest.Builder()
        .TeamMember(
            new TeamMember.Builder()
            .ReferenceId("reference_id_2")
            .Status("ACTIVE")
            .GivenName("Jane")
            .FamilyName("Smith")
            .EmailAddress("jane_smith@gmail.com")
            .PhoneNumber("+14159223334")
            .AssignedLocations(
                new TeamMemberAssignedLocations.Builder()
                .AssignmentType("ALL_CURRENT_AND_FUTURE_LOCATIONS")
                .Build())
            .Build())
        .Build(),
        ["fpgteZNMaf0qOK-a4t6P"] = new UpdateTeamMemberRequest.Builder()
        .TeamMember(
            new TeamMember.Builder()
            .ReferenceId("reference_id_1")
            .Status("ACTIVE")
            .GivenName("Joe")
            .FamilyName("Doe")
            .EmailAddress("joe_doe@gmail.com")
            .PhoneNumber("+14159283333")
            .AssignedLocations(
                new TeamMemberAssignedLocations.Builder()
                .AssignmentType("EXPLICIT_LOCATIONS")
                .LocationIds(
                    new List<string>
                    {
                        "YSGH2WBKG94QZ",
                        "GA2Y9HSJ8KRYT",
                    })
                .Build())
            .Build())
        .Build(),
    }
)
.Build();

try
{
    BulkUpdateTeamMembersResponse result = await teamApi.BulkUpdateTeamMembersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# List Jobs

Lists jobs in a seller account. Results are sorted by title in ascending order.

```csharp
ListJobsAsync(
    string cursor = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `cursor` | `string` | Query, Optional | The pagination cursor returned by the previous call to this endpoint. Provide this<br>cursor to retrieve the next page of results for your original request. For more information,<br>see [Pagination](https://developer.squareup.com/docs/build-basics/common-api-patterns/pagination). |

## Response Type

[`Task<Models.ListJobsResponse>`](../../doc/models/list-jobs-response.md)

## Example Usage

```csharp
try
{
    ListJobsResponse result = await teamApi.ListJobsAsync();
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Create Job

Creates a job in a seller account. A job defines a title and tip eligibility. Note that
compensation is defined in a [job assignment](../../doc/models/job-assignment.md) in a team member's wage setting.

```csharp
CreateJobAsync(
    Models.CreateJobRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`CreateJobRequest`](../../doc/models/create-job-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.CreateJobResponse>`](../../doc/models/create-job-response.md)

## Example Usage

```csharp
CreateJobRequest body = new CreateJobRequest.Builder(
    new Job.Builder()
    .Title("Cashier")
    .IsTipEligible(true)
    .Build(),
    "idempotency-key-0"
)
.Build();

try
{
    CreateJobResponse result = await teamApi.CreateJobAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Job

Retrieves a specified job.

```csharp
RetrieveJobAsync(
    string jobId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `jobId` | `string` | Template, Required | The ID of the job to retrieve. |

## Response Type

[`Task<Models.RetrieveJobResponse>`](../../doc/models/retrieve-job-response.md)

## Example Usage

```csharp
string jobId = "job_id2";
try
{
    RetrieveJobResponse result = await teamApi.RetrieveJobAsync(jobId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Job

Updates the title or tip eligibility of a job. Changes to the title propagate to all
`JobAssignment`, `Shift`, and `TeamMemberWage` objects that reference the job ID. Changes to
tip eligibility propagate to all `TeamMemberWage` objects that reference the job ID.

```csharp
UpdateJobAsync(
    string jobId,
    Models.UpdateJobRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `jobId` | `string` | Template, Required | The ID of the job to update. |
| `body` | [`UpdateJobRequest`](../../doc/models/update-job-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateJobResponse>`](../../doc/models/update-job-response.md)

## Example Usage

```csharp
string jobId = "job_id2";
UpdateJobRequest body = new UpdateJobRequest.Builder(
    new Job.Builder()
    .Title("Cashier 1")
    .IsTipEligible(true)
    .Build()
)
.Build();

try
{
    UpdateJobResponse result = await teamApi.UpdateJobAsync(
        jobId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Search Team Members

Returns a paginated list of `TeamMember` objects for a business.
The list can be filtered by location IDs, `ACTIVE` or `INACTIVE` status, or whether
the team member is the Square account owner.

```csharp
SearchTeamMembersAsync(
    Models.SearchTeamMembersRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`SearchTeamMembersRequest`](../../doc/models/search-team-members-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.SearchTeamMembersResponse>`](../../doc/models/search-team-members-response.md)

## Example Usage

```csharp
SearchTeamMembersRequest body = new SearchTeamMembersRequest.Builder()
.Query(
    new SearchTeamMembersQuery.Builder()
    .Filter(
        new SearchTeamMembersFilter.Builder()
        .LocationIds(
            new List<string>
            {
                "0G5P3VGACMMQZ",
            })
        .Status("ACTIVE")
        .Build())
    .Build())
.Limit(10)
.Build();

try
{
    SearchTeamMembersResponse result = await teamApi.SearchTeamMembersAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Team Member

Retrieves a `TeamMember` object for the given `TeamMember.id`.
Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrieve-a-team-member).

```csharp
RetrieveTeamMemberAsync(
    string teamMemberId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to retrieve. |

## Response Type

[`Task<Models.RetrieveTeamMemberResponse>`](../../doc/models/retrieve-team-member-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";
try
{
    RetrieveTeamMemberResponse result = await teamApi.RetrieveTeamMemberAsync(teamMemberId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Team Member

Updates a single `TeamMember` object. The `TeamMember` object is returned on successful updates.
Learn about [Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#update-a-team-member).

```csharp
UpdateTeamMemberAsync(
    string teamMemberId,
    Models.UpdateTeamMemberRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member to update. |
| `body` | [`UpdateTeamMemberRequest`](../../doc/models/update-team-member-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateTeamMemberResponse>`](../../doc/models/update-team-member-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";
UpdateTeamMemberRequest body = new UpdateTeamMemberRequest.Builder()
.TeamMember(
    new TeamMember.Builder()
    .ReferenceId("reference_id_1")
    .Status("ACTIVE")
    .GivenName("Joe")
    .FamilyName("Doe")
    .EmailAddress("joe_doe@gmail.com")
    .PhoneNumber("+14159283333")
    .AssignedLocations(
        new TeamMemberAssignedLocations.Builder()
        .AssignmentType("EXPLICIT_LOCATIONS")
        .LocationIds(
            new List<string>
            {
                "YSGH2WBKG94QZ",
                "GA2Y9HSJ8KRYT",
            })
        .Build())
    .Build())
.Build();

try
{
    UpdateTeamMemberResponse result = await teamApi.UpdateTeamMemberAsync(
        teamMemberId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Retrieve Wage Setting

Retrieves a `WageSetting` object for a team member specified
by `TeamMember.id`. For more information, see
[Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#retrievewagesetting).

Square recommends using [RetrieveTeamMember](../../doc/api/team.md#retrieve-team-member) or [SearchTeamMembers](../../doc/api/team.md#search-team-members)
to get this information directly from the `TeamMember.wage_setting` field.

```csharp
RetrieveWageSettingAsync(
    string teamMemberId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member for which to retrieve the wage setting. |

## Response Type

[`Task<Models.RetrieveWageSettingResponse>`](../../doc/models/retrieve-wage-setting-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";
try
{
    RetrieveWageSettingResponse result = await teamApi.RetrieveWageSettingAsync(teamMemberId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update Wage Setting

Creates or updates a `WageSetting` object. The object is created if a
`WageSetting` with the specified `team_member_id` doesn't exist. Otherwise,
it fully replaces the `WageSetting` object for the team member.
The `WageSetting` is returned on a successful update. For more information, see
[Troubleshooting the Team API](https://developer.squareup.com/docs/team/troubleshooting#create-or-update-a-wage-setting).

Square recommends using [CreateTeamMember](../../doc/api/team.md#create-team-member) or [UpdateTeamMember](../../doc/api/team.md#update-team-member)
to manage the `TeamMember.wage_setting` field directly.

```csharp
UpdateWageSettingAsync(
    string teamMemberId,
    Models.UpdateWageSettingRequest body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `teamMemberId` | `string` | Template, Required | The ID of the team member for which to update the `WageSetting` object. |
| `body` | [`UpdateWageSettingRequest`](../../doc/models/update-wage-setting-request.md) | Body, Required | An object containing the fields to POST for the request.<br><br>See the corresponding object definition for field details. |

## Response Type

[`Task<Models.UpdateWageSettingResponse>`](../../doc/models/update-wage-setting-response.md)

## Example Usage

```csharp
string teamMemberId = "team_member_id0";
UpdateWageSettingRequest body = new UpdateWageSettingRequest.Builder(
    new WageSetting.Builder()
    .JobAssignments(
        new List<JobAssignment>
        {
            new JobAssignment.Builder(
                "SALARY"
            )
            .JobTitle("Manager")
            .AnnualRate(
                new Money.Builder()
                .Amount(3000000L)
                .Currency("USD")
                .Build())
            .WeeklyHours(40)
            .Build(),
            new JobAssignment.Builder(
                "HOURLY"
            )
            .JobTitle("Cashier")
            .HourlyRate(
                new Money.Builder()
                .Amount(2000L)
                .Currency("USD")
                .Build())
            .Build(),
        })
    .IsOvertimeExempt(true)
    .Build()
)
.Build();

try
{
    UpdateWageSettingResponse result = await teamApi.UpdateWageSettingAsync(
        teamMemberId,
        body
    );
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

