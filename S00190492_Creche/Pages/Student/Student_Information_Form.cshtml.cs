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

        public bool DaysOfWeek()
        {
            bool atLeastADay;
            if (Student.Monday == true || Student.Tuesday == true || Student.Wednesday == true || Student.Thursday == true || Student.Friday == true)
            {
                if (Student.Monday) Student.DaysOfWeek += "Monday ";
                if (Student.Tuesday) Student.DaysOfWeek += "Tuesday ";
                if (Student.Wednesday) Student.DaysOfWeek += "Wednesday ";
                if (Student.Thursday) Student.DaysOfWeek += "Thursday ";
                if (Student.Friday) Student.DaysOfWeek += "Friday";
                Student.CheckDaysOfWeek = "";
                
                if(Student.Hours == "Full Time")
                {
                    Student.TotalDue =TotalDays() * 35;
                }
                else
                {
                    Student.TotalDue = TotalDays() * 20;
                }


                atLeastADay = true;
            }
            else
            {
                Student.CheckDaysOfWeek = "You need to select at least a day of the week";
                atLeastADay = false;
            }


            return atLeastADay;
        }

        public bool CheckDateStart()
        {
            bool checkDates = false;
            if (Student.StartingDate > DateTime.Now)
            {
                Student.CheckDateStart = "";
                checkDates = true;
            }
            else
            {
                Student.CheckDateStart = "The date is not valid";
                checkDates = false;
            }
            return checkDates;
        }

        public int TotalDays()
        {
            int numberOfDays = 0;
            if (Student.Monday) numberOfDays += 1;
            if (Student.Tuesday) numberOfDays += 1;
            if (Student.Wednesday) numberOfDays += 1;
            if (Student.Thursday) numberOfDays += 1;
            if (Student.Friday) numberOfDays += 1;

            return numberOfDays;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid && DaysOfWeek() && CheckDateStart() )
            {
                
                _db.Students.Add(Student);
                await _db.SaveChangesAsync();
                return RedirectToPage("ValueDetails");

            }
            else
            {
                return Page();
            }
        }

    }
}