using ComplantSystem.Models.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class UsersCommunication:IEntityBase
    {
        public UsersCommunication()
        {
            Id = Guid.NewGuid().ToString();
        }
       
        public string Id { get; set; } 
        public int UserId { get; set; }
        public virtual ApplicationUser UsersHas { get; set; }
        public string Titile { get; set; }
        public string reason { get; set; }
    }
}