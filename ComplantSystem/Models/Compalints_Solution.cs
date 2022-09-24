using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem
{
    public class Compalints_Solution : IEntityBase
    {
        public Compalints_Solution()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        public virtual string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser UserAddSolution { get; set; }
        public string UploadsComplainteId { get; set; }
        [ForeignKey("UploadsComplainteId")]
        public virtual UploadsComplainte CompalintsHasSolution { get; set; }
        public string SolutionProvName { get; set; }
        public string SolutionProvIdentity { get; set; }
        public bool IsAccept { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة الحل المقدم ")]
        public string ContentSolution { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateSolution { get; set; } = DateTime.Now;

    }
}
