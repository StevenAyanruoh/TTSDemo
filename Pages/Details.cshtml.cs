using Microsoft.AspNetCore.Mvc.RazorPages;

public class DetailsModel : PageModel
{
    public string Title { get; set; }
    public void OnGet(string title)
    {
        Title = title;
    }
}