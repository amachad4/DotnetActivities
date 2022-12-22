using Activities.Data;
using Activities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Activities.Pages.ActivitiesApp
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Activity? Activity { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid && Activity != null)
            {
                await _db.Activities.AddAsync(Activity);
                await _db.SaveChangesAsync();
                TempData["success"] = "Successfully created the activity";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
