//using ComplantSystem.Models.Data.Base;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ComplantSystem.Models
//{
//    public class TypeCommunication :IEntityBase
//    {
//        //public TypeCommunication()
//        //{
//        //    Id = Guid.NewGuid().ToString();
//        //}
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; }
//        public string? Name { get; set; }

//        public int? AdminsId { get; set; }
//        public virtual Admins UsersAddType { get; set; }
//        public virtual ICollection<BenefCommunication>? BenefCommunications { get; set; }
//    }
//}
