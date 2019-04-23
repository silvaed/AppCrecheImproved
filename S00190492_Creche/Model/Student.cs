using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S00190492_Creche.Model
{
    public class Student
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        [Required(ErrorMessage = "The child first name is required")]
        [RegularExpression(@"\D{2,}", ErrorMessage = "The first name should have at least 2 characters")]
        [Display(Name = "Child First Name")]
        public string ChildFirstName { get; set; } = "";

        [Required(ErrorMessage = "The child last name is required")]
        [RegularExpression(@"\D{2,}", ErrorMessage = "The last name should have at least 2 characters")]
        [Display(Name = "Child Last Name")]
        public string ChildLastName { get; set; } = "";

        [RegularExpression(@"\d{7,7}[A-Z|a-z]{2,2}", ErrorMessage = "PPS number should have the format 1234567AA or 1234567aa")]
        [Required(ErrorMessage = "The PPS number is required")]
        [Display(Name = "PPS Number")]
        public string PPS { get; set; } = "";

        [Required(ErrorMessage = "You did not put a date or the date is not valid")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Select a gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [RegularExpression(@"\D{2,}", ErrorMessage = "The first name should have at least 2 characters")]
        [Required(ErrorMessage = "The parent first name is required")]
        [Display(Name = "Parent First Name")]
        public string ParentFirstName { get; set; } = "";

        [RegularExpression(@"\D{2,}", ErrorMessage = "The last name should have at least 2 characters")]
        [Required(ErrorMessage = "The parent last name is required")]
        [Display(Name = "Parent Last Name")]
        public string ParentLastName { get; set; } = "";

        [Required(ErrorMessage = "Select a relationship")]
        [Display(Name = "Relationship")]
        public string RelationshipToChild { get; set; }

        [RegularExpression(@"[\w|]{1,1}(\D|\d){3,}", ErrorMessage = "The address should have at least 4 characters")]
        [Required(ErrorMessage = "The address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; } = "";

        [RegularExpression(@"\D{2,}", ErrorMessage = "The city should have at least 2 characters")]
        [Required(ErrorMessage = "The city is required")]
        [Display(Name = "City")]
        public string City { get; set; } = "";

        [RegularExpression(@"\w{4,4}\w{3,3}|\w{4,4}\s{1,1}\w{3,3}", ErrorMessage = "The ZipCode should have 7 characters")]
        [Required(ErrorMessage = "The ZipCode is required")]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; } = "";

        [RegularExpression(@"0\d{9}", ErrorMessage = "The Phone Number should have the format 0XXXXXXXXX Whitout spaces")]
        [Required(ErrorMessage = "The mobile number is required")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; } = "";

        [RegularExpression(@"0\d{9}", ErrorMessage = "The Phone Number should have the format 0XXXXXXXXX Whitout spaces")]
        [Display(Name = "Second Contact Number")]
        public string SecondContactNumber { get; set; } = "";

        [Required(ErrorMessage = "The e-mail is required")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Second E-mail")]
        [DataType(DataType.EmailAddress)]
        public string SecondEmail { get; set; }

        [Required(ErrorMessage = "Select Full or Part Time")]
        [Display(Name = "Full or Part Time")]
        public string Hours { get; set; }

        [Required(ErrorMessage = "You did not put a date or the date is not valid")]
        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        public bool Monday { get; set; } 
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }

        public string DaysOfWeek { get; set; } = "";
        public string CheckDaysOfWeek { get; set; } = "";
        public decimal TotalDue { get; set; } = 0m;
        public string CheckDateBirth { get; set; } = "";
        public string CheckDateStart { get; set; } = "";
        public string Discount { get; set; } = "";
        public string MessageApplication { get; set; } = "Thank you. Your application has been processed.";
        public decimal DiscountValue { get; set; } = 0m;


        public Student()
        {

        }

        public int MethodTotalDays()
        {
            int numberOfDays = 0;
            if (Monday) numberOfDays += 1;
            if (Tuesday) numberOfDays += 1;
            if (Wednesday) numberOfDays += 1;
            if (Thursday) numberOfDays += 1;
            if (Friday) numberOfDays += 1;

            return numberOfDays;
        }

        public bool MethodDaysOfWeek()
        {
            bool atLeastADay;
            if (Monday == true || Tuesday == true || Wednesday == true || Thursday == true || Friday == true)
            {
                if (Monday) DaysOfWeek += "Monday ";
                if (Tuesday) DaysOfWeek += "Tuesday ";
                if (Wednesday) DaysOfWeek += "Wednesday ";
                if (Thursday) DaysOfWeek += "Thursday ";
                if (Friday) DaysOfWeek += "Friday";
                CheckDaysOfWeek = "";

                if (Hours == "Full Time")
                {
                    TotalDue = MethodTotalDays() * 35m;
                    if (MethodTotalDays() >= 4 && MethodTotalDays() <= 5)
                    {
                        DiscountValue = TotalDue - (TotalDue * 0.9m);
                        TotalDue = TotalDue * 0.9m;
                        Discount = "You got a discount of 10% on the original value";
                    }

                }
                else
                {
                    TotalDue = MethodTotalDays() * 20m;
                    if (MethodTotalDays() >= 4 && MethodTotalDays() <= 5)
                    {
                        DiscountValue = TotalDue - (TotalDue * 0.9m);
                        TotalDue = TotalDue * 0.9m;
                        Discount = "You got a discount of 10% on the original value";
                    }
                }


                atLeastADay = true;
            }

            else
            {
               CheckDaysOfWeek = "You need to select at least a day of the week";
               atLeastADay = false;
            }


            return atLeastADay;
        }

        public bool MethodCheckDateStart()
        {
            bool checkDates = false;
            if (StartingDate > DateTime.Now)
            {
                CheckDateStart = "";
                checkDates = true;
            }
            else
            {
                CheckDateStart = "The date is not valid";
                checkDates = false;
            }
            return checkDates;
        }

        public bool MethodCheckDateBirth()
        {
            bool checkDate = false;
            string birthDate = Convert.ToString(DateOfBirth);
            string starDating = Convert.ToString(StartingDate);
            TimeSpan date = Convert.ToDateTime(starDating) - Convert.ToDateTime(birthDate);
            int Days = date.Days;

            if (Days >= 1095 && Days <= 1825)
            {
                checkDate = true;
                CheckDateBirth = "";
            }
            else
            {
                checkDate = false;
                CheckDateBirth = "The date is not valid, the child should be between 3 and 5 years old to start on this date.";

            }


            return checkDate;


        }
    }




}
