using Coravel.Invocable;

namespace MultiCron.Jobs;

public class JobOne(Switchboard switchboard) : JobBase(switchboard), IInvocable
{
    public async Task Invoke()
    {
        if (Switchboard.IsDisabled(nameof(JobOne)))
        {
            Console.WriteLine($"Skipping {GetType().Name} as it is disabled in the Switchboard.");
            return;
        }

        Console.WriteLine($"I am {GetType().Name}");
        await Task.CompletedTask;
    }
}
