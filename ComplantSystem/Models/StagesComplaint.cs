using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class StagesComplaint
    {
        //public StagesComplaint()
        //{
        //    Id = Guid.NewGuid().ToString();
        //}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UploadsComplainte> UploadsComplainte { get; set; }

    }
}
