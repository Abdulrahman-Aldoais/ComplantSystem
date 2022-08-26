using ComplantSystem.Models.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ComplantSystem.Models
{
    public class Proposal:IEntityBase
    {
        public Proposal()
        {
            Id = Guid.NewGuid().ToString();
        }
      

        public string Id { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string TitileProposal { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string DescProposal { get; set; }
        [Comment("تحديد وقت ادخال الصف في قاعدية البيانات")]
        //[Timestamp]

        public DateTime DateSubmeted { get; set; }

        public int BeneficiarieId { get; set; }

        public virtual Beneficiarie Beneficiarie { get; set; }

    }
}
