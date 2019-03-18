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
                    Student.TotalDue =TotalDays() * 35m;
                    if(TotalDays()>=4 && TotalDays() <= 5)
                    {
                        Student.TotalDue = Student.TotalDue * 0.9m;
                        Student.Discount = "You got a discount of 10% on the original value";
                    }

                }
                else
                {
                    Student.TotalDue = TotalDays() * 20m;
                    if (TotalDays() >= 4 && TotalDays() <= 5)
                    {
                        Student.TotalDue = Student.TotalDue * 0.9m;
                        Student.Discount = "You got a discount of 10% on the original value";
                    }
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

        public bool CheckDateBirth()
        {
            bool checkDate = false;
            string birthDate = Convert.ToString(Student.DateOfBirth);
            string starDating = Convert.ToString(Student.StartingDate);
            TimeSpan date = Convert.ToDateTime(starDating) - Convert.ToDateTime(birthDate);
            int Days = date.Days;

            if (Days >= 1095 && Days <= 1825)
            {
                checkDate = true;
                Student.CheckDateBirth = "";
            }
            else
            {
                checkDate = false;
                Student.CheckDateBirth = "The date is not valid, the child should be between 3 and 5 years old to start on this date.";
               
            }


            return checkDate; 

            
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid && DaysOfWeek() && CheckDateStart() && CheckDateBirth())
            {
                
                _db.Students.Add(Student);
                await _db.SaveChangesAsync();
                return RedirectToPage("ValueDetails", Student);
                //return RedirectToPage("ValueDetails", new {PPS = Student.PPS});

            }
            else
            {
                return Page();
            }
        }

    }
}