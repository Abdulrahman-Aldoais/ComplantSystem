using ComplantSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComplantSystem
{
    public class UserViewModels
    {
        public string FullName { get; set; }

        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Governorate Governorates { get; set; }
        public virtual Directorate Directorates { get; set; }
        public virtual SubDirectorate SubDirectorate { get; set; }
        public virtual Village Village { get; set; }
        public bool IsBlocked { get; set; }

        public string UserId { get; set; }

        public DateTime DateOfBirth { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }



    }
}
