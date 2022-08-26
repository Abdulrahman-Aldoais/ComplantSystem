﻿using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class UploadsComplainte : IEntityBase
    {
        public UploadsComplainte()
        {
            Id = Guid.NewGuid().ToString();
            UploadDate = DateTime.Now;


            //CompalintsHasSolutions = new List<Compalints_Solution>();

        }
        public string Id { set; get; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string TitleComplaint { get; set; }

        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string TypeComplaintId { get; set; }
        public virtual TypeComplaint TypeComplaint { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string DescComplaint { get; set; }
        public int? SocietyId { get; set; }
        public virtual Society Society { get; set; }
        public int StatusCompalintId { get; set; } = 1;
        public virtual StatusCompalint StatusCompalint { get; set; }
        public int StagesComplaintId { get; set; } = 1;
        public virtual StagesComplaint StagesComplaint { get; set; }
        public string PropBeneficiarie { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]
        public virtual int GovernorateId { get; set; }
        [ForeignKey("GovernorateId")]
        public virtual Governorate Governorate { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]

        public virtual int DirectorateId { get; set; }
        [ForeignKey("DirectorateId")]

        public virtual Directorate Directorate { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بختيار المنطقة   ")]

        public virtual int SubDirectorateId { get; set; }
        [ForeignKey("SubDirectorateId")]

        public virtual SubDirectorate SubDirectorate { get; set; }

        //[Required(ErrorMessage = "يجب ان تقوم بإختبار المنطقة المحددة ")]

        public virtual Village Villages { get; set; }

        public virtual ICollection<Compalints_Solution> Compalints_Solutions { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser HoUser { get; set; }
        public string OriginalFileName { get; set; }
        public string FileName { get; set; }
        public decimal Size { get; set; }

        public string ContentType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UploadDate { get; set; }



    }
}
