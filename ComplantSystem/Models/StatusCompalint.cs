using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class StatusCompalint
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        //RelationShipes one to many with UploadsComplainte and StatusCompalint
        public virtual ICollection<UploadsComplainte> UploadsComplainte { get; set; }
    }
}
