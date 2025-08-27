
namespace MultiCron;

public class Switchboard(IServiceCollection services)
{
	private readonly Dictionary<string, bool> _jobs = FindJobs(services);

	public Dictionary<string, bool> Jobs => _jobs;

	public bool IsDisabled() => _jobs.TryGetValue(GetType().Name, out var isEnabled) && !isEnabled;

	private static Dictionary<string, bool> FindJobs(IServiceCollection services) => 
		services.Where(s => s.ServiceType.IsSubclassOf(typeof(Jobs.JobBase)))
			.Select(s => s.ServiceType.Name)
			.Distinct()
			.ToDictionary(name => name, _ => true);
}
