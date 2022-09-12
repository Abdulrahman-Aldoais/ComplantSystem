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
        public virtual int GovernorateId { get; set; }
        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { get; set; }
        public virtual int DirectorateId { get; set; }
        [ForeignKey("DirectorateId")]
        public virtual Directorate Directorate { get; set; }
        public virtual int SubDirectorateId { get; set; }
        [ForeignKey("SubDirectorateId")]
        public virtual SubDirectorate SubDirectorate { get; set; }
        public string UserId { get; set; }
        public string NameUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string UserName { get; set; }
        public virtual string TypeCommuncationId { get; set; }
        [ForeignKey("TypeCommuncationId")]
        public virtual TypeCommunication TypeCommunication { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Titile { get; set; }
        public string reason { get; set; }

    }
}