using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class Society
    {
        public Society()
        {
            //Id = Guid.NewGuid().ToString();
            this.Users = new List<ApplicationUser>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; }
        
        public virtual ICollection<ApplicationUser> Users { get; set; }

      
    }
}
