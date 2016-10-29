using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AspNet_MVC5_Validation.Models
{
    public class User : IEquatable<User>
    {
        private static int id = 0;

        public int Id { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Invalid Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        [Remote("EmailAlreadyExists", "Register", HttpMethod = "POST", ErrorMessage = "Email already Exists")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DateRange("01/01/1970", "31/12/2000")]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Range(1, 4, ErrorMessage = "Please specify a value between 1 and 4")]
        public byte Level { get; set; }


        public User()
        {
            Id = ++id;
        }

        public bool Equals(User other)
        {
            return this.Email.ToLower().Equals(other.Email.ToLower());
        }
    }
}