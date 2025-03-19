using Square.Core;
using Square.Labor.BreakTypes;
using Square.Labor.EmployeeWages;
using Square.Labor.Shifts;
using Square.Labor.TeamMemberWages;
using Square.Labor.WorkweekConfigs;

namespace Square.Labor;

public partial class LaborClient
{
    private RawClient _client;

    internal LaborClient(RawClient client)
    {
        _client = client;
        BreakTypes = new BreakTypesClient(_client);
        EmployeeWages = new EmployeeWagesClient(_client);
        Shifts = new ShiftsClient(_client);
        TeamMemberWages = new TeamMemberWagesClient(_client);
        WorkweekConfigs = new WorkweekConfigsClient(_client);
    }

    public BreakTypesClient BreakTypes { get; }

    public EmployeeWagesClient EmployeeWages { get; }

    public ShiftsClient Shifts { get; }

    public TeamMemberWagesClient TeamMemberWages { get; }

    public WorkweekConfigsClient WorkweekConfigs { get; }
}
