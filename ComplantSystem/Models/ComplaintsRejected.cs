using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class ComplaintsRejected
    {
        public ComplaintsRejected()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser UserRejectedComplaint { get; set; }
        public string UploadsComplainteId { get; set; }
        [ForeignKey("UploadsComplainteId")]
        public virtual UploadsComplainte Rejected { get; set; }
        public string RejectedProvName { get; set; }
        public string RejectedUserProvIdentity { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة الحل المقدم ")]
        public string reume { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateSolution { get; set; } = DateTime.Now;
        public virtual ICollection<ComplaintsRejected> ComplaintsRejecteds { get; set; }



    }
}