using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class TypeComplaint : IEntityBase
    {
        public TypeComplaint()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required(ErrorMessage = "يجب ان تقوم بكتابة الصنف ")]
        public string Type { get; set; }
        public string UserId { get; set; }
        public string UsersNameAddType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual ICollection<UploadsComplainte> UploadsComplaintes { get; set; }

    }
}
