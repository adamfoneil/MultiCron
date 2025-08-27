using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace MultiCron.Pages;

public class IndexModel(
    ILogger<IndexModel> logger,
    Switchboard switchboard) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
	public readonly Switchboard Switchboard = switchboard;

	public void OnGet()
    {

    }

    public IActionResult OnPostToggleJob(string jobKey)
    {
        if (Switchboard.Jobs.TryGetValue(jobKey, out bool value))
        {
            Switchboard.Jobs[jobKey] = !value;
        }
        return RedirectToPage();
    }
}
