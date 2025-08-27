using Coravel.Invocable;

namespace MultiCron.Jobs;

public class JobTwo(Switchboard switchboard) : JobBase(switchboard), IInvocable
{
    public async Task Invoke()
    {
        if (Switchboard.IsDisabled(nameof(JobTwo)))
        {
            Console.WriteLine($"Skipping {GetType().Name} as it is disabled in the Switchboard.");
            return;
        }

        Console.WriteLine($"I am {GetType().Name}");
        await Task.CompletedTask;
    }
}
