using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using S00190492_Creche.Model;
using Microsoft.AspNetCore.Http;

namespace S00190492_Creche.Pages.Student
{
    public class Student_Information_FormModel : PageModel
    {
        private readonly CrecheContext _db;

        public Student_Information_FormModel(CrecheContext db)
        {
            _db = db;
        }

        [BindProperty]
        public S00190492_Creche.Model.Student Student { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid && Student.MethodDaysOfWeek() && Student.MethodCheckDateStart() && Student.MethodCheckDateBirth())
            {
                
                _db.Students.Add(Student);
                await _db.SaveChangesAsync();
                //return RedirectToPage("ValueDetails", Student);

                //Feedback from project
                return RedirectToPage("ValueDetails", new { id = Student.ID });

            }
            else
            {
                return Page();
            }
        }

    }
}