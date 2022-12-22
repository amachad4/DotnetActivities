using Activities.Data;
using Activities.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Activities.Pages.ActivitiesApp
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Activity? Activity { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Activity = _db.Activities.Find(id);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var activityFromDb = await _db.Activities.FindAsync(Activity?.Id);

            if (activityFromDb != null)
            {
                _db.Activities.Remove(activityFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Successfully deleted the activity";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
