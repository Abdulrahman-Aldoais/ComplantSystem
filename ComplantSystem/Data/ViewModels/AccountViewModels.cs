using ComplantSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "يرجى ادخال كلمة المرور"), RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "صيغة يجب ان تكون كلمة السر ارقام و حروف و رموز")]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "يرجى ادخال كلمة المرور"), RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "صيغة يجب ان تكون كلمة السر ارقام و حروف و رموز")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "يرجى اعادة ادخال كلمة المرور"), Compare("NewPassword", ErrorMessage = "كلمة المرور غير متطابقة")]
        public string PasswordConfirm { get; set; }
    }



    public class EditUserViewModel
    {
        [Display(Name = " الاسم")]
        [Required(ErrorMessage = "يجب ادخال الاسم كاملا")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "ادخل رقم البطاقة"), MaxLength(12, ErrorMessage = "يجب ان لا يكون رقم البطاقة اكبر من تسعة 12 رقم "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "ادخل رقم الهاتف"), MaxLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اكثر من تسعة ارقام "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        public string PhoneNumber { get; set; }
        //public virtual ApplicationRole Role { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsBlocked { get; set; }
        [Display(Name = "نوع المستخدم")]
        public int UserRoles { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }


    public class UserProfileEditVM
    {
        [Display(Name = " الاسم")]
        [Required(ErrorMessage = "يجب ادخال الاسم كاملا")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "ادخل رقم البطاقة"), MaxLength(12, ErrorMessage = "يجب ان لا يكون رقم البطاقة اكبر من تسعة 12 رقم "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "ادخل رقم الهاتف"), MaxLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اكثر من تسعة ارقام "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        public string PhoneNumber { get; set; }
        //public virtual ApplicationRole Role { get; set; }
        public byte[] ProfilePicture { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

    }

    public class UserViewModels
    {
        public string Id { get; set; }
        public string FullName { get; set; }

        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int GovernorateId { get; set; }
        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorates { get; set; }
        public int DirectorateId { get; set; }
        [ForeignKey("DirectorateId")]

        public virtual Directorate Directorates { get; set; }
        public int SubDirectorateId { get; set; }
        [ForeignKey("SubDirectorateId")]

        public virtual SubDirectorate SubDirectorate { get; set; }

        public bool IsBlocked { get; set; }

        // public string UserId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }



    }

    public class AddUserViewModel
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
