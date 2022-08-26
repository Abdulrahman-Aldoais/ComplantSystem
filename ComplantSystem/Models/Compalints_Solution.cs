using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;

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

        public string UserId { get; set; }


        public virtual ApplicationUser UserAddSolution { get; set; }
        public string UploadsComplainteId { get; set; }
        public virtual UploadsComplainte CompalintsHasSolution { get; set; }


        public string ContentSolution { get; set; } = "";
        public DateTime DateSolution { get; set; } = DateTime.Now;

    }
}
