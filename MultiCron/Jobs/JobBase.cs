namespace MultiCron.Jobs;

public abstract class JobBase(Switchboard switchboard)
{
	/// <summary>
	/// jobs use this to determine if they should run
	/// </summary>
	protected Switchboard Switchboard { get; } = switchboard;
}