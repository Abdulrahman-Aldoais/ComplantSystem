using ComplantSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComplantSystem.Data
{
    public class UsersViewModel
    {

        public string Id { get; set; }

        public string FullName { get; set; }

        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }

        public int GovernorateId { get; set; }
        public virtual Governorate Governorates { get; set; }
        public int DirectorateId { get; set; }
        public virtual Directorate Directorates { get; set; }
        public int SubDirectorateId { get; set; }
        public virtual SubDirectorate SubDirectorate { get; set; }
        public int? VillageId { get; set; }
        public virtual Village Village { get; set; }

        public int? SocietyId { get; set; }
        public virtual Society Societies { get; set; }
        //public IEnumerable<string> Roles { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsBlocked { get; set; }
        [DataType(DataType.Password)]
        public string UserId { get; set; }
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
