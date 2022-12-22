using Activities.Data;
using Activities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Activities.Pages.ActivitiesApp
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Activity? Activity { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Activity = _db.Activities.Find(id);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid && Activity != null)
            {
                _db.Activities.Update(Activity);
                await _db.SaveChangesAsync();
                TempData["success"] = "Successfully updated the activity";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
