using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class Beneficiarie
    {
        public Beneficiarie()
        {
            UploadsComplainte = new List<Compalint>();
            SubmitionProposals = new List<Proposal>();
            BenefCommunications = new List<BenefCommunication>();
            Id = Guid.NewGuid().ToString();

        }
        public string Id { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بتعبئة هذه الحقل")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only.")]
        public string IdentityNumber { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser Admin { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        //[Required(ErrorMessage = "يجب ان تقوم بتعبئة هذه الحقل")]
        //[MaxLength(50,ErrorMessage ="Maximum 12 characters only.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? GovernorateId { get; set; }
        public virtual Governorate Governorate { get; set; }
        public int? DirectorateId { get; set; }
        public virtual Directorate Directorate { get; set; }
        public int? SubDirectorateId { get; set; }
        public virtual SubDirectorate SubDirectorate { get; set; }
        public int? VillageId { get; set; }
        public virtual Village Village { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        [Comment("تحديد وقت ادخال الصف في قاعدية البيانات")]
        //[Timestamp]
        //[Precision(3)]
        public DateTime DateCreated { get; set; }
        public DateTime Update_at { get; set; }
        public virtual ICollection<Compalint> UploadsComplainte { get; set; }
        public int? TypeBeneficiariId { get; set; }
        public virtual TypeBeneficiari TypeBeneficiaris { get; set; }
        public virtual ICollection<BenefCommunication> BenefCommunications { get; set; }
        //Relationships
        public virtual ICollection<Proposal> SubmitionProposals { get; set; }


    }

}
