using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_Pages.Pages;

public class MyPageModel : PageModel
{
    public string Message { get; private set; } = "";

    public void OnGet()
    {
        Message = "Hello Razor!";
    }
}
