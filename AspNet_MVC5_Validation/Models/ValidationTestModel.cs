using System;
using System.ComponentModel.DataAnnotations;

namespace AspNet_MVC5_Validation.Models
{
    public class ValidationTestModel
    {
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DateRange("01/01/1970", "30/12/2000")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }


        [PhoneMaskValidation("ddd-ddd-dddd")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

    }
}