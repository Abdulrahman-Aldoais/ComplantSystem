using ComplantSystem.Models.Data.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class UsersCommunication : IEntityBase
    {
        public UsersCommunication()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public int BenfId { get; set; }
        public string BenfName { get; set; }
        public string BenfPhoneNumber { get; set; }
        public int BenfGovId { get; set; }
        [ForeignKey("BenfGovId")]
        public virtual Governorate Governorate { get; set; }
        public int BenfDirId { get; set; }
        [ForeignKey("BenfDirId")]
        public virtual Directorate Directorate { get; set; }
        public int BenfSubDirId { get; set; }
        [ForeignKey("BenfSubDirId")]
        public virtual SubDirectorate SubDirectorate { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser UsersHas { get; set; }
        public string UserName { get; set; }
        public string TypeCommuncationId { get; set; }
        [ForeignKey("TypeCommuncationId")]
        public TypeCommunication TypeCommunication { get; set; }
        public string Titile { get; set; }
        public string reason { get; set; }

    }
}