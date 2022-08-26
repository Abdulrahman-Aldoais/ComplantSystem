using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class LimitationOrder:IEntityBase
    {
        public LimitationOrder()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        //public int BeneficiarieId { get; set; }
        //[ForeignKey("Beneficiarie")]
        //public Beneficiarie BeneficiarieInf { get; set; }
        //public int AdminsId { get; set; }
        //public Admins ApplicantUserInfo { get; set; }
        //public int BeneficiarieLiId { get; set; }
        //[ForeignKey("BeneficiarieLiId")]
        //public Beneficiarie BeneficiarieLimit { get; set; }
       
        //public virtual List<Admins> UserLimit { get; set; }
        public int OrderStatus { get; set; }
        public int UserResponsibleId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Reason { get; set; }
      
    }
}