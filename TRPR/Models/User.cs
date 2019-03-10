using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TRPR.Models
{
    public class User : IdentityUser
    {
        public int UserID { get; set; }

        [PersonalData]
        public string UserFullName { get; set; }

        [PersonalData]
        public string UserFirstName { get; set; }
        [PersonalData]
        public string UserMiddleName { get; set; }
        [PersonalData]
        public string UserLastName { get; set; }

        [PersonalData]
        public string UserEmail { get; set; }

        [PersonalData]
        public DateTime UserDateOfBirth { get; set; }

        [PersonalData]
        public string UserPrefix { get; set; }

        [PersonalData]
        public string UserPhoneNumber { get; set; }


        /*
            [Display(Name = "Email Address")]
            [Required(ErrorMessage = "You must enter a valid email address.")]
            [StringLength(256, ErrorMessage = "Your email address cannot exceed the allowed number of characters.")]
            [DataType(DataType.EmailAddress)]
            public string UserEmail { get; set; }

            [Display(Name = "Password")]
            [Required(ErrorMessage = "You must enter a password.")]
            [StringLength(25, MinimumLength = 8, ErrorMessage = "Your password must be between 8 and 25 characters long.")]
            [DataType(DataType.Password)]
            public string UserPassword { get; set; }

            public DateTime? UserDateCreated { get; set; }

            [Display(Name = "Name")]
            public string UserFullName
            {
                get
                {
                    return UserFirstName +
                        (string.IsNullOrEmpty(UserMiddleName) ? " " :
                        (" " + (char?)UserMiddleName[0] + ". ").ToUpper()) +
                        UserLastName;
                }
            }

            [Display(Name = "First Name")]
            [Required(ErrorMessage = "You need a first name.")]
            [StringLength(30, ErrorMessage = "First name cannot exceed 30 characters.")]
            public string UserFirstName { get; set; }

            [Display(Name = "Middle Name")]
            [StringLength(30, ErrorMessage = "Middle name cannot exceed 30 characters.")]
            public string UserMiddleName { get; set; }

            [Display(Name = "Last Name")]
            [Required(ErrorMessage = "You need a last name.")]
            [StringLength(30, ErrorMessage = "Last name cannot exceed 30 characters.")]
            public string UserLastName { get; set; }

            [Display(Name = "Prefered Prefix")]
            [Required(ErrorMessage = "Please tell us how you'd like to be identified.")]
            public string UserPrefix { get; set; }

            [Display(Name = "Date of Birth")]
            [Required(ErrorMessage = "Please enter your DOB.")]
            [DataType(DataType.Date)]
            public DateTime UserDateOfBirth { get; set; }
        
        [Phone]
        [Display(Name = "Phone Number")]
        public string UserPhoneNumber { get; set; }

     //work on later UserRole {admin, researcher, etc}
     // work on later public string VerificationCode { get; set; }
    //work on later public bool Verified { get; set; } 
        */

    }
}
