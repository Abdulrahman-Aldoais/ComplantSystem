using ComplantSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplantSystem
{
    public class AdminUserViewModel
    {
        [Required(ErrorMessage = "ادخل الاسم ")]
        public string FullName { get; set; }
        //[NotMapped]
        //public string FullName { get { return FirstName + " " + LastName; } }
        [Required(ErrorMessage = "ادخل رقم البطاقة الشخصية"), MaxLength(12, ErrorMessage = "يجب ان لا يكون رقم البطاقة اكثر من اثنا عشر ارقام "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        [Remote(action: "CheckingIdentityNumber", controller: "ManageUsers")]
        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "ادخل رقم الهاتف"), MaxLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اكثر من تسعة ارقام "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        [Remote(action: "CheckingPhoneNumber", controller: "ManageUsers")]
        public string PhoneNumber { get; set; }
        public IEnumerable<Governorate> GovernoratesList { get; set; }
        public int GovernorateId { get; set; }
        public int DirectorateId { get; set; }
        public int SubDirectorateId { get; set; }
        public string UserId { get; set; }
        public string OriginatorName { get; set; }
        public int? SocietyId { get; set; }
        //public IEnumerable<string> Roles { get; set; }
        public byte[] ProfilePicture { get; set; }
        [Display(Name = "نوع المستخدم")]
        public int userRoles { get; set; }
        public bool IsBlocked { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "يرجى ادخال كلمة المرور"), RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "صيغة يجب ان تكون كلمة السر ارقام و حروف و رموز")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "يرجى اعادة ادخال كلمة المرور"), Compare("Password", ErrorMessage = "كلمة المرور غير متطابقة")]
        public string PasswordConfirm { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
