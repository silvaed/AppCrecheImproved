using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using S00190492_Creche.Model;

namespace S00190492_Creche.Pages.Student
{
    public class ListStudentsModel : PageModel
    {
        private readonly CrecheContext _db;

        public ListStudentsModel(CrecheContext db)
        {
            _db = db;
        }

        public IList<S00190492_Creche.Model.Student> Students { get; private set; }

        
        public S00190492_Creche.Model.Student Student { get; private set; }
        
        [BindProperty]
        public string Edit { get; set; }
        [BindProperty]
        public string Delete { get; set; }
        [BindProperty]
        public string Details { get; set; }

        public async Task OnGetAsync()
        {
            Students = await _db.Students.AsNoTracking().ToListAsync();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (ModelState.IsValid && Edit != null)
            {
                Student = await _db.Students.FindAsync(Edit);
                
                return RedirectToPage("EditPage", new { id = Student.ID });

            }
            else if (ModelState.IsValid && Delete != null)
            {
                Student = await _db.Students.FindAsync(Delete);
                _db.Students.Remove(Student);
                _db.SaveChanges();
                Students = await _db.Students.AsNoTracking().ToListAsync();
                return Page();

            }
            else if (ModelState.IsValid && Details != null)
            {
                Student = await _db.Students.FindAsync(Details);

                return RedirectToPage("DetailPage", new { id = Student.ID });

            }
            else
            {
                return Page();
            }
            
        }


    }
}