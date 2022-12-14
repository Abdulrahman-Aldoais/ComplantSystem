using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class UpComplaintCause
    {
        public UpComplaintCause()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser UserUpComplaint { get; set; }
        public string UploadsComplainteId { get; set; }
        [ForeignKey("UploadsComplainteId")]
        public virtual UploadsComplainte CompalintUp { get; set; }
        public string UpProvName { get; set; }
        public string UpUserProvIdentity { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة الحل المقدم ")]
        public string Cause { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateUp { get; set; } = DateTime.Now;



    }
}
