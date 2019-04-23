using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S00190492_Creche.Model;

namespace S00190492_Creche.Pages.Student
{
    public class DetailPageModel : PageModel
    {
        private readonly CrecheContext _db;

        public DetailPageModel(CrecheContext db)
        {
            _db = db;
        }

        [BindProperty]
        public S00190492_Creche.Model.Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Student = await _db.Students.FindAsync(id);

            return Page();
        }

       
    }
}