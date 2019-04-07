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
    public class ValueDetailsModel : PageModel
    {
        private readonly CrecheContext _db;

        public ValueDetailsModel(CrecheContext db)
        {
            _db = db;
        }

        
        //[BindProperty(SupportsGet = true)]
        //public S00190492_Creche.Model.Student Student { get; set; }



        //Feedback from project
        public S00190492_Creche.Model.Student Student { get; set; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            Student = await _db.Students.FindAsync(id);

            return Page();
        }

    }
}