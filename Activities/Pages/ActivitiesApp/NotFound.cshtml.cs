using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Activities.Pages.ActivitiesApp
{
    public class NotFoundModel : PageModel
    {
        public int? Code { get; set; }
        public void OnGet(int? code)
        {
            if(code.HasValue)
            {
                Code = code.Value;
            }
        }
    }
}
