using ComplantSystem.Models.Benef;
using ComplantSystem.Models.Data.Base;
using System;


namespace ComplantSystem.Models
{
    public class Communication_Counter : IEntityBase
    {
        public Communication_Counter()
        {
            Id = Guid.NewGuid().ToString();
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public int Communic_Counter { get; set; }

        public int BeneficiarieId { get; set; }
        public virtual Beneficiarie Beneficiaries { get; set; }

        public int BenefCommunicationId { get; set; }
        public virtual BenefCommunication BenefCommunications { get; set; }
    }
}
