using ComplantSystem.Models.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class TypeBeneficiari:IEntityBase
    {
        public TypeBeneficiari()
        {
            Id = Guid.NewGuid().ToString();
        }
     
        public string Id { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Type { get; set; }

    }
}
