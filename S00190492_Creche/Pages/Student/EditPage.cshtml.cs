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
    public class EditPageModel : PageModel
    {
        private readonly CrecheContext _db;

        public EditPageModel(CrecheContext db)
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


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid && Student.MethodDaysOfWeek() && Student.MethodCheckDateStart() && Student.MethodCheckDateBirth())
            {

                S00190492_Creche.Model.Student Student2 = await _db.Students.FindAsync(Student.ID);
                Student2.ID = Student.ID;
                Student2.ChildFirstName = Student.ChildFirstName;
                Student2.Address = Student.Address;
                Student2.ChildLastName = Student.ChildLastName;
                Student2.City = Student.City;
                Student2.DateOfBirth = Student.DateOfBirth;
                Student2.Email = Student.Email;
                Student2.SecondEmail = Student.SecondEmail;
                Student2.StartingDate = Student.StartingDate;
                Student2.PPS = Student.PPS;
                Student2.Gender = Student.Gender;
                Student2.ParentFirstName = Student.ParentFirstName;
                Student2.ParentLastName = Student.ParentLastName;
                Student2.RelationshipToChild = Student.RelationshipToChild;
                Student2.ZipCode = Student.ZipCode;
                Student2.MobileNumber = Student.MobileNumber;
                Student2.SecondContactNumber = Student.SecondContactNumber;
                Student2.Hours = Student.Hours;
                Student2.DaysOfWeek = Student.DaysOfWeek;
                Student2.TotalDue = Student.TotalDue;
                Student2.DiscountValue = Student.DiscountValue;

                // _db.Students.Update(Student2);
                //Student2 = Student;
                await _db.SaveChangesAsync();
                //return RedirectToPage("ValueDetails", Student);

                //Feedback from project
                return RedirectToPage("ListStudents");

            }
            else
            {
                return Page();
            }
        }


    }
}