using ComplantSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComplantSystem
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "يجب ادخال رقم البطاقة")]
        [EmailAddress(ErrorMessage = "يرجى كتابة رقم البطاقة بشكل صحيح")]
        [Display(Name = "رقم البطاقة")]

        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "ادخل كلمة المرور ")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "تذكرني")]
        public bool RememberMe { get; set; }
    }


    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        //[Timestamp]
        public DateTime DateCreated { get; set; }
        public ApplicationRole Roles { get; set; }

        public int? GovernorateId { get; set; }

        public int? DirectorateId { get; set; }

        public int? SubDirectorateId { get; set; }
        //[ForeignKey("SubDirectorateId")]

        public int? VillageId { get; set; }
        //[ForeignKey("VillageId")]

        public int SocietyId { get; set; }
        //[ForeignKey("SociId")]

        //public IEnumerable<string> Roles { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsBlocked { get; set; }

        public DateTime CreatedDate { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

}
