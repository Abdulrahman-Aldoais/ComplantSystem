﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class ApplicationUser : IdentityUser
    {


        [Required(ErrorMessage = "ادخل الاسم ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "ادخل رقم البطاقة الشخصية"), MaxLength(12, ErrorMessage = "يجب ان لا يكون رقم البطاقة اكثر من اثنا عشر ارقام "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "ادخل رقم الهاتف"), MaxLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اكثر من تسعة ارقام "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        public string PhoneNumber { get; set; }
        public virtual int GovernorateId { get; set; }
        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { get; set; }
        public virtual int DirectorateId { get; set; }
        [ForeignKey("DirectorateId")]
        public virtual Directorate Directorate { get; set; }
        public virtual int SubDirectorateId { get; set; }
        [ForeignKey("SubDirectorateId")]
        public virtual SubDirectorate SubDirectorate { get; set; }
        public virtual ICollection<Compalints_Solution> Compalints_Solutions { get; set; }

        public int? SocietyId { get; set; }
        public virtual Society Societies { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsBlocked { get; set; }
        public string UserId { get; set; }
        public string originatorName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DateOfBirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
        public int RoleId { get; set; }



        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }


    }


}


