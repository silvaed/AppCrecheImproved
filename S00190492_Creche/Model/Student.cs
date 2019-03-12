using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace S00190492_Creche.Model
{
    public class Student
    {
        [Required(ErrorMessage = "The child first name is required")]
        [RegularExpression(@"\D{2,}", ErrorMessage = "The first name should have at least 2 characters")]
        [Display(Name = "Child First Name")]
        public string ChildFirstName { get; set; } = "";
        [Required(ErrorMessage = "The child last name is required")]
        [RegularExpression(@"\D{2,}", ErrorMessage = "The last name should have at least 2 characters")]
        [Display(Name = "Child Last Name")]
        public string ChildLastName { get; set; } = "";
        [Required(ErrorMessage = "The PPS number is required")]
        [Display(Name = "PPS Number")]
        [Key]
        public string PPS { get; set; } = "";
        [Required(ErrorMessage = "Please  Enter a birth date")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Select a gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "The parent first name is required")]
        [Display(Name = "Parent First Name")]
        public string ParentFirstName { get; set; } = "";
        [Required(ErrorMessage = "The parent last name is required")]
        [Display(Name = "Parent Last Name")]
        public string ParentLastName { get; set; } = "";
        [Required(ErrorMessage = "Select a relationship")]
        [Display(Name = "Relationship")]
        public string RelationshipToChild { get; set; }
        [Required(ErrorMessage = "The address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; } = "";
        [Required(ErrorMessage = "The city is required")]
        [Display(Name = "City")]
        public string City { get; set; } = "";
        [Required(ErrorMessage = "The ZipCode is required")]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; } = "";
        [Required(ErrorMessage = "The mobile number is required")]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"0\d{9}", ErrorMessage = "The Phone Number should have the format 0XXXXXXXXX Whitout spaces")]
        public string MobileNumber { get; set; } = "";
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
        //[Required(ErrorMessage = "Select at least one day of week")]
        //[Display(Name = "Days of Week")]
        //public string[] DaysRequested { get; set; } 
        [Required(ErrorMessage = "The starting date is required")]
        [Display(Name = "Starting Date")]
        public DateTime StartingDate { get; set; }

        public Student()
        {

        }
    }


}
