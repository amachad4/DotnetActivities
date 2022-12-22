using Activities.Data;
using Activities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Activities.Pages.ActivitiesApp
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Activity>? Activities { get; set; }
        public Activity? SingleActivity { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                SingleActivity = _db.Activities.Find(id.Value);
                if (SingleActivity == null)
                {
                    return RedirectToPage("NotFound");
                }
            }
            else
            {
                Activities = _db.Activities.OrderBy(activity => activity.Id);
            }
            return Page();
        }
    }
}
