namespace MultiCron;

public class Switchboard(IEnumerable<string> jobNames)
{
    private readonly Dictionary<string, bool> _jobs = jobNames.Distinct().ToDictionary(name => name, _ => true);

    public Dictionary<string, bool> Jobs => _jobs;

    public bool IsDisabled(string jobName) => _jobs.TryGetValue(jobName, out var isEnabled) && !isEnabled;
}
