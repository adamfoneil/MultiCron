using Coravel;
using MultiCron.Jobs;

namespace MultiCron;

internal static class JobSetup
{
	// add all your jobs to the service collection here
	internal static void AddJobs(this IServiceCollection services)
	{
		services.AddScheduler(); // main Coravel service		
		services.AddSingleton<JobOne>();
		services.AddSingleton<JobTwo>();

		// Collect job names
		var jobNames = new[] { nameof(JobOne), nameof(JobTwo) };
		services.AddSingleton(new Switchboard(jobNames)); // controls which jobs are active
	}

	internal static void ScheduleJobs(this IServiceProvider provider)
	{
		provider.UseScheduler(scheduler =>
		{
			// set whatever schedule makes sense
			scheduler.Schedule<JobOne>().EverySeconds(5).PreventOverlapping(nameof(JobOne));
			scheduler.Schedule<JobTwo>().EverySeconds(3).PreventOverlapping(nameof(JobTwo));
		});
	}
}
