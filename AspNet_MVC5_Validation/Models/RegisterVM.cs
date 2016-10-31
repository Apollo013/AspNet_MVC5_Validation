using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AspNet_MVC5_Validation.Models
{
    public class RegisterVM : IEquatable<RegisterVM>
    {
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Invalid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Invalid Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        [Remote("EmailAlreadyExists", "User", HttpMethod = "POST", ErrorMessage = "Email already Exists")]
        public string Email { get; set; }

        [Range(1, 4, ErrorMessage = "Please specify a value between 1 and 4")]
        public byte Level { get; set; }


        public bool Equals(RegisterVM other)
        {
            return this.Email.ToLower().Equals(other.Email.ToLower());
        }
    }
}